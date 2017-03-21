using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DepartmentPortal
{
    public partial class examresults : System.Web.UI.Page
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
                string id = Session["id"].ToString();

                if (!this.IsPostBack)
                {
                    mvres.ActiveViewIndex = 0;
                    List<string> type = new List<string>()
                    {
                        "Internal","External"
                    };

                    ddltype.DataSource = type;
                    ddltype.DataBind();

                    using (DepartmentPortalDataContext db = new DepartmentPortalDataContext())
                    {
                        try
                        {
                            var q = from i in db.Semesters
                                    where i.student_id == id
                                    select i.sem;

                            ddlsem.DataSource = q;
                            ddlsem.DataBind();

                        }
                        catch (Exception ex) { }
                    }
                }

            }
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            int sem = Convert.ToInt32(ddlsem.SelectedValue);
            int type = ddltype.SelectedItem.Text == "Internal" ? 0 : 1;
            string id = Session["id"].ToString();

            using(DepartmentPortalDataContext db = new DepartmentPortalDataContext())
            {
                try
                {
                    int sid = Convert.ToInt32((from i in db.Semesters
                                               where i.student_id == id && i.sem == sem
                                               select i.sem_id).Single());


                    if (type == 0)
                    {
                        var q = from i in db.sessions
                                join j in db.InternalMarks on i.session_id equals j.session_id
                                join k in db.subjects on j.subject_id equals k.subject_id
                                where i.sem_id == sid
                                select new
                                {
                                    k.subject_id,
                                    k.subject_name,
                                    j.marks1,
                                    j.marks2,
                                    j.marks3,
                                    j.bmarks
                                };

                        gvinternal.DataSource = q;
                        gvinternal.DataBind();
                        mvres.ActiveViewIndex = 1;

                    }
                    else if (type == 1)
                    {
                        
                        var q = from i in db.ExternalMarks
                                join j in db.subjects on i.subject_id equals j.subject_id
                                where i.sem_id == sid
                                select new
                                {
                                    i.subject_id,
                                    j.subject_name,
                                    i.pract_marks,
                                    j.subject_credit,
                                    i.grade,
                                    i.status,
                                };

                        gvexternal.DataSource = q;
                        gvexternal.DataBind();
                        mvres.ActiveViewIndex = 2;
                    }
                }
                catch(Exception ex) { }
            }
        }

        protected void gvinternal_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = "Subject Code";
                e.Row.Cells[1].Text = "Subject Name";
                e.Row.Cells[2].Text = "S1 Marks";
                e.Row.Cells[3].Text = "S2 Marks";
                e.Row.Cells[4].Text = "S3 Marks";
                e.Row.Cells[5].Text = "Block Marks";
            }
        }

        protected void gvexternal_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = "Subject Code";
                e.Row.Cells[1].Text = "Subject Name";
                e.Row.Cells[2].Text = "Practical Status";
                e.Row.Cells[3].Text = "Subject Credit";
                e.Row.Cells[4].Text = "Grade";
                e.Row.Cells[5].Text = "Status";
            }
        }
    }
}