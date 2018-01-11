using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace DSS_Project
{
    public partial class WebForm15 : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            txtChildName.Focus();
            if (Session["NewtxtChildName"] != null || Session["NewtxtDSSchild"] != null)
            {
                txtDSSchild.Text = Convert.ToString(Session["NewtxtDSSchild"]);
                txtChildName.Text = Convert.ToString(Session["NewtxtChildName"]);
                ShowData();
                Session["NewtxtDSSchild"] = null;
                Session["NewtxtChildName"] = null;
            }

            Session["NewFM_DSS_ID"] = null;
            Session["NewMW_DSS_ID"] = null;
            Session["NewDSS_Member"] = null;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ShowData();

        }



        private void ShowData()
        {
            try
            {
                MySqlConnection con = new MySqlConnection(constr);

                if (txtChildName.Text != "" && txtDSSchild.Text != "")
                {
                    MySqlCommand cmd = new MySqlCommand("select * from census where member_type='c' and name like '%" + txtChildName.Text + "%' and dss_id_member like '%" + txtDSSchild.Text + "%' order by dss_id_member");
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
                else if (txtChildName.Text == "" && txtDSSchild.Text != "")
                {
                    MySqlCommand cmd = new MySqlCommand("select * from census where member_type='c'  and dss_id_member like '%" + txtDSSchild.Text + "%' order by dss_id_member");
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
                else if (txtChildName.Text != "" && txtDSSchild.Text == "")
                {
                    MySqlCommand cmd = new MySqlCommand("select * from census where member_type='c' and name like '%" + txtChildName.Text + "%' order by dss_id_member");
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
                else
                {
                    MySqlCommand cmd = new MySqlCommand("select * from census where member_type='c' order by dss_id_member");
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
            }
            catch (Exception ex)
            {
                Response.Write("<script type=\"text/javascript\">alert('" + ex.Message + "')</script>");
            }
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            ShowData();
        }


        protected void Link_Button1(object sender, EventArgs e)
        {
            string dss_id_m = ((LinkButton)sender).Text;
            Session["NewtxtChildName"] = txtChildName.Text;
            Session["NewtxtDSSchild"] = txtDSSchild.Text;
            Session["NewMW_DSS_ID"] = dss_id_m;
            Response.Redirect("WebForm14.aspx");
        }
        protected void Link_Button2(object sender, EventArgs e)
        {
            string DSSID_Member = ((LinkButton)sender).Text;
            Session["NewtxtChildName"] = txtChildName.Text;
            Session["NewtxtDSSchild"] = txtDSSchild.Text;
            Session["NewWebPage3"] = "NewWebForm5";
            Session["NewDSS_Member"] = DSSID_Member;
            Response.Redirect("WebForm13.aspx");
        }
        protected void Link_Button3(object sender, EventArgs e)
        {
            string Dss_ID_hh = ((LinkButton)sender).Text;
            Session["NewtxtChildName"] = txtChildName.Text;
            Session["NewtxtDSSchild"] = txtDSSchild.Text;
            Session["NewWebPage2"] = "NewWebForm5";
            Session["NewFM_DSS_ID"] = Dss_ID_hh;
            Response.Redirect("WebForm12.aspx");
        }


        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TableCell statusCell = e.Row.Cells[5];
                if (statusCell.Text == "1")
                {
                    statusCell.Text = "Male";
                }
                if (statusCell.Text == "2")
                {
                    statusCell.Text = "Female";
                }
            }
        }
    }
}