<%@ Page Title="" Language="C#" MasterPageFile="~/Student.Master" AutoEventWireup="true" CodeBehind="myprofs.aspx.cs" Inherits="DepartmentPortal.myprofs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div class="container-fluid">
<div class="row">
    <div class="col-sm-9">
        <fieldset>
            <legend><h2>Faculty Info</h2></legend>
                <asp:GridView ID="gvprofs" CellPadding="8" Width="1000px" OnRowDataBound="gvprofs_RowDataBound" runat="server"></asp:GridView>
            <div>
            </div>
        </fieldset>
    </div>
</div>
</div>
<br /><br /><br /><br /><br /><br />
</asp:Content>
