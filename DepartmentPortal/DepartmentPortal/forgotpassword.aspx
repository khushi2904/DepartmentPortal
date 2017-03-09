<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="forgotpassword.aspx.cs" Inherits="DepartmentPortal.forgotpassword" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>DDU</title>
    <meta charset="utf-8" />  
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/jquery-1.10.2.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    
</head>
<body style="background-color:white">
    <form id="form1" runat="server">
    
    
        <nav style="padding-top:1em; padding-bottom:1em; background-color:#000000" class="navbar navbar-default">
            <div class="container">
                <div class="navbar-header">
                    <a class="navbar-brand" href="Default.aspx"><p style="color:#dfcece; font-size:45px; margin-top:28px">Dharmsinh Desai University</p></a>
                </div>
                
            </div>
        </nav>

        <br /><br /><br />
        

        <div class="container" style="border-style:solid; padding:20px; padding-left:100px; padding-right:100px">
                            
            <asp:MultiView ID="MultiView1" runat="server">

                <asp:View runat="server">

                        <div class="text-center">
                            <h2>Forgot Password</h2>
                            <h5>Step-1: Please Enter ID.</h5>
                        </div>

                    <div class="form-group">

                        <asp:Label ID="Label1" runat="server" Text="Student ID : " Font-Bold="True"></asp:Label>
                        <asp:TextBox ID="txtid" runat="server" placeholder="Enter Here" class="form-control"></asp:TextBox>
                    </div>
                        <div class="text-center">
                            <asp:Button ID="btnsubmit" runat="server" class="btn btn-default" Width="150px" Text="Submit" OnClick="btnsubmit_Click" />                   
                        </div>
                    

                </asp:View>

                <asp:View runat="server">

                    <div class="text-center">
                            <h2>Forgot Password</h2>
                            <h5>Step-2: Please answer the questions below.</h5>
                    </div>

                    
                        <div class="form-group">
                            <asp:Label ID="Label2" runat="server" Text="Q1 : " Font-Bold="True"></asp:Label>
                            <asp:Label ID="lblsecques1" runat="server" Text="" Font-Bold="True"></asp:Label>
                            <asp:TextBox ID="txtsecans1" runat="server" placeholder="Enter Answer" class="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="Label3" runat="server" Text="Q2 : " Font-Bold="True"></asp:Label>
                            <asp:Label ID="lblsecques2" runat="server" Text="" Font-Bold="True"></asp:Label>
                            <asp:TextBox ID="txtsecans2" runat="server" placeholder="Enter Answer" class="form-control"></asp:TextBox>
                        </div>

                        <div class="text-center">
                            <asp:Button ID="btnsubmit_ans" runat="server" class="btn btn-default" Width="150px" Text="Submit" OnClick="btnsubmit_ans_Click"  />                   
                        </div>


                </asp:View>
                
                <asp:View ID="viewpassword" runat="server">

                    <div class="text-center">
                            <h2>Forgot Password</h2>
                            <h5>Step-3: Change Password.</h5>
                    </div>

                        <div class="form-group">
                            <asp:Label ID="Label5" runat="server" Text="Enter New Password : " Font-Bold="True"></asp:Label>
                            <asp:TextBox ID="txtpass" runat="server" TextMode="Password" placeholder="Enter Here" class="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="Label7" runat="server" Text="Re-Enter New Password : " Font-Bold="True"></asp:Label>
                            <asp:TextBox ID="txtcpass" runat="server" placeholder="Enter Here" TextMode="Password" class="form-control"></asp:TextBox>
                        </div>

                        <div class="text-center">
                            <asp:Button ID="btnsubmit_pass" runat="server" class="btn btn-default" Width="150px" Text="Submit" OnClick="btnsubmit_pass_Click"  />                   
                        </div>

                </asp:View>    
                <asp:View ID="viewfinal" runat="server">
                    <div class="text-center">
                    <h2>Congratulations! Your password has been reset.</h2><br />
                    <asp:Button ID="btnredirect" CssClass="btn btn-default" runat="server" Text="Go back to Home Page" OnClick="btnredirect_Click" />
                    </div>
                </asp:View>

            </asp:MultiView>
                  
            

            <div class="text-center">                
                <asp:Label ID="lblerror" runat="server" Text=""></asp:Label>
            </div>
        </div>
        

        <br /><br /><br /><br /><br /><br />
        <div style="background-color:#f0b04b; padding:20px" class="text-center">
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
                
                  
            </div>
            <hr />
            <p style="padding-bottom:10px">&copy; <%: DateTime.Now.Year %> - Khushi Desai</p>     
            
        </div>
    


    
    </form>
</body>
</html>
