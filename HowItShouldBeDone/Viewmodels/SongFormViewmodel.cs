using HowItShouldBeDone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HowItShouldBeDone
{
    public class SongFormViewmodel
    {
        public List<Album> Albums { get; set; }
        public Song song { get; set; }
    }
}