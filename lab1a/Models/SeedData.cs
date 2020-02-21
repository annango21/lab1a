using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using lab1a.Data;
using System;
using System.Linq;
using System.Collections.Generic;

namespace lab1a.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RazorPagesMovieContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RazorPagesMovieContext>>()))
            {
                
               if (!context.Genres.Any())
                {
                    context.Genres.AddRange(
                        new Genre{
                            Name = "Romantic Comedy"
                        },
                        new Genre {
                            Name = "Comedy"
                        },
                        new Genre {
                            Name = "Western"
                        }

                    );
                    context.SaveChanges();
                }
                //immediately get the new genres into a list
                //List<Genre>
                var genres = context.Genres.ToList();
                 // Look for any movies.
                if (!context.Movie.Any())
                {
                     context.Movie.AddRange(
                    new Movie
                    {
                        Title = "When Harry Met Sally",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        GenreId = genres.Find(g => g.Name == "Romantic Comedy").Id,
                        Price = 7.99M
                    },

                    new Movie
                    {
                        Title = "Ghostbusters ",
                        ReleaseDate = DateTime.Parse("1984-3-13"),
                        GenreId = genres.Find(g => g.Name == "Comedy").Id,
                        Price = 8.99M
                    },

                    new Movie
                    {
                        Title = "Ghostbusters 2",
                        ReleaseDate = DateTime.Parse("1986-2-23"),
                        GenreId = genres.Find(g => g.Name == "Comedy").Id,
                        Price = 9.99M
                    },

                    new Movie
                    {
                        Title = "Rio Bravo",
                        ReleaseDate = DateTime.Parse("1959-4-15"),
                        GenreId = genres.Find(g => g.Name == "Western").Id,
                        Price = 3.99M
                    }
                );
                context.SaveChanges();
                }
            }
            
        }
    }
}