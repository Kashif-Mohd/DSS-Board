<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WebForm16.aspx.cs" Inherits="DSS_Project.WebForm16" %>
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
                    <a  class="active" href="javascript:;">
                        <i class="fa fa-tasks"></i>
                        <span>New Data</span>
                    </a>
                    <ul class="sub">
                        <li><a href="WebForm11.aspx">Family Members Data</a></li>
                        <li><a href="WebForm12.aspx">DSSID House Hold</a></li>
                        <li><a href="WebForm14.aspx">Married Women</a></li>
                        <li><a href="WebForm15.aspx">Children</a></li>
                        <li class="active"><a href="WebForm16.aspx">Mother by Child</a></li>
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
    <h3><b>Mother and their Child: </b></h3>
    <hr style="margin-top: -10px">

    <div style="text-align: center; margin-top: 0px">
        <asp:Panel ID="Panel1" runat="server" DefaultButton="btnSearch">
            <asp:TextBox ID="txtDSSChild" MaxLength="15" placeholder="DSSID Child" ForeColor="#446CB3"  runat="server" Width="165px"></asp:TextBox>
            <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search" />
        </asp:Panel>
    </div>

    <br>

    <asp:GridView ID="GridView1" runat="server" EmptyDataText="No Record Found." CssClass="footable" AllowPaging="True" PageSize="200" AllowSorting="True" ForeColor="#333333" AutoGenerateColumns="false">

        <Columns>
            <asp:TemplateField HeaderText="Serial No.">
                <ItemTemplate>
                    <%# Container.DataItemIndex + 1 %>
                </ItemTemplate>
                <ItemStyle Width="2%" />
            </asp:TemplateField>
            <asp:BoundField DataField="child_name" HeaderText="Child Name" />

            <asp:TemplateField HeaderText="DSSID Child">
                <ItemTemplate>
                    <asp:LinkButton ID="Linkbutton1" OnClick="Link_Button1" Text='<%#Eval("child_id") %>' runat="server"  ToolTip="Child Detail">child_id</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="mother_name" HeaderText="Mother Name" />
            <asp:TemplateField HeaderText="DSSID Mother">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton2" OnClick="Link_Button2" Text='<%#Eval("mother_id") %>' runat="server"  ToolTip="Mother Detail">mother_id</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="date_of_birth" HeaderText="Date of Birth" />
            <asp:BoundField DataField="no_of_children" HeaderText="Number of Child" />
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



    <br>
    <br>
    <br>
</asp:Content>
