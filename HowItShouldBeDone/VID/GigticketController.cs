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
        public ActionResult Create(GigFormViewModel viewModel)
        {
            var customerId = User.Identity.GetUserId();
            var customer = _context.Users.Single(u => u.Id == customerId);
            var genre = _context.Genres.Single(g => g.Id == viewModel.Genre);

            var gig = new Gigticket()
            {
                Customer = customer,
                DateTime = DateTime.Parse(string.Format("{0} {1}",viewModel.Date, viewModel.Time)),
                Venue = viewModel.Venue,
                Genre = genre
            };
            return RedirectToAction("Index", "Home");
        }
    }
}