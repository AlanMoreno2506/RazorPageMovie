﻿using Microsoft.EntityFrameworkCore;
using RazorPageMovie.Data;
using System;
using System.ComponentModel.DataAnnotations;

namespace RazorPageMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {

            using (var context = new RazorPageMovieContext(
            serviceProvider.GetRequiredService<
             DbContextOptions<RazorPageMovieContext>>()))
            {
                if (context == null || context.Movie == null)
                {
                    throw new ArgumentException("Null RazorPagesMovieContext");
                }
                //Para mirar cualquier pelicula 
                if (context.Movie.Any())
                {
                    return;  //Db muestra todo lo que contiene la clase
                }

                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "When Harry met Sally",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Genre = "Romantic Comedy",
                        Price = 7.99M,
                        Rating = "R"
                    },
                    new Movie
                    {
                        Title = "GhostBusters",
                        ReleaseDate = DateTime.Parse("1984-3-13"),
                        Genre = "Comedy",
                        Price = 8.99M,
                        Rating = "E"
                    },
                    new Movie
                    {
                        Title = "GhostBusters 2",
                        ReleaseDate = DateTime.Parse("1986-2-23"),
                        Genre = "Comedy",
                        Price = 9.99M,
                        Rating = "E"
                    },
                    new Movie
                    {
                        Title = "Rio Bravo",
                        ReleaseDate = DateTime.Parse("1959-4-15"),
                        Genre = "Western",
                        Price = 3.99M,
                        Rating = "NA"
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
