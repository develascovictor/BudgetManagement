using BudgetManagement.Application.Interfaces;
using BudgetManagement.Domain.Entities;
using BudgetManagement.Shared.Pagination.Models;
using log4net;
using System.Linq;
using System.Reflection;

namespace BudgetManagement.Application.Services
{
    public class BudgetService : IBudgetService
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private readonly IUnitOfWork _unitOfWork;

        public BudgetService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public DataPage<Budget> SearchBudgets(string filterOptions, string sortOptions, PageOptions pageOptions)
        {
            var domains = _unitOfWork.BudgetRepository.Search(filterOptions, sortOptions, pageOptions.Index, pageOptions.Limit, out var total).ToList();
            return new DataPage<Budget>(domains, pageOptions, total);
        }
    }
}