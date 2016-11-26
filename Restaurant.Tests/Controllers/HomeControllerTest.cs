using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restaurant.Web;
using Restaurant.Web.Controllers;
using Moq;
using Restaurant.Interface;
using Restaurant.Web.Models;
using Restaurant.Core;
using Restaurant.Interface.Repository;

namespace Restaurant.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        private Mock<IUnitOfWork> mOW;
        private Mock<IEmail> mEmail;
        private Mock<IRepository<Booking>> mRepo;
        private HomeController controller;
        private RestaurantViewModel model;
        

        [TestInitialize]
        public void SetUp()
        {
            mOW = new Mock<IUnitOfWork>();
            mRepo = new Mock<IRepository<Booking>>();
            mEmail = new Mock<IEmail>();
            mOW.Setup(d => d.Repository<Booking>()).Returns(mRepo.Object);
            controller = new HomeController(mOW.Object, mEmail.Object);
            model = new RestaurantViewModel { Email = "JohnTestEmail@test.com", Name = "Test", PhoneNum = "9999", PreferredDateTime = DateTime.Now };
        }

        [TestMethod]
        public void IndexActionShouldRedirectToConfirmationPageAfterSuccessfulCommit()
        {
            // Arrange            
            mOW.Setup(d => d.Commit()).Returns(true);

            // Act
            var result = controller.Index(model) as ActionResult;

            // Assert
            Assert.IsNotNull(((RedirectToRouteResult)result).RouteValues.FirstOrDefault().Value, "BookingCompleted");
        }

        [TestMethod]
        public void IndexActionShouldRedirectToErrorPageIfAnyDatabaseErrorOccurred()
        {
            // Arrange            
            mOW.Setup(d => d.Commit()).Returns(false);
            
            //controller.ModelState.AddModelError("key1", "Error");

            // Act
            var result = controller.Index(model) as ActionResult;

            // Assert
            Assert.IsNotNull(((RedirectToRouteResult)result).RouteValues.FirstOrDefault().Value, "Error");
        }

        [TestMethod]
        public void IndexActionShouldRedirectToIndexPageIfModelIsNotValid()
        {
            // Arrange            
            mOW.Setup(d => d.Commit()).Returns(false);
            controller.ModelState.AddModelError("key1", "Error");

            // Act
            var result = controller.Index(model) as ActionResult;

            // Assert
            Assert.IsNotNull(((ViewResultBase)result).Model);
            Assert.AreEqual(((ViewResultBase)result).ViewName,"Index");
        }

    }
}
