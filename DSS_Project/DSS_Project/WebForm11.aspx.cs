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
    public partial class WebForm11 : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            Button2.Visible = false;

            if (!IsPostBack)
            {
                txtDSSMember.Focus();
                Session["NewFM_DSS_ID"] = null;
                Session["NewDSS_Member"] = null;
                //DataGet.DSS_Member = "EMPTY";
                if (Session["NewtxtDSSMember1"] != null)
                {
                    txtDSSMember.Text = Convert.ToString(Session["NewtxtDSSMember1"]);
                    ShowData();
                    Session["NewtxtDSSMember1"] = null;
                }
            }
        }




        public override void VerifyRenderingInServerForm(Control control)
        {
            //base.VerifyRenderingInServerForm(control);
        }



        protected void Button1_Click(object sender, EventArgs e)
        {
            ShowData();
        }



        protected void Button2_Click(object sender, EventArgs e)
        {
            ShowData();
            if (GridView1.Rows.Count != 0)
            {
                //ExcelExport("DSSID_Data("+DateTime.Today+").xls", "application/vnd.ms-excel");
                ExcelExport();
            }
        }




        public void ExcelExportMessage()
        {
            if (txtDSSMember.Text != "")
            {
                GridView2.Caption = "DSSID Family Member Data, Search by: " + txtDSSMember.Text;
            }
            else
            {
                GridView2.Caption = "DSSID Family Member Data";
            }
        }

        public void ExcelExport()
        {
            try
            {
                Response.Clear();
                Response.AddHeader("content-disposition", "attachment;filename=NewFamilyData (" + DateTime.Today.ToString("dd-MM-yyyy") + ").xls");
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




        protected void Link_Button1(object sender, EventArgs e)
        {
            Session["NewtxtDSSMember1"] = txtDSSMember.Text;
            string Dss_ID_hh = ((LinkButton)sender).Text;
            Session["NewWebPage2"] = "NewWebForm1";
            Session["NewFM_DSS_ID"] = Dss_ID_hh;
            Response.Redirect("WebForm12.aspx");
        }
        protected void Link_Button2(object sender, EventArgs e)
        {
            Session["NewtxtDSSMember1"] = txtDSSMember.Text;
            string DSSID_Member = ((LinkButton)sender).Text;
            Session["NewWebPage3"] = "NewWebForm1";
            Session["NewDSS_Member"] = DSSID_Member;
            Response.Redirect("WebForm13.aspx");
        }

        private void ShowData()
        {
            try
            {
                MySqlConnection con = new MySqlConnection(constr);


                if (txtDSSMember.Text != "")
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




        private void Exportdata()
        {
            try
            {
                MySqlConnection con = new MySqlConnection(constr);


                if (txtDSSMember.Text != "")
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



        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            ShowData();
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
                TableCell statusCell = e.Row.Cells[5];
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

        }

    }
}