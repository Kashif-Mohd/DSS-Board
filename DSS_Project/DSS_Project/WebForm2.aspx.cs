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
    public partial class WebForm2 : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            Button2.Visible = false;

            if (!IsPostBack)
            {
                txtDSSMember.Focus();
                if (Session["txtDSSMember2"] != null && Session["FM_DSS_ID"] == null)
                {
                    txtDSSMember.Text = Convert.ToString(Session["txtDSSMember2"]);
                    ShowData();
                    ImageButton1.Visible = false;
                    Session["txtDSSMember2"] = null;
                    Session["DSS_Member"] = null;
                }
                else if (Session["FM_DSS_ID"] != null )
                {
                    lbe_DSSID_H.Text = Convert.ToString(Session["FM_DSS_ID"]);
                    ImageButton1.Visible = true;
                    if (Session["txtDSSMember2"] != null)
                    {
                        txtDSSMember.Text = Convert.ToString(Session["txtDSSMember2"]);
                    }
                    ShowData();
                    Session["txtDSSMember2"] = null;
                    Session["DSS_Member"] = null;
                }
                else
                {
                    ImageButton1.Visible = false;
                    ShowData();
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

                if (Session["FM_DSS_ID"] != null && txtDSSMember.Text != "")
                {
                    MySqlCommand cmd = new MySqlCommand("select * from family_members where dss_id_hh='" + Convert.ToString(Session["FM_DSS_ID"]) + "' and dss_id_member like '%" + txtDSSMember.Text + "%' order by dss_id_member");
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

                else if (Session["FM_DSS_ID"] == null && txtDSSMember.Text != "")
                {
                    MySqlCommand cmd = new MySqlCommand("select * from family_members where dss_id_member like '%" + txtDSSMember.Text + "%' order by dss_id_member");
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
                else if (Session["FM_DSS_ID"] != null && txtDSSMember.Text == "")
                {
                    MySqlCommand cmd = new MySqlCommand("select * from family_members where dss_id_hh='" + Convert.ToString(Session["FM_DSS_ID"]) + "' order by dss_id_member");
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
                    MySqlCommand cmd = new MySqlCommand("select * from family_members order by dss_id_member");
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

                if (Session["FM_DSS_ID"] != null && txtDSSMember.Text != "")
                {
                    MySqlCommand cmd = new MySqlCommand("select * from family_members where dss_id_hh='" + Convert.ToString(Session["FM_DSS_ID"]) + "' and dss_id_member like '%" + txtDSSMember.Text + "%' order by dss_id_member");
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

                else if (Session["FM_DSS_ID"] == null && txtDSSMember.Text != "")
                {
                    MySqlCommand cmd = new MySqlCommand("select * from family_members where dss_id_member like '%" + txtDSSMember.Text + "%' order by dss_id_member");
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
                else if (Session["FM_DSS_ID"] != null && txtDSSMember.Text == "")
                {
                    MySqlCommand cmd = new MySqlCommand("select * from family_members where dss_id_hh='" + Convert.ToString(Session["FM_DSS_ID"]) + "' order by dss_id_member");
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
                    MySqlCommand cmd = new MySqlCommand("select * from family_members order by dss_id_member");
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
            Session["txtDSSMember2"] = txtDSSMember.Text;
            Session["WebPage3"] = "WebForm2";
            Session["DSS_Member"] = DSSID_Member;
            Response.Redirect("WebForm3.aspx");
        }
        protected void Link_Button2(object sender, EventArgs e)
        {
            string Dss_ID_hh = ((LinkButton)sender).Text;
            Session["txtDSSMember2"] = txtDSSMember.Text;
            Session["WebPageSame2"] = "WebFormSame2";
            Session["FM_DSS_ID"] = Dss_ID_hh;
            Response.Redirect("WebForm2.aspx");
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
            if (txtDSSMember.Text != "" && Session["FM_DSS_ID"] != null)
            {
                GridView2.Caption = "DSSID House Hold: " + Convert.ToString(Session["FM_DSS_ID"]) + ", Search by DSSID Member: " + txtDSSMember.Text;
            }
            else if (txtDSSMember.Text != "" && Session["FM_DSS_ID"] == null)
            {
                GridView2.Caption = "DSSID House Hold, Search by DSSID Member: " + txtDSSMember.Text;
            }
            else
            {
                GridView2.Caption = "DSSID House Hold: " + Convert.ToString(Session["FM_DSS_ID"]);
            }
        }

        public void ExcelExport()
        {
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=OldHouseHold (" + DateTime.Today.ToString("dd-MM-yyyy") + ").xls");
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
            if (Convert.ToString(Session["WebPage2"]) == "WebForm1")
            {
                Session["WebPage2"] = null;
                Response.Redirect("WebForm1.aspx");
            }
            else if (Convert.ToString(Session["WebPage2"]) == "WebForm2")
            {
                Session["WebPage2"] = null;
                Response.Redirect("WebForm2.aspx");
            }
            else if (Convert.ToString(Session["WebPageSame2"]) == "WebFormSame2")
            {
                Session["FM_DSS_ID"] = null;
                Session["DSS_Member"] = null;  
                Session["WebPageSame2"] = null;
                Response.Redirect("WebForm2.aspx");
               
            }
            else if (Convert.ToString(Session["WebPage2"]) == "WebForm4")
            {
                Session["WebPage2"] = null;
                Response.Redirect("WebForm4.aspx");
            }
            else if (Convert.ToString(Session["WebPage2"]) == "WebForm5")
            {
                Session["WebPage2"] = null;
                Response.Redirect("WebForm5.aspx");
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
                TableCell statusCell = e.Row.Cells[22];
                if (statusCell.Text == "mw")
                {
                    statusCell.Text = "Married Woman";
                }
                if (statusCell.Text == "h")
                {
                    statusCell.Text = "Husband";
                }
                if (statusCell.Text == "ch")
                {
                    statusCell.Text = "Child";
                }
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TableCell statusCell = e.Row.Cells[13];
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