using SQLAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Goals
    {
        private string goalID = "";
        private Goals()
        {
        }
        public Goals(string id)
        {
            goalID = id;
        }
        public string populateGoalText()
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                //Select Goal Info
                DataProvider dp = new DataProvider();
                DataTable dt = dp.getGoalInfo(goalID);
                if (dt.Rows.Count > 0)
                {
                    sb.Append("<p>");
                    sb.Append(dt.Rows[0]["textGoal"].ToString());
                    sb.Append("</p>");

                    sb.Append("<p>");
                    sb.Append("<b>Goal Date: </b>");
                    sb.Append(dt.Rows[0]["dateGoal"].ToString());
                    sb.Append("</p>");

                }
                else
                {
                    //No Data found
                    sb.Append("<p>");
                    sb.Append("An Error Occurred, No Data Found!");
                    sb.Append("</p>");
                }

                //Over
                return sb.ToString();
            }
            catch (Exception ex)
            { throw ex; }
        }
        public void addComment(string comment, string owner)
        {
            try
            {
                DataProvider dp = new DataProvider();
                dp.addComment(goalID, owner, comment);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string populateCommentsTable()
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                DataProvider dp = new DataProvider();
                DataTable dt = dp.getComments(goalID);
                if (dt.Rows.Count > 0)
                {
                    sb.Append("<table id=\"tableComments\">");
                    sb.Append("<thead>");
                    sb.Append("<tr>");
                    sb.Append("<th></th>");
                    sb.Append("<th></th>");
                    sb.Append("</tr>");
                    sb.Append("</thead>");
                    sb.Append("<tbody>");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        sb.Append("<tr>");

                        sb.Append("<td>");
                        if (dt.Rows[i]["OwnerID"].ToString().Equals("1"))
                        { sb.Append("<img src='_img/chi.jpg' alt='Evonne' title='Evonne' style='width:50px;'/>"); }
                        else
                        { sb.Append("<img src='_img/retard.jpg' alt='Hector' title='Hector' style='width:50px;'/>"); }
                        sb.Append("</td>");

                        sb.Append("<td>");
                        sb.Append(dt.Rows[i]["CommentText"].ToString());
                        sb.Append("</td>");

                        sb.Append("</tr>");
                    }
                    sb.Append("</tbody>");
                    sb.Append("</table>");

                    sb.Append("<script>");
                    sb.Append("$(document).ready(function(){");
                    sb.Append("$('#tableComments').DataTable();");
                    sb.Append("});");
                    sb.Append("</script>");
                }
                else
                {
                    sb.Append("<h3>No Comments...</h3>");
                }
                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void UploadPicture(string ownerID, string comment, string filename)
        {
            try
            {
                DataProvider dp = new DataProvider();
                dp.addPicture(goalID, filename, ownerID, comment);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string populatePictures()
        {
            StringBuilder sb = new StringBuilder();
            DataProvider dp = new DataProvider();
            DataTable dt = dp.getPictures(goalID);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sb.Append("<div class=\"panel\" style=\"width:32%;float:left;\">");
                    sb.Append("<img id=\"pdiv" + i.ToString() + "\" src=\"" + dt.Rows[i]["Path"].ToString() + "\" alt=\"X\" style=\"width:100%;\"/>");
                    sb.Append("<p>" + dt.Rows[i]["Comment"].ToString() + "</p>");
                    sb.Append("</div>");

                    sb.Append("<div class=\"modal fade\" id=\"myModal" + i.ToString() + "\" tabindex=\"-1\" role=\"dialog\" aria-hidden=\"true\">");
                    sb.Append("<div class=\"modal-dialog\">");
                    sb.Append("<div class=\"modal-content\">");
                    sb.Append("<div class=\"modal-body\">");
                    sb.Append("<img src=\"" + dt.Rows[i]["Path"].ToString() + "\" alt=\"X\" style=\"width:100%;\"/>");
                    sb.Append("<p>" + dt.Rows[i]["Comment"].ToString() + "</p>");
                    sb.Append("</div>");
                    sb.Append("<div class=\"modal-footer\">");
                    sb.Append("<button type=\"button\" class=\"btn btn-default\" data-dismiss=\"modal\">Close</button>");
                    sb.Append("</div></div></div></div>");
                    sb.Append("<script>");
                    sb.Append("$('#myModal" + i.ToString() + "').on('shown.bs.modal', function () {");
                    sb.Append("$('#pdiv" + i.ToString() + "').focus()");
                    sb.Append("});");
                    sb.Append("</script>");
                }
            }
            else
            {
                sb.Append("<h2>No Pictures...</h2>");
            }
            return sb.ToString();
        }
    }
}
