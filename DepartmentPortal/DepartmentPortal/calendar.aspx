<%@ Page Title="" Language="C#" MasterPageFile="~/Student.Master" AutoEventWireup="true" CodeBehind="calendar.aspx.cs" Inherits="DepartmentPortal.calendar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div class="container-fluid">
<div class="row">
    <div class="col-sm-9">
        <fieldset>
            <legend><h2>Home</h2></legend>
                <asp:GridView ID="gvevents" CellPadding="8" Width="1000px" OnRowDataBound="gvevents_RowDataBound" runat="server"></asp:GridView>
            <div>
            </div>
        </fieldset>
    </div>
</div>
</div>
    <br /><br /><br /><br /><br /><br />
</asp:Content>
