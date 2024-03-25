using System;
using System.Globalization;

namespace CourseAssignment
{
    public class BudgetManager : Budget
    {
        private List<Budget> BudgetItems;
        private List<Expense> ExpenseItems;


        public BudgetManager()
        {
            BudgetItems = new List<Budget>();
            ExpenseItems = new List<Expense>();

        }


     

        //METHODS INVOLVING THE BUDGET

        //Get the budget list 
        public List<Budget> GetBudgetList()
        {
            return BudgetItems;
        }

        //Get the expense list 
        public List<Expense> GetExpenselist()
        {
            return ExpenseItems;
        }

        //Adding a budget Category with an amount containing a date
        public bool AddBudgetCategory(string name, decimal amount, Date budgetDate)
        {

            foreach (Budget item in BudgetItems)
            {
                if (item.GetName() == name)
                {
                    Console.WriteLine(">>> >> Category Already Exist!!! << <<<");
                    return false;
                }
            }
            Budget budget = new Budget(name, amount, budgetDate);
            BudgetItems.Add(budget);
            Console.WriteLine(">>> >> Category Added Successfully << <<<");
            return true;

        }

        //Editing a budget Category and Amount
        public bool EditBudgetCategory(string oldName, string newName, decimal newAmount)
        {
            foreach (Budget item in BudgetItems)
            {
                if (item.GetName() == oldName)
                {
                    item.SetName(newName);
                    item.SetAmount(newAmount);
                    Console.WriteLine(">>>  Category Name and Amount Updated <<<");
                    return true;
                }
            }

            Console.WriteLine(">>> Category Name and Amount not found <<<");
            return false;
        }


        //Deleting a budget Category
        public bool DeleteBudgetCategory(string name)
        {
            foreach (Budget item in BudgetItems)
            {
                if (item.GetName() == name)
                {
                    BudgetItems.Remove(item);
                    Console.WriteLine(" ");
                    Console.WriteLine("--- Category deleted successfully ---");
                    Console.WriteLine(" ");
                    return true;
                }
            }

            Console.WriteLine(" ");
            Console.WriteLine(">>> >> No record found for the category selected << <<<");
            Console.WriteLine(" ");
            return false;

        }


        //Displaying the list of categories and amounts in a budget list
        public void DisplayBudgetItems()
        {

            Console.WriteLine("Budget List");

            foreach (Budget items in BudgetItems)
            {
                Console.WriteLine($"Category Name: {items.GetName()}, Category Amount: £{items.GetAmount()}, Start Date: {items.GetBudgetDate().DisplayStartDate()}, End Date: {items.GetBudgetDate().DisplayEndDate()}");
            }

            Console.WriteLine(" ");
        }


        //Displaying the total amount in the budget list
        public decimal DisplayBudgetTotal()
        {
            decimal totalBudget = 0;

            foreach (Budget item in BudgetItems)
            {
                totalBudget += item.GetAmount();

            }

            Console.WriteLine(" ");
            Console.WriteLine($"Total Budget Amount = £{totalBudget}");

            return totalBudget;
        }



        //METHODS INVOLVING THE EXPENSES

        //Adding an expense Category and Amount
        public bool AddExpenseCategory(string name, decimal amount, Date expenseDate)
        {

            Expense expense = new Expense(name, amount, expenseDate);
            ExpenseItems.Add(expense);
            Console.WriteLine(" ");
            Console.WriteLine(">>> >> Category Added Successfully << <<<");
            Console.WriteLine(" ");
            return true;

        }

        //Editing an expense Category and Amount
        public bool EditExpenseCategory(string oldName, string newName, decimal newAmount)
        {
            foreach (Expense item in ExpenseItems)
            {
                if (item.GetName() == oldName)
                {
                    item.SetName(newName);
                    item.SetAmount(newAmount);
                    Console.WriteLine(">>>  Category Name and Amount Updated <<<");
                    return true;
                }
            }

            Console.WriteLine(">>> Category Name and Amount not found <<<");
            return false;
        }

        //Deleting an expense Category
        public bool DeleteExpenseCategory(string name, decimal amount)
        {
            foreach (Expense item in ExpenseItems)
            {
                if (item.GetName() == name && item.GetAmount() == amount)
                {
                    ExpenseItems.Remove(item);
                    Console.WriteLine(" ");
                    Console.WriteLine("--- Category deleted successfully ---");
                    Console.WriteLine(" ");
                    return true;
                }
            }

            Console.WriteLine(" ");
            Console.WriteLine(">>> >> No record found for the category selected << <<<");
            Console.WriteLine(" ");
            return false;

        }

        //Displaying the list of categories and amounts in an expense list
        public void DisplayExpenseItems()
        {
            Console.WriteLine("Expense List");

            foreach (Expense items in ExpenseItems)
            {
                Console.WriteLine($"Category Name: {items.GetName()}, Category Amount: £{items.GetAmount()}, Date: {items.GetBudgetDate().DisplayStartDate()}");
            }

            Console.WriteLine(" ");
        }

        //View recent expenses
        public void ViewRecentExpenses()
        {
            List<Expense> RecentExpense = new List<Expense>(ExpenseItems);
            RecentExpense = RecentExpense.OrderByDescending(e => e.GetExpenseDate()).ToList();
            foreach (Expense item in RecentExpense)
            {
                Console.WriteLine($"Category Name: {item.GetName()}, Category Amount: £{item.GetAmount()}, Date: {item.GetBudgetDate().DisplayStartDate()}");
            }

        }


        //Displaying the total amount in the expense list
        public decimal DisplayExpenseTotal()
        {
            decimal totalExpense = 0;

            foreach (Expense item in ExpenseItems)
            {
                totalExpense += item.GetAmount();

            }

            Console.WriteLine(" ");
            Console.WriteLine($"Total Expense Amount = £{totalExpense}");
            Console.WriteLine(" ");

            return totalExpense;
        }




        //Overview

        //Calculating the diffence between the total budget amount and the expenses
        public void DisplayBudgetExpenseDiff()
        {
            decimal difference = 0;
            decimal perdiff = 0;
            decimal tBudget = DisplayBudgetTotal();
            decimal tExpense = DisplayExpenseTotal();


            if (tBudget != 0 && tExpense != 0)
            {
                difference = tBudget - tExpense;

                perdiff = (Math.Abs(difference) / tBudget) * 100;

                Console.WriteLine(" ");
                Console.WriteLine($"The Difference between the budget and Enpense = £{Math.Abs(difference)}");
                Console.WriteLine(" ");

                if (difference >= 0)
                {
                    Console.WriteLine($"KUDOS! You are well within your budget.You've saved up £{Math.Abs(difference)} extra.");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine($"Unfortunately, your expenses is £{Math.Abs(difference)} more than your budget.");
                    Console.WriteLine($"You spent {perdiff}% more than your budget.");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine(" ERROR!!! Unable to calculate difference. Check to see that you have at least a category and amount in your Budget List and Expense List");
            }



        }

        // Takes a collection of expense items as input and calculates the total expense.
        private decimal CalculateTotalExpense(IEnumerable<Expense> expenses)
        {
            return expenses.Sum(item => item.GetAmount());
        }

        // Takes a collection of budget items as input and calculates the total budget.
        private decimal CalculateTotalBudget(IEnumerable<Budget> budgets)
        {
            return budgets.Sum(item => item.GetAmount());
        }

        // Generates an expense list with items within the date given for the budget
        public List<Expense> GetExpenseDate()
        {

            List<Expense> CompareExpenses = new List<Expense>();

            // Iterate through each buttem item
            foreach (Budget item in BudgetItems)
            {
                // Get start sate and end date from budget item
                Date dateObject = item.GetBudgetDate();
                DateTime startDate = dateObject.GetStartDate();
                DateTime endDate = dateObject.GetEndDate();

                // Filters expenses within the date range of the budget
                IEnumerable<Expense> CompareExpense = ExpenseItems.Where(expense => expense.GetExpenseDate() >= startDate &&
                expense.GetExpenseDate() <= endDate);

                // Adds filtered expenses to the list 
                CompareExpenses = CompareExpense.ToList();
            }
            return CompareExpenses; // List with filtered expenses
        }


        // Compares difference between budget and expense for a given category for expense and budget  
        public void DisplayCategoryDifference()
        {
            //Prompt user for category name
            Console.WriteLine("Enter expense name: ");
            string categoryName = Console.ReadLine();
            if (categoryName != null)
            {
                categoryName.ToUpper();
            }
            else
            {
                Console.WriteLine(">>>> Enter valid category name <<<<");
                
            }

            // Retrieve expense items for the given category 
            IEnumerable<Expense> compareExpenseItems = GetExpenseDate().Where(item => item.GetName() == categoryName);

            // Retrieve budget items for the given category 
            IEnumerable<Budget> compareBudgetItems = BudgetItems.Where(item => item.GetName() == categoryName);

            // Calculate total expense
            decimal totalExpense = CalculateTotalExpense(compareExpenseItems);

            // Calculate total budget
            decimal totalBudget = CalculateTotalBudget(compareBudgetItems);

            // Calculate difference 
            decimal difference = totalBudget - totalExpense;

            // Percentage difference
            decimal percentageDifference = totalBudget != 0 ? (difference / totalBudget) * 100 : 0;

            // Display results
            Console.WriteLine();
            Console.WriteLine($"Total Expense for {categoryName}: £{totalExpense}");
            Console.WriteLine($"Total Budget for {categoryName}: £{totalBudget}");
            Console.WriteLine($"Difference: £{Math.Abs(difference)}");

            // Display appropriate message based on difference
            if (difference >= 0)
            {
                Console.WriteLine($"You are within your budget for {categoryName}. You've saved £{Math.Abs(difference)}.");
            }
            else
            {
                Console.WriteLine($"You've exceeded your budget for {categoryName}. You spent £{Math.Abs(difference)} more than budget.");
                Console.WriteLine($"You've overspent by {Math.Abs(percentageDifference):0.00}%.");
            }

            Console.WriteLine();
        }
    }
}

