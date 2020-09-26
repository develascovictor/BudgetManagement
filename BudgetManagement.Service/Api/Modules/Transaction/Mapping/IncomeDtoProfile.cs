using AutoMapper;
using BudgetManagement.Service.Api.Modules.Transaction.Models;

namespace BudgetManagement.Service.Api.Modules.Transaction.Mapping
{
    public class IncomeDtoProfile : Profile
    {
        public IncomeDtoProfile()
        {
            CreateMap<Domain.Entities.Income, IncomeDto>();
        }
    }
}