using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLAccess
{
    public static class DataAccess
    {
        private static string connstring = "Data Source=184.168.194.77;Initial Catalog=ayalaSolivanData;Persist Security Info=True;User ID=hectorhaas;Password=6470060aA@";
        public static void justExecuteQuery(string query)
        {
            try 
            { 
                SqlConnection conn = new SqlConnection(connstring);
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable getAnyDataTable(string query)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connstring);
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataSet getAnyDataSet(string query)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connstring);
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataSet dt = new DataSet();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
