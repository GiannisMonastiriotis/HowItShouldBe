using HowItShouldBeDone.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
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

        public ActionResult Details(int? id)
        {
            if(id == null)
            {   
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var song = _context.Songs.Include(s => s.Album.Artist).SingleOrDefault(s => s.ID == id);
            if(song == null)
            {
                return HttpNotFound();
            }
            return View(song);
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        public ActionResult New()
        {
            var Albums = _context.Albums.ToList();

            var viewmodel = new SongFormViewmodel()
            {
                song = new Song(),
                Albums = Albums
            };
            return View("SongForm", viewmodel);
        }
    }
}