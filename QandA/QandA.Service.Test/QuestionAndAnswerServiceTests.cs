using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

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

    }

    public class QuestionAndAnswerService
    {
        private IUnitOfWork unitOfWork;

        public QuestionAndAnswerService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public Question GetQuestion(int questionNumber)
        {
            return unitOfWork.QuestionsRepository.SingleOrDefault(questionNumber);
        }
    }

    public class Question
    {
        public int Id { get; set; }
        public string Desc { get; set; }
    }

    public interface IUnitOfWork
    {
        IGenericRepository<Question> QuestionsRepository { get; set; }
    }

    public interface IGenericRepository<T>
    {
        T SingleOrDefault(int p);
    }
}
