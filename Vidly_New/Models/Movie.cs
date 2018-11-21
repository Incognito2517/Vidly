﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly_New.Models;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public Genre Genre { get; set; }
        [Required]
        [Display (Name = "Genre")]
        public byte GenreId { get; set; }
        [Required]
        [Display (Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }
        [Timestamp]
        public byte[] Timestamp { get; set; }
        [Required]
        [Range (1, 20)]
        [Display (Name = "Number in Stock")]
        public int NumberInStock { get; set; }

    }
}