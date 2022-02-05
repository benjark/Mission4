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
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)

        {
            //leaving blank for now
        }
        public DbSet<MovieModel> Movies { get; set; }
        public DbSet<Category> Categorys{get;set;}


        // Setting up a seeded database

        protected override void OnModelCreating(ModelBuilder mb)
        {

         

            mb.Entity<Category>().HasData(
                new Category { CategoryID = 1, CategoryName ="Action"},
                new Category { CategoryID = 2, CategoryName = "Romance" },
                new Category { CategoryID = 3, CategoryName = "Thriller" },
                new Category { CategoryID = 4, CategoryName = "Historical" }
                );
            mb.Entity<MovieModel>().HasData(

                new MovieModel
                {
                    MovieID = 1,
                    Title = "Revenge of the Sith",
                    CategoryID = 1,
                    Director = "George Lucas",
                    Rating = "PG-13",
                    Year = "2005",
                    Edited = false


                },
                new MovieModel
                {
                    MovieID = 2,
                    Title = "Bourne Ultimatum",
                    CategoryID = 1,
                    Director = "Paul Greengrass",
                    Rating = "PG-13",
                    Year = "2007",
                    Edited = false
                },
                new MovieModel
                {
                    MovieID = 3,
                    Title = "Endgame",
                    CategoryID = 1,
                    Director = "Joe and Anthony Russo",
                    Rating = "PG-13",
                    Year = "2018",
                    Edited = false
                }
                );
        }
    }
}
