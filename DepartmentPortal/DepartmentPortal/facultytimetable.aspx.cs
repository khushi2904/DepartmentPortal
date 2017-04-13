using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DepartmentPortal
{
    public partial class facultytimetable : System.Web.UI.Page
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
                if (!this.IsPostBack)
                {
                    List<string> day = new List<string>()
                {
                    "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"
                };
                    ddlday.DataSource = day;
                    ddlday.DataBind();

                    List<string> sem = new List<string>()
                {
                    "1","2","3","4","5","6","7","8"
                };
                    ddlsem.DataSource = sem;
                    ddlsem.DataBind();
                    ddlsrchsem.DataSource = sem;
                    ddlsrchsem.DataBind();

                    List<string> branch = new List<string>()
                {
                    "CE","EC","IT","MH","CH","CL","IC"
                };
                    ddlbranch.DataSource = branch;
                    ddlbranch.DataBind();
                    ddlsrchbranch.DataSource = branch;
                    ddlsrchbranch.DataBind();
                }

            }
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            using(DepartmentPortalDataContext db = new DepartmentPortalDataContext())
            {
                try
                {
                    var q = from i in db.DailyTTs
                            where i.sem == Convert.ToInt32(ddlsem.SelectedItem.Value) &&
                            i.branch ==ddlbranch.SelectedItem.Value &&
                            i.division == txtdiv.Text
                            select i;

                    if (!q.Any())
                    {
                        DailyTT dtt = new DailyTT()
                        {
                            sem = Convert.ToInt32(ddlsem.SelectedItem.Value),
                            branch = ddlbranch.SelectedItem.Value,
                            division = txtdiv.Text,
                            s1_dur = txts1durfrom.Text + "-" + txts1durto.Text,
                            s2_dur = txts2durfrom.Text + "-" + txts2durto.Text,
                            s3_dur = txts3durfrom.Text + "-" + txts3durto.Text,
                            s4_dur = txts4durfrom.Text + "-" + txts4durto.Text,
                            s5_dur = txts5durfrom.Text + "-" + txts5durto.Text,
                            s6_dur = txts6durfrom.Text + "-" + txts6durto.Text,
                            s7_dur = txts7durfrom.Text + "-" + txts7durto.Text,
                            s1_type = txts1subname.Text == "" ? null : (cbks1lab.Checked ? "b" : "l"),
                            s2_type = txts2subname.Text == "" ? null : (cbks2lab.Checked ? "b" : "l"),
                            s3_type = txts3subname.Text == "" ? null : (cbks3lab.Checked ? "b" : "l"),
                            s4_type = txts4subname.Text == "" ? null : (cbks4lab.Checked ? "b" : "l"),
                            s5_type = txts5subname.Text == "" ? null : (cbks5lab.Checked ? "b" : "l"),
                            s6_type = txts6subname.Text == "" ? null : (cbks6lab.Checked ? "b" : "l"),
                            s7_type = txts7subname.Text == "" ? null : (cbks7lab.Checked ? "b" : "l"),
                        };
                        db.DailyTTs.InsertOnSubmit(dtt);
                        db.SubmitChanges();
                    }
                    else
                    {
                        lblsubmiterror.Text = "TimeTable already exists.";
                    }

                    var ttid = Convert.ToInt32((from i in db.DailyTTs
                                                where i.sem == Convert.ToInt32(ddlsem.SelectedItem.Value) &&
                                                i.branch == ddlbranch.SelectedItem.Value &&
                                                i.division == txtdiv.Text
                                                select i.tt_Id).ToList().Last());


                    var q1 = from i in db.lecTTs
                             where i.tt_id == ttid && i.day == ddlday.SelectedItem.Value
                             select i;

                    if (!q1.Any())
                    {
                        lecTT ltt = new lecTT()
                        {
                            tt_id = ttid,
                            day = ddlday.SelectedItem.Value,
                            s1 = cbks1lab.Checked ? null : txts1subname.Text,
                            f1 = cbks1lab.Checked ? null : txts1facname.Text,
                            s2 = cbks2lab.Checked ? null : txts2subname.Text,
                            f2 = cbks2lab.Checked ? null : txts2facname.Text,
                            s3 = cbks3lab.Checked ? null : txts3subname.Text,
                            f3 = cbks3lab.Checked ? null : txts3facname.Text,
                            s4 = cbks4lab.Checked ? null : txts4subname.Text,
                            f4 = cbks4lab.Checked ? null : txts4facname.Text,
                            s5 = cbks5lab.Checked ? null : txts5subname.Text,
                            f5 = cbks5lab.Checked ? null : txts5facname.Text,
                            s6 = cbks6lab.Checked ? null : txts6subname.Text,
                            f6 = cbks6lab.Checked ? null : txts6facname.Text,
                            s7 = cbks7lab.Checked ? null : txts7subname.Text,
                            f7 = cbks7lab.Checked ? null : txts7facname.Text
                        };

                        db.lecTTs.InsertOnSubmit(ltt);

                        List<string> lecs = new List<string>();
                        List<string> facs = new List<string>();

                        if (cbks1lab.Checked) { lecs.Add(txts1subname.Text); facs.Add(txts1facname.Text); }
                        if (cbks2lab.Checked) { lecs.Add(txts2subname.Text); facs.Add(txts2facname.Text); }
                        if (cbks3lab.Checked) { lecs.Add(txts3subname.Text); facs.Add(txts3facname.Text); }
                        if (cbks4lab.Checked) { lecs.Add(txts4subname.Text); facs.Add(txts4facname.Text); }
                        if (cbks5lab.Checked) { lecs.Add(txts5subname.Text); facs.Add(txts5facname.Text); }
                        if (cbks6lab.Checked) { lecs.Add(txts6subname.Text); facs.Add(txts6facname.Text); }
                        if (cbks7lab.Checked) { lecs.Add(txts7subname.Text); facs.Add(txts7facname.Text); }

                        int n = lecs.Count();
                        lab_tt btt;
                        for (int i = 0; i < n; i++)
                        {
                            btt = new lab_tt()
                            {
                                tt_id = ttid,
                                day = ddlday.SelectedItem.Value,
                                s1 = "LAB - " + lecs[i],
                                f1 = facs[i],
                                b1 = txtbatch.Text,
                            };
                            db.lab_tts.InsertOnSubmit(btt);
                        }

                        db.SubmitChanges();
                        lblsubmiterror.Text = "TimeTable has been successfully generated.";
                    }
                    else
                    {

                        lblsubmiterror.Text = "TimeTable already exists.";
                    }

                }
                catch(Exception ex)
                {
                    lblsubmiterror.Text = "TimeTable could not be generated.";
                }
            }
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            int sem = Convert.ToInt32(ddlsrchsem.SelectedItem.Value);
            string branch = ddlsrchbranch.SelectedItem.Value;
            string cs = txtsrchdiv.Text;
            string batch = txtsrchbatch.Text;




            using (DepartmentPortalDataContext db = new DepartmentPortalDataContext())
            {
                try
                {

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
                             where i.tt_id == ttid && i.b1 == batch && i.day == j.day
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
                catch (Exception ex) { }
            }
        }

        string[] head;
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