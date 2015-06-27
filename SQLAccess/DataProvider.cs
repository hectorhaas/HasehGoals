﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace SQLAccess
{
    public class DataProvider
    {
        public DataProvider()
        { }
        public DataTable getCurrentGoals()
        {
            try
            {
                string query = "Select * from Goals where UPPER(completed) = 'N' ORDER BY dateGoal ASC";
                DataTable dt = DataAccess.getAnyDataTable(query);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet getCurrentGoalsWebService()
        {
            try
            {
                string query = "Select * from Goals where UPPER(completed) = 'N' ORDER BY dateGoal ASC";
                DataSet dt = DataAccess.getAnyDataSet(query);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable getPastGoals()
        {
            try
            {
                string query = "Select TOP 10 * from Goals where UPPER(completed) = 'Y' ORDER BY dateCompleted DESC";
                DataTable dt = DataAccess.getAnyDataTable(query);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable getGoalInfo(string id)
        {
            try
            {
                string query = "Select * from Goals WHERE Id = " + id;
                DataTable dt = DataAccess.getAnyDataTable(query);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void addComment(string goalID, string owner, string commentText)
        {
            try
            {
                string query = "Insert into GoalsComments (GoalID, OwnerID, CommentText) VALUES (" + goalID + "," + owner + ",'" + commentText.Replace("'", "''").Replace("&", "and") + "')";
                DataAccess.justExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable getComments(string goalID)
        {
            try
            {
                string query = "Select * from GoalsComments WHERE GoalID = " + goalID + " ORDER BY Id DESC";
                DataTable dt = DataAccess.getAnyDataTable(query);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void addPicture(string goaldID, string fileName, string owner, string comment)
        {
            try
            {
                if(comment.Trim().Equals(""))
                {
                    comment = "NULL";
                }
                else
                {
                    comment = "'" + comment.Trim().Replace("'", "''").Replace("&", "and") + "'";
                }
                string query = "Insert into GoalsPictures (Path, GoalID, UploadOwner, Comment, UploadDate) VALUES ('" + fileName + "', " + goaldID + ", " + owner + ", " + comment + " , GETDATE())";
                DataAccess.justExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable getPictures(string goalID)
        {
            try
            {
                string query = "Select * from GoalsPictures WHERE GoalID = " + goalID;
                return DataAccess.getAnyDataTable(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
