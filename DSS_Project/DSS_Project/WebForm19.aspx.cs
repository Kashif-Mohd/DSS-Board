using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DSS_Project
{
    public partial class WebForm19 : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["DSS_ID"] = null;
            ShowData();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            ShowData();
        }
        private void ShowData()
        {
            try
            {
                MySqlConnection con = new MySqlConnection(constr);


                MySqlCommand cmd = new MySqlCommand("SELECT * from error_forms", con);
                {
                    MySqlDataAdapter sda = new MySqlDataAdapter();
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        {
                            sda.Fill(dt);
                            GridView1.DataSource = dt;
                            GridView1.DataBind();
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script type=\"text/javascript\">alert('" + ex.Message + "')</script>");
            }
        }


        protected void Link_Button1(object sender, EventArgs e)
        {
            string dss_id = ((LinkButton)sender).Text;           
            Session["DSS_ID"] = dss_id;
            Response.Redirect("WebForm17.aspx");
        }

    }
}