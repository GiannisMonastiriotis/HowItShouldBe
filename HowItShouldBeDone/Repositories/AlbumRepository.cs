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
        public Album GetById(int id)
        {
            return _context.Albums.SingleOrDefault(a => a.ID == id);
        }

        public Album GetByIdWithArtist(int? id)
        {   if(id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            return _context.Albums.Include(a => a.Artist).SingleOrDefault(a => a.ID == id);
        }
    }
}