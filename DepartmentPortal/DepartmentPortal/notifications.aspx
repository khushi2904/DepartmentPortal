<%@ Page Title="" Language="C#" MasterPageFile="~/Student.Master" AutoEventWireup="true" CodeBehind="notifications.aspx.cs" Inherits="DepartmentPortal.notifications" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div class="container-fluid">
<div class="row">
    <div class="col-sm-9">
        <fieldset>
            <legend><h2>Notifications</h2></legend>
            <br />
            <asp:GridView ID="gvnotifications" OnRowDataBound="gvnotifications_RowDataBound" Width="1000px" CellPadding="8" runat="server"></asp:GridView>

        </fieldset>
    </div>
</div>
</div>
<br /><br /><br />
</asp:Content>
