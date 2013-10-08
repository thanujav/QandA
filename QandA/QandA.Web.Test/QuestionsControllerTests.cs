using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QandA.Web.Controllers;
using QandA.Core.Interfaces;
using Moq;
using QandA.Core.Domain;
using System.Web.Mvc;
using System.Collections.Generic;
using QandA.Core.Dto;
using QandA.Web.Models;

namespace QandA.Web.Test
{
    [TestClass]
    public class QuestionsControllerTests
    {
        [TestMethod]
        public void DetailsWithIdReturnsQuestionAndAnswers()
        {
            //Arrange
            var questionsAndAnswerService = new Mock<IQuestionAndAnswerService>();
            questionsAndAnswerService.Setup(qaas => qaas.GetQuestion(It.IsAny<int>()))
                                     .Returns(new Question { Id = 1, Desc = "What is Asp.net?", Answers = new List<Answer> { new Answer { Id = 1, Desc = "It is a framework." } } });
            var questionsController = new QuestionsController(questionsAndAnswerService.Object);

            //Act
            var result = questionsController.Details(1) as ViewResult;

            //Assert
            var model = result.Model as Question;
            Assert.AreEqual(1, model.Id);
            Assert.AreEqual("What is Asp.net?", model.Desc);
            Assert.IsTrue(model.Answers.Count > 0);
            Assert.AreEqual(1, model.Answers[0].Id);
            Assert.AreEqual("It is a framework.", model.Answers[0].Desc);
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
        public void IndexReturnsAPageFullOfResults()
        {
            //Arrange
            var questionAndAnswerService = new Mock<IQuestionAndAnswerService>();
            questionAndAnswerService.Setup(qas => qas.GetPaged(It.IsAny<int>(), It.IsAny<int>()))
                                    .Returns(new PagedQuestions
                                    {
                                        Questions = new List<Question> 
                                        {
                                            new Question { Id = 1, Desc = "AA" },
                                            new Question { Id = 2, Desc = "AA" },
                                            new Question { Id = 3, Desc = "AA" },
                                            new Question { Id = 4, Desc = "AA" },
                                            new Question { Id = 5, Desc = "AA" },
                                            new Question { Id = 6, Desc = "AA" },
                                            new Question { Id = 7, Desc = "AA" },
                                            new Question { Id = 8, Desc = "AA" },
                                            new Question { Id = 9, Desc = "AA" },
                                            new Question { Id = 10, Desc = "AA" }
                                        },
                                        TotalQuestions = 12
                                    }
                                    );
            var questionController = new QuestionsController(questionAndAnswerService.Object);
            
            //Act
            var result = questionController.Index(1) as ViewResult;
            
            //Assert
            Assert.IsNotNull(result.Model as QuestionsIndexViewModel);
            Assert.AreEqual(1, (result.Model as QuestionsIndexViewModel).PagingInfo.CurrentPage);
            Assert.AreEqual(2, (result.Model as QuestionsIndexViewModel).PagingInfo.TotalPages);
        }
    }

}
