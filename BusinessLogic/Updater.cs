using SQLAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public static class Updater
    {
        public static void completeGoal(string id)
        {
            try
            {
            string query = "Update Goals SET completed = 'Y', dateCompleted = getdate() WHERE Id = " + id;
            DataAccess.justExecuteQuery(query);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public static void deleteGoal(string id)
        {
            try
            {
                string query = "DELETE FROM Goals WHERE Id = " + id;
                DataAccess.justExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
