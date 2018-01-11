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
    public partial class WebForm12 : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            Button2.Visible = false;

            if (!IsPostBack)
            {
                txtDSSMember.Focus();
                if (Session["NewtxtDSSMember2"] != null && Session["NewFM_DSS_ID"] == null)
                {
                    txtDSSMember.Text = Convert.ToString(Session["NewtxtDSSMember2"]);
                    ShowData();
                    ImageButton1.Visible = false;
                    Session["NewtxtDSSMember2"] = null;
                    Session["NewDSS_Member"] = null;
                }
                else if (Session["NewFM_DSS_ID"] != null)
                {
                    lbe_DSSID_H.Text = Convert.ToString(Session["NewFM_DSS_ID"]);
                    ImageButton1.Visible = true;
                    if (Session["NewtxtDSSMember2"] != null)
                    {
                        txtDSSMember.Text = Convert.ToString(Session["NewtxtDSSMember2"]);
                    }
                    ShowData();
                    Session["NewtxtDSSMember2"] = null;
                    Session["NewDSS_Member"] = null;
                }
                else
                {
                    ImageButton1.Visible = false;
                }
            }
        }



        protected void Button1_Click(object sender, EventArgs e)
        {
            ShowData();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */

        }
        private void ShowData()
        {
            try
            {
                MySqlConnection con = new MySqlConnection(constr);

                if (Session["NewFM_DSS_ID"] != null && txtDSSMember.Text != "")
                {
                    MySqlCommand cmd = new MySqlCommand("select * from census where dss_id_hh='" + Convert.ToString(Session["NewFM_DSS_ID"]) + "' and dss_id_member like '%" + txtDSSMember.Text + "%' order by dss_id_member");
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

                else if (Session["NewFM_DSS_ID"] == null && txtDSSMember.Text != "")
                {
                    MySqlCommand cmd = new MySqlCommand("select * from census where dss_id_member like '%" + txtDSSMember.Text + "%' order by dss_id_member");
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
                else if (Session["NewFM_DSS_ID"] != null && txtDSSMember.Text == "")
                {
                    MySqlCommand cmd = new MySqlCommand("select * from census where dss_id_hh='" + Convert.ToString(Session["NewFM_DSS_ID"]) + "' order by dss_id_member");
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
                    MySqlCommand cmd = new MySqlCommand("select * from census order by dss_id_member");
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



        private void ExportData()
        {
            try
            {
                MySqlConnection con = new MySqlConnection(constr);

                if (Session["NewFM_DSS_ID"] != null && txtDSSMember.Text != "")
                {
                    MySqlCommand cmd = new MySqlCommand("select * from census where dss_id_hh='" + Convert.ToString(Session["NewFM_DSS_ID"]) + "' and dss_id_member like '%" + txtDSSMember.Text + "%' order by dss_id_member");
                    {
                        MySqlDataAdapter sda = new MySqlDataAdapter();
                        {
                            cmd.Connection = con;
                            cmd.CommandTimeout = 999999;
                            cmd.CommandType = CommandType.Text;
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

                else if (Session["NewFM_DSS_ID"] == null && txtDSSMember.Text != "")
                {
                    MySqlCommand cmd = new MySqlCommand("select * from census where dss_id_member like '%" + txtDSSMember.Text + "%' order by dss_id_member");
                    {
                        MySqlDataAdapter sda = new MySqlDataAdapter();
                        {
                            cmd.Connection = con;
                            cmd.CommandTimeout = 999999;
                            cmd.CommandType = CommandType.Text;
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
                else if (Session["NewFM_DSS_ID"] != null && txtDSSMember.Text == "")
                {
                    MySqlCommand cmd = new MySqlCommand("select * from census where dss_id_hh='" + Convert.ToString(Session["NewFM_DSS_ID"]) + "' order by dss_id_member");
                    {
                        MySqlDataAdapter sda = new MySqlDataAdapter();
                        {
                            cmd.Connection = con;
                            cmd.CommandTimeout = 999999;
                            cmd.CommandType = CommandType.Text;
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
                    MySqlCommand cmd = new MySqlCommand("select * from census order by dss_id_member");
                    {
                        MySqlDataAdapter sda = new MySqlDataAdapter();
                        {
                            cmd.Connection = con;
                            cmd.CommandTimeout = 999999;
                            cmd.CommandType = CommandType.Text;
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
            string DSSID_Member = ((LinkButton)sender).Text;
            Session["NewtxtDSSMember2"] = txtDSSMember.Text;
            Session["NewWebPage3"] = "NewWebForm2";
            Session["NewDSS_Member"] = DSSID_Member;
            Response.Redirect("WebForm13.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            ShowData();
            if (GridView1.Rows.Count != 0)
            {
                ExcelExport();
            }
        }

        public void ExcelExportMessage()
        {
            if (txtDSSMember.Text != "" && Session["NewFM_DSS_ID"] != null)
            {
                GridView2.Caption = "DSSID House Hold: " + Convert.ToString(Session["NewFM_DSS_ID"]) + ", Search by DSSID Member: " + txtDSSMember.Text;
            }
            else if (txtDSSMember.Text != "" && Session["NewFM_DSS_ID"] == null)
            {
                GridView2.Caption = "DSSID House Hold, Search by DSSID Member: " + txtDSSMember.Text;
            }
            else
            {
                GridView2.Caption = "DSSID House Hold: " + Convert.ToString(Session["NewFM_DSS_ID"]);
            }
        }

        public void ExcelExport()
        {
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=NewHouseHold (" + DateTime.Today.ToString("dd-MM-yyyy") + ").xls");
            Response.Charset = "";

            Response.ContentType = "application/vnd.xls";
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite =
            new HtmlTextWriter(stringWrite);
            GridView2.AllowPaging = false;
            ExcelExportMessage();
            GridView2.CaptionAlign = TableCaptionAlign.Top;
            ExportData();
            for (int i = 0; i < GridView2.HeaderRow.Cells.Count; i++)
            {
                GridView2.HeaderRow.Cells[i].Style.Add("background-color", "#5D7B9D");
                GridView2.HeaderRow.Cells[i].Style.Add("Color", "white");
            }

            GridView2.RenderControl(htmlWrite);
            Response.Write(stringWrite.ToString());
            Response.End();
        }



        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            ShowData();
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if (Convert.ToString(Session["NewWebPage2"]) == "NewWebForm1")
            {
                Session["NewWebPage2"] = null;
                Response.Redirect("WebForm11.aspx");
            }
            else if (Convert.ToString(Session["NewWebPage2"]) == "NewWebForm2")
            {
                Session["NewWebPage2"] = null;
                Response.Redirect("WebForm12.aspx");
            }
            else if (Convert.ToString(Session["NewWebPage2"]) == "NewWebForm4")
            {
                Session["NewWebPage2"] = null;
                Response.Redirect("WebForm14.aspx");
            }
            else if (Convert.ToString(Session["NewWebPage2"]) == "NewWebForm5")
            {
                Session["NewWebPage2"] = null;
                Response.Redirect("WebForm15.aspx");
            }
        }

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Button2.Visible = true;
                if (GridView1.PageCount >= 460)
                {
                    Button2.Enabled = false;
                }
                else
                {
                    Button2.Enabled = true;
                }
                TableCell statusCell = e.Row.Cells[34];
                if (statusCell.Text == "mw")
                {
                    statusCell.Text = "Married Woman";
                }
                if (statusCell.Text == "h")
                {
                    statusCell.Text = "Husband";
                }
                if (statusCell.Text == "c")
                {
                    statusCell.Text = "Child";
                }
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TableCell statusCell = e.Row.Cells[23];
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