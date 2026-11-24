using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using mock.depart.Controllers;
using mock.depart.Models;
using mock.depart.Services;
using Moq;

namespace mockTests.Controllers
{
    [TestClass()]
    public class CatsControllerTests
    {

        [TestMethod]
        public void Delete_CatNotFound()
        {
            Mock<CatsService> catsServiceMock = new Mock<CatsService>();
            Mock<CatsController> controller = new Mock<CatsController>(catsServiceMock.Object) { CallBase = true };

            catsServiceMock.Setup(s => s.Get(It.IsAny<int>())).Returns(value: null);

            controller.Setup(c => c.UserId).Returns("1");

            var actionResult = controller.Object.DeleteCat(0);
            var result = actionResult.Result as NotFoundResult;
            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void Delete_WrongOwner()
        {

            Mock<CatsService> catsServiceMock = new Mock<CatsService>();
            Mock<CatsController> controller = new Mock<CatsController>(catsServiceMock.Object) { CallBase = true };

            CatOwner co = new CatOwner()
            {
                Id = "11111"
            };


        }





    }
}
