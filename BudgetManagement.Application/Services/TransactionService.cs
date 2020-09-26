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