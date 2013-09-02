using QandA.Core.Domain;
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

        public ActionResult Details(int id)
        {
            var question = _questionAndAnswerService.GetQuestion(id);
            return View(question);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Question question)
        {
            Question addedQuestion = _questionAndAnswerService.AddQuestion(question);

            return RedirectToAction("details", new { id = addedQuestion.Id });
        }

        public ActionResult Index()
        {
            List<Question> questions = _questionAndAnswerService.GetAll();
            return View(questions);
        }
    }
}
