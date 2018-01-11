using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Globalization;
using System.Threading;

namespace DSS_Project
{
    public partial class WebForm9 : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;
        MySqlDataReader dreader;

        string FirstName;
        string LastName;
        string FullName;

        protected void Page_Load(object sender, EventArgs e)
        {
            txtFirstName.Focus();
        }
        protected void btnInsert_Click(object sender, EventArgs e)
        {
            if (txtFirstName.Text == "")
            {
                clear();
                Response.Write("<script type=\"text/javascript\">alert('Please Enter First Name!')</script>");
                txtFirstName.Focus();
            }
            else if (txtLastName.Text == "")
            {
                clear();
                Response.Write("<script type=\"text/javascript\">alert('Please Enter Last Name!')</script>");
                txtLastName.Focus();
            }

            else if (FindUser() == true)
            {
                clear();
                Response.Write("<script type=\"text/javascript\">alert('Full Name is already exists!')</script>");
            }
            else if (txtEmployeeNo.Text == "")
            {
                clear();
                Response.Write("<script type=\"text/javascript\">alert('Please Enter Employee Number!')</script>");
                txtEmployeeNo.Focus();
            }

            else if (txtSite.Text.Length < 2 || txtSite.Text == "")
            {
                clear();
                Response.Write("<script type=\"text/javascript\">alert('Please enter only AlphaNumeric value where 2 characters long')</script>");
                txtSite.Focus();
            }
            else if (txtRegion.Text.Length < 6 && txtRegion.Text != "")
            {
                clear();
                Response.Write("<script type=\"text/javascript\">alert('Please enter only AlphaNumeric value where 6 characters long')</script>");
                txtRegion.Focus();
            }
            else
            {
                clear();
                CapitalizeName();
                Insert();
            }

        }



        public void CapitalizeName()
        {
            string txt1 = txtFirstName.Text.Trim();
            CultureInfo cultureInfo1 = Thread.CurrentThread.CurrentCulture;
            TextInfo ti1 = cultureInfo1.TextInfo;
            FirstName = ti1.ToTitleCase(txt1);

            string txt2 = txtLastName.Text.Trim();
            CultureInfo cultureInfo2 = Thread.CurrentThread.CurrentCulture;
            TextInfo ti2 = cultureInfo2.TextInfo;
            LastName = ti2.ToTitleCase(txt2);

            FullName = FirstName + " " + LastName;
        }

        public void Insert()
        {
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("insert into users (full_name,region_dss,site) values ('" + FullName + "','" + txtRegion.Text + "','" + txtSite.Text.ToUpper() + "')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            CreateUserAndPassword();
        }




        public void CreateUserAndPassword()
        {
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();
            try
            {               
                MySqlCommand cmd = new MySqlCommand("select Max(id) as Max from users", con);
                dreader = cmd.ExecuteReader();
                if (dreader.Read())
                {
                    //get Last 2 ID digit:
                    string gMaxId = dreader["Max"].ToString();
                    string MaxId = gMaxId.Substring(gMaxId.Length - 2);



                    //For UserName:
                    string First4 = FirstName;    // txtFirstName.Text
                    string firstFour = First4.Substring(0, 4);

                    string First2 = LastName;    //txtLastName.Text
                    string firstTwo = First2.Substring(0, 2);

                    string UserName = firstFour + MaxId + firstTwo;
                    txtUsername.Text = UserName;

                    //For Password:
                    string Last2 = FirstName;  //txtFirstName.Text
                    string lastTwo = Last2.Substring(Last2.Length - 2);

                    string PassWord = lastTwo + txtEmployeeNo.Text;
                    txtPassword.Text = PassWord;
                    UpdateUserPassword();
                }
            }

            finally
            {
                con.Close(); 
            }
        }



        public void UpdateUserPassword()
        {
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("Update users set username='" + txtUsername.Text + "',password='" + txtPassword.Text + "' where full_name='" + FullName + "'", con);
            int result = cmd.ExecuteNonQuery();

            if (result == 1)
            {
                Response.Write("<script type=\"text/javascript\">alert('Created User Successfully!')</script>");
            }
            con.Close();
        }



        public void clear()
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
        }

        public bool FindUser()
        {
            CapitalizeName();
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("select * from users where full_name='" + FullName + "'", con);
            dreader = cmd.ExecuteReader();
            if (dreader.Read())
            {
                con.Close();
                return true;
            }
            con.Close();
            return false;
        }

    }
}