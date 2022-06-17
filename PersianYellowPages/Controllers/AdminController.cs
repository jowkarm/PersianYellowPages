using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersianYellowPages.DataLayer;
using PersianYellowPages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersianYellowPages.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        // GET: AdminController
        public ActionResult Index()
        {
            List<BusinessDetailsViewModel> businessList = BusinessDB.AdminBusinessList();
            return View(businessList);
        }


        // GET: AdminController/Edit/5
        public ActionResult Verify(int id)
        {
            ViewBag.Action = "Verify";
            BusinessDetailsViewModel business = BusinessDB.GetBusiness(id);
            return View(business);
        }

        // POST: AdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Verify(BusinessDetailsViewModel business)
        {
            BusinessDB.VerifyBusiness(business);
            return RedirectToAction("Index", "Admin");
        }

    
    }
}
