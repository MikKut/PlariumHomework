using System;
using System.Collections.Generic;

namespace VariantC
{
    class HorrorFilm : Film
    {
            public HorrorFilm() : base()
            {
            }

            public HorrorFilm(string name, string country, DateTime dateOfCreation, List<Actor> arrayOfActors, List<Director> arrayOfDirectors) : base(name, country, dateOfCreation, arrayOfActors, arrayOfDirectors)
            {
            }
    }
}

