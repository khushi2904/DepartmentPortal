using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DepartmentPortal
{
    public partial class mysubjects : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null || Session["id"] == null || Session["sem"] == null || Session["branch"] == null)
            {
                Session.RemoveAll();
                Response.Redirect("expired.aspx");
            }
            else
            {
                using(DepartmentPortalDataContext db = new DepartmentPortalDataContext())
                {
                    try
                    {
                        string id = Session["id"].ToString();
                        int sem = Convert.ToInt32(Session["sem"]);

                        string sub = (from i in db.Students
                                      where i.student_id == id
                                      select i.branch).Single();

                        var q = from i in db.subjects
                                where (i.course == sub || i.course == null) && i.allotted_sem == sem
                                select new
                                {
                                    i.subject_id,
                                    i.subject_name,
                                    i.subject_description,
                                    i.subject_credit
                                };

                        gvsubjects.DataSource = q;
                        gvsubjects.DataBind();
                    }
                    catch(Exception ex) { }
                }
            }
        }

        protected void gvsubjects_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = "Code";
                e.Row.Cells[1].Text = "Name";
                e.Row.Cells[2].Text = "Description";
                e.Row.Cells[3].Text = "Credit";
            }
        }
    }
}