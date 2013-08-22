using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace QandA.Service.Test
{
    [TestClass]
    public class QuestionAndAnswerServiceTests
    {
        [TestMethod]
        public void GetRandomQuestion()
        {
            //Arrange
            var questionAndAnswerService = new QuestionAndAnswerService();
            
            //Act
            var question = questionAndAnswerService.GetRandomQuestion();
            
            //Assert
            Assert.IsNotNull(question);
        }

    }

    public class QuestionAndAnswerService
    {
        public Question GetRandomQuestion()
        {
            return new Question();
        }
    }

    public class Question
    {
        public int Id { get; set; }
        public string Desc { get; set; }
    }
}
