using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DepartmentPortal
{
    public partial class studenthome : System.Web.UI.Page
    {
        int sem;
        string branch, id;
        string cs;
        string[] head;
        string batch;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null || Session["id"] == null || Session["sem"] == null || Session["branch"] == null  )
            {
                Session.RemoveAll();
                Response.Redirect("expired.aspx");
            }
            else
            {
                lblday.Text = DateTime.Now.DayOfWeek.ToString() + ", " + DateTime.Now.Date.ToString().Substring(0,9);
                Timer1.Enabled = true;
                //Timer1.Interval = 60000;

                sem = Convert.ToInt32(Session["sem"]);
                branch = Session["branch"].ToString();
                id = Session["id"].ToString();

                try
                {
                    using (DepartmentPortalDataContext db = new DepartmentPortalDataContext())
                    {
                        cs = (from i in db.Semesters
                              where i.student_id == id && i.sem == sem
                              select i.division).Single().ToString();
                                            

                        batch = (from i in db.Semesters
                                 where i.student_id == id && i.sem == sem
                                 select i.batch).Single().ToString();

                        var q = (from i in db.DailyTTs
                                 where i.sem == sem && i.branch == branch && i.division == cs
                                 select new
                                 {
                                     a = i.s1_dur,
                                     b = i.s2_dur,
                                     c = i.s3_dur,
                                     d = i.s4_dur,
                                     e = i.s5_dur,
                                     f = i.s6_dur,
                                     g = i.s7_dur

                                 }).Single();

                        head = new String[7];

                        head[0] = q.a;
                        head[1] = q.b;
                        head[2] = q.c;
                        head[3] = q.d;
                        head[4] = q.e;
                        head[5] = q.f;
                        head[6] = q.g;

                        int ttid = 0;
                        int lab = 0;

                        var q1 = (from i in db.DailyTTs
                                 where i.sem == sem && i.branch == branch && i.division == cs
                                 select i).Single();

                        if (q1.s1_type.Contains("b")) { lab = 1; }
                        else if (q1.s2_type.Contains("b")) { lab = 2; }
                        else if (q1.s3_type.Contains("b")) { lab = 3; }
                        else if (q1.s4_type.Contains("b")) { lab = 4; }
                        else if (q1.s5_type.Contains("b")) { lab = 5; }
                        else if (q1.s6_type.Contains("b")) { lab = 6; }
                        else if (q1.s7_type.Contains("b")) { lab = 7; }
                        else { lab = 0; }
                        ttid = q1.tt_Id;

                        var q2 = from i in db.lab_tts
                                 join j in db.lecTTs on i.tt_id equals j.tt_id
                                 where i.tt_id == ttid && i.b1 == batch && i.day==j.day
                                 select new
                                 {
                                     i.day,
                                     a = (lab == 1) ? i.s1 + "\n" + i.f1 : j.s1 + "\n" + j.f1,
                                     b = (lab == 2) ? i.s1 + "\n" + i.f1 : j.s2 + "\n" + j.f2,
                                     c = (lab == 3) ? i.s1 + "\n" + i.f1 : j.s3 + "\n" + j.f3,
                                     d = (lab == 4) ? i.s1 + "\n" + i.f1 : j.s4 + "\n" + j.f4,
                                     e = (lab == 5) ? i.s1 + "\n" + i.f1 : j.s5 + "\n" + j.f5,
                                     f = (lab == 6) ? i.s1 + "\n" + i.f1 : j.s6 + "\n" + j.f6,
                                     g = (lab == 7) ? i.s1 + "\n" + i.f1 : j.s7 + "\n" + j.f7,
                                 };

                        gvtimetable.DataSource = q2;
                        gvtimetable.DataBind();
                    }
                }
                catch(Exception ex) { }


            }
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            lbltimer.Text = DateTime.Now.ToString("hh:mm");
        }

        
        protected void gvtimetable_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = "Time";
                
                for (int i = 0; i < 7; i++)
                {
                    if (head[i] == String.Empty)
                    {
                        e.Row.Cells[i + 1].Visible = false;
                    }
                    else
                    {
                        e.Row.Cells[i + 1].Text = head[i];
                    }
                    
                }
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i < 7; i++)
                {
                    if (head[i] != String.Empty)
                    {
                        e.Row.Cells[i + 1].Text = e.Row.Cells[i + 1].Text.Replace("\n", "<br />");
                    }
                    else
                    {
                        e.Row.Cells[i + 1].Visible = false;
                    }
                }
            }
        }
        
    }
}