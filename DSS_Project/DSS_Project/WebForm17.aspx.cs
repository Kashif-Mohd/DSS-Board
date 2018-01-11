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
    public partial class WebForm17 : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Session["DSS_ID"] != null)
                {
                    lbe_DSSID.Text = Convert.ToString(Session["DSS_ID"]);
                    ShowData();
                    ImageButton1.Visible = true;
                    //Session["DSS_ID"] = null;
                }

                else
                {
                    lbe_DSSID.Text = "";
                    ImageButton1.Visible = false;
                    ShowData();
                }
            }

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

                if (lbe_DSSID.Text != "")
                {
                    MySqlCommand cmd = new MySqlCommand("select * from dss.forms where dssid='"+ Convert.ToString(Session["DSS_ID"])+"'", con);
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
                else
                {
                    MySqlCommand cmd = new MySqlCommand("select * from dss.forms", con);
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


        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if (Convert.ToString(Session["DSS_ID"]) != null)
            {
                Session["DSS_ID"] = null;
                Response.Redirect("WebForm19.aspx");
            }
        }
    }
}