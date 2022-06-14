using HowItShouldBeDone.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HowItShouldBeDone.VID
{
    public class SongsController : Controller
    {
        // GET: Songs

        private readonly ApplicationDbContext _context;

        public SongsController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var songs = _context.Songs.Include(a => a.Album.Artist).ToList();
            return View(songs);
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

    }
}