using Autofac;
using Autofac.Integration.WebApi;
using BudgetManagement.Api.Configuration;
using BudgetManagement.Api.DependencyResolution;
using Microsoft.Owin;
using Owin;
using System.Configuration;
using System.Net;
using System.Reflection;
using System.Web.Http;

[assembly: OwinStartup(typeof(BudgetManagement.Api.Startup))]
namespace BudgetManagement.Api
{
    public class Startup
    {
        private const string ApiConfigurationSectionName = "apiConfiguration";
        private const string ApiSecuritySectionName = "apiSecurity";

        public void Configuration(IAppBuilder app)
        {
            var configManager = new ConfigManager();
            //var apiMasherySecction = ConfigurationManager.GetSection(ApiConfigurationSectionName);
            //var apiConfig = (ApiConfigurationSection)apiMasherySecction;

            //var apiSecurity = (ApiSecuritySection)ConfigurationManager.GetSection(ApiSecuritySectionName);

            // Add our custom services and message handlers to the pipeline.
            var config = new HttpConfiguration();
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
            app.UseAutofacMiddleware(container);
            app.UseAutofacWebApi(config);
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

        //private static void ConfigureFormatters(HttpConfiguration config)
        //{
        //    // Remove XML serializer, as we'll only be using JSON.
        //    config.Formatters.Remove(config.Formatters.XmlFormatter);
        //    // Remove stock JSON formatter.
        //    config.Formatters.Remove(config.Formatters.JsonFormatter);
        //    // Add custom JSON formatter.
        //    var jsonFormatter = new JsonMediaTypeFormatter
        //    {
        //        UseDataContractJsonSerializer = false,
        //        SerializerSettings =
        //        {
        //            ContractResolver = new CamelCasePropertyNamesContractResolver(),
        //            DateTimeZoneHandling = DateTimeZoneHandling.Utc,
        //            DateFormatString = "yyyy-MM-ddTHH:mm:ssZ",
        //            Formatting = Formatting.Indented
        //        }
        //    };

        //    config.Formatters.Add(jsonFormatter);
        //}

        //private static void ConfigureParameterBinders(HttpConfiguration config)
        //{
        //    var schemaValidator = new JsonSchemaValidator();
        //    config.ParameterBindingRules.Insert(0, descriptor =>
        //    {
        //        var modelType = typeof(IJsonSchemaModel);

        //        if (
        //            modelType.IsAssignableFrom(descriptor.ParameterType) ||
        //            (descriptor.ParameterType.IsArray && modelType.IsAssignableFrom(descriptor.ParameterType.GetElementType())) ||
        //            (typeof(ICollection).IsAssignableFrom(descriptor.ParameterType) && modelType.IsAssignableFrom(descriptor.ParameterType.GetGenericArguments()[0]))
        //        )
        //        {
        //            return new JsonSchemaParameterBinding(descriptor, schemaValidator);
        //        }

        //        return null;
        //    });
        //}

        //private static void RegisterJsonSchemas(IConfigManager configManager)
        //{
        //    JsonSchemaRegistry.RegisterLicense(configManager);
        //    JsonSchemaRegistry.RegisterJsonSchema<UpdateOfferRequest>();
        //    JsonSchemaRegistry.RegisterJsonSchema<UpdateOfferThresholdRequest>();
        //    JsonSchemaRegistry.RegisterJsonSchema<UpdateSuccessManagerDefaultsRequest>();
        //    JsonSchemaRegistry.RegisterJsonSchema<CreateFromNewOfferRequest>();
        //    JsonSchemaRegistry.RegisterJsonSchema<UpdateMaintenanceSettingsRequest>();
        //    JsonSchemaRegistry.RegisterJsonSchema<CreateUserRequestDto>();
        //    JsonSchemaRegistry.RegisterJsonSchema<UpdateUserRequestDto>();
        //    JsonSchemaRegistry.RegisterJsonSchema<UpdatePartnerRequest>();
        //    JsonSchemaRegistry.RegisterJsonSchema<UpdateAssignmentRequest>();
        //    JsonSchemaRegistry.RegisterJsonSchema<UpdateBulkAssignmentsRequest>();
        //}
    }
}