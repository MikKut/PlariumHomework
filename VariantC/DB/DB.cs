using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace MainProject.DB
{
    class DataBase
    {
        static string pathToCurrentBD;
        static string pathToBackup;
        static string pathToDBBackup;
        public DataBase(string thepathToCurrentBD)
        {
            pathToCurrentBD = MakeFileName(thepathToCurrentBD, ".txt");
            pathToBackup = MakeFileName(thepathToCurrentBD + "_backup",".json");
            pathToDBBackup = MakeFileName("backup", ".txt");
            if (!File.Exists(pathToCurrentBD))
            {
                File.Create(pathToCurrentBD).Close();
            }
            if (!File.Exists(pathToBackup))
            {
                File.Create(pathToBackup).Close();
            }
            if (!File.Exists(pathToBackup))
            {
                File.Create(pathToDBBackup).Close();
            }
        }
        private readonly string SeparatorInTheEnd = "------------------------------";
       
        public void CreateRecords(VideoLibrary vb)
        {          
            try
            {
                using (StreamWriter sw = new StreamWriter(pathToCurrentBD, false, Encoding.Default))
                {
                    sw.WriteLine(vb.films.Values.Count);
                    foreach (var film in vb.films) 
                    {
                        sw.WriteLine(film.Value.ToString());
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + " so the data base was backuped");
                try
                {
                    File.Copy(pathToDBBackup, pathToCurrentBD, true);
                }
                catch (IOException iox)
                {
                    Console.WriteLine(iox.Message);
                }
            }
        }
    
        public VideoLibrary ReadRecords() 
        {
            var vb = new VideoLibrary();
            try
            {
                string nameOfTheFilm = "", country = "", category = "";
                string[] actorInfo;
                string[] directorInfo;
                int numberOfActors = 0, numberOfDirectors = 0;
                List<Actor> actors;
                List<Director> directors;
                DateTime dateOfCreation = default(DateTime);
                using (StreamReader sr = new StreamReader(pathToCurrentBD, Encoding.Default))
                {
                    int countOfFilms = Int32.Parse(sr.ReadLine());
                    for (int i = 0; i < countOfFilms; i++)
                    {
                        FillToFilmInfo(sr.ReadLine().Split("///"),ref category, ref nameOfTheFilm, ref country, ref numberOfActors, ref numberOfDirectors, ref dateOfCreation);
                        actors = new(numberOfActors);
                        directors = new(numberOfDirectors);
                        for (int j = 0; j < numberOfActors; j++)
                        {
                            actorInfo = sr.ReadLine().Split(" ");
                            actors.Add(new Actor(actorInfo[0], DateTime.Parse(actorInfo[1])));
                        }
                        for (int j = 0; j < numberOfDirectors; j++)
                        {
                            directorInfo = sr.ReadLine().Split(" ");
                            directors.Add(new Director(directorInfo[0], DateTime.Parse(directorInfo[1])));
                        }
                        switch (category)
                        {
                            case "horror":
                                vb.AddFilm(new HorrorFilm(nameOfTheFilm, country, dateOfCreation, actors, directors));
                                break;
                            case "comedy":
                                vb.AddFilm(new ComedyFilm(nameOfTheFilm, country, dateOfCreation, actors, directors));
                                break;
                            case "action":
                                vb.AddFilm(new ComedyFilm(nameOfTheFilm, country, dateOfCreation, actors, directors));
                                break;
                        }
                        sr.ReadLine();
                    }
                }
                MakeBackup(vb);
                return vb;
            }
                
            catch (Exception e)
            {
                Console.WriteLine($"Error in reading video library: \"{e.Message}\" so the library is backuped");
                UpdateRecords(GetBackup());
                return GetBackup();
            }
        }
        public void UpdateRecords(VideoLibrary vb) // Обновить запись заказа по телефону.
        {
             try 
             {
                EraseBD();
                CreateRecords(vb);
                MakeBackup(vb);
             }
             catch (Exception e)
             {
                 Console.WriteLine(e.Message);
                 CreateRecords(GetBackup());
             }
        }
        public void EraseBD()
        {
            try
            {
                if (File.Exists(pathToCurrentBD))
                {
                    File.Delete(pathToCurrentBD);
                }
                else
                {
                    throw new FileNotFoundException();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"There is no files to delete");
            }
          
        }
        public VideoLibrary GetBackup()
        {
            return JsonSerializer.Deserialize<VideoLibrary>(pathToBackup);
        }
        private void MakeBackup(VideoLibrary vb)
        {
            StringBuilder jsonString = new(JsonSerializer.Serialize<VideoLibrary>(vb));
            foreach (var film in vb.films)
            {
                jsonString.Append(JsonSerializer.Serialize(film.Value));
            }
            File.WriteAllText(pathToDBBackup, jsonString.ToString());
        }
        private void FillToFilmInfo(string[] data, ref string category, ref string nameOfTheFilm, ref string country, ref int numberOfActors, ref int numberOfDirectors, ref DateTime dateOfCreation)
        {
            #region Film.ToString()
            //Film.ToString(): 
            //
            //    return $"{this.Category}///{this.Name}///{this.DateOfCreation.ToString()}///{this.Country}///{this.NumberOfActors}///{this.NumberOfDirectors}\n" +
            //       $"{ActorsToString()}+\n{DirectorsToString()}";
            #endregion
            category = data[0];
            nameOfTheFilm = data[1];
            dateOfCreation = DateTime.Parse(data[2]);
            country = data[3];
            numberOfActors = Int32.Parse(data[4]);
            numberOfDirectors = Int32.Parse(data[5]);
        }
        public bool FilmExists(Film film)
        {
            try
            {
                bool isFound = false;
                string nameOfTheFilm = "", country = "", category = "";
                int numberOfActors = 0, numberOfDirectors = 0;
                string[] actorInfo;
                string[] directorInfo;
                List<Actor> actors;
                List<Director> directors;
                DateTime dateOfCreation = default(DateTime);
                using (StreamReader sr = new StreamReader(pathToCurrentBD, Encoding.Default))
                {
                    int countOfFilms = Int32.Parse(sr.ReadLine());
                    for (int i = 0; i < countOfFilms; i++)
                    {
                        FillToFilmInfo(sr.ReadLine().Split("///"), ref category, ref nameOfTheFilm, ref country, ref numberOfActors, ref numberOfDirectors, ref dateOfCreation);
                        actors = new(numberOfActors);
                        directors = new(numberOfDirectors);
                        if ((numberOfActors == film.NumberOfActors && numberOfDirectors == film.NumberOfDirectors && category == film.Category && country == film.Country)) isFound = true;
                        for (int j = 0; j < numberOfActors; j++)
                        {
                            actorInfo = sr.ReadLine().Split(" ");
                            actors.Add(new Actor(actorInfo[0], DateTime.Parse(actorInfo[1])));
                        }
                        if (film.actors.Equals(actors))
                        {
                            isFound = true;
                        }
                        else
                        {
                            isFound = false;
                        }
                        for (int j = 0; j < numberOfDirectors; j++)
                        {
                            directorInfo = sr.ReadLine().Split(" ");
                            directors.Add(new Director(directorInfo[0], DateTime.Parse(directorInfo[1])));
                        }
                        if (film.actors.Equals(actors))
                        {
                            isFound = true;
                        }
                        else
                        {
                            isFound = false;
                        }
                        if (isFound)
                        {
                            return true;
                        }
                        else
                        {
                            sr.ReadLine();
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private string MakeFileName(string fileName, string ending)
        {
            if (!Regex.IsMatch(fileName, $@"\w *{ending}$"))
            {
                fileName += $@"{ending}";
            }
            StringBuilder pathToCurrentBDOfTheDB = new StringBuilder();
            pathToCurrentBDOfTheDB.Append(fileName);
            return pathToCurrentBDOfTheDB.ToString();
        }
    }
    
}

 