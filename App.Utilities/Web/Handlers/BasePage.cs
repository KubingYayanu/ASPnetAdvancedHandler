using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;

namespace App.Utilities.Web.Handlers
{
    public abstract partial class BasePage : Page
    {
        /// <summary>
		/// Intercept the execution right before the handler method is called
		/// </summary>
		/// <param name="e"></param>
		public virtual void OnMethodInvoke(OnMethodInvokeArgs e) { }

        /// <summary>
		/// Intercept the execution right after the handler method is called
		/// </summary>
		public virtual void AfterMethodInvoke(object result) { }

        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);

            var ajaxCall = new AjaxCallSignature(context);
        }
    }
}
