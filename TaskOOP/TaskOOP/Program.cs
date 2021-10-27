using System;

namespace FlowerShop
{
    //Цветочница. Определить иерархию цветов. Создать несколько объектов-цветов.
    //Собрать букет (используя аксессуары) с определением его стоимости.
    //Провести сортировку цветов в букете на основе уровня свежести.
    //Найти цветок в букете, соответствующий заданному диапазону длин стеблей.
    class Program
    {
        static void Main()
        {
            Bouquet bq = new Bouquet(2, 2);
            Console.WriteLine(bq.TotalPrice);
            var flower = bq.FindFlowerOfCertainDiapasonOfStemLengthOrNull(2, 10);
            Console.WriteLine(flower == null ? "There is no such flower" : flower); ;
            bq.MakeSortByFreshness();
        }
    }
}