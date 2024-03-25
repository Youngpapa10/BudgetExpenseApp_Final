using System;
namespace CourseAssignment
{
	public class Date
	{
        private DateTime StartDate;
        private DateTime EndDate;


        // Creates a date object 
        public Date(DateTime startDate)
        {
            StartDate = startDate;
        }

        public Date(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }

        // Gets the start date 
        public DateTime GetStartDate()
        {
            return StartDate;
        }

        // Gets the end date 
        public DateTime GetEndDate()
        {
            return EndDate;
        }

        public string DisplayStartDate()
        {
            return StartDate.ToString("MM/dd/yyyy");
        }

        public string DisplayEndDate()
        {
            return EndDate.ToString("MM/dd/yyyy");
        }
    }
}

