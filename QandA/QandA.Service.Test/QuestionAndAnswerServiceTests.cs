﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using QandA.Core.Interfaces;
using QandA.Core.Domain;

namespace QandA.Service.Test
{
    [TestClass]
    public class QuestionAndAnswerServiceTests
    {
        [TestMethod]
        public void GetFirstQuestion()
        {
            //Arrange
            var questionsRepository = setupQuestionRepository(1, "What is ASP.NET?");
            var unitOfWork = setupUnitOfWork(questionsRepository);
            var questionAndAnswerService = new QuestionAndAnswerService(unitOfWork.Object);
            
            //Act
            var question = questionAndAnswerService.GetQuestion(1);
            
            //Assert
            Assert.IsNotNull(question);
            Assert.AreEqual(1, question.Id);
            Assert.AreEqual("What is ASP.NET?", question.Desc);
        }

        [TestMethod]
        public void GetSecondQuestion()
        {
            //Arrange
            var questionsRepository = setupQuestionRepository(2, "What is MVC?");
            var unitOfWork = setupUnitOfWork(questionsRepository);
            var questionAndAnswerService = new QuestionAndAnswerService(unitOfWork.Object);

            //Act
            var question = questionAndAnswerService.GetQuestion(2);

            //Assert
            Assert.IsNotNull(question);
            Assert.AreEqual(2, question.Id);
            Assert.AreEqual("What is MVC?", question.Desc);
        }

        private static Mock<IUnitOfWork> setupUnitOfWork(Mock<IGenericRepository<Question>> questionsRepository)
        {
            var unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork.SetupGet(uow => uow.QuestionsRepository)
                      .Returns(questionsRepository.Object);
            return unitOfWork;
        }

        private static Mock<IGenericRepository<Question>> setupQuestionRepository(int id, string desc)
        {
            var questionsRepository = new Mock<IGenericRepository<Question>>();
            questionsRepository.Setup(qr => qr.SingleOrDefault(It.IsAny<int>()))
                               .Returns(new Question { Id = id, Desc = desc });
            return questionsRepository;
        }
    }   
}
