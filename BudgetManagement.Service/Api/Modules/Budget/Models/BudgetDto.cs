using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace BudgetManagement.Service.Api.Modules.Budget.Models
{
    public class BudgetDto
    {
        public int Id { get; private set; }
        public int UserId { get; private set; }
        public string Name { get; private set; }
        public bool HasTypes { get; private set; }
        public bool Active { get; private set; }
        public DateTime CreatedOn { get; private set; }
        public DateTime UpdatedOn { get; private set; }
        public IDictionary<string, string> Errors { get; private set; }

        public BudgetDto()
        {
            // For Mapping
        }

        [JsonConstructor]
        public BudgetDto(
            int id,
            int userId,
            string name,
            bool hasTypes,
            bool active,
            DateTime createdOn,
            DateTime updatedOn,
            IDictionary<string, string> errors = null)
        {
            Id = id;
            UserId = userId;
            Name = name;
            HasTypes = hasTypes;
            Active = active;
            CreatedOn = createdOn;
            UpdatedOn = updatedOn;

            Errors = errors;
        }
    }
}