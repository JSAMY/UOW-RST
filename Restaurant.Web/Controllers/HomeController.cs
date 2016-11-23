using Restaurant.Common;
using Restaurant.Core;
using Restaurant.DAL;
using Restaurant.Interface;
using Restaurant.Interface.Repository;
using Restaurant.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurant.Web.Controllers
{
    public class HomeController : BaseController
    {
         

        public HomeController(IUnitOfWork _unitOfWork, IRepository<Booking> _bookingRepository) 
            :base(_unitOfWork, _bookingRepository)  
        {
            
        }

        public ActionResult Index()
        {
            return View(new RestaurantViewModel());
        }

        [HttpPost]
        public ActionResult Index(RestaurantViewModel model)
        {
            try
            {
                Booking booking = new Booking
                {
                    CreatedAt = DateTime.Now,
                    Email = model.Email,
                    Name = model.Name,
                    PhoneNum = model.Number,
                    PreferredDateTime = model.PreferredDateTime,
                    TableNo = "1"
                };

                bookingRepository.Insert(booking);
                unitOfWork.Commit();
                return RedirectToAction("BookingCompleted");
            }
            catch(Exception ex)
            {
                return RedirectToAction("Error");
            }
        }


        public ActionResult BookingCompleted()
        {
             
            return View();
        }

        public ActionResult Error()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}