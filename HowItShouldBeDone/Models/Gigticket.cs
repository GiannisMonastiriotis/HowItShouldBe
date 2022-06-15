using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HowItShouldBeDone.Models
{
    public class Gigticket
    {
        public int Id { get; set; }
        [Required]
        public ApplicationUser Customer { get; set; }

        [Required]
        public string ArtistId { get; set; }

        [Required]
        public byte GenreId { get; set; }
        public DateTime DateTime { get; set; }

        
        [StringLength(255)]
        public string Venue { get; set; }

  
        public Genre Genre { get; set; }

        public double Price { get; set; }
    }
}