using BudgetManagement.Application.Services;
using BudgetManagement.Infrastructure;
using BudgetManagement.Persistence.SqlServer;
using BudgetManagement.Service.Api.Modules.Budget;
using BudgetManagement.Service.Api.Modules.Budget.Interfaces;
using BudgetManagement.Service.Api.Modules.Budget.Models;
using BudgetManagement.Service.Api.Modules.Budget.Views;
using BudgetManagement.Service.Api.Modules.SalaryEntry;
using BudgetManagement.Service.Api.Modules.SalaryEntry.Interfaces;
using BudgetManagement.Service.Api.Modules.SalaryEntry.Models;
using BudgetManagement.Service.Api.Modules.SalaryEntry.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BudgetManagement.Client.SalaryEntry
{
    public partial class AssignSalaryEntryForm : Form
    {
        private SalaryEntryDto _salaryEntry;
        private IReadOnlyCollection<BudgetDto> _budgets;

        private readonly int _salaryEntryId;
        private readonly IBudgetModule _budgetModule;
        private readonly ISalaryEntryModule _salaryEntryModule;

        public AssignSalaryEntryForm(int salaryEntryId)
        {
            InitializeComponent();

            _salaryEntryId = salaryEntryId;

            var unitOfWork = new UnitOfWork(new BudgetManagementEntities());
            _budgetModule = new BudgetModule(new BudgetModuleImpl(new BudgetService(unitOfWork)));
            _salaryEntryModule = new SalaryEntryModule(new SalaryEntryModuleImpl(new SalaryEntryService(unitOfWork)));
        }

        private async void AssignSalaryEntryForm_Load(object sender, EventArgs e)
        {
            await GetBudgets();
            await GetSalaryEntry();

            var used = _salaryEntry.Incomes.Sum(x => x.Value);

            lblAvailable.Text = $@"${(_salaryEntry.Value - used)}";
        }

        private async Task GetBudgets()
        {
            var request = new SearchBudgetsRequest
            {
                Filter = null,
                Sort = null
            };
            var commandResult = await _budgetModule.SearchBudgetsAsync(request, default);

            if (commandResult.StatusCode == HttpStatusCode.OK)
            {
                _budgets = commandResult.Result.Resources;
            }
        }

        private async Task GetSalaryEntry()
        {
            var request = new GetSalaryEntryByIdRequest
            {
                Id = _salaryEntryId
            };
            var commandResult = await _salaryEntryModule.GetSalaryEntryByIdAsync(request, default);

            if (commandResult.StatusCode == HttpStatusCode.OK)
            {
                _salaryEntry = commandResult.Result;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }
    }
}
