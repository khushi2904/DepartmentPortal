<%@ Page Title="" Language="C#" MasterPageFile="~/Student.Master" AutoEventWireup="true" CodeBehind="examresults.aspx.cs" Inherits="DepartmentPortal.examresults" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div class="container-fluid">
<div class="row">
    <div class="col-sm-9">
        <fieldset>
            <legend><h2>Home</h2></legend>
                
            <div class="form-inline">

            <div class="row">
            <div class="col-sm-3">
            
            <div class="form-group">
                <asp:Label ID="Label1" class="control-label" runat="server" Text="Exam Type : "></asp:Label>
                
                    <asp:DropDownList ID="ddltype" CssClass="btn btn-default" runat="server"></asp:DropDownList>
                
            </div>
            </div>

            <div class="col-sm-3">
            <div class="form-group">
                <asp:Label ID="Label2" class="control-label" runat="server" Text="Semester : "></asp:Label>
                
                    <asp:DropDownList ID="ddlsem" CssClass="btn btn-default" runat="server"></asp:DropDownList>
               
            </div>
            </div>

            <div class="col-sm-6">
            <div class="form-group">
                <asp:Button ID="btnsearch" runat="server" class="btn btn-default" Width="120px" Text="Search" OnClick="btnsearch_Click" />
            </div>
            </div>

            </div>
            </div>

            <br /><br /><br />
            <asp:MultiView ID="mvres" runat="server">
                <asp:View runat="server"></asp:View>
                <asp:View runat="server">

                    <asp:GridView ID="gvinternal" CellPadding="8" Width="1000px" OnRowDataBound="gvinternal_RowDataBound" runat="server"></asp:GridView>

                </asp:View>
                <asp:View runat="server">

                    <asp:GridView ID="gvexternal" CellPadding="8" Width="1000px" OnRowDataBound="gvexternal_RowDataBound" runat="server"></asp:GridView>

                </asp:View>
            </asp:MultiView>

        </fieldset>
    </div>
</div>
</div>

    <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
</asp:Content>
