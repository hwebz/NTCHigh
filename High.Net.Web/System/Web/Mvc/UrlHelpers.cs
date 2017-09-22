namespace System.Web.Mvc
{
    internal class UrlHelpers
    {
        private HttpContext current;

        public UrlHelpers(HttpContext current)
        {
            this.current = current;
        }
    }
}