<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WebForm12.aspx.cs" Inherits="DSS_Project.WebForm12" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .headrgrd {
            margin-bottom: 3px;
        }

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
                </li-->

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
                       <li><a href="WebForm11.aspx">Family Members Data</a></li>
                        <li class="active"><a href="WebForm12.aspx">DSSID House Hold</a></li>
                        <li><a href="WebForm14.aspx">Married Women</a></li>
                        <li><a href="WebForm15.aspx">Children</a></li>
                        <li><a href="WebForm16.aspx">Mother by Child</a></li>
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
    <div style="margin-top: 5px;">
        <asp:ImageButton ID="ImageButton1" title="back" Height="18" Width="22" runat="server" OnClick="ImageButton1_Click" ImageUrl="~/assets/img/backbtna.png" />
    </div>


    <h3><b>New DSSID House Hold:</b>
        <asp:Label ID="lbe_DSSID_H" runat="server" ForeColor="gray" Text=""></asp:Label></h3>
    <hr style="margin-top: -10px">


    <div style="text-align: center; margin-top: 0px">
        <asp:Panel ID="Panel1" runat="server" DefaultButton="Button1">
            <asp:TextBox ID="txtDSSMember" placeholder="DSSID Member" ForeColor="#446CB3"  MaxLength="15" runat="server" Width="165px"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Search" />
        </asp:Panel>
    </div>

    <div style="text-align: right; margin-top: -15px">
        <asp:Button ID="Button2" title="Export to Excel" Height="30px" CssClass="btn btn-success btn-sm" OnClick="Button2_Click" runat="server" Text="Export to .xls" />
    </div>

    <br>
    <div style="width: 100%; height: 100%; overflow: auto; overflow-y: hidden;">

        <asp:GridView ID="GridView1" runat="server" EmptyDataText="No Record Found." AllowPaging="True" PageSize="200" CssClass="footable headrgrd" CellPadding="4" ForeColor="#333333" OnRowDataBound="OnRowDataBound" OnPageIndexChanging="GridView1_PageIndexChanging" AutoGenerateColumns="false">
            <Columns>
                <asp:TemplateField HeaderText="Serial No.">
                    <ItemTemplate>
                        <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                    <ItemStyle Width="2%" />
                </asp:TemplateField>
                <asp:BoundField DataField="﻿col_id" HeaderText="Col ID" />
                <asp:BoundField DataField="col_dt" HeaderText="Col Date" />
                <asp:BoundField DataField="id" HeaderText="ID" />
                <asp:BoundField DataField="refid" HeaderText="Ref ID" />
                <asp:BoundField DataField="uid" HeaderText="UID" />
                <asp:BoundField DataField="uuid" HeaderText="UUID" />
                <asp:BoundField DataField="date" HeaderText="Date" />
                <asp:BoundField DataField="formdate" HeaderText="Form Date" />
                <asp:BoundField DataField="deviceid" HeaderText="Device ID" />
                <asp:BoundField DataField="user" HeaderText="User" />
                <asp:BoundField DataField="dss_id_hh" HeaderText="DSSID House Hold" />
                <asp:BoundField DataField="dss_id_f" HeaderText="DSSID Father" />
                <asp:BoundField DataField="dss_id_m" HeaderText="DSSID Mother" />
                <asp:BoundField DataField="dss_id_h" HeaderText="DSSID Head" />
                <asp:TemplateField HeaderText="DSSID Member">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" OnClick="Link_Button1" Text='<%#Eval("dss_id_member") %>' runat="server" ToolTip="Member Detail"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="prevs_dss_id_member" HeaderText="Previous DSSID Member" />
                <asp:BoundField DataField="site_code" HeaderText="Site Code" />
                <asp:BoundField DataField="name" HeaderText="Name" />
                <asp:BoundField DataField="dob" HeaderText="Date of Birth" />
                <asp:BoundField DataField="agey" HeaderText="Agey" />
                <asp:BoundField DataField="agem" HeaderText="Agem" />
                <asp:BoundField DataField="aged" HeaderText="Aged" />
                <asp:BoundField DataField="gender" HeaderText="Gender" />
                <asp:BoundField DataField="is_head" HeaderText="is head" />
                <asp:BoundField DataField="relation_hh" HeaderText="Relation HH" />
                <asp:BoundField DataField="current_status" HeaderText="Current Status" />
                <asp:BoundField DataField="current_statusx" HeaderText="Current Status X" />
                <asp:BoundField DataField="dod" HeaderText="DOD" />
                <asp:BoundField DataField="m_status" HeaderText="M Status" />
                <asp:BoundField DataField="education" HeaderText="Education" />
                <asp:BoundField DataField="educationx" HeaderText="Education X" />
                <asp:BoundField DataField="occupation" HeaderText="Occupation" />
                <asp:BoundField DataField="occupationx" HeaderText="Occupation X" />
                <asp:BoundField DataField="member_type" HeaderText="Member Type" />
                <asp:BoundField DataField="updated_flag" HeaderText="Updated Flag" />
                <asp:BoundField DataField="update_date" HeaderText="Updated Date" />
                <asp:BoundField DataField="synced" HeaderText="Synced" />
                <asp:BoundField DataField="sync_date" HeaderText="Sync Date" />
                <asp:BoundField DataField="remarks" HeaderText="Remarks" />
                <asp:BoundField DataField="project_name" HeaderText="Project Name" />
                <asp:BoundField DataField="currentdate" HeaderText="Current Date" />
            </Columns>
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerSettings Position="TopAndBottom" Mode="NumericFirstLast" PreviousPageText="&amp;lt;" PageButtonCount="13" />
            <PagerStyle BackColor="#284775" ForeColor="White" CssClass="StylePager" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>



        <asp:GridView ID="GridView2" runat="server" CssClass="footable" AllowPaging="True" PageSize="200" OnRowDataBound="OnRowDataBound" OnPageIndexChanging="GridView1_PageIndexChanging" AllowSorting="True" ForeColor="#333333" AutoGenerateColumns="false">
          <Columns>
                <asp:TemplateField HeaderText="Serial No.">
                    <ItemTemplate>
                        <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                    <ItemStyle Width="2%" />
                </asp:TemplateField>
                <asp:BoundField DataField="﻿col_id" HeaderText="Col ID" />
                <asp:BoundField DataField="col_dt" HeaderText="Col Date" />
                <asp:BoundField DataField="id" HeaderText="ID" />
                <asp:BoundField DataField="refid" HeaderText="Ref ID" />
                <asp:BoundField DataField="uid" HeaderText="UID" />
                <asp:BoundField DataField="uuid" HeaderText="UUID" />
                <asp:BoundField DataField="date" HeaderText="Date" />
                <asp:BoundField DataField="formdate" HeaderText="Form Date" />
                <asp:BoundField DataField="deviceid" HeaderText="Device ID" />
                <asp:BoundField DataField="user" HeaderText="User" />
                <asp:BoundField DataField="dss_id_hh" HeaderText="DSSID House Hold" />
                <asp:BoundField DataField="dss_id_f" HeaderText="DSSID Father" />
                <asp:BoundField DataField="dss_id_m" HeaderText="DSSID Mother" />
                <asp:BoundField DataField="dss_id_h" HeaderText="DSSID Head" />
                <asp:BoundField DataField="dss_id_member" HeaderText="DSSID Member" />
                <asp:BoundField DataField="prevs_dss_id_member" HeaderText="Previous DSSID Member" />
                <asp:BoundField DataField="site_code" HeaderText="Site Code" />
                <asp:BoundField DataField="name" HeaderText="Name" />
                <asp:BoundField DataField="dob" HeaderText="Date of Birth" />
                <asp:BoundField DataField="agey" HeaderText="Agey" />
                <asp:BoundField DataField="agem" HeaderText="Agem" />
                <asp:BoundField DataField="aged" HeaderText="Aged" />
                <asp:BoundField DataField="gender" HeaderText="Gender" />
                <asp:BoundField DataField="is_head" HeaderText="is head" />
                <asp:BoundField DataField="relation_hh" HeaderText="Relation HH" />
                <asp:BoundField DataField="current_status" HeaderText="Current Status" />
                <asp:BoundField DataField="current_statusx" HeaderText="Current Status X" />
                <asp:BoundField DataField="dod" HeaderText="DOD" />
                <asp:BoundField DataField="m_status" HeaderText="M Status" />
                <asp:BoundField DataField="education" HeaderText="Education" />
                <asp:BoundField DataField="educationx" HeaderText="Education X" />
                <asp:BoundField DataField="occupation" HeaderText="Occupation" />
                <asp:BoundField DataField="occupationx" HeaderText="Occupation X" />
                <asp:BoundField DataField="member_type" HeaderText="Member Type" />
                <asp:BoundField DataField="updated_flag" HeaderText="Updated Flag" />
                <asp:BoundField DataField="update_date" HeaderText="Updated Date" />
                <asp:BoundField DataField="synced" HeaderText="Synced" />
                <asp:BoundField DataField="sync_date" HeaderText="Sync Date" />
                <asp:BoundField DataField="remarks" HeaderText="Remarks" />
                <asp:BoundField DataField="project_name" HeaderText="Project Name" />
                <asp:BoundField DataField="currentdate" HeaderText="Current Date" />
            </Columns>
        </asp:GridView>

    </div>
    <br>
    <br>
    <br>
    <br>
</asp:Content>
