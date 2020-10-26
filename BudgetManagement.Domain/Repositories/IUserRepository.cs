using BudgetManagement.Domain.Entities;

namespace BudgetManagement.Domain.Repositories
{
    public interface IUserRepository
    {
        User GetById(int id);
        User Login(string userName, string password);
    }
}