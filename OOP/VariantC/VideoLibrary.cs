using System;
using System.Collections.Generic;

namespace VariantC
{
    class VideoLibrary
    {
        List<Film> films;
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
        public VideoLibrary(int quantityOfFilms)
        {
            try
            {
                NumberOfFilms = quantityOfFilms;
                films = new List<Film>(quantityOfFilms);
                for (int i = 0; i < quantityOfFilms; i++)
                {
                    films.Add(new Film());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Wrong input data: \"{ex.Message}\", try again");
            }
        
        }
        public void AddFilm(Film theFilm)
        {
            try
            {
                foreach (Film film in films)
                {
                    if (this.FilmExists(theFilm))
                    {
                        throw new Exception($"The film \"{theFilm.Name}\" already exists");
                    }
                }
                films.Add(theFilm);
                NumberOfFilms++;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Wrong input data: \"{ex.Message}\", try again");
                AddFilm(theFilm);
            }
        }
        public void RemoveFilm(Film film)
        {
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
                Console.WriteLine($"Wrong input data: \"{ex.Message}\", try again");
                AddFilm(film);
            }
        }
        public bool FilmExists(Film theFilm)
        {
            foreach (Film film in films)
            {
                if (film.Equal(theFilm))
                {
                    return true;
                }
            }
            return false;
        }
        public void DisplayActorsOfTheFilm(Film theFilm)
        {
            if (this.FilmExists(theFilm))
            {
                foreach (Film film in films)
                {
                    if (theFilm.Equal(film))
                    {
                        film.DisplayInformationAboutTheActors();
                    }
                }
            }
            else 
            {
                Console.WriteLine("There is no such film");
            }
        }
        public void DisplayActorsWhoWasAsMinimumInNFilms(int n)
        {
            int sizeOfTheList = 0,countOfAppears = 1;
            bool wasAdded = false;
            List<Actor> listOfAllActors = new List<Actor>();
            foreach (Film film in films)
            {
                foreach (Actor actor in film.actors)
                {
                    listOfAllActors.Add(actor);
                }
            }
            listOfAllActors.Sort(delegate (Actor ac1, Actor ac2) { return ac1.Name.CompareTo(ac2.Name); });
            sizeOfTheList = listOfAllActors.Count;
            for (int i = 0; i < sizeOfTheList-1; i++)
            {
                if (listOfAllActors[i].Equal(listOfAllActors[i + 1]))
                {
                    countOfAppears++;
                    wasAdded = true;
                }
                else
                {
                    if (countOfAppears >= n && wasAdded)
                    {
                        Console.WriteLine(listOfAllActors[i].Name);
                    }
                    countOfAppears = 0;
                }
            }
        }
        public void DisplayActorsWhoWasDirectorInAnyOfTheFilms()
        {
            List<Actor> listOfAllActors = new List<Actor>();
            List<Director> listOfAllDirectors = new List<Director>();
            foreach (Film film in films)
            {
                foreach (Director director in film.directors)
                {
                    listOfAllDirectors.Add(director);
                }
                foreach (Actor actor in film.actors)
                {
                    listOfAllActors.Add(actor);
                }
            }
            listOfAllActors.Sort(delegate(Actor ac1, Actor ac2 ) { return ac1.Name.CompareTo(ac2.Name); });
            listOfAllDirectors.Sort(delegate (Director ac1, Director ac2) { return ac1.Name.CompareTo(ac2.Name); });
            for (int i = 0; i < listOfAllActors.Count; i++)
            {
                for (int j = 0; j < listOfAllDirectors.Count; j++)
                {
                    if (listOfAllActors[i].Equal(listOfAllDirectors[j]))
                    {
                        listOfAllActors[i].ShowInformation();
                        break;
                    }
                   
                }
            }
        }
       
        public void DiplayFilmsOfTheYear(DateTime time)
        {
            foreach (Film film in films)
            {
                if (film.DateOfCreation.Year == time.Year)
                {
                    Console.WriteLine(film.Name);
                }
            }
        }
        public void DiplayFilmsOfTheYear(int year)
        {
            foreach (Film film in films)
            {
                if (film.DateOfCreation.Year == year)
                {
                    Console.WriteLine(film.Name);
                }
            }
        }
        public void DeleteFilmsUnderTheYear(int year)
        {
            foreach (Film film in films)
            {
                if (film.DateOfCreation.Year < year)
                {
                    this.RemoveFilm(film);
                    NumberOfFilms--;
                }
            }
        }
        public void DeleteFilmsUnderTheYear(DateTime time)
        {
            foreach (Film film in films)
            {
                if (film.DateOfCreation.Year < time.Year)
                {
                    this.RemoveFilm(film);
                    NumberOfFilms--;
                }
            }
        }
    }
}
