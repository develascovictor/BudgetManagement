using BudgetManagement.Application.Interfaces;
using BudgetManagement.Domain.Entities;
using log4net;
using System.Reflection;

namespace BudgetManagement.Application.Services
{
    public class UserService : IUserService
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public User GetUserById(int id)
        {
            var domain = _unitOfWork.UserRepository.GetById(id);
            return domain;
        }

        public User Login(string userName, string password)
        {
            var domain = _unitOfWork.UserRepository.Login(userName, password);
            return domain;
        }
    }
}