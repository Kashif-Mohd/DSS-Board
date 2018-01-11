<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WebForm8.aspx.cs" Inherits="DSS_Project.WebForm8" %>

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

        .btnSrch {
            background-color: #3498DB;
            border: 1px solid #2574A9;
            display: inline-block;
            cursor: pointer;
            color: white;
            font-family: arial;
            font-size: 13px;
            padding: 4px 35px;
            text-decoration: none;
            text-shadow: 0px 1px 0px #2f6627;
            border-radius: 3px;
            font-weight: bold;
        }

            .btnSrch:hover {
                background-color: #2574A9;
            }

            .btnSrch:active {
                position: relative;
                top: 1px;
            }
    </style>

    <script type="text/javascript">
        function upperCaseF(a) {
            setTimeout(function () {
                a.value = a.value.toUpperCase();
            }, 1);
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

    <div style="margin-top: 20px;">
        <asp:ImageButton ID="ImageButton1" Height="18" Width="22" runat="server" OnClick="ImageButton1_Click" ImageUrl="~/assets/img/backbtna.png" />
    </div>
    <h3><b>Update Region:</b>
        <asp:Label ID="lbe_FullName" runat="server" ForeColor="gray" Text=""></asp:Label></h3>

    <hr style="margin-top: 10px">

    <div style="padding-left: 6%; background-color: #E4F1FE; width: 38%; border-radius: 10px; box-shadow: inset 0 0 3px #bdc3c7, 0 0 5px #95a5a6;">
        <div style="margin-top: 25px">
            <asp:Panel ID="Panel1" runat="server" DefaultButton="btnUpdate">
                <table border="0" style="width: 100%; font-size: 16px; text-align: left; height: 40px;">
                    <tr style="height: 30px"></tr>
                    <tr style="height: 50px; margin-top: 20px;">
                        <td style="text-align: left">Full Name:</td>
                        <td style="font-family: Arial">
                            <asp:Label ID="lbeFullName" runat="server" Text="" Font-Size="16px" ForeColor="#446CB3"></asp:Label>
                    </tr>

                    <tr style="height: 50px;">
                        <td style="text-align: left">Username:</td>
                        <td style="font-family: Arial">
                            <asp:Label ID="lbeUsername" runat="server" Text="" Font-Size="16px" ForeColor="#446CB3"></asp:Label>
                    </tr>

                    <tr style="height: 50px;">
                        <td style="text-align: left">Password:</td>
                        <td style="font-family: Arial">
                            <asp:Label ID="lbePassword" runat="server" Text="" Font-Size="16px" ForeColor="#446CB3"></asp:Label>
                    </tr>


                    <tr style="height: 50px">
                        <td style="text-align: left">Region:</td>
                        <td style="font-family: Arial">
                            <asp:TextBox ID="txtRegion" Width="120" runat="server" placeholder="eg. ABCD12" MaxLength="6" Font-Size="13px"  ForeColor="#446CB3" onkeydown="upperCaseF(this)"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: center; padding-right: 20%; height: 100px">
                            <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" CssClass="btnSrch" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
    </div>
    <hr style="margin-top: 20px">
</asp:Content>
