using App.Utilities.Web.Interfaces;
using System;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Xml.Serialization;

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
            if (!IsPostBack)
            {
                var ajaxCall = new AjaxCallSignature(context);

                if (!string.IsNullOrWhiteSpace(ajaxCall.method))
                {
                    //context.Response.ContentType = string.Empty;
                    if (!string.IsNullOrEmpty(ajaxCall.returnType))
                    {
                        switch (ajaxCall.returnType)
                        {
                            case "json":
                                context.Response.ContentType = "application/json";
                                break;
                            case "xml":
                                context.Response.ContentType = "application/xml";
                                break;
                            case "jpg":
                            case "jpeg":
                            case "image/jpg":
                                context.Response.ContentType = "image/jpg";
                                break;
                            default:
                                break;
                        }
                    }

                    // call the requested method
                    object result = ajaxCall.Invoke(this, context);

                    // if neither on the arguments or the actual method the content type was set then make sure to use the default content type
                    if (string.IsNullOrEmpty(context.Response.ContentType) && !SkipContentTypeEvaluation)
                    {
                        context.Response.ContentType = DefaultContentType();
                    }

                    // only skip transformations if the requestor explicitly said so
                    if (result == null)
                    {
                        context.Response.Write(string.Empty);
                    }
                    else if (!SkipDefaultSerialization)
                    {
                        switch (context.Response.ContentType.ToLower())
                        {
                            case "application/json":
                                JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
                                string json = jsonSerializer.Serialize(result);
                                context.Response.Write(json);
                                break;
                            case "application/xml":
                                XmlSerializer xmlSerializer = new XmlSerializer(result.GetType());
                                StringBuilder xmlSb = new StringBuilder();
                                System.Xml.XmlWriter xmlWriter = System.Xml.XmlWriter.Create(xmlSb);
                                xmlSerializer.Serialize(xmlWriter, result);
                                context.Response.Write(xmlSb.ToString());
                                break;
                            case "text/html":
                                context.Response.Write(result);
                                break;
                            default:
                                throw new Exception(string.Format("Unsupported content type [{0}]", context.Response.ContentType));
                        }
                    }
                    else
                    {
                        context.Response.Write(result);
                    }
                }
            }

            //最後呼叫base, 繼續life cycle
            base.ProcessRequest(context);
        }

        /// <summary>
        /// Setting this to false will make the handler to respond with exactly what the called method returned.
        /// If true the handler will try to serialize the content based on the ContentType set.
        /// </summary>
        public bool SkipDefaultSerialization { get; set; }

        /// <summary>
        /// Setting this to true will avoid the handler to change the content type wither to its default value or to its specified value on the request.
        /// This is useful if you're handling the request yourself and need to specify it yourself.
        /// </summary>
        public bool SkipContentTypeEvaluation { get; set; }

        /// <summary>
        /// Returns the default content type returned by the handler.
        /// </summary>
        /// <returns></returns>
        public virtual string DefaultContentType()
        {
            return "application/json";
        }
    }
}
