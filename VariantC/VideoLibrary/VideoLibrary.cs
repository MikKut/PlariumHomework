using System;
using System.Collections.Generic;
using System.Linq;

namespace MainProject
{
    [Serializable]
    class VideoLibrary
    {
        public delegate void RatingEventHandler(RatingEventArguments args, Film film);
        public event RatingEventHandler OnRating;
        public Dictionary<int, Film> Films;
        private int _numberOfFilms;

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
                    throw new Exception("number of Films less than zero");
                }
            }
        }
        public VideoLibrary()
        {
            Films = new();
            SubscribeAtRating();
        }
        public VideoLibrary(VideoLibrary vb)
        {
            this.Films = vb.Films;
            this.NumberOfFilms = vb.NumberOfFilms;
            SubscribeAtRating();
        }
        public void RateTheFilm(double rate, Film film)
        {
            if (!this.FilmExists(film))
            {
                throw new ArgumentException("There is no such film");
            }
            RatingEventArguments args = new();
            args.TotalRating = rate;
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
                Films.Add(NumberOfFilms, theFilm);
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
                    Films.Remove(index);
                    NumberOfFilms--;
                }
                else
                {
                    throw new Exception("There is 0 Films left");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Wrong input data: \"{ex.Message}\"");
            }
        }
        public int FindIndexOfTheFilmOrReturnMinusOne(Film film)
        {
            var theFilms = 
                Films
                .Where(theFilm => theFilm.Value == film)
                .Select(x => x);

            foreach (var theFilm in theFilms)
            {
                return theFilm.Key;
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
                    Films.Remove(indexOfTheFilm);
                    NumberOfFilms--;
                }
                else
                {
                    throw new ArgumentException("There is 0 Films left");
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
                foreach (var film in Films)
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
                var theFilms =
                    Films
                    .Where(film => theFilm.Equal(film.Value))
                    .Select(x => x);

                foreach (var film in theFilms)
                {
                    film.Value.DisplayInformationAboutTheActors();
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
            listOfAllActors.AddRange(Films.SelectMany(film => film.Value.Actors));
            return listOfAllActors;
        }
        public void FindActorsWhoWasDirectorInAnyOfTheFilms()
        {
            List<Actor> listOfAllActors = FindListOfAllActors();
            List<Director> listOfAllDirectors = new();
            foreach (var film in Films)
            {
                listOfAllDirectors.AddRange(film.Value.Directors);
                listOfAllActors.AddRange(film.Value.Actors);
            }
            listOfAllActors.Sort();
            listOfAllDirectors.Sort();
            DisplayActorsWhoWasDirectorInAnyOfTheFilms(listOfAllActors, listOfAllDirectors);
        }
        private void DisplayActorsWhoWasDirectorInAnyOfTheFilms(List<Actor> sortedListOfAllActors, List<Director> sortedListOfAllDirectors )
        {
            Actor prevActor = new(" ", default(DateTime)), currentActor = new(" ", default(DateTime));

            var staff = 
                sortedListOfAllActors
                .SelectMany(actor => sortedListOfAllDirectors
                .Select(director => (actor, director)));

            foreach (var (actor, director) in staff)
            {
                currentActor = actor;
                if (currentActor.Equal(director))
                {
                    if (!prevActor.Equal(currentActor))
                    {
                        currentActor.ShowInformation();
                    }
                    prevActor = actor;
                    break;
                }
            }
        }


        public void DiplayFilmsOfTheYear(DateTime time)
        {
            var theFilms = 
                Films
                .Where(film => film.Value.DateOfCreation.Year == time.Year)
                .Select(x => x);

            foreach (var film in theFilms)
            {
                Console.WriteLine(film.Value.Name);
            }
        }
        public void DiplayFilmsOfTheYear(int year)
        {
            var theFilms =
                Films
                .Where(film => film.Value.DateOfCreation.Year == year)
                .Select(x => x);

            foreach (var film in theFilms)
            {
                Console.WriteLine(film.Value.Name);
            }
        }
        public void DeleteFilmsUnderTheYear(int year)
        {
            var theFilms = 
                Films
                .Where(film => film.Value.DateOfCreation.Year < year)
                .Select(x => x);

            foreach (var film in theFilms)
            {
                this.RemoveFilm(film.Value);
            }
        }
        public void DeleteFilmsUnderTheYear(DateTime time)
        {
            var theFilms =
                Films
                .Where(film => film.Value.DateOfCreation.Year < time.Year)
                .Select(x => x);

            foreach (var film in theFilms)
            {
                this.RemoveFilm(film.Value);
            }
        }
    }
}
