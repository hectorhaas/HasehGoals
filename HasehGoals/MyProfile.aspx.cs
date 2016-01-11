using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
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
            if(!dt.Rows[0]["profilePicturePath"].ToString().Equals(""))
            {
                divProfilePic.InnerHtml = "<img src=\""+dt.Rows[0]["profilePicturePath"].ToString()+"\" style=\"width:100%;\" alt=\"Profile Pic\" />";
            }
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string fileName = "";
            string ext = "";
            string dbFileName = "";
            lblMessage.Text = "";
            #region Upload
            if (!FileUploadPictures.HasFile)
            {

            }
            else
            {
                
                if (FileUploadPictures.HasFile)
                {
                    string tempstr = Session["GoalOwner"].ToString();
                    string[] typeArray = FileUploadPictures.FileName.Split('.');
                    ext = "." + typeArray[typeArray.Length - 1];
                    fileName = Server.MapPath("images") + "/" + tempstr + ext;
                    dbFileName = "images/profile" + tempstr + ext;
                    int number = 1;

                    fileName = Server.MapPath("images") + "/profile" + tempstr + number.ToString() + ext;
                    dbFileName = "images/profile" + tempstr + number.ToString() + ext;
                    while (File.Exists(fileName))
                    {
                        number++;
                        fileName = Server.MapPath("images") + "/profile" + tempstr + number.ToString() + ext;
                        dbFileName = "images/profile" + tempstr + number.ToString() + ext;
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
                    
                }

            }
            #endregion
            Users usr = new Users();
            usr.updateUser(Session["GoalOwner"].ToString(), txtUserName.Text, txtPassword.Text, txtEmail.Text, chkReceiveEmails.Checked,dbFileName);
            lblMessage.Text = "Info Updated";
            populateFields();
        }
    }
}