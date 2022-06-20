using HowItShouldBeDone.Models;
using HowItShouldBeDone.Repositories;
using HowItShouldBeDone.Viewmodels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HowItShouldBeDone.VID
{
    public class GigticketController : Controller
    {
       // private readonly GigTicketFormRepository _TickRepos;
        //private readonly GenresRepository _GenreRepos;
        private readonly ApplicationDbContext _context;
        public GigticketController()
        {
           // _TickRepos = new GigTicketFormRepository();
            //_GenreRepos = new GenresRepository();
            _context = new ApplicationDbContext();
        }
        //GET: Gigticket
        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new GigFormViewModel()
            {
                //Genres = _GenreRepos.GetAll()
                Genres = _context.Genres.ToList()
            }; 
            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GigFormViewModel viewModel)
        {
            
          
            var genre = _context.Genres.Single(g => g.Id == viewModel.Genre);

            if (!ModelState.IsValid)
            {
                viewModel.Genres = _context.Genres.ToList();
                return View("Create", viewModel);
            }
            var gig = new Gigticket()
            {
                ArtistId = User.Identity.GetUserId(),
                DateTime = viewModel.GetDateTime(),
                Venue = viewModel.Venue,
                GenreId = viewModel.Genre
        };
            return RedirectToAction("Index", "Home");
        }
    }
}