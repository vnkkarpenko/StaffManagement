using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StaffManagement;
using StaffManagement.Controllers;
using StaffManagement.Interfaces;

namespace StaffManagement.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
           //Arrange
           var mockLogger = new Moq.Mock<IStaffRepository>();
           var controller = new HomeController(mockLogger.Object);

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
