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
                sem = Convert.ToInt32(Session["sem"]);
                branch = Session["branch"].ToString();
                id = Session["id"].ToString();

                try
                {
                    using (DepartmentPortalDataContext db = new DepartmentPortalDataContext())
                    {


                        if (!this.IsPostBack)
                        {
                            lbtnskip.Visible = false;
                            lblskippederror.Text = "";

                            var lat = from i in db.n_lastaccesseds
                                      where i.student_id == id
                                      select i.lastaccessed;

                            var mlat = from i in db.m_lastaccesseds
                                       where i.student_id == id
                                       select i.lastaccesssed;

                            if (!mlat.Any())
                            {
                                m_lastaccessed m = new m_lastaccessed()
                                {
                                    student_id = id,
                                    lastaccesssed = DateTime.Now
                                };
                                db.m_lastaccesseds.InsertOnSubmit(m);
                                db.SubmitChanges();
                            }


                            if (!lat.Any())
                            {
                                n_lastaccessed n = new n_lastaccessed()
                                {
                                    student_id = id,
                                    lastaccessed = DateTime.Now
                                };
                                db.n_lastaccesseds.InsertOnSubmit(n);
                                db.SubmitChanges();
                            }

                            DateTime la = Convert.ToDateTime(lat.Single());
                            DateTime ma = Convert.ToDateTime(mlat.Single());

                            Session["messagecount"] = (from i in db.messages
                                                       where i.student_id == id && ma.CompareTo(i.sent_time) < 0
                                                       select i).Count();

                            Session["notifcount"] = (from i in db.notifications
                                                     where i.sem == sem && Convert.ToDateTime(i.notifdate).CompareTo(la) > 0
                                                     select i).Count();
                        }
               

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

                        TimeSpan[] timeslot = new TimeSpan[7];
                        int z=0;
                        for(int i = 0; i < timeslot.Length; i++)
                        {
                            if (head[i] != "")
                            {
                                string s = head[i].Substring(0, head[i].IndexOf('-'));
                                timeslot[i] = TimeSpan.Parse(s);
                                z = i;
                            }
                        }
                        TimeSpan endtime = TimeSpan.Parse(head[z].Substring(head[z].IndexOf('-')+1));
                        //TimeSpan now = TimeSpan.Parse("8:30");
                        TimeSpan now = TimeSpan.Parse(DateTime.Now.TimeOfDay.ToString());
                        
                        var c = (from j in db.DailyTTs
                                 where j.tt_Id == ttid
                                 select j).Single();

                        string[] t = { c.s1_type, c.s2_type, c.s3_type, c.s4_type, c.s5_type, c.s6_type, c.s7_type };

                        var d = (from k in db.lecTTs
                                 where k.tt_id == ttid && k.day == DateTime.Now.DayOfWeek.ToString()
                                 select k).Single();


                        string[] a = {
                                            d.s1+", "+d.f1,
                                            d.s2+", "+d.f2,
                                            d.s3+", "+d.f3,
                                            d.s4+", "+d.f4,
                                            d.s5+", "+d.f5,
                                            d.s6+", "+d.f6,
                                            d.s7+", "+d.f7
                                      };

                        var f = from k in db.lab_tts
                                where k.tt_id == ttid && k.b1==batch && k.day == DateTime.Now.DayOfWeek.ToString()
                                select new { a = k.s1 + ", " + k.f1 };

                        if (timeslot[0].CompareTo(now) > 0)
                        {
                            lblcurlec.Text = "-------------";
                        }
                        else if (timeslot[z].CompareTo(now) < 0 && now.CompareTo(endtime) < 0)
                        {
                            if (t[z].Contains("l"))
                                lblcurlec.Text = a[z];
                            else
                                lblcurlec.Text = f.Single().ToString();
                            lbtnskip.Visible = true;
                        }
                        else if (now.CompareTo(endtime) > 0)
                        {
                            lblcurlec.Text = "-------------";
                        }
                        else
                        {
                            for (int i = 0; i < 6; i++)
                            {
                                if(timeslot[i].CompareTo(now)<=0 && timeslot[i + 1].CompareTo(now) > 0)
                                {
                                    string pos = t[i];

                                    if (pos.Contains("l"))
                                    {
                                       lblcurlec.Text = a[i];                                               
                                    }
                                    else
                                    {
                                        lblcurlec.Text = f.Single().ToString().Remove(0, 5).Replace('}', ' ');
                                    }
                                    lbtnskip.Visible = true;
                                }
                            }
                        }

                        var semid = (from i in db.Semesters
                                     where i.student_id == Session["id"].ToString() && i.sem == sem
                                     select i.sem_id).ToList().Last();

                        var eta = (from i in db.sessions
                                   where i.sem_id == semid
                                   select i).SingleOrDefault();

                        double attendance = Convert.ToDouble(eta.est_attendance) / 3;


                        int nl = (from i in db.skippeds
                                  where i.student_id == id && i.sem == sem && i.skipdate == DateTime.Now.Date
                                  select i).Count();
                        
                        lblestattendance.Text = "Est. Attendance : " + attendance + "%";
                        lblskipped.Text = "You have skipped " + nl+ " sessions today.";

                        var skips = (from i in db.skippeds
                                     where i.student_id == id && i.sem == sem
                                     select new
                                     {
                                         i.skipped1,
                                         d = i.skipdate.ToString().Remove(10)
                                     }).OrderByDescending(j=>j.d);

                        gvskipedsessions.DataSource = skips;
                        gvskipedsessions.DataBind();

                    }
                }
                catch(Exception ex)
                {
                    lblcurlec.Text = "-------------";
                }
            }
        }

       
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            try
            {
                using (DepartmentPortalDataContext db = new DepartmentPortalDataContext())
                {
                    var q = from i in db.skippeds
                            where i.student_id == id && i.sem == sem && i.skipdate == DateTime.Now.Date && i.skipped1 == lblcurlec.Text
                            select i;

                    if (q.Any()) {
                        lblskippederror.Text = "You have already skipped this session.";
                    }
                    else
                    {
                        skipped s = new skipped
                        {
                            student_id = id,
                            sem = sem,
                            skipdate = DateTime.Now.Date,
                            skipped1 = lblcurlec.Text,
                        };
                        db.skippeds.InsertOnSubmit(s);
                        db.SubmitChanges();

                        var semid = (from i in db.Semesters
                                     where i.student_id == Session["id"].ToString() && i.sem == sem
                                     select i.sem_id).ToList().Last();


                        var eta = (from i in db.sessions
                                   where i.sem_id == semid
                                   select i).SingleOrDefault();

                        eta.est_attendance = eta.est_attendance - 1;
                        db.SubmitChanges();
                        double attendance = Convert.ToDouble(eta.est_attendance) / 3;



                        int nl = (from i in db.skippeds
                                  where i.student_id == id && i.sem == sem && i.skipdate == DateTime.Now.Date
                                  select i).Count();
                        
                        lblskipped.Text = "You have skipped " + nl + " sessions today.";
                        lblestattendance.Text = "Est. Attendance : " + attendance + "%";

                    }
                }
            }
            catch (Exception ex) { }
        }

        protected void gvskipedsessions_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = "Session";
                e.Row.Cells[1].Text = "Date";
            }
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