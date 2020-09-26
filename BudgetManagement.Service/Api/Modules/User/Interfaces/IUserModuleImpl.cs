using BudgetManagement.Service.Api.Modules.User.Models;
using BudgetManagement.Service.Api.Modules.User.Views;
using System.Threading;
using System.Threading.Tasks;

namespace BudgetManagement.Service.Api.Modules.User.Interfaces
{
    public interface IUserModuleImpl
    {
        Task<string> HealthCheckAsync();

        Task<UserDto> GetUserByIdAsync(GetUserByIdRequest request, CancellationToken cancellationToken);
    }
}