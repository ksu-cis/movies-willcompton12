using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Movies
{
    /// <summary>
    /// A class representing a database of movies
    /// </summary>
    public class MovieDatabase
    {
        private  List<Movie> movies = new List<Movie>();

        /// <summary>
        /// Loads the movie database from the JSON file
        /// </summary>
        public MovieDatabase() {
            
            using (StreamReader file = System.IO.File.OpenText("movies.json"))
            {
                string json = file.ReadToEnd();
                movies = JsonConvert.DeserializeObject<List<Movie>>(json);
            }
        }

        public  List<Movie> All { get { return movies; } }

        public  List<Movie> Search(List<Movie> movies, string term)
        {
         
            List<Movie> result = new List<Movie>();

            foreach(Movie movie in All)
            {
               if( movie.Title.Contains(term, StringComparison.CurrentCultureIgnoreCase))
                {
                    result.Add(movie);
                }
            }

            return result;
        }

        public  List<Movie> FilterByMPAA(List<Movie> movies, List<string> mpaa)
        {
            List<Movie> results = new List<Movie>();

            foreach(Movie movie in movies)
            {
                if (mpaa.Contains(movie.MPAA_Rating))
                {
                    results.Add(movie);
                }
            }

            return results;
        }

        public List<Movie> FilterByMinIMDB(List<Movie> movies, float minIMDB)
        {
            List<Movie> results = new List<Movie>();

            foreach(Movie movie in movies)
            {
                if (movie.IMDB_Rating >= minIMDB)
                {
                    results.Add(movie);
                }
            }

            return results;
        }

        public List<Movie> FilterByMaxIMDB(List<Movie> movies, float maxIMDB)
        {
            List<Movie> results = new List<Movie>();

            foreach (Movie movie in movies)
            {
                if (movie.IMDB_Rating <= maxIMDB)
                {
                    results.Add(movie);
                }
            }

            return results;
        }

        public List<Movie> Filter(List<string> ratings)
        {
            List<Movie> result = new List<Movie>();

            foreach(Movie movie in movies)
            {
                if (ratings.Contains(movie.MPAA_Rating))
                {
                    result.Add(movie);
                }
            }

            return result;
        }

        public List<Movie> SearchAndFilter(string searchString, List<string> ratings)
        {

            List<Movie> result = new List<Movie>();

            foreach(Movie movie in movies)
            {
                if (ratings.Contains(movie.MPAA_Rating) && movie.Title.Contains(searchString, StringComparison.CurrentCultureIgnoreCase))
                {
                    result.Add(movie);
                }
            }

            return result;
        }
    }
}
