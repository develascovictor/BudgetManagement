using AutoMapper;
using BudgetManagement.Service.Api.Modules.SalaryEntry.Models;

namespace BudgetManagement.Service.Api.Modules.SalaryEntry.Mapping
{
    public class SalaryIncomeDtoProfile : Profile
    {
        public SalaryIncomeDtoProfile()
        {
            CreateMap<Domain.Entities.SalaryIncome, SalaryIncomeDto>();
        }
    }
}