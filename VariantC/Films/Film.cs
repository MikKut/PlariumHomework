using System;
using System.Collections.Generic;
using System.Text;

namespace MainProject
{
    abstract internal class Film
    {
        public delegate void DisplayStaffInformation();
        public abstract string Category { get; }
        private const double MinRating = 0, MaxRating = 10;
        private string _name, _country;
        public List<Actor> actors;
        public List<Director> directors;
        private int _numberOfActors = 0, _numberOfDirectors = 0, _numberOfRates = 0;
        private double _totalRating = 0;
        public double TotalRating
        {
            get => _totalRating;
            private set
            {
                if (value < MinRating || value > MaxRating)
                {
                    throw new ArgumentException("Wrong rating");
                }
                _totalRating = value; 
            }
        }
        public void AddRating(double rate)
        {
            TotalRating = (TotalRating + rate) / ++_numberOfRates;
        }
        public DateTime DateOfCreation { get; set; }
        public string Name
        {
            get => _name;
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new Exception("Name of the film is empty");
                }
                else
                {
                    _name = value;
                }
            }
        }
        public string Country 
        {
            get => _country;
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new Exception("Country of film is empty");
                }
                else
                {
                    _country = value;
                }
            }
        }
        public int NumberOfActors
        {
            get => _numberOfActors;
            set 
            {
                if (value <= 0)
                {
                    throw new Exception($"number of actors in film \"{Name}\" less than 1");
                }
                else 
                {
                    _numberOfActors = value;
                }
            }
        }
        public int NumberOfDirectors
        {
            get => _numberOfDirectors;
            set
            {
                if (value <= 0)
                {
                    throw new Exception($"number of directors in film \"{Name}\" less than 1.");
                }
                else
                {
                    _numberOfDirectors = value;
                }
            }
        }
        public Film(string name, string country, DateTime dateOfCreation, List<Actor> arrayOfActors, List<Director> arrayOfDirectors)
        {
            Name = name;
            Country = country;
            DateOfCreation = dateOfCreation;
            actors = new List<Actor>(arrayOfActors);
            NumberOfActors = arrayOfActors.Capacity;
            NumberOfDirectors = arrayOfDirectors.Capacity;
            directors = new List<Director>(arrayOfDirectors);
        }
        public Film()
        {
            try
            {
                FillFilmInfo();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Wrong input data: \"{ex.Message}\", try again");
                FillFilmInfo();
            }
        }
        public void FillFilmInfo()
        {
            Console.Write("\nFill film info:\nEnter name:");
            Name = Console.ReadLine();
            Console.Write("Enter country:");
            Country = Console.ReadLine();
            DateOfCreation = FindDateOfTheFilm();
            FillActorsInfo();
            FillDirectorsInfo();       
        }
        public DisplayStaffInformation GetDelegateOfDisplaingStaffInformation(bool displayActorsInfo, bool displayDirectorInfo)
        {
            DisplayStaffInformation del = null;
            if (displayActorsInfo == true)
            {
                del += DisplayInformationAboutTheActors;
            }
            if (displayDirectorInfo == true)
            {
                del += DisplayInformationAboutTheDirectors;
            }
            return del;
        }
        public void DisplayFilmInfo(DisplayStaffInformation del)
        {
            if (del is not null)
            {
                del();
            }
        }
        public void RateTheFilm(double mark)
        {
            TotalRating = mark;
        }
        private int FillNumberOf(string category)
        {
            try
            {
                Console.Write($"Enter number of {category}s: ");
                if (!int.TryParse(Console.ReadLine(), out int temp))
                {
                    throw new Exception($"Number of {category}s is wrong of film {Name}");
                }
                return temp;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Wrong input data: \"{ex.Message}\", try again");
                return FillNumberOf(category);
            }
        }
        private DateTime FindDateOfTheFilm()
        {
            try
            {
                Console.Write("Enter date of creation: ");
                if (!DateTime.TryParse(Console.ReadLine(), out DateTime temp))
                {
                    throw new Exception($"Wrong date of creation of film {Name}");
                }
                return temp;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Wrong input data: \"{ex.Message}\", try again");
                return FindDateOfTheFilm();
            }
        }
        private void FillActorsInfo()
        {
            try
            {
                NumberOfActors = FillNumberOf("actor");
                Console.WriteLine("Fill actor info:");
                actors = new List<Actor>(NumberOfActors);
                for (int i = 0; i < NumberOfActors; i++)
                {
                    actors[i] = new Actor();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Wrong input data: \"{ex.Message}\", try again");
                FillActorsInfo();
            }
        }
        private void FillDirectorsInfo()
        {
            try
            {      
                NumberOfDirectors = FillNumberOf("director");
                Console.WriteLine("Fill director info:");
                directors = new List<Director>(NumberOfDirectors);
                for (int i = 0; i < NumberOfDirectors; i++)
                {
                    directors[i] = new Director();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Wrong input data: \"{ex.Message}\", try again");
                FillDirectorsInfo();
            }
        }
        public void DisplayInformationAboutTheActors()
        {
            Console.WriteLine($"In the film {Name} starred: ");
            foreach (Person actor in actors)
            {
                actor.ShowInformation();
            }
        }
        public void DisplayInformationAboutTheDirectors()
        {
            Console.WriteLine($"In the film {Name} starred: ");
            foreach (Director director in directors)
            {
                director.ShowInformation();
            }
        }
        private string ActorsToString()
        {
            StringBuilder res = new();
            foreach (var actor in actors)
            {
                res.Append(actor.ToString());
            }
            return res.ToString();
        }
        private string DirectorsToString()
        {
            StringBuilder res = new();
            foreach (var director in directors)
            {
                res.Append(director.ToString());
            }
            return res.ToString();
        }
        public override string ToString()
        {
            return $"{this.Category}///{this.Name}///{this.DateOfCreation.ToString()}///{this.Country}///{actors.Count}///{directors.Count}\n" +
                $"{ActorsToString()}{DirectorsToString()}";

        }
        public bool Equal(Film film2)
        {
            if (film2.DateOfCreation == this.DateOfCreation && film2.Name == this.Name)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
