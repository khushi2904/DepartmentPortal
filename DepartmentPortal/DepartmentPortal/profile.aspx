<%@ Page Title="" Language="C#" MasterPageFile="~/Student.Master" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="DepartmentPortal.profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="row">
        <div class="col-sm-6">

        
    <fieldset>
        <legend><h2>Profile</h2></legend>

            <div class="form-horizontal">

            <div class="form-group">
                <asp:Label ID="Label1" class="control-label col-sm-3" runat="server" Text="Student ID : "></asp:Label>
                <div class="col-sm-9">
                    <asp:Label ID="lblid" runat="server" Text=""></asp:Label>
                </div>
            </div>

            <div class="form-group">
                <asp:Label ID="Label2" class="control-label col-sm-3" runat="server" Text="Full Name : "></asp:Label>
                <div class="col-sm-9">
                    <asp:Label ID="lblname" runat="server" Text=""></asp:Label>
                </div>
            </div>

            <div class="form-group">
                <asp:Label ID="Label3" class="control-label col-sm-3" runat="server" Text="Branch : "></asp:Label>
                <div class="col-sm-9">
                    <asp:Label ID="lblbranch" runat="server" Text=""></asp:Label>
                </div>
            </div>

            <div class="form-group">
                <asp:Label ID="Label4" class="control-label col-sm-3" runat="server" Text="Batch : "></asp:Label>
                <div class="col-sm-9">
                    <asp:Label ID="lblbatch" runat="server" Text=""></asp:Label>
                </div>
            </div>

            <div class="form-group">
                <asp:Label ID="Label5" class="control-label col-sm-3" runat="server" Text="Current Sem : "></asp:Label>
                <div class="col-sm-9">
                    <asp:Label ID="lblsem" runat="server" Text=""></asp:Label>
                </div>
            </div>

            <div class="form-group">
                <asp:Label ID="Label6" class="control-label col-sm-3" runat="server" Text="Seat Type : "></asp:Label>
                <div class="col-sm-9">
                    <asp:Label ID="lblseat" runat="server" Text=""></asp:Label>
                </div>
            </div>

            <div class="form-group">
                <asp:Label ID="Label10" class="control-label col-sm-3" runat="server" Text="Year of Completion : "></asp:Label>
                <div class="col-sm-9">
                    <asp:Label ID="lblyoc" runat="server" Text=""></asp:Label>
                </div>
            </div>

            <div class="form-group">
                <asp:Label ID="Label7" class="control-label col-sm-3" runat="server" Text="Birthdate : "></asp:Label>
                <div class="col-sm-9">
                    <asp:Label ID="lblbdate" runat="server" Text=""></asp:Label>
                </div>
            </div>

            <div class="form-group">
                <asp:Label ID="Label8" class="control-label col-sm-3" runat="server" Text="Email ID : "></asp:Label>
                <div class="col-sm-9">
                    <asp:Label ID="lblemail" runat="server" Text=""></asp:Label>
                </div>
            </div>

            <div class="form-group">
                <asp:Label ID="Label9" class="control-label col-sm-3" runat="server" Text="Contact No. : "></asp:Label>
                <div class="col-sm-9">
                    <asp:Label ID="lblcontact" runat="server" Text=""></asp:Label>
                </div>
            </div>

            <div class="form-group">
                <asp:Label ID="Label11" class="control-label col-sm-3" runat="server" Text="Address : "></asp:Label>
                <div class="col-sm-9">
                    <asp:Label ID="lbladdr" runat="server" Text=""></asp:Label>
                </div>
            </div>

            </div>
    </fieldset>
            </div>
    </div>

    <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
</asp:Content>
