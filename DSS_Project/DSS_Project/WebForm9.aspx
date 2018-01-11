<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WebForm9.aspx.cs" Inherits="DSS_Project.WebForm9" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .CapitalizeCase {
            text-transform: capitalize;
        }

        .btnSrch {
            background-color: #3498DB;
            border: 1px solid #2574A9;
            display: inline-block;
            cursor: pointer;
            color: white;
            font-family: arial;
            font-size: 13px;
            padding: 4px 38px;
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



        function lettersOnly() {
            var charCode = event.keyCode;

            if ((charCode > 64 && charCode < 91) || (charCode > 96 && charCode < 123) || charCode == 8)

                return true;
            else
                return false;
        }

        function OnlyNumeric(evt) {
            var theEvent = evt || window.event;
            var key = theEvent.keyCode || theEvent.which;
            key = String.fromCharCode(key);
            var regex = /[0-9]/;
            if (!regex.test(key)) {
                theEvent.returnValue = false;
                if (theEvent.preventDefault) theEvent.preventDefault();
            }
        }

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
                        <li><a href="WebForm7.aspx">List of Users</a></li>
                         <li><a href="WorkerPF.aspx">Worker Performance</a></li>
                        <li class="active"><a href="WebForm9.aspx">Add New User</a></li>
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
    <hr>
    <h3 style="padding-left: 12%"><b>Create New User</b></h3>
    <hr style="margin-top: 10px;">
    <br>
    <div style="padding-left: 5%;">
        <asp:Panel ID="Panel1" runat="server" DefaultButton="btnInsert">


            <table border="0" style="width: 40%; font-size: 15px; text-align: left">
                <tr style="height: 50px;">
                    <td style="text-align: left">Username:</td>
                    <td>
                        <asp:TextBox ID="txtUsername" Enabled="false" Width="190" runat="server" Font-Size="13px"></asp:TextBox></td>
                </tr>

                <tr style="height: 50px;">
                    <td style="text-align: left">Password:</td>
                    <td>
                        <asp:TextBox ID="txtPassword" Enabled="false" Width="190" runat="server" Font-Size="13px"></asp:TextBox></td>
                </tr>
                <tr style="height: 50px;">
                    <td style="text-align: left">Full Name:</td>
                    <td>
                        <asp:TextBox ID="txtFirstName" Width="90" runat="server" CssClass="CapitalizeCase" placeholder="First Name" Font-Size="13px" pattern="[a-zA-Z]{4,}" title="Minimum 4 characters can be enter only." ForeColor="#446CB3" onkeypress="return lettersOnly(event)" MaxLength="12"></asp:TextBox>
                        &nbsp         
                        <asp:TextBox ID="txtLastName" Width="90" runat="server" CssClass="CapitalizeCase" placeholder="Last Name" Font-Size="13px" pattern="[a-zA-Z]{3,}" title="Minimum 3 characters can be enter only." ForeColor="#446CB3" onkeypress="return lettersOnly(event)" MaxLength="12"></asp:TextBox></td>
                </tr>
                <tr style="height: 50px">
                    <td style="text-align: left">Employee No.:</td>
                    <td>
                        <asp:TextBox ID="txtEmployeeNo" Width="190" runat="server" pattern="[0-9]{6,}" title="Minimum 6 digit is required, except any symbols and characters." ForeColor="#446CB3" placeholder="eg. 123456" Font-Size="13px" onkeypress="return OnlyNumeric(event)" MaxLength="6"></asp:TextBox></td>
                </tr>
                                <tr style="height: 50px">
                    <td style="text-align: left">Site:</td>
                    <td>
                        <asp:TextBox ID="txtSite" Width="190" runat="server" ForeColor="#446CB3" placeholder="eg. RG,BH" Font-Size="13px" MaxLength="2" onkeypress="return lettersOnly(event)" style="text-transform:uppercase"></asp:TextBox></td>
                </tr>

                <tr style="height: 50px">
                    <td style="text-align: left">Region:</td>
                    <td>
                        <asp:TextBox ID="txtRegion" Width="190" runat="server" ForeColor="#446CB3" placeholder="eg. ABCD12" Font-Size="13px" MaxLength="6" onkeydown="upperCaseF(this)"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center; padding-right: 80px; height: 100px">
                        <asp:Button ID="btnInsert" runat="server" Text="Sign Up" OnClick="btnInsert_Click" CssClass="btnSrch" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
    <hr>
    <br>
</asp:Content>
