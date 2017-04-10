using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DepartmentPortal
{
    public partial class notifications : System.Web.UI.Page
    {
        DateTime date;
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
                        DateTime today = DateTime.Now.AddDays(-30);

                        var la = (from i in db.n_lastaccesseds
                                  where i.student_id == id
                                  select i).Single();


                        date = Convert.ToDateTime(la.lastaccessed);

                        var q = (from i in db.notifications
                                 where (i.sem == sem || i.sem == null) && Convert.ToDateTime(i.notifdate).CompareTo(today) > 0
                                 select new
                                 {
                                     i.notif,
                                     i.notifdate
                                 }).OrderByDescending(d => d.notifdate);

                        gvnotifications.DataSource = q;
                        gvnotifications.DataBind();

                        la.lastaccessed = DateTime.Now;
                        db.SubmitChanges();

                        Session["notifcount"] = 0;
                    }
                    catch(Exception ex) { }
                }
            }
        }

        protected void gvnotifications_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Visible = false;
                e.Row.Cells[1].Visible = false;
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DateTime today = DateTime.Now;
                if (today.CompareTo(date) > 0)
                {
                    DateTime messd = Convert.ToDateTime(e.Row.Cells[1].Text);
                    if (messd.CompareTo(date) > 0)
                    {
                        e.Row.BackColor = System.Drawing.Color.LightGray;

                    }
                    else
                    {
                        e.Row.BackColor = System.Drawing.Color.White;
                    }
                }
            }
        }
    }
}