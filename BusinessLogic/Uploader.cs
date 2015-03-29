using SQLAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public static class Uploader
    {
        public static void UploadNewGoal(string owner, string text, string goalDate)
        {
            try
            {
                string query = "Insert into Goals (textGoal, dateSubmitted, goalOwner, completed, dateGoal) VALUES ('" + text + "', getdate(), " + owner + ", 'N', CONVERT(datetime, '"+goalDate+"', 101))";
                DataAccess.justExecuteQuery(query);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }
        public static void UploadNewPicture(string id)
        {

        }
    }
}
