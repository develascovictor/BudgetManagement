using BudgetManagement.Application.Services;
using BudgetManagement.Client.SalaryEntry;
using BudgetManagement.Client.Transaction;
using BudgetManagement.Infrastructure;
using BudgetManagement.Persistence.SqlServer;
using BudgetManagement.Service.Api.Modules.Budget;
using BudgetManagement.Service.Api.Modules.Budget.Interfaces;
using BudgetManagement.Service.Api.Modules.Budget.Views;
using System;
using System.Net;
using System.Windows.Forms;

namespace BudgetManagement.Client
{
    public partial class MainForm : Form
    {
        private readonly IBudgetModule _budgetModule;

        public MainForm()
        {
            InitializeComponent();

            _budgetModule = new BudgetModule(new BudgetModuleImpl(new BudgetService(new UnitOfWork(new BudgetManagementEntities()))));
        }

        private async void Reload()
        {
            var request = new SearchBudgetsRequest
            {
                Filter = null,
                Sort = null
            };
            var commandResult = await _budgetModule.SearchBudgetsAsync(request, default);

            if (commandResult.StatusCode == HttpStatusCode.OK)
            {
                gridBudgets.DataSource = commandResult.Result.Resources;
            }
        }

        private void gridBudgets_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var budgetId = (int) gridBudgets.Rows[e.RowIndex].Cells[0].Value;

            var tr = new TransactionsByBudgetForm(budgetId);
            tr.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Reload();
        }

        private void btnAddSalaryEntry_Click(object sender, EventArgs e)
        {
            var sef = new AddSalaryEntryForm();
            sef.Show();
        }
    }
}