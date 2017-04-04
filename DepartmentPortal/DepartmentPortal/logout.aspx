<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="logout.aspx.cs" Inherits="DepartmentPortal.logout" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>DDU</title>
    <meta charset="utf-8" />  
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/jquery-1.10.2.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <nav style="padding-top:2em; background-color:black" class="navbar navbar-inverse">
            <div class="container">
                <div class="navbar-header">
                    <a class="navbar-brand" href="<%= Server.MapPath("~/default.aspx") %>"><h1 class="navbar-text">Dharmsinh Desai University</h1></a>
                </div> 
            </div>                              
        </nav>

        <br /><br /><br />
        <div class="container text-center">
            <h3>You have been successfully logged out. Click <a href="Default.aspx">here</a> to go back to Home.</h3>
        </div>
    </div>

        <footer style="position:fixed; bottom:0; width:100%" class="container text-center">
                <hr />
                <p>&copy; <%: DateTime.Now.Year %> - Khushi Desai</p>
        </footer>
    
    </form>
</body>
</html>
