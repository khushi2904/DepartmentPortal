using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BotDetect.Web.UI;


namespace DepartmentPortal
{
    public partial class Default : System.Web.UI.Page
    {
        static bool idflag = false;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!this.IsPostBack)
            {
                idflag = false;
                lblerror.Text = "";
            }
        }


        protected void btnlogin_Click(object sender, EventArgs e)
        {
            if (txtid.Text == "" || txtpass.Text == "")
            {
                lblerror.Text = "All details are mandatory.";
                return;
            }
            else
            {
                ExampleCaptcha.UserInputID = CaptchaCodeTextBox.ClientID;
                if (IsPostBack)
                {
                    bool isHuman = ExampleCaptcha.Validate(CaptchaCodeTextBox.Text);
                    CaptchaCodeTextBox.Text = null;
                    if (!isHuman)
                    {
                        lblerror.Text = "Incorrect Captcha.";
                    }
                    else
                    {
                        try
                        {
                            using (DepartmentPortalDataContext db = new DepartmentPortalDataContext())
                            {
                                if (!idflag)
                                {
                                    var q = from i in db.Students
                                            where i.student_id == txtid.Text && i.password == txtpass.Text
                                            select i;

                                    if (q.Any())
                                    {
                                        foreach (var i in q)
                                        {
                                            Session["id"] = i.student_id;
                                            Session["username"] = i.full_name;
                                            Session["sem"] = i.current_sem;
                                            Session["branch"] = i.branch;

                                            DateTime today = DateTime.Now;
                                            today = today.AddDays(-1);
                                            
                                            var ev = from j in db.Events
                                                     where today.CompareTo(j.date)<0
                                                     select j;

                                            var notifs = (from j in db.notifications
                                                          where today.CompareTo(j.notifdate) < 0
                                                          select j.notif).ToList();

                                            foreach(var k in ev)
                                            {
                                                string msg = "Tomorrow is " + k.name;
                                                if (!notifs.Contains(msg))
                                                {
                                                    notification n = new notification()
                                                    {
                                                        notifdate = DateTime.Now,
                                                        notif = msg
                                                    };
                                                    db.notifications.InsertOnSubmit(n);
                                                    db.SubmitChanges();
                                                }
                                            }


                                            Response.Redirect("studenthome.aspx");
                                        }
                                    }
                                    else
                                    {
                                        lblerror.Text = "Incorrect Credentials. Please try again.";
                                    }

                                }
                                else
                                {
                                    var q = from i in db.Faculties
                                            where i.faculty_id == txtid.Text && i.password == txtpass.Text
                                            select i;

                                    if (q.Any())
                                    {
                                        foreach (var i in q)
                                        {
                                            Session["id"] = i.faculty_id;
                                            Session["username"] = i.faculty_name;
                                            Session["type"] = i.user_type;

                                            Response.Redirect("facultyprofile.aspx");
                                        }
                                    }
                                    else
                                    {
                                        lblerror.Text = "Incorrect Credentials. Please try again.";
                                    }
                                }
                            }
                            
                        }
                        catch (Exception ex)
                        {
                            lblerror.Text = "Exception";
                        }
                        
                    }
                }
            }
        }

        protected void btnlinkfac_Click(object sender, EventArgs e)
        {
            idflag = true;
        }

        protected void lbtnforgotpassword_Click(object sender, EventArgs e)
        {
            
                Response.Redirect("forgotpassword.aspx?id="+txtid.Text+"&idflag="+idflag);
           
        }
    }
}