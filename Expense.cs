using System;
namespace CourseAssignment
{
	public class Expense: Budget
	{
        // Generates an Expense object 
        public Expense(string name, decimal amount, Date startDate) : base(name, amount, startDate)
        {

        }

        // Gets an expense date object
        public DateTime GetExpenseDate()
        {
            return BudgetDate.GetStartDate();
        }

        // Expense date object as a string 
        public string DisplayExpenseDate()
        {
            return BudgetDate.DisplayStartDate();
        }


    }
}

