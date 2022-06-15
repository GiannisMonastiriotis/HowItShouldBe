using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using HowItShouldBeDone.Models;

namespace HowItShouldBeDone.Repositories
{
    public class Artistrepository
    {
        private readonly ApplicationDbContext _context;

        public Artistrepository()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<Artist> GetAll()
        {
            return _context.Artists;
        }

        public IEnumerable<Artist> GetAllWithAlbum()
        {
            var artists = _context.Artists.Include(a => a.Albums);
            return artists; 
        }
        public Artist GetById(int? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            return _context.Artists.SingleOrDefault(a => a.ID == id);
        }

        public Artist GetByIdWithAlbum(int? id)
        {   if(id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            return _context.Artists.Include(a => a.Albums).SingleOrDefault(a => a.ID == id);
        }
        
        public void Create(Artist artist)
        {
            _context.Artists.Add(artist);
            _context.SaveChanges();
        }

        public void Update(Artist artist)
        {
            _context.Entry(artist).State = EntityState.Modified;
            _context.SaveChanges();

        }
        public void Delete(int? id)
        {   if(id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            var artist = GetById(id);
            _context.Artists.Remove(artist);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}