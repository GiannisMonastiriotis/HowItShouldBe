using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HowItShouldBeDone.Models
{
    public class ManagingAlbumShop
    {

        public Album Album { get; set; }

        public Shop Shop { get; set; }
       
        [Key]
        [Column(Order = 1)]
        public int ShopId { get; set; }
        [Key]
        [Column(Order = 2)]
        public int AlbumId { get; set; }

    }
}