using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dates
{
    public partial class Date
    {
        public class Day
        {
            int _numberOFDay;
            public int NumberOfDay 
            { 
                get => _numberOFDay;
            }
            public Day(int day, Month mmonth)
            {
                if (day > 0 && day < mmonth.quantityOfDays[(int)mmonth.TheMonth].Item2)
                {
                    _numberOFDay = day;
                }
                else
                {
                    throw new ArgumentException($"The number of days ({day}) in month {mmonth.TheMonth} is uncorrect");
                }

            }
            public override bool Equals(object objDay)
            {
                if (objDay is Day day)
                {
                    if (this.NumberOfDay == day.NumberOfDay)
                    {
                        return true;
                    }
                    return false;
                }
                else
                {
                    throw new InvalidCastException($"{objDay} is not a member of Date.Day class");
                }
            }
            public static DayOfWeek ValueOf(int index)
            {
                if (index >= 0 && index <= 6)
                    return (DayOfWeek)index;
                else
                    throw new ArgumentException("Wrong number of days");
            }
            public override string ToString()
            {
                return ($"{NumberOfDay}");
            }

            public override int GetHashCode()
            {
                return _numberOFDay.GetHashCode();
            }
        }
    }
}
 