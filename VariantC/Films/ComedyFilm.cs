using System;
using System.Text.Json.Serialization;
using System.Collections.Generic;
namespace MainProject
{
    [Serializable]
    internal class ComedyFilm : Film
    {
        private readonly string _category = "comedy";
        [JsonPropertyName("category")]
        public override string Category { get => _category; }
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