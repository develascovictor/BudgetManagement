using AutoMapper;
using BudgetManagement.Application.Interfaces;
using BudgetManagement.Service.Api.Modules.Base;
using BudgetManagement.Service.Api.Modules.Budget.Interfaces;
using BudgetManagement.Service.Api.Modules.Budget.Mapping;
using BudgetManagement.Service.Api.Modules.Budget.Models;
using BudgetManagement.Service.Api.Modules.Budget.Views;
using BudgetManagement.Shared.Extensions;
using BudgetManagement.Shared.Server.Api.Pagination;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BudgetManagement.Service.Api.Modules.Budget
{
    public class BudgetModuleImpl : BaseModuleImpl<Domain.Entities.Budget, int, BudgetDto, BudgetDto>, IBudgetModuleImpl
    {
        private readonly IBudgetService _budgetService;

        private static readonly List<Profile> Profiles = new List<Profile>
        {
            new BudgetDtoProfile()
        };

        private static readonly IConfigurationProvider MapperConfigurationProvider = new MapperConfiguration(cfg =>
        {
            cfg.AllowNullCollections = true;
            Profiles.ForEach(cfg.AddProfile);
        });

        public BudgetModuleImpl(IBudgetService budgetService)
            : base(MapperConfigurationProvider)
        {
            _budgetService = budgetService;
        }

        public async Task<string> HealthCheckAsync()
        {
            return await Task.FromResult($"Status: Budget Healthy [{DateTime.UtcNow:O}]");
        }

        public async Task<Page<BudgetDto>> SearchBudgetsAsync(SearchBudgetsRequest request, PaginationRequest paginationRequest, CancellationToken cancellationToken)
        {
            var caller = CallerExtensions.LogCaller();
            var pageDto = await SearchAsync(pageOptions => _budgetService.SearchBudgets(request.Filter, request.Sort, pageOptions), paginationRequest, caller.Method, cancellationToken);

            return pageDto;
        }
    }
}