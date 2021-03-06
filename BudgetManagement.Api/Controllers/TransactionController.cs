﻿using Autofac.Integration.WebApi;
using BudgetManagement.Api.Controllers.Base;
using BudgetManagement.Service.Api.Modules.Transaction.Interfaces;
using BudgetManagement.Service.Api.Modules.Transaction.Views;
using log4net;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace BudgetManagement.Api.Controllers
{
    [AutofacControllerConfiguration]
    [RoutePrefix(RouteUrl)]
    public class TransactionController : BaseController
    {
        private const string RouteUrl = "transaction";
        private const string BaseUrl = "/" + RouteUrl;

        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly ITransactionModule _transactionModule;

        public TransactionController(ITransactionModule transactionModule)
        {
            _transactionModule = transactionModule;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IHttpActionResult> GetTransactionByIdAsync([FromUri] int id, CancellationToken cancellationToken)
        {
            var url = $"{BaseUrl}/{id}";
            Log.Info($"GetTransactionByIdAsync - Url: {url}");

            var request = new GetTransactionByIdRequest
            {
                Id = id
            };
            var commandResult = await _transactionModule.GetTransactionByIdAsync(request, cancellationToken);

            return GetResponse(commandResult);
        }

        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> SearchTransactionsByBudgetIdAsync(CancellationToken cancellationToken)
        {
            var url = $"{BaseUrl}{Request.RequestUri.Query}";
            Log.Info($"SearchTransactionsByBudgetIdAsync - Url: {url}");

            var request = GetFromQueryString<SearchTransactionsByBudgetIdRequest>();
            var commandResult = await _transactionModule.SearchTransactionsByBudgetIdAsync(request, cancellationToken);

            return GetResponse(commandResult);
        }

        [HttpPost]
        [Route("{id}/expense")]
        public async Task<IHttpActionResult> CreateExpenseAsync([FromUri] int id, [FromBody] CreateExpenseRequest request, CancellationToken cancellationToken)
        {
            var url = $"{BaseUrl}/{id}/expense";
            Log.Info($"CreateExpenseAsync - Url: {url}");

            var commandResult = await _transactionModule.CreateExpenseAsync(request, cancellationToken);
            return GetResponse(commandResult);
        }

        [HttpPost]
        [Route("{id}/income")]
        public async Task<IHttpActionResult> CreateIncomeAsync([FromUri] int id, [FromBody] CreateIncomeRequest request, CancellationToken cancellationToken)
        {
            var url = $"{BaseUrl}/{id}/income";
            Log.Info($"CreateIncomeAsync - Url: {url}");

            var commandResult = await _transactionModule.CreateIncomeAsync(request, cancellationToken);
            return GetResponse(commandResult);
        }
    }
}