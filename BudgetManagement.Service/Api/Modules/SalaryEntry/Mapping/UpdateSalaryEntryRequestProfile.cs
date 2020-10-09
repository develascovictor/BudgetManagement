using AutoMapper;
using BudgetManagement.Application.Models;
using BudgetManagement.Service.Api.Modules.SalaryEntry.Views;

namespace BudgetManagement.Service.Api.Modules.SalaryEntry.Mapping
{
    public class UpdateSalaryEntryRequestProfile : Profile
    {
        public UpdateSalaryEntryRequestProfile()
        {
            CreateMap<UpdateSalaryEntryRequest, SalaryEntryUpdateDefinition>();
        }
    }
}