using BudgetManagement.Domain.Entities;

namespace BudgetManagement.Application.Interfaces
{
    public interface IUserService
    {
        User GetUserById(int id);
    }
}