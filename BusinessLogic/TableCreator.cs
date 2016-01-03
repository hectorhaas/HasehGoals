using SQLAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class TableCreator
    {
        public TableCreator() { }
        public string getCurrentGoalsTable()
        {
            try
            {
                DataProvider dp = new DataProvider();
                DataTable dt = dp.getCurrentGoals();
                if (dt.Rows.Count > 0)
                {

                    StringBuilder sb = new StringBuilder();
                    StringBuilder scripts = new StringBuilder();
                    sb.Append("<table class='table table-bordered'>");
                    scripts.Append("<script>");
                    #region head
                    sb.Append("<thead>");

                    sb.Append("<tr>");
                    sb.Append("<td>");
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append("Owner");
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append("Goal");
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append("Date to Complete");
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append("</td>");
                    sb.Append("</tr>");

                    sb.Append("</thead>");
                    #endregion
                    #region body
                    sb.Append("<tbody>");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        sb.Append("<tr id='row" + i.ToString() + "'>");
                        //Select Button
                        sb.Append("<td>");
                        sb.Append("<button type=\"button\" class=\"btn btn-primary\" id=\"tbnSelect" + i.ToString() + "\">Open</button>");
                        sb.Append("</td>");
                        //Owner
                        sb.Append("<td>");
                        if (dt.Rows[i]["goalOwner"].ToString().Equals("1"))
                        { sb.Append("<img src='_img/chi.jpg' alt='Evonne' style='width:50px;'/>"); }
                        else if (dt.Rows[i]["goalOwner"].ToString().Equals("2"))
                        { sb.Append("<img src='_img/retard.jpg' alt='Hector' style='width:50px;'/>"); }
                        else
                        {
                            sb.Append("<img src='_img/chi.jpg' alt='Evonne' style='width:25px;'/>");
                            sb.Append("<img src='_img/retard.jpg' alt='Hector' style='width:25px;'/>");
                        }
                        sb.Append("</td>");
                        //Goal Text
                        sb.Append("<td>");
                        sb.Append(dt.Rows[i]["textGoal"].ToString());
                        sb.Append("</td>");
                        //Date to Complete
                        sb.Append("<td>");
                        sb.Append(Convert.ToDateTime(dt.Rows[i]["dateGoal"].ToString()).ToShortDateString());
                        sb.Append("</td>");
                        //Buttons
                        sb.Append("<td>");
                        sb.Append("<a id=\"atag" + i.ToString() + "\" style=\"visibility:hidden;\">" + dt.Rows[i]["Id"].ToString() + "</a>");
                        sb.Append("<button type=\"button\" class=\"btn btn-danger\" id=\"tbnDelete" + i.ToString() + "\">Delete</button>");
                        sb.Append("<button type=\"button\" class=\"btn btn-success\" id=\"tbnComplete" + i.ToString() + "\">Complete</button>");
                        sb.Append("</td>");
                        sb.Append("</tr>");

                        //Scripts
                        scripts.Append("var goalID" + i.ToString() + " = $(\"#atag" + i.ToString() + "\").text();");
                        //Delete
                        scripts.Append("$(\"#tbnDelete" + i.ToString() + "\").click(function ()");
                        scripts.Append("{");
                        scripts.Append("var textThingy" + i.ToString() + " = $(\"#atag" + i.ToString() + "\").text();");

                        scripts.Append("var wd" + i.ToString() + " = window.open(\"slavePage.aspx?delete=\"+textThingy" + i.ToString() + ",\"_blank\",\"toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=yes, width=400, height=400\");");
                        scripts.Append("wd" + i.ToString() + ".onunload = function () {");
                        scripts.Append("window.location.href = window.location.href;");
                        scripts.Append("};");

                        scripts.Append("});");
                        //Complete
                        scripts.Append("$(\"#tbnComplete" + i.ToString() + "\").click(function ()");
                        scripts.Append("{");
                        scripts.Append("var textThingyC" + i.ToString() + " = $(\"#atag" + i.ToString() + "\").text();");

                        scripts.Append("var w" + i.ToString() + " = window.open(\"slavePage.aspx?complete=\"+textThingyC" + i.ToString() + ",\"_blank\",\"toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=yes, width=400, height=400\");");
                        scripts.Append("w" + i.ToString() + ".onunload = function () {");
                        scripts.Append("window.location.href = window.location.href;");
                        scripts.Append("};");

                        scripts.Append("});");

                        //Select
                        //Complete
                        scripts.Append("$(\"#tbnSelect" + i.ToString() + "\").click(function ()");
                        scripts.Append("{");

                        scripts.Append("window.location.href = 'Goal.aspx?id='+ goalID" + i.ToString()+";");

                        scripts.Append("});");
                    }
                    sb.Append("</tbody>");
                    #endregion
                    sb.Append("</table>");
                    scripts.Append("</script>");
                    return sb.ToString() + scripts.ToString();
                }
                else
                {
                    return "<h2>No Current Goals</h2>";
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        public string getPastGoalsTable()
        {
            try
            {
                DataProvider dp = new DataProvider();
                DataTable dt = dp.getPastGoals();
                if (dt.Rows.Count > 0)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("<table class='table table-bordered'>");
                    #region head
                    sb.Append("<thead>");

                    sb.Append("<tr>");
                    sb.Append("<td>");
                    sb.Append("Owner");
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append("Goal");
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append("Date Completed");
                    sb.Append("</td>");
                    sb.Append("</tr>");

                    sb.Append("</thead>");
                    #endregion
                    #region body
                    sb.Append("<tbody>");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        sb.Append("<tr id='row" + i.ToString() + "'>");
                        //Owner
                        sb.Append("<td>");
                        if (dt.Rows[i]["goalOwner"].ToString().Equals("1"))
                        { sb.Append("<img src='_img/chi.jpg' alt='Evonne' style='width:50px;'/>"); }
                        else if (dt.Rows[i]["goalOwner"].ToString().Equals("2"))
                        { sb.Append("<img src='_img/retard.jpg' alt='Hector' style='width:50px;'/>"); }
                        else
                        {
                            sb.Append("<img src='_img/chi.jpg' alt='Evonne' style='width:25px;'/>");
                            sb.Append("<img src='_img/retard.jpg' alt='Hector' style='width:25px;'/>");
                        }
                        sb.Append("</td>");
                        //Goal Text
                        sb.Append("<td>");
                        sb.Append(dt.Rows[i]["textGoal"].ToString());
                        sb.Append("</td>");
                        //Date to Complete
                        sb.Append("<td>");
                        sb.Append(Convert.ToDateTime(dt.Rows[i]["dateCompleted"].ToString()).ToShortDateString());
                        sb.Append("</td>");
                        //Buttons
                        sb.Append("</tr>");
                    }
                    sb.Append("</tbody>");
                    #endregion
                    sb.Append("</table>");
                    return sb.ToString();
                }
                else
                {
                    return "<h3>No Past Goals</h3>";
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        public DataSet getCurrentGoalsWebService()
        {
            try
            {
                DataProvider dp = new DataProvider();
                DataSet ds = dp.getCurrentGoalsWebService();
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
