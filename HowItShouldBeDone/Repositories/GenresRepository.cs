using HowItShouldBeDone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HowItShouldBeDone.Repositories
{
    public class GenresRepository
    {
        private readonly ApplicationDbContext _context;

        public GenresRepository()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<Genre> GetAll()
        {
            var genres = _context.Genres.ToList();
            return genres;
        }
    }
}