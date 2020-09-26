using AutoMapper;
using BudgetManagement.Service.Api.Modules.User.Models;

namespace BudgetManagement.Service.Api.Modules.User.Mapping
{
    public class UserDtoProfile : Profile
    {
        public UserDtoProfile()
        {
            CreateMap<Domain.Entities.User, UserDto>();
        }
    }
}