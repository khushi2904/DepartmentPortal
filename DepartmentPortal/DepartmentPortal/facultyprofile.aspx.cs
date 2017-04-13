using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DepartmentPortal
{
    public partial class facultyprofile : System.Web.UI.Page
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
                using(DepartmentPortalDataContext db = new DepartmentPortalDataContext())
                {
                    try
                    {
                        if (!this.IsPostBack)
                        {
                            var q = (from i in db.Faculties
                                     where i.faculty_id == Session["id"].ToString()
                                     select i).Single();
                            txtbdate.Text = q.birthdate.ToString().Remove(10);
                            txtbranch.Text = q.branch.ToString();
                            txtcontact.Text = q.contact_no.ToString();
                            txtdesignation.Text = q.Designation.ToString();
                            txtemail.Text = q.email_id.ToString();
                            txtfullname.Text = q.faculty_name.ToString();
                            txtid.Text = q.faculty_id.ToString();
                            txtadd.Text = q.address.ToString();


                            var la = from i in db.m_lastaccesseds
                                     where i.student_id == Session["id"].ToString()
                                     select i;

                            if (!la.Any())
                            {
                                m_lastaccessed mla = new m_lastaccessed()
                                {
                                    student_id = Session["id"].ToString(),
                                    lastaccesssed = DateTime.Now
                                };
                                db.m_lastaccesseds.InsertOnSubmit(mla);
                                db.SubmitChanges();
                            }

                            var la1 = la.Single();
                            DateTime lat = Convert.ToDateTime(la1.lastaccesssed);

                            Session["messagecount"] = (from i in db.messages
                                           where lat.CompareTo(i.sent_time) < 0
                                           select i).Count();



                        }

                        if (Session["type"].ToString() == "f")
                        {
                            mvbutton.ActiveViewIndex = 0;
                            mvsearch.ActiveViewIndex = 0;
                            mvaddnew.ActiveViewIndex = 0;
                        }
                        else if (Session["type"].ToString() == "a")
                        {
                            mvbutton.ActiveViewIndex = 1;
                            mvsearch.ActiveViewIndex = 1;
                            mvaddnew.ActiveViewIndex = 1;

                            txtbdate.ReadOnly = false;
                            txtbranch.ReadOnly = false;
                            txtcontact.ReadOnly = false;
                            txtdesignation.ReadOnly = false;
                            txtemail.ReadOnly = false;
                            txtfullname.ReadOnly = false;
                            txtadd.ReadOnly = false;
                        }
                    }
                    catch(Exception ex) { }
                }                
            }
        }

        protected void btnchange_Click(object sender, EventArgs e)
        {
            using(DepartmentPortalDataContext db = new DepartmentPortalDataContext())
            {
                try
                {
                    var q = (from i in db.Faculties
                             where i.faculty_id == txtid.Text
                             select i).Single();

                    q.faculty_name = txtfullname.Text;
                    q.branch = txtbranch.Text;
                    q.Designation = txtdesignation.Text;
                    q.birthdate = Convert.ToDateTime(txtbdate.Text);
                    q.email_id = txtemail.Text;
                    q.contact_no = Convert.ToDecimal(txtcontact.Text);
                    q.address = txtadd.Text;

                    db.SubmitChanges();

                    lblchangeerror.Text = "Changes have been made successfully";
                }
                catch(Exception ex)
                {
                    lblchangeerror.Text = "Changes could not be made. Please try again later."; 
                }
            }
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            if (txtsearch.Text == "")
            {
                lblsearcherror.Text = "Search field empty.";
                return;
            }
            using(DepartmentPortalDataContext db = new DepartmentPortalDataContext())
            {
                try
                {
                    var q = (from i in db.Faculties
                             where i.faculty_name.Equals(txtsearch.Text) || i.faculty_id.Equals(txtid.Text)
                             select i).First();
                    txtid.Text = q.faculty_id.ToString();
                    txtfullname.Text = q.faculty_name.ToString();
                    txtemail.Text = q.email_id.ToString();
                    txtdesignation.Text = q.Designation.ToString();
                    txtcontact.Text = q.contact_no.ToString();
                    txtbranch.Text = q.branch.ToString();
                    txtbdate.Text = q.birthdate.ToString();
                    txtadd.Text = q.address.ToString();
                   
                }
                catch(Exception ex) { }
            }
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            using(DepartmentPortalDataContext db = new DepartmentPortalDataContext())
            {
                try
                {
                    var id = (from i in db.Students
                              select i.Id).ToList().LastOrDefault();
                    id++;
                    string stid = txtsnewbatch.Text.Substring(2) + txtsnewbranch.Text + "U" + txtsnewseat.Text + "0" + id;
                    decimal yoc1 = Convert.ToDecimal(txtsnewbatch.Text) + 4;
                    Student s = new Student()
                    {
                        student_id = stid,
                        password = txtsnewfname.Text,
                        full_name = txtsnewfname.Text,
                        branch = txtsnewbranch.Text,
                        batch = Convert.ToDecimal(txtsnewbatch.Text),
                        seat = txtsnewseat.Text,
                        current_sem = 1,
                        yoc = yoc1,
                        birthdate = Convert.ToDateTime(txtsnewbdate.Text),
                        email_id = txtsnewemail.Text,
                        contact_no = Convert.ToDecimal(txtsnewcontact.Text),
                        address = txtsnewaddress.Text,
                    };

                    db.Students.InsertOnSubmit(s);
                    db.SubmitChanges();

                    lbladderror.Text = "Student has been added. ID = " + stid;
                    
                }
                catch(Exception ex)
                {
                    lbladderror.Text = "Could not add student. please try again later";
                }
            }
        }

        protected void btnfadd_Click(object sender, EventArgs e)
        {
            using(DepartmentPortalDataContext db = new DepartmentPortalDataContext())
            {
                try
                {
                    var id = (from i in db.Faculties
                              select i.id).ToList().LastOrDefault();
                    id++;
                    string ftid = txtfbranch.Text + id;

                    Faculty f = new Faculty()
                    {
                        faculty_id = ftid,
                        password = txtfnewname.Text,
                        faculty_name = txtfnewname.Text,
                        user_type = Convert.ToChar(txtfnewtype.Text),
                        branch = txtfbranch.Text,
                        Designation = txtfnewdesig.Text,
                        birthdate = Convert.ToDateTime(txtfnewbdate.Text),
                        email_id = txtfnewemail.Text,
                        contact_no = Convert.ToDecimal(txtfnewcontact.Text),
                        address = txtfnewadd.Text,
                    };

                    db.Faculties.InsertOnSubmit(f);
                    db.SubmitChanges();

                    lblfadderror.Text = "Faculty has been added. ID = " + ftid;

                }
                catch(Exception ex)
                {
                    lblfadderror.Text = "Could not add faculty. Please try again later";
                }
            }
        }
    }
}