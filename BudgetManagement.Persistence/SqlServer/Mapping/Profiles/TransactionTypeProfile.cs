using AutoMapper;

namespace BudgetManagement.Persistence.SqlServer.Mapping.Profiles
{
    public class TransactionTypeProfile : Profile
    {
        public TransactionTypeProfile()
        {
            CreateMap<TransactionType, Domain.Entities.TransactionType>()
                .ForMember(dest => dest.Events, opt => opt.Ignore())
                .ForMember(dest => dest.Errors, opt => opt.Ignore());

            CreateMap<Domain.Entities.TransactionType, TransactionType>()
                .ForMember(dest => dest.Budget, opt => opt.Ignore())
                .ForMember(dest => dest.Transactions, opt => opt.Ignore());
        }
    }
}