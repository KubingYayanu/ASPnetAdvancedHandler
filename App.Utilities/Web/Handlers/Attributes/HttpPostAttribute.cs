namespace App.Utilities.Web.Handlers
{
    public class HttpPostAttribute : HttpVerbAttribute
    {
        public override string HttpVerb
        {
            get { return "POST"; }
        }
    }
}