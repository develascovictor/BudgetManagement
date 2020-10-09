using Autofac.Integration.WebApi;
using BudgetManagement.Api.Controllers.Base;
using BudgetManagement.Service.Api.Modules.SalaryEntry.Interfaces;
using BudgetManagement.Service.Api.Modules.SalaryEntry.Views;
using log4net;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace BudgetManagement.Api.Controllers
{
    [AutofacControllerConfiguration]
    [RoutePrefix(RouteUrl)]
    public class SalaryEntryController : BaseController
    {
        private const string RouteUrl = "salaryEntry";
        private const string BaseUrl = "/" + RouteUrl;

        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly ISalaryEntryModule _salaryEntryModule;

        public SalaryEntryController(ISalaryEntryModule salaryEntryModule)
        {
            _salaryEntryModule = salaryEntryModule;
        }

        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> SearchSalaryEntriesAsync(CancellationToken cancellationToken)
        {
            var url = $"{BaseUrl}{Request.RequestUri.Query}";
            Log.Info($"SearchSalaryEntriesAsync - Url: {url}");

            var request = GetFromQueryString<SearchSalaryEntriesRequest>();
            var commandResult = await _salaryEntryModule.SearchSalaryEntriesAsync(request, cancellationToken);

            return GetResponse(commandResult);
        }

        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> CreateSalaryEntryAsync([FromBody] CreateSalaryEntryRequest request, CancellationToken cancellationToken)
        {
            var url = $"{BaseUrl}";
            Log.Info($"CreateSalaryEntryAsync - Url: {url}");

            var commandResult = await _salaryEntryModule.CreateSalaryEntryAsync(request, cancellationToken);
            return GetResponse(commandResult);
        }

        [HttpPatch]
        [Route("")]
        public async Task<IHttpActionResult> UpdateSalaryEntryAsync([FromBody] UpdateSalaryEntryRequest request, CancellationToken cancellationToken)
        {
            var url = $"{BaseUrl}";
            Log.Info($"UpdateSalaryEntryAsync - Url: {url}");

            var commandResult = await _salaryEntryModule.UpdateSalaryEntryAsync(request, cancellationToken);
            return GetResponse(commandResult);
        }
    }
}