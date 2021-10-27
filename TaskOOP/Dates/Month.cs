using System;

namespace Dates
{
    public partial class Date
    {
        public class Month
        {
            AllMonths _month;
            public (AllMonths, int)[] quantityOfDays =
            {
                (AllMonths.Junuary,31),
                (AllMonths.February,28),
                (AllMonths.March,31),
                (AllMonths.April,30),
                (AllMonths.May,31),
                (AllMonths.June,30),
                (AllMonths.July,31),
                (AllMonths.August,31),
                (AllMonths.September,30),
                (AllMonths.October,31),
                (AllMonths.November,30),
                (AllMonths.December,31),
            };
            public AllMonths TheMonth
            {
                get => _month;
                private set
                {
                    if ((int)value < 1 || (int)value > 12)
                    {
                        throw new ArgumentException($"Month number {value} cannot exist");
                    }
                    else
                    {
                        _month = value;
                    }
                }
            }
            public enum AllMonths : int
            {
                Junuary = 01,
                February,
                March,
                April,
                May,
                June,
                July,
                August,
                September,
                October,
                November,
                December
            }
            public Month(int month, Year year)
            {
                TheMonth = (AllMonths)month;
                if (year.IsEven)
                {
                    quantityOfDays[1].Item2 += 1;
                }
            }
            public int GetNumberOfDaysOfTheMonth(int positionOfMonth)
            {
                return quantityOfDays[positionOfMonth].Item2;
            }
            public (int daysBetweenMonths, bool minusOneYear) GetNumberOfDays(Month secondMonth)
            {
                int daysBetweenMonths = 0;
                if (this._month > secondMonth._month)
                {
                    for (int i = (int)this._month; i < (int)secondMonth._month; i++)
                    {
                        daysBetweenMonths += this.quantityOfDays[(int)_month].Item2;
                    }
                    return (daysBetweenMonths, false);
                }
                else
                {
                    for (int i = (int)secondMonth._month; i < (int)this._month; i++)
                    {
                        daysBetweenMonths += secondMonth.quantityOfDays[(int)_month].Item2;
                    }
                    return (daysBetweenMonths, true);
                }
            }
            public override bool Equals(object objMonth)
            {
                if (objMonth is Month month)
                {
                    if (this._month == month._month && ((int)this._month == (int)month._month))
                    {
                        return true;
                    }
                    return false;
                }
                else
                {
                    throw new InvalidCastException($"{objMonth} is not a member of Date.Month class");
                }
            }
            public override int GetHashCode()
            {
                return TheMonth.GetHashCode() + quantityOfDays.GetHashCode();

            }
            public override string ToString()
            {
                return ($"{_month}");
            }
        }
    }
}
