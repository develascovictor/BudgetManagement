using AutoMapper;

namespace BudgetManagement.Persistence.SqlServer.Mapping.Profiles
{
    public class BudgetProfile : Profile
    {
        public BudgetProfile()
        {
            CreateMap<Budget, Domain.Entities.Budget>()
                .ForMember(dest => dest.Events, opt => opt.Ignore())
                .ForMember(dest => dest.Errors, opt => opt.Ignore());

            CreateMap<Domain.Entities.Budget, Budget>()
                .ForMember(dest => dest.Transactions, opt => opt.Ignore())
                .ForMember(dest => dest.TransactionTypes, opt => opt.Ignore())
                .ForMember(dest => dest.User, opt => opt.Ignore());
       }
    }
}