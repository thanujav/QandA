using QandA.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QandA.Web.Controllers
{
    public class QuestionsController : Controller
    {
        private IQuestionAndAnswerService _questionAndAnswerService;
        public QuestionsController(IQuestionAndAnswerService questionAndAnswerService)
        {
            _questionAndAnswerService = questionAndAnswerService;
        }

        public ActionResult Index(int id)
        {
            var question = _questionAndAnswerService.GetQuestion(id);
            return View(question);
        }

    }
}
