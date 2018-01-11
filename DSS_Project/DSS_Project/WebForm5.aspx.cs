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
    public partial class WebForm5 : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            txtChildName.Focus();
            if (Session["txtChildName"] != null || Session["txtDSSchild"] != null)
            {
                txtDSSchild.Text = Convert.ToString(Session["txtDSSchild"]);
                txtChildName.Text = Convert.ToString(Session["txtChildName"]);
                ShowData();
                Session["txtDSSchild"] = null;
                Session["txtChildName"] = null;
            }
            else { ShowData(); }
            Session["FM_DSS_ID"] = null;
            Session["MW_DSS_ID"] = null;
            Session["DSS_Member"] = null;
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
                    MySqlCommand cmd = new MySqlCommand("select * from family_members where member_type='ch' and name like '%" + txtChildName.Text + "%' and dss_id_member like '%" + txtDSSchild.Text + "%' order by dss_id_member");
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
                    MySqlCommand cmd = new MySqlCommand("select * from family_members where member_type='ch'  and dss_id_member like '%" + txtDSSchild.Text + "%' order by dss_id_member");
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
                    MySqlCommand cmd = new MySqlCommand("select * from family_members where member_type='ch' and name like '%" + txtChildName.Text + "%' order by dss_id_member");
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
                    MySqlCommand cmd = new MySqlCommand("select * from family_members where member_type='ch' order by dss_id_member");
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
            Session["txtChildName"] = txtChildName.Text;
            Session["txtDSSchild"] = txtDSSchild.Text;
            Session["MW_DSS_ID"] = dss_id_m;
            Response.Redirect("WebForm4.aspx");
        }
        protected void Link_Button2(object sender, EventArgs e)
        {
            string DSSID_Member = ((LinkButton)sender).Text;
            Session["txtChildName"] = txtChildName.Text;
            Session["txtDSSchild"] = txtDSSchild.Text;
            Session["WebPage3"] = "WebForm5";
            Session["DSS_Member"] = DSSID_Member;
            Response.Redirect("WebForm3.aspx");
        }
        protected void Link_Button3(object sender, EventArgs e)
        {
            string Dss_ID_hh = ((LinkButton)sender).Text;
            Session["txtChildName"] = txtChildName.Text;
            Session["txtDSSchild"] = txtDSSchild.Text;
            Session["WebPage2"] = "WebForm5";
            Session["FM_DSS_ID"] = Dss_ID_hh;
            Response.Redirect("WebForm2.aspx");
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