<%@ Page Title="" Language="C#" MasterPageFile="~/Student.Master" AutoEventWireup="true" CodeBehind="studenthome.aspx.cs" Inherits="DepartmentPortal.studenthome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div class="container-fluid">
<div class="row">
    <div class="col-sm-9">
        <fieldset>
            <legend><h2>Home</h2></legend>
            
            <div style="border:solid; padding:1.5em;">

                <asp:Label ID="lblday" runat="server" Font-Bold="True" Font-Size="X-Large" /><br />
                <asp:Timer ID="Timer1" OnTick="Timer1_Tick" runat="server"></asp:Timer>
                <asp:Label ID="lbltimer" runat="server" Font-Bold="True" Font-Size="Large" />
            </div>
            <br /><br />
            <div class="text-center">
            <asp:GridView ID="gvtimetable" RowStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="Medium" OnRowDataBound="gvtimetable_RowDataBound" CellPadding="8" Width="1000px" runat="server" HeaderStyle-Height="20px" HeaderStyle-Wrap="False" RowStyle-Wrap="false"></asp:GridView>
            </div>

        </fieldset>
    </div>
    <div class="col-sm-3">
    </div>
</div>
</div>
    <br /><br /><br /><br /><br /><br /><br /><br />
</asp:Content>
