using System;
using System.Collections.Generic;

namespace MainProject
{
    class ActionFilm : Film
    {
        public override string Category { get => "action";}
        public ActionFilm() : base()
        {
        }

        public ActionFilm(string name, string country, DateTime dateOfCreation, List<Actor> arrayOfActors, List<Director> arrayOfDirectors) : base(name, country, dateOfCreation, arrayOfActors, arrayOfDirectors)
        {
        }
    }
}
