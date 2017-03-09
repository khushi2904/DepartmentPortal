using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BotDetect.Web.UI;
using System.Data;
using System.Data.Sql;
using System.Configuration;
using System.Data.SqlClient;

namespace DepartmentPortal
{
    public partial class Default : System.Web.UI.Page
    {
        bool idflag = false;
        string mycs;
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                mycs = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lenovo\Source\Repos\DepartmentPortal\DepartmentPortal\DepartmentPortal\App_Data\DepartmentPortal.mdf;Integrated Security=True";
                conn = new SqlConnection(mycs);
            }
            catch(Exception ex) { }

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
                            string sql = string.Empty;
                            SqlCommand cmd;
                            SqlDataReader rdr;
                            if (idflag == false)
                            {
                                sql = "select student_id, password, full_name from student where student_id=@id and password=@pass";
                                cmd = new SqlCommand(sql, conn);
                                cmd.Parameters.AddWithValue("@id", txtid.Text);
                                cmd.Parameters.AddWithValue("@pass", txtpass.Text);
                                conn.Open();
                                rdr = cmd.ExecuteReader();
                                while (rdr.Read())
                                {
                                    string id = rdr["student_id"].ToString();
                                    string pass = rdr["password"].ToString();
                                    if (id == txtid.Text && pass == txtpass.Text)
                                    {
                                        Session["id"] = id;
                                        Session["username"] = rdr["full_name"].ToString();
                                        Response.Redirect("studenthome.aspx");
                                    }
                                    else
                                    {
                                        lblerror.Text = "Incorrect Credentials. Please try again.";
                                    }
                                    break;
                                }
                                rdr.Close();
                            }
                            else
                            {
                                sql = "select faculty_id, password, user_type  from faculty where faculty_id=@id and password=@pass";
                                cmd = new SqlCommand(sql, conn);
                                cmd.Parameters.AddWithValue("@id", txtid.Text);
                                cmd.Parameters.AddWithValue("@pass", txtpass.Text);
                                conn.Open();
                                rdr = cmd.ExecuteReader();
                                while (rdr.Read())
                                {
                                    string id = rdr["faculty_id"].ToString();
                                    string pass = rdr["password"].ToString();
                                    string type = rdr["user_type"].ToString();
                                    if (id == txtid.Text && pass == txtpass.Text)
                                    {
                                        Session["id"] = id;
                                        Session["username"] = rdr["full_name"].ToString();
                                        Session["type"] = type;
                                        
                                        Response.Redirect("facultyhome.aspx");
                                    }
                                    else
                                    {
                                        lblerror.Text = "Incorrect Credentials. Please try again.";
                                    }
                                    break;
                                }
                                rdr.Close();
                            }
                        }
                        catch (Exception ex)
                        {
                            lblerror.Text = "Exception";
                        }
                        finally
                        {
                            conn.Close();
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