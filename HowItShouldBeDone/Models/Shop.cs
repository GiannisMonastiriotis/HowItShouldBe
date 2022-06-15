using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HowItShouldBeDone.Models
{
    public class Shop
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Album> Albums { get; set; }
    }
}