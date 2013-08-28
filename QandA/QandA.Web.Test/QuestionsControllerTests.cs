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
    public class QuestionsControllerTests
    {
        [TestMethod]
        public void GetFirstQuestion()
        {
            //Arrange
            var questionsAndAnswerService = new Mock<IQuestionAndAnswerService>();
            questionsAndAnswerService.Setup(qaas => qaas.GetQuestion(It.IsAny<int>()))
                                     .Returns(new Question { Id = 1, Desc = "What is Asp.net?" });
            var questionsController = new QuestionsController(questionsAndAnswerService.Object);

            //Act
            var result = questionsController.Index(1) as ViewResult;

            
            var model = result.Model as Question;
            Assert.AreEqual(1, model.Id);
            Assert.AreEqual("What is Asp.net?", model.Desc);
        }
    }

}
