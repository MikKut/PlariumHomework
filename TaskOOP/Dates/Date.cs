using System;

namespace Dates
{
    public partial class Date
    {
        Year CurrentYear { get; }
        Month CurrentMonth { get; }
        Day CurrentDay { get; }
        public Date(int day, int month, int year)
        {
            CurrentYear = new Year(year, true);
            CurrentMonth = new Month(month, CurrentYear);
            CurrentDay = new Day(day, CurrentMonth);
        }
        public int GetDaysFromThisUntill(Date date)
        {
            (int daysBetweenMonths, bool minusOneYear) dm;
            int totalQuantityOfDays = 0, startYear;
            Year year = this.CurrentYear - date.CurrentYear;
            startYear = year.GetYear().Item1;
            dm = this.CurrentMonth.GetNumberOfDays(date.CurrentMonth);
            totalQuantityOfDays += dm.daysBetweenMonths;
            if (dm.minusOneYear)
            {
                year--;
            }
            for (int i = 0; i < year.GetYear().Item1; i++)
            {
                if (Year.CheckWhetherItIsEven(startYear++))
                {
                    totalQuantityOfDays += 366;
                }
                else
                {
                    totalQuantityOfDays += 365;
                }
            }
            return totalQuantityOfDays;
        }
        private DayOfWeek GetDayOfWeek()
        {
            return new DateTime(CurrentYear.GetYear().Item1, (int)CurrentMonth.TheMonth, CurrentDay.NumberOfDay).DayOfWeek;
        }
        public void DisplayDayOFWeek()
        {
            Console.WriteLine(GetDayOfWeek());
        }
        public override bool Equals(object objDate)
        {
            if (objDate is Date date)
            {
                if (this.CurrentYear == date.CurrentYear && date.CurrentMonth == this.CurrentMonth && date.CurrentDay == this.CurrentDay)
                {
                    return true;
                }
                return false;
            }
            else
            {
                throw new InvalidCastException($"{objDate} is not a member of Date.Date class");
            }
        }
        public override int GetHashCode()
        {
            return CurrentYear.GetHashCode() + CurrentMonth.GetHashCode() + CurrentDay.GetHashCode();
        }
        public override string ToString()
        {
            return ($"{CurrentDay} {CurrentMonth} {CurrentYear}");
        }

    }
}