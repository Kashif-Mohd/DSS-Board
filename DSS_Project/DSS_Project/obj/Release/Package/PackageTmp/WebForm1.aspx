<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="DSS_Project.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <style>
        .StylePager a:hover {
            background-color: #52B3D9;
             margin-right:3px;
        }
        .StylePager a {
             margin-right:3px;
        }
        .StylePager span {
            background:green;
             margin-right:3px;
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
                    <a href="#">
                        <i class="fa fa-dashboard"></i>
                        <span>Dashboard</span>
                    </a>
                </li>

                <li class="sub-menu">
                    <a href="javascript:;">
                        <i class="fa fa-desktop"></i>
                        <span>UI Elements</span>
                    </a>
                    <ul class="sub">
                        <li><a href="#">General</a></li>
                        <li><a href="#">Buttons</a></li>
                        <li><a href="#">Panels</a></li>
                    </ul>
                </li>

                <li class="sub-menu">
                    <a class="active" href="javascript:;">
                        <i class="fa fa-tasks"></i>
                        <span>Forms</span>
                    </a>
                    <ul class="sub">
                        <li class="active"><a href="WebForm1.aspx">Family Members Data</a></li>
                        <!--li><a href="WebForm2.aspx">Show by DSSID HH</a></li-->

                    </ul>
                </li>
                <li class="sub-menu">
                    <a href="javascript:;">
                        <i class="fa fa-th"></i>
                        <span>Data Tables</span>
                    </a>
                    <ul class="sub">
                        <li><a href="#">Basic Table</a></li>
                        <li><a href="#">Responsive Table</a></li>
                    </ul>
                </li>
                <li class="sub-menu">
                    <a href="javascript:;">
                        <i class="fa fa-cogs"></i>
                        <span>Setting</span>
                    </a>
                    <ul class="sub">
                        <li><a href="#">Profile</a></li>
                        <li><a href="#">Todo List</a></li>
                    </ul>
                </li>

            </ul>
            <!-- sidebar menu end-->
        </div>
    </aside>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <h2><b>Family Member Data: </b></h2>
    <hr style="margin-top:-10px">
    <asp:GridView ID="GridView1" runat="server" CssClass="footable" AllowPaging="True" PageSize="200" OnPageIndexChanging="GridView1_PageIndexChanging" AllowSorting="True" ForeColor="#333333"  AutoGenerateColumns="false">

        <Columns>
            <asp:BoundField DataField="_idpk" HeaderText="ID" />
            <asp:BoundField DataField="_date" HeaderText="Date" />
            <asp:TemplateField HeaderText="dss_id_hh">
                <ItemTemplate>
                    <asp:LinkButton ID="Linkbutton1" OnClick="Link_Button1" Text='<%#Eval("dss_id_hh") %>' runat="server"><%#Eval("dss_id_hh") %></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="dss_id_f" HeaderText="dss_id_f" />
            <asp:BoundField DataField="dss_id_m" HeaderText="dss_id_m" />
            <asp:BoundField DataField="dss_id_h" HeaderText="dss_id_h" />
            <asp:BoundField DataField="dss_id_member" HeaderText="dss_id_member" />
            <asp:BoundField DataField="prevs_dss_id_member" HeaderText="prevs_dss_id_member" />
            <asp:BoundField DataField="site_code" HeaderText="site_code" />
            <asp:BoundField DataField="name" HeaderText="name" />
            <asp:BoundField DataField="dob" HeaderText="dob" />
            <asp:BoundField DataField="age" HeaderText="age" />
            <asp:BoundField DataField="gender" HeaderText="gender" />
            <asp:BoundField DataField="is_head" HeaderText="is_head" />
            <asp:BoundField DataField="relation_hh" HeaderText="relation_hh" />
            <asp:BoundField DataField="current_status" HeaderText="current_status" />
            <asp:BoundField DataField="current_date" HeaderText="current_date" />
            <asp:BoundField DataField="dod" HeaderText="dod" />
            <asp:BoundField DataField="m_stautus" HeaderText="m_stautus" />
            <asp:BoundField DataField="education" HeaderText="education" />
            <asp:BoundField DataField="occupation" HeaderText="occupation" />
            <asp:BoundField DataField="member_type" HeaderText="member_type" />


        </Columns>
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />

        <HeaderStyle BackColor="#5D7B9D" ForeColor="white" Font-Bold="True" />
        <PagerSettings Position="TopAndBottom" Mode="NumericFirstLast" PreviousPageText="&amp;lt;" PageButtonCount="13" />
        <PagerStyle BackColor="#284775" ForeColor="White" CssClass="StylePager" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />



    </asp:GridView>
</asp:Content>
