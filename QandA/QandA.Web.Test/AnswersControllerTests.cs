using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QandA.Web.Controllers;
using QandA.Core.Interfaces;
using Moq;
using QandA.Core.Domain;
using System.Web.Mvc;

namespace QandA.Web.Test
{
    [TestClass]
    public class AnswersControllerTests
    {
        [TestMethod]
        public void AddAnswerAddsAnswerToQuestionGoesToQuestionDetailsView()
        {
            //Arrange
            var questionAndAnswerServiceMock = new Mock<IQuestionAndAnswerService>();
            questionAndAnswerServiceMock.Setup(qas => qas.AddAnswer(It.IsAny<int>(), It.IsAny<Answer>()))
                                        .Returns(new Answer { Id = 1, Desc = "It is a framework." });
            AnswersController answersController = new AnswersController(questionAndAnswerServiceMock.Object);
            
            //Act
            var answer = new Answer { Desc = "It is a framework." }; 
            var redirectToRouteResult = answersController.Create(1, answer) as RedirectToRouteResult;
            
            //Assert
            Assert.AreEqual("questions", redirectToRouteResult.RouteValues["controller"] as String);
            Assert.AreEqual("details", redirectToRouteResult.RouteValues["action"] as String);
            Assert.AreEqual(1, redirectToRouteResult.RouteValues["id"]);
        }
    }
}
