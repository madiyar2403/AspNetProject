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

namespace ProjectForDotNet.UnitTestProject2
{
    [TestFixture]
    class CategoriesControllerUnitTests
    {
        [Test]
        public void Category_Index_View_Contains_ListOfCategory_Model()
        {
            Mock<ICategoriesRepository> mock = new Mock<ICategoriesRepository>();

            mock.Setup(m => m.Category).Returns(new Models.Category[]
                {
                    new Models.Category{ CategoryId = 1, Name = "Helicopter", TypeId = 1, Description = "A helicopter is a vertical take-off and landing rotorcraft, in which the lifting and driving forces at all stages of flight are created by one or more main rotors driven by one or several engines." }
                    
                }.AsQueryable());

            CategoriesController controller = new CategoriesController(mock.Object);

            var actual = (List<Models.Category>)controller.Index().Model;

            Assert.IsInstanceOf<List<Models.Category>>(actual);
        }

        [Test]
        public void DeleteReturnsOk()
        {
            // Arrange
            var mock = new Mock<ICategoriesRepository>();
            var controller = new CategoriesController(mock.Object);

            // Act
            IHttpActionResult actionResult = (IHttpActionResult)controller.Delete(5);

            // Assert
            Assert.IsInstanceOf((System.Type)actionResult, typeof(OkResult));
        }

        [Test]
        public void AddCategoryReturnsARedirectAndAddsCategory()
        {
            // Arrange
            var mock = new Mock<ICategoriesRepository>();
            var controller = new CategoriesController(mock.Object);
            var newCategory = new Models.Category()
            {
                Name = "Example"
            };

            // Act
            var result = controller.Create(newCategory);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
            mock.Verify(r => r.Save(newCategory));
        }
    }
}
