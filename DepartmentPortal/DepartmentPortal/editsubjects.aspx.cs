using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DepartmentPortal
{
    public partial class editsubjects : System.Web.UI.Page
    {
        string branch;
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
                        branch = (from i in db.Faculties
                                 where i.faculty_id == Session["id"].ToString()
                                 select i.branch).Single();

                        var q = from i in db.subjects
                                where i.course == branch
                                select new
                                {
                                    i.subject_id,
                                    i.allotted_sem,
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

        protected void btnadd_Click(object sender, EventArgs e)
        {
            using (DepartmentPortalDataContext db = new DepartmentPortalDataContext())
            {
                try
                {
                    var q = from i in db.subjects
                            where i.subject_name == txtname.Text && i.course == branch
                            select i;

                    if (q.Any())
                    {
                        lbladderror.Text = "Subject already exists.";
                        return;
                    }

                    subject s = new subject()
                    {
                        subject_name = txtnewname.Text,
                        subject_description = txtnewdesc.Text,
                        subject_credit = Convert.ToDecimal(txtnewcredit.Text),
                        allotted_sem = Convert.ToInt32(txtnewsem.Text),
                        course = branch
                    };

                    
                    db.subjects.InsertOnSubmit(s);
                    db.SubmitChanges();
                    lbladderror.Text = "Subject Added Successfully.";
                    Page_Load(sender, e);
                }
                catch (Exception ex) { }
            }
        }

        protected void btnedit_Click(object sender, EventArgs e)
        {
            using (DepartmentPortalDataContext db = new DepartmentPortalDataContext())
            {
                try
                {
                    var q = (from i in db.subjects
                             where i.course == branch
                             select i).Single();

                    q.subject_name = txtname.Text;
                    q.subject_description = txtdesc.Text;
                    q.subject_credit = Convert.ToDecimal(txtcredit.Text);
                    q.allotted_sem = Convert.ToInt32(txtsem.Text);

                    db.SubmitChanges();
                    lblediterror.Text = "Subject Modification Successful.";
                    Page_Load(sender, e);
                }
                catch (Exception ex)
                {
                    lblediterror.Text = "Subject Modification Unsuccessful";
                }
            }
        }

        protected void btnremove_Click(object sender, EventArgs e)
        {
            using (DepartmentPortalDataContext db = new DepartmentPortalDataContext())
            {
                try
                {

                    var a = from i in db.subjects
                             where i.subject_id==Convert.ToInt32(txtid.Text)
                             select i;

                    if (!a.Any())
                    {
                        lblediterror.Text = "Subject doesn't exist.";
                        return;
                    }

                    var q = (from i in db.subjects
                             where i.subject_id == Convert.ToInt32(txtid.Text)
                             select i).Single();

                    db.subjects.DeleteOnSubmit(q);
                    db.SubmitChanges();
                    lblediterror.Text = "Subject Removed Successfully.";
                    Page_Load(sender, e);
                }
                catch (Exception ex)
                {
                    lblediterror.Text = "Subject Removal Unsuccessful";
                }
            }
        }

        protected void gvsubjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (DepartmentPortalDataContext db = new DepartmentPortalDataContext())
            {
                try
                {
                    mvedit.ActiveViewIndex = 1;
                    txtid.Text = gvsubjects.SelectedRow.Cells[1].Text;
                    txtname.Text = gvsubjects.SelectedRow.Cells[3].Text;
                    txtsem.Text = gvsubjects.SelectedRow.Cells[2].Text;
                    txtdesc.Text = gvsubjects.SelectedRow.Cells[4].Text;
                    txtcredit.Text = gvsubjects.SelectedRow.Cells[5].Text;
                }
                catch (Exception ex) { }
            }
        }

        protected void gvsubjects_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
                e.Row.Cells[0].Style.Add(HtmlTextWriterStyle.Display, "none");
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Style.Add(HtmlTextWriterStyle.Display, "none");
                e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.background='#eeeeee';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.background='#ffffff';";
                e.Row.Attributes["onclick"] = "__doPostBack('" + gvsubjects.UniqueID + "','Select$" + e.Row.RowIndex + "');";

            }
        }

        protected void gvsubjects_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[1].Text = "Subject ID";
                e.Row.Cells[2].Text = "Alloted Semester";
                e.Row.Cells[3].Text = "Subject Name";
                e.Row.Cells[4].Text = "Subject Description";
                e.Row.Cells[5].Text = "Subject Credit";
            }
        }
    }
}