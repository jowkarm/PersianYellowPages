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
    [Authorize]
    public class BusinessOwnerController : Controller
    {
        private IHttpContextAccessor Accessor;
        public BusinessOwnerController(IHttpContextAccessor _accessor)
        {
            this.Accessor = _accessor;
        }



        // GET: BusinessOwnerController
        public ActionResult Index()
        {
            HttpContext context = this.Accessor.HttpContext;
            string userEmail = context.User.Identity.Name;
            List<BusinessDetailsViewModel> businessList = BusinessDB.OwnerBusinessList(userEmail);
            return View(businessList);
        }

        // GET: BusinessOwnerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BusinessOwnerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BusinessOwnerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }



        // GET: BusinessOwnerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BusinessOwnerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BusinessOwnerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BusinessOwnerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
