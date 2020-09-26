using AutoMapper;
using BudgetManagement.Service.Api.Modules.Transaction.Models;

namespace BudgetManagement.Service.Api.Modules.Transaction.Mapping
{
    public class TransactionDtoProfile : Profile
    {
        public TransactionDtoProfile()
        {
            CreateMap<Domain.Entities.Transaction, TransactionDto>();
        }
    }
}