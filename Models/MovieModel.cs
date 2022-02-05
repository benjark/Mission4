using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

// Model for the movies, including all of the data types that will need to be put into the database. 
namespace Mission4.Models
{
    public class MovieModel
    {
        [Key]
        [Required]
        public int MovieID { get; set; }

        public string Title { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public string Rating { get; set; }

        [Required]
        public string Year { get; set; }

        public bool Edited { get; set; }

        public string LentTo { get; set; }

        [MaxLength(25)]
        public string Notes { get; set; }

        //Build Foreign Key Relationship
        
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
