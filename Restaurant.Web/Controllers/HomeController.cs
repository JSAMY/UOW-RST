using Restaurant.Common;
using Restaurant.Core;
using Restaurant.Core.CommonModel;
using Restaurant.Interface;
using Restaurant.Web.Models;
using System;
using System.Web.Mvc;

namespace Restaurant.Web.Controllers
{
    public class HomeController : BaseController
    {         
        public HomeController(IUnitOfWork _unitOfWork,IEmail _emailService)
          : base(_unitOfWork, _emailService)
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
                if (ModelState.IsValid)
                {
                    var bookingRepo = unitOfWork.Repository<Booking>();
                    var booking = Helper.Bind<Booking, RestaurantViewModel>(model, true, true);
                    //booking.TableNo = "1"; // in future table no may required
                    booking.CreatedAt = DateTime.Now;
                    bookingRepo.Insert(booking);
                    var uwStatus = unitOfWork.Commit();
                    if(uwStatus)
                    {
                        //sending email call
                        emailService.Send(
                            new 
                            EmailDetails
                            {
                                emailToAddress = model.Email,
                                emailFromAddress = "",
                                Subject = "details ......",
                                Body = "detils .....",
                                emailFromName = "..from ... name..",
                                emailToName = "...to...name"
                            });

                        return RedirectToAction("BookingCompleted");
                    }
                    else
                    {
                        return RedirectToAction("Error");
                    }
                }

                return View("Index", model);

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