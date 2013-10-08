namespace QandA.Core.Domain
{
    public class Answer
    {
        public int Id { get; set; }
        public string Desc { get; set; }
        public UserProfile UserProfile { get; set; }
    }
}
