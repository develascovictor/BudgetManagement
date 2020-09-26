using AutoMapper;
using BudgetManagement.Service.Api.Modules.Budget.Models;

namespace BudgetManagement.Service.Api.Modules.Budget.Mapping
{
    public class BudgetDtoProfile : Profile
    {
        public BudgetDtoProfile()
        {
            CreateMap<Domain.Entities.Budget, BudgetDto>();
        }
    }
}