using Autofac.Integration.WebApi;
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
        [Route("")]
        public async Task<IHttpActionResult> CreateTransactionAsync([FromBody] CreateTransactionRequest request, CancellationToken cancellationToken)
        {
            var url = $"{BaseUrl}";
            Log.Info($"CreateTransactionAsync - Url: {url}");

            var commandResult = await _transactionModule.CreateTransactionAsync(request, cancellationToken);
            return GetResponse(commandResult);
        }

        [HttpPost]
        [Route("salary")]
        public async Task<IHttpActionResult> CreateTransactionAsync([FromBody] CreateSalaryEntryTransactionRequest request, CancellationToken cancellationToken)
        {
            var url = $"{BaseUrl}/salary";
            Log.Info($"CreateTransactionAsync - Url: {url}");

            var commandResult = await _transactionModule.CreateTransactionAsync(request, cancellationToken);
            return GetResponse(commandResult);
        }

        [HttpPatch]
        [Route("{id}")]
        public async Task<IHttpActionResult> UpdateTransactionAsync([FromUri] int id, [FromBody] UpdateTransactionRequest request, CancellationToken cancellationToken)
        {
            var url = $"{BaseUrl}/{id}";
            Log.Info($"UpdateTransactionAsync - Url: {url}");

            var commandResult = await _transactionModule.UpdateTransactionAsync(request, cancellationToken);
            return GetResponse(commandResult);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IHttpActionResult> DeleteTransactionAsync([FromUri] int id, CancellationToken cancellationToken)
        {
            var url = $"{BaseUrl}/{id}";
            Log.Info($"DeleteTransactionAsync - Url: {url}");

            var commandResult = await _transactionModule.DeleteTransactionAsync(new DeleteTransactionRequest { Id = id }, cancellationToken);
            return GetResponse(commandResult);
        }

        [HttpPost]
        [Route("{transactionId}/expense")]
        public async Task<IHttpActionResult> CreateExpenseAsync([FromUri] int transactionId, [FromBody] CreateExpenseRequest request, CancellationToken cancellationToken)
        {
            var url = $"{BaseUrl}/{transactionId}/expense";
            Log.Info($"CreateExpenseAsync - Url: {url}");

            var commandResult = await _transactionModule.CreateExpenseAsync(request, cancellationToken);
            return GetResponse(commandResult);
        }

        [HttpPatch]
        [Route("{transactionId}/expense/{id}")]
        public async Task<IHttpActionResult> UpdateExpenseAsync([FromUri] int transactionId, [FromUri] int id, [FromBody] UpdateExpenseRequest request, CancellationToken cancellationToken)
        {
            var url = $"{BaseUrl}/{transactionId}/expense/{id}";
            Log.Info($"UpdateExpenseAsync - Url: {url}");

            var commandResult = await _transactionModule.UpdateExpenseAsync(request, cancellationToken);
            return GetResponse(commandResult);
        }

        [HttpDelete]
        [Route("{transactionId}/expense/{id}")]
        public async Task<IHttpActionResult> DeleteExpenseAsync([FromUri] int transactionId, [FromUri] int id, CancellationToken cancellationToken)
        {
            var url = $"{BaseUrl}/{transactionId}/expense/{id}";
            Log.Info($"DeleteExpenseAsync - Url: {url}");

            var commandResult = await _transactionModule.DeleteExpenseAsync(new DeleteExpenseRequest { Id = id }, cancellationToken);
            return GetResponse(commandResult);
        }

        [HttpPost]
        [Route("{transactionId}/income")]
        public async Task<IHttpActionResult> CreateIncomeAsync([FromUri] int transactionId, [FromBody] CreateIncomeRequest request, CancellationToken cancellationToken)
        {
            var url = $"{BaseUrl}/{transactionId}/income";
            Log.Info($"CreateIncomeAsync - Url: {url}");

            var commandResult = await _transactionModule.CreateIncomeAsync(request, cancellationToken);
            return GetResponse(commandResult);
        }

        [HttpPatch]
        [Route("{transactionId}/income/{id}")]
        public async Task<IHttpActionResult> UpdateIncomeAsync([FromUri] int transactionId, [FromUri] int id, [FromBody] UpdateIncomeRequest request, CancellationToken cancellationToken)
        {
            var url = $"{BaseUrl}/{transactionId}/income/{id}";
            Log.Info($"UpdateIncomeAsync - Url: {url}");

            var commandResult = await _transactionModule.UpdateIncomeAsync(request, cancellationToken);
            return GetResponse(commandResult);
        }

        //TODO: Create logic to validate if transactionid matches the id it sends as well (if income or expense belongs to transaction)
        [HttpDelete]
        [Route("{transactionId}/income/{id}")]
        public async Task<IHttpActionResult> DeleteIncomeAsync([FromUri] int transactionId, [FromUri] int id, CancellationToken cancellationToken)
        {
            var url = $"{BaseUrl}/{transactionId}/income/{id}";
            Log.Info($"DeleteIncomeAsync - Url: {url}");

            var commandResult = await _transactionModule.DeleteIncomeAsync(new DeleteIncomeRequest { Id = id }, cancellationToken);
            return GetResponse(commandResult);
        }
    }
}