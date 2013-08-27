using QandA.Core.Domain;
using QandA.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QandA.Service
{
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
}
