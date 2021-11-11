using System;
using System.Collections.Generic;
namespace MainProject
{
    [Serializable]
    internal class ComedyFilm : Film
    {
        public override string Category { get => "comedy"; }
        public ComedyFilm() : base()
        {
        }

        public ComedyFilm(string name, string country, DateTime dateOfCreation, List<Actor> arrayOfActors, List<Director> arrayOfDirectors) : base(name, country, dateOfCreation, arrayOfActors, arrayOfDirectors)
        {
        }

        public ComedyFilm(Film film) : base(film)
        {
        }

        public ComedyFilm(bool fillInConsole) : base(fillInConsole)
        {
        }
    }
}