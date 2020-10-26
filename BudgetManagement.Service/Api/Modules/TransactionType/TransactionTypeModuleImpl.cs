using AutoMapper;
using BudgetManagement.Application.Interfaces;
using BudgetManagement.Service.Api.Modules.Base;
using BudgetManagement.Service.Api.Modules.TransactionType.Interfaces;
using BudgetManagement.Service.Api.Modules.TransactionType.Mapping;
using BudgetManagement.Service.Api.Modules.TransactionType.Models;
using BudgetManagement.Service.Api.Modules.TransactionType.Views;
using BudgetManagement.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BudgetManagement.Service.Api.Modules.TransactionType
{
    public class TransactionTypeModuleImpl : BaseModuleImpl<Domain.Entities.TransactionType, int, TransactionTypeDto, TransactionTypeDto>, ITransactionTypeModuleImpl
    {
        private readonly ITransactionTypeService _transactionTypeService;

        private static readonly List<Profile> Profiles = new List<Profile>
        {
            new TransactionTypeDtoProfile()
        };

        private static readonly IConfigurationProvider MapperConfigurationProvider = new MapperConfiguration(cfg =>
        {
            cfg.AllowNullCollections = true;
            Profiles.ForEach(cfg.AddProfile);
        });

        public TransactionTypeModuleImpl(ITransactionTypeService transactionTypeService)
            : base(MapperConfigurationProvider)
        {
            _transactionTypeService = transactionTypeService;
        }

        public async Task<IReadOnlyCollection<TransactionTypeDto>> ListTransactionTypesByBudgetIdAsync(GetTransactionTypesByBudgetIdRequest request, CancellationToken cancellationToken)
        {
            var caller = CallerExtensions.LogCaller();
            var dtos = await GetAsync(() => _transactionTypeService.ListTransactionTypesByBudgetId(request.BudgetId), caller.Method, cancellationToken);

            return dtos;
        }
    }
}