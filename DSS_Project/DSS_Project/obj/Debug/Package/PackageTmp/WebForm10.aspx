<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WebForm10.aspx.cs" Inherits="DSS_Project.WebForm10" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
       

        .btnSrch {
            background-color: #3498DB;
            border: 1px solid #2574A9;
            display: inline-block;
            cursor: pointer;
            color: white;
            font-family: arial;
            font-size: 13px;
            padding: 4px 20px;
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
                    <a class="active" href="javascript:;">
                        <i class="fa fa-cogs"></i>
                        <span>Setting</span>
                    </a>
                    <ul class="sub">
                        <li class="active"><a href="WebForm10.aspx">Change Password</a></li>
                        <li><a href="#">Todo List</a></li>
                    </ul>
                </li>

            </ul>
            <!-- sidebar menu end-->
        </div>
    </aside>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
       <hr>
    <h3 style="padding-left: 5%"><b>Resetting Your Login Password</b></h3>
    <hr style="margin-top: 10px;">
    <br>
    <div style="padding-left: 5%;">
        <asp:Panel ID="Panel1" runat="server" DefaultButton="btnInsert">


            <table border="0" style="width: 38%; font-size: 15px; text-align: left">
                <tr style="height: 50px;">
                    <td style="text-align: left">User Name:</td>
                    <td style="text-align: left">
                 <asp:Label ID="lbeFullName" runat="server" Text="" Font-Names="Calibri" Font-Size="22px" Font-Bold="true" ForeColor="#446CB3"></asp:Label>
                    </td>
                </tr>

                <tr style="height: 50px;">
                    <td style="text-align: left">Enter Old Password:</td>
                    <td>
                        <asp:TextBox ID="txtOldPassword" type="password" placeholder="old password" MaxLength="18" Width="160"  runat="server" Font-Size="13px"></asp:TextBox></td>
                </tr>
                                <tr style="height: 50px;">
                    <td style="text-align: left">Enter New Password:</td>
                    <td>
                        <asp:TextBox ID="txtNewPassword" type="password" placeholder="new password" MaxLength="18" Width="160" runat="server" Font-Size="13px"></asp:TextBox></td>
                </tr>
                <tr style="height: 50px;">
                    <td style="text-align: left">Re-type Password:</td>
                    <td>
                        <asp:TextBox ID="txtConfirmPassword" type="password" placeholder="confirm password" MaxLength="18" Width="160" runat="server" Font-Size="13px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center; padding-right: 70px; height: 110px">
                        <asp:Button ID="btnInsert" runat="server" Text="Confirm" OnClick="btnInsert_Click" CssClass="btnSrch" Width="95" />
                        &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                        <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" CssClass="btnSrch" Width="95"/>
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
    <hr>
    <br>
</asp:Content>
