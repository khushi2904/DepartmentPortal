<%@ Page Title="" Language="C#" MasterPageFile="~/Student.Master" AutoEventWireup="true" CodeBehind="studenthome.aspx.cs" Inherits="DepartmentPortal.studenthome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div class="container-fluid">
<div class="row">
    <div class="col-sm-9">
        <fieldset>
            <legend><h2>Home</h2></legend>
            
            <div>

                <asp:Label ID="lblday" runat="server" Font-Bold="True" Font-Size="X-Large" /><br />
                
                <asp:Label ID="Label1" runat="server" Font-Bold="true" Text="Ongoing: " Font-Size="Large" />
                <asp:Label ID="lblcurlec" runat="server" Font-Bold="true" Font-Size="Large" />
                &nbsp;&nbsp;&nbsp;<asp:LinkButton ID="lbtnskip" OnClick="LinkButton1_Click" runat="server">Skip</asp:LinkButton><br />
                <asp:Label ID="lblskipped" runat="server" Text=""></asp:Label>
                <asp:Label ID="lblskippederror" runat="server" ></asp:Label><br />
                <asp:Label Font-Bold="true" ID="lblestattendance" runat="server" ></asp:Label>
            </div>
            <br /><br />
            <div class="text-center">
            <asp:GridView ID="gvtimetable" RowStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="Medium" OnRowDataBound="gvtimetable_RowDataBound" CellPadding="8"  runat="server" HeaderStyle-Height="20px" HeaderStyle-Wrap="False" RowStyle-Wrap="false"></asp:GridView>
            </div>

        </fieldset>
    </div>
    <div class="col-sm-3">
        <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
        <div class="panel panel-default" style="height:100%; width:100%;">
                    <div class="panel-heading" style="text-align:center" ><b>Skiped Sessions</b></div>
                    <div class="panel-body" style="padding:15px">

                        <div class="form-horizontal">
                            <asp:GridView ID="gvskipedsessions" RowStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="Medium" OnRowDataBound="gvskipedsessions_RowDataBound" CellPadding="8" runat="server" HeaderStyle-Height="20px" HeaderStyle-Wrap="False" RowStyle-Wrap="false"></asp:GridView>
                        </div>
                    </div>
                    </div>




    </div>
</div>
</div>
    <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
</asp:Content>
