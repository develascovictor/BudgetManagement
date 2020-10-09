using AutoMapper;
using BudgetManagement.Application.Interfaces;
using BudgetManagement.Application.Models;
using BudgetManagement.Service.Api.Modules.Base;
using BudgetManagement.Service.Api.Modules.SalaryEntry.Interfaces;
using BudgetManagement.Service.Api.Modules.SalaryEntry.Mapping;
using BudgetManagement.Service.Api.Modules.SalaryEntry.Models;
using BudgetManagement.Service.Api.Modules.SalaryEntry.Views;
using BudgetManagement.Shared.Extensions;
using BudgetManagement.Shared.Server.Api.Pagination;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BudgetManagement.Service.Api.Modules.SalaryEntry
{
    public class SalaryEntryModuleImpl : BaseEventModuleImpl<Domain.Entities.SalaryEntry, int, SalaryEntryDto, SalaryEntryDto>, ISalaryEntryModuleImpl
    {
        private readonly ISalaryEntryService _salaryEntryService;

        private static readonly List<Profile> Profiles = new List<Profile>
        {
            new SalaryEntryDtoProfile(),
            new CreateSalaryEntryRequestProfile()
        };

        private static readonly IConfigurationProvider MapperConfigurationProvider = new MapperConfiguration(cfg =>
        {
            cfg.AllowNullCollections = true;
            Profiles.ForEach(cfg.AddProfile);
        });

        public SalaryEntryModuleImpl(ISalaryEntryService salaryEntryService)
            : base(null, MapperConfigurationProvider)
        {
            _salaryEntryService = salaryEntryService;
        }

        public async Task<string> HealthCheckAsync()
        {
            return await Task.FromResult($"Status: Salary Entry Healthy [{DateTime.UtcNow:O}]");
        }

        public async Task<Page<SalaryEntryDto>> SearchSalaryEntriesAsync(SearchSalaryEntriesRequest request, PaginationRequest paginationRequest, CancellationToken cancellationToken)
        {
            var caller = CallerExtensions.LogCaller();
            var pageDto = await SearchAsync((pageOptions) => _salaryEntryService.SearchSalaryEntries(request.Filter, request.Sort, pageOptions), paginationRequest, caller.Method, cancellationToken);

            return pageDto;
        }

        public async Task<SalaryEntryDto> CreateSalaryEntryAsync(CreateSalaryEntryRequest request, CancellationToken cancellationToken)
        {
            var caller = CallerExtensions.LogCaller();
            var dto = await RunRequestAndDispatchEventAsync<CreateSalaryEntryRequest, SalaryEntryCreateDefinition>(x => _salaryEntryService.CreateSalaryEntry(x), request, caller.Method, cancellationToken);

            return dto;
        }

        public async Task<SalaryEntryDto> UpdateSalaryEntryAsync(UpdateSalaryEntryRequest request, CancellationToken cancellationToken)
        {
            var caller = CallerExtensions.LogCaller();
            var dto = await RunRequestAndDispatchEventAsync<UpdateSalaryEntryRequest, SalaryEntryUpdateDefinition>(x => _salaryEntryService.UpdateSalaryEntry(request.Id, x), request, caller.Method, cancellationToken);

            return dto;
        }
    }
}