namespace App.Utilities.Web.Handlers
{
    public class HttpGetAttribute : HttpVerbAttribute
    {
        public override string HttpVerb
        {
            get { return "GET"; }
        }
    }
}