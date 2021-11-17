using System;
using System.Collections.Generic;

namespace MainProject
{
    class ComparerPersonsByName : IComparer<Person>
    {
        public int Compare(Person person1, Person person2) => person1.Name.CompareTo(person2.Name);
    }
    class ComparerPersonsByDateOfBirth : IComparer<Person>
    {
        public int Compare(Person person1, Person person2) => person1.DateOfBirth.CompareTo(person2.DateOfBirth);
    }
}
