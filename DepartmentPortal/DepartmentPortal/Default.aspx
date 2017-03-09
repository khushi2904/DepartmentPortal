<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DepartmentPortal.Default" %>
<%@ Register Assembly="BotDetect" Namespace="BotDetect.Web.UI"  TagPrefix="BotDetect" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>DDU</title>
    <meta charset="utf-8" />  

    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/jquery-1.10.2.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    
</head>
<body style="background-color:#ffffff">
    <form id="form1" runat="server">
    

        <nav style="padding-top:1em; padding-bottom:1em; background-color:#000000" class="navbar navbar-default">
            <div class="container">
                <div class="navbar-header">
                    <a class="navbar-brand" href="Default.aspx"><p style="color:#dfcece; font-size:45px; margin-top:28px">Dharmsinh Desai University</p></a>
                </div>                    
             </div>                                            
        </nav>

        <div class="container form-horizontal" style="padding-top:1em;">

        <div class="row text-center">
        <div class="col-sm-4">
        </div>
        
        <div class="col-sm-4" style="border-style:solid; padding-left:20px; padding-right:20px; padding-bottom:10px">

        
                <h2>Login</h2>
                                    
                    <div class="form-group-lg">
                            <asp:TextBox ID="txtid" runat="server" Height="40px" class="form-control" placeholder="Enter ID"></asp:TextBox>
                    </div>
                    <br />
                    
                    <div class="form-group-lg">
                            <asp:TextBox ID="txtpass" runat="server" Height="40px" class="form-control" TextMode="Password" placeholder="Enter Password"></asp:TextBox>
                    </div>
                    <br />

                    <div class="form-group-lg">
                       <BotDetect:WebFormsCaptcha ID="ExampleCaptcha" runat="server" /><br />
                            <asp:TextBox ID="CaptchaCodeTextBox" Height="40px" class="form-control" placeholder="Enter Captcha Text" runat="server" />
                    </div>
                    <br />

                    <div class="form-group-lg">
                            <asp:Button ID="btnlogin" runat="server" Width="150px" Height="40px" class="btn btn-default btn-lg" Text="Login" OnClick="btnlogin_Click" />
                    </div>
                    <br />
                            
                    <div class="form-group-lg">
                        <asp:LinkButton ID="lbtnforgotpassword" OnClick="lbtnforgotpassword_Click" runat="server">Forgotten Password?</asp:LinkButton>
                    </div>        

            <br />
            <asp:Label ID="lblerror" runat="server" Text="" ForeColor="Red"></asp:Label>

            </div>
        <div class="col-sm-4"></div>
    </div>
    

    </div>
    <br /><br />
      
        <div style="background-color:#f0b04b; padding:10px" class="text-center">
                    <h3>Explore the power of simpler and smarter services</h3>
                    <h4>24x7 access to a wide range of transactions</h4>
                    <h4>Grow your money with smart ways to invest online</h4>
                    <p style="font-size:10px"><i>Customer ID is mandatory for online registration.<br /> To avail a new Customer ID, register at the nearest NTKV Bank branch.</i></p>

        </div>



        <div class="container-fluid text-center" style="padding-top:0.5em; color:#dfcece;background-color:black">
            <p style="font-size:x-large"><u>About</u></p>
            <p>Online Department Portal<br />
               Software Developmet Project<br />
            </p>
            <hr />
            <p style="font-size:x-large">
               <u>Created By - </u>
            </p>
            <p>Khushi Desai (CE-026)<br />
               SEM VI<br />
               B.Tech. Computer Engineering<br />
               FOT.,Dharmsinh Desai University, Nadiad<br />
            </p>
            <hr />
            <div>
                <asp:LinkButton ID="btnlinkfac"  runat="server" ForeColor="#dfcece"  OnClick="btnlinkfac_Click"><b>Faculty Login</b></asp:LinkButton>
                  
            </div>
            <hr />
            <p style="padding-bottom:10px">&copy; <%: DateTime.Now.Year %> - Khushi Desai</p>     
            
        </div>
    

    
    </form>
</body>
</html>
