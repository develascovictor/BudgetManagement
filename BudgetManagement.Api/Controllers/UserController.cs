using Autofac.Integration.WebApi;
using BudgetManagement.Api.Controllers.Base;
using BudgetManagement.Service.Api.Modules.User.Interfaces;
using BudgetManagement.Service.Api.Modules.User.Views;
using log4net;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace BudgetManagement.Api.Controllers
{
    [AutofacControllerConfiguration]
    [RoutePrefix(RouteUrl)]
    public class UserController : BaseController
    {
        private const string RouteUrl = "user";
        private const string BaseUrl = "/" + RouteUrl;

        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IUserModule _userModule;

        public UserController(IUserModule userModule)
        {
            _userModule = userModule;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IHttpActionResult> GetUserByIdAsync([FromUri] int id, CancellationToken cancellationToken)
        {
            var url = $"{BaseUrl}/{id}";
            Log.Info($"GetUserByIdAsync - Url: {url}");

            var request = new GetUserByIdRequest
            {
                Id = id
            };
            var commandResult = await _userModule.GetUserByIdAsync(request, cancellationToken);

            return GetResponse(commandResult);
        }

        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> LoginAsync(CancellationToken cancellationToken)
        {
            var url = $"{BaseUrl}/{Request.RequestUri.Query}";
            Log.Info($"LoginAsync - Url: {url}");

            var request = GetFromQueryString<LoginRequest>();
            var commandResult = await _userModule.LoginAsync(request, cancellationToken);

            return GetResponse(commandResult);
        }
    }
}