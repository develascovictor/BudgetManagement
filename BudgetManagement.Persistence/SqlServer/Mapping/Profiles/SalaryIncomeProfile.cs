using AutoMapper;

namespace BudgetManagement.Persistence.SqlServer.Mapping.Profiles
{
    public class SalaryIncomeProfile : Profile
    {
        public SalaryIncomeProfile()
        {
            CreateMap<Income, Domain.Entities.SalaryIncome>()
                .ForMember(dest => dest.BudgetId, opt => opt.MapFrom(x => x.Transaction.BudgetId))
                .ForMember(dest => dest.BudgetName, opt => opt.MapFrom(x => x.Transaction.Budget.Name));

            CreateMap<Domain.Entities.SalaryIncome, Income>()
                .ForMember(dest => dest.CreatedOn, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedOn, opt => opt.Ignore())
                .ForMember(dest => dest.SalaryEntry, opt => opt.Ignore())
                .ForMember(dest => dest.Transaction, opt => opt.Ignore())
                .ForMember(dest => dest.Transfers, opt => opt.Ignore());
        }
    }
}