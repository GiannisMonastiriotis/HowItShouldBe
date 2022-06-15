using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HowItShouldBeDone.Models;
using HowItShouldBeDone.Repositories;

namespace HowItShouldBeDone.VID
{
    public class AlbumsController : Controller
    {
        //private ApplicationDbContext db = new ApplicationDbContext();
        private readonly Artistrepository _Artistrepos;
        private readonly AlbumRepository _Arepos;
        // GET: Albums
        public AlbumsController()
        {
            _Artistrepos = new Artistrepository();
            _Arepos = new AlbumRepository();
        }
        public ActionResult Index()
        {
            var albums = _Arepos.GetAllWithArtist();
            return View(albums.ToList());
        }

        // GET: Albums/Details/5
        public ActionResult Details(int? id)
        {
            //if (id == null)
            //{
            //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            Album album;

            try {
                 album = _Arepos.GetByIdWithArtist(id);
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // GET: Albums/Create
        public ActionResult Create()
        {
            ViewBag.ArtistId = new SelectList(_Artistrepos.GetAll(), "ID", "FullName");
            return View();
        }

        // POST: Albums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,Description,ArtistId")] Album album)
        {
            if (ModelState.IsValid)
            {
                _Arepos.Create(album);
                return RedirectToAction("Index");
            }

            ViewBag.ArtistId = new SelectList(_Artistrepos.GetAll(), "ID", "FirstName", album.ArtistId);
            return View(album);
        }

        // GET: Albums/Edit/5
        public ActionResult Edit(int? id)
        {
            Album album;
            try
            {
                 album = _Arepos.GetById(id);

            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (album == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArtistId = new SelectList(_Artistrepos.GetAll(), "ID", "FullName", album.ArtistId);
            return View(album);
        }

        // POST: Albums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Description,ArtistId")] Album album)
        {
            if (ModelState.IsValid)
            {
                _Arepos.Update(album);
                return RedirectToAction("Index");
            }
            ViewBag.ArtistId = new SelectList(_Arepos.GetAll(), "ID", "FirstName", album.ArtistId);
            return View(album);
        }
         
        // GET: Albums/Delete/5
        public ActionResult Delete(int? id)
        {
            Album album;
            try
            {
                 album = _Arepos.GetByIdWithArtist(id);
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // POST: Albums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
          
            try
            {
                _Arepos.Delete(id);
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _Arepos.Dispose();
                _Artistrepos.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
