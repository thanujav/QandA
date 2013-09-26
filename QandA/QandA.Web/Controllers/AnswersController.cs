using QandA.Core.Domain;
using QandA.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QandA.Web.Controllers
{
    public class AnswersController : Controller
    {
        IQuestionAndAnswerService _questionAndAnswerService;
        public AnswersController(IQuestionAndAnswerService questionAndAnswerService)
        {
            _questionAndAnswerService = questionAndAnswerService;
        }

        public ActionResult Create(int questionId)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(int questionId, Answer answer)
        {
            Answer addedAnswer = _questionAndAnswerService.AddAnswer(questionId, answer);

            return RedirectToAction("details", "questions", new { id = questionId });
        }

    }
}
