﻿// Mohammad Jokar Konavi, Behrooz Kazemi, Tonya Martinez ,and Andrea Griffis
// 06/17/2022
// Module 3 Project Deliverable Assignment


using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PersianYellowPages.DataLayer;
using PersianYellowPages.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


namespace PersianYellowPages.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            
            ViewBag.States = BusinessDB.StateList();
            List <BusinessDetailsViewModel> businessList = BusinessDB.BusinessList();
            return View(businessList);
        }


        // GET: Products/ShowSearchForm
        [HttpGet]
        public IActionResult Search()
        {
            // create the view model
            List<BusinessDetailsViewModel> model = new List<BusinessDetailsViewModel>();

            // pass the view model to the view
            return View(model);
        }

        // POST: Products/ShowSearchResults
        [HttpPost]
        public IActionResult Search(string SearchPhrase)
        {
            // create the view model
            String withDoubleQuotes = "%" + SearchPhrase + "%";
            String stringWithSingleQuotes = withDoubleQuotes.Replace('"', '\'');

            List<BusinessDetailsViewModel> model = BusinessDB.SearchBusiness(stringWithSingleQuotes);

            

            // pass the view model to the view
            return View("Search", model);
        }


        public ActionResult Details(int id)
        {
            ViewBag.Reviews = BusinessDB.ReviewList(id);
            BusinessDetailsViewModel businessDetails = BusinessDB.GetBusiness(id);
            return View(businessDetails);
        }

        // GET: Home/Add
        [HttpGet]
        public ActionResult Review(int businessId)
        {
            ViewBag.Action = "Review";
            Review review = new Review();
            review.BusinessId = businessId;
            return View(review);
        }

        [HttpPost]
        public ActionResult Review(Review review)
        {

            BusinessDB.AddReview(review);
            return RedirectToAction("Details", "Home", new { id = review.BusinessId });
        }



        public IActionResult ChangeLanguage(string culture)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions() { Expires = DateTimeOffset.UtcNow.AddYears(1) });

            return Redirect(Request.Headers["Referer"].ToString());
        }

      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
