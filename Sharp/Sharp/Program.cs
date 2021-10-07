using System;

namespace Sharp
{
    static class SyntaxHomework
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CountSumOfNumbersDividedByThreeWithoutReminder(7) + " is sum of numbers that can be divided by three without reminder"); //task 1.1
            PrintTheIncreseOfTheSubjectAndDisplayTotalAmountOfTheSubjectForThePeriod(10, "mileage of the skier", "km", 10, "day", 7, true);
            PrintTheIncreseOfTheSubjectAndDisplayTotalAmountOfTheSubjectForThePeriod(20, "harvest", "centner", 2, "year", 8, true); //task 2.1 a,c
            PrintTheIncreseOfTheSubjectAndDisplayTotalAmountOfTheSubjectForThePeriod(100, "square", "hectare", 5, "year", 7, false, 4); //task 2.1 b
            Console.WriteLine(CalculateTheNumberOfDigits(10)); //task 2.2.1
            Console.WriteLine(FindTheDigitalRoot(23454)); //task 2.2.2
            PrintWhichOfTwoDigitsIsRighterIntTheNumber(178378223, 7, 8); //task 2.2.3
            Console.WriteLine(FindMaxIndexInTheArray(new int[] { 0, 1, 2, 3, 4, 4, 5, 5, 5, 0 })); //task 3.1.1
            PrintTheLongestRepeatingSequenceInArray("abcabc".ToCharArray()); //Task 3.1.3
            Console.WriteLine(FindQuantityOfStringsWithoutZero(new int[,] { { 1, 2, 3, 4, 5 }, { 2, 3, 4, 5, 0 }, { 9, 1230, 7, 0, 0 } })); //3.1.4.1
            Console.WriteLine(FindMaxElementAppearsMoreThenOnceInTheMatrix(new int[,] { { 1, 2, 3, 4, 5 }, { 2, 3, 4, 5, 0 }, { 9, 1230, 7, 8, 0 } }));//3.1.4.2

        }
        #region Task 1.1
        //Write a program that enters seven values and calculates the sum of integers that are divisible by 3 without a remainder.
        static int CountSumOfNumbersDividedByThreeWithoutReminder(int quantityOfNumbers)
        {
            int sum = 0, result;
            Console.WriteLine("Enter numbers to find the sum of all the digits that can be divided by three without reminder:");
            for (int i = 0; i < quantityOfNumbers; i++)
            {
                Console.WriteLine($"Enter the element number {i + 1} of {quantityOfNumbers}: ");
                if (Int32.TryParse(Console.ReadLine(), out result))
                {
                    if (result % 3 == 0)
                    {
                        sum += result;
                    }
                }
                else
                {
                    Console.WriteLine("Your number is not a number. Try again.");
                    i--;
                }
            }
            return sum;
        }
        #endregion
        #region Task 2.1, 1.2
        //2.1
        //In a certain year (let's call it conditionally the first) on a plot of 100 hectares, the average harvest of barley was 20 centners per hectare.
        //After that, each year the area of the site increased by 5%, and the average harvest by 2%. Determine:
        //a) harvest for the second, third, ..., eighth year;
        //b) the area of the site in the fourth, fifth, ..., seventh year;
        //c) how much will be harvested in the first six years.
        //2.2
        //Having started training, the skier ran 10 km on the first day.
        //Every next day, he increased the mileage by 10% of the mileage of the previous day. Define:
        //a) the skier's run for the second, third, ..., tenth day of training;
        //b) what is the total path he ran in the first 7 days of training
        static void PrintTheIncreseOfTheSubjectAndDisplayTotalAmountOfTheSubjectForThePeriod(double startQuantityOfTheSubject, string nameOfTheSubject, string nameOfTheUnitOfMeasureOfTheSubbject, double persentageIncrease, string nameOfTheUnitOfTime, int finalUnitOfTime, bool showAmountOfTheSubjectFromFirstToSomeTime, int startUnitOfTime = 0)
        {
            int quantityOfUnitOfTimeToFindOutTotalSumOfTheSubject = 0, sumIndexator; //unit of time can be year, day, month etc 
            double quantityOfTheSubjectForPreviousTime = startQuantityOfTheSubject, sumOfFirstDays = startQuantityOfTheSubject;
            startUnitOfTime--; //calculation starts from second unit of time(year, day or month)
            if (showAmountOfTheSubjectFromFirstToSomeTime)
            {
                while (true)
                {
                    Console.WriteLine($"Enter the quantity of {nameOfTheUnitOfTime}s untill which it is needed to make calculations of the amount of {nameOfTheSubject}: "); // getting number of the years for task "c"
                    if (Int32.TryParse(Console.ReadLine(), out quantityOfUnitOfTimeToFindOutTotalSumOfTheSubject))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Your number is not a number. Try again.");
                    }
                }

            }
            sumIndexator = quantityOfUnitOfTimeToFindOutTotalSumOfTheSubject;
            for (int i = 1; i < finalUnitOfTime; i++)
            {
                quantityOfTheSubjectForPreviousTime = quantityOfTheSubjectForPreviousTime + persentageIncrease / 100 * quantityOfTheSubjectForPreviousTime; //previos quantity of the subject + persent
                if (i >= startUnitOfTime)
                {
                    Console.WriteLine($"Number of the {nameOfTheSubject} on the {nameOfTheUnitOfTime} number {i + 1} of {finalUnitOfTime} {nameOfTheUnitOfTime} will increase its performance to  {quantityOfTheSubjectForPreviousTime} {nameOfTheUnitOfMeasureOfTheSubbject}s");

                }
                if (showAmountOfTheSubjectFromFirstToSomeTime) // if we need to find out sum of first units if time
                {
                    if (sumIndexator > 1)
                    {
                        sumOfFirstDays += quantityOfTheSubjectForPreviousTime;
                        sumIndexator--;
                    }

                }
            }
            if (showAmountOfTheSubjectFromFirstToSomeTime)
            {
                Console.WriteLine($"The total quantity of the {nameOfTheSubject} in the first {quantityOfUnitOfTimeToFindOutTotalSumOfTheSubject} {nameOfTheUnitOfTime}s is {sumOfFirstDays}");
            }
        }

        #endregion
        #region Task 2.2.1
        //A natural number is given. Determine the number of digits in it;
        static int CalculateTheNumberOfDigits(uint number)
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
        static uint FindTheDigitalRoot(uint number)
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
        static void PrintWhichOfTwoDigitsIsRighterIntTheNumber(int number, int first, int second)
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
        #region Task 3.1.1
        //Find the location (index) of the largest number in the array.
        //If there are several such numbers, find the index of the first of them.
        static int FindMaxIndexInTheArray(int[] array)
        {
            int index = 0, max = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                    index = i;
                }
            }
            return index;
        }
        #endregion
        #region Task 3.1.2
        //There are two increasing integer arrays: x of length k and y of length m.
        //Find the number of common elements in these arrays
        //(that is, the number of those integers t for which t = x [i] = y [j] for some i and j).
        static int FindNumberOfCommonElementsInTheArrays(int[] array1, int sizeOfFirstArray, int[] array2, int sizeOfSecondArray)
        {
            int result = 0;
            for (int i = 0; i < sizeOfFirstArray; i++)
            {
                for (int j = 0; j < sizeOfSecondArray; j++)
                {
                    if (array1[i] == array2[j])
                    {
                        result++;
                    }
                }
            }
            return result;
        }
        #endregion
        #region Task 3.1.3
        //Find the longest repeating sequence of characters in a one-dimensional array.
        static void PrintTheLongestRepeatingSequenceInArray(char[] array)
        {
            int lengthOfTheArray = array.Length;
            int[,] matrix = new int[lengthOfTheArray, lengthOfTheArray];
            int previousLengthOfRepeatingSequence = 0, currentLengthOfRepeatingSequence = 0, currentFinalIndex = 0, savedFinalIndex = -1;
            for (int i = 0; i < lengthOfTheArray; i++)
            {
                for (int j = 0; j < lengthOfTheArray; j++)
                {
                    if (array[i] == array[j])
                    {
                        matrix[i, j] = 1;
                    }
                }
            }
            for (int d = 1; d < lengthOfTheArray; d++)
            {
                for (int i = 0, j = 0; i < lengthOfTheArray - d; i++, j++)
                {
                    if (matrix[i+d, j] == 1)
                    {
                        currentFinalIndex = i;
                        currentLengthOfRepeatingSequence++;
                    }
                    else
                    {
                        if (previousLengthOfRepeatingSequence < currentLengthOfRepeatingSequence)
                        {
                            savedFinalIndex = currentFinalIndex;
                            previousLengthOfRepeatingSequence = currentLengthOfRepeatingSequence;
                            currentLengthOfRepeatingSequence = 0;
                        }
                        else 
                        {
                            currentFinalIndex = 0;
                        }
                    }
                }
            }
            if (previousLengthOfRepeatingSequence == 0)
            {
                Console.WriteLine("There is no repeating sequences");
            }

            else
            {
                Console.Write("Common sequence is ");
                for (int i = 0, j = savedFinalIndex+1-previousLengthOfRepeatingSequence; i < previousLengthOfRepeatingSequence; i++, j++)
                {
                    Console.Write(array[j]);
                }
                Console.WriteLine();
            }
        }
        #endregion
        #region Task 3.1.4
        //An integer rectangular matrix is given. Define:
        //1)the number of lines that do not contain any zero elements;
        //2)the maximum of the numbers that appear in the given matrix more than once.

        static int FindQuantityOfStringsWithoutZero(int[,] array)
        {
            int result = 0;
            int quantityOfStrings = array.GetLength(0);
            int quantityOfRows = array.GetLength(1);
            for (int i = 0; i < quantityOfStrings; i++)
            {
                for (int j = 0; j < quantityOfRows; j++)
                {
                    if (array[i,j] == 0)
                    {
                        result++;
                        break;
                    }
                }
            }
            return result;
        }
        static int FindMaxElementAppearsMoreThenOnceInTheMatrix(int[,] array)
        {
            int quantityOfStrings = array.GetLength(0);
            int quantityOfRows = array.GetLength(1);
            int max = Int32.MinValue;
            bool flag = false;
            for (int i = 0; i < quantityOfStrings; i++)
            {
                for (int j = 0; j < quantityOfRows; j++)
                {
                    for (int k = 0; k < quantityOfStrings; k++)
                    {
                        for (int b = 0; b<quantityOfRows; b++)
                        {
                            if (!(i==k && j==b) && (array[i,j] == array[k,b] && array[i,j] > max))
                            {
                                max = array[i,j];
                                flag = true;
                                break;
                            }
                        }
                        if (flag)
                        {
                            flag = false;
                            break;
                        }
                    }
                }
            }
            return max;
        }
        #endregion
    }
}
