using AutoMapper;
using BudgetManagement.Service.Api.Modules.SalaryEntry.Models;

namespace BudgetManagement.Service.Api.Modules.SalaryEntry.Mapping
{
    public class SalaryEntryDtoProfile : Profile
    {
        public SalaryEntryDtoProfile()
        {
            CreateMap<Domain.Entities.SalaryEntry, SalaryEntryDto>();
        }
    }
}