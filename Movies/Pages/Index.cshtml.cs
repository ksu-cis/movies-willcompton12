using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Movies.Pages
{
    public class IndexModel : PageModel
    {
        MovieDatabase movieDatabase = new MovieDatabase();

        public List<Movie> Movies;
        public void OnGet()
        {
            Movies = movieDatabase.All;
        }

        public void OnPost(string search, List<string> rating, float? minIMDB, float? maxIMDB)
        {
            Movies = movieDatabase.All;

            if(search != null)
            {
                Movies = movieDatabase.Search(Movies, search);
            }

            if(rating.Count != 0)
            {
                Movies = movieDatabase.FilterByMPAA(Movies, rating);
            }
            if (minIMDB != null)
            {
                Movies = movieDatabase.FilterByMinIMDB(Movies, (float)minIMDB);
            }
            if(maxIMDB != null)
            {
                Movies = movieDatabase.FilterByMaxIMDB(Movies, (float)maxIMDB);
            }
        }
    }
}
