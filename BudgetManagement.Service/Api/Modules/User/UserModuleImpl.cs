using AutoMapper;
using BudgetManagement.Application.Interfaces;
using BudgetManagement.Service.Api.Modules.Base;
using BudgetManagement.Service.Api.Modules.User.Interfaces;
using BudgetManagement.Service.Api.Modules.User.Mapping;
using BudgetManagement.Service.Api.Modules.User.Models;
using BudgetManagement.Service.Api.Modules.User.Views;
using BudgetManagement.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BudgetManagement.Service.Api.Modules.User
{
    public class UserModuleImpl : BaseModuleImpl<Domain.Entities.User, int, UserDto, UserDto>, IUserModuleImpl
    {
        private readonly IUserService _userService;

        private static readonly List<Profile> Profiles = new List<Profile>
        {
            new UserDtoProfile()
        };

        private static readonly IConfigurationProvider MapperConfigurationProvider = new MapperConfiguration(cfg =>
        {
            cfg.AllowNullCollections = true;
            Profiles.ForEach(cfg.AddProfile);
        });

        public UserModuleImpl(IUserService userService)
            : base(MapperConfigurationProvider)
        {
            _userService = userService;
        }

        public async Task<UserDto> GetUserByIdAsync(GetUserByIdRequest request, CancellationToken cancellationToken)
        {
            var caller = CallerExtensions.LogCaller();
            var dto = await GetByIdAsync(() => _userService.GetUserById(request.Id), caller.Method, cancellationToken);

            return dto;
        }
    }
}