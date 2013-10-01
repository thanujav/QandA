using QandA.Core.Domain;
using QandA.Core.Dto;
using QandA.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QandA.Service
{
    public class QuestionAndAnswerService : IQuestionAndAnswerService
    {
        private IUnitOfWork _unitOfWork;

        public QuestionAndAnswerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Question GetQuestion(int questionId)
        {
            return _unitOfWork.QuestionsRepository.SingleOrDefault(q => q.Id == questionId);
        }

        public Question AddQuestion(Question question)
        {
            Question addedQuestion = _unitOfWork.QuestionsRepository.Add(question);
            _unitOfWork.Save();
            return addedQuestion;
        }

        public List<Question> GetAll()
        {
            return _unitOfWork.QuestionsRepository.GetAll();
        }

        public Answer AddAnswer(int questionId, Answer answer)
        {
            Question question = _unitOfWork.QuestionsRepository.SingleOrDefault(q => q.Id == questionId);
            question.Answers.Add(answer);
            _unitOfWork.Save();

            return answer;
        }

        public PagedQuestions GetPaged(int pageSize, int pageNum)
        {

            List<Question> questions = _unitOfWork.QuestionsRepository.GetPaged(pageSize, pageNum);
            int totalQuestions = _unitOfWork.QuestionsRepository.Count();

            return new PagedQuestions { Questions = questions, TotalQuestions = totalQuestions };
        }
    }
}
