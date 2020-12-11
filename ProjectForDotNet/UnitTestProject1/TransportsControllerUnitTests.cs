using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using ProjectForDotNet.Controllers;
using ProjectForDotNet.Models;

namespace ProjectForDotNet.UnitTestProject3
{
    [TestFixture]
    class TransportsControllerUnitTests
    {
        [Test]
        public void Transport_Index_View_Contains_ListOfTransport_Model()
        {
            Mock<ITransportsRepository> mock = new Mock<ITransportsRepository>();

            mock.Setup(m => m.Transport).Returns(new Models.Transport[]
                {
                    new Models.Transport{ Name = "N700 Series", Price = 450000000, Producer = "Shinkansen", Weight = 71500, Capacity = 515, MaxSpeed = 300, ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/3/30/N700_Z0_7881A_Hamamatsu_20060128.jpg/450px-N700_Z0_7881A_Hamamatsu_20060128.jpg", CategoryId = 4, Description = "The Shinkansen N700 series electric train is a high-speed Japanese electric train developed jointly by JR Central and JR West for use on the Tokaido and Sanyo lines. Tests of the prototype train began on March 10, 2005. Commissioned on July 1, 2007." }

                }.AsQueryable());

            TransportsController controller = new TransportsController(mock.Object);

            var actual = (List<Models.Transport>)controller.Index().Model;

            Assert.IsInstanceOf<List<Models.Transport>>(actual);
        }

        [Test]
        public void DeleteReturnsOk()
        {
            // Arrange
            var mock = new Mock<ITransportsRepository>();
            var controller = new TransportsController(mock.Object);

            // Act
            IHttpActionResult actionResult = (IHttpActionResult)controller.Delete(5);

            // Assert
            Assert.IsInstanceOf((System.Type)actionResult, typeof(OkResult));
        }

        [Test]
        public void AddTransportReturnsARedirectAndAddsTransport()
        {
            // Arrange
            var mock = new Mock<ITransportsRepository>();
            var controller = new TransportsController(mock.Object);
            var newTransport = new Models.Transport()
            {
                Name = "Example"
            };

            // Act
            var result = controller.Create(newTransport);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
            mock.Verify(r => r.Save(newTransport));
        }
    }
}
