using BudgetManagement.Application.Services;
using BudgetManagement.Infrastructure;
using BudgetManagement.Persistence.SqlServer;
using BudgetManagement.Service.Api.Modules.Transaction;
using BudgetManagement.Service.Api.Modules.Transaction.Interfaces;
using BudgetManagement.Service.Api.Modules.Transaction.Views;
using System;
using System.Net;
using System.Windows.Forms;

namespace BudgetManagement.Client
{
    public partial class TransactionsByBudgetForm : Form
    {
        int _budgetId;
        ITransactionModule _transactionModule;

        public TransactionsByBudgetForm(int budgetId)
        {
            InitializeComponent();

            _budgetId = budgetId;
            _transactionModule = new TransactionModule(new TransactionModuleImpl(new TransactionService(new UnitOfWork(new BudgetManagementEntities()))));
        }

        private async void Reload()
        {
            var request = new SearchTransactionsByBudgetIdRequest
            {
                BudgetId = _budgetId,
                Filter = null,
                Sort = "-date"
            };
            var commandResult = await _transactionModule.SearchTransactionsByBudgetIdAsync(request, default);

            if (commandResult.StatusCode == HttpStatusCode.OK)
            {
                gridTransactions.DataSource = commandResult.Result.Resources;
            }
        }

        private void TransactionsByBudgetForm_Load(object sender, EventArgs e)
        {
            Reload();
        }
    }
}