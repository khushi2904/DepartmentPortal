using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DepartmentPortal
{
    public partial class facultynotifications : System.Web.UI.Page
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
                using(DepartmentPortalDataContext db = new DepartmentPortalDataContext())
                {
                    try
                    {
                        branch = (from i in db.Faculties
                                  where i.faculty_id == Session["id"].ToString()
                                  select i.branch).SingleOrDefault();
                    }
                    catch(Exception ex) { }
                }
            }
        }
        

        protected void btnsend_Click(object sender, EventArgs e)
        {
            if(txtsem.Text==string.Empty || txtmessage.Text == string.Empty)
            {
                lblsenderror.Text = "All details are mandatory.";
                return;
            }
            else
            {
                using (DepartmentPortalDataContext db = new DepartmentPortalDataContext())
                {
                    try
                    {
                        notification n = new notification()
                        {
                            sem = Convert.ToInt32(txtsem.Text),
                            notifdate = DateTime.Now,
                            notif = txtmessage.Text
                        };
                        db.notifications.InsertOnSubmit(n);
                        db.SubmitChanges();
                        lblsenderror.Text = "Notification has been sent";
                    }
                    catch (Exception ex) { }
                }
            }
        }
    }
}