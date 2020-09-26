using AutoMapper;
using BudgetManagement.Service.Api.Modules.TransactionType.Models;

namespace BudgetManagement.Service.Api.Modules.TransactionType.Mapping
{
    public class TransactionTypeDtoProfile : Profile
    {
        public TransactionTypeDtoProfile()
        {
            CreateMap<Domain.Entities.TransactionType, TransactionTypeDto>();
        }
    }
}