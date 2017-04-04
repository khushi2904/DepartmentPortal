<%@ Page Title="" Language="C#" MasterPageFile="~/Faculty.Master" AutoEventWireup="true" CodeBehind="editsubjects.aspx.cs" Inherits="DepartmentPortal.editsubjects" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div class="container-fluid">
<div class="row">
    <div class="col-sm-9">
        <fieldset>
            <legend><h2>Courses</h2></legend>            
              <fieldset>
                    <legend><h4>Add Subject</h4></legend>
                    <div class="form-horizontal" style="margin-left:-150px">

                        <div class="form-group">
                            <asp:Label ID="Label2" class="control-label col-sm-3" runat="server" Text="New Subject :"></asp:Label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="txtnewname" placeholder="Enter Subject Name" class="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="Label1" class="control-label col-sm-3" runat="server" Text="Subject Description :"></asp:Label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="txtnewdesc" placeholder="Enter Subject Description" TextMode="MultiLine" class="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="Label3" class="control-label col-sm-3" runat="server" Text="Subject Credit :"></asp:Label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="txtnewcredit" placeholder="Enter Subject Credit" class="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="Label5" class="control-label col-sm-3" runat="server" Text="Semester Allotment : "></asp:Label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="txtnewsem" placeholder="Enter Semester" class="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-offset-3 col-sm-9">
                            <asp:Button ID="btnadd" runat="server" CssClass="btn btn-default" Text="Add Subject" Width="120px" OnClick="btnadd_Click" />&nbsp;&nbsp;
                            <asp:Label ID="lbladderror" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                    </div>    
                </fieldset>

                <asp:MultiView ID="mvedit" runat="server">
                <asp:View runat="server"></asp:View>
                <asp:View runat="server">
                <fieldset>
                    <legend><h4>Edit Event </h4></legend>
                    <div class="form-horizontal" style="margin-left:-150px">

                        <div class="form-group">
                            <asp:Label ID="Label10" class="control-label col-sm-3" runat="server" Text="Subject ID :"></asp:Label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="txtid" ReadOnly="true"  class="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="Label4" class="control-label col-sm-3" runat="server" Text="Subject Name:"></asp:Label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="txtname" class="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="Label6" class="control-label col-sm-3" runat="server" Text="Subject Description :"></asp:Label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="txtdesc" TextMode="MultiLine" class="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="Label7" class="control-label col-sm-3" runat="server" Text="Subject Credit :"></asp:Label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="txtcredit" class="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="Label8" class="control-label col-sm-3" runat="server" Text="Semester Allotment : "></asp:Label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="txtsem" class="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-offset-3 col-sm-9">
                            <asp:Button ID="btnedit" runat="server" CssClass="btn btn-default" Text="Edit" Width="120px" OnClick="btnedit_Click" />&nbsp;&nbsp;
                            <asp:Button ID="btnremove" runat="server" CssClass="btn btn-default" Text="Remove" Width="120px" OnClick="btnremove_Click" />&nbsp;&nbsp;
                            <asp:Label ID="lblediterror" runat="server" Text=""></asp:Label>
                            </div>
                        </div>


                    </div>
                </fieldset>
                </asp:View>
                </asp:MultiView>

            <br /><br />
            <asp:GridView ID="gvsubjects" OnSelectedIndexChanged="gvsubjects_SelectedIndexChanged" AutoGenerateSelectButton="true" OnRowCreated="gvsubjects_RowCreated" CellPadding="5" runat="server" OnRowDataBound="gvsubjects_RowDataBound" AllowSorting="true" Width="700px"></asp:GridView>


        </fieldset>
    </div>
</div>
</div>
    <br /><br /><br /><br /><br /><br /><br /><br /><br />
</asp:Content>
