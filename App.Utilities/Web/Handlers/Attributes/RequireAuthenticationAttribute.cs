using System;

namespace App.Utilities.Web.Handlers
{
    /// <summary>
    /// Use this attribute to decorate the handler methods that need explicit authentication configuration.
    /// If this attibute is set to true it will validate if the user is authenticated.
    /// </summary>
    public class RequireAuthenticationAttribute : Attribute
    {
        public readonly bool RequireAuthentication = false;

        public RequireAuthenticationAttribute(bool value)
        {
            RequireAuthentication = value;
        }
    }
}