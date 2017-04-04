<%@ Page Title="" Language="C#" MasterPageFile="~/Faculty.Master" AutoEventWireup="true" CodeBehind="facultyprofile.aspx.cs" Inherits="DepartmentPortal.facultyprofile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div class="container-fluid">
<div class="row">
    <div class="col-sm-9">
        <fieldset>
            <legend><h2>Profile</h2></legend>            
            <div class="form-horizontal" style="margin-left:-150px">

            <asp:MultiView ID="mvsearch" runat="server">
                <asp:View runat="server"></asp:View>
                <asp:View runat="server">

                <div class="form-group">
                <asp:Label ID="Label9" class="control-label col-sm-3" runat="server" Text="Search Faculty : "></asp:Label>
                <div class="col-sm-3">
                    <asp:TextBox ID="txtsearch" placeholder="Enter Name/ID" class="form-control" runat="server"></asp:TextBox> 
                </div>
                <div class="col-sm-6">
                    <asp:Button ID="btnsearch" CssClass="btn btn-default" Width="70px" OnClick="btnsearch_Click" runat="server" Text="Search" />
                </div>
                </div>
                <div class="col-sm-offset-3 col-sm-9">
                
                <asp:Label ID="lblsearcherror" runat="server" Text=""></asp:Label>
                </div>
                </asp:View>
            </asp:MultiView>

            <hr />
            <div class="form-group">
                <asp:Label ID="Label2" class="control-label col-sm-3" runat="server" Text="Faculty ID :"></asp:Label>
                <div class="col-sm-9">
                    <asp:TextBox ID="txtid" placeholder="John Doe" ReadOnly="true" class="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="Label5" class="control-label col-sm-3" runat="server" Text="Full Name : "></asp:Label>
                <div class="col-sm-9">
                    <asp:TextBox ID="txtfullname" placeholder="Enter Here"  class="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="Label1" class="control-label col-sm-3" runat="server" Text="Designation : "></asp:Label>
                <div class="col-sm-9">
                    <asp:TextBox ID="txtdesignation" placeholder="Enter Here"  class="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="Label3" class="control-label col-sm-3" runat="server" Text="Branch : "></asp:Label>
                <div class="col-sm-9">
                    <asp:TextBox ID="txtbranch" placeholder="Enter Here"  class="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                </div>
            </div>
                <div class="form-group">
                <asp:Label ID="Label4" class="control-label col-sm-3" runat="server" Text="Birth Date : "></asp:Label>
                <div class="col-sm-9">
                    <asp:TextBox ID="txtbdate" placeholder="Enter Here"  class="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                </div>
            </div>
                <div class="form-group">
                <asp:Label ID="Label6" class="control-label col-sm-3" runat="server" Text="Email ID : "></asp:Label>
                <div class="col-sm-9">
                    <asp:TextBox ID="txtemail" placeholder="Enter Here"  class="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                </div>
            </div>
                <div class="form-group">
                <asp:Label ID="Label7" class="control-label col-sm-3" runat="server" Text="Contact No. : "></asp:Label>
                <div class="col-sm-9">
                    <asp:TextBox ID="txtcontact" placeholder="Enter Here"  class="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                </div>
            </div>
                <div class="form-group">
                <asp:Label ID="Label8" class="control-label col-sm-3" runat="server" Text="Address : "></asp:Label>
                <div class="col-sm-9">
                    <asp:TextBox ID="txtadd" placeholder="Enter Here"  class="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                </div>
            </div>
            <asp:MultiView ID="mvbutton" runat="server">
                <asp:View runat="server"></asp:View>
                <asp:View runat="server">
                <div class="col-sm-offset-3 col-sm-9">

                <asp:Button ID="btnchange" runat="server" CssClass="btn btn-default" Text="Change" Width="120px" OnClick="btnchange_Click" />&nbsp;&nbsp;
                <asp:Label ID="lblchangeerror" runat="server" Text=""></asp:Label>
            </div>
            </asp:View>
            </asp:MultiView>

            </div>
        </fieldset>
    </div>
</div>
        </div>
    <br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
</asp:Content>
