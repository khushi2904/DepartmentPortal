<%@ Page Title="" Language="C#" MasterPageFile="~/Faculty.Master" AutoEventWireup="true" CodeBehind="facultymessages.aspx.cs" Inherits="DepartmentPortal.facultymessages" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container-fluid">
<div class="row">
    <div class="col-sm-8">
        <fieldset>
            <legend><h2>Home</h2></legend>            

            <asp:MultiView ID="mvchats" runat="server">
                <asp:View id="v1" runat="server">

                    <div class="form-inline">

                    <div class="row">
                    
                    <div class="col-sm-4">
            
                    <div class="form-group">
                      <asp:TextBox ID="txtsearch" Placeholder="Search Contact" CssClass="form-control" Width="200px" runat="server"></asp:TextBox>                
                    </div>
                    </div>

                    <div class="col-sm-8">
                    <div class="form-group">
                        <asp:Button ID="btnsearch" runat="server" class="btn btn-default" Width="120px" Text="Search" OnClick="btnsearch_Click" />
                    </div>
                    </div>

                    </div>
                    </div>


                   <asp:Label ID="lblerror" CssClass="col-sm-offset-3 col-sm-9" runat="server" Text=""></asp:Label> 
                    <br /><br />


                    <asp:MultiView ID="mvsearch" runat="server">
                        <asp:View runat="server">

                            <asp:GridView ID="gvchats" Width="900px" CellPadding="8" AutoGenerateSelectButton="true" OnRowCreated="gvchats_RowCreated" OnSelectedIndexChanged="gvchats_SelectedIndexChanged" runat="server" OnRowDataBound="gvchats_RowDataBound"></asp:GridView>
                            

                        </asp:View>
                        <asp:View runat="server">

                            <asp:GridView ID="gvsearch" Width="900px" CellPadding="8" AutoGenerateSelectButton="true" OnRowCreated="gvsearch_RowCreated" OnSelectedIndexChanged="gvsearch_SelectedIndexChanged" runat="server" OnRowDataBound="gvsearch_RowDataBound"></asp:GridView>
                            <asp:Label ID="lblnoresults" runat="server" Text="Label"></asp:Label> 

                        </asp:View>
                    </asp:MultiView>
                    
                    
                </asp:View>

                <asp:View ID="v2" runat="server">

                    <div class="form-inline">

                    <div class="row">
                    <div class="col-sm-4">
            
                    <div class="form-group">
                        <asp:TextBox ID="txtmessage" Placeholder="Enter New Message.." TextMode="MultiLine" Width="200px" CssClass="form-control"  runat="server"></asp:TextBox>                
                    </div>
                    </div>

                    <div class="col-sm-8">
                    <div class="form-group">
                        <asp:Button ID="btnsend" runat="server" class="btn btn-default" Width="90px" Text="Send" OnClick="btnsend_Click" />
                        <asp:Button ID="btnback" runat="server" class="btn btn-default" Width="90px" Text="Back" OnClick="btnback_Click" />
                    </div>
                    </div>

                    </div>
                    </div>

                    <br /><br />
                    <asp:GridView ID="gvmessage" Width="1000px" CellPadding="8" OnRowDataBound="gvmessage_RowDataBound" runat="server"></asp:GridView>

                </asp:View>
            </asp:MultiView>


        </fieldset>
    </div>
</div>
</div>
    <br /><br /><br /><br /><br /><br /><br />




</asp:Content>
