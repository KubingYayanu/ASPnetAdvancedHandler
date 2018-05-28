namespace App.Utilities.Web.Handlers
{
    public class HttpPutAttribute : HttpVerbAttribute
    {
        public override string HttpVerb
        {
            get { return "PUT"; }
        }
    }
}