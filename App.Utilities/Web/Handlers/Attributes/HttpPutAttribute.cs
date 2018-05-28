namespace App.Utilities.Web.Handlers
{
    public class HttpDeleteAttribute : HttpVerbAttribute
    {
        public override string HttpVerb
        {
            get { return "DELETE"; }
        }
    }
}