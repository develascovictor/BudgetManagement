using BudgetManagement.Application.Interfaces;
using BudgetManagement.Application.Models;
using BudgetManagement.Domain.Entities;
using BudgetManagement.Domain.Exceptions;
using BudgetManagement.Shared.Pagination.Models;
using log4net;
using System;
using System.Linq;
using System.Reflection;

namespace BudgetManagement.Application.Services
{
    public class SalaryEntryService : ISalaryEntryService
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private readonly IUnitOfWork _unitOfWork;

        public SalaryEntryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public DataPage<SalaryEntry> SearchSalaryEntries(string filterOptions, string sortOptions, PageOptions pageOptions)
        {
            var domains = _unitOfWork.SalaryEntryRepository.Search(filterOptions, sortOptions, pageOptions.Index, pageOptions.Limit, out var total).ToList();
            return new DataPage<SalaryEntry>(domains, pageOptions, total);
        }

        public SalaryEntry CreateSalaryEntry(SalaryEntryCreateDefinition salaryEntryCreateDefinition)
        {
            var user = _unitOfWork.UserRepository.GetById(salaryEntryCreateDefinition.UserId);

            if (user == null)
            {
                throw new UserNotFoundException(salaryEntryCreateDefinition.UserId);
            }

            var domain = new SalaryEntry
            (
                0,
                salaryEntryCreateDefinition.UserId,
                salaryEntryCreateDefinition.Date,
                salaryEntryCreateDefinition.Amount,
                salaryEntryCreateDefinition.Rate,
                DateTime.Now,
                DateTime.Now
            );
            domain = _unitOfWork.SalaryEntryRepository.Create(domain);

            _unitOfWork.SaveChanges();

            return domain;
        }
    }
}