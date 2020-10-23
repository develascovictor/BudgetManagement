using BudgetManagement.Application.Services;
using BudgetManagement.Infrastructure;
using BudgetManagement.Persistence.SqlServer;
using BudgetManagement.Service.Api.Modules.Budget;
using BudgetManagement.Service.Api.Modules.SalaryEntry;
using BudgetManagement.Service.Api.Modules.SalaryEntry.Interfaces;
using BudgetManagement.Service.Api.Modules.SalaryEntry.Views;
using System;
using System.Net;
using System.Windows.Forms;

namespace BudgetManagement.Client.SalaryEntry
{
    public partial class AddSalaryEntryForm : Form
    {
        private readonly ISalaryEntryModule _salaryEntryModule;

        public AddSalaryEntryForm()
        {
            InitializeComponent();

            var unitOfWork = new UnitOfWork(new BudgetManagementEntities());
            _salaryEntryModule = new SalaryEntryModule(new SalaryEntryModuleImpl(new SalaryEntryService(unitOfWork)));
        }

        private void AddSalaryEntryForm_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (numericAmount.Value <= 0 && numericAmount.Value <= 0)
            {
                return;
            }

            var date = datePickerDate.Value.Date;

            var request = new CreateSalaryEntryRequest
            {
                UserId = 1,
                Date = date,
                Amount = numericAmount.Value,
                Rate = numericRate.Value
            };
            var commandResult = await _salaryEntryModule.CreateSalaryEntryAsync(request, default);

            MessageBox.Show(commandResult.StatusCode == HttpStatusCode.OK ? "SUCCESS" : "ERROR");
        }

        private void numericAmount_ValueChanged(object sender, EventArgs e)
        {
            tbxValue.Text = $"${numericAmount.Value / numericRate.Value}";
        }

        private void numericRate_ValueChanged(object sender, EventArgs e)
        {
            tbxValue.Text = $"${numericAmount.Value / numericRate.Value}";
        }
    }
}
