namespace BudgetManagement.Shared.Server.Api.StandardErrors
{
    /// <summary>
    /// This class is a source of constants that are used to predefine standard API errors.
    /// </summary>
    public static class ErrorConstants
    {
        private const string ApiFrameworkPrefix = "0000";

        // framework-defined error codes
        public static readonly string NotFoundErrorCode = ApiFrameworkPrefix + "0001";
        public static readonly string InternalServerErrorErrorCode = ApiFrameworkPrefix + "0002";
        public static readonly string BadRequestErrorCode = ApiFrameworkPrefix + "0003";
        public static readonly string UnauthorizedErrorCode = ApiFrameworkPrefix + "0004";
        public static readonly string ForbiddenErrorCode = ApiFrameworkPrefix + "0005";
        public static readonly string MethodNotAllowedErrorCode = ApiFrameworkPrefix + "0006";
        public static readonly string UnsupportedMediaTypeErrorCode = ApiFrameworkPrefix + "0007";
        public static readonly string NotAcceptableErrorCode = ApiFrameworkPrefix + "0008";
        public static readonly string UnversionedRequestErrorCode = ApiFrameworkPrefix + "0009";
        public static readonly string GoneErrorCode = ApiFrameworkPrefix + "0010";
        public static readonly string ConflictErrorCode = ApiFrameworkPrefix + "0011";

        //TODO: Update URL
        /// <summary>
        /// The standard template string for the location of error documentation pages.
        /// </summary>
        public static readonly string InfoUrlTemplateString = "http://developer.cisco.impact.com/api/errors#{0}.htm";
    }
}