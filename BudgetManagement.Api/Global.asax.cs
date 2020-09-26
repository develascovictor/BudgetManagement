using Autofac;
using Autofac.Integration.WebApi;
using BudgetManagement.Api.Configuration;
using BudgetManagement.Api.DependencyResolution;
using log4net.Config;
using System.Net;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace BudgetManagement.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            //GlobalConfiguration.Configure(WebApiConfig.Register);
            //GlobalConfiguration.Configure(x => Configuration(new HttpConfiguration()));
            GlobalConfiguration.Configure(Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            XmlConfigurator.Configure();
        }

        private void Configuration(HttpConfiguration config)
        {
            var configManager = new ConfigManager();
            //var apiMasherySecction = ConfigurationManager.GetSection(ApiConfigurationSectionName);
            //var apiConfig = (ApiConfigurationSection)apiMasherySecction;

            //var apiSecurity = (ApiSecuritySection)ConfigurationManager.GetSection(ApiSecuritySectionName);

            // Add our custom services and message handlers to the pipeline.
            //var config = new HttpConfiguration();
            //config.Services.Replace(typeof(IExceptionHandler), new GlobalExceptionHandler());
            //config.Services.Replace(typeof(IHttpActionSelector), new ActionSelector());
            //config.MessageHandlers.Add(new LogRequestAndResponseHandler());
            //config.MessageHandlers.Add(new RoutingErrorHandler());
            //config.MessageHandlers.Add(new CorsMessageHandler());
            //config.MessageHandlers.Insert(0, new OwinServerCompressionHandler(new GZipCompressor(), new DeflateCompressor()));
            //config.Filters.Add(new HasReadOnlyAccessAttribute());

            //// Setup formatters for receipt/response of messages.
            //ConfigureFormatters(config);
            //ConfigureCsvExportCustomHeaders();
            //ConfigureParameterBinders(config);
            //RegisterJsonSchemas(configManager);

            // Register all of our domain objects and create our DI container.
            var builder = new ContainerBuilder();
            var domainObjectRegister = new DomainObjectRegister();
            domainObjectRegister.RegisterDomainObjects(builder, configManager);

            var assemblies = Assembly.GetExecutingAssembly();
            builder.RegisterApiControllers(assemblies);

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            // Register OWIN middleware into the pipeline.
            //app.UseAutofacMiddleware(container);
            //app.UseAutofacWebApi(config);
            //app.UseCors(CorsOptions.AllowAll);
            //app.UseAuthentication("mashery", container.Resolve<IUserInfoService>(), apiConfig.Module.ApplicationId);
            //app.UseUserContextProvider(container.Resolve<IUserContextServiceFactory>());
            //app.UseWebApi(config);

            // Setup documentation support.
            // SwaggerConfig.Register(config, configManager, apiConfig, apiSecurity);

            // Register all of our changes with the main API pipeline.
            WebApiConfig.Register(config);

            ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;
        }
    }
}
