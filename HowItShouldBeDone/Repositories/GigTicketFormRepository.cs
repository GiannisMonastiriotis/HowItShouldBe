using HowItShouldBeDone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HowItShouldBeDone.Viewmodels
{
    public class GigTicketFormRepository
    {
        private readonly ApplicationDbContext _context;

        public GigTicketFormRepository()
        {
            _context = new ApplicationDbContext();
        }
         
        public IEnumerable<Gigticket> GetAll()
        {
            var gigtickets = _context.Gigtickets.ToList();
            return gigtickets;
        }
        public void Create(Gigticket ticket)
        {
            _context.Gigtickets.Add(ticket);
            _context.SaveChanges();
        }


        public void Dispose()
        {
            _context.Dispose();
        }
    }
}