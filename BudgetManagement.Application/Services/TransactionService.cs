using BudgetManagement.Application.Interfaces;
using BudgetManagement.Application.Models;
using BudgetManagement.Domain.Entities;
using BudgetManagement.Domain.Exceptions;
using BudgetManagement.Shared.Pagination.Models;
using log4net;
using System;
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
            var budget = _unitOfWork.BudgetRepository.GetById(transactionCreationDefinition.BudgetId);

            if (budget == null)
            {
                throw new BudgetNotFoundException(transactionCreationDefinition.BudgetId);
            }

            if (transactionCreationDefinition.TransactionTypeId == null)
            {
                if (budget.HasTypes)
                {
                    //TODO:
                }
            }

            else
            {
                var transactionTypeId = transactionCreationDefinition.TransactionTypeId ?? 0;
                var transactionType = _unitOfWork.TransactionTypeRepository.GetById(transactionTypeId);

                if (transactionType == null)
                {
                    throw new TransactionTypeNotFoundException(transactionTypeId);
                }
            }

            var expenses = transactionCreationDefinition.Expenses.Where(x => x != null).Select(x => new Expense(0, 0, x.Date, x.Amount, x.Rate, DateTime.Now, DateTime.Now)).ToList();
            var incomes = transactionCreationDefinition.Incomes.Where(x => x != null).Select(x => new Income(0, 0, null, x.Date, x.Amount, x.Rate, DateTime.Now, DateTime.Now)).ToList();

            if (expenses.Any(x => x.Date.Date < transactionCreationDefinition.Date.Date))
            {
                //TODO:
            }

            if (incomes.Any(x => x.Date.Date < transactionCreationDefinition.Date.Date))
            {
                //TODO:
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
            domain = _unitOfWork.TransactionRepository.Create(domain);

            _unitOfWork.SaveChanges();

            return domain;
        }

        public Expense CreateExpense(ExpenseCreateDefinition expenseCreateDefinition)
        {
            var transaction = _unitOfWork.TransactionRepository.GetById(expenseCreateDefinition.TransactionId);

            if (transaction == null)
            {
                throw new TransactionNotFoundException(expenseCreateDefinition.TransactionId);
            }

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

        public Income CreateIncome(IncomeCreateDefinition incomeCreateDefinition)
        {
            var transaction = _unitOfWork.TransactionRepository.GetById(incomeCreateDefinition.TransactionId);

            if (transaction == null)
            {
                throw new TransactionNotFoundException(incomeCreateDefinition.TransactionId);
            }

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
    }
}