﻿using AutoMapper;
using BudgetManagement.Application.Models;
using BudgetManagement.Service.Api.Modules.Transaction.Views;

namespace BudgetManagement.Service.Api.Modules.Transaction.Mapping
{
    public class UpdateIncomeRequestProfile : Profile
    {
        public UpdateIncomeRequestProfile()
        {
            CreateMap<UpdateIncomeRequest, IncomeUpdateDefinition>();
        }
    }
}