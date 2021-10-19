using System;


namespace VariantA
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "Стрелять бегать и кушать и";
            StrBuilderTasks.MarkTheWordInTheText("йцукен йцукеныд йцукен гоа пыпло йцукен кшойцукенг йцукен", "йцукен");
            StrBuilderTasks.RemoveVerbsFromString(ref str);
            Console.WriteLine();
            Console.WriteLine(str);
            StrBuilderTasks.FindWordWithSameBase("уйцукен йцукеныд гоа пыпло йцук кшойцукенг");
        }
    }
}
