using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using HowItShouldBeDone.Models;

namespace HowItShouldBeDone.Repositories
{
    public class AlbumRepository
    {
        private readonly ApplicationDbContext _context;

        public AlbumRepository()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<Album> GetAll()
        {
            return _context.Albums;
        }

        public IEnumerable<Album> GetAllWithArtist()
        {
            var albums = _context.Albums.Include(a => a.Artist);
            return albums; 
        }
    }
}