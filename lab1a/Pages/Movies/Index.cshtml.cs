using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using lab1a.Data;
using lab1a.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace lab1a.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly lab1a.Data.RazorPagesMovieContext _context;

        public IndexModel(lab1a.Data.RazorPagesMovieContext context)
        {
            _context = context;
        }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        // Requires using Microsoft.AspNetCore.Mvc.Rendering;
        public SelectList Genres { get; set; }
        [BindProperty(SupportsGet = true)]
        public string MovieGenre { get; set; }

        public IList<Movie> Movie { get;set; }

       public async Task OnGetAsync()
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from g in _context.Genres
                                            orderby g.Name
                                            select g.Name;

            var movies = from m in _context.Movie.Include(m => m.Genre)
                        select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                movies = movies.Where(s => s.Title.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(MovieGenre))
            {
                movies = movies.Where(movie => movie.Genre.Name == MovieGenre);
            }
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            Movie = await movies.ToListAsync();
        }
    }
}
