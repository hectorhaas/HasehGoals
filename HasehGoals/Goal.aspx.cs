using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HasehGoals
{
    public partial class Goal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                //PopulateFields
                populateGoalData();
            }
        }
        private void populateGoalData()
        {
            if(Request.QueryString["id"]!=null)
            {
                Goals gi = new Goals(Request.QueryString["id"].ToString());
                //Populate Goal Info
                divGoalInfo.InnerHtml = gi.populateGoalText();
                
                //Populate Comments
                populateCommentsTable();
                //Populate Pictures
            }
            else
            {
                divLoginContainer.InnerHtml = "Error";
                divComments.InnerHtml = "Error";
                divGoalInfo.InnerHtml = "Error";
                divPictures.InnerHtml = "Error";
            }
        }

        protected void txtEvonne_Click(object sender, EventArgs e)
        {
            ownerID.Value = "1";
            panelLogin.Visible = false;
            panelMainContent.Visible = true;
        }

        protected void txtHector_Click(object sender, EventArgs e)
        {
            ownerID.Value = "2";
            panelLogin.Visible = false;
            panelMainContent.Visible = true;
        }

        protected void btnGoBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void btnAddComment_Click(object sender, EventArgs e)
        {
            try
            {
                Goals gi = new Goals(Request.QueryString["id"].ToString());
                gi.addComment(txtComment.Text, ownerID.Value);
                txtComment.Text = "";
                //RepopulateTable
                populateCommentsTable();
            }
            catch(Exception ex)
            {
                txtComment.Text = "Error: " + ex.ToString();
            }
        }
        private void populateCommentsTable()
        {
            try
            {
                Goals gi = new Goals(Request.QueryString["id"].ToString());
                divComments.InnerHtml = gi.populateCommentsTable();
            }
            catch(Exception ex)
            {
                divComments.InnerHtml = "An Error Occurred";
            }
        }
    }
}