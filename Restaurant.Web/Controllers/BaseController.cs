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
        protected IUnitOfWork unitOfWork;
        protected IEmail emailService;

        public BaseController()
        {

        }

        public BaseController(IUnitOfWork _unitOfWork,IEmail _emailService)
        {
            this.unitOfWork = _unitOfWork;
            this.emailService = _emailService;        
        }
        

    }
}