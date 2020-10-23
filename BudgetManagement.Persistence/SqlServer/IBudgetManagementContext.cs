using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace BudgetManagement.Persistence.SqlServer
{
    public interface IBudgetManagementContext : IDisposable
    {
        DbSet<AuditLog> AuditLogs { get; set; }
        DbSet<Budget> Budgets { get; set; }
        DbSet<Expense> Expenses { get; set; }
        DbSet<Income> Incomes { get; set; }
        DbSet<SalaryEntry> SalaryEntries { get; set; }
        DbSet<Transaction> Transactions { get; set; }
        DbSet<TransactionType> TransactionTypes { get; set; }
        DbSet<Transfer> Transfers { get; set; }
        DbSet<User> Users { get; set; }
        
        DbSet Set(Type entityType);
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        int SaveChanges();
    }
}