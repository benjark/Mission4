using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mission4.Models
{
    public class MovieContext : DbContext
    {
        // Set up standard options
        public MovieContext (DbContextOptions<MovieContext> options) : base (options)

        { 
             
         }
        public DbSet<MovieModel> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<MovieModel>().HasData(
                new MovieModel
                {
                    Title = "Revenge of the Sith",
                    Category = "Action",
                    Director = "George Lucas",
                    Rating = "PG-13",
                    Year = "2005",
                    Edited = false


                },
                new MovieModel
                {
                    Title = "Bourne Ultimatum",
                    Category = "Action",
                    Director = "Paul Greengrass",
                    Rating = "PG-13",
                    Year = "2007",
                    Edited = false
                },
                new MovieModel
                {
                    Title = "Endgame",
                    Category = "Action",
                    Director = "Joe and Anthony Russo",
                    Rating = "PG-13",
                    Year = "2018",
                    Edited = false
                }
                );
        }
    }
}
