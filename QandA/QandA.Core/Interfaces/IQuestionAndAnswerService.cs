using QandA.Core.Domain;
using QandA.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QandA.Core.Interfaces
{
    public interface IQuestionAndAnswerService
    {
        Question GetQuestion(int questionId);

        Question AddQuestion(Question question);

        List<Question> GetAll();

        Answer AddAnswer(int questionId, Answer answer);

        PagedQuestions GetPaged(int pageSize, int pageNum);
    }
}
