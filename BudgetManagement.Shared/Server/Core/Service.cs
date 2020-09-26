using log4net;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Reflection;
using System.Threading;
using System.Timers;

namespace BudgetManagement.Shared.Server.Core
{
    // TODO: consider a common base class for TaskProcessorBase and Service. They have a lot of duplicated code.
    //public abstract class Service : ServiceDescriptor, IDisposable
    //{
    //    private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

    //    private static int _leaseRenewalSyncPoint = 0;

    //    #region constants

    //    private const string NoConfigurationSuppliedMessage =
    //        "Failed to initialize service [{0}] because no configuration was supplied.";
    //    private const string ServiceMustBeEnabledToExecuteMessage =
    //        "An exception occurred when attempting to execute the service [{0}]. The service must be enabled prior to execution.";
    //    private const string StartingServiceExecutionMessage = "Starting execution of service [{0}].";
    //    private const string EndingServiceExecutionMessage = "Ending execution of service [{0}].";
    //    private const string InitializingServiceMessage = "Initializing service [{0}].";
    //    private const string RunningServiceMessage = "Running service [{0}].";
    //    private const string ServiceTypeIdCannotBeDefaultGuidMessage =
    //        "The ServiceTypeId of service [{0}] is invalid. The default Guid value of 00000000-0000-0000-0000-000000000000 is not a valid ServiceTypeId.";
    //    private const string ServiceNameCannotBeEmptyOrNullMessage =
    //        "The Name of service [{0}] is invalid. A service Name cannot be empty or null";
    //    private const string ServiceDescriptionCannotBeEmptyOrNullMessage =
    //        "The Description of service [{0}] is invalid. A service Description cannot be empty or null";
    //    private const string ServiceInstanceIdCannotBeDefaultGuidMessage =
    //        "The ServiceInstanceId of service [{0}] is invalid. The default Guid value of 00000000-0000-0000-0000-000000000000 is not a valid ServiceInstanceId.";
    //    private const string DisposingMessage = "Disposing [{0}].";
    //    private const string DisposingBoolMessage = "Dispose(bool) [{0}].";
    //    private const string ServiceInitializationExceptionMessage = "An exception occurred while initializing service [{0}].";
    //    private const string DisposeExceptionMessage = "An exception occurred while disposing [{0}].";
    //    private const string NoEnvironmentSpecifiedMessage =
    //        "No environment was specified so the service will not be registered with the service registry. Service Name: [{0}], Service Type Id: [{1}], " +
    //        "Service Instance Id: [{2}]";
    //    private const string ServiceRegistryLeaseInitializedMessage = "The service initialized a registration lease in the service registry. " +
    //        "Service Name: [{0}], Service Type Id: [{1}], Service Instance Id: [{2}]";
    //    private const string ServiceRegistryLeaseInitializationFailedMessage = "The service failed to initialize a registration lease in the service registry. " +
    //        "Service Name: [{0}], Service Type Id: [{1}], Service Instance Id: [{2}]";
    //    private const string ServiceRegistryLeaseRenewalFailedMessage = "The service failed to renew a registration lease in the service registry. " +
    //        "Service Name: [{0}], Service Type Id: [{1}], Service Instance Id: [{2}]";
    //    private const string LeaseRenewalTimerDisposeMessage =
    //        "Waited {0} milliseconds for lease renewal timer callback to exit.";
    //    private const string ServiceNotRegisteredMessage =
    //        "The service configuration has disabled registration so the service will not be registered with the service registry. " +
    //        "Service Name: [{0}], Service Type Id: [{1}], Service Instance Id: [{2}]";
    //    private const string FailureCreatingCustomMetricsReporter =
    //        "Custom metrics are enabled but an exception occurred when initializing the metrics reporter. Missing telemetry configuration is a common" +
    //        " cause of this error. Message: {0}";
    //    private const string NullString = "null";

    //    // The following value is optimized for lease expiration and unregistration values specified in the ConsulServiceRegistrar implementation.
    //    // See comments in that implementation for details and exercise caution when changing this value. 
    //    private const long ServiceRegistryLeaseRenewalInterval = 30000;
    //    private const int SafeDisposeTimerTimeoutSeconds = 5;

    //    #endregion

    //    #region private fields

    //    private bool _disposed = false;
    //    private readonly Guid _serviceInstanceId;
    //    private readonly string _serviceFrameworkVersion;
    //    private Enums.ServiceState _state;
    //    private readonly ServiceConfiguration _configuration;
    //    private ApiHost _apiHost;
    //    private ServiceRegistrar _serviceRegistrar;
    //    private readonly string _environment;
    //    private System.Timers.Timer _serviceRegistryLeaseRenewalTimer;

    //    #endregion

    //    #region constructors

    //    private Service()
    //    {
    //    }

    //    // TODO: examine if we can do DI (for things like Reporter and ServiceRegistrar) while still allowing derived classes to call base(config) ctor
    //    /// <summary>
    //    /// Performs base initialization. This constructor must be called by any deriving service implementation to
    //    /// create a fully initialized service.
    //    /// </summary>
    //    /// <param name="config"></param>
    //    protected Service(ServiceConfiguration config)
    //    {
    //        _configuration = config ?? throw new ArgumentNullException("config", String.Format(NoConfigurationSuppliedMessage, this.GetType()));

    //        _serviceInstanceId = Guid.NewGuid();
    //        _serviceFrameworkVersion = string.Empty;
    //        _state = Enums.ServiceState.Idle;
    //        _environment = _configuration.Environment;

    //        // TODO: DI would be good here, and while at it think about how we could support DI throughout the framework and for service implementors as well.
    //        //       A bootstrapper might be a good idea, rather than injection.
    //        // TODO: what do we use for Address in Consul if the service does not have API enabled?
    //        _serviceRegistrar = ServiceRegistrarFactory.GetServiceRegistrar();
    //    }

    //    #endregion

    //    #region ServiceDescriptor implementation

    //    public sealed override string ServiceFrameworkVersion => _serviceFrameworkVersion;
    //    public sealed override Guid ServiceInstanceId => _serviceInstanceId;
    //    [JsonConverter(typeof(StringEnumConverter))]
    //    public sealed override Enums.ServiceState State => _state;
    //    public sealed override string Environment => _environment;

    //    #endregion

    //    /// <summary>
    //    /// Describes state related to the service instance.
    //    /// </summary>
    //    public ServiceDefinition ServiceDefinition =>
    //        new ServiceDefinition()
    //        {
    //            Description = this.Description,
    //            Environment = this.Environment,
    //            InstanceId = this.ServiceInstanceId,
    //            MachineName = this.HostInformation.MachineName,
    //            Name = this.Name,
    //            TypeId = this.ServiceTypeId
    //        };

    //    /// <summary>
    //    /// Gets a boolean value indicating whether the service is enabled for execution.
    //    /// </summary>
    //    public bool Enabled => _configuration.Enabled;

    //    /// <summary>
    //    /// Executes the service.
    //    /// </summary>
    //    /// <param name="cancellationToken">Used to request cancellation of the service. A service host
    //    /// that is shutting down can use this token to indicate to the service that a shutdown is imminent.</param>
    //    public void Execute(CancellationToken cancellationToken)
    //    {
    //        Log.InfoFormat(StartingServiceExecutionMessage, this.GetType());

    //        if (!Enabled)
    //            throw new ServiceNotEnabledException(String.Format(ServiceMustBeEnabledToExecuteMessage, this.GetType()));

    //        try
    //        {
    //            Log.DebugFormat(InitializingServiceMessage, this.GetType());
    //            _state = Enums.ServiceState.Initializing;
    //            Initialize();

    //            Log.DebugFormat(RunningServiceMessage, this.GetType());
    //            _state = Enums.ServiceState.Running;
    //            Run(cancellationToken);
    //        }
    //        finally
    //        {
    //            _state = Enums.ServiceState.Idle;
    //        }

    //        Log.InfoFormat(EndingServiceExecutionMessage, this.GetType());
    //    }

    //    /// <summary>
    //    /// Executes the business logic of the service.
    //    /// </summary>
    //    /// <param name="cancellationToken">Used to indicate that shutdown of the service is imminent.
    //    /// The business logic can check this token at any time to detect if a shutdown has been initiated
    //    /// by the service host. If a shutdown is in progress then the service can perform cleanup before exiting.</param>
    //    protected abstract void Run(CancellationToken cancellationToken);

    //    /// <summary>
    //    /// Performs base initialization of a service.
    //    /// </summary>
    //    private void Initialize()
    //    {
    //        ValidateServiceMetadata();

    //        if (_configuration.ApiSettings.Enabled)
    //        {
    //            var serviceDefinition = new ServiceDefinition()
    //            {
    //                Description = Description,
    //                Environment = Environment,
    //                MachineName = HostInformation.MachineName,
    //                InstanceId = ServiceInstanceId,
    //                Name = Name,
    //                TypeId = ServiceTypeId
    //            };

    //            if (_configuration.Environment == Shared.ServiceTypes.Constants.Environments.Local
    //                || string.IsNullOrEmpty(_configuration.Environment))
    //                _apiHost = new ApiHost(this.GetType(), "127.0.0.1", serviceDefinition);
    //            else
    //                _apiHost = new ApiHost(this.GetType(), null, serviceDefinition);
    //        }

    //        if (RegisterService())
    //            StartServiceRegistryLeaseRenewal(ServiceRegistryLeaseRenewalInterval);
    //    }

    //    /// <summary>
    //    /// Starts a timer for renewal of a registration lease in the service registry using the specified tme interval.
    //    /// </summary>
    //    /// <param name="interval">The time interval, in milliseconds, at which the registration lease will be renewed.</param>
    //    private void StartServiceRegistryLeaseRenewal(long interval)
    //    {
    //        _serviceRegistrar.RenewLease(this.ServiceInstanceId)
    //            .ContinueWith(
    //                t =>
    //                {
    //                    if (t.IsFaulted)
    //                        Log.ErrorFormat(ServiceRegistryLeaseInitializationFailedMessage, this.Name,
    //                            this.ServiceTypeId, this.ServiceInstanceId);
    //                    else
    //                        Log.DebugFormat(ServiceRegistryLeaseInitializedMessage, this.Name, this.ServiceTypeId,
    //                            this.ServiceInstanceId);
    //                });

    //        _serviceRegistryLeaseRenewalTimer = new System.Timers.Timer(interval) { AutoReset = false };
    //        _serviceRegistryLeaseRenewalTimer.Elapsed += RegistrationLeaseRenewalTimerCallback;
    //        _serviceRegistryLeaseRenewalTimer.Start();
    //    }

    //    /// <summary>
    //    /// Callback method for use with a timer to renew a registration lease with the service registry.
    //    /// Exceptions in this method will be logged but not propagated in order to allow service to continue to operate
    //    /// even when there is a failure of the service registry.
    //    /// </summary>
    //    private async void RegistrationLeaseRenewalTimerCallback(object sender, ElapsedEventArgs args)
    //    {
    //        try
    //        {
    //            if (Interlocked.CompareExchange(ref _leaseRenewalSyncPoint, 1, 0) == 0)
    //            {
    //                try
    //                {
    //                    await _serviceRegistrar.RenewLease(this.ServiceInstanceId);
    //                }
    //                catch (Exception e)
    //                {
    //                    Log.WarnFormat(ServiceRegistryLeaseRenewalFailedMessage, this.Name ?? NullString,
    //                        this.ServiceTypeId,
    //                        this.ServiceInstanceId);
    //                }
    //                finally
    //                {
    //                    _leaseRenewalSyncPoint = 0;
    //                }
    //            }
    //        }
    //        finally
    //        {
    //            // A lock-free way to avoid reentrancy, so that calls to this timer will never overrun each other
    //            _serviceRegistryLeaseRenewalTimer.Start();
    //        }
    //    }

    //    private bool RegisterService()
    //    {
    //        var serviceInfo = new ServiceInformation()
    //        {
    //            Description = this.Description,
    //            HostName = this.RuntimeInformation.HostInformation.MachineName,
    //            InstanceId = this.ServiceInstanceId,
    //            Name = this.Name,
    //            TypeId = this.ServiceTypeId,
    //            Environment = _configuration.Environment
    //        };

    //        if (_configuration.DisableRegistration)
    //        {
    //            Log.WarnFormat(ServiceNotRegisteredMessage,
    //                    serviceInfo.Name ?? NullString, serviceInfo.TypeId,
    //                    serviceInfo.InstanceId);

    //            return false;
    //        }

    //        try
    //        {
    //            if (string.IsNullOrEmpty(_configuration.Environment))
    //            {
    //                var message = string.Format(NoEnvironmentSpecifiedMessage,
    //                    serviceInfo.Name ?? NullString, serviceInfo.TypeId,
    //                    serviceInfo.InstanceId);

    //                Log.Warn(message);

    //                return false;
    //            }

    //            if (_apiHost != null)
    //            {
    //                var result = _serviceRegistrar.RegisterAsync(serviceInfo, _apiHost.Uri, true).Result;
    //            }
    //            else
    //            {
    //                var result = _serviceRegistrar.RegisterAsync(serviceInfo).Result;
    //            }
    //        }
    //        catch (Exception e)
    //        {
    //            if (_configuration.TerminateOnRegistrationFailure)
    //                throw new ServiceInitializationException(
    //                    String.Format(ServiceInitializationExceptionMessage, this.GetType()), e);

    //            Log.Error(String.Format(ServiceInitializationExceptionMessage, this.GetType()) + e.Message);
    //        }

    //        return true;
    //    }

    //    /// <summary>
    //    /// Verifies that service metadata is correct and complete.
    //    /// </summary>
    //    private void ValidateServiceMetadata()
    //    {
    //        if (string.IsNullOrEmpty(Name))
    //            throw new ServiceMetadataIsInvalidException(String.Format(ServiceNameCannotBeEmptyOrNullMessage, this.GetType()));
    //        if (string.IsNullOrEmpty(Description))
    //            throw new ServiceMetadataIsInvalidException(String.Format(ServiceDescriptionCannotBeEmptyOrNullMessage, this.GetType()));
    //        if (ServiceInstanceId == Guid.Empty)
    //            throw new ServiceMetadataIsInvalidException(String.Format(ServiceInstanceIdCannotBeDefaultGuidMessage, this.GetType()));
    //        if (ServiceTypeId == Guid.Empty)
    //            throw new ServiceMetadataIsInvalidException(String.Format(ServiceTypeIdCannotBeDefaultGuidMessage, this.GetType()));
    //    }

    //    #region dispose implementation

    //    /// <summary>
    //    /// Releases resources allocated by the service.
    //    /// </summary>
    //    public void Dispose()
    //    {
    //        Log.DebugFormat(DisposingMessage, this.GetType());

    //        _state = Enums.ServiceState.Disposing;

    //        try
    //        {
    //            // TODO: the following line blocks in a potentially unsafe way
    //            var result = _serviceRegistrar.UnregisterAsync(this.RuntimeInformation.ServiceInstanceId).Result;
    //        }
    //        catch (Exception e)
    //        {
    //            Log.ErrorFormat(DisposeExceptionMessage, this.GetType());
    //        }

    //        Dispose(true);
    //        GC.SuppressFinalize(this);
    //    }

    //    protected virtual void Dispose(bool disposing)
    //    {
    //        Log.DebugFormat(DisposingBoolMessage, this.GetType());

    //        if (_disposed)
    //            return;

    //        if (disposing)
    //        {
    //            // Free managed objects here.
    //            if (_apiHost != null)
    //                _apiHost.Dispose();

    //            if (_serviceRegistryLeaseRenewalTimer != null)
    //            {
    //                int timeoutCounter = 0;

    //                // insure that any callbacks to the timer have completed prior to proceeding
    //                // with stopping and disposal of the timer
    //                while (Interlocked.CompareExchange(ref _leaseRenewalSyncPoint, -1, 0) != 0)
    //                {
    //                    if (timeoutCounter == SafeDisposeTimerTimeoutSeconds * 1000)
    //                        break;

    //                    // Give up the rest of this thread's current time
    //                    // slice. This is a naive algorithm for yielding.
    //                    Thread.Sleep(1);

    //                    timeoutCounter++;
    //                }
    //                _serviceRegistryLeaseRenewalTimer.Stop();
    //                _serviceRegistryLeaseRenewalTimer.Dispose();

    //                Log.DebugFormat(LeaseRenewalTimerDisposeMessage, timeoutCounter);
    //            }

    //            if (_serviceRegistrar != null)
    //            {
    //                _serviceRegistrar.Dispose();
    //            }
    //        }

    //        // Free unmanaged objects here.
    //        //

    //        _disposed = true;
    //    }

    //    #endregion
    //}
}
