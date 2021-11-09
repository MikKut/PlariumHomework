using System;
using System.Collections.Generic;
using System.Linq;
namespace MainProject
{
    static class SortPersons
    {  
        public static void SortByName(ref List<Person> persons)
        {
            persons.Sort(new ComparerPersonsByName());
        }
        public static void SortByDateOfBirth(ref List<Person> persons)
        {
            persons.Sort(new ComparerPersonsByDateOfBirth());
        }
    }


}
