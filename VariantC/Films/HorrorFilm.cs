using System;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace MainProject
{
    [Serializable]
    internal class HorrorFilm : Film
    {
        [NonSerialized]
        private readonly string _category = "horror";
        [JsonPropertyName("category")]
        public override string Category { get => _category; }
        public HorrorFilm() : base()
        {

        }

        public HorrorFilm(string name, string country, DateTime dateOfCreation, List<Actor> arrayOfActors, List<Director> arrayOfDirectors) : base(name, country, dateOfCreation, arrayOfActors, arrayOfDirectors)
        {

        }

        public HorrorFilm(Film film) : base(film)
        {
        }

        public HorrorFilm(bool fillInConsole) : base(fillInConsole)
        {
        }
    }
}

