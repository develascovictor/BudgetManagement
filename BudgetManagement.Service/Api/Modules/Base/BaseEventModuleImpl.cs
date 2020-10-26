using AutoMapper;
using BudgetManagement.Domain.Entities.Base;
using BudgetManagement.Shared.EventHandling.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BudgetManagement.Service.Api.Modules.Base
{
    public abstract class BaseEventModuleImpl<TDomain, TId, TListDto, TSingleDto> : BaseModuleImpl<TDomain, TId, TListDto, TSingleDto>
        where TDomain : BaseDomainEventHandler<TId>
        where TListDto : class
        where TSingleDto : class
    {
        private readonly IEventDispatcher _eventDispatcher;

        protected BaseEventModuleImpl(IEventDispatcher eventDispatcher, Profile profile)
            : base(profile)
        {
            _eventDispatcher = eventDispatcher;
        }

        protected BaseEventModuleImpl(IEventDispatcher eventDispatcher, List<Profile> profiles)
            : base(profiles)
        {
            _eventDispatcher = eventDispatcher;
        }

        protected BaseEventModuleImpl(IEventDispatcher eventDispatcher, IConfigurationProvider mapperConfiguration)
            : base(mapperConfiguration)
        {
            _eventDispatcher = eventDispatcher;
        }

        protected async Task<TSingleDto> RunRequestAndDispatchEventAsync(Func<TDomain> func, string methodName, CancellationToken cancellationToken)
        {
            var timer = new Stopwatch();
            timer.Start();

            try
            {
                return await GetSingleDtoAndEvaluateEvents(func, cancellationToken);
            }

            finally
            {
                timer.Stop();
                Log.Debug(LogMessage(methodName, timer));
            }
        }

        protected async Task<TSingleDto> RunRequestAndDispatchEventAsync<TRequest, TDefinition>(Func<TDefinition, TDomain> func, TRequest request, string methodName, CancellationToken cancellationToken)
        {
            return await RunAlternateRequestAndDispatchEventAsync<TRequest, TDefinition, TSingleDto, TDomain>(func, request, methodName, cancellationToken);
        }

        protected async Task<TAlternateSingleDto> RunAlternateRequestAndDispatchEventAsync<TRequest, TDefinition, TAlternateSingleDto, TAlternateDomain>(Func<TDefinition, TAlternateDomain> func, TRequest request, string methodName, CancellationToken cancellationToken)
            where TAlternateDomain : BaseDomainEventHandler<TId>
            where TAlternateSingleDto : class
        {
            var timer = new Stopwatch();
            timer.Start();

            try
            {
                var definition = MapperInstance.Map<TRequest, TDefinition>(request);
                return await GetAlternateSingleDtoAndEvaluateEvents<TAlternateSingleDto, TAlternateDomain>(() => func(definition), cancellationToken);
            }

            finally
            {
                timer.Stop();
                Log.Debug(LogMessage(methodName, timer));
            }
        }

        private async Task<TSingleDto> GetSingleDtoAndEvaluateEvents(Func<TDomain> func, CancellationToken cancellationToken)
        {
            return await GetAlternateSingleDtoAndEvaluateEvents<TSingleDto, TDomain>(func, cancellationToken);
        }

        private async Task<TAlternateSingleDto> GetAlternateSingleDtoAndEvaluateEvents<TAlternateSingleDto, TAlternateDomain>(Func<TAlternateDomain> func, CancellationToken cancellationToken)
            where TAlternateDomain : BaseDomainEventHandler<TId>
            where TAlternateSingleDto : class
        {
            //TODO: Add exception for null func
            var domain = await Task.Run(func, cancellationToken);

            if (domain == null)
            {
                return null;
            }

            var events = domain.Events;

            if (_eventDispatcher != null && events?.Any() == true)
            {
                _eventDispatcher.Dispatch(events);
            }

            return MapperInstance.Map<TAlternateDomain, TAlternateSingleDto>(domain);
        }

        protected async Task RunAction(Action func, string methodName, CancellationToken cancellationToken)
        {
            var timer = new Stopwatch();
            timer.Start();

            try
            {
                await Task.Run(func, cancellationToken);
            }

            finally
            {
                timer.Stop();
                Log.Debug(LogMessage(methodName, timer));
            }
        }
    }
}