using App.Utilities.Web.Interfaces;
using System.Web;
using System.Web.UI;

namespace App.Utilities.Web.Handlers
{
    public abstract partial class BasePage : Page, IModelBinder
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
            var ajaxCall = new AjaxCallSignature(context);

            //最後base呼叫, 繼續life cycle
            base.ProcessRequest(context);
        }
    }
}
