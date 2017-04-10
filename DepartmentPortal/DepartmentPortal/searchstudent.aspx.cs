using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DepartmentPortal
{
    public partial class searchstudent : System.Web.UI.Page
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
                using (DepartmentPortalDataContext db = new DepartmentPortalDataContext())
                {
                    try
                    {
                        if (!this.IsPostBack)
                        {
                            mvsearhbtn.ActiveViewIndex = 0;
                            mvresults.ActiveViewIndex = 0;

                            btnsearch.Enabled = false;

                            branch = (from i in db.Faculties
                                      where i.faculty_id == Session["id"].ToString()
                                      select i.branch).Single();

                            if (Session["type"].ToString() == "a")
                            {
                                txtsaddress.ReadOnly = false;
                                txtsbatch.ReadOnly = false;
                                txtsbdate.ReadOnly = false;
                                txtsbranch.ReadOnly = false;
                                txtscontact.ReadOnly = false;
                                txtsfullname.ReadOnly = false;
                                txtsemail.ReadOnly = false;
                                txtsyoc.ReadOnly = false;
                                txtsseat.ReadOnly = false;
                                mvsavedetails.ActiveViewIndex = 1;
                            }
                            else
                            {
                                txtsaddress.ReadOnly = true;
                                txtsbatch.ReadOnly = true;
                                txtsbdate.ReadOnly = true;
                                txtsbranch.ReadOnly = true;
                                txtscontact.ReadOnly = true;
                                txtsfullname.ReadOnly = true;
                                txtsemail.ReadOnly = true;
                                txtsyoc.ReadOnly = true;
                                txtsseat.ReadOnly = true;
                                mvsavedetails.ActiveViewIndex = 0;
                            }

                            
                               

                        }
                    }catch(Exception ex) { }


                 }
            }
        }

        static string stid;
        protected void loadresults()
        {
            using(DepartmentPortalDataContext db = new DepartmentPortalDataContext())
            {
                try
                {
                    var q = (from i in db.Students
                             where i.student_id == stid
                             select i).SingleOrDefault();

                    txtsstid.Text = q.student_id.ToString();
                    txtsyoc.Text = q.yoc.ToString();
                    txtsfullname.Text = q.full_name.ToString();
                    txtsemail.Text = q.email_id.ToString();
                    txtscontact.Text = q.contact_no.ToString();
                    txtsbranch.Text = q.branch.ToString();
                    txtsbdate.Text = q.birthdate.ToString().Remove(10);
                    txtsbatch.Text = q.batch.ToString();
                    txtsaddress.Text = q.address.ToString();
                    txtsseat.Text = q.seat.ToString();


                    mvres.ActiveViewIndex = 0;
                    List<string> type = new List<string>()
                            {
                                "Internal","External"
                            };

                    ddltype.DataSource = type;
                    ddltype.DataBind();


                    var q1 = from i in db.Semesters
                            where i.student_id == stid
                            select i.sem;

                    ddlsem.DataSource = q1;
                    ddlsem.DataBind();


                }
                catch (Exception ex) { }
            }
        }

        protected void btnsearchbyname_Click(object sender, EventArgs e)
        {
            mvsearhbtn.ActiveViewIndex = 1;
        }

        protected void btnseachbysem_Click(object sender, EventArgs e)
        {
            mvsearhbtn.ActiveViewIndex = 2;
        }

        protected void btnnamesearch_Click(object sender, EventArgs e)
        {
            using(DepartmentPortalDataContext db = new DepartmentPortalDataContext())
            {
                try
                {
                    var q = (from i in db.Students
                             join j in db.Semesters on i.student_id equals j.student_id
                             where i.branch == branch && i.current_sem == j.sem && i.full_name.Contains(txtname.Text)
                             select new
                             {
                                 i.student_id,
                                 i.full_name,
                                 j.division,
                                 j.batch
                             }).ToList();

                    gvsearch.DataSource = q;
                    gvsearch.DataBind();
                    mvresults.ActiveViewIndex = 1;
                }
                catch(Exception ex) { }
            }
        }

        static int sem;
        static string branch;
        protected void txtsem_TextChanged(object sender, EventArgs e)
        {
            using (DepartmentPortalDataContext db = new DepartmentPortalDataContext())
            {
                try
                {
                    sem = Convert.ToInt32(txtsem.Text);

                    var q = (from i in db.Students
                             join j in db.Semesters on i.student_id equals j.student_id
                             where i.branch == branch && i.current_sem == j.sem && j.sem == sem
                             select j.division).ToList();


                    q.Insert(0, "--select--");

                    ddlclass.DataSource = q;
                    ddlclass.DataBind();

                    q.Clear();
                    q.Insert(0, "--select--");

                    ddlbatch.DataSource = q;
                    ddlbatch.DataBind();

                    btnsearch.Enabled = true;
                }
                catch (Exception ex) { }
            }
        }

        static string cs,batch;
        protected void ddlclass_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (DepartmentPortalDataContext db = new DepartmentPortalDataContext())
            {
                try
                {
                    cs = ddlclass.SelectedItem.Text;


                    var q = (from i in db.Students
                             join j in db.Semesters on i.student_id equals j.student_id
                             where i.branch == branch && i.current_sem == j.sem && j.sem == sem && j.division == cs
                             select j.batch).ToList();

                    q.Insert(0, "--select--");

                    ddlbatch.DataSource = q;
                    ddlbatch.DataBind();


                }
                catch (Exception ex) { }
            }
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            if (txtsem.Text == string.Empty)
            {
                lblsearcherror.Text = "Semester detail is compulsory.";
                return;
            }
            using (DepartmentPortalDataContext db = new DepartmentPortalDataContext())
            {
                try
                {
                    sem = Convert.ToInt32(txtsem.Text);
                    cs = (ddlclass.SelectedItem.Text == "--select--") ? "" : ddlclass.SelectedItem.Text;
                    batch = (ddlbatch.SelectedItem.Text == "--select--") ? "" : ddlbatch.SelectedItem.Text;


                    var q = (from i in db.Students
                             join j in db.Semesters on i.student_id equals j.student_id
                             where i.current_sem == j.sem && i.current_sem == sem && i.branch == branch
                             select new
                             {
                                 i.student_id,
                                 i.full_name,
                                 j.division,
                                 j.batch
                             }).ToList();

                    if (cs != string.Empty)
                    {
                        foreach (var i in q)
                        {
                            if (i.division == cs)
                            {
                                if (batch != string.Empty)
                                {
                                    if (i.batch != batch)
                                    {
                                        q.Remove(i);
                                    }
                                }
                            }
                            else
                            {
                                q.Remove(i);
                            }

                        }
                    }

                    gvsearch.DataSource = q;
                    gvsearch.DataBind();
                    mvresults.ActiveViewIndex = 1;
                }
                catch (Exception ex) { }
            }
        }

        protected void gvsearch_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[1].Text = "Student ID";
                e.Row.Cells[2].Text = "Full Name";
                e.Row.Cells[3].Text = "Division";
                e.Row.Cells[4].Text = "Batch";
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

        protected void btnsavedetails_Click(object sender, EventArgs e)
        {
            using(DepartmentPortalDataContext db = new DepartmentPortalDataContext())
            {
                try
                {
                    var q = (from i in db.Students
                             where i.student_id == stid
                             select i).SingleOrDefault();

                    q.full_name = txtsfullname.Text;
                    q.branch = txtsbranch.Text;
                    q.batch = Convert.ToDecimal(txtsbatch.Text);
                    q.seat = txtsseat.Text;
                    q.yoc = Convert.ToDecimal(txtsyoc.Text);
                    q.birthdate = Convert.ToDateTime(txtsbdate.Text);
                    q.email_id = txtsemail.Text;
                    q.contact_no = Convert.ToDecimal(txtscontact.Text);
                    q.address = txtsaddress.Text;

                    db.SubmitChanges();
                    lblsavedetailserror.Text = "Details successfully updated.";

                }
                catch(Exception ex) { }
            }
        }

        protected void btnsearchexam_Click(object sender, EventArgs e)
        {
            int sem = Convert.ToInt32(ddlsem.SelectedValue);
            int type = ddltype.SelectedItem.Text == "Internal" ? 0 : 1;
            

            using (DepartmentPortalDataContext db = new DepartmentPortalDataContext())
            {
                try
                {
                    int sid = Convert.ToInt32((from i in db.Semesters
                                               where i.student_id == stid && i.sem == sem
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
                                    j.bmarks,
                                    j.rmarks
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
                catch (Exception ex) { }
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
                e.Row.Cells[6].Text = "Remedial Marks";
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

        protected void gvsearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            stid = gvsearch.SelectedRow.Cells[1].Text;
            mvsearhbtn.ActiveViewIndex = 3;
            mvresults.ActiveViewIndex = 2;
            loadresults();
        }
    }
}