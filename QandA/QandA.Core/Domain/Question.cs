using System.Collections.Generic;

namespace QandA.Core.Domain
{
    public class Question
    {
        public int Id { get; set; }
        public string Desc { get; set; }
        public virtual List<Answer> Answers { get; set; }
        public UserProfile UserProfile { get; set; }
    }
}
