using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QandA.Web.Controllers;
using QandA.Core.Interfaces;
using Moq;
using QandA.Core.Domain;
using System.Web.Mvc;
using System.Collections.Generic;

namespace QandA.Web.Test
{
    [TestClass]
    public class QuestionsControllerTests
    {
        [TestMethod]
        public void DetailsWithIdReturnsQuestion()
        {
            //Arrange
            var questionsAndAnswerService = new Mock<IQuestionAndAnswerService>();
            questionsAndAnswerService.Setup(qaas => qaas.GetQuestion(It.IsAny<int>()))
                                     .Returns(new Question { Id = 1, Desc = "What is Asp.net?" });
            var questionsController = new QuestionsController(questionsAndAnswerService.Object);

            //Act
            var result = questionsController.Details(1) as ViewResult;

            //Assert
            var model = result.Model as Question;
            Assert.AreEqual(1, model.Id);
            Assert.AreEqual("What is Asp.net?", model.Desc);
        }

        [TestMethod]
        public void CreateIfModelValidRedirectsToDetails()
        {
            //Arrange
            var questionAndAnswerService = new Mock<IQuestionAndAnswerService>();
            questionAndAnswerService.Setup(qas => qas.AddQuestion(It.IsAny<Question>()))
                                    .Returns(new Question { Id = 1, Desc = "What is .NET" });
            var questionsController = new QuestionsController(questionAndAnswerService.Object);
            
            //Act
            var result = questionsController.Create(new Question { Desc = "What is .NET" }) as RedirectToRouteResult;
            
            //Assert
            Assert.AreEqual("details", result.RouteValues["action"] as String);
        }

        [TestMethod]
        public void IndexReturnsAllQuestion()
        {
            //Arrange
            var questionAndAnswerService = new Mock<IQuestionAndAnswerService>();
            questionAndAnswerService.Setup(qas => qas.GetAll())
                                    .Returns(new List<Question> { });
            var questionController = new QuestionsController(questionAndAnswerService.Object);
            
            //Act
            var result = questionController.Index() as ViewResult;
            
            //Assert
            Assert.IsNotNull(result.Model as List<Question>);
        }
    }

}
