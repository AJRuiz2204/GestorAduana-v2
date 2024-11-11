// Global.asax.cs
using System;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace GestorAduana_v1
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_AuthenticateRequest(Object sender, EventArgs e)
        {
            HttpCookie authCookie = Context.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                try
                {
                    FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);

                    if (authTicket != null && !authTicket.Expired)
                    {
                        string[] roles = authTicket.UserData.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                        GenericIdentity identity = new GenericIdentity(authTicket.Name, "Forms");
                        GenericPrincipal principal = new GenericPrincipal(identity, roles);

                        Context.User = principal;
                        System.Threading.Thread.CurrentPrincipal = principal;
                    }
                }
                catch
                {
                    // Manejo de errores si la cookie no puede ser desencriptada
                    FormsAuthentication.SignOut();
                }
            }
        }
    }
}
