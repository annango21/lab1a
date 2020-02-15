using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using lab1a.Data;
using lab1a.Models;

namespace lab1a.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly lab1a.Data.RazorPagesMovieContext _context;

        public IndexModel(lab1a.Data.RazorPagesMovieContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; }

        public async Task OnGetAsync()
        {
            Movie = await _context.Movie.ToListAsync();
        }
    }
}
