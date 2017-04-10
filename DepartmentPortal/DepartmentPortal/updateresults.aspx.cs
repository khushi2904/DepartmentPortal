using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DepartmentPortal
{
    public partial class updateresults : System.Web.UI.Page
    {
        static string branch;
        static int semid, sessid, count;
        static string[] subname;
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
                            mvresults.ActiveViewIndex = 0;
                            mvsearhbtn.ActiveViewIndex = 0;
                            mvextrasubinternal.ActiveViewIndex = 0;
                            mvexternalsubject.ActiveViewIndex = 0;
                            mvnewsem.ActiveViewIndex = 0;
                            mvadvancesemester.ActiveViewIndex = 0;

                            btnsearch.Enabled = false;

                            branch = (from i in db.Faculties
                                      where i.faculty_id == Session["id"].ToString()
                                      select i.branch).Single();
                            
                        }
                        
                    }
                    catch(Exception ex)
                    {

                    }
                }
            }
        }

        protected void loadresults()
        {
            using(DepartmentPortalDataContext db = new DepartmentPortalDataContext())
            {
                try
                {
                    if (mvresults.ActiveViewIndex == 2)
                    {


                        semid = (from i in db.Semesters
                                 where i.student_id == stid && i.sem == sem
                                 select i.sem_id).ToList().LastOrDefault();

                        sessid = (from i in db.sessions
                                  where i.sem_id == semid
                                  select i.session_id).ToList().LastOrDefault();

                        count = (from i in db.subjects
                                 where i.allotted_sem == sem && (i.course == branch || i.course == null)
                                 select i).Count();

                        var q = from i in db.InternalMarks
                                where i.session_id == sessid
                                select new
                                {
                                    i.subject.subject_name,
                                    i.marks1,
                                    i.marks2,
                                    i.marks3,
                                    i.bmarks,
                                    i.rmarks
                                };

                        gvinternals.DataSource = q;
                        gvinternals.DataBind();

                        var qex = from i in db.ExternalMarks
                                where i.sem_id == semid
                                select new
                                {
                                    i.subject.subject_name,
                                    i.marks,
                                    i.pract_marks,
                                    i.rem_1,
                                    i.rem_2,
                                    i.grade,
                                    i.status
                                };

                        gvexterals.DataSource = qex;
                        gvexterals.DataBind();

                        

                        if (count == 6)
                        {
                            mvextrasubinternal.ActiveViewIndex = 1;
                        }

                        subname = (from i in db.subjects
                                   where i.allotted_sem == sem && (i.course == branch || i.course == null)
                                   select i.subject_name).ToArray();

                        lbls1.Text = subname[0];
                        lbls2.Text = subname[1];
                        lbls3.Text = subname[2];
                        lbls4.Text = subname[3];
                        lbls5.Text = subname[4];

                        if (count == 6)
                        {
                            lbls6.Text = subname[5];
                        }

                        var s = (from i in db.InternalMarks
                                 where i.session_id == sessid && i.subject.subject_name == subname[0]
                                 select i).SingleOrDefault();

                        txts1m1.Text = s.marks1.ToString();
                        txts1m2.Text = s.marks2.ToString();
                        txts1m3.Text = s.marks3.ToString();
                        txts1bm.Text = s.bmarks.ToString();
                        txts1rm.Text = s.rmarks.ToString();

                        s = (from i in db.InternalMarks
                             where i.session_id == sessid && i.subject.subject_name == subname[1]
                             select i).SingleOrDefault();

                        txts2m1.Text = s.marks1.ToString();
                        txts2m2.Text = s.marks2.ToString();
                        txts2m3.Text = s.marks3.ToString();
                        txts2bm.Text = s.bmarks.ToString();
                        txts2rm.Text = s.rmarks.ToString();

                        s = (from i in db.InternalMarks
                             where i.session_id == sessid && i.subject.subject_name == subname[2]
                             select i).SingleOrDefault();

                        txts3m1.Text = s.marks1.ToString();
                        txts3m2.Text = s.marks2.ToString();
                        txts3m3.Text = s.marks3.ToString();
                        txts3bm.Text = s.bmarks.ToString();
                        txts3rm.Text = s.rmarks.ToString();

                        s = (from i in db.InternalMarks
                             where i.session_id == sessid && i.subject.subject_name == subname[3]
                             select i).SingleOrDefault();

                        txts4m1.Text = s.marks1.ToString();
                        txts4m2.Text = s.marks2.ToString();
                        txts4m3.Text = s.marks3.ToString();
                        txts4bm.Text = s.bmarks.ToString();
                        txts4rm.Text = s.rmarks.ToString();

                        s = (from i in db.InternalMarks
                             where i.session_id == sessid && i.subject.subject_name == subname[4]
                             select i).SingleOrDefault();

                        txts5m1.Text = s.marks1.ToString();
                        txts5m2.Text = s.marks2.ToString();
                        txts5m3.Text = s.marks3.ToString();
                        txts5bm.Text = s.bmarks.ToString();
                        txts5rm.Text = s.rmarks.ToString();

                        if (count == 6)
                        {
                            s = (from i in db.InternalMarks
                                 where i.session_id == sessid && i.subject.subject_name == subname[5]
                                 select i).SingleOrDefault();

                            txts6m1.Text = s.marks1.ToString();
                            txts6m2.Text = s.marks2.ToString();
                            txts6m3.Text = s.marks3.ToString();
                            txts6bm.Text = s.bmarks.ToString();
                            txts6rm.Text = s.rmarks.ToString();
                        }

                        txtattendance.Text = (from i in db.sessions
                                 where i.session_id == sessid
                                 select i.attendance).SingleOrDefault().ToString();

                    }

                }
                catch (Exception ex) { }
            }

        }

        static int sem;
        static string cs, batch;
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            if (txtsem.Text == string.Empty)
            {
                lblsearcherror.Text = "Semester detail is compulsory.";
                return;
            }
            using(DepartmentPortalDataContext db = new DepartmentPortalDataContext())
            {
                try
                {
                    sem = Convert.ToInt32(txtsem.Text);
                    cs = (ddlclass.SelectedItem.Text=="--select--")?"":ddlclass.SelectedItem.Text;
                    batch = (ddlbatch.SelectedItem.Text=="--select--")?"":ddlbatch.SelectedItem.Text;


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
                        foreach(var i in q)
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
                catch(Exception ex) { }
            }
        }

        static string stid;
        protected void gvsearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            using(DepartmentPortalDataContext db =new DepartmentPortalDataContext())
            {
                try
                {
                    stid = gvsearch.SelectedRow.Cells[1].Text;
                    mvresults.ActiveViewIndex = 2;
                    mvsearhbtn.ActiveViewIndex = 1;
                    mvadvancesemester.ActiveViewIndex = 1;
                    loadresults();
                    loadextresults();
                }
                catch(Exception ex) { }
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
                e.Row.Cells[1].Text = "Student ID";
                e.Row.Cells[2].Text = "Full Name";
                e.Row.Cells[3].Text = "Division";
                e.Row.Cells[4].Text = "Batch";
            }
        }

        protected void ddlclass_SelectedIndexChanged(object sender, EventArgs e)
        {
            using(DepartmentPortalDataContext db = new DepartmentPortalDataContext())
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
                catch(Exception ex) { }
            }
        }

        protected void loadextresults()
        {
            using(DepartmentPortalDataContext db = new DepartmentPortalDataContext())
            {
                try
                {
                    if (count == 6)
                    {
                        mvexternalsubject.ActiveViewIndex = 1;
                    }

                    var q = from i in db.ExternalMarks
                            where i.sem_id == semid
                            select new
                            {
                                i.subject.subject_name,
                                i.marks,
                                i.pract_marks,
                                i.rem_1,
                                i.rem_2,
                                i.grade,
                                i.status
                            };

                    gvexterals.DataSource = q;
                    gvexterals.DataBind();

                    var qin = from i in db.InternalMarks
                            where i.session_id == sessid
                            select new
                            {
                                i.subject.subject_name,
                                i.marks1,
                                i.marks2,
                                i.marks3,
                                i.bmarks,
                                i.rmarks
                            };

                    gvinternals.DataSource = qin;
                    gvinternals.DataBind();



                    lbls1name.Text = subname[0];
                    lbls2name.Text = subname[1];
                    lbls3name.Text = subname[2];
                    lbls4name.Text = subname[3];
                    lbls5name.Text = subname[4];
                    if (count == 6)
                    {
                        lbls6name.Text = subname[5];
                    }

                    var q1 = (from i in db.ExternalMarks
                              where i.sem_id == semid && i.subject.subject_name == subname[0]
                              select i).SingleOrDefault();

                    txts1m.Text = q1.marks.ToString();
                    txts1pm.Text = q1.pract_marks.ToString();
                    txts1r1.Text = q1.rem_1.ToString();
                    txts1r2.Text = q1.rem_2.ToString();
                    txts1grade.Text = q1.grade.ToString();
                    txts1stat.Text = q1.status.ToString();

                    q1 = (from i in db.ExternalMarks
                          where i.sem_id == semid && i.subject.subject_name == subname[1]
                          select i).SingleOrDefault();

                    txts2m.Text = q1.marks.ToString();
                    txts2pm.Text = q1.pract_marks.ToString();
                    txts2r1.Text = q1.rem_1.ToString();
                    txts2r2.Text = q1.rem_2.ToString();
                    txts2grade.Text = q1.grade.ToString();
                    txts2stat.Text = q1.status.ToString();

                    q1 = (from i in db.ExternalMarks
                          where i.sem_id == semid && i.subject.subject_name == subname[2]
                          select i).SingleOrDefault();

                    txts3m.Text = q1.marks.ToString();
                    txts3pm.Text = q1.pract_marks.ToString();
                    txts3r1.Text = q1.rem_1.ToString();
                    txts3r2.Text = q1.rem_2.ToString();
                    txts3grade.Text = q1.grade.ToString();
                    txts3stat.Text = q1.status.ToString();

                    q1 = (from i in db.ExternalMarks
                          where i.sem_id == semid && i.subject.subject_name == subname[3]
                          select i).SingleOrDefault();

                    txts4m.Text = q1.marks.ToString();
                    txts4pm.Text = q1.pract_marks.ToString();
                    txts4r1.Text = q1.rem_1.ToString();
                    txts4r2.Text = q1.rem_2.ToString();
                    txts4grade.Text = q1.grade.ToString();
                    txts4stat.Text = q1.status.ToString();

                    q1 = (from i in db.ExternalMarks
                          where i.sem_id == semid && i.subject.subject_name == subname[4]
                          select i).SingleOrDefault();

                    txts5m.Text = q1.marks.ToString();
                    txts5pm.Text = q1.pract_marks.ToString();
                    txts5r1.Text = q1.rem_1.ToString();
                    txts5r2.Text = q1.rem_2.ToString();
                    txts5grade.Text = q1.grade.ToString();
                    txts5stat.Text = q1.status.ToString();

                    if (count == 6)
                    {
                        q1 = (from i in db.ExternalMarks
                              where i.sem_id == semid && i.subject.subject_name == subname[5]
                              select i).SingleOrDefault();

                        txts6m.Text = q1.marks.ToString();
                        txts6pm.Text = q1.pract_marks.ToString();
                        txts6r1.Text = q1.rem_1.ToString();
                        txts6r2.Text = q1.rem_2.ToString();
                        txts6grade.Text = q1.grade.ToString();
                        txts6stat.Text = q1.status.ToString();
                    }


                }
                catch(Exception ex) { }
            }
        }

        protected void gvexterals_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = "Subject Name";
                e.Row.Cells[1].Text = "Marks";
                e.Row.Cells[2].Text = "Practical Marks";
                e.Row.Cells[3].Text = "Rem1 Marks";
                e.Row.Cells[4].Text = "Rem2 Marks";
                e.Row.Cells[5].Text = "Grade";
                e.Row.Cells[6].Text = "Status";
            }
        }

        protected void btnsaveex_Click(object sender, EventArgs e)
        {
            using (DepartmentPortalDataContext db = new DepartmentPortalDataContext())
            {
                try
                {
                    var q1 = (from i in db.ExternalMarks
                              where i.sem_id==semid && i.subject.subject_name == subname[0]
                              select i).SingleOrDefault();
                    q1.marks = Convert.ToInt32(txts1m.Text == "" ? "-1" : txts1m.Text);
                    q1.pract_marks = Convert.ToInt32(txts1pm.Text == "" ? "-1" : txts1pm.Text);
                    q1.rem_1 = Convert.ToInt32(txts1r1.Text == "" ? "-1" : txts1r1.Text);
                    q1.rem_2 = Convert.ToInt32(txts1r2.Text == "" ? "-1" : txts1r2.Text);
                    q1.grade = txts1grade.Text == "" ? "-1" : txts1grade.Text;
                    q1.status = txts1stat.Text == "" ? "-1" : txts1stat.Text;
                    db.SubmitChanges();

                    q1 = (from i in db.ExternalMarks
                          where i.sem_id == semid && i.subject.subject_name == subname[1]
                          select i).SingleOrDefault();
                    q1.marks = Convert.ToInt32(txts2m.Text == "" ? "-1" : txts2m.Text);
                    q1.pract_marks = Convert.ToInt32(txts2pm.Text == "" ? "-1" : txts2pm.Text);
                    q1.rem_1 = Convert.ToInt32(txts2r1.Text == "" ? "-1" : txts2r1.Text);
                    q1.rem_2 = Convert.ToInt32(txts2r2.Text == "" ? "-1" : txts2r2.Text);
                    q1.grade = txts2grade.Text == "" ? "-1" : txts2grade.Text;
                    q1.status = txts2stat.Text == "" ? "-1" : txts2stat.Text;
                    db.SubmitChanges();

                    q1 = (from i in db.ExternalMarks
                          where i.sem_id == semid && i.subject.subject_name == subname[2]
                          select i).SingleOrDefault();
                    q1.marks = Convert.ToInt32(txts3m.Text == "" ? "-1" : txts3m.Text);
                    q1.pract_marks = Convert.ToInt32(txts3pm.Text == "" ? "-1" : txts3pm.Text);
                    q1.rem_1 = Convert.ToInt32(txts3r1.Text == "" ? "-1" : txts3r2.Text);
                    q1.rem_2 = Convert.ToInt32(txts3r2.Text == "" ? "-1" : txts3r2.Text);
                    q1.grade = txts3grade.Text == "" ? "-1" : txts3grade.Text;
                    q1.status = txts3stat.Text == "" ? "-1" : txts3stat.Text;
                    db.SubmitChanges();

                    q1 = (from i in db.ExternalMarks
                          where i.sem_id == semid && i.subject.subject_name == subname[3]
                          select i).SingleOrDefault();
                    q1.marks = Convert.ToInt32(txts4m.Text == "" ? "-1" : txts4m.Text);
                    q1.pract_marks = Convert.ToInt32(txts4pm.Text == "" ? "-1" : txts4pm.Text);
                    q1.rem_1 = Convert.ToInt32(txts4r1.Text == "" ? "-1" : txts4r1.Text);
                    q1.rem_2 = Convert.ToInt32(txts4r2.Text == "" ? "-1" : txts4r2.Text);
                    q1.grade = txts4grade.Text == "" ? "-1" : txts4grade.Text;
                    q1.status = txts4stat.Text == "" ? "-1" : txts4stat.Text;
                    db.SubmitChanges();

                    q1 = (from i in db.ExternalMarks
                          where i.sem_id == semid && i.subject.subject_name == subname[4]
                          select i).SingleOrDefault();
                    q1.marks = Convert.ToInt32(txts5m.Text == "" ? "-1" : txts5m.Text);
                    q1.pract_marks = Convert.ToInt32(txts5pm.Text == "" ? "-1" : txts5pm.Text);
                    q1.rem_1 = Convert.ToInt32(txts5r1.Text == "" ? "-1" : txts5r1.Text);
                    q1.rem_2 = Convert.ToInt32(txts5r2.Text == "" ? "-1" : txts5r2.Text);
                    q1.grade = txts5grade.Text == "" ? "-1" : txts5grade.Text;
                    q1.status = txts5stat.Text == "" ? "-1" : txts5stat.Text;
                    db.SubmitChanges();

                    if (count == 6)
                    {
                        q1 = (from i in db.ExternalMarks
                              where i.sem_id == semid && i.subject.subject_name == subname[5]
                              select i).SingleOrDefault();
                        q1.marks = Convert.ToInt32(txts6m.Text == "" ? "-1" : txts6m.Text);
                        q1.pract_marks = Convert.ToInt32(txts6pm.Text == "" ? "-1" : txts6pm.Text);
                        q1.rem_1 = Convert.ToInt32(txts6r1.Text == "" ? "-1" : txts6r1.Text);
                        q1.rem_2 = Convert.ToInt32(txts6r2.Text == "" ? "-1" : txts6r2.Text);
                        q1.grade = txts6grade.Text == "" ? "-1" : txts6grade.Text;
                        q1.status = txts6stat.Text == "" ? "-1" : txts6stat.Text;
                        db.SubmitChanges();
                    }
                    lblsaveexerror.Text = "Changes have been made.";
                    loadextresults();
                }
                catch (Exception ex) { }
            }
        }

        protected void txtattendance_TextChanged(object sender, EventArgs e)
        {
            using(DepartmentPortalDataContext db = new DepartmentPortalDataContext())
            {
                try
                {
                    var q = (from i in db.sessions
                             where i.session_id == sessid
                             select i).SingleOrDefault();

                    q.attendance = Convert.ToDecimal(txtattendance.Text);
                    db.SubmitChanges();

                }
                catch(Exception ex) { }
            }
        }

        protected void btnpass_Click(object sender, EventArgs e)
        {
            mvnewsem.ActiveViewIndex = 1;
            txtattendance.ReadOnly = true;
            btnpass.Visible = false;

            using(DepartmentPortalDataContext db = new DepartmentPortalDataContext())
            {
                try
                {
                    var qin = from i in db.InternalMarks
                              where i.session_id == sessid
                              select new
                              {
                                  i.subject.subject_name,
                                  i.marks1,
                                  i.marks2,
                                  i.marks3,
                                  i.bmarks,
                                  i.rmarks
                              };

                    gvinternals.DataSource = qin;
                    gvinternals.DataBind();

                    var qex = from i in db.ExternalMarks
                              where i.sem_id == semid
                              select new
                              {
                                  i.subject.subject_name,
                                  i.marks,
                                  i.pract_marks,
                                  i.rem_1,
                                  i.rem_2,
                                  i.grade,
                                  i.status
                              };

                    gvexterals.DataSource = qex;
                    gvexterals.DataBind();
                }
                catch(Exception ex) { }
            }
        }

        protected void btncreate_Click(object sender, EventArgs e)
        {
            using (DepartmentPortalDataContext db = new DepartmentPortalDataContext())
            {
                try
                {
                    var qin = from i in db.InternalMarks
                            where i.session_id == sessid
                            select new
                            {
                                i.subject.subject_name,
                                i.marks1,
                                i.marks2,
                                i.marks3,
                                i.bmarks,
                                i.rmarks
                            };

                    gvinternals.DataSource = qin;
                    gvinternals.DataBind();

                    var qex = from i in db.ExternalMarks
                              where i.sem_id == semid
                              select new
                              {
                                  i.subject.subject_name,
                                  i.marks,
                                  i.pract_marks,
                                  i.rem_1,
                                  i.rem_2,
                                  i.grade,
                                  i.status
                              };

                    gvexterals.DataSource = qex;
                    gvexterals.DataBind();


                    int newsemid,newcount;
                    int[] newsubs;

                    if (cbkattempt.Checked == false) {
                        Semester s = new Semester()
                        {
                            student_id = stid,
                            sem = sem + 1,
                            roll_no = Convert.ToInt32(txtrollno.Text),
                            attempt = 0,
                            division = txtdiv.Text,
                            batch = txtbatch.Text
                        };
                        db.Semesters.InsertOnSubmit(s);
                        var q = (from i in db.Students
                                where i.student_id == stid
                                select i).SingleOrDefault();

                        int cursem = Convert.ToInt32(q.current_sem) + 1;
                        q.current_sem++;
                        db.SubmitChanges();

                        newsemid = (from i in db.Semesters
                                        where i.student_id == stid
                                        select i.sem_id).ToList().LastOrDefault();

                        newsubs = (from i in db.subjects
                                       where i.allotted_sem == cursem
                                       select i.subject_id).ToArray();
                        newcount = newsubs.Length;


                    }
                    else
                    {
                        int at = Convert.ToInt32((from i in db.Semesters
                                                  where i.sem_id == semid
                                                  select i.attempt).SingleOrDefault());

                        Semester s = new Semester()
                        {
                            student_id = stid,
                            sem = sem,
                            roll_no = Convert.ToInt32(txtrollno.Text),
                            attempt = at+1,
                            division = txtdiv.Text,
                            batch = txtbatch.Text
                        };
                        db.Semesters.InsertOnSubmit(s);

                        newsemid = (from i in db.Semesters
                                    where i.student_id == stid
                                    select i.sem_id).ToList().LastOrDefault();

                        newsubs = (from i in db.subjects
                                   where i.allotted_sem == sem && i.course == branch
                                   select i.subject_id).ToArray();

                        newcount = newsubs.Length;


                    }



                    ExternalMark ex;

                    for (int j = 0; j < newcount; j++)
                    {

                        ex = new ExternalMark()
                        {
                            sem_id = newsemid,
                            subject_id = newsubs[j],
                            marks = -1,
                            pract_marks = -1,
                            rem_1 = -1,
                            rem_2 = -1,
                            grade = "-1",
                            status = "-1"
                        };
                        db.ExternalMarks.InsertOnSubmit(ex);
                        db.SubmitChanges();
                    }



                    session ss = new session()
                    {
                        sem_id = newsemid,
                        session_type = 'n',
                        attendance = 0,
                        est_attendance = 0
                    };
                    db.sessions.InsertOnSubmit(ss);
                    db.SubmitChanges();

                    var newsessid = (from i in db.sessions
                                     where i.sem_id == newsemid
                                     select i.session_id).ToList().LastOrDefault();

                    InternalMark m;

                    for (int j = 0; j < newcount; j++)
                    {
                        m = new InternalMark()
                        {
                            subject_id = newsubs[j],
                            session_id = newsessid,
                            marks1 = -1,
                            marks2 = -1,
                            marks3 = -1,
                            rmarks = -1,
                            bmarks = -1,
                        };
                        db.InternalMarks.InsertOnSubmit(m);
                        db.SubmitChanges();
                    }

                    lblcreateerror.Text = "Student's semester has been incremented.";
                }
                catch (Exception ex) { }
            }
        }

        protected void gvinternals_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = "Subject Name";
                e.Row.Cells[1].Text = "Sess1 Marks";
                e.Row.Cells[2].Text = "Sess2 Marks";
                e.Row.Cells[3].Text = "Sess3 Marks";
                e.Row.Cells[4].Text = "Block Marks";
                e.Row.Cells[5].Text = "Remedial Marks";
            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            using(DepartmentPortalDataContext db = new DepartmentPortalDataContext())
            {
                try
                {
                    var q1 = (from i in db.InternalMarks
                            where i.session_id == sessid && i.subject.subject_name == subname[0]
                            select i).SingleOrDefault();
                    q1.marks1 = Convert.ToInt32(txts1m1.Text==""?"-1":txts1m1.Text);
                    q1.marks2 = Convert.ToInt32(txts1m2.Text == "" ? "-1" : txts1m2.Text);
                    q1.marks3 = Convert.ToInt32(txts1m3.Text == "" ? "-1" : txts1m3.Text);
                    q1.bmarks = Convert.ToInt32(txts1bm.Text == "" ? "-1" : txts1bm.Text);
                    q1.rmarks = Convert.ToInt32(txts1rm.Text == "" ? "-1" : txts1rm.Text);

                    var q2 = (from i in db.InternalMarks
                         where i.session_id == sessid && i.subject.subject_name == subname[1]
                         select i).SingleOrDefault();
                    q2.marks1 = Convert.ToInt32(txts2m1.Text == "" ? "-1" : txts2m1.Text);
                    q2.marks2 = Convert.ToInt32(txts2m2.Text == "" ? "-1" : txts2m2.Text);
                    q2.marks3 = Convert.ToInt32(txts2m3.Text == "" ? "-1" : txts2m3.Text);
                    q2.bmarks = Convert.ToInt32(txts2bm.Text == "" ? "-1" : txts2bm.Text);
                    q2.rmarks = Convert.ToInt32(txts2rm.Text == "" ? "-1" : txts2rm.Text);

                    var q3 = (from i in db.InternalMarks
                         where i.session_id == sessid && i.subject.subject_name == subname[2]
                         select i).SingleOrDefault();
                    q3.marks1 = Convert.ToInt32(txts3m1.Text == "" ? "-1" : txts3m1.Text);
                    q3.marks2 = Convert.ToInt32(txts3m2.Text == "" ? "-1" : txts3m2.Text);
                    q3.marks3 = Convert.ToInt32(txts3m3.Text == "" ? "-1" : txts3m3.Text);
                    q3.bmarks = Convert.ToInt32(txts3bm.Text == "" ? "-1" : txts3bm.Text);
                    q3.rmarks = Convert.ToInt32(txts3rm.Text == "" ? "-1" : txts3rm.Text);

                    var q4 = (from i in db.InternalMarks
                         where i.session_id == sessid && i.subject.subject_name == subname[3]
                         select i).SingleOrDefault();
                    q4.marks1 = Convert.ToInt32(txts4m1.Text == "" ? "-1" : txts4m1.Text);
                    q4.marks2 = Convert.ToInt32(txts4m2.Text == "" ? "-1" : txts4m2.Text);
                    q4.marks3 = Convert.ToInt32(txts4m3.Text == "" ? "-1" : txts4m3.Text);
                    q4.bmarks = Convert.ToInt32(txts4bm.Text == "" ? "-1" : txts4bm.Text);
                    q4.rmarks = Convert.ToInt32(txts4rm.Text == "" ? "-1" : txts4rm.Text);

                    var q5 = (from i in db.InternalMarks
                         where i.session_id == sessid && i.subject.subject_name == subname[4]
                         select i).SingleOrDefault();
                    q5.marks1 = Convert.ToInt32(txts5m1.Text == "" ? "-1" : txts5m1.Text);
                    q5.marks2 = Convert.ToInt32(txts5m2.Text == "" ? "-1" : txts5m2.Text);
                    q5.marks3 = Convert.ToInt32(txts5m3.Text == "" ? "-1" : txts5m3.Text);
                    q5.bmarks = Convert.ToInt32(txts5bm.Text == "" ? "-1" : txts5bm.Text);
                    q5.rmarks = Convert.ToInt32(txts5rm.Text == "" ? "-1" : txts5rm.Text);

                    if (count == 6)
                    {
                        var q6 = (from i in db.InternalMarks
                             where i.session_id == sessid && i.subject.subject_name == subname[5]
                             select i).SingleOrDefault();
                        q6.marks1 = Convert.ToInt32(txts6m1.Text == "" ? "-1" : txts6m1.Text);
                        q6.marks2 = Convert.ToInt32(txts6m2.Text == "" ? "-1" : txts6m2.Text);
                        q6.marks3 = Convert.ToInt32(txts6m3.Text == "" ? "-1" : txts6m3.Text);
                        q6.bmarks = Convert.ToInt32(txts6bm.Text == "" ? "-1" : txts6bm.Text);
                        q6.rmarks = Convert.ToInt32(txts6rm.Text == "" ? "-1" : txts6rm.Text);
                    }

                    db.SubmitChanges();

                    lblsaveerror.Text = "Changes have been made.";
                    loadresults();

                }
                catch(Exception ex) { }
            }
        }

        protected void txtsem_TextChanged(object sender, EventArgs e)
        {
            using(DepartmentPortalDataContext db = new DepartmentPortalDataContext())
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
                catch(Exception ex) { }
            }
        }
    }
}