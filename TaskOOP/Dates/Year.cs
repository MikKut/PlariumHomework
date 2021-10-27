using System;
namespace Dates
{
    public partial class Date
    {
        public class Year
        {
            (int, string) _year;
            readonly string beforeChrist = "BC";
            readonly string afterChrist = "AC";
            public bool IsEven;
            public Year(int year, bool isAfterChrist)
            {
                if (year <= 0)
                {
                    _year.Item1 = year * -1;
                }
                else
                {
                    _year.Item1 = year;
                }
                if (isAfterChrist)
                {
                    _year.Item2 = afterChrist;
                }
                else
                {
                    _year.Item2 = beforeChrist;
                }
                IsEven = CheckWhetherItIsEven();
            }
            public (int, string) GetYear()
            {
                return _year;
            }
            public void SetYear(int year, bool isAfterChrist)
            {
                if (year <= 0)
                {
                    _year.Item1 = year * -1;
                }
                else
                {
                    _year.Item1 = year;
                }
                if (isAfterChrist)
                {
                    _year.Item2 = afterChrist;
                }
                else
                {
                    _year.Item2 = beforeChrist;
                }
            }
            private bool CheckWhetherItIsEven()
            {
                //If the year is evenly divisible by 4, go to step 2. Otherwise, go to step 5.
                //If the year is evenly divisible by 100, go to step 3.Otherwise, go to step 4.
                //If the year is evenly divisible by 400, go to step 4.Otherwise, go to step 5.
                //The year is a leap year(it has 366 days).
                //The year is not a leap year(it has 365 days).
                if (_year.Item1 % 4 == 0 && _year.Item1 % 100 == 0 && _year.Item1 % 400 == 0)
                {
                    return true;
                }
                return false;
            }
            public static bool CheckWhetherItIsEven(Year year)
            {

                if (year._year.Item1 % 4 == 0 && year._year.Item1 % 100 == 0 && year._year.Item1 % 400 == 0)
                {
                    return true;
                }
                return false;
            }
            public static bool CheckWhetherItIsEven(int year)
            {

                if (year % 4 == 0 && year % 100 == 0 && year % 400 == 0)
                {
                    return true;
                }
                return false;
            }
            public override bool Equals(object objYear)
            {
                if (objYear is Year year)
                {
                    if (this._year.Item1 == year._year.Item1 && this._year.Item2 == year._year.Item2)
                    {
                        return true;
                    }
                    return false;
                }
                else
                {
                    throw new InvalidCastException($"{objYear} is not a member of Date.Year class");
                }
            }
            public override string ToString()
            {
                return ($"{_year.Item1} {_year.Item2}");
            }
            public static Year operator --(Year first)
            {
                if (first._year.Item1 != 1)
                {
                    if (first._year.Item2 == "AC")
                    {
                        first._year.Item1--;
                    }
                    else
                    {
                        first._year.Item1++;
                    }
                }
                else
                {
                    if (first._year.Item2 == "AC")
                    {
                        first._year.Item2 = "BC";
                    }
                    else
                    {
                        first._year.Item2 = "AC";
                    }

                }
                return first;
            }
            public static Year operator -(Year first, Year second)
            {
                Year year = new(1, false);
                if (first._year.Item2.Equals(first.beforeChrist) && second._year.Item2.Equals(second.beforeChrist))
                {
                    year._year.Item1 = first._year.Item1 + second._year.Item1;
                    year._year.Item2 = "BC";
                    return year;
                }
                else
                {
                    if ((first._year.Item2.Equals(first.afterChrist) && second._year.Item2.Equals(second.afterChrist)))
                    {
                        year._year.Item1 = first._year.Item1 - second._year.Item1;
                        year._year.Item2 = "AC";
                        if (year._year.Item1 > 0)
                        {
                            return year;
                        }
                        else
                        {
                            year._year.Item1 *= -1;
                            year._year.Item2 = "BC";
                            return year;
                        }
                    }
                    else
                    {
                        if (first._year.Item2 == "BC")
                        {
                            year._year.Item1 = 2 * first._year.Item1 + second._year.Item1;
                            year._year.Item2 = "BC";
                            return year;
                        }
                        else
                        {
                            year._year.Item1 = first._year.Item1 - second._year.Item1;
                            if (year._year.Item1 > 0)
                            {
                                year._year.Item2 = "AC";
                                return year;
                            }
                            else
                            {
                                year._year.Item1 *= -1;
                                year._year.Item2 = "BC";
                                return year;
                            }

                        }
                    }

                }
            }

            public override int GetHashCode()
            {
                return _year.GetHashCode() + beforeChrist.GetHashCode() + afterChrist.GetHashCode() + IsEven.GetHashCode();
            }
        }

    }
}