namespace BudgetManagement.Service.Api.Modules.User.Views
{
    public class LoginRequest
    {
        /// <summary>
        /// User Name
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        public string Password { get; set; }
    }
}