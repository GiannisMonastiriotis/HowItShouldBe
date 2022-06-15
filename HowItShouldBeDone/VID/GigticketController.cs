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

        public GigticketController()
        {
            _TickRepos = new GigTicketFormRepository();
        }
        //GET: Gigticket
        public ActionResult Create()
        {
            return View();
        }
    }
}