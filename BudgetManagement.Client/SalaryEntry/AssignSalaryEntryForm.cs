using BudgetManagement.Application.Services;
using BudgetManagement.Infrastructure;
using BudgetManagement.Persistence.SqlServer;
using BudgetManagement.Service.Api.Modules.SalaryEntry;
using BudgetManagement.Service.Api.Modules.SalaryEntry.Interfaces;
using System;
using System.Windows.Forms;

namespace BudgetManagement.Client.SalaryEntry
{
    public partial class AssignSalaryEntryForm : Form
    {
        private readonly int _salaryEntryId;
        private readonly ISalaryEntryModule _salaryEntryModule;

        public AssignSalaryEntryForm(int salaryEntryId)
        {
            InitializeComponent();

            _salaryEntryId = salaryEntryId;
            _salaryEntryModule = new SalaryEntryModule(new SalaryEntryModuleImpl(new SalaryEntryService(new UnitOfWork(new BudgetManagementEntities()))));
        }

        private void AssignSalaryEntryForm_Load(object sender, EventArgs e)
        {
        }

        private async void Reload()
        {
            var request = new SearchTransactionsByBudgetIdRequest
            {
                BudgetId = _budgetId,
                Filter = null,
                Sort = "-date"
            };
            var commandResult = await _salaryEntryModule.(request, default);

            if (commandResult.StatusCode == HttpStatusCode.OK)
            {
                gridTransactions.DataSource = commandResult.Result.Resources;
            }
        }
    }
}
