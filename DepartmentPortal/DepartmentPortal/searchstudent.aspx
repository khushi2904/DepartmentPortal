<%@ Page Title="" Language="C#" MasterPageFile="~/Faculty.Master" AutoEventWireup="true" CodeBehind="searchstudent.aspx.cs" Inherits="DepartmentPortal.searchstudent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
<div class="container-fluid">
<div class="row">
    <div class="col-sm-10">
        <fieldset>
            <legend><h2>Search Student</h2></legend>            
            <div class="form-horizontal" style="margin-left:-150px">

                <asp:MultiView ID="mvsearhbtn" runat="server">
                    <asp:View runat="server">
                    <div class="form-group">
                        <div class="col-sm-offset-3 col-sm-9">
                        <asp:Button ID="btnsearchbyname" runat="server" CssClass="btn btn-default" Text="Search By Name" Width="160px" OnClick="btnsearchbyname_Click" />&nbsp;&nbsp;
                        <asp:Button ID="btnseachbysem" runat="server" CssClass="btn btn-default" Text="Search By Semester" Width="160px" OnClick="btnseachbysem_Click" />
                            </div>
                    </div>
                    </asp:View>
                    <asp:View runat="server">

                         <div class="form-group">
                           <asp:Label ID="Label4" class="control-label col-sm-3" runat="server" Text="Enter Student Name :"></asp:Label>
                           <div class="col-sm-9">
                               <asp:TextBox ID="txtname" placeholder="Enter Here.. " class="form-control" runat="server"></asp:TextBox>
                           </div>
                        </div>
                        <div class="form-group">
                         <div class="col-sm-offset-3 col-sm-9">
                         <asp:Button ID="btnnamesearch" runat="server" CssClass="btn btn-default" Text="Search" Width="120px" OnClick="btnnamesearch_Click" />&nbsp;&nbsp;
                         <asp:Label ID="lblnamesearcherror" runat="server" Text=""></asp:Label>
                         </div>
                    </div>

                    </asp:View>
                    <asp:View runat="server">

                <div class="form-group">
                   <asp:Label ID="Label2" class="control-label col-sm-3" runat="server" Text="Enter Semester :"></asp:Label>
                   <div class="col-sm-9">
                       <asp:TextBox ID="txtsem" OnTextChanged="txtsem_TextChanged" AutoPostBack="true" placeholder="Enter Here.. " class="form-control" runat="server"></asp:TextBox>
                   </div>
                </div>
                <div class="form-group">
                   <asp:Label ID="Label1" class="control-label col-sm-3" runat="server" Text="Enter Class :"></asp:Label>
                   <div class="col-sm-9">
                       <asp:DropDownList ID="ddlclass" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlclass_SelectedIndexChanged" runat="server"></asp:DropDownList>
                   </div>
                </div>
                <div class="form-group">
                   <asp:Label ID="Label3" class="control-label col-sm-3" runat="server" Text="Enter Batch :"></asp:Label>
                   <div class="col-sm-9">
                       <asp:DropDownList ID="ddlbatch" CssClass="form-control" runat="server"></asp:DropDownList>
                   </div>
                </div>
                <div class="form-group">
                     <div class="col-sm-offset-3 col-sm-9">
                     <asp:Button ID="btnsearch" runat="server" CssClass="btn btn-default" Text="Search" Width="120px" OnClick="btnsearch_Click" />&nbsp;&nbsp;
                     <asp:Label ID="lblsearcherror" runat="server" Text=""></asp:Label>
                     </div>
                </div>
                
                        </asp:View>
                    <asp:View runat="server"></asp:View>
                </asp:MultiView>
            </div>

            <br />
            
        </fieldset>

        <asp:MultiView ID="mvresults" runat="server">
            <asp:View runat="server"></asp:View>
            <asp:View runat="server">
                <asp:GridView ID="gvsearch" OnSelectedIndexChanged="gvsearch_SelectedIndexChanged" AutoGenerateSelectButton="true" OnRowCreated="gvsearch_RowCreated" CellPadding="5" runat="server" OnRowDataBound="gvsearch_RowDataBound" AllowSorting="true" Width="700px"></asp:GridView>
            </asp:View>
            <asp:View runat="server">

                <div class="form-horizontal" style="margin-left:-150px">
                <div class="form-group">
                   <asp:Label ID="Label5" class="control-label col-sm-3" runat="server" Text="Student ID :"></asp:Label>
                   <div class="col-sm-9">
                       <asp:TextBox ID="txtsstid" ReadOnly="true" placeholder="Enter Here.. " class="form-control" runat="server"></asp:TextBox>
                   </div>
                </div>
                <div class="form-group">
                   <asp:Label ID="Label6" class="control-label col-sm-3" runat="server" Text="Full Name :"></asp:Label>
                   <div class="col-sm-9">
                       <asp:TextBox ID="txtsfullname" placeholder="Enter Here.. " class="form-control" runat="server"></asp:TextBox>
                   </div>
                </div>
                <div class="form-group">
                   <asp:Label ID="Label7" class="control-label col-sm-3" runat="server" Text="Branch :"></asp:Label>
                   <div class="col-sm-9">
                       <asp:TextBox ID="txtsbranch" placeholder="Enter Here.. " class="form-control" runat="server"></asp:TextBox>
                   </div>
                </div>
                <div class="form-group">
                   <asp:Label ID="Label8" class="control-label col-sm-3" runat="server" Text="Batch :"></asp:Label>
                   <div class="col-sm-9">
                       <asp:TextBox ID="txtsbatch" placeholder="Enter Here.. " class="form-control" runat="server"></asp:TextBox>
                   </div>
                </div>
                <div class="form-group">
                   <asp:Label ID="Label14" class="control-label col-sm-3" runat="server" Text="Seat :"></asp:Label>
                   <div class="col-sm-9">
                       <asp:TextBox ID="txtsseat" placeholder="Enter Here.. " class="form-control" runat="server"></asp:TextBox>
                   </div>
                </div>
                <div class="form-group">
                   <asp:Label ID="Label9" class="control-label col-sm-3" runat="server" Text="Year of Completion :"></asp:Label>
                   <div class="col-sm-9">
                       <asp:TextBox ID="txtsyoc" placeholder="Enter Here.. " class="form-control" runat="server"></asp:TextBox>
                   </div>
                </div>
                <div class="form-group">
                   <asp:Label ID="Label10" class="control-label col-sm-3" runat="server" Text="Birthdate :"></asp:Label>
                   <div class="col-sm-9">
                       <asp:TextBox ID="txtsbdate" placeholder="Enter Here.. " class="form-control" runat="server"></asp:TextBox>
                   </div>
                </div>
                <div class="form-group">
                   <asp:Label ID="Label11" class="control-label col-sm-3" runat="server" Text="Email ID :"></asp:Label>
                   <div class="col-sm-9">
                       <asp:TextBox ID="txtsemail" placeholder="Enter Here.. " class="form-control" runat="server"></asp:TextBox>
                   </div>
                </div>
                <div class="form-group">
                   <asp:Label ID="Label12" class="control-label col-sm-3" runat="server" Text="Contact No. :"></asp:Label>
                   <div class="col-sm-9">
                       <asp:TextBox ID="txtscontact" placeholder="Enter Here.. " class="form-control" runat="server"></asp:TextBox>
                   </div>
                </div>
                <div class="form-group">
                   <asp:Label ID="Label13" class="control-label col-sm-3" runat="server" Text="Address :"></asp:Label>
                   <div class="col-sm-9">
                       <asp:TextBox ID="txtsaddress" TextMode="MultiLine" placeholder="Enter Here.. " class="form-control" runat="server"></asp:TextBox>
                   </div>
                </div>

                <asp:MultiView ID="mvsavedetails" runat="server">
                    <asp:View runat="server"></asp:View>
                    <asp:View runat="server">

                      <div class="form-group">
                     <div class="col-sm-offset-3 col-sm-9">
                     <asp:Button ID="btnsavedetails" runat="server" CssClass="btn btn-default" Text="Update" Width="120px" OnClick="btnsavedetails_Click" />&nbsp;&nbsp;
                     <asp:Label ID="lblsavedetailserror" runat="server" Text=""></asp:Label>
                     </div>
                </div>

                    </asp:View>
                </asp:MultiView>
                    </div>




                <fieldset>
            <legend><h4>Exam Results</h4></legend>
                
            <div class="form-inline">

            <div class="row">
            <div class="col-sm-3">
            
            <div class="form-group">
                <asp:Label ID="Label15" class="control-label" runat="server" Text="Exam Type : "></asp:Label>
                
                    <asp:DropDownList ID="ddltype" CssClass="btn btn-default" runat="server"></asp:DropDownList>
                
            </div>
            </div>

            <div class="col-sm-3">
            <div class="form-group">
                <asp:Label ID="Label16" class="control-label" runat="server" Text="Semester : "></asp:Label>
                
                    <asp:DropDownList ID="ddlsem" CssClass="btn btn-default" runat="server"></asp:DropDownList>
               
            </div>
            </div>

            <div class="col-sm-6">
            <div class="form-group">
                <asp:Button ID="btnsearchexam" runat="server" class="btn btn-default" Width="120px" Text="Search" OnClick="btnsearchexam_Click" />
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



            </asp:View>
        </asp:MultiView>


        
        </div>
    </div>
</div>

    <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
</asp:Content>
