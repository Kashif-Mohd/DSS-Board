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
    public partial class WebForm16 : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["NewtxtDSSChild"] != null)
                {
                    txtDSSChild.Text = Convert.ToString(Session["NewtxtDSSChild"]);
                    ShowData();
                    Session["NewtxtDSSChild"] = null;
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ShowData();
        }


        private void ShowData()
        {
            try
            {
                MySqlConnection con = new MySqlConnection(constr);

                if (txtDSSChild.Text != "")
                {
                    MySqlCommand cmd = new MySqlCommand("SELECT c.name child_name, c.dss_id_member child_id, m.name mother_name, m.dss_id_member mother_id, c.dob date_of_birth, count(*) no_of_children FROM dss.census C join census m on c.dss_id_m = m.dss_id_member where c.member_type = 'c' and  c.dss_id_member Like '%" + txtDSSChild.Text + "%' group by mother_id order by right(c.dob, 4) desc, right(left(c.dob, 5),2) desc, left(left(c.dob, 5),2) desc;");
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
                    MySqlCommand cmd = new MySqlCommand("SELECT c.name child_name, c.dss_id_member child_id, m.name mother_name, m.dss_id_member mother_id, c.dob date_of_birth, count(*) no_of_children FROM dss.census C join census m on c.dss_id_m = m.dss_id_member where c.member_type = 'c' group by mother_id order by right(c.dob, 4) desc, right(left(c.dob, 5),2) desc, left(left(c.dob, 5),2) desc;");
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

        protected void Link_Button1(object sender, EventArgs e)
        {
            string child_id = ((LinkButton)sender).Text;
            Session["NewDSS_Member"] = child_id;
            Session["NewWebPage3"] = "NewWebForm6";
            Session["NewtxtDSSChild"] = txtDSSChild.Text;
            Response.Redirect("WebForm13.aspx");
        }
        protected void Link_Button2(object sender, EventArgs e)
        {
            string mother_id = ((LinkButton)sender).Text;
            Session["NewDSS_Member"] = mother_id;
            Session["NewWebPage3"] = "NewWebForm6";
            Session["NewtxtDSSChild"] = txtDSSChild.Text;
            Response.Redirect("WebForm13.aspx");
        }
    }
}