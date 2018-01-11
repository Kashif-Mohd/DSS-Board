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
    public partial class WebForm13 : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Session["NewDSS_Member"] != null)
                {
                    lbe_DSSID_HH.Text = Convert.ToString(Session["NewDSS_Member"]);
                    ShowData();
                    //if (Convert.ToString(Session["WebPage3"]) == "WebForm4")
                    //{
                    //    ShowChildData();
                    //}
                }
                else
                {
                    Response.Redirect("WebForm11.aspx");
                }

                if (Convert.ToString(Session["NewWebPage3"]) == "NewWebForm1")
                {
                    NewWebF1.Attributes.Add("class", "active");
                }
                else if (Convert.ToString(Session["NewWebPage3"]) == "NewWebForm2")
                {
                    NewWebF2.Attributes.Add("class", "active");
                }
                else if (Convert.ToString(Session["NewWebPage3"]) == "NewWebForm4")
                {
                    NewWebF4.Attributes.Add("class", "active");
                }
                else if (Convert.ToString(Session["NewWebPage3"]) == "NewWebForm5")
                {
                    NewWebF5.Attributes.Add("class", "active");
                }
                else if (Convert.ToString(Session["NewWebPage3"]) == "NewWebForm6")
                {
                    NewWebF6.Attributes.Add("class", "active");
                }

            }

        }

        public static DataTable FlipDataTable(DataTable dt)
        {
            DataTable table = new DataTable();
            //Get all the rows and change into columns
            for (int i = 0; i <= dt.Rows.Count; i++)
            {
                table.Columns.Add(Convert.ToString(i));
            }
            DataRow dr;
            //get all the columns and make it as rows
            for (int j = 0; j < dt.Columns.Count; j++)
            {
                dr = table.NewRow();
                dr[0] = dt.Columns[j].ToString();
                for (int k = 1; k <= dt.Rows.Count; k++)
                    dr[k] = dt.Rows[k - 1][j];
                table.Rows.Add(dr);
            }

            return table;
        }



        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ShowData();
        }
        protected void Link_Button1(object sender, EventArgs e)
        {
            string DSSID_Member = ((LinkButton)sender).Text;
            Session["NewDSS_Member"] = DSSID_Member;
            Response.Redirect("WebForm13.aspx");
        }
        private void ShowData()
        {
            try
            {
                MySqlConnection con = new MySqlConnection(constr);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from census where dss_id_member='" + Convert.ToString(Session["NewDSS_Member"]) + "'");
                {
                    MySqlDataAdapter sda = new MySqlDataAdapter();
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        {
                            sda.Fill(dt);
                            GridView1.DataSource = dt;
                            GridView1.DataSource = FlipDataTable(dt);
                            GridView1.DataBind();
                            GridView1.HeaderRow.Visible = false;
                            con.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                Response.Write("<script type=\"text/javascript\">alert('" + ex.Message + "')</script>");

            }
        }

        private void ShowChildData()
        {
            try
            {
                MySqlConnection con = new MySqlConnection(constr);
                con.Open();
                MySqlCommand cmdd = new MySqlCommand("select * from census where member_type='c' and dss_id_m='" + lbe_DSSID_HH.Text + "' order by dss_id_member");
                {
                    MySqlDataAdapter sdda = new MySqlDataAdapter();
                    {
                        cmdd.Connection = con;
                        sdda.SelectCommand = cmdd;
                        DataTable dtt = new DataTable();
                        {
                            sdda.Fill(dtt);
                            GridView2.Caption = "Child Information";
                            GridView2.DataSource = dtt;
                            GridView2.DataBind();
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                Response.Write("<script type=\"text/javascript\">alert('" + ex.Message + "')</script>");

            }

        }




        private void ShowMotherData()
        {
            string Mthr = lbe_DSSID_HH.Text;
            if (Mthr.Length > 1)
            {
                Mthr = Mthr.Substring(0, Mthr.Length - 1);
            }


            try
            {
                MySqlConnection con = new MySqlConnection(constr);
                con.Open();
                MySqlCommand cmdd = new MySqlCommand("select *,(select count(*) from census where dss_id_member Like'" + Mthr + "%' and member_type='c') as countChild  from census where dss_id_member='" + Mthr + "' order by dss_id_member");
                {
                    MySqlDataAdapter sdda = new MySqlDataAdapter();
                    {
                        cmdd.Connection = con;
                        sdda.SelectCommand = cmdd;
                        DataTable dtt = new DataTable();
                        {
                            sdda.Fill(dtt);
                            GridView3.Caption = "Mother Information";
                            GridView3.DataSource = dtt;
                            GridView3.DataBind();
                        }
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
            if (Convert.ToString(Session["NewWebPage3"]) == "NewWebForm1")
            {
                Session["NewWebPage3"] = null;
                Response.Redirect("WebForm11.aspx");
            }
            else if (Convert.ToString(Session["NewWebPage3"]) == "NewWebForm2")
            {
                Session["NewWebPage3"] = null;
                Response.Redirect("WebForm12.aspx");
            }
            else if (Convert.ToString(Session["NewWebPage3"]) == "NewWebForm4")
            {
                Session["NewWebPage3"] = null;
                Response.Redirect("WebForm14.aspx");
            }
            else if (Convert.ToString(Session["NewWebPage3"]) == "NewWebForm5")
            {
                Session["NewWebPage3"] = null;
                Response.Redirect("WebForm15.aspx");
            }
            else if (Convert.ToString(Session["NewWebPage3"]) == "NewWebForm6")
            {
                Session["NewWebPage3"] = null;
                Response.Redirect("WebForm16.aspx");
            }
            else
            {
                Response.Redirect("WebForm11.aspx");
            }
        }


        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Font.Bold = true;
                e.Row.Cells[0].ForeColor = System.Drawing.Color.White;
                e.Row.Cells[0].Width = 230;

                e.Row.Cells[1].ForeColor = System.Drawing.Color.FromName("#284775");
                e.Row.Cells[1].BackColor = System.Drawing.Color.FromName("#DADFE1");
                e.Row.Cells[1].BorderColor = System.Drawing.Color.FromName("#52B3D9");
                e.Row.Cells[0].BorderColor = System.Drawing.Color.FromName("#81CFE0");

                //e.Row.Cells[0].BackColor = System.Drawing.Color.CornflowerBlue;

                TableCell statusCell = e.Row.Cells[1];
                if (statusCell.Text == "mw")
                {
                    statusCell.Text = "Married Woman";
                    lbe_DSSID_HH.Text = Convert.ToString(Session["NewDSS_Member"]);
                    ShowChildData();
                }
                else if (statusCell.Text == "h")
                {
                    statusCell.Text = "Husband";
                }
                else if (statusCell.Text == "c")
                {
                    statusCell.Text = "Child";
                    lbe_DSSID_HH.Text = Convert.ToString(Session["NewDSS_Member"]);
                    ShowMotherData();
                }
            }

            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{

            //    TableCell statusCell = e.Row.Cells[1];
            //    if (statusCell.Text == "1")
            //    {
            //        statusCell.Text = "Male";
            //    }
            //    if (statusCell.Text == "2")
            //    {
            //        statusCell.Text = "Female";
            //    }
            //}
        }

        protected void OnRowDataBound1(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                TableCell statusCell = e.Row.Cells[3];
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