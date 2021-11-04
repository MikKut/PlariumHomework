using System;
using System.Collections.Generic;
using System.Collections;

namespace Collection
{
    class Program
    {
        //
        //1. В кругу стоят N человек, пронумерованных от 1 до N.
        //При ведении счета по кругу вычеркивается каждый второй человек,
        //пока не останется один. Составить две программы, моделирующие процесс.
        //Одна из программ должна использовать класс ArrayList, а вторая — LinkedList
        //

        static void Main(string[] args)
        {
            try
            {
                LinkedList<Person> ls = new();
                ls.AddLast(new Person("1"));
                ls.AddLast(new Person("2"));
                ls.AddLast(new Person("3"));
                ls.AddLast(new Person("4"));
                ls.AddLast(new Person("5"));
                ls.AddLast(new Person("6"));
                ls.AddLast(new Person("7"));
                ls.AddLast(new Person("8"));
                ls.AddLast(new Person("9"));
                ArrayList ar = new(9);
                ar.Add(new Person("1"));
                ar.Add(new Person("2"));
                ar.Add(new Person("3"));
                ar.Add(new Person("4"));
                ar.Add(new Person("5"));
                ar.Add(new Person("6"));
                ar.Add(new Person("7"));
                ar.Add(new Person("8"));
                ar.Add(new Person("9"));
                RussianRoulette rt = new RussianRoulette(ls);
                RussianRoulette rt1 = new RussianRoulette(ar);
                rt.PlayRussianRoulette();
                rt1.PlayRussianRoulette();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
    }
}
