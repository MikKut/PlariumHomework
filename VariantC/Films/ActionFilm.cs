using System;
using System.Collections.Generic;

namespace MainProject
{
    [Serializable] 
    internal class ActionFilm : Film
    {
        public override string Category { get => "action";}
        public ActionFilm() : base()
        {
        }
        public ActionFilm(bool enterViaConsole) : base(enterViaConsole)
        {
            
        }

        public ActionFilm(string name, string country, DateTime dateOfCreation, List<Actor> arrayOfActors, List<Director> arrayOfDirectors) : base(name, country, dateOfCreation, arrayOfActors, arrayOfDirectors)
        {
        }

        public ActionFilm(Film film) : base(film)
        {
        }
    }
}
