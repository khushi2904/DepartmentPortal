using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DepartmentPortal
{
    public partial class messages : System.Web.UI.Page
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
                if (!this.IsPostBack)
                {
                    mvchats.ActiveViewIndex = 0;
                    mvsearch.ActiveViewIndex = 0;
                    lblerror.Text = "";
                    lblnoresults.Text = "";

                }
                    string id = Session["id"].ToString();
                    using (DepartmentPortalDataContext db = new DepartmentPortalDataContext())
                    {
                        try
                        {
                            var q = (from i in db.messages
                                     join j in db.Faculties on i.faculty_id equals j.faculty_id
                                     where i.student_id == id
                                     select new
                                     {
                                         j.faculty_id,
                                         j.faculty_name,
                                     }).Distinct();
                            

                            var m = (from i in db.m_lastaccesseds
                                     where i.student_id == id
                                     select i).Single();

                            DateTime la = Convert.ToDateTime(m.lastaccesssed);
                            m.lastaccesssed = DateTime.Now;

                            names = (from i in db.messages
                                     where i.student_id == id && Convert.ToDateTime(i.sent_time).CompareTo(la) > 0 && i.type=='r'
                                     select i.faculty_id).ToList();

                            gvchats.DataSource = q;
                            gvchats.DataBind();

                        Session["messagecount"] = 0;
                            
                        }
                        catch (Exception ex) { }
                    }
                
            }
        }

        List<string> names;
        
        protected void gvchats_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[1].Text = "ID";
                e.Row.Cells[2].Text = "Name";
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if(names.Contains(e.Row.Cells[1].Text))
                    e.Row.BackColor = System.Drawing.Color.LightGray;

                names.Clear();
                
            }
        }

        protected void gvchats_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
                e.Row.Cells[0].Style.Add(HtmlTextWriterStyle.Display, "none");
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Style.Add(HtmlTextWriterStyle.Display, "none");
                e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.background='#eeeeee';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.background='#ffffff';";
                e.Row.Attributes["onclick"] = "__doPostBack('" + gvchats.UniqueID + "','Select$" + e.Row.RowIndex + "');";

            }
        }
        static string fid;
        protected void gvchats_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
               fid = gvchats.SelectedRow.Cells[1].Text;
            }
            catch(Exception ex) { }

            string id = Session["id"].ToString();

            using (DepartmentPortalDataContext db = new DepartmentPortalDataContext())
            {
                try
                {
                    var q = (from i in db.messages
                             where i.student_id == id && i.faculty_id == fid
                             select new
                             {
                                 a = (i.type == 's') ? "Sent" : "Received",
                                 i.message1,
                                 i.sent_time
                             }).OrderBy(d => d.sent_time);

                    if (!q.Any())
                    {
                        lblnoresults.Text = "No Messages found.";
                    }
                    else
                    {
                        gvmessage.DataSource = q;
                        gvmessage.DataBind();
                        mvchats.ActiveViewIndex = 1;
                        lblnoresults.Text = "";
                    }
                }
                catch(Exception ex) { }
            }
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            if (txtsearch.Text == String.Empty)
            {
                lblerror.Text = "No text entered.";
                return;
            }
            else
            {
                string id = Session["id"].ToString();
                using(DepartmentPortalDataContext db = new DepartmentPortalDataContext())
                {
                    try
                    {
                        var q = (from i in db.Faculties
                                where (i.faculty_id.Contains(txtsearch.Text) || i.faculty_name.Contains(txtsearch.Text))
                                select new
                                {
                                    i.faculty_id,
                                    i.faculty_name
                                }).OrderBy(d => d.faculty_id).OrderBy(d => d.faculty_name);

                        gvsearch.DataSource = q;
                        gvsearch.DataBind();
                        mvsearch.ActiveViewIndex = 1;
                    }
                    catch(Exception ex) { }
                }
            }
        }

        protected void gvsearch_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
                e.Row.Cells[0].Style.Add(HtmlTextWriterStyle.Display, "none");
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Style.Add(HtmlTextWriterStyle.Display, "none");
                e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.background='#eeeeee';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.background='#ffffff';";
                e.Row.Attributes["onclick"] = "__doPostBack('" + gvsearch.UniqueID + "','Select$" + e.Row.RowIndex + "');";

            }
        }
        
        protected void gvsearch_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[1].Text = "ID";
                e.Row.Cells[2].Text = "Name";
            }
        }

        protected void btnsend_Click(object sender, EventArgs e)
        {
            string id = Session["id"].ToString();
            if(txtmessage.Text == string.Empty) { return; }
            else
            {
                using(DepartmentPortalDataContext db = new DepartmentPortalDataContext())
                {
                    try
                    {
                        message m = new message()
                        {
                            student_id = Session["id"].ToString(),
                            faculty_id = fid,
                            message1 = txtmessage.Text,
                            sent_time = DateTime.Now,
                            type = 's'
                        };

                        db.messages.InsertOnSubmit(m);
                        db.SubmitChanges();

                        var q = (from i in db.messages
                                 where i.student_id == id && i.faculty_id == fid
                                 select new
                                 {
                                     a = (i.type == 's') ? "Sent" : "Received",
                                     i.message1,
                                     i.sent_time
                                 }).OrderBy(d => d.sent_time);

                        gvmessage.DataSource = q;
                        gvmessage.DataBind();
                    }
                    catch(Exception ex) { }
                }
            }
        }

        protected void gvmessage_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Visible = false;
                e.Row.Cells[1].Visible = false;
                e.Row.Cells[2].Visible = false;
            }
        }

        protected void btnback_Click(object sender, EventArgs e)
        {
            mvsearch.ActiveViewIndex = 0;
            mvchats.ActiveViewIndex = 0;
            string id = Session["id"].ToString();
            using (DepartmentPortalDataContext db = new DepartmentPortalDataContext())
            {
                try
                {
                    var q = (from i in db.messages
                             join j in db.Faculties on i.faculty_id equals j.faculty_id
                             where i.student_id == id
                             select new
                             {
                                 j.faculty_id,
                                 j.faculty_name,
                             }).Distinct();

                    gvchats.DataSource = q;
                    gvchats.DataBind();
                }
                catch (Exception ex) { }
            }
        }

        protected void gvsearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                fid = gvsearch.SelectedRow.Cells[1].Text;
            }
            catch (Exception ex) { }

            string id = Session["id"].ToString();

            using (DepartmentPortalDataContext db = new DepartmentPortalDataContext())
            {
                try
                {
                    var q = (from i in db.messages
                             where i.student_id == id && i.faculty_id == fid
                             select new
                             {
                                 a = (i.type == 's') ? "Sent" : "Received",
                                 i.message1,
                                 i.sent_time
                             }).OrderBy(d => d.sent_time);

                    if (!q.Any())
                    {
                        lblnoresults.Text = "No Messages found.";
                    }
                    else
                    {
                        gvmessage.DataSource = q;
                        gvmessage.DataBind();
                        mvchats.ActiveViewIndex = 1;
                        lblnoresults.Text = "";
                    }
                }
                catch (Exception ex) { }
            }
        }
    }
}