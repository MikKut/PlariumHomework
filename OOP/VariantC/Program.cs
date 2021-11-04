using System;
using System.Collections.Generic;

namespace VariantC
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var vb = new VideoLibrary();
                vb.AddFilm(new HorrorFilm("Hu", "UA", DateTime.Parse("01/01/2025"), new List<Actor> { new Actor("a", DateTime.Parse("01/01/1999")) }, new List<Director> { new Director("a", DateTime.Parse("01/01/1999")) } ));
                vb.AddFilm(new ComedyFilm("Cu", "UA", DateTime.Parse("01/01/2002"), new List<Actor> { new Actor("a", DateTime.Parse("01/01/1999")) }, new List<Director> { new Director("a", DateTime.Parse("01/01/1999")) }));
                vb.AddFilm(new ActionFilm("Au", "UA", DateTime.Parse("01/01/2002"), new List<Actor> { new Actor("a", DateTime.Parse("01/01/1999")) }, new List<Director> { new Director("a", DateTime.Parse("01/01/1999")) }));
                vb.DisplayActorsOfTheFilm(new ActionFilm("Au", "UA", DateTime.Parse("01/01/2002"), new List<Actor> { new Actor("a",DateTime.Parse("01/01/1999")) }, new List<Director> { new Director("a", DateTime.Parse("01/01/1999")) }));
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
