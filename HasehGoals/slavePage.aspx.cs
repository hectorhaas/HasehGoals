using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HasehGoals
{
    public partial class slavePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if(Request.QueryString["delete"]!=null)
                {
                    Updater.deleteGoal(Request.QueryString.Get("delete"));
                }
                else if (Request.QueryString["complete"]!=null)
                {
                    Updater.completeGoal(Request.QueryString.Get("complete"));
                }
                else
                {

                }
            }
            catch
            {

            }
            ClientScript.RegisterStartupScript(typeof(Page), "closePage", "window.close();", true);
        }
    }
}