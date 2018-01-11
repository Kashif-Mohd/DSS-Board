using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DSS_Project
{
    public partial class Main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["DSSusername"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Session["DSSusername"] = null;
            Response.Redirect("Login.aspx"); 
        }
    }
}