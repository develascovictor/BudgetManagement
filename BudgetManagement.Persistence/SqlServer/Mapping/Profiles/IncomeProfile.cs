using AutoMapper;

namespace BudgetManagement.Persistence.SqlServer.Mapping.Profiles
{
    public class IncomeProfile : Profile
    {
        public IncomeProfile()
        {
            CreateMap<Income, Domain.Entities.Income>()
                .ForMember(dest => dest.Events, opt => opt.Ignore())
                .ForMember(dest => dest.Errors, opt => opt.Ignore());

            CreateMap<Domain.Entities.Income, Income>()
                .ForMember(dest => dest.SalaryEntry, opt => opt.Ignore())
                .ForMember(dest => dest.Transaction, opt => opt.Ignore())
                .ForMember(dest => dest.Transfers, opt => opt.Ignore());
        }
    }
}