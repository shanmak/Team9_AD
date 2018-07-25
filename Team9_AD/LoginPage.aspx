<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="Team9_AD.Login_page" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   
    <%--<meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">--%>
    <title>Login Page</title>
    <link rel="stylesheet" href="assets/bootstrap/css/bootstrap.min.css"/>
    <link rel="stylesheet" href="assets/fonts/ionicons.min.css"/>
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Abel"/>
    <link rel="stylesheet" href="assets/css/Footer-Dark.css"/>
    <link rel="stylesheet" href="assets/css/Login-Form-Dark.css"/>
    <link rel="stylesheet" href="assets/css/Navigation-Clean.css"/>
    <link rel="stylesheet" href="assets/css/styles.css"/>

    <script src="assets/js/jquery.min.js"></script>
    <script src="assets/bootstrap/js/bootstrap.min.js"></script>

</head>
<body>
     <div class="login-dark">
        <nav class="navbar navbar-light navbar-expand-md" style="background-color:#ffffff;">
            <div class="container-fluid"><a class="navbar-brand" href="#" style="font-weight:bold;font-size:40px;font-family:Abel, sans-serif;"><img src="assets/img/LOGO.jpg">LOGIC UNIVERSITY</a>
                <div
                    class="collapse navbar-collapse" id="navcol-1"></div>
    </div>
    </nav>
    <form method="post" runat="server">
        <div class="illustration"><i class="icon ion-ios-locked-outline"></i></div>
        <div class="form-group"><input class="form-control" type="text" name="ID"  placeholder="ID" id="username" runat="server"/>
           <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Enter UserID" ControlToValidate="username"></asp:RequiredFieldValidator>--%>

       &nbsp;<input class="form-control" type="password" name="password"  required="" placeholder="Password" id="password" runat="server"/></div>
       <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Enter Password" ControlToValidate="password"></asp:RequiredFieldValidator>--%>
        <div class="form-group"><asp:Button class="btn btn-primary btn-block" type="submit" runat="server" Text="Log In" OnClick="Login_Click"></asp:Button></div><a href="#" class="forgot">Forgot your ID or password?</a>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </form>
    </div>

    <div class="footer-dark">
        <footer>
            <div class="container">
                <div class="row">
                    <div class="col-sm-6 col-md-3 item">
                        <h3>Contact Us</h3>
                        <ul>
                            <li><a href="#">25 Heng Mui Keng Terrace</a></li>
                            <li><a href="#">119615</a></li>
                        </ul>
                    </div>
                    <div class="col-sm-6 col-md-3 item">
                        <h3>Users</h3>
                        <ul>
                            <li><a href="#">Employees</a></li>
                            <li><a href="#">Department Head</a></li>
                            <li><a href="#">Department Rep</a></li>
                            <li><a href="#">Supervisor</a></li>
                            <li><a href="#">Manager</a></li>
                            <li><a href="#">Clerk</a></li>
                        </ul>
                    </div>
                    <div class="col-md-6 item text">
                        <h3>Team Members</h3>
                        <p id="teammembers" style="font-size:14px;">Ayyakkannu&nbsp;Priyasangeetha,&nbsp;Hunasavally&nbsp;Virupaksha&nbsp;Dhanya,&nbsp;<br>Krriti Ravikumar,&nbsp;Padmashri Narendran,&nbsp;Prasanth Raju,&nbsp;Santhosh&nbsp;Manivannan,&nbsp;Shanmugam&nbsp;Manikandan, Subash&nbsp;Machavel
                            and Sundarababu Surendran<br></p>
                    </div>
                </div>
                <p class="copyright">AD PROJECT TEAM-9 (SA46) © 2018</p>
            </div>
        </footer>
    </div>
    
</body>
</html>
