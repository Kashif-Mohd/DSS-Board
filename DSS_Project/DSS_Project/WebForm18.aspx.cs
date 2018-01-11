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
    public partial class WebForm18 : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            ShowData();
        }

        //protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    GridView1.PageIndex = e.NewPageIndex;
        //    ShowData();
        //}
        private void ShowData()
        {
            try
            {
                MySqlConnection con = new MySqlConnection(constr);

                con.Open();
                MySqlCommand cmd2 = new MySqlCommand("select * from sync_status", con);
                {
                    MySqlDataAdapter sda2 = new MySqlDataAdapter();
                    {
                        cmd2.Connection = con;
                        sda2.SelectCommand = cmd2;
                        DataTable dt = new DataTable();
                        {
                            sda2.Fill(dt);
                            GridView2.DataSource = dt;
                            GridView2.DataBind();
                        }
                    }
                    con.Close();
                }


                //con.Open();
                //MySqlCommand cmd = new MySqlCommand("select * from data_by_worker", con);
                //{
                //    MySqlDataAdapter sda = new MySqlDataAdapter();
                //    {
                //        cmd.Connection = con;
                //        sda.SelectCommand = cmd;
                //        DataTable dt = new DataTable();
                //        {
                //            sda.Fill(dt);
                //            GridView1.DataSource = dt;
                //            GridView1.DataBind();
                //        }
                //    }
                //    con.Close();
                //}
            }
            catch (Exception ex)
            {
                Response.Write("<script type=\"text/javascript\">alert('" + ex.Message + "')</script>");
            }
        }
    }
}