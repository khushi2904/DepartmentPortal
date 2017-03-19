using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DepartmentPortal
{
    public partial class profile : System.Web.UI.Page
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
                    string id = Session["id"].ToString();
                    using (DepartmentPortalDataContext db = new DepartmentPortalDataContext())
                    {
                        var q = (from i in db.Students
                                 where i.student_id == id
                                 select i).Single();

                        lblname.Text = q.full_name.ToString();
                        lblid.Text = id;
                        lblbranch.Text = q.branch.ToString();
                        lblbatch.Text = q.batch.ToString();
                        lblsem.Text = q.current_sem.ToString();
                        lblseat.Text = q.seat.ToString();
                        lblyoc.Text = (q.yoc.ToString()=="") ? "-------" : q.yoc.ToString();
                        lblbdate.Text = q.birthdate.ToString().Remove(11);
                        lblcontact.Text = q.contact_no.ToString();
                        lbladdr.Text = q.add1.ToString() + ", " + q.add2.ToString() + ", " + q.city.ToString() + " - " + q.pincode + ", " + q.state + ", " + q.country + ".";
                        lblemail.Text = q.email_id.ToString();
                    }
                }
                catch (Exception ex) { }
            }
        }
    }
}