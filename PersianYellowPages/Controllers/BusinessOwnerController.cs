// Mohammad Jokar Konavi, Behrooz Kazemi, Tonya Martinez ,and Andrea Griffis
// 06/17/2022
// Module 3 Project Deliverable Assignment


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

        

        // GET: BusinessOwnerController/Add
        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.Action = "Add";
            return View(new Business());
        }

        [HttpPost]
        public ActionResult Add(Business business)
        {
            
            BusinessDB.AddBusiness(business);
            return RedirectToAction("Index", "BusinessOwner");
        }




        //GET: BusinessOwnerController/Edit
        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            BusinessDetailsViewModel business = BusinessDB.GetBusiness(id);
            return View(business);
        }

        // POST: BusinessOwnerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BusinessDetailsViewModel business)
        {
            BusinessDB.UpdateBusiness(business);
            return RedirectToAction("Index", "BusinessOwner");

        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            ViewBag.Action = "Delete";
            Business business = BusinessDB.FindBusiness(id);
            return View(business);
        }

        // POST: BusinessOwnerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Business business)
        {
            int id = business.BusinessId;
            BusinessDB.DeleteBusiness(id);
            return RedirectToAction("Index", "BusinessOwner");
        }
    }
}
