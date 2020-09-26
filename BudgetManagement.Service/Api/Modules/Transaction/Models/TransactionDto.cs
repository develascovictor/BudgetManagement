using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace BudgetManagement.Service.Api.Modules.Transaction.Models
{
    public class TransactionDto
    {
        public int Id { get; private set; }
        public int BudgetId { get; private set; }
        public int? TransactionTypeId { get; private set; }
        public DateTime Date { get; private set; }
        public string Description { get; private set; }
        public string Notes { get; private set; }
        public DateTime CreatedOn { get; private set; }
        public DateTime UpdatedOn { get; private set; }
        public IDictionary<string, string> Errors { get; private set; }

        public TransactionDto()
        {
            // For Mapping
        }

        [JsonConstructor]
        public TransactionDto(
            int id,
            int budgetId,
            int? transactionTypeId,
            DateTime date,
            string description,
            string notes,
            DateTime createdOn,
            DateTime updatedOn,
            IDictionary<string, string> errors = null)
        {
            Id = id;
            BudgetId = budgetId;
            TransactionTypeId = transactionTypeId;
            Date = date;
            Description = description;
            Notes = notes;
            CreatedOn = createdOn;
            UpdatedOn = updatedOn;

            Errors = errors;
        }
    }
}