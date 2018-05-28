using System;

namespace App.Utilities.Web.Handlers
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public abstract class HttpVerbAttribute : Attribute
    {
        public abstract string HttpVerb { get; }
    }
}