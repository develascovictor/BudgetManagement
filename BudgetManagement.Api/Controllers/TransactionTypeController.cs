using Autofac.Integration.WebApi;
using BudgetManagement.Api.Controllers.Base;
using BudgetManagement.Service.Api.Modules.TransactionType.Interfaces;
using BudgetManagement.Service.Api.Modules.TransactionType.Views;
using log4net;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace BudgetManagement.Api.Controllers
{
    [AutofacControllerConfiguration]
    [RoutePrefix(RouteUrl)]
    public class TransactionTypeController : BaseController
    {
        private const string RouteUrl = "transactionType";
        private const string BaseUrl = "/" + RouteUrl;

        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly ITransactionTypeModule _transactionTypeModule;

        public TransactionTypeController(ITransactionTypeModule transactionTypeModule)
        {
            _transactionTypeModule = transactionTypeModule;
        }

        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> GetTransactionTypesByBudgetIdAsync(CancellationToken cancellationToken)
        {
            var url = $"{BaseUrl}{Request.RequestUri.Query}";
            Log.Info($"GetTransactionTypesByBudgetIdAsync - Url: {url}");

            var request = GetFromQueryString<GetTransactionTypesByBudgetIdRequest>();
            var commandResult = await _transactionTypeModule.GetTransactionTypesByBudgetIdAsync(request, cancellationToken);

            return GetResponse(commandResult);
        }
    }
}