using AutoMapper;

namespace BudgetManagement.Persistence.SqlServer.Mapping.Profiles
{
    public class TransactionProfile : Profile
    {
        public TransactionProfile()
        {
            CreateMap<Transaction, Domain.Entities.Transaction>()
                .ForMember(dest => dest.Events, opt => opt.Ignore())
                .ForMember(dest => dest.Errors, opt => opt.Ignore());

            CreateMap<Domain.Entities.Transaction, Transaction>()
                .ForMember(dest => dest.Budget, opt => opt.Ignore())
                .ForMember(dest => dest.Expenses, opt => opt.Ignore())
                .ForMember(dest => dest.Incomes, opt => opt.Ignore())
                .ForMember(dest => dest.TransactionType, opt => opt.Ignore());
        }
    }
}