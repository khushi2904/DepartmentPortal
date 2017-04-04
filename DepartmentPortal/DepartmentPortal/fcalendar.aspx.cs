using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DepartmentPortal
{
    public partial class fcalendar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null || Session["id"] == null || Session["type"] == null)
            {
                Session.RemoveAll();
                Response.Redirect("expired.aspx");
            }
            else
            {
                if (!this.IsPostBack)
                {
                    mvedit.ActiveViewIndex = 0;
                }
                using(DepartmentPortalDataContext db = new DepartmentPortalDataContext())
                {
                    try
                    {
                        var q = (from i in db.Events
                                 select new
                                 {
                                     i.event_id,
                                     i.name,
                                     date = i.date.ToString()
                                 }).OrderBy(d => d.date);

                        gvcalendar.DataSource = q;
                        gvcalendar.DataBind();
                    }
                    catch(Exception ex) { }
                }
            }
        }

        protected void gvcalendar_SelectedIndexChanged(object sender, EventArgs e)
        {
            using(DepartmentPortalDataContext db = new DepartmentPortalDataContext())
            {
                try
                {
                    mvedit.ActiveViewIndex = 1;
                    txtid.Text = gvcalendar.SelectedRow.Cells[1].Text;
                    txtname.Text = gvcalendar.SelectedRow.Cells[2].Text;
                    txteditdate.Text = gvcalendar.SelectedRow.Cells[3].Text;
                }
                catch(Exception ex) { }
            }
        }

        protected void gvcalendar_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
                e.Row.Cells[0].Style.Add(HtmlTextWriterStyle.Display, "none");
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Style.Add(HtmlTextWriterStyle.Display, "none");
                e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.background='#eeeeee';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.background='#ffffff';";
                e.Row.Attributes["onclick"] = "__doPostBack('" + gvcalendar.UniqueID + "','Select$" + e.Row.RowIndex + "');";

            }
        }

        protected void gvcalendar_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[1].Text = "Event ID";
                e.Row.Cells[2].Text = "Event Name";
                e.Row.Cells[3].Text = "Event Date";
            }
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            using(DepartmentPortalDataContext db = new DepartmentPortalDataContext())
            {
                try
                {
                    var q = from i in db.Events
                            where i.name == txtname.Text && i.date == Convert.ToDateTime(txtdate.Text)
                            select i;

                    if (q.Any())
                    {
                        lbladderror.Text = "Event already exists.";
                        return;
                    }

                    Event ev = new Event()
                    {
                        date = Convert.ToDateTime(txtdate.Text),
                        name = txtnewevent.Text
                    };
                    db.Events.InsertOnSubmit(ev);
                    db.SubmitChanges();
                    lbladderror.Text = "Event Added Successfully.";
                    Page_Load(sender, e);
                }
                catch(Exception ex) { }
            }
        }

        protected void btnedit_Click(object sender, EventArgs e)
        {
            using(DepartmentPortalDataContext db = new DepartmentPortalDataContext())
            {
                try
                {
                    var q = (from i in db.Events
                             where i.event_id == Convert.ToInt32(txtid.Text)
                             select i).Single();
                    q.name = txtname.Text;
                    q.date = Convert.ToDateTime(txteditdate.Text);
                    db.SubmitChanges();
                    lblediterror.Text = "Event Modification Successful.";
                    Page_Load(sender, e);
                }
                catch(Exception ex)
                {
                    lblediterror.Text = "Event Modification Unsuccessful";
                }
            }
        }

        protected void btnremove_Click(object sender, EventArgs e)
        {
            using (DepartmentPortalDataContext db = new DepartmentPortalDataContext())
            {
                try
                {
                    var a = from i in db.Events
                            where i.event_id == Convert.ToInt32(txtid.Text) && i.name == txtname.Text && i.date == Convert.ToDateTime(txtdate.Text)
                            select i;

                    if (!a.Any())
                    {
                        lblediterror.Text = "Event doesn't exist.";
                        return;
                    }

                    var q = (from i in db.Events
                             where i.event_id == Convert.ToInt32(txtid.Text)
                             select i).Single();
                    db.Events.DeleteOnSubmit(q);
                    db.SubmitChanges();
                    lblediterror.Text = "Event Removed Successfully.";
                    Page_Load(sender, e);
                }
                catch (Exception ex)
                {
                    lblediterror.Text = "Event Removal Unsuccessful";
                }
            }
        }
    }
}