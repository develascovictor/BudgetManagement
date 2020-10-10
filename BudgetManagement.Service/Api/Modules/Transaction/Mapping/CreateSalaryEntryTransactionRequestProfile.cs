using AutoMapper;
using BudgetManagement.Application.Models;
using BudgetManagement.Service.Api.Modules.Transaction.Views;

namespace BudgetManagement.Service.Api.Modules.Transaction.Mapping
{
    public class CreateSalaryEntryTransactionRequestProfile : Profile
    {
        public CreateSalaryEntryTransactionRequestProfile()
        {
            CreateMap<CreateSalaryEntryTransactionRequest, SalaryEntryTransactionCreateDefinition>();
        }
    }
}