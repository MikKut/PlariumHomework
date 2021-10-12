using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFPlarium
{
    public static partial class SyntaxHomework
    {
        #region Task 1.1
        //Write a program that enters seven values and calculates the sum of integers that are divisible by 3 without a remainder.
        public static int CountSumOfNumbersDividedByThreeWithoutReminder(string strSequence)
        {
            int sum = 0, quatityOfNumbers;
            bool isParsedSuccessfuly;
            int[] array;
            isParsedSuccessfuly = ParseTheArray(strSequence, out array, out quatityOfNumbers);
            if (isParsedSuccessfuly)
            {
                for (int i = 0; i < quatityOfNumbers; i++)
                {
                    if (array[i] % 3 == 0)
                    {
                        sum += array[i];
                    }

                }
                return sum;
            }
            else
            {
                return 0;
            }
        }
        private static bool ParseTheArray(string strSequence, out int[] array, out int quantityOfNumbers)
        {
            string[] strArray;
            strArray = strSequence.Split(' ');
            quantityOfNumbers = strArray.Length;
            array = new int[quantityOfNumbers];
            if (quantityOfNumbers == 0)
            {
                return false;
            }
            for (int i = 0; i < quantityOfNumbers; i++)
            {
                if (!Int32.TryParse(strArray[i], out array[i]))
                {
                    return false;
                }
            
            }
            return true;
        }
        #endregion
    }
}
