<%@ Page Title="" Language="C#" MasterPageFile="~/Student.Master" AutoEventWireup="true" CodeBehind="mysubjects.aspx.cs" Inherits="DepartmentPortal.mysubjects" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div class="container-fluid">
<div class="row">
    <div class="col-sm-9">
        <fieldset>
            <legend><h2>Home</h2></legend>
                <asp:GridView ID="gvsubjects" CellPadding="8" Width="1000px" OnRowDataBound="gvsubjects_RowDataBound" runat="server"></asp:GridView>
        </fieldset>
    </div>
</div>
</div>
    <br /><br /><br /><br /><br /><br /><br />
</asp:Content>
