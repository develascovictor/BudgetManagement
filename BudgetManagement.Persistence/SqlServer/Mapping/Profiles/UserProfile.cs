using AutoMapper;

namespace BudgetManagement.Persistence.SqlServer.Mapping.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, Domain.Entities.User>();

            CreateMap<Domain.Entities.User, User>()
                .ForMember(dest => dest.CreatedOn, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedOn, opt => opt.Ignore())
                .ForMember(dest => dest.Budgets, opt => opt.Ignore())
                .ForMember(dest => dest.SalaryEntries, opt => opt.Ignore())
                .ForMember(dest => dest.AuditLogs, opt => opt.Ignore());
        }
    }
}