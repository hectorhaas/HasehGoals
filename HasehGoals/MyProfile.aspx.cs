using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HasehGoals
{
    public partial class MyProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //checkifloggedin
            if(Session["GoalOwner"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                //populate
                populateFields();
            }
        }
        private void populateFields()
        {

            Users usr = new Users();
            DataTable dt = usr.getUser(Session["GoalOwner"].ToString());
            txtUserName.Text = dt.Rows[0]["userName"].ToString();
            txtPassword.Text = dt.Rows[0]["userPassword"].ToString();
            txtEmail.Text = dt.Rows[0]["Email"].ToString();
            if (dt.Rows[0]["receiveEmails"].ToString().Equals("Y"))
            {
                chkReceiveEmails.Checked = true;
            }
            else
            {
                chkReceiveEmails.Checked = false;
            }
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            Users usr = new Users();
            usr.updateUser(Session["GoalOwner"].ToString(), txtUserName.Text, txtPassword.Text, txtEmail.Text, chkReceiveEmails.Checked);
            lblMessage.Text = "Info Updated";
            populateFields();
        }
    }
}