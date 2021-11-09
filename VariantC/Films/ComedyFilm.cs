using System;
using System.Collections.Generic;
namespace MainProject
{
    class ComedyFilm : Film
    {
        public override string Category { get => "comedy"; }
        public ComedyFilm() : base()
        {
        }

        public ComedyFilm(string name, string country, DateTime dateOfCreation, List<Actor> arrayOfActors, List<Director> arrayOfDirectors) : base(name, country, dateOfCreation, arrayOfActors, arrayOfDirectors)
        {
        }
    }
}