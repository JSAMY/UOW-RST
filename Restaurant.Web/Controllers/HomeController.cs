using Restaurant.Core;
using Restaurant.DAL;
using Restaurant.Interface.Repository;
using Restaurant.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurant.Web.Controllers
{
    public class HomeController : Controller
    {

        private IUnitOfWork unitOfWork = new UnitOfWork();
        private IRepository<Booking> bookingRepository;

        public HomeController()
        {
            bookingRepository = unitOfWork.Repository<Booking>();
        }

        public ActionResult Index()
        {
            //bookingRepository.Save();

            return View(new RestaurantViewModel());
        }

        [HttpPost]
        public ActionResult Index(RestaurantViewModel model)
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

            bookingRepository.Save(booking);

            return View(new RestaurantViewModel());
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