using BusinessLogic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
                populatePicturesTable();
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
                divComments.InnerHtml = "An Error Occurred: " + ex.ToString();
            }
        }

        protected void btnPictureUpload_Click(object sender, EventArgs e)
        {
            #region Upload
            if (!FileUploadPictures.HasFile)
            {

            }
            else
            {
                string fileName = "";
                string ext = "";
                string dbFileName = "";
                if (FileUploadPictures.HasFile)
                {
                    string tempstr = Request.QueryString["id"].ToString();
                    string[] typeArray = FileUploadPictures.FileName.Split('.');
                    ext = "." + typeArray[typeArray.Length - 1];
                    fileName = Server.MapPath("images") + "/" + tempstr + ext;
                    dbFileName = "images/" + tempstr + ext;
                    int number = 1;

                    fileName = Server.MapPath("images") + "/" + tempstr + number.ToString() + ext;
                    dbFileName = "images/" + tempstr + number.ToString() + ext;
                    while (File.Exists(fileName))
                    {
                        number++;
                        fileName = Server.MapPath("images") + "/" + tempstr + number.ToString() + ext;
                        dbFileName = "images/" + tempstr + number.ToString() + ext;
                    }
                    FtpWebRequest request;
                    string folderName = "/goals.ayalasolivan.com/images/";
                    string absoluteFileName = dbFileName;

                    request = WebRequest.Create(new Uri(string.Format(@"ftp://hectorhaas2@50.62.168.157/goals.ayalasolivan.com/" + dbFileName))) as FtpWebRequest;
                    request.Method = WebRequestMethods.Ftp.UploadFile;
                    request.UseBinary = true;
                    request.UsePassive = true;
                    request.KeepAlive = true;
                    request.Credentials = new NetworkCredential("hectorhaas2", "6470060aA@");
                    request.ConnectionGroupName = "group";
                    byte[] buffer = FileUploadPictures.FileBytes;
                    Stream requestStream = request.GetRequestStream();
                    requestStream.Write(buffer, 0, buffer.Length);
                    requestStream.Close();
                    requestStream.Flush();

                    Goals gi = new Goals(Request.QueryString["id"].ToString());
                    gi.UploadPicture(ownerID.Value, txtPictureComment.Text, dbFileName);

                }

            }
            #endregion
            txtPictureComment.Text = "";
            //reloadPics
            populatePicturesTable();
        }
        private void populatePicturesTable()
        {
            Goals gi = new Goals(Request.QueryString["id"].ToString());
            divPictures.InnerHtml = gi.populatePictures();
        }
    }
}