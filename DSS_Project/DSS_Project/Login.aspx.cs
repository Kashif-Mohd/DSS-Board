using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DSS_Project
{
    public partial class Login : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;
        MySqlDataReader dreader;

        protected void Page_Load(object sender, EventArgs e)
        {
            txtUserNme.Focus();
        }

        public class RegularExpression
        {
            public static bool CheckEmail(String email)
            {
                bool Isvalid = false;
                Regex r = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                if (r.IsMatch(email))
                    Isvalid = true;
                return Isvalid;
            }
        }


        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Loginn();
        }


        private void Loginn()
        {
            if (txtUserNme.Text == "")
            {
                Response.Write("<script type=\"text/javascript\">alert('Please Enter User ID!')</script>");
                txtUserNme.Focus();
            }
            else if (RegularExpression.CheckEmail(txtUserNme.Text.ToString()) == false)
            {
                Response.Write("<script type=\"text/javascript\">alert('Invalid User ID, please enter Like eg: admin@aku.edu')</script>");
                txtUserNme.Focus();
            }
            else if (txtPass.Text == "")
            {
                Response.Write("<script type=\"text/javascript\">alert('Please Enter Password!')</script>");
                txtPass.Focus();
            }
            else if (txtPass.Text == "")
            {
                Response.Write("<script type=\"text/javascript\">alert('Please Enter Password!')</script>");
                txtPass.Focus();
            }
            else if (LogSeach() == false)
            {
                Response.Write("<script>alert('Incorrect User Name or Password')</script>");
                txtPass.Text = "";
                txtPass.Focus();
            }
            else
            {
                Session["DSSusername"] = txtUserNme.Text;
                Response.Redirect("WebForm18.aspx");
            }
        }



        public bool LogSeach()
        {
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand("select * from users where username='" + txtUserNme.Text + "' and password='" + txtPass.Text + "'", con);
                dreader = cmd.ExecuteReader();
                if (dreader.Read())
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script type=\"text/javascript\">alert('" + ex.Message + "')</script>");
                Response.Write("<script>window.location.href='Login.aspx';</script>");
            }
            finally
            {
                con.Close();
            }
            return false;
        }

    }
}