using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using MvcMovie.Models.Database;

namespace MvcMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DataBaseContext(
                serviceProvider.GetRequiredService<DbContextOptions<DataBaseContext>>()))
            {
                // Look for any movies.
                if (context.Movies.Any())
                {
                    if (context.Comments.Any())
                    {
                        return;   // DB has been seeded
                    }
                    else
                    {
                        context.Comments.AddRange(
                            new Comment
                            {
                                Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec id nibh mollis, finibus urna sed, finibus augue.",
                                Movie = context.Set<Movie>().Find(1)
                            },
                            new Comment
                            {
                                Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec id nibh mollis, finibus urna sed, finibus augue.",
                                Movie = context.Set<Movie>().Find(2)
                            },
                            new Comment
                            {
                                Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec id nibh mollis, finibus urna sed, finibus augue.",
                                Movie = context.Set<Movie>().Find(3)
                            },
                            new Comment
                            {
                                Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec id nibh mollis, finibus urna sed, finibus augue.",
                                Movie = context.Set<Movie>().Find(4)
                            }
                        );
                        context.SaveChanges();
                        return;
                    }
                }
                else
                {
                    context.Movies.AddRange(
                        new Movie
                        {
                            Title = "When Harry Met Sally",
                            ReleaseDate = DateTime.Parse("1989-1-11"),
                            Genre = "Romantic Comedy",
                            Price = 7.99M,
                            Rating = "C"
                        },

                        new Movie
                        {
                            Title = "Ghostbusters ",
                            ReleaseDate = DateTime.Parse("1984-3-13"),
                            Genre = "Comedy",
                            Price = 8.99M,
                            Rating = "R"
                        },

                        new Movie
                        {
                            Title = "Ghostbusters 2",
                            ReleaseDate = DateTime.Parse("1986-2-23"),
                            Genre = "Comedy",
                            Price = 9.99M,
                            Rating = "M"
                        },

                        new Movie
                        {
                            Title = "Rio Bravo",
                            ReleaseDate = DateTime.Parse("1959-4-15"),
                            Genre = "Western",
                            Price = 3.99M,
                            Rating = "M"
                        }
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}
