using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace DepartmentPortal
{
    public partial class forgotpassword : System.Web.UI.Page
    {
        string mycs;
        SqlConnection conn;
        bool idflag;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                mycs = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lenovo\Source\Repos\DepartmentPortal\DepartmentPortal\DepartmentPortal\App_Data\DepartmentPortal.mdf;Integrated Security=True";
                conn = new SqlConnection(mycs);
            }
            catch (Exception ex) { }

            if (!this.IsPostBack)
            {
                MultiView1.ActiveViewIndex = 0;
                string id = Request.QueryString["id"];
                idflag = Convert.ToBoolean(Request.QueryString["idflag"]);
                if (id != "")
                {
                    txtid.Text = id;
                }
            }

            lblerror.Text = "";
        }

        static string q1 = String.Empty, q2 = String.Empty;
        static string a1 = String.Empty, a2 = String.Empty;
        
        protected void btnredirect_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void btnsubmit_pass_Click(object sender, EventArgs e)
        {
            if ((txtpass.Text == "" || txtcpass.Text == ""))
            {
                lblerror.Text = "All fields are mandatory.";
                return;
            }
            else if (txtpass.Text != txtcpass.Text)
            {
                lblerror.Text = "Passwords do not match";
                return;
            }
            else
            {
                try
                {
                    string sql;
                    if (idflag == false)
                        sql = "update student set password=@pass where student_id=@id";
                    else
                        sql = "update faculty set password=@pass where faculty_id=@id";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", txtid.Text);
                    cmd.Parameters.AddWithValue("@pass", txtpass.Text);
                    conn.Open();
                    int n = cmd.ExecuteNonQuery();
                    if (n == 1)
                    {
                        MultiView1.ActiveViewIndex += 1;
                    }
                    else
                    {
                        lblerror.Text = "Error updating. Please try again later.";
                    }
                }
                catch(Exception ex)
                {
                    lblerror.Text = "Error updating. Please try again later.";
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            if (txtid.Text == "")
            {
                lblerror.Text = "Invalid input.";
                return;
            }
            else
            {
                try
                {
                    string sql;
                    if(idflag==false)
                        sql = "select sec_ques_1,sec_ques_2,sec_ans_1,sec_ans_2 from student where student_id=@id";
                    else
                        sql = "select sec_ques_1,sec_ques_2,sec_ans_1,sec_ans_2 from faculty where faculty_id=@id";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", txtid.Text);
                    conn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            q1 = rdr["sec_ques_1"].ToString();
                            q2 = rdr["sec_ques_2"].ToString();
                            a1 = rdr["sec_ans_1"].ToString();
                            a2 = rdr["sec_ans_2"].ToString();
                        }
                        rdr.Close();
                    }
                    else
                    {
                        lblerror.Text = "Invalid input.";
                        return;
                    }
                    lblsecques1.Text = q1;
                    lblsecques2.Text = q2;
                    MultiView1.ActiveViewIndex += 1;
                }
                catch(Exception ex)
                {
                    lblerror.Text = "Invalid details.";
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        protected void btnsubmit_ans_Click(object sender, EventArgs e)
        {
            lblsecques1.Text = q1;
            lblsecques2.Text = q2;

            if (txtsecans1.Text == a1 && txtsecans2.Text == a2)
            {
                MultiView1.ActiveViewIndex += 1;
            }
            else
            {
                lblerror.Text = "Incorrect Input. Reset process failed.";
            }
        }

    }
}