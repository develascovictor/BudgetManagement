using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace BudgetManagement.Service.Api.Modules.TransactionType.Models
{
    public class TransactionTypeDto
    {
        public int Id { get; private set; }
        public int BudgetId { get; private set; }
        public string Name { get; private set; }
        public DateTime CreatedOn { get; private set; }
        public DateTime UpdatedOn { get; private set; }
        public IDictionary<string, string> Errors { get; private set; }

        public TransactionTypeDto()
        {
            // For Mapping
        }

        [JsonConstructor]
        public TransactionTypeDto(
            int id,
            int budgetId,
            string name,
            DateTime createdOn,
            DateTime updatedOn,
            IDictionary<string, string> errors = null)
        {
            Id = id;
            BudgetId = budgetId;
            Name = name;
            CreatedOn = createdOn;
            UpdatedOn = updatedOn;

            Errors = errors;
        }
    }
}