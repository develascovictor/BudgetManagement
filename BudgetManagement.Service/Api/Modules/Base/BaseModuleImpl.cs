using AutoMapper;
using BudgetManagement.Domain.Entities.Base;
using BudgetManagement.Service.Api.Utilities;
using BudgetManagement.Shared.Extensions;
using BudgetManagement.Shared.Pagination.Models;
using BudgetManagement.Shared.Server.Api.Pagination;
using log4net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace BudgetManagement.Service.Api.Modules.Base
{
    //TODO: Add exception for null func
    public abstract class BaseModuleImpl<TDomain, TId, TListDto, TSingleDto>
        where TDomain : BaseDomain<TId>
        where TListDto : class
        where TSingleDto : class
    {
        protected readonly string ClassName;
        protected readonly IMapper MapperInstance;
        protected readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        protected BaseModuleImpl(Profile profile)
        {
            ClassName = GetType().Name;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(profile);
            });
            MapperInstance = new Mapper(config);
        }

        protected BaseModuleImpl(List<Profile> profiles)
        {
            ClassName = GetType().Name;

            var config = new MapperConfiguration(cfg =>
            {
                profiles.ForEach(cfg.AddProfile);
            });
            MapperInstance = new Mapper(config);
        }

        protected BaseModuleImpl(IConfigurationProvider mapperConfiguration)
        {
            ClassName = GetType().Name;
            MapperInstance = new Mapper(mapperConfiguration);
        }

        public async Task<string> HealthCheckAsync()
        {
            var caller = CallerExtensions.LogCaller();

            var timer = new Stopwatch();
            timer.Start();

            try
            {
                return await Task.FromResult($"Status: {ClassName} Healthy [{DateTime.Now:O}]");
            }

            finally
            {
                timer.Stop();
                Log.Debug(LogMessage(caller.Method, timer));
            }
        }

        public async Task<IReadOnlyCollection<TListDto>> GetAsync(Func<IReadOnlyCollection<TDomain>> func, string methodName, CancellationToken cancellationToken)
        {
            var timer = new Stopwatch();
            timer.Start();

            try
            {
                var collection = await Task.Run(func, cancellationToken);
                var resources = MapperInstance.Map<IReadOnlyCollection<TDomain>, IReadOnlyCollection<TListDto>>(collection).ToList();

                return resources;
            }

            finally
            {
                timer.Stop();
                Log.Debug(LogMessage(methodName, timer));
            }
        }

        public async Task<Page<TListDto>> SearchAsync(Func<PageOptions, DataPage<TDomain>> func, PaginationRequest paginationRequest, string methodName, CancellationToken cancellationToken)
        {
            var timer = new Stopwatch();
            timer.Start();

            try
            {
                if (string.IsNullOrEmpty(paginationRequest.Cursor))
                {
                    paginationRequest.Cursor = Cursor.EmptyCursor;
                }

                var index = paginationRequest.Cursor == Cursor.EmptyCursor ? 0 : int.Parse(paginationRequest.Cursor);
                //TODO: Fix issue divide by zero
                var pageOptions = new PageOptions(index, paginationRequest.Limit);

                var page = await Task.Run(() => func(pageOptions), cancellationToken);
                var resources = MapperInstance.Map<IEnumerable<TDomain>, IEnumerable<TListDto>>(page.Data).ToList();
                var paginationResponse = PaginationResponseFactory.GetPaginationResponse(page.PageOptions.Index, page.PageOptions.Limit, page.Total);

                return new Page<TListDto>(resources, paginationResponse);
            }

            finally
            {
                timer.Stop();
                Log.Debug(LogMessage(methodName, timer));
            }
        }

        public async Task<TSingleDto> GetByIdAsync(Func<TDomain> func, string methodName, CancellationToken cancellationToken)
        {
            var timer = new Stopwatch();
            timer.Start();

            try
            {
                var domain = await Task.Run(func, cancellationToken);
                var dto = MapperInstance.Map<TDomain, TSingleDto>(domain);

                return dto;
            }

            finally
            {
                timer.Stop();
                Log.Debug(LogMessage(methodName, timer));
            }
        }

        protected string LogMessage(string method, Stopwatch timer) => $"{ClassName}.{method} [Execution Time: {timer.ElapsedMilliseconds} ms]";
    }
}