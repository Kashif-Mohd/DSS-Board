<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DSS_Project.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">


    <title>DSS Project</title>
     <link runat="server" rel="icon" href="~/assets/img/icon.ico" type="image/ico" />
    <!-- Bootstrap core CSS -->
    <link href="assets/css/bootstrap.css" rel="stylesheet">
    <!--external css-->
    <link href="assets/font-awesome/css/font-awesome.css" rel="stylesheet" />
        
    <!-- Custom styles for this template -->
    <link href="assets/css/style.css" rel="stylesheet">
    <link href="assets/css/style-responsive.css" rel="stylesheet">

</head>
<body>
    
	  
	  
	  <div id="login-page" >
	

		      <form class="form-login" runat="server" style="background-color:#41495c;border-top-left-radius: 6px;border-top-right-radius: 6px;box-shadow: inset 0 0 1px #bdc3c7, 0 0 3px #95a5a6;"  >
			     <div style=" background-color:#f5d56e;border-top-left-radius: 5px;border-top-right-radius: 5px; padding-top:30px; height:50px">
			                  <h2 style="text-align: center; font-size:19px; word-spacing:5px;  color:#34495e;font-family:arial;margin-top:-13px;text-transform: capitalize;"><b> DSS PROJECT (AKU)</b></h2>
				</div>
		        <h2 class="form-login-heading" style="border-top-left-radius: 0px;border-top-right-radius: 0px;">sign in now</h2>

				<br>
		        <div class="login-wrap">
                    <asp:TextBox ID="txtUserNme" runat="server" class="form-control" placeholder="User ID"  MaxLength="30"></asp:TextBox>
		            <br>
                <asp:TextBox ID="txtPass" runat="server" type="password" class="form-control" placeholder="Password" MaxLength="18"></asp:TextBox>

					<br><br><br>

                    <asp:Button ID="btnLogin" runat="server"  onclick="btnLogin_Click" class="btn btn-theme btn-block" Text="SIGN IN" />
		            <br>
		            <hr style="margin-bottom:10px">
		<a href="https://www.aku.edu/Pages/home.aspx" target="_blank" style="color: #BFBFBF; text-align:center; font-size:10px; margin-left:19%; font-family:Arial">The Aga Khan Unversity Hospital (AKU)</a>
		        </div>
		
		      </form>	  	
	  	</div>


    <!-- js placed at the end of the document so the pages load faster -->
    <script src="assets/js/jquery.js"></script>
    <script src="assets/js/bootstrap.min.js"></script>

    <!--BACKSTRETCH-->
    <!-- You can use an image of whatever size. This script will stretch to fit in any screen size.-->
    <script type="text/javascript" src="assets/js/jquery.backstretch.min.js"></script>
    <script>
        $.backstretch("assets/img/akupic.jpg", { speed: 500 });
    </script>
</body>
</html>
