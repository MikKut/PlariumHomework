using System;
using System.Collections.Generic;

namespace MainProject
{
    class VideoLibrary
    {
        public delegate void RatingEventHandler(RatingEventArguments args, Film film);
        public event RatingEventHandler OnRating;
        public Dictionary<int, Film> films;
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
            SubscribeAtRating();
        }
        public VideoLibrary(VideoLibrary vb)
        {
            this.films = vb.films;
            this.NumberOfFilms = vb.NumberOfFilms;
            SubscribeAtRating();
        }
        public void RateTheFilm(double rate, Film film)
        {
            RatingEventArguments args = new();
            args.TotalRating = rate;
            if (!this.FilmExists(film))
            {
                throw new ArgumentException("There is no such film");
            }
            OnRating?.Invoke(args, film);
        }
        private void SubscribeAtRating()
        {
            OnRating += this.SetRate;
        }
        private void SetRate(RatingEventArguments args, Film film)
        {
            film.RateTheFilm(args.TotalRating);
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
                films.Add(NumberOfFilms, theFilm);
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
                    int index = FindIndexOfTheFilmOrReturnMinusOne(film);
                    if (index == -1)
                    {
                        throw new ArgumentException("There is no such film");
                    }
                    films.Remove(index);
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
        public int FindIndexOfTheFilmOrReturnMinusOne(Film film)
        {
            foreach (var theFilm in films)
            {
                if (theFilm.Value == film)
                {
                    return theFilm.Key;
                }
            }
            return -1;
        }
        public void RemoveFilm(int indexOfTheFilm)
        {
            Console.WriteLine("Removing the film");
            try
            {
                if (indexOfTheFilm > NumberOfFilms)
                {
                    throw new ArgumentException($"There is no film by index \"{indexOfTheFilm}\"");
                }
                if (NumberOfFilms > 0)
                {
                    films.Remove(indexOfTheFilm);
                    NumberOfFilms--;
                }
                else
                {
                    throw new ArgumentException("There is 0 films left");
                }
            }
            catch (ArgumentException ex)
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
                    if (film.Value.Equal(theFilm))
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
                    if (theFilm.Equal(film.Value))
                    {
                        film.Value.DisplayInformationAboutTheActors();
                    }
                }
            }
            else
            {
                Console.WriteLine("There is no such film");
            }
        }
        public void FindActorsWhoWasAsMinimumInNFilms(int numberOfFilms)
        {
            int sizeOfTheList, countOfAppears = 1;
            bool wasAdded = false;
            Actor prevActor = new(" ", default(DateTime));
            List<Actor> listOfAllActors = FindListOfAllActors();
            listOfAllActors.Sort();
            sizeOfTheList = listOfAllActors.Count;
            for (int i = 0; i < sizeOfTheList - 1; i++)
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
        private List<Actor> FindListOfAllActors()
        {
            List<Actor> listOfAllActors = new();
            foreach (var film in films)
            {
                foreach (Actor actor in film.Value.actors)
                {
                    listOfAllActors.Add(actor);
                }
            }
            return listOfAllActors;
        }
        public void FindActorsWhoWasDirectorInAnyOfTheFilms()
        {
            List<Actor> listOfAllActors = FindListOfAllActors();
            List<Director> listOfAllDirectors = new();
            foreach (var film in films)
            {
                foreach (Director director in film.Value.directors)
                {
                    listOfAllDirectors.Add(director);
                }
                foreach (Actor actor in film.Value.actors)
                {
                    listOfAllActors.Add(actor);
                }
            }
            listOfAllActors.Sort();
            listOfAllDirectors.Sort();
            DisplayActorsWhoWasDirectorInAnyOfTheFilms(listOfAllActors, listOfAllDirectors);
        }
        private void DisplayActorsWhoWasDirectorInAnyOfTheFilms(List<Actor> listOfAllActors/*sorted!*/, List<Director> listOfAllDirectors /*sorted!*/ )
        {
            Actor prevActor = new(" ", default(DateTime)), currentActor = new(" ", default(DateTime));
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
                if (film.Value.DateOfCreation.Year == time.Year)
                {
                    Console.WriteLine(film.Value.Name);
                }
            }
        }
        public void DiplayFilmsOfTheYear(int year)
        {
            foreach (var film in films)
            {
                if (film.Value.DateOfCreation.Year == year)
                {
                    Console.WriteLine(film.Value.Name);
                }
            }
        }
        public void DeleteFilmsUnderTheYear(int year)
        {
            foreach (var film in films)
            {
                if (film.Value.DateOfCreation.Year < year)
                {
                    this.RemoveFilm(film.Value);
                }
            }
        }
        public void DeleteFilmsUnderTheYear(DateTime time)
        {
            foreach (var film in films)
            {
                if (film.Value.DateOfCreation.Year < time.Year)
                {
                    this.RemoveFilm(film.Value);
                }
            }
        }
    }
}
