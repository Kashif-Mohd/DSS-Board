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
    public partial class WebForm8 : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;
        MySqlDataReader dreader;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["full_name"] != null)
                {
                    //lbe_FullName.Text = Convert.ToString(Session["full_name"]);
                    ShowGetDetail();
                    //txtRegion.Focus();
                }
                else
                {
                    Response.Redirect("WebForm7.aspx");
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lbeFullName.Text != "")
            {

                if (txtRegion.Text.Length < 6 && txtRegion.Text != "")
                {
                    Response.Write("<script type=\"text/javascript\">alert('Please enter only AlphaNumeric value where 6 character long, except any symbols.')</script>");
                    txtRegion.Focus();
                }
                else
                {
                    UserLog();
                    MySqlConnection con = new MySqlConnection(constr);
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("update users SET region_dss='" + txtRegion.Text + "' where full_name='" + lbeFullName.Text + "' and password='" + lbePassword.Text + "'", con);

                    int result = cmd.ExecuteNonQuery();

                    if (result == 1)
                    {
                        if (txtRegion.Text == "")
                        {
                            Response.Write("<script type=\"text/javascript\">alert('Region Removed Successfully!');window.location.href='WebForm7.aspx';</script>");
                        }
                        else
                        {
                            Response.Write("<script type=\"text/javascript\">alert('Region Updated Successfully!');window.location.href='WebForm7.aspx';</script>");
                        }                   
                    }
                }
            }
            else
            {
                Response.Write("<script type=\"text/javascript\">alert('No user account is Open, please open first!')</script>");
            }
        }





        public void UserLog()
        {
            try
            {
                MySqlConnection con = new MySqlConnection(constr);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * from users where full_name='" + Convert.ToString(Session["full_name"]) + "'", con);
                {
                    dreader = cmd.ExecuteReader();
                    if (dreader.Read())
                    {
                        string idd = dreader["id"].ToString();

                        string FulNme = dreader["full_name"].ToString();

                        DateTime StartTime = Convert.ToDateTime(dreader["updated"]);
                        string StartDateTime = StartTime.ToString("yyyy-MM-dd HH:mm:ss");

                        string LastRegion = dreader["region_dss"].ToString();

                        con.Close();

                        con.Open();
                        MySqlCommand cmd2 = new MySqlCommand("insert into user_log (fullname,start_time,id_user,dss_region) values ('" + FulNme + "','" + StartDateTime + "','" + idd + "','" + LastRegion + "')", con);
                        cmd2.ExecuteNonQuery();
                        con.Close();
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
            if (Convert.ToString(Session["WebPage8"]) == "WebForm7")
            {
                Session["WebPage8"] = null;
                Response.Redirect("WebForm7.aspx");
            }
        }


        private void ShowGetDetail()
        {
            try
            {
                MySqlConnection con = new MySqlConnection(constr);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * from users where full_name='" + Convert.ToString(Session["full_name"]) + "'", con);
                {
                    dreader = cmd.ExecuteReader();
                    if (dreader.Read())
                    {
                        lbeFullName.Text = dreader["full_name"].ToString();
                        lbeUsername.Text = dreader["username"].ToString();
                        lbePassword.Text = dreader["password"].ToString();
                        //txtEmployeeNo.Text = dreader["full_name"].ToString();
                        txtRegion.Text = dreader["region_dss"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script type=\"text/javascript\">alert('" + ex.Message + "')</script>");
            }
        }



    }
}