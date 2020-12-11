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

namespace ProjectForDotNet.UnitTestProject1
{
    [TestFixture]
    public class TypesControllerUnitTests
    {
        /*[Test]
        //[Ignore]
        public void Index_Returns_ActionResult() 
        {
            TypesController controller = new TypesController();

            var actual = controller.Index();

            Assert.IsInstanceOf<ActionResult>(actual);
        }*/

        [Test]
        public void Type_Index_View_Contains_ListOfType_Model() 
        {
            Mock<ITypesRepository> mock = new Mock<ITypesRepository>();

            mock.Setup(m => m.Type).Returns(new Models.Type[]
                { 
                    new Models.Type{ TypeId = 1, Name = "Air", Description = "Air transport is an important enabler to achieving economic growth and development. Air transport facilitates integration into the global economy and provides vital connectivity on a national, regional, and international scale. It helps generate trade, promote tourism, and create employment opportunities. The World Bank has financed aviation-related projects for over sixty years. Today, the WBG remains actively engaged in every region on projects related to air transport policy and regulation, safety, infrastructure rehabilitation, institutional strengthening, and capacity building." },
                    new Models.Type{ TypeId = 2, Name = "Land", Description = "Land transport – transport or movement of people, animals, and goods from one location to another on land, usually by railway or road." },
                    new Models.Type{ TypeId = 3, Name = "Water", Description = "Water transport is the process of moving people, goods, etc. by barge, boat, ship or sailboat over a sea, ocean, lake, canal, river, etc. This category does not include articles on the transport of water for the purpose of consuming the water." }
                }.AsQueryable());

            TypesController controller = new TypesController(mock.Object);

            var actual = (List<Models.Type>)controller.Index().Model;

            Assert.IsInstanceOf<List<Models.Type>>(actual);
        }

        [Test]
        public void DeleteReturnsOk()
        {
            // Arrange
            var mock = new Mock<ITypesRepository>();
            var controller = new TypesController(mock.Object);
            
            // Act
            IHttpActionResult actionResult = (IHttpActionResult)controller.Delete(5);
            
            // Assert
            Assert.IsInstanceOf((System.Type)actionResult, typeof(OkResult));
        }

        [Test]
        public void AddTypeReturnsARedirectAndAddsType()
        {
            // Arrange
            var mock = new Mock<ITypesRepository>();
            var controller = new TypesController(mock.Object);
            var newType = new Models.Type()
            {
                Name = "Example"
            };

            // Act
            var result = controller.Create(newType);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
            mock.Verify(r => r.Save(newType));
        }


    }

}
