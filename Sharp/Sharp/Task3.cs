using System;

namespace Sharp
{
     static partial class SyntaxHomework
    {
        #region Task 3.1.1
        //Find the location (index) of the largest number in the array.
        //If there are several such numbers, find the index of the first of them.
        public static int FindMaxIndexInTheArray(int[] array)
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
        public static int FindNumberOfCommonElementsInTheArrays(int[] array1, int sizeOfFirstArray, int[] array2, int sizeOfSecondArray)
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
        public static void PrintTheLongestRepeatingSequenceInArray(char[] array)
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
                    if (matrix[i + d, j] == 1)
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
                for (int i = 0, j = savedFinalIndex + 1 - previousLengthOfRepeatingSequence; i < previousLengthOfRepeatingSequence; i++, j++)
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

        public static int FindQuantityOfStringsWithoutZero(int[,] array)
        {
            int result = 0;
            int quantityOfStrings = array.GetLength(0);
            int quantityOfRows = array.GetLength(1);
            for (int i = 0; i < quantityOfStrings; i++)
            {
                for (int j = 0; j < quantityOfRows; j++)
                {
                    if (array[i, j] == 0)
                    {
                        result++;
                        break;
                    }
                }
            }
            return result;
        }
        public static int FindMaxElementAppearsMoreThenOnceInTheMatrix(int[,] array)
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
                        for (int b = 0; b < quantityOfRows; b++)
                        {
                            if (!(i == k && j == b) && (array[i, j] == array[k, b] && array[i, j] > max))
                            {
                                max = array[i, j];
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

