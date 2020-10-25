using BudgetManagement.Application.Services;
using BudgetManagement.Infrastructure;
using BudgetManagement.Persistence.SqlServer;
using BudgetManagement.Service.Api.Modules.SalaryEntry;
using BudgetManagement.Service.Api.Modules.SalaryEntry.Interfaces;
using BudgetManagement.Service.Api.Modules.SalaryEntry.Views;
using System;
using System.Net;
using System.Windows.Forms;

namespace BudgetManagement.Client.SalaryEntry
{
    public partial class SalaryEntriesForm : Form
    {
        private readonly ISalaryEntryModule _salaryEntryModule;

        public SalaryEntriesForm()
        {
            InitializeComponent();

            _salaryEntryModule = new SalaryEntryModule(new SalaryEntryModuleImpl(new SalaryEntryService(new UnitOfWork(new BudgetManagementEntities()))));
        }

        private void SalaryEntriesForm_Load(object sender, EventArgs e)
        {
            Reload();
        }

        private async void Reload()
        {
            var request = new SearchSalaryEntriesRequest
            {
                Filter = null,
                Sort = null
            };
            var commandResult = await _salaryEntryModule.SearchSalaryEntriesAsync(request, default);

            if (commandResult.StatusCode == HttpStatusCode.OK)
            {
                gridSalaryEntries.DataSource = commandResult.Result.Resources;
            }
        }

        private void btnAddSalaryEntry_Click(object sender, EventArgs e)
        {
            var sef = new AddSalaryEntryForm();
            sef.Show();
        }

        private void gridSalaryEntries_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var salaryEntryId = (int)gridSalaryEntries.Rows[e.RowIndex].Cells[0].Value;
            var ase = new AssignSalaryEntryForm(salaryEntryId);
            ase.Show();
        }
    }
}