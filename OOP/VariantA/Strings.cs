using System;
using System.Text;

namespace VariantA
{
    static class StrBuilderTasks
    {
        static char[] separators = { ' ', ',', '.', '-', ';', ':', '\t', '\n', '\0' };
        static char[] letters = { 'ф', 'ы', 'в', 'а', 'п', 'р', 'о', 'л', 'д', 'ж', 'э', 'я', 'ч', 'с',
            'м', 'и', 'т', 'ь', 'б', 'ю', 'й', 'ц', 'у', 'к', 'е', 'н', 'г', 'ш', 'щ', 'з', 'х', 'ъ' };
        public static void RemoveVerbsFromString(ref string text)
        {
            string[] arrayOfEnds = { "ать", "ять", "ешь", "ют" };
            string[] arrayOfWords = (text.ToLower().Split(separators));
            string[] arrayOfSeparators = text.ToLower().Split(letters);
            bool isVerb = false;
            int index = 0, lengthOfSeparatorArray = arrayOfSeparators.Length;
            StringBuilder resultString = new StringBuilder();
            foreach (string word in arrayOfWords)
            {
                isVerb = false;

                foreach (string end in arrayOfEnds)
                {
                    if (word.EndsWith(end))
                    {
                        isVerb = true;
                        break;
                    }
                }

                if (!isVerb)
                {
                    resultString.Append(word);
                    while (index < lengthOfSeparatorArray)
                    {
                        if (arrayOfSeparators[index++] != string.Empty)
                        {
                            resultString.Append(arrayOfSeparators[index - 1]);
                            break;
                        }

                    }
                }
            }

            text = resultString.ToString();
        }
        public static void MarkTheWordInTheText(string text, string word)
        {
            string[] arrayOfWords = text.Split(separators);
            string[] arrayOfSeparators = text.ToLower().Split(letters);
            int lengthOfSeparatorArray = arrayOfSeparators.Length;
            int index = 0, indexOfSeparator = 0;
            word.ToLower();
            foreach (string theWord in arrayOfWords)
            {
                if (theWord.ToLower() != word)
                {
                    Console.Write($"{theWord}");
                    while (indexOfSeparator < lengthOfSeparatorArray)
                    {
                        if (arrayOfSeparators[indexOfSeparator++] != string.Empty)
                        {
                            Console.Write(arrayOfSeparators[indexOfSeparator - 1]);
                            break;
                        }
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write($"{theWord}");
                    while (indexOfSeparator < lengthOfSeparatorArray)
                    {
                        if (arrayOfSeparators[indexOfSeparator++] != string.Empty)
                        {
                            Console.Write(arrayOfSeparators[indexOfSeparator - 1]);
                            break;
                        }
                    }
                    Console.ReadKey();
                    Console.ForegroundColor = ConsoleColor.White;

                }
            }
        }
        public static void FindWordWithSameBase(string text)
        {
            string[] arrayOfWords = text.Split(separators);
            int  size = arrayOfWords.Length;
            (int indexOfEndFirst, int indexOfEndSecond, int lengthOfTheBase) indexes;
            for (int i = 0; i < size; i++)
            {
                for (int j = i+1; j < size; j++)
                {
                    indexes = FindIndexesAndLengthOfEndIfLongestCommonBase(arrayOfWords[i], arrayOfWords[j]);
                    if (indexes.lengthOfTheBase > 3)
                    {
                        PrintWordsSeparatedInLexemes(indexes.indexOfEndFirst, indexes.lengthOfTheBase, arrayOfWords[i]);
                        PrintWordsSeparatedInLexemes(indexes.indexOfEndSecond, indexes.lengthOfTheBase, arrayOfWords[j]);
                    }
                }
            }

        }

        private static void PrintWordsSeparatedInLexemes( int indexOfBaseEnd, int lengthOfTheBase, string word)
        {
            int sizeOfPrefix = indexOfBaseEnd- lengthOfTheBase, index = 0, copyOfSize = 0;
            while (sizeOfPrefix-- > -1)
            {
                copyOfSize++;
                Console.Write(word[index++]);
            }
            Console.Write(' ');
            for (int i = index; i < lengthOfTheBase+copyOfSize; i++)
            {
                Console.Write(word[index++]);
            }
            Console.Write(' ');
            for (int i = index; i < word.Length; i++)
            {
                Console.Write(word[index++]);
            }
            Console.WriteLine();
        }

        private static (int indexOfEndFirst, int indexOfEndSecond, int lengthOfTheBase) FindIndexesAndLengthOfEndIfLongestCommonBase(string firstWord, string secondWord)
        {
            var lengthsArray = new int[firstWord.Length, secondWord.Length];
            int maxLength = 0, indexOfBaseEndOfFirst = 0, indexOfBaseEndOfSecond = 0;
            for (int i = 0; i < firstWord.Length; i++)
            {
                for (int j = 0; j < secondWord.Length; j++)
                {
                    if (firstWord[i] == secondWord[j])
                    {
                        if (i == 0 || j == 0)
                        {
                            lengthsArray[i, j] = 1;
                        }
                        else 
                        {
                            lengthsArray[i, j] = lengthsArray[i - 1, j - 1] + 1;
                        }

                        if (lengthsArray[i, j] > maxLength)
                        {
                            indexOfBaseEndOfFirst = i;
                            indexOfBaseEndOfSecond = j;
                            maxLength = lengthsArray[i, j];
                        }
                    }
                    else
                    {
                        lengthsArray[i, j] = 0;
                    }
                }
            }
            return (indexOfBaseEndOfFirst,indexOfBaseEndOfSecond,maxLength);
        }
        private static void PrintLineOfSeparators()
        {
            Console.WriteLine("-------------------------------------------------------------------------");
        }
    }
}
