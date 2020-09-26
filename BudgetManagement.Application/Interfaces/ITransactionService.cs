using BudgetManagement.Application.Models;
using BudgetManagement.Domain.Entities;
using BudgetManagement.Shared.Pagination.Models;

namespace BudgetManagement.Application.Interfaces
{
    public interface ITransactionService
    {
        Transaction GetTransactionById(int id);
        DataPage<Transaction> SearchTransactionsByBudgetId(int budgetId, string filterOptions, string sortOptions, PageOptions pageOptions);
        Expense CreateExpense(ExpenseCreateDefinition expenseCreateDefinition);
        Income CreateIncome(IncomeCreateDefinition incomeCreateDefinition);
    }
}