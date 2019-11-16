using System;
using App.Utilities.Web.Handlers;
using ModelBinder.Web.Models;

namespace ModelBinder.Web.Pages
{
    public partial class Test : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public TestModel TestFunction(TestModel m)
        {
            Context.Response.ContentType = "application/json";
            return m;
        }
    }
}