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

        //ICollection<Shop> Shops { get; set; }

        //ICollection<Album> Albums { get; set; }

        //public ManagingAlbumShop()
        //{
        //    Shops = new HashSet<Shop>();
        //    Albums = new HashSet<Album>();
        //}
       // [ForeignKey("Album")]
        public Album Album { get; set; }
      //  [ForeignKey("Shop")]
        public Shop Shop { get; set; }
       
        public int ShopId { get; set; }
       
        public int AlbumId { get; set; }

    }
}