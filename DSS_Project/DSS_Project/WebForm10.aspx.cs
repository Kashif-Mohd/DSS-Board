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
    public partial class WebForm10 : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;
        MySqlDataReader dreader;
        protected void Page_Load(object sender, EventArgs e)
        {
            GetUserName();
            txtOldPassword.Focus();
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            
            if (txtOldPassword.Text == "")
            {
                Response.Write("<script type=\"text/javascript\">alert('Please Enter Old Password!')</script>");
                txtOldPassword.Focus();
            }
            else if (txtOldPassword.Text.Length < 6 && txtOldPassword.Text != "")
            {
                Response.Write("<script type=\"text/javascript\">alert('Password must be at least 6 characters long.')</script>");
                txtOldPassword.Text = "";
                txtOldPassword.Focus();
            }
            else if (txtNewPassword.Text == "")
            {
                Response.Write("<script type=\"text/javascript\">alert('Please Enter New Password!')</script>");
                txtNewPassword.Focus();
            }
            else if (txtNewPassword.Text.Length < 6 && txtNewPassword.Text != "")
            {
                Response.Write("<script type=\"text/javascript\">alert('Password must be at least 6 characters long.')</script>");
                txtNewPassword.Text = "";
                txtNewPassword.Focus();
            }

            else if (txtConfirmPassword.Text == "")
            {
                Response.Write("<script type=\"text/javascript\">alert('Please Enter Confirm Password!')</script>");
                txtConfirmPassword.Focus();
            }
            else if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                Response.Write("<script type=\"text/javascript\">alert('Password Does Not Match!')</script>");
                txtConfirmPassword.Text = "";
                txtConfirmPassword.Focus();
            }
            else if (checkPassword() == false)
            {
                Response.Write("<script type=\"text/javascript\">alert('Password you entered is incorrect, please enter correct password!')</script>");
                txtOldPassword.Text = "";
                txtOldPassword.Focus();
            }
            else
            {
                changePassword();
            }
        }


        public void changePassword()
        {
            try
            {
                MySqlConnection con = new MySqlConnection(constr);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("update users SET password='" + txtNewPassword.Text + "' where  username='" + Convert.ToString(Session["DSSusername"]) + "' and full_name='"+lbeFullName.Text+"'", con);
                int result = cmd.ExecuteNonQuery();

                if (result == 1)
                {
                    Response.Write("<script type=\"text/javascript\">alert('Password Changed Successfully!')</script>");
                    //Response.Write("<script>window.location.href='Login.aspx';</script>");
                    Clearr();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script type=\"text/javascript\">alert('" + ex.Message + "')</script>");

            }
        }


        public bool checkPassword()
        {
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("select * from users where username='" + Convert.ToString(Session["DSSusername"]) + "' and password='" + txtOldPassword.Text + "'", con);
            dreader = cmd.ExecuteReader();
            if (dreader.Read())
            {
                return true;
            }
            return false;
        }



        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clearr();
        }


        public void Clearr()
        {
            txtOldPassword.Text = "";
            txtNewPassword.Text = "";
            txtConfirmPassword.Text = "";         
        }


        public void GetUserName()
        {
            try
            {
                MySqlConnection con = new MySqlConnection(constr);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from users where username='" + Convert.ToString(Session["DSSusername"]) + "'", con);
                {
                    dreader = cmd.ExecuteReader();
                    if (dreader.Read())
                    {
                        string UsrNme = dreader["full_name"].ToString();
                        lbeFullName.Text = UsrNme;
                        con.Close();
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