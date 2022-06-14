using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HowItShouldBeDone.Models
{
    public class Song
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(255, MinimumLength = 3)]
        [Display(Name ="Song Title")]
        public string Title { get; set; }
        [Display(Name = "Album")]
        public int AlbumId { get; set; }
        public Album Album { get; set; }

        public string Youtube { get; set; }
    }
}