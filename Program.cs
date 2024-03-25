using System;
using System.Globalization;

namespace CourseAssignment;

class Program
{
    static void Main(string[] args)
    {
            
            BudgetManager newBudget = new BudgetManager();
            Date budgetDate = GetBudgetDate();

            while (true)
            {
                if (!UserMenu(newBudget, budgetDate))
                  break;

            }

            // Generate date object that will be given to all budget items 
            static Date GetBudgetDate()
            {
                DateTime budgetStart;
                DateTime budgetEnd;

                while (true) // Keep looping until valid dates are entered
                {
                    try
                    {
                        Console.WriteLine("Please enter your budget start date (YYYY/MM/DD): ");
                        budgetStart = DateTime.ParseExact(Console.ReadLine(), "yyyy/MM/dd", CultureInfo.InvariantCulture);
                        Console.WriteLine();
                        break; // Exit the loop if start date is valid
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid date format. Please enter dates in the format YYYY/MM/DD.");
                        Console.WriteLine();
                    }
                }

                while (true) // Keep looping until valid end date is entered
                {
                    try
                    {
                        Console.WriteLine("Please enter your budget end date (YYYY/MM/DD): ");
                        budgetEnd = DateTime.ParseExact(Console.ReadLine(), "yyyy/MM/dd", CultureInfo.InvariantCulture);
                        Console.WriteLine();
                        break; // Exit the loop if end date is valid
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid date format. Please enter dates in the format YYYY/MM/DD.");
                        Console.WriteLine();
                    }
                }

                return new Date(budgetStart, budgetEnd);
            }

            // Main user menu 
            static bool UserMenu(BudgetManager budgetCategory,Date budgetDate)
            {
                    Console.WriteLine(">>>> WELCOME TO THE BUDGET APPLICATION <<<<");
                    Console.WriteLine();
                    Console.WriteLine("Please select an option below:");
                    Console.WriteLine("1) Input Budget items");
                    Console.WriteLine("2) Input Expenses items");
                    Console.WriteLine("3) View Current Budget");
                    Console.WriteLine("4) View Current Expenses");
                    Console.WriteLine("5) View Recent Expense Transactions");
                    Console.WriteLine("6) Generate Overview");
                    Console.WriteLine("7) Compare Budget and Expense Category ");
                    Console.WriteLine("8) Exit ");
                    Console.WriteLine();

                    string response = Console.ReadLine();

                    if (response == "1")

                    {
                        Console.WriteLine();
                        BudgetItem(budgetCategory, budgetDate);
                    
                    }

                    else if (response == "2")

                    {
                        Console.WriteLine();
                        ExpenseItem(budgetCategory);
                    }

                    else if (response == "3")
                    {
                        Console.WriteLine();
                        budgetCategory.DisplayBudgetItems();
                        budgetCategory.DisplayBudgetTotal();
                    }

                    else if (response == "4")
                    {
                        Console.WriteLine();
                        budgetCategory.DisplayExpenseItems();
                        budgetCategory.DisplayExpenseTotal();
                    }

                    else if (response == "5")
                    {
                        Console.WriteLine();
                        if (budgetCategory.GetExpenselist().Count() != 0)
                        {
                            budgetCategory.ViewRecentExpenses();
                        }
                        else
                        {
                        Console.WriteLine("Please add expenses to your budget.");
                        }
                    }

                    else if (response == "6")
                    {
                        Console.WriteLine();
                        Console.WriteLine(">>>>>>> GENERAL OVERVIEW <<<<<<<");
                        Console.WriteLine();
                        budgetCategory.DisplayBudgetItems();
                        Console.WriteLine();
                        budgetCategory.DisplayBudgetTotal();
                        Console.WriteLine();
                        Console.WriteLine();
                        budgetCategory.DisplayExpenseItems();
                        Console.WriteLine();
                        budgetCategory.DisplayExpenseTotal();
                        Console.WriteLine();
                        Console.WriteLine();
                        budgetCategory.DisplayBudgetExpenseDiff();
                    }

                    else if (response == "7")
                    {
                        Console.WriteLine();
                        budgetCategory.DisplayCategoryDifference();
                    }

                    else if (response == "8")
                    {
                        Console.WriteLine();
                        Console.WriteLine(">>>> EXITING THE BUDGET APPLICATION <<<<");
                        return false;
                    }
                return true;

            }


            // Options for budget items 
            static void BudgetItem(BudgetManager budgetCategory, Date budgetDate)
            {
                Console.WriteLine("Please select an option below and add a BUDGET category:");
                Console.WriteLine("1) Rent");
                Console.WriteLine("2) Food");
                Console.WriteLine("3) Transportation");
                Console.WriteLine("4) Entertainment");
                Console.WriteLine("5) Shopping");
                Console.WriteLine("6) Add a category");
                Console.WriteLine("7) Edit a category");
                Console.WriteLine("8) Delete a category");
                Console.WriteLine("9) Back to Main Menu");
                Console.WriteLine();

                string response = Console.ReadLine();

                switch (response)
                {
                    case ("1"):
                        Console.WriteLine("Please enter amount: ");
                        decimal amount = Convert.ToDecimal(Console.ReadLine());
                        budgetCategory.AddBudgetCategory("Rent", amount, budgetDate);
                        budgetCategory.DisplayBudgetItems();
                        budgetCategory.DisplayBudgetTotal();
                        Console.WriteLine();
                        BudgetItem(budgetCategory, budgetDate);
                        break;

                    case ("2"):
                        Console.WriteLine("Please enter amount: ");
                        decimal amount1 = Convert.ToDecimal(Console.ReadLine());
                        budgetCategory.AddBudgetCategory("Food", amount1, budgetDate); ;
                        budgetCategory.DisplayBudgetItems();
                        budgetCategory.DisplayBudgetTotal();
                        Console.WriteLine();
                        BudgetItem(budgetCategory, budgetDate);
                        break;

                    case ("3"):
                        Console.WriteLine("Please enter amount: ");
                        decimal amount2 = Convert.ToDecimal(Console.ReadLine());
                        budgetCategory.AddBudgetCategory("Transportation", amount2, budgetDate);
                        budgetCategory.DisplayBudgetItems();
                        budgetCategory.DisplayBudgetTotal();
                        Console.WriteLine();
                        BudgetItem(budgetCategory, budgetDate);
                        break;

                    case ("4"):
                        Console.WriteLine("Please enter amount: ");
                        decimal amount3 = Convert.ToDecimal(Console.ReadLine());
                        budgetCategory.AddBudgetCategory("Entertainment", amount3, budgetDate);
                        budgetCategory.DisplayBudgetItems();
                        budgetCategory.DisplayBudgetTotal();
                        Console.WriteLine();
                        BudgetItem(budgetCategory, budgetDate);
                        break;

                    case ("5"):
                        Console.WriteLine("Please enter amount: ");
                        decimal amount4 = Convert.ToDecimal(Console.ReadLine());
                        budgetCategory.AddBudgetCategory("Shopping", amount4, budgetDate);
                        budgetCategory.DisplayBudgetItems();
                        budgetCategory.DisplayBudgetTotal();
                        Console.WriteLine();
                        BudgetItem(budgetCategory, budgetDate);
                        break;

                    case ("6"):
                        Console.WriteLine("Please enter name: ");
                        string name = Console.ReadLine();
                        Console.WriteLine("Please enter amount: ");
                        decimal amount5 = Convert.ToDecimal(Console.ReadLine());
                        budgetCategory.AddBudgetCategory(name, amount5, budgetDate);
                        budgetCategory.DisplayBudgetItems();
                        budgetCategory.DisplayBudgetTotal();
                        Console.WriteLine();
                        BudgetItem(budgetCategory, budgetDate);
                        break;

                    case ("7"):
                        Console.WriteLine("Please enter category name: ");
                        string oldName = Console.ReadLine();
                        Console.WriteLine("Please enter new category name: ");
                        string newName = Console.ReadLine();
                        Console.WriteLine("Please enter new amount: ");
                        decimal newAmount = Convert.ToDecimal(Console.ReadLine());
                        budgetCategory.EditBudgetCategory(oldName, newName, newAmount);
                        budgetCategory.DisplayBudgetItems();
                        budgetCategory.DisplayBudgetTotal();
                        Console.WriteLine();
                        BudgetItem(budgetCategory, budgetDate);
                        break;
                    

                    case ("8"):
                        Console.WriteLine("Please enter name: ");
                        string name1 = Console.ReadLine();
                        budgetCategory.DeleteBudgetCategory(name1);
                        budgetCategory.DisplayBudgetItems();
                        budgetCategory.DisplayBudgetTotal();
                        Console.WriteLine();
                        BudgetItem(budgetCategory, budgetDate);
                        break;

                    case ("9"):
                        Console.WriteLine(" ");
                        Console.WriteLine(">>> Heading to main menu. <<<");
                        Console.WriteLine(" ");
                        budgetCategory.DisplayBudgetTotal();
                        budgetCategory.DisplayExpenseTotal();
                        Console.WriteLine(" ");
                        break;

                }

            }

         // Creates a DateTime object to be based on users prompt
        // To be used for creation of expense items

        static Date GetValidExpenseDate(string prompt)
        {
            DateTime date;

            while (true)
            {

                try
                {
                    Console.WriteLine(prompt);
                    date = DateTime.ParseExact(Console.ReadLine(), "yyyy/MM/dd", CultureInfo.InvariantCulture);
                    Console.WriteLine();
                    break; // Exit the loop if date is valid
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid date format. Please enter date in the format YYYY/MM/DD.");
                    Console.WriteLine();
                }

                /* Console.WriteLine(prompt);
                string userInput = Console.ReadLine();
                if (DateTime.TryParseExact(userInput, "yyyy/MM/dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                {
                    break; // Exit the loop if parsing is successful
                }
                Console.WriteLine("Invalid date format. Please enter dates in the format YYYY/MM/DD."); */
            }
            return new Date(date);
        }

        // Options for Expense items 
        static void ExpenseItem(BudgetManager budgetCategory)
        {
                Console.WriteLine("Please select an option below and add an EXPENSE category:");
                Console.WriteLine("1) Rent");
                Console.WriteLine("2) Food");
                Console.WriteLine("3) Transportation");
                Console.WriteLine("4) Entertainment");
                Console.WriteLine("5) Shopping");
                Console.WriteLine("6) Add a category");
                Console.WriteLine("7) Edit a category");
                Console.WriteLine("8) Delete a category");
                Console.WriteLine("9) Back to Main Menu");
                Console.WriteLine();

                string response = Console.ReadLine();

                switch (response)
                {
                    case ("1"):
                        Date expense = GetValidExpenseDate("Please enter date for Rent (YYYY/MM/DD): ");
                        Console.WriteLine("Please enter amount: ");
                        decimal amount = Convert.ToDecimal(Console.ReadLine());
                        budgetCategory.AddExpenseCategory("Rent", amount, expense);
                        budgetCategory.DisplayExpenseItems();
                        budgetCategory.DisplayExpenseTotal();
                        ExpenseItem(budgetCategory);
                        break;

                    case ("2"):
                        Date expense1 = GetValidExpenseDate("Please enter date for Food (YYYY/MM/DD): ");
                        Console.WriteLine("Please enter amount: ");
                        decimal amount1 = Convert.ToDecimal(Console.ReadLine());
                        budgetCategory.AddExpenseCategory("Food", amount1, expense1);
                        budgetCategory.DisplayExpenseItems();
                        budgetCategory.DisplayExpenseTotal();
                        ExpenseItem(budgetCategory);
                        break;

                    case ("3"):
                        Date expense2 = GetValidExpenseDate("Please enter date for Transportation (YYYY/MM/DD): ");
                        Console.WriteLine("Please enter amount: ");
                        decimal amount2 = Convert.ToDecimal(Console.ReadLine());
                        budgetCategory.AddExpenseCategory("Transportation", amount2, expense2);
                        budgetCategory.DisplayExpenseItems();
                        budgetCategory.DisplayExpenseTotal();
                        ExpenseItem(budgetCategory);
                        break;

                    case ("4"):
                        Date expense3 = GetValidExpenseDate("Please enter date for Entertainment (YYYY/MM/DD): ");
                        Console.WriteLine("Please enter amount: ");
                        decimal amount3 = Convert.ToDecimal(Console.ReadLine());
                        budgetCategory.AddExpenseCategory("Entertainment", amount3, expense3);
                        budgetCategory.DisplayExpenseItems();
                        budgetCategory.DisplayExpenseTotal();
                        ExpenseItem(budgetCategory);
                        break;

                    case ("5"):
                        Date expense4 = GetValidExpenseDate("Please enter date for Shopping (YYYY/MM/DD): ");
                        Console.WriteLine("Please enter amount: ");
                        decimal amount4 = Convert.ToDecimal(Console.ReadLine());
                        budgetCategory.AddExpenseCategory("Shopping", amount4, expense4);
                        budgetCategory.DisplayExpenseItems();
                        budgetCategory.DisplayExpenseTotal();
                        ExpenseItem(budgetCategory);
                        break;

                    case ("6"):
                        Date expense5 = GetValidExpenseDate("Please enter date for expense category (YYYY/MM/DD): ");
                        Console.WriteLine("Please enter name: ");
                        string name = Console.ReadLine();
                        Console.WriteLine("Please enter amount: ");
                        decimal amount5 = Convert.ToDecimal(Console.ReadLine());
                        budgetCategory.AddExpenseCategory(name, amount5, expense5);
                        budgetCategory.DisplayExpenseItems();
                        budgetCategory.DisplayExpenseTotal();
                        ExpenseItem(budgetCategory);
                        break;

                    case ("7"):
                        Console.WriteLine("Please enter category name: ");
                        string oldName = Console.ReadLine();
                        Console.WriteLine("Please enter new category name: ");
                        string newName = Console.ReadLine();
                        Console.WriteLine("Please enter new amount: ");
                        decimal newAmount = Convert.ToDecimal(Console.ReadLine());
                        budgetCategory.EditExpenseCategory(oldName, newName, newAmount);
                        budgetCategory.DisplayExpenseItems();
                        budgetCategory.DisplayExpenseTotal();
                        ExpenseItem(budgetCategory);
                        break;

                    case ("8"):
                        Console.WriteLine("Please enter name: ");
                        string name1 = Console.ReadLine();
                        Console.WriteLine("Please enter amount: ");
                        decimal amount6 = Convert.ToDecimal(Console.ReadLine());
                        budgetCategory.DeleteExpenseCategory(name1, amount6);
                        budgetCategory.DisplayExpenseItems();
                        budgetCategory.DisplayExpenseTotal();
                        ExpenseItem(budgetCategory);
                        break;

                    case ("9"):
                        Console.WriteLine(" ");
                        Console.WriteLine(">>> Heading to main menu. <<<");
                        Console.WriteLine(" ");
                        budgetCategory.DisplayBudgetTotal();
                        budgetCategory.DisplayExpenseTotal();
                        Console.WriteLine(" ");
                        break;

                }

            }


          
    }
}

