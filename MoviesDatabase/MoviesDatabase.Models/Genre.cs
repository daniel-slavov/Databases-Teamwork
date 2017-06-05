﻿using System.Collections.Generic;
using MoviesDatabase.Models.Contracts;
using System.ComponentModel.DataAnnotations;

namespace MoviesDatabase.Models
{
    public class Genre : IModel
    {
        public Genre()
        {
            this.Movies = new HashSet<Movie>();
        }

        public Genre(string name) : this()
        {
            this.Name = name;
        }

        public int GenreID { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
