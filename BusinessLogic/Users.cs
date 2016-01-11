using SQLAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Users
    {
        public Users()
        { }
        public string verifyAccess(string userName, string password)
        {
            DataProvider dp = new DataProvider();
            DataTable dt = dp.verifyAccess(userName, password);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["Id"].ToString();
            }
            else
            {
                return null;
            }
        }
        public void updateUser(string GoalOwnerID, string userName, string userPassword, string email, bool receiveEmails, string profilePicPath)
        {
            DataProvider dp = new DataProvider();
            string receiveEmailsString = "";
            if(receiveEmails)
            {
                receiveEmailsString = "Y";
            }
            else
            {
                receiveEmailsString = "N";
            }
            userName = cleanText(userName);
            userPassword = cleanText(userPassword);
            email = cleanText(email);
            dp.updateUser(GoalOwnerID, userName, userPassword, email, receiveEmailsString, profilePicPath);
        }
        public DataTable getUser(string GoalOwnerID)
        {
            DataProvider dp = new DataProvider();
            return dp.getUser(GoalOwnerID);
        }
        public string cleanText(string text)
        {
            text = text.Trim().Replace("'", "''");
            return text;
        }
        public string getProfilePic(string GoalOwnerID)
        {
            DataProvider dp = new DataProvider();
            return dp.getProfilePic(GoalOwnerID);
        }
    }
}
