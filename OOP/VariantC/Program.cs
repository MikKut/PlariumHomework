using System;
 

namespace VariantC
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var vb = new VideoLibrary(2);
                vb.DisplayActorsOfTheFilm(new Film("Au", "UA", DateTime.Parse("01/01/2025"), new Actor[] {new Actor("a",DateTime.Parse("01/01/2003")) }, new Director[] { new Director("a", DateTime.Parse("01/01/2003")) }));
                vb.DisplayActorsWhoWasAsMinimumInNFilms(2);
                vb.DisplayActorsWhoWasDirectorInAnyOfTheFilms();
                vb.DiplayFilmsOfTheYear(2002);
                vb.DeleteFilmsUnderTheYear(2003);
                vb.DiplayFilmsOfTheYear(2002);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message); 
            }
        }
    }
}
