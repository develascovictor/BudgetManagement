using BudgetManagement.Application.Models;
using BudgetManagement.Domain.Entities;
using BudgetManagement.Shared.Pagination.Models;

namespace BudgetManagement.Application.Interfaces
{
    public interface ITransactionService
    {
        Transaction GetTransactionById(int id);
        DataPage<Transaction> SearchTransactionsByBudgetId(int budgetId, string filterOptions, string sortOptions, PageOptions pageOptions);
        Transaction CreateTransaction(TransactionCreateDefinition transactionCreationDefinition);
        Transaction CreateTransaction(SalaryEntryTransactionCreateDefinition salaryEntryTransactionCreateDefinition);
        Transaction UpdateTransaction(int id, TransactionUpdateDefinition transactionUpdateDefinition);
        void DeleteTransaction(int id);
        Expense CreateExpense(ExpenseCreateDefinition expenseCreateDefinition);
        Expense UpdateExpense(int id, ExpenseUpdateDefinition expenseUpdateDefinition);
        void DeleteExpense(int id);
        Income CreateIncome(IncomeCreateDefinition incomeCreateDefinition);
        Income UpdateIncome(int id, IncomeUpdateDefinition incomeUpdateDefinition);
        void DeleteIncome(int id);
    }
}