using System;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CourseAssignment
{
	public class Budget
	{
        private string Name;
		private decimal Amount;
        protected Date BudgetDate;

        // Creates a budget object 
        public Budget()
		{
            
        }

        public Budget(string name, decimal amount, Date BudgetDate)
        {
            Name = name;
            Amount = amount;
            this.BudgetDate = BudgetDate;
        }

        public string GetName()
		{
			return Name;
		}

        public void SetName(string name)
        {
            Name = name;
        }

        public decimal GetAmount()
        {
            return Amount;
        }

        public void SetAmount(decimal amount)
        {
            Amount = amount;
        }

        public Date GetBudgetDate()
        {
            return BudgetDate;

        }
    }
}

