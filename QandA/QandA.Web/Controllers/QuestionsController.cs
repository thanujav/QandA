﻿using QandA.Core.Constants;
using QandA.Core.Domain;
using QandA.Core.Dto;
using QandA.Core.Interfaces;
using QandA.Web.Models;
using System.Web.Mvc;

namespace QandA.Web.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly IQuestionAndAnswerService _questionAndAnswerService;
        public QuestionsController(IQuestionAndAnswerService questionAndAnswerService)
        {
            _questionAndAnswerService = questionAndAnswerService;
        }

        public ActionResult Details(int id)
        {
            var question = _questionAndAnswerService.GetQuestion(id);
            return View(question);
        }

        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Question question)
        {
            var addedQuestion = _questionAndAnswerService.AddQuestion(question);

            return RedirectToAction("details", new { id = addedQuestion.Id });
        }

        public ActionResult Index(int page=1)
        {
            var pagedQuestions = _questionAndAnswerService.GetPaged(General.PageSize, page);

            return View(new QuestionsIndexViewModel { Questions = pagedQuestions.Questions, PagingInfo = new PagingInfo { CurrentPage = page, TotalPages = int.Parse((pagedQuestions.TotalQuestions/General.PageSize).ToString()) + 1 } });
        }
    }
}
