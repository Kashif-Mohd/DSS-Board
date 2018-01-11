<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WebForm17.aspx.cs" Inherits="DSS_Project.WebForm17" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <style>
        .StylePager a:hover {
            background-color: #52B3D9;
            margin-right: 3px;
        }

        .StylePager a {
            margin-right: 3px;
        }

        .StylePager span {
            background: green;
            margin-right: 3px;
        }
    </style>


     <aside>
        <div id="sidebar" class="nav-collapse ">
            <!-- sidebar menu start-->
            <ul class="sidebar-menu" id="nav-accordion">

                <p class="centered">
                    <img src="assets/img/aku_logo.png" class="img-circle" width="110">
                </p>
                <h5 class="centered">Aga Khan Unversity (AKU)</h5>

                <li class="mt">
                    <a href="WebForm18.aspx">
                        <i class="fa fa-dashboard"></i>
                        <span>Dashboard</span>
                    </a>
                </li>

                <!--li class="sub-menu">
                    <a href="javascript:;">
                        <i class="fa fa-desktop"></i>
                        <span>UI Elements</span>
                    </a>
                    <ul class="sub">
                        <li><a href="#">General</a></li>
                        <li><a href="#">Buttons</a></li>
                        <li><a href="#">Panels</a></li>
                    </ul>
                </!--li-->

                <li class="sub-menu">
                    <a href="javascript:;">
                        <i class="fa fa-tasks"></i>
                        <span>Old Data</span>
                    </a>
                    <ul class="sub">
                        <li><a href="WebForm1.aspx">Family Members Data</a></li>
                        <li><a href="WebForm2.aspx">DSSID House Hold</a></li>
                        <li><a href="WebForm4.aspx">Married Women</a></li>
                        <li><a href="WebForm5.aspx">Children</a></li>
                        <li><a href="WebForm6.aspx">Mother by Child</a></li>
                    </ul>
                </li>

                 <li class="sub-menu">
                    <a href="javascript:;">
                        <i class="fa fa-tasks"></i>
                        <span>New Data</span>
                    </a>
                    <ul class="sub">
                        <li><a href="WebForm11.aspx">Family Members Data</a></li>
                        <li><a href="WebForm12.aspx">DSSID House Hold</a></li>
                        <li><a href="WebForm14.aspx">Married Women</a></li>
                        <li><a href="WebForm15.aspx">Children</a></li>
                        <li><a href="WebForm16.aspx">Mother by Child</a></li>
                    </ul>
                </li>
                <li class="sub-menu">
                    <a  class="active" href="javascript:;">
                        <i class="fa fa-tasks"></i>
                        <span>Forms</span>
                    </a>
                    <ul class="sub">
                        <li class="active"><a href="WebForm17.aspx">Form1</a></li>
                    </ul>
                </li>

                 <li class="sub-menu">
                    <a href="javascript:;">
                        <i class="fa fa-tasks"></i>
                        <span>Errors</span>
                    </a>
                    <ul class="sub">
                        <li><a href="WebForm19.aspx">Error Forms</a></li>
                    </ul>
                </li>

                <li class="sub-menu">
                    <a href="javascript:;">
                        <i class="fa fa-th"></i>
                        <span>Tab Users</span>
                    </a>
                    <ul class="sub">
                        <li><a href="WebForm7.aspx">List of Users</a></li>
                         <li><a href="WorkerPF.aspx">Worker Performance</a></li>
                        <li><a href="WebForm9.aspx">Add New User</a></li>
                    </ul>
                </li>
                <li class="sub-menu">
                    <a href="javascript:;">
                        <i class="fa fa-cogs"></i>
                        <span>Setting</span>
                    </a>
                    <ul class="sub">
                        <li><a href="WebForm10.aspx">Change Password</a></li>
                        <li><a href="#">Todo List</a></li>
                    </ul>
                </li>

            </ul>
            <!-- sidebar menu end-->
        </div>
    </aside>
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
   
     <div style="margin-top: 5px;">
        <asp:ImageButton ID="ImageButton1" title="back" Height="18" Width="22" runat="server" OnClick="ImageButton1_Click" ImageUrl="~/assets/img/backbtna.png" />
    </div>

     <h3><b>Form 1: </b> <asp:Label ID="lbe_DSSID" runat="server" ForeColor="gray" Text=""></asp:Label></h3>
    <hr style="margin-top: -10px">

    <br>
        <div style="width: 100%; height: 100%; overflow: auto; overflow-y: hidden;">

    <asp:GridView ID="GridView1" runat="server" EmptyDataText="No Record Found." CssClass="footable" AllowPaging="True" PageSize="200" OnPageIndexChanging="GridView1_PageIndexChanging"   AllowSorting="True" ForeColor="#333333"  AutoGenerateColumns="false">

          <Columns>              
              
                <asp:BoundField HeaderText="col_id" DataField="col_id" />
                <asp:BoundField HeaderText="col_dt" DataField="col_dt" />
                <asp:BoundField HeaderText="_id" DataField="_id" />
                <asp:BoundField HeaderText="_uid" DataField="_uid" />
                <asp:BoundField HeaderText="isnew" DataField="isnew" />
                <asp:BoundField HeaderText="dssid" DataField="dssid" />
                <asp:BoundField HeaderText="formdate" DataField="formdate"/>
                <asp:BoundField HeaderText="user" DataField="user" />
                <asp:BoundField HeaderText="istatus" DataField="istatus" />
                <asp:BoundField HeaderText="gpslat" DataField="gpslat" />
                <asp:BoundField HeaderText="gpslng" DataField="gpslng" />
                <asp:BoundField HeaderText="gpsdate" DataField="gpsdate" />
                <asp:BoundField HeaderText="gpsacc" DataField="gpsacc" />
                <asp:BoundField HeaderText="deviceid" DataField="deviceid" />
              <asp:BoundField HeaderText="tagid" DataField="tagid" />  
              <asp:BoundField HeaderText="synced" DataField="synced" />
                <asp:BoundField HeaderText="synced_date" DataField="synced_date" />                           
            </Columns>     

        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" ForeColor="white" Font-Bold="True"  Height="30px"/>
        <PagerSettings Position="TopAndBottom" Mode="NumericFirstLast" PreviousPageText="&amp;lt;" PageButtonCount="13" />
        <PagerStyle BackColor="#284775" ForeColor="White" CssClass="StylePager" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />       
    </asp:GridView>
     </div>
    
    <br>
    <br>
</asp:Content>
