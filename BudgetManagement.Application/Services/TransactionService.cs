using BudgetManagement.Application.Interfaces;
using BudgetManagement.Application.Models;
using BudgetManagement.Domain.Entities;
using BudgetManagement.Domain.Exceptions;
using BudgetManagement.Shared.Pagination.Models;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace BudgetManagement.Application.Services
{
    public class TransactionService : ITransactionService
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private readonly IUnitOfWork _unitOfWork;

        public TransactionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Transaction GetTransactionById(int id)
        {
            var domain = _unitOfWork.TransactionRepository.GetById(id);
            return domain;
        }

        public DataPage<Transaction> SearchTransactionsByBudgetId(int budgetId, string filterOptions, string sortOptions, PageOptions pageOptions)
        {
            var domains = _unitOfWork.TransactionRepository.SearchByBudgetId(budgetId, filterOptions, sortOptions, pageOptions.Index, pageOptions.Limit, out var total).ToList();
            return new DataPage<Transaction>(domains, pageOptions, total);
        }

        public Transaction CreateTransaction(TransactionCreateDefinition transactionCreationDefinition)
        {
            ValidateBudgetAndTransactionTypeId(transactionCreationDefinition.BudgetId, transactionCreationDefinition.TransactionTypeId);

            var expenses = transactionCreationDefinition.Expenses.Where(x => x != null).Select(x => new Expense(0, 0, x.Date, x.Amount, x.Rate, DateTime.Now, DateTime.Now)).ToList();
            var incomes = transactionCreationDefinition.Incomes.Where(x => x != null).Select(x => new Income(0, 0, null, x.Date, x.Amount, x.Rate, DateTime.Now, DateTime.Now)).ToList();

            ValidateDate(transactionCreationDefinition.Date, expenses, incomes);

            if (incomes.Any(x => x.SalaryEntryId != null))
            {
                var salaryEntryIds = incomes.Where(x => x.SalaryEntryId != null).Select(x => (int) x.SalaryEntryId).ToList();

                if (salaryEntryIds.Count != 1)
                {
                    //TODO: Invalid operation
                    throw new Exception();
                }

                var salaryEntryId = salaryEntryIds.Single();
                var salaryEntry = _unitOfWork.SalaryEntryRepository.GetById(salaryEntryId);

                if (salaryEntry == null)
                {
                    throw new SalaryEntryNotFoundException(salaryEntryId);
                }
            }

            var domain = new Transaction
            (
                0,
                transactionCreationDefinition.BudgetId,
                transactionCreationDefinition.TransactionTypeId,
                transactionCreationDefinition.Date,
                transactionCreationDefinition.Description,
                transactionCreationDefinition.Notes,
                DateTime.Now,
                DateTime.Now,
                expenses,
                incomes
            );

            var createdDomain = _unitOfWork.TransactionRepository.Create(domain);

            _unitOfWork.SaveChanges();

            return createdDomain;
        }

        public Transaction CreateTransaction(SalaryEntryTransactionCreateDefinition salaryEntryTransactionCreateDefinition)
        {
            ValidateBudgetAndTransactionTypeId(salaryEntryTransactionCreateDefinition.BudgetId, null);

            var salaryEntry = _unitOfWork.SalaryEntryRepository.GetById(salaryEntryTransactionCreateDefinition.SalaryEntryId);

            if (salaryEntry == null)
            {
                throw new SalaryEntryNotFoundException(salaryEntryTransactionCreateDefinition.SalaryEntryId);
            }

            var income = new Income
            (
                0,
                0,
                salaryEntryTransactionCreateDefinition.SalaryEntryId,
                salaryEntryTransactionCreateDefinition.Date,
                salaryEntryTransactionCreateDefinition.Amount,
                salaryEntryTransactionCreateDefinition.Rate,
                DateTime.Now,
                DateTime.Now
            );
            var domain = new Transaction
            (
                0,
                salaryEntryTransactionCreateDefinition.BudgetId,
                null,
                salaryEntryTransactionCreateDefinition.Date,
                "Salary",
                null,
                DateTime.Now,
                DateTime.Now,
                null,
                new List<Income> { income }
            );

            var createdDomain = _unitOfWork.TransactionRepository.Create(domain);

            _unitOfWork.SaveChanges();

            return createdDomain;
        }

        public Transaction UpdateTransaction(int id, TransactionUpdateDefinition transactionUpdateDefinition)
        {
            var transaction = _unitOfWork.TransactionRepository.GetById(id);

            if (transaction == null)
            {
                throw new TransactionNotFoundException(id);
            }

            ValidateBudgetAndTransactionTypeId(transaction.BudgetId, transactionUpdateDefinition.TransactionTypeId);

            //TODO: Determine if this goes on domain instead
            if (transactionUpdateDefinition.Date != null)
            {
                ValidateDate((DateTime) transactionUpdateDefinition.Date, transaction.Expenses, transaction.Incomes);
            }

            transaction
                .UpdateTransactionTypeId(transactionUpdateDefinition.TransactionTypeId)
                .UpdateDate(transactionUpdateDefinition.Date)
                .UpdateDescription(transactionUpdateDefinition.Description)
                .UpdateNotes(transactionUpdateDefinition.Notes);

            var updatedTransaction = _unitOfWork.TransactionRepository.Update(transaction);
            _unitOfWork.SaveChanges();

            return updatedTransaction;
        }

        public void DeleteTransaction(int id)
        {
            var transaction = _unitOfWork.TransactionRepository.GetById(id);

            if (transaction == null)
            {
                throw new TransactionNotFoundException(id);
            }

            if (transaction.Expenses.Any())
            {
                _unitOfWork.ExpenseRepository.Delete(transaction.Expenses);
            }

            if (transaction.Incomes.Any())
            {
                _unitOfWork.IncomeRepository.Delete(transaction.Incomes);
            }

            _unitOfWork.TransactionRepository.Delete(transaction);
            _unitOfWork.SaveChanges();
        }

        private void ValidateBudgetAndTransactionTypeId(int budgetId, int? transactionTypeId)
        {
            var budget = _unitOfWork.BudgetRepository.GetById(budgetId);

            if (budget == null)
            {
                throw new BudgetNotFoundException(budgetId);
            }

            if (transactionTypeId == null)
            {
                if (budget.HasTypes)
                {
                    //TODO:
                }
            }

            else
            {
                var transactionTypeIdAsInt = transactionTypeId ?? 0;
                var transactionType = _unitOfWork.TransactionTypeRepository.GetById(transactionTypeIdAsInt);

                if (transactionType == null)
                {
                    throw new TransactionTypeNotFoundException(transactionTypeIdAsInt);
                }
            }
        }

        private static void ValidateDate(DateTime date, IEnumerable<Expense> expenses, IEnumerable<Income> incomes)
        {
            if (expenses.Any(x => x.Date.Date < date.Date))
            {
                //TODO:
            }

            if (incomes.Any(x => x.Date.Date < date.Date))
            {
                //TODO:
            }
        }

        public Expense CreateExpense(ExpenseCreateDefinition expenseCreateDefinition)
        {
            var transaction = _unitOfWork.TransactionRepository.GetById(expenseCreateDefinition.TransactionId);

            if (transaction == null)
            {
                throw new TransactionNotFoundException(expenseCreateDefinition.TransactionId);
            }

            //TODO: Add validation if transaction does not contain an income with salary entry ID

            var domain = new Expense
            (
                0,
                expenseCreateDefinition.TransactionId,
                expenseCreateDefinition.Date,
                expenseCreateDefinition.Amount,
                expenseCreateDefinition.Rate,
                DateTime.Now,
                DateTime.Now
            );
            domain = _unitOfWork.ExpenseRepository.Create(domain);

            _unitOfWork.SaveChanges();

            return domain;
        }

        public Expense UpdateExpense(int id, ExpenseUpdateDefinition expenseUpdateDefinition)
        {
            var expense = _unitOfWork.ExpenseRepository.GetById(id);

            if (expense == null)
            {
                throw new ExpenseNotFoundException(id);
            }

            var transaction = _unitOfWork.TransactionRepository.GetById(expense.TransactionId);

            if (transaction.Date > expenseUpdateDefinition.Date)
            {
                //TOD:
            }

            expense
                .UpdateDate(expenseUpdateDefinition.Date)
                .UpdateAmount(expenseUpdateDefinition.Amount)
                .UpdateRate(expenseUpdateDefinition.Rate);

            var updatedExpense = _unitOfWork.ExpenseRepository.Update(expense);
            _unitOfWork.SaveChanges();

            return updatedExpense;
        }

        public Income CreateIncome(IncomeCreateDefinition incomeCreateDefinition)
        {
            var transaction = _unitOfWork.TransactionRepository.GetById(incomeCreateDefinition.TransactionId);

            if (transaction == null)
            {
                throw new TransactionNotFoundException(incomeCreateDefinition.TransactionId);
            }

            //TODO: Add validation if transaction does not contain an income with salary entry ID

            var domain = new Income
            (
                0,
                incomeCreateDefinition.TransactionId,
                null,
                incomeCreateDefinition.Date,
                incomeCreateDefinition.Amount,
                incomeCreateDefinition.Rate,
                DateTime.Now,
                DateTime.Now
            );
            domain = _unitOfWork.IncomeRepository.Create(domain);

            _unitOfWork.SaveChanges();

            return domain;
        }

        public Income UpdateIncome(int id, IncomeUpdateDefinition incomeUpdateDefinition)
        {
            var income = _unitOfWork.IncomeRepository.GetById(id);

            if (income == null)
            {
                throw new IncomeNotFoundException(id);
            }

            var transaction = _unitOfWork.TransactionRepository.GetById(income.TransactionId);

            if (transaction.Date > incomeUpdateDefinition.Date)
            {
                //TOD:
            }

            income
                .UpdateDate(incomeUpdateDefinition.Date)
                .UpdateAmount(incomeUpdateDefinition.Amount)
                .UpdateRate(incomeUpdateDefinition.Rate);

            var updatedIncome = _unitOfWork.IncomeRepository.Update(income);
            _unitOfWork.SaveChanges();

            return updatedIncome;
        }
    }
}