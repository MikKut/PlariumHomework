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
        public DataBase(string thepathToCurrentBD)
        {
            pathToCurrentBD = MakeFileName(thepathToCurrentBD, ".txt");
            pathToBackup = MakeFileName(thepathToCurrentBD + "_backup",".json");
            if (!File.Exists(pathToCurrentBD))
            {
                File.Create(pathToCurrentBD).Close();
            }
            if (!File.Exists(pathToBackup))
            {
                File.Create(pathToBackup).Close();
            }
            CreateRecords(new VideoLibrary());
        }
       
        public void CreateRecords(VideoLibrary vb)
        {          
            try
            {
                using (var sw = new StreamWriter(pathToCurrentBD, false, Encoding.Default))
                {
                    sw.WriteLine(vb.Films.Values.Count);
                    foreach (var film in vb.Films) 
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
                    CreateRecords(GetBackup());
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
                List<Actor> Actors;
                List<Director> Directors;
                DateTime dateOfCreation = default;
                using (var sr = new StreamReader(pathToCurrentBD, Encoding.Default))
                {
                    int countOfFilms = Int32.Parse(sr.ReadLine());
                    for (int i = 0; i < countOfFilms; i++)
                    {
                        FillToFilmInfo(sr.ReadLine().Split("///"),ref category, ref nameOfTheFilm, ref country, ref numberOfActors, ref numberOfDirectors, ref dateOfCreation);
                        Actors = new(numberOfActors);
                        Directors = new(numberOfDirectors);
                        for (int j = 0; j < numberOfActors; j++)
                        {
                            actorInfo = sr.ReadLine().Split(" ");
                            Actors.Add(new Actor(actorInfo[0], DateTime.Parse(actorInfo[1])));
                        }
                        for (int j = 0; j < numberOfDirectors; j++)
                        {
                            directorInfo = sr.ReadLine().Split(" ");
                            Directors.Add(new Director(directorInfo[0], DateTime.Parse(directorInfo[1])));
                        }
                        switch (category)
                        {
                            case "horror":
                                vb.AddFilm(new HorrorFilm(nameOfTheFilm, country, dateOfCreation, Actors, Directors));
                                break;
                            case "comedy":
                                vb.AddFilm(new ComedyFilm(nameOfTheFilm, country, dateOfCreation, Actors, Directors));
                                break;
                            case "action":
                                vb.AddFilm(new ComedyFilm(nameOfTheFilm, country, dateOfCreation, Actors, Directors));
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
        public void UpdateRecords(VideoLibrary vb) 
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
                Console.WriteLine($"There is no files to delete: \"{ex.Message}\"");
            }
          
        }
        public VideoLibrary GetBackup()
        {
            VideoLibrary vb;
            Film film;
            List<Actor> theActors = new();
            List<Director> theDirectors = new();
            string  filmString ;
            using (var sr = new StreamReader(pathToBackup, Encoding.Default))
            {
                vb = new VideoLibrary(JsonSerializer.Deserialize<VideoLibrary>(sr.ReadLine()));
                for (int i = 0; i < vb.NumberOfFilms; i++)
                {
                    filmString = sr.ReadLine();
                    if (filmString.StartsWith("{\"Category\":\"horror"))
                    {
                        film = JsonSerializer.Deserialize<HorrorFilm>(filmString);
                        for (int j = 0; j < film.NumberOfActors; j++)
                        {
                            theActors.Add(JsonSerializer.Deserialize<Actor>(sr.ReadLine()));
                        }
                        film.ChangeActorsInfo(theActors);
                        for (int j = 0; j < film.NumberOfDirectors; j++)
                        {
                            theDirectors.Add(JsonSerializer.Deserialize<Director>(sr.ReadLine()));
                        }
                        film.ChangeDirectorsInfo(theDirectors);
                        vb.Films.Add(i, new HorrorFilm(film));
                    }
                    else if (filmString.StartsWith("{\"Category\":\"comedy"))
                    {
                        film = JsonSerializer.Deserialize<ComedyFilm>(filmString);
                        for (int j = 0; j < film.NumberOfActors; j++)
                        {
                            theActors.Add(JsonSerializer.Deserialize<Actor>(sr.ReadLine()));
                        }
                        film.ChangeActorsInfo(theActors);
                        for (int j = 0; j < film.NumberOfDirectors; j++)
                        {
                            theDirectors.Add(JsonSerializer.Deserialize<Director>(sr.ReadLine()));
                        }
                        film.ChangeDirectorsInfo(theDirectors);
                        vb.Films.Add(i, new ComedyFilm(film));
                    }
                    else if (filmString.StartsWith("{\"Category\":\"action"))
                    {
                        film = JsonSerializer.Deserialize<ActionFilm>(filmString);
                        for (int j = 0; j < film.NumberOfActors; j++)
                        {
                            theActors.Add(JsonSerializer.Deserialize<Actor>(sr.ReadLine()));
                        }
                        film.ChangeActorsInfo(theActors);
                        for (int j = 0; j < film.NumberOfDirectors; j++)
                        {
                            theDirectors.Add(JsonSerializer.Deserialize<Director>(sr.ReadLine()));
                        }
                        film.ChangeDirectorsInfo(theDirectors);
                        vb.Films.Add(i, new ActionFilm(film));
                    }
                    else
                    {
                        throw new JsonException("There is no such category of film");
                    }
                }              
            }
            return vb;
        }

        private void MakeBackup(VideoLibrary vb)
        {
            StringBuilder jsonString = new(JsonSerializer.Serialize<VideoLibrary>(vb));
            Console.WriteLine(jsonString);
            foreach (var film in vb.Films)
            {
                jsonString.Append('\n');
                jsonString.Append(JsonSerializer.Serialize(film.Value));
                foreach (var actor in film.Value.Actors)
                {
                    jsonString.Append('\n');
                    jsonString.Append(JsonSerializer.Serialize(actor));
                }
                foreach (var director in film.Value.Directors)
                {
                    jsonString.Append('\n');
                    jsonString.Append(JsonSerializer.Serialize(director));
                }
            } 
            File.WriteAllText(pathToBackup, jsonString.ToString());
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
                List<Actor> Actors;
                List<Director> Directors;
                DateTime dateOfCreation = default;
                using (var sr = new StreamReader(pathToCurrentBD, Encoding.Default))
                {
                    int countOfFilms = Int32.Parse(sr.ReadLine());
                    for (int i = 0; i < countOfFilms; i++)
                    {
                        FillToFilmInfo(sr.ReadLine().Split("///"), ref category, ref nameOfTheFilm, ref country, ref numberOfActors, ref numberOfDirectors, ref dateOfCreation);
                        Actors = new(numberOfActors);
                        Directors = new(numberOfDirectors);
                        if ((numberOfActors == film.NumberOfActors && numberOfDirectors == film.NumberOfDirectors && category == film.Category && country == film.Country)) isFound = true;
                        for (int j = 0; j < numberOfActors; j++)
                        {
                            actorInfo = sr.ReadLine().Split(" ");
                            Actors.Add(new Actor(actorInfo[0], DateTime.Parse(actorInfo[1])));
                        }
                        if (film.Actors.Equals(Actors))
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
                            Directors.Add(new Director(directorInfo[0], DateTime.Parse(directorInfo[1])));
                        }
                        if (film.Actors.Equals(Actors))
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
            var pathToCurrentBDOfTheDB = new StringBuilder();
            pathToCurrentBDOfTheDB.Append(fileName);
            return pathToCurrentBDOfTheDB.ToString();
        }
    }
    
}

 