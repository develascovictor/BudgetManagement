//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BudgetManagement.Persistence.SqlServer
{
    using System;
    using System.Collections.Generic;
    
    public partial class Transfer
    {
        public int Id { get; set; }
        public int ExpenseId { get; set; }
        public int IncomeId { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public System.DateTime UpdatedOn { get; set; }
    
        public virtual Expense Expense { get; set; }
        public virtual Income Income { get; set; }
    }
}
