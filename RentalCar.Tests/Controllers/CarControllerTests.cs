using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RentalCar.Contracts;
using RentalCar.Controllers;
using RentalCar.Models.AppModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Web.Mvc;

namespace RentalCar.Tests
{
    [TestClass]
    public class CarControllerTests
    {
        Mock<IRepository<Car>> repositoryMoq;
        CarsController sut;

        public CarControllerTests()
        {
            repositoryMoq = new Mock<IRepository<Car>>();
            sut = new CarsController(repositoryMoq.Object);
        }

        Car carStub = new Car()
        {
            Id = 0,
            Make = "Some make",
            Model = "Some model",
            Availability = true,
            Reviews = new List<CarReview>(),
        };

        [TestMethod]
        public void AllCars()
        {
            List<Car> listStub = new List<Car>() { carStub };
            repositoryMoq.Setup(r => r.Read()).Returns(listStub);

            var result = sut.AllCars();

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void Details()
        {
            repositoryMoq.Setup(r => r.Read(It.IsAny<int>())).Returns(carStub);

            var result = sut.Details(1);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void Create()
        {
            var result = sut.Create() as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CreatePost()
        {
            // Act
            repositoryMoq.Setup(r => r.Create(carStub)).Returns(1);
            var result = sut.Create(carStub);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
        }

        [TestMethod]
        public void Edit()
        {
            carStub = null;
            repositoryMoq.Setup(r => r.Read(It.IsAny<int>())).Returns(carStub);

            // Act
            var result = sut.Edit(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void EidtPost()
        {
            // Act
            repositoryMoq.Setup(r => r.Update(It.IsAny<Car>())).Returns(-1);
            var result = sut.Edit(carStub);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
    }
}
