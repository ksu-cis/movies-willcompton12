﻿using System;
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

        [BindProperty]
        public string search { get; set; }

        [BindProperty]
        public List<string> rating { get; set; } = new List<string>();

        [BindProperty]
        public float? minIMDB { get; set; }

        [BindProperty]
        public float? maxIMDB { get; set; }

        public void OnGet()
        {
            Movies = movieDatabase.All;
        }

        public void OnPost()
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
