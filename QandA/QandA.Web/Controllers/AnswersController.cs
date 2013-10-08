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
        readonly IQuestionAndAnswerService _questionAndAnswerService;
        public AnswersController(IQuestionAndAnswerService questionAndAnswerService)
        {
            _questionAndAnswerService = questionAndAnswerService;
        }

        public ActionResult Create(int questionId)
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(int questionId, Answer answer)
        {
            var addedAnswer = _questionAndAnswerService.AddAnswer(questionId, answer);

            return RedirectToAction("details", "questions", new { id = questionId });
        }

    }
}
