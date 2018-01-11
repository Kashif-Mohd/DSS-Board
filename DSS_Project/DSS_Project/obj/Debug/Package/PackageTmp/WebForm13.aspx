<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WebForm13.aspx.cs" Inherits="DSS_Project.WebForm13" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <style>
        .hedr {
            text-align: center;
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
                    <a  href="javascript:;">
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
                    <a class="active" href="javascript:;">
                        <i class="fa fa-tasks"></i>
                        <span>New Data</span>
                    </a>
                    <ul class="sub">
                        <li runat="server" id="NewWebF1"><a href="WebForm11.aspx">Family Members Data</a></li>
                        <li runat="server" id="NewWebF2"><a href="WebForm12.aspx">DSSID House Hold</a></li>
                        <li runat="server" id="NewWebF4"><a href="WebForm14.aspx">Married Women</a></li>
                        <li runat="server" id="NewWebF5"><a href="WebForm15.aspx">Children</a></li>
                        <li runat="server" id="NewWebF6"><a href="WebForm16.aspx">Mother by Child</a></li>
                    </ul>
                </li>
                <li class="sub-menu">
                    <a href="javascript:;">
                        <i class="fa fa-tasks"></i>
                        <span>Forms</span>
                    </a>
                    <ul class="sub">
                        <li><a href="WebForm17.aspx">Form1</a></li>
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
     <div style="margin-top: 10px;">
        <asp:ImageButton ID="ImageButton1" Height="18" Width="22" runat="server" OnClick="ImageButton1_Click" ImageUrl="~/assets/img/backbtna.png" />
    </div>
    <h3><b>DSSID Member: </b>
        <asp:Label ID="lbe_DSSID_HH" runat="server" ForeColor="gray" Text=""></asp:Label></h3>

    <hr style="margin-top: -10px">



    <asp:GridView ID="GridView1" runat="server" Width="65%" Font-Size="4.0mm" CssClass="footable" CellPadding="20" ForeColor="#333333" OnRowDataBound="OnRowDataBound" OnPageIndexChanging="GridView1_PageIndexChanging">
        <RowStyle BackColor="#67809F" ForeColor="WhiteSmoke" />

    </asp:GridView>
    <br>



    <asp:GridView ID="GridView2" runat="server" EmptyDataText="No Child records." Width="65%" Font-Size="4.0mm" CssClass="footable"  OnRowDataBound="OnRowDataBound1"  CellPadding="20" ForeColor="#333333"  AllowSorting="True" AutoGenerateColumns="false">
        <Columns>
            <asp:TemplateField HeaderText="Child No.">
                <ItemTemplate>
                    <%# Container.DataItemIndex + 1 %>
                </ItemTemplate>
                <ItemStyle Width="2%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="DSSID Child">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" OnClick="Link_Button1" Text='<%#Eval("dss_id_member") %>' runat="server"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="name" HeaderText="Name" />
            <asp:BoundField DataField="gender" HeaderText="Gender" />
            <asp:BoundField DataField="dob" HeaderText="Date of Birth" />
        </Columns>
        <RowStyle BackColor="#DADFE1" ForeColor="#284775" BorderColor="#52B3D9" />
        <HeaderStyle BackColor="#5D7B9D" ForeColor="white" Font-Bold="True" BorderColor="#81CFE0" />
    </asp:GridView>




    <asp:GridView ID="GridView3" runat="server" EmptyDataText="Mother is not in our record." Width="65%" Font-Size="4.0mm" CssClass="footable" CellPadding="20" ForeColor="#333333" AllowSorting="True" AutoGenerateColumns="false">
        <Columns>
            <asp:TemplateField HeaderText="DSSID Mother">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" OnClick="Link_Button1" Text='<%#Eval("dss_id_member") %>' runat="server"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="name" HeaderText="Mother Name" />
            <asp:BoundField DataField="dob" HeaderText="Date of Birth" />
            <asp:BoundField DataField="countChild" HeaderText="Total Child" />

        </Columns>
        <RowStyle BackColor="#DADFE1" ForeColor="#284775" BorderColor="#52B3D9" />
        <HeaderStyle BackColor="#5D7B9D" ForeColor="white" Font-Bold="True" BorderColor="#81CFE0" />
    </asp:GridView>
    <br>
</asp:Content>
