﻿using System;

namespace BudgetManagement.Application.Models.Base
{
    public abstract class BaseTransactionDefinition
    {
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public decimal Rate { get; set; }
    }
}