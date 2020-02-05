using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using Elmah;
namespace ELMAHLogger
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Application["TotalApplications"] = 0;
            Application["TotalUserSessions"] = 0;
            Application["TotalApplications"] = (int)Application["TotalApplications"] + 1;
            HttpException ApplicationStart = new HttpException("Application Started " + "Total Applications:" + Application["TotalApplications"]);
            Elmah.ErrorSignal.FromCurrentContext().Raise(ApplicationStart);
        }
        void Session_Start(object sender, EventArgs e)
        {
            Application["TotalUserSessions"] = (int)Application["TotalUserSessions"] + 1;
            HttpException SessionStart = new HttpException("Session Started "+"Total Sessions:" + Application["TotalUserSessions"]);
            Elmah.ErrorSignal.FromCurrentContext().Raise(SessionStart);
            Session.Abandon();
            HttpException SessionEnd = new HttpException("Session Started " + "Total Sessions:" + Application["TotalUserSessions"]);
            Elmah.ErrorSignal.FromCurrentContext().Raise(SessionEnd);
        }
        void Session_End(object sender, EventArgs e)
        {
            Application["TotalUserSessions"] = (int)Application["TotalUserSessions"] - 1;
            HttpException SessionEnd = new HttpException("Session Stopped " + "Total Sessions:" + Application["TotalUserSessions"]);
            Elmah.ErrorSignal.FromCurrentContext().Raise(SessionEnd);
        }
        void Application_End(object sender, EventArgs e)
        {
            Application["TotalApplications"] = (int)Application["TotalApplications"] - 1;
            HttpException ApplicationEnd = new HttpException("Application Ended "+"Total Applications:" + Application["TotalApplications"]);
            Elmah.ErrorSignal.FromCurrentContext().Raise(ApplicationEnd);
        }
        void Application_Error(object sender, EventArgs e)
        {
            HttpException ApplicationError = new HttpException("Application Error");
            Elmah.ErrorSignal.FromCurrentContext().Raise(ApplicationError);

        }
    }
}