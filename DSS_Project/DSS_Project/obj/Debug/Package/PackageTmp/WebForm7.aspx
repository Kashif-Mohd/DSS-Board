<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WebForm7.aspx.cs" Inherits="DSS_Project.WebForm7" %>

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

        .Grd {
            text-align: center;
        }
    </style>

    <script type="text/javascript">

        function onlyAlphabets(evt) {
            var charCode;
            if (window.event)
                charCode = window.event.keyCode;  //for IE
            else
                charCode = evt.which;  //for firefox
            if (charCode == 32) //for &lt;space&gt; symbol
                return true;
            if (charCode > 31 && charCode < 65) //for characters before 'A' in ASCII Table
                return false;
            if (charCode > 90 && charCode < 97) //for characters between 'Z' and 'a' in ASCII Table
                return false;
            if (charCode > 122) //for characters beyond 'z' in ASCII Table
                return false;
            return true;
        }
    </script>
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
                    <a class="active" href="javascript:;">
                        <i class="fa fa-th"></i>
                        <span>Tab Users</span>
                    </a>
                    <ul class="sub">
                        <li class="active"><a href="WebForm7.aspx">List of Users</a></li>
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

    <h3><b>Users Detail: </b></h3>
    <hr style="margin-top: -5px">

    <div style="text-align: center; width: 80%;margin-top: 30px; ">

        <asp:Panel ID="Panel1" runat="server" DefaultButton="btnSearch">
            <asp:TextBox ID="txtFullName" placeholder="Name or Region" ForeColor="#446CB3"  MaxLength="20" runat="server" Width="165px"></asp:TextBox>
            <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search" />
        
        <div style="text-align: right; margin-top: -22px">
            <asp:Button ID="Button2" Height="30px" CssClass="btn btn-success btn-sm" OnClick="Button2_Click" title="Export to Excel" runat="server" Text="Export to .xls" /></div>

        <div style="margin-top: -40px; padding-left:5px">
            <table style="width:15%; ">
                <tr>
                    <td style="text-align: left; ">Search by Name:</td><td>
            <asp:RadioButton ID="rbName" GroupName="opt" Checked="true" runat="server" /><br>
                    </td>
                    <tr>
                <tr>
                    <td style="text-align: left; ">Search by Region:</td><td>
            <asp:RadioButton ID="rbRegion" GroupName="opt" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
</asp:Panel>

        <br>
        <asp:GridView ID="GridView1" runat="server" EmptyDataText="No Record Found." CssClass="Grd footable" AllowPaging="True" PageSize="200" AllowSorting="True" ForeColor="#333333" AutoGenerateColumns="false">

            <Columns>
                <asp:TemplateField HeaderText="Serial No.">
                    <ItemTemplate>
                        <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                    <ItemStyle Width="10%" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Full Name">
                    <ItemTemplate>
                        <asp:LinkButton ID="Linkbutton1" OnClick="Link_Button1" Text='<%#Eval("full_name") %>' runat="server" ToolTip="Update Region">full_name</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="region_dss" HeaderText=" Region DSS" />
                <asp:BoundField DataField="site" HeaderText="Site" />
                <asp:BoundField DataField="username" HeaderText=" User Name" />
                <asp:BoundField DataField="password" HeaderText=" Password" />

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

        <asp:GridView ID="GridView2" runat="server" CssClass="footable" AllowPaging="True" AllowSorting="True" ForeColor="#333333" AutoGenerateColumns="false">
            <Columns>
                <asp:TemplateField HeaderText="Serial No.">
                    <ItemTemplate>
                        <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                    <ItemStyle Width="10%" />
                </asp:TemplateField>
                <asp:BoundField DataField="full_name" HeaderText="Full Name" />
                <asp:BoundField DataField="region_dss" HeaderText="Region DSS" />
                <asp:BoundField DataField="site" HeaderText="Site" />
                <asp:BoundField DataField="username" HeaderText="User Name" />
                <asp:BoundField DataField="password" HeaderText="Password" />

            </Columns>
        </asp:GridView>


    </div>
    <br>
    <br>
</asp:Content>
