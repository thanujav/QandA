namespace QandA.Web.Security
{
    public class WebSecurity : IWebSecurity
    {
        public int CurrentUserId 
        {
            get
            {
                return WebMatrix.WebData.WebSecurity.CurrentUserId;
            }
        }
    }
}