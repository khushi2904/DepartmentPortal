using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DepartmentPortal
{
    public partial class myprofs : System.Web.UI.Page
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
                try
                {
                    using (DepartmentPortalDataContext db = new DepartmentPortalDataContext())
                    {
                        var q = (from i in db.Faculties
                                 where i.branch=="CE"
                                 select new
                                 {
                                     i.faculty_id,
                                     i.faculty_name,
                                     i.Designation,
                                     i.email_id
                                 }).OrderBy(d => d.faculty_name);

                        gvprofs.DataSource = q;
                        gvprofs.DataBind();
                    }
                }
                catch (Exception ex) { }
            }
        }

        protected void gvprofs_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = "ID";
                e.Row.Cells[1].Text = "Full Name";
                e.Row.Cells[2].Text = "Designation";
                e.Row.Cells[3].Text = "Email ID";
            }
        }
    }
}