using HowItShouldBeDone.Repositories;
using HowItShouldBeDone.Viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HowItShouldBeDone.VID
{
    public class GigticketController : Controller
    {
        private readonly GigTicketFormRepository _TickRepos;
        private readonly GenresRepository _GenreRepos;
        public GigticketController()
        {
            _TickRepos = new GigTicketFormRepository();
        }
        //GET: Gigticket
        public ActionResult Create()
        {
            var viewModel = new GigFormViewModel()
            {
                Genres = _GenreRepos.GetAll()

            };
            return View(viewModel);
        }
    }
}