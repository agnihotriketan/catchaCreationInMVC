using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.SessionState;

namespace catchaCreationInMVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());
        }


        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var ex = Server.GetLastError();
            // Log application level exceptions
        }

        protected void Application_EndRequest()
        {
            if (Context.Response.StatusCode != 200 && Context.Response.StatusCode != 302 && Context.Response.StatusCode != 400)
            {
                var statusCode = Response.StatusCode;
                switch (statusCode)
                {
                    case 400:
                        Response.Clear();
                        Response.Redirect("~/Home/Error");
                        break;
                    case 404:
                        Response.Clear();
                        Response.Redirect("~/Home/Error");
                        break;
                    case 500:
                        Response.Clear();
                        Response.Redirect("~/Home/Error");
                        break;
                    default: 
                        break;
                }
            }
        }

        //To enable session in webApi
        public override void Init()
        {
            PostAuthenticateRequest += MvcApplication_PostAuthenticateRequest;
            base.Init();
        }

        static void MvcApplication_PostAuthenticateRequest(object sender, EventArgs e)
        {
            HttpContext.Current.SetSessionStateBehavior(SessionStateBehavior.Required);
        }
    }
}
