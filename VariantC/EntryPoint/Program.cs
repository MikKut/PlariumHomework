using System;
using System.Collections.Generic;
using MainProject;
using MainProject.DB;

namespace MainProject.EntryPoint
{
    class Program
    {
      
        static void Main(string[] args)
        {
            try
            {
                var vb = new VideoLibrary();
                Film theFilm = new HorrorFilm("Hu", "UA", DateTime.Parse("01/01/2025"), new List<Actor> { new Actor("a", DateTime.Parse("01/01/1999")) }, new List<Director> { new Director("a", DateTime.Parse("01/01/1999")) });
                vb.AddFilm(theFilm);
                vb.AddFilm(new ComedyFilm("Cu", "UA", DateTime.Parse("01/01/2002"), new List<Actor> { new Actor("a", DateTime.Parse("01/01/1999")) }, new List<Director> { new Director("a", DateTime.Parse("01/01/1999")) }));
                vb.AddFilm(new ActionFilm("Au", "UA", DateTime.Parse("01/01/2002"), new List<Actor> { new Actor("a", DateTime.Parse("01/01/1999")) }, new List<Director> { new Director("a", DateTime.Parse("01/01/1999")) }));
                vb.DisplayActorsOfTheFilm(new ActionFilm("Au", "UA", DateTime.Parse("01/01/2002"), new List<Actor> { new Actor("a",DateTime.Parse("01/01/1999")) }, new List<Director> { new Director("a", DateTime.Parse("01/01/1999")) }));
                vb.FindActorsWhoWasAsMinimumInNFilms(2);
                vb.FindActorsWhoWasDirectorInAnyOfTheFilms();
                vb.RateTheFilm(4,theFilm);
                var del = theFilm.GetDelegateOfDisplaingStaffInformation(true, true);
                theFilm.DisplayFilmInfo(del);
                var db = new DataBase("db.txt");
                db.CreateRecords(vb);
                var vb2 = db.ReadRecords();
                var vb3 = db.GetBackup();
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
