using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharp
{
    static partial class SyntaxHomework
    {
        #region Task 1.1
        //Write a program that enters seven values and calculates the sum of integers that are divisible by 3 without a remainder.
        public static int CountSumOfNumbersDividedByThreeWithoutReminder(int quantityOfNumbers)
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
        public static void PrintTheIncreseOfTheSubjectAndDisplayTotalAmountOfTheSubjectForThePeriod(double startQuantityOfTheSubject, string nameOfTheSubject, string nameOfTheUnitOfMeasureOfTheSubbject, double persentageIncrease, string nameOfTheUnitOfTime, int finalUnitOfTime, bool showAmountOfTheSubjectFromFirstToSomeTime, int startUnitOfTime = 0)
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
    }
}
