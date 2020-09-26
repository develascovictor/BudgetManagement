using Autofac.Integration.WebApi;
using BudgetManagement.Api.Controllers.Base;
using BudgetManagement.Service.Api.Modules.Budget.Interfaces;
using BudgetManagement.Service.Api.Modules.Budget.Views;
using log4net;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace BudgetManagement.Api.Controllers
{
    [AutofacControllerConfiguration]
    [RoutePrefix(RouteUrl)]
    public class BudgetController : BaseController
    {
        private const string RouteUrl = "budget";
        private const string BaseUrl = "/" + RouteUrl;

        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IBudgetModule _budgetModule;

        public BudgetController(IBudgetModule budgetModule)
        {
            _budgetModule = budgetModule;
        }

        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> SearchBudgetsAsync(CancellationToken cancellationToken)
        {
            var url = $"{BaseUrl}{Request.RequestUri.Query}";
            Log.Info($"SearchBudgetsAsync - Url: {url}");

            var request = GetFromQueryString<SearchBudgetsRequest>();
            var commandResult = await _budgetModule.SearchBudgetsAsync(request, cancellationToken);

            return GetResponse(commandResult);
        }
    }
}