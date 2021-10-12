using System;

namespace Sharp
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(SyntaxHomework.CountSumOfNumbersDividedByThreeWithoutReminder(7) + " is sum of numbers that can be divided by three without reminder"); //task 1.1
            SyntaxHomework.PrintTheIncreseOfTheSubjectAndDisplayTotalAmountOfTheSubjectForThePeriod(10, "mileage of the skier", "km", 10, "day", 7, true);//task 1.2
            SyntaxHomework.PrintTheIncreseOfTheSubjectAndDisplayTotalAmountOfTheSubjectForThePeriod(20, "harvest", "centner", 2, "year", 8, true); //task 2.1 a,c (same method as in task 1.2)
            SyntaxHomework.PrintTheIncreseOfTheSubjectAndDisplayTotalAmountOfTheSubjectForThePeriod(100, "square", "hectare", 5, "year", 7, false, 4); //task 2.1 b
            Console.WriteLine(SyntaxHomework.CalculateTheNumberOfDigits(10)); //task 2.2.1
            Console.WriteLine(SyntaxHomework.FindTheDigitalRoot(23454)); //task 2.2.2
            SyntaxHomework.PrintWhichOfTwoDigitsIsRighterIntTheNumber(178378223, 7, 8); //task 2.2.3
            Console.WriteLine(SyntaxHomework.FindMaxIndexInTheArray(new int[] { 0, 1, 2, 3, 4, 4, 5, 5, 5, 0 })); //task 3.1.1
            SyntaxHomework.PrintTheLongestRepeatingSequenceInArray("abcabc".ToCharArray()); //Task 3.1.3
            Console.WriteLine(SyntaxHomework.FindQuantityOfStringsWithoutZero(new int[,] { { 1, 2, 3, 4, 5 }, { 2, 3, 4, 5, 0 }, { 9, 1230, 7, 0, 0 } })); //3.1.4.1
            Console.WriteLine(SyntaxHomework.FindMaxElementAppearsMoreThenOnceInTheMatrix(new int[,] { { 1, 2, 3, 4, 5 }, { 2, 3, 4, 5, 0 }, { 9, 1230, 7, 8, 0 } }));//3.1.4.2
        }
    }
}
