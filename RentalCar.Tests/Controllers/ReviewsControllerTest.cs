using System;
using System.Collections.Generic;
//using System.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RentalCar.Contracts;
using RentalCar.Controllers;
using RentalCar.Models.AppModels;

namespace RentalCar.Tests
{
    [TestClass]
    public class ReviewsControllerTest
    {
        Mock<IRepository<CarReview>> repositoryMoq;
        ReviewsController sut;

        public ReviewsControllerTest()
        {
            repositoryMoq = new Mock<IRepository<CarReview>>();
            sut = new ReviewsController(repositoryMoq.Object);
        }

        CarReview reviewStub = new CarReview()
        {
            Id = 0,
            CarId = 0,
            Rating = 0,
            ReviewerName = "Some Name",
            Review = "Some Review"
        };

        [TestMethod]
        public void AllReviews()
        {
            List<CarReview> listStub = new List<CarReview>() { reviewStub };
            repositoryMoq.Setup(r => r.Read()).Returns(listStub);

            var result = sut.AllReviews();

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void CreatePost()
        {
            // Act
            repositoryMoq.Setup(r => r.Create(It.IsAny<CarReview>())).Returns(1);
            var result = sut.Create(reviewStub);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
        }

        [TestMethod]
        public void EditGet()
        {
            repositoryMoq.Setup(r => r.Read(It.IsAny<int>())).Returns(reviewStub);

            var result = sut.Delete(reviewStub.Id);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void EditPost()
        {
            repositoryMoq.Setup(r => r.Update(It.IsAny<CarReview>())).Returns(-1);

            var result = sut.Edit(reviewStub);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void Delete()
        {
            repositoryMoq.Setup(r => r.Read(It.IsAny<int>())).Returns(reviewStub);

            var result = sut.Delete(1);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void DeletePost()
        {
            repositoryMoq.Setup(r => r.DeleteConfirmed(It.IsAny<CarReview>())).Returns(1);

            var result = sut.DeleteConfirmed(reviewStub);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
        }
    }
}
