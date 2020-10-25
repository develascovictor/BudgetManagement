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
using BudgetManagement.Service.Api.Modules.Transaction;
using BudgetManagement.Service.Api.Modules.Transaction.Interfaces;
using BudgetManagement.Service.Api.Modules.Transaction.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        private readonly ITransactionModule _transactionModule;

        public AssignSalaryEntryForm(int salaryEntryId)
        {
            InitializeComponent();

            _salaryEntryId = salaryEntryId;

            var unitOfWork = new UnitOfWork(new BudgetManagementEntities(true));
            _budgetModule = new BudgetModule(new BudgetModuleImpl(new BudgetService(unitOfWork)));
            _salaryEntryModule = new SalaryEntryModule(new SalaryEntryModuleImpl(new SalaryEntryService(unitOfWork)));
            _transactionModule = new TransactionModule(new TransactionModuleImpl(new TransactionService(unitOfWork)));
        }

        private void AssignSalaryEntryForm_Load(object sender, EventArgs e)
        {
            GetBudgets();
            GetSalaryEntry();
        }

        private void RefreshAvailableLabel()
        {
            var used = _salaryEntry.Incomes.Sum(x => x.Value);
            lblAvailable.Text = $@"${(_salaryEntry.Value - used)}";
        }

        private async void GetBudgets()
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

                cbxBudgets.DataSource = _budgets;
                cbxBudgets.DisplayMember = nameof(BudgetDto.Name);
                cbxBudgets.ValueMember = nameof(BudgetDto.Id);
            }
        }

        private async void GetSalaryEntry()
        {
            var request = new GetSalaryEntryByIdRequest
            {
                Id = _salaryEntryId
            };
            var commandResult = await _salaryEntryModule.GetSalaryEntryByIdAsync(request, default);

            if (commandResult.StatusCode == HttpStatusCode.OK)
            {
                _salaryEntry = commandResult.Result;
                RefreshAvailableLabel();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            var request = new CreateSalaryEntryTransactionRequest
            {
                SalaryEntryId = _salaryEntryId,
                BudgetId = (int) cbxBudgets.SelectedValue,
                Date = _salaryEntry.Date,
                Amount = numericValue.Value,
                Rate = _salaryEntry.Rate
            };
            var commandResult = await _transactionModule.CreateTransactionAsync(request, default);

            if (commandResult.StatusCode == HttpStatusCode.OK)
            {
                //var transaction = commandResult.Result.;
                //_salaryEntry.Incomes.Add(new SalaryIncomeDto
                //{
                //    Id = 0,
                //    TransactionId = 0,
                //    SalaryEntryId = null,
                //    Date = default,
                //    Amount = 0,
                //    Rate = 0,
                //    Value = 0,
                //    TransactionDescription = null,
                //    BudgetId = 0,
                //    BudgetName = null
                //});

                RefreshAvailableLabel();
            }
        }
    }
}
