using Restaurant.Core;
using Restaurant.DAL;
using Restaurant.Interface;
using Restaurant.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurant.Web.Controllers
{
    public class BaseController : Controller
    {
        protected IUnitOfWork unitOfWork;// = new UnitOfWork();

        protected IRepository<Booking> bookingRepository;

        public BaseController()
        {

        }

        public BaseController(IUnitOfWork _unitOfWork, IRepository<Booking> _bookingRepository)
        {
            this.unitOfWork = _unitOfWork;
            this.bookingRepository = _bookingRepository;
        }

    }
}