using AutoMapper;

namespace BudgetManagement.Persistence.SqlServer.Mapping.Profiles
{
    public class SalaryEntryProfile : Profile
    {
        public SalaryEntryProfile()
        {
            CreateMap<SalaryEntry, Domain.Entities.SalaryEntry>()
                .ForMember(dest => dest.Events, opt => opt.Ignore())
                .ForMember(dest => dest.Errors, opt => opt.Ignore());

            CreateMap<Domain.Entities.SalaryEntry, SalaryEntry>()
                .ForMember(dest => dest.Incomes, opt => opt.Ignore())
                .ForMember(dest => dest.User, opt => opt.Ignore());
        }
    }
}