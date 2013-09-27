﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using QandA.Core.Interfaces;
using QandA.Core.Domain;
using System.Collections.Generic;
using QandA.Core.Constants;

namespace QandA.Service.Test
{
    [TestClass]
    public class QuestionAndAnswerServiceTests
    {
        [TestMethod]
        public void GetQuestionWithIdReturnNonNullQandAs()
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
            Assert.IsTrue(question.Answers.Count > 0);
            Assert.AreEqual(1, question.Answers[0].Id);
            Assert.AreEqual("It is a framework.", question.Answers[0].Desc);
        }

        [TestMethod]
        public void GetQuestionWithIdReturnNonNull2()
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
            questionsRepository.Setup(qr => qr.SingleOrDefault(It.IsAny<Func<Question, bool>>()))
                               .Returns(new Question { Id = id, Desc = desc, Answers = new List<Answer> { new Answer { Id = 1, Desc = "It is a framework." } } });
            questionsRepository.Setup(qr => qr.Add(It.IsAny<Question>()))
                               .Returns(new Question { Id = id, Desc = desc, Answers = new List<Answer> { new Answer { Id = 2, Desc = "It is a framework." } } });
            questionsRepository.Setup(qas => qas.GetAll())
                               .Returns(new List<Question> { new Question { Id = id, Desc = desc } });
            return questionsRepository;
        }

        [TestMethod]
        public void AddQuestionReturnQuestionWithId()
        {
            //Arrange
            var questionsRepository = setupQuestionRepository(1, "What is ASP.NET?");
            var unitOfWork = setupUnitOfWork(questionsRepository);
            var questionAndAnswerService = new QuestionAndAnswerService(unitOfWork.Object);
            
            //Act
            Question question = questionAndAnswerService.AddQuestion(new Question { Desc = "What is .NET" });
            
            //Assert
            Assert.IsTrue(question.Id > 0);
        }

        [TestMethod]
        public void GetAllReturnsAllQuestions()
        {
            //Arrange
            var questionsRepository = setupQuestionRepository(1, "What is ASP.NET?");
            var unitOfWork = setupUnitOfWork(questionsRepository);
            var questionAndAnswerService = new QuestionAndAnswerService(unitOfWork.Object);
            
            //Act
            List<Question> questions = questionAndAnswerService.GetAll();
            
            //Assert
            Assert.IsTrue(questions.Count > 0);
        }

        [TestMethod]
        public void AddAnswerWithQuestionIdReturnsAddedAnswer()
        {
            //Arrange
            var questionsRepository = setupQuestionRepository(1, "What is ASP.NET?");
            var unitOfWork = setupUnitOfWork(questionsRepository);
            IQuestionAndAnswerService questionAndAnswerService = new QuestionAndAnswerService(unitOfWork.Object);
            
            //Act
            Answer addedAnswer = questionAndAnswerService.AddAnswer(1, new Answer { Desc = "It is a framework." });
            
            //Assert
            Assert.IsNotNull(addedAnswer.Id);
        }

        [TestMethod]
        public void GetPaged_ReturnsPageFullOfQuestions()
        {
            //Arrange
            var questionsRepository = setupGetPagedQuestionRepository();
            var unitOfWork = setupUnitOfWork(questionsRepository);
            var questionAndAnswerService = new QuestionAndAnswerService(unitOfWork.Object);

            //Act
            List<Question> questions = questionAndAnswerService.GetPaged(General.PageSize, 1);

            //Assert
            Assert.AreEqual(10, questions.Count);
        }

        private static Mock<IGenericRepository<Question>> setupGetPagedQuestionRepository()
        {
            var questionsRepository = new Mock<IGenericRepository<Question>>();
            questionsRepository.Setup(qas => qas.GetPaged(It.IsAny<int>(), It.IsAny<int>()))
                               .Returns(new List<Question> 
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
                               });

            return questionsRepository;
        }
    }   
}
