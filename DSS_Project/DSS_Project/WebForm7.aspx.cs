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
    public partial class WebForm7 : System.Web.UI.Page
    {       
        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["txtFullName"] != null)
            {
                txtFullName.Text = Convert.ToString(Session["txtFullName"]);
                if (Session["radio"] == Convert.ToString("2"))
                {
                    rbRegion.Checked = true;
                    rbName.Checked = false;
                }
                Session["txtFullName"] = null;
                ShowData();
            }
            else
            {
                ShowData();
            }
            Session["full_name"] = null;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Button2.Enabled = true;
            ShowData();
            if (GridView1.Rows.Count == 0)
            {
                Button2.Enabled = false;
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //base.VerifyRenderingInServerForm(control);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            ShowData();
            if (GridView1.Rows.Count != 0)
            {
                ExcelExport();
            }
            else 
            {
                Button2.Enabled = false;
            }
        }
        public void ExcelExportMessage()
        {
            if (txtFullName.Text != "")
            {
                GridView2.Caption = "List of Users, Search by: " + txtFullName.Text;
            }
            else
            {
                GridView2.Caption = "List of Users";
            }
        }
        public void ExcelExport()
        {
            try
            {
                Response.Clear();
                Response.AddHeader("content-disposition", "attachment;filename=Users-List (" + DateTime.Today.ToString("dd-MM-yyyy") + ").xls");
                Response.Charset = "";

                Response.ContentType = "application/vnd.xls";
                System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter htmlWrite =
                new HtmlTextWriter(stringWrite);
                GridView2.AllowPaging = false;
                ExcelExportMessage();
                GridView2.CaptionAlign = TableCaptionAlign.Top;

                Exportdata();
                for (int i = 0; i < GridView2.HeaderRow.Cells.Count; i++)
                {
                    GridView2.HeaderRow.Cells[i].Style.Add("background-color", "#5D7B9D");
                    GridView2.HeaderRow.Cells[i].Style.Add("Color", "white");
                }
                GridView2.RenderControl(htmlWrite);
                Response.Write(stringWrite.ToString());
                Response.End();

            }
            catch (Exception ex)
            {
                Response.Write("<script type=\"text/javascript\">alert(" + ex.Message + ")</script>");

            }
        }

        private void ShowData()
        {
            try
            {
                MySqlConnection con = new MySqlConnection(constr);

                if (txtFullName.Text == "")
                {
                    MySqlCommand cmd = new MySqlCommand("select *,(SUBSTRING(password,3,CHARACTER_LENGTH(password))) as employee from users  where username Not like '%@%' order by full_name");
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
                else if (rbName.Checked == true)
                {
                    MySqlCommand cmd = new MySqlCommand("select *,(SUBSTRING(password,3,CHARACTER_LENGTH(password))) as employee from users where full_name Like '%" + txtFullName.Text + "%' and username Not like '%@%' order by full_name");
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
                    MySqlCommand cmd = new MySqlCommand("select *,(SUBSTRING(password,3,CHARACTER_LENGTH(password))) as employee from users where region_dss Like '%" + txtFullName.Text + "%' and username Not like '%@%' order by full_name");
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


        private void Exportdata()
        {
            try
            {
                MySqlConnection con = new MySqlConnection(constr);

                if (txtFullName.Text == "")
                {
                    MySqlCommand cmd = new MySqlCommand("select *,(SUBSTRING(password,3,CHARACTER_LENGTH(password))) as employee from users  where username Not like '%@%' order by full_name");
                    {
                        MySqlDataAdapter sda = new MySqlDataAdapter();
                        {
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            DataTable dt = new DataTable();
                            {
                                sda.Fill(dt);
                                GridView2.DataSource = dt;
                                GridView2.DataBind();
                            }
                        }
                    }
                }
                else if (rbName.Checked == true)
                {
                    MySqlCommand cmd = new MySqlCommand("select *,(SUBSTRING(password,3,CHARACTER_LENGTH(password))) as employee from users where full_name Like '%" + txtFullName.Text + "%' and username Not like '%@%' order by full_name");
                    {
                        MySqlDataAdapter sda = new MySqlDataAdapter();
                        {
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            DataTable dt = new DataTable();
                            {
                                sda.Fill(dt);
                                GridView2.DataSource = dt;
                                GridView2.DataBind();
                            }
                        }
                    }
                }
                else
                {
                    MySqlCommand cmd = new MySqlCommand("select *,(SUBSTRING(password,3,CHARACTER_LENGTH(password))) as employee from users where region_dss Like '%" + txtFullName.Text + "%' and username Not like '%@%' order by full_name");
                    {
                        MySqlDataAdapter sda = new MySqlDataAdapter();
                        {
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            DataTable dt = new DataTable();
                            {
                                sda.Fill(dt);
                                GridView2.DataSource = dt;
                                GridView2.DataBind();
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
            string full_name = ((LinkButton)sender).Text;
            Session["full_name"] = full_name;
            Session["WebPage8"] = "WebForm7";
            Session["txtFullName"] = txtFullName.Text;

            if (rbName.Checked == true)
            {
                Session["radio"] = "1";
            }
            else
            {
                Session["radio"] = "2";
            }
            Response.Redirect("WebForm8.aspx");
        }

    }
}