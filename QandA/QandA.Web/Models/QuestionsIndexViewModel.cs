using QandA.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QandA.Web.Models
{
    public class QuestionsIndexViewModel
    {
        public IEnumerable<Question> Questions { get; set;}
        public PagingInfo PagingInfo { get; set; }
    }
}