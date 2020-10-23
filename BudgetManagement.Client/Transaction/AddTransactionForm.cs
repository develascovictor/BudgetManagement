using BudgetManagement.Application.Services;
using BudgetManagement.Infrastructure;
using BudgetManagement.Persistence.SqlServer;
using BudgetManagement.Service.Api.Modules.Transaction;
using BudgetManagement.Service.Api.Modules.Transaction.Interfaces;
using BudgetManagement.Service.Api.Modules.Transaction.Views;
using BudgetManagement.Service.Api.Modules.TransactionType;
using BudgetManagement.Service.Api.Modules.TransactionType.Interfaces;
using BudgetManagement.Service.Api.Modules.TransactionType.Models;
using BudgetManagement.Service.Api.Modules.TransactionType.Views;
using System;
using System.Collections.Generic;
using System.Net;
using System.Windows.Forms;

namespace BudgetManagement.Client.Transaction
{
    public partial class AddTransactionForm : Form
    {
        private readonly int _budgetId;
        private readonly ITransactionModule _transactionModule;
        private readonly ITransactionTypeModule _transactionTypeModule;

        public AddTransactionForm(int budgetId)
        {
            InitializeComponent();

            _budgetId = budgetId;

            var unitOfWork = new UnitOfWork(new BudgetManagementEntities());
            _transactionModule = new TransactionModule(new TransactionModuleImpl(new TransactionService(unitOfWork)));
            _transactionTypeModule = new TransactionTypeModule(new TransactionTypeModuleImpl(new TransactionTypeService(unitOfWork)));
        }

        private async void LoadTransactionTypes()
        {
            var request = new GetTransactionTypesByBudgetIdRequest
            {
                BudgetId = _budgetId
            };
            var commandResult = await _transactionTypeModule.GetTransactionTypesByBudgetIdAsync(request, default);

            if (commandResult.StatusCode == HttpStatusCode.OK)
            {
                ddlTransactionType.ValueMember = null;
                ddlTransactionType.DisplayMember = "Name";
                ddlTransactionType.DataSource = commandResult.Result;
            }
        }

        private void AddTransactionForm_Load(object sender, EventArgs e)
        {
            LoadTransactionTypes();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (numericExpenseAmount.Value <= 0 && numericIncomeAmount.Value <= 0)
            {
                return;
            }

            var transactionType = (TransactionTypeDto) ddlTransactionType.SelectedItem;
            var date = datePickerDate.Value.Date;

            var request = new CreateTransactionRequest
            {
                BudgetId = _budgetId,
                TransactionTypeId = transactionType.Id,
                Date = date,
                Description = tbxDescription.Text,
                Notes = tbxNotes.Text,
                Expenses =
                    numericExpenseAmount.Value > 0
                    ? new List<CreateExpenseRequest> { new CreateExpenseRequest { Date = date, Amount = numericExpenseAmount.Value, Rate = numericExpenseRate.Value } }
                    : null,
                Incomes =
                    numericIncomeAmount.Value > 0
                    ? new List<CreateIncomeRequest> { new CreateIncomeRequest { Date = date, Amount = numericIncomeAmount.Value, Rate = numericIncomeRate.Value } }
                    : null,
            };
            var commandResult = await _transactionModule.CreateTransactionAsync(request, default);

            MessageBox.Show(commandResult.StatusCode == HttpStatusCode.OK ? "SUCCESS" : "ERROR");
        }

        private void numericExpenseAmount_ValueChanged(object sender, EventArgs e)
        {
            tbxExpenseValue.Text = $"${numericExpenseAmount.Value / numericExpenseRate.Value}";
        }

        private void numericExpenseRate_ValueChanged(object sender, EventArgs e)
        {
            tbxExpenseValue.Text = $"${numericExpenseAmount.Value / numericExpenseRate.Value}";
        }

        private void numericIncomeAmount_ValueChanged(object sender, EventArgs e)
        {
            tbxIncomeValue.Text = $"${numericIncomeAmount.Value / numericIncomeRate.Value}";
        }

        private void numericIncomeRate_ValueChanged(object sender, EventArgs e)
        {
            tbxIncomeValue.Text = $"${numericIncomeAmount.Value / numericIncomeRate.Value}";
        }
    }
}