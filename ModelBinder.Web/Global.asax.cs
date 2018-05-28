using ModelBinder.Web.App_Start;
using System;
using System.Web.Optimization;

namespace ModelBinder.Web
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}