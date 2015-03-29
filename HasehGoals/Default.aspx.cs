using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HasehGoals
{
    public partial class Default : System.Web.UI.Page
    {
        TableCreator tb = new TableCreator();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            { 
            //Populate List of Current Goals
                populateListCurrentGoals();
            //Populate List of Past Goals
                populateListPastGoals();
            //Security Check?
            }
        }
        private void populateListCurrentGoals()
        {
            divGoalsTable.InnerHtml = tb.getCurrentGoalsTable();
        }
        private void populateListPastGoals()
        {
            divPastGoalsTable.InnerHtml = tb.getPastGoalsTable();
        }

        protected void btnSubmitGoal_Click(object sender, EventArgs e)
        {
            try
            {
                errorLabel.Text = "";
                if (txtGoal.Text.Trim().Equals(""))
                {
                    errorLabel.Text = "You need to populate the text box!";
                }
                else if(txtDate.Text.Trim().Equals(""))
                {
                    errorLabel.Text = "You need to select a date!";
                }
                else
                {

                    Uploader.UploadNewGoal(ddlOwner.SelectedValue, txtGoal.Text, txtDate.Text);
                    txtDate.Text = "";
                    txtGoal.Text = "";
                    populateListCurrentGoals();
                    populateListPastGoals();
                }
            }
            catch(Exception ex)
            {
                errorLabel.Text = ex.ToString();
            }
        }
    }
}