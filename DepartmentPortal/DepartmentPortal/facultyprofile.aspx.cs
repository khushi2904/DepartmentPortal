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
                            txtbdate.Text = q.birthdate.ToString().Remove(11);
                            txtbranch.Text = q.branch.ToString();
                            txtcontact.Text = q.contact_no.ToString();
                            txtdesignation.Text = q.Designation.ToString();
                            txtemail.Text = q.email_id.ToString();
                            txtfullname.Text = q.faculty_name.ToString();
                            txtid.Text = q.faculty_id.ToString();
                            txtadd.Text = q.address.ToString();
                        }

                        if (Session["type"].ToString() == "f")
                        {
                            mvbutton.ActiveViewIndex = 0;
                            mvsearch.ActiveViewIndex = 0;
                        }
                        else if (Session["type"].ToString() == "a")
                        {
                            mvbutton.ActiveViewIndex = 1;
                            mvsearch.ActiveViewIndex = 1;

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
    }
}