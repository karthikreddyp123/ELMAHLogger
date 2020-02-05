using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Elmah;
using System.Data;
namespace ELMAHLogger
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.Write("Number of Applications:" + Application["TotalApplications"]);
            //Response.Write("<br/>");
            //Response.Write("Number of User Sessions:" + Application["TotalUserSessions"]);
            //HttpException TotalApplicationCount = new HttpException("Total Applications:" + Application["TotalApplications"]);
            //Elmah.ErrorSignal.FromCurrentContext().Raise(TotalApplicationCount);
            //HttpException TotalUserSessionCount = new HttpException("Total User Sessions:" + Application["TotalUserSessions"]);
            //Elmah.ErrorSignal.FromCurrentContext().Raise(TotalUserSessionCount);
            //try
            //{
                throw new DivideByZeroException();

            //}
            //catch(Exception ex)
            //{
            //    Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
            //}
        }
    }
}