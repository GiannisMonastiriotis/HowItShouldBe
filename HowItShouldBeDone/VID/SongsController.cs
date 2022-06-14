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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Song song)
        {
            try
            {
                song.Youtube = $"https://www.youtube.com/embed/{song.Youtube}";
                _context.Songs.Add(song);
                if (!ModelState.IsValid)
                {
                    var viewModel = new SongFormViewmodel() { song = new Song(),Albums = _context.Albums.ToList()};
                    return View("SongFrom", viewModel);
                }
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
    
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var song = _context.Songs
                .Include(s=> s.Album)
                .SingleOrDefault(s => s.ID == id);
            if(song == null)
            {
                return HttpNotFound();
            }

            var albums = _context.Albums.ToList();

            var viewModel = new SongFormViewmodel()
            {
                song = song,
                Albums = albums
            };

            return View("SongFrom", viewModel);

        }
    }
}