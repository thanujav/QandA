using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QandA.Core.Domain;

namespace QandA.Core.Dto
{
    public class PagedQuestions
    {
        public List<Question> Questions { get; set; }
        public int TotalQuestions { get; set; }
    }
}
