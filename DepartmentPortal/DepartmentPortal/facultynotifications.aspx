<%@ Page Title="" Language="C#" MasterPageFile="~/Faculty.Master" AutoEventWireup="true" CodeBehind="facultynotifications.aspx.cs" Inherits="DepartmentPortal.facultynotifications" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
<div class="row">
    <div class="col-sm-9">
        <fieldset>
            <legend><h2>Send Notifications</h2></legend>
            <br />
            <div class="form-horizontal" style="margin-left:-150px">

                <div class="form-group">
                  <asp:Label ID="Label4" class="control-label col-sm-3" runat="server" Text="Enter Semester :"></asp:Label>
                  <div class="col-sm-9">
                       <asp:TextBox ID="txtsem" placeholder="Enter Here.. " class="form-control" runat="server"></asp:TextBox>
                  </div>
                  </div>

                <div class="form-group">
                  <asp:Label ID="Label1" class="control-label col-sm-3" runat="server" Text="Enter Semester :"></asp:Label>
                  <div class="col-sm-9">
                       <asp:TextBox ID="txtmessage" TextMode="MultiLine" placeholder="Enter Here.. " class="form-control" runat="server"></asp:TextBox>
                  </div>
                  </div>

                <div class="form-group">
                     <div class="col-sm-offset-3 col-sm-9">
                     <asp:Button ID="btnsend" runat="server" CssClass="btn btn-default" Text="Send" Width="120px" OnClick="btnsend_Click" />&nbsp;&nbsp;
                     <asp:Label ID="lblsenderror" runat="server" Text=""></asp:Label>
                     </div>
                </div>

            </div>

        </fieldset>
    </div>
</div>
</div>
<br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
</asp:Content>
