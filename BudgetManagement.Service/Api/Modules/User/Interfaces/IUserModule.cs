using BudgetManagement.Service.Api.Modules.User.Models;
using BudgetManagement.Service.Api.Modules.User.Views;
using BudgetManagement.Shared.Response.Models;
using System.Threading;
using System.Threading.Tasks;

namespace BudgetManagement.Service.Api.Modules.User.Interfaces
{
    public interface IUserModule
    {
        Task<CommandResult<string>> GetHealthAsync(CancellationToken cancellationToken);

        Task<CommandResult<UserDto>> GetUserByIdAsync(GetUserByIdRequest request, CancellationToken cancellationToken);
    }
}