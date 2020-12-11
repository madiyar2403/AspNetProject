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

namespace ProjectForDotNet.UnitTestProject4
{
    [TestFixture]
    class OrdersControllerUnitTests
    {
        [Test]
        public void Order_Index_View_Contains_ListOfOrder_Model()
        {
            Mock<IOrdersRepository> mock = new Mock<IOrdersRepository>();

            mock.Setup(m => m.Order).Returns(new Models.Order[]
                {
                    new Models.Order{  }

                }.AsQueryable());

            OrdersController controller = new OrdersController(mock.Object);

            var actual = (List<Models.Order>)controller.Index().Model;

            Assert.IsInstanceOf<List<Models.Order>>(actual);
        }

        [Test]
        public void DeleteReturnsOk()
        {
            // Arrange
            var mock = new Mock<IOrdersRepository>();
            var controller = new OrdersController(mock.Object);

            // Act
            IHttpActionResult actionResult = (IHttpActionResult)controller.Delete(5);

            // Assert
            Assert.IsInstanceOf((System.Type)actionResult, typeof(OkResult));
        }

        [Test]
        public void AddOrderReturnsARedirectAndAddsOrder()
        {
            // Arrange
            var mock = new Mock<IOrdersRepository>();
            var controller = new OrdersController(mock.Object);
            var newOrder = new Models.Order()
            {
                FirstName = "Example"
            };

            // Act
            var result = controller.Create(newOrder);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
            mock.Verify(r => r.Save(newOrder));
        }
    }
}
