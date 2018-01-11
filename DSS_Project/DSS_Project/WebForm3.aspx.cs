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
    public partial class WebForm3 : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {              
                if (Session["DSS_Member"] != null)
                {
                    lbe_DSSID_HH.Text = Convert.ToString(Session["DSS_Member"]);
                    ShowData();
                    //if (Convert.ToString(Session["WebPage3"]) == "WebForm4")
                    //{
                    //    ShowChildData();
                    //}
                }
                else
                {
                    Response.Redirect("WebForm1.aspx");
                }

                if (Convert.ToString(Session["WebPage3"]) == "WebForm1")
                {
                    WebF1.Attributes.Add("class", "active");
                }
                else if (Convert.ToString(Session["WebPage3"]) == "WebForm2")
                {
                    WebF2.Attributes.Add("class", "active");
                }
                else if (Convert.ToString(Session["WebPage3"]) == "WebForm4")
                {
                    WebF4.Attributes.Add("class", "active");
                }
                else if (Convert.ToString(Session["WebPage3"]) == "WebForm5")
                {
                    WebF5.Attributes.Add("class", "active");
                }
                else if (Convert.ToString(Session["WebPage3"]) == "WebForm6")
                {
                    WebF6.Attributes.Add("class", "active");
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
            Session["DSS_Member"] = DSSID_Member;
            Response.Redirect("WebForm3.aspx");
        }
        private void ShowData()
        {
            try
            {
                MySqlConnection con = new MySqlConnection(constr);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select _id as ID,_date as Date,dss_id_hh as 'DSSID House Hold',dss_id_f as 'DSSID Father',dss_id_m as 'DSSID Mother',dss_id_h as 'DSSID Head',dss_id_member as 'DSSID Member',prevs_dss_id_member as 'Previous DSSID Member',site_code as 'Site Code',name as Name,dob as 'Date of Birth',age as Age,gender as Gender,is_head,relation_hh as 'Relation House Hold',current_status as 'Current Status',current_date as 'Current Date',dod,m_status,education as Education,occupation as Occupation,member_type as 'Member Type' from family_members where dss_id_member='" + Convert.ToString(Session["DSS_Member"]) + "'");
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
                MySqlCommand cmdd = new MySqlCommand("select * from family_members where member_type='ch' and dss_id_m='" + lbe_DSSID_HH.Text + "' order by dss_id_member");
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
                MySqlCommand cmdd = new MySqlCommand("select *,(select count(*) from family_members where dss_id_member Like'" + Mthr + "%' and member_type='ch') as countChild  from family_members where dss_id_member='" + Mthr + "' order by dss_id_member");
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
            if (Convert.ToString(Session["WebPage3"]) == "WebForm1")
            {
                Session["WebPage3"] = null;
                Response.Redirect("WebForm1.aspx");
            }
            else if (Convert.ToString(Session["WebPage3"]) == "WebForm2")
            {
                Session["WebPage3"] = null;
                Response.Redirect("WebForm2.aspx");
            }
            else if (Convert.ToString(Session["WebPage3"]) == "WebForm4")
            {
                Session["WebPage3"] = null;
                Response.Redirect("WebForm4.aspx");
            }
            else if (Convert.ToString(Session["WebPage3"]) == "WebForm5")
            {
                Session["WebPage3"] = null;
                Response.Redirect("WebForm5.aspx");
            }
            else if (Convert.ToString(Session["WebPage3"]) == "WebForm6")
            {
                Session["WebPage3"] = null;
                Response.Redirect("WebForm6.aspx");
            }
            else
            {
                Response.Redirect("WebForm1.aspx");
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
                    lbe_DSSID_HH.Text = Convert.ToString(Session["DSS_Member"]);
                    ShowChildData();
                }
                else if (statusCell.Text == "h")
                {
                    statusCell.Text = "Husband";
                }
                else if (statusCell.Text == "ch")
                {
                    statusCell.Text = "Child";
                    lbe_DSSID_HH.Text = Convert.ToString(Session["DSS_Member"]);
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