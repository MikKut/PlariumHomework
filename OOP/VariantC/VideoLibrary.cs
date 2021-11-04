using System;
using System.Collections.Generic;

namespace VariantC
{
    class VideoLibrary
    {
        Dictionary<Film, int> films;
        int _numberOfFilms = 0;
        public int NumberOfFilms
        {
            get => _numberOfFilms;
            set 
            {
                if (value == 0)
                {
                    throw new Exception("Quantity of film is zero");
                }
                if (value >= 0)
                {
                    _numberOfFilms = value;
                }
                else 
                {
                    throw new Exception("number of films less than zero");   
                }
            }
        }
        public VideoLibrary()
        {
            films = new();
        }
        public VideoLibrary(VideoLibrary vb)
        {
            this.films = vb.films;
            this.NumberOfFilms = vb.NumberOfFilms;
        }
        public void AddFilm(Film theFilm)
        {
            Console.WriteLine("Adding the film");
            try
            {
                if (this.FilmExists(theFilm))
                {
                    throw new Exception($"The film \"{theFilm.Name}\" already exists");
                }
                films.Add(theFilm, NumberOfFilms);
                NumberOfFilms++;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Wrong input data: \"{ex.Message}\"");
            }
        }
        public void RemoveFilm(Film film)
        {
            Console.WriteLine("Removing the film");
            try
            {
                if (NumberOfFilms > 0)
                {
                    films.Remove(film);
                    NumberOfFilms--;
                }
                else
                {
                    throw new Exception("There is 0 films left");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Wrong input data: \"{ex.Message}\"");
            }
        }
        public bool FilmExists(Film theFilm)
        {
            if (NumberOfFilms != 0)
            {
                foreach (var film in films)
                {
                    if (film.Key.Equal(theFilm))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public void DisplayActorsOfTheFilm(Film theFilm)
        {
            if (this.FilmExists(theFilm))
            {
                foreach (var film in films)
                {
                    if (theFilm.Equal(film.Key))
                    {
                        film.Key.DisplayInformationAboutTheActors();
                    }
                }
            }
            else 
            {
                Console.WriteLine("There is no such film");
            }
        }
        public void DisplayActorsWhoWasAsMinimumInNFilms(int numberOfFilms)
        {
            int sizeOfTheList = 0,countOfAppears = 1;
            bool wasAdded = false;
            List<Actor> listOfAllActors = new();
            Actor prevActor = new(" ", default(DateTime));
            foreach (var film in films)
            {
                foreach (Actor actor in film.Key.actors)
                {
                    listOfAllActors.Add(actor);
                }
            }
            listOfAllActors.Sort();
            sizeOfTheList = listOfAllActors.Count;
            for (int i = 0; i < sizeOfTheList-1; i++)
            {
                if (listOfAllActors[i].Equal(listOfAllActors[i + 1]))
                {
                    countOfAppears++;
                    wasAdded = true;
                    if (countOfAppears >= numberOfFilms)
                    {
                        prevActor = listOfAllActors[i];
                    }
                }
                else
                {
                    if (countOfAppears >= numberOfFilms && wasAdded)
                    {
                        prevActor.ShowInformation();
                    }
                    countOfAppears = 0;
                    wasAdded = false;
                }
            }
            if (countOfAppears >= numberOfFilms)
            {
                prevActor.ShowInformation();
            }
        }
        public void DisplayActorsWhoWasDirectorInAnyOfTheFilms()
        {
            List<Actor> listOfAllActors = new();
            List<Director> listOfAllDirectors = new();
            Actor prevActor = new(" ", default(DateTime)), currentActor = new(" ", default(DateTime));
            foreach (var film in films)
            {
                foreach (Director director in film.Key.directors)
                {
                    listOfAllDirectors.Add(director);
                }
                foreach (Actor actor in film.Key.actors)
                {
                    listOfAllActors.Add(actor);
                }
            }
            listOfAllActors.Sort();
            listOfAllDirectors.Sort();
            for (int i = 0; i < listOfAllActors.Count; i++)
            {
                for (int j = 0; j < listOfAllDirectors.Count; j++)
                {
                    currentActor = listOfAllActors[i];
                    if (currentActor.Equal(listOfAllDirectors[j]))
                    {
                        if (!prevActor.Equal(currentActor))
                        {
                            currentActor.ShowInformation();
                        }
                        prevActor = listOfAllActors[i];
                        break;
                    }
                   
                }
            }
        }
       
        public void DiplayFilmsOfTheYear(DateTime time)
        {
            foreach (var film in films)
            {
                if (film.Key.DateOfCreation.Year == time.Year)
                {
                    Console.WriteLine(film.Key.Name);
                }
            }
        }
        public void DiplayFilmsOfTheYear(int year)
        {
            foreach (var film in films)
            {
                if (film.Key.DateOfCreation.Year == year)
                {
                    Console.WriteLine(film.Key.Name);
                }
            }
        }
        public void DeleteFilmsUnderTheYear(int year)
        {
            foreach (var film in films)
            {
                if (film.Key.DateOfCreation.Year < year)
                {
                    this.RemoveFilm(film.Key);
                }
            }
        }
        public void DeleteFilmsUnderTheYear(DateTime time)
        {
            foreach (var film in films)
            {
                if (film.Key.DateOfCreation.Year < time.Year)
                {
                    this.RemoveFilm(film.Key);
                }
            }
        }
    }
}
