using BudgetManagement.Application.Interfaces;
using BudgetManagement.Domain.Entities;
using log4net;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace BudgetManagement.Application.Services
{
    public class TransactionTypeService : ITransactionTypeService
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private readonly IUnitOfWork _unitOfWork;

        public TransactionTypeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IReadOnlyCollection<TransactionType> GetTransactionTypesByBudgetId(int budgetId)
        {
            var domains = _unitOfWork.TransactionTypeRepository.GetByBudgetId(budgetId).ToList();
            return domains;
        }
    }
}