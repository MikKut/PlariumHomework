using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharp
{
    static partial class SyntaxHomework
    {
        #region Task 2.2.1
        //A natural number is given. Determine the number of digits in it;
        public static int CalculateTheNumberOfDigits(uint number)
        {
            int result = 0;
            while (true)
            {
                result++;
                number /= 10;
                if (number == 0)
                {
                    break;
                }

            }
            return result;
        }
        #endregion
        #region Task 2.2.2
        //Make a program for finding the digital result of a natural number.
        public static uint FindTheDigitalRoot(uint number)
        {
            uint result = 0;
            while (number > 0 || result > 9)
            {
                if (number == 0)
                {
                    number = result;
                    result = 0;
                }
                result += number % 10;
                number /= 10;
            }
            return result;
        }
        #endregion
        #region Task 2.2.3
        //A natural number is given. If it contains digits a and b,
        //then determine which of them is located in the number to the right.
        //If one or both of these digits occur several times in the number,
        //then the last of the same digits must be considered.
        public static void PrintWhichOfTwoDigitsIsRighterIntTheNumber(int number, int first, int second)
        {
            Console.Write($"In number {number}");
            while (true)
            {
                if (number % 10 == first)
                {
                    Console.WriteLine($" among digits {first} and {second} is righter {first}");
                    break;
                }
                if (number % 10 == second)
                {
                    Console.WriteLine($" among digits {first} and {second} is righter {second}");
                    break;

                }
                if ((number /= 10) == 0)
                {
                    Console.WriteLine($" is not found digits {first} and {second} ");
                    break;
                }
            }
        }
        #endregion
    }
}
