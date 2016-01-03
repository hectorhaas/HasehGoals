using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HasehGoals
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //verify if login is correct
            lblError.Text = "";
            Users usr = new Users();
            string usrID = usr.verifyAccess(txtUsername.Text.Trim().ToUpper(), txtPassword.Text.Trim());
            //take action
            if (usrID == null)
            {
                lblError.Text = "The username / password you used is incorrect.";
            }
            else
            {
                Session["GoalOwner"] = usrID;
                Response.Redirect("Default.aspx");
            }
        }
    }
}