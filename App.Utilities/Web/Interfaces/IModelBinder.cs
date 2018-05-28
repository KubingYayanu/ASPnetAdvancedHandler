using App.Utilities.Web.Handlers;
using System.Web;

namespace App.Utilities.Web.Interfaces
{
    public interface IModelBinder
    {
        /// <summary>
        /// Intercept the execution right before the handler method is called
        /// </summary>
        /// <param name="e"></param>
        void OnMethodInvoke(OnMethodInvokeArgs e);

        /// <summary>
        /// Intercept the execution right after the handler method is called
        /// </summary>
        /// <param name="result"></param>
        void AfterMethodInvoke(object result);

        void ProcessRequest(HttpContext context);
    }
}