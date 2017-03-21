using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DepartmentPortal
{
    public partial class messages : System.Web.UI.Page
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
                using(DepartmentPortalDataContext db = new DepartmentPortalDataContext())
                {
                    try
                    {

                    }
                    catch(Exception ex) { }
                }
            }
        }
    }
}