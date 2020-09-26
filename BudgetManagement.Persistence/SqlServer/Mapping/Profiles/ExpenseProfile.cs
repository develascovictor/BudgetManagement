using AutoMapper;

namespace BudgetManagement.Persistence.SqlServer.Mapping.Profiles
{
    public class ExpenseProfile : Profile
    {
        public ExpenseProfile()
        {
            CreateMap<Expense, Domain.Entities.Expense>()
                .ForMember(dest => dest.Events, opt => opt.Ignore())
                .ForMember(dest => dest.Errors, opt => opt.Ignore());

            CreateMap<Domain.Entities.Expense, Expense>()
                .ForMember(dest => dest.Transaction, opt => opt.Ignore())
                .ForMember(dest => dest.Transfers, opt => opt.Ignore());
        }
    }
}