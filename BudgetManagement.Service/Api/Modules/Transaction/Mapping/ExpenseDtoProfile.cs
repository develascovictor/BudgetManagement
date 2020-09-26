using AutoMapper;
using BudgetManagement.Service.Api.Modules.Transaction.Models;

namespace BudgetManagement.Service.Api.Modules.Transaction.Mapping
{
    public class ExpenseDtoProfile : Profile
    {
        public ExpenseDtoProfile()
        {
            CreateMap<Domain.Entities.Expense, ExpenseDto>();
        }
    }
}