using System;
using System.Collections.Generic;
namespace VariantC
{
    class ComedyFilm : Film
    {
        public ComedyFilm() : base()
        {
        }

        public ComedyFilm(string name, string country, DateTime dateOfCreation, List<Actor> arrayOfActors, List<Director> arrayOfDirectors) : base(name, country, dateOfCreation, arrayOfActors, arrayOfDirectors)
        {
        }
    }
}