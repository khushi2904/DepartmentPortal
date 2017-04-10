<%@ Page Title="" Language="C#" MasterPageFile="~/Faculty.Master" AutoEventWireup="true" CodeBehind="facultyprofile.aspx.cs" Inherits="DepartmentPortal.facultyprofile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div class="container-fluid">
<div class="row">
    <div class="col-sm-12">
        <fieldset>
            <legend><h2>Home</h2></legend>            
            <div class="form-horizontal" style="margin-left:-150px">

            <asp:MultiView ID="mvsearch" runat="server">
                <asp:View runat="server"></asp:View>
                <asp:View runat="server">

                <div class="form-group">
                <asp:Label ID="Label9" class="control-label col-sm-3" runat="server" Text="Search Faculty : "></asp:Label>
                <div class="col-sm-3">
                    <asp:TextBox ID="txtsearch" placeholder="Enter Name/ID" class="form-control" runat="server"></asp:TextBox> 
                </div>
                <div class="col-sm-6">
                    <asp:Button ID="btnsearch" CssClass="btn btn-default" Width="70px" OnClick="btnsearch_Click" runat="server" Text="Search" />
                </div>
                </div>
                <div class="col-sm-offset-3 col-sm-9">
                
                <asp:Label ID="lblsearcherror" runat="server" Text=""></asp:Label>
                </div>
                </asp:View>
            </asp:MultiView>

            <hr />
            <div class="form-group">
                <asp:Label ID="Label2" class="control-label col-sm-3" runat="server" Text="Faculty ID :"></asp:Label>
                <div class="col-sm-9">
                    <asp:TextBox ID="txtid" placeholder="John Doe" ReadOnly="true" class="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="Label5" class="control-label col-sm-3" runat="server" Text="Full Name : "></asp:Label>
                <div class="col-sm-9">
                    <asp:TextBox ID="txtfullname" placeholder="Enter Here"  class="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="Label1" class="control-label col-sm-3" runat="server" Text="Designation : "></asp:Label>
                <div class="col-sm-9">
                    <asp:TextBox ID="txtdesignation" placeholder="Enter Here"  class="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="Label3" class="control-label col-sm-3" runat="server" Text="Branch : "></asp:Label>
                <div class="col-sm-9">
                    <asp:TextBox ID="txtbranch" placeholder="Enter Here"  class="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                </div>
            </div>
                <div class="form-group">
                <asp:Label ID="Label4" class="control-label col-sm-3" runat="server" Text="Birth Date : "></asp:Label>
                <div class="col-sm-9">
                    <asp:TextBox ID="txtbdate" placeholder="Enter Here"  class="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                </div>
            </div>
                <div class="form-group">
                <asp:Label ID="Label6" class="control-label col-sm-3" runat="server" Text="Email ID : "></asp:Label>
                <div class="col-sm-9">
                    <asp:TextBox ID="txtemail" placeholder="Enter Here"  class="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                </div>
            </div>
                <div class="form-group">
                <asp:Label ID="Label7" class="control-label col-sm-3" runat="server" Text="Contact No. : "></asp:Label>
                <div class="col-sm-9">
                    <asp:TextBox ID="txtcontact" placeholder="Enter Here"  class="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                </div>
            </div>
                <div class="form-group">
                <asp:Label ID="Label8" class="control-label col-sm-3" runat="server" Text="Address : "></asp:Label>
                <div class="col-sm-9">
                    <asp:TextBox ID="txtadd" placeholder="Enter Here"  class="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                </div>
            </div>
            <asp:MultiView ID="mvbutton" runat="server">
                <asp:View runat="server"></asp:View>
                <asp:View runat="server">
                <div class="form-group">
                <div class="col-sm-offset-3 col-sm-9">

                <asp:Button ID="btnchange" runat="server" CssClass="btn btn-default" Text="Change" Width="120px" OnClick="btnchange_Click" />&nbsp;&nbsp;
                <asp:Label ID="lblchangeerror" runat="server" Text=""></asp:Label>
                    </div>
                    
            </div>
            </asp:View>
            </asp:MultiView>

            </div>
        </fieldset>
    </div>
</div>

    <asp:MultiView ID="mvaddnew" runat="server">
        <asp:View runat="server"></asp:View>
        <asp:View runat="server">
            <fieldset>
                <legend><h4>Add New</h4></legend>
            


                    <div class="panel panel-default" style="height:100%; width:100%;">
                    <div class="panel-heading" style="text-align:center" ><b>New Student</b></div>
                    <div class="panel-body" style="padding:15px">

                        <div class="form-horizontal" style="margin-left:-100px">

                            <div class="form-group">
                                <asp:Label ID="Label10" class="control-label col-sm-3" runat="server" Text="Full Name : "></asp:Label>
                                <div class="col-sm-9">
                                    <asp:TextBox ID="txtsnewfname" placeholder="Enter Here"  class="form-control" runat="server"></asp:TextBox>
                            </div>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="Label12" class="control-label col-sm-3" runat="server" Text="Branch : "></asp:Label>
                                <div class="col-sm-9">
                                    <asp:TextBox ID="txtsnewbranch" placeholder="Enter Here"  class="form-control" runat="server"></asp:TextBox>
                            </div>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="Label13" class="control-label col-sm-3" runat="server" Text="Batch : "></asp:Label>
                                <div class="col-sm-9">
                                    <asp:TextBox ID="txtsnewbatch" placeholder="Enter Here"  class="form-control" runat="server"></asp:TextBox>
                            </div>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="Label14" class="control-label col-sm-3" runat="server" Text="Seat : "></asp:Label>
                                <div class="col-sm-9">
                                    <asp:TextBox ID="txtsnewseat" placeholder="Enter Here"  class="form-control" runat="server"></asp:TextBox>
                            </div>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="Label15" class="control-label col-sm-3" runat="server" Text="Birthdate : "></asp:Label>
                                <div class="col-sm-9">
                                    <asp:TextBox ID="txtsnewbdate" placeholder="Enter Here" TextMode="Date" class="form-control" runat="server"></asp:TextBox>
                            </div>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="Label16" class="control-label col-sm-3" runat="server" Text="Email ID : "></asp:Label>
                                <div class="col-sm-9">
                                    <asp:TextBox ID="txtsnewemail" placeholder="Enter Here"  class="form-control" runat="server"></asp:TextBox>
                            </div>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="Label17" class="control-label col-sm-3" runat="server" Text="Contact No. : "></asp:Label>
                                <div class="col-sm-9">
                                    <asp:TextBox ID="txtsnewcontact" placeholder="Enter Here"  class="form-control" runat="server"></asp:TextBox>
                            </div>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="Label18" class="control-label col-sm-3" runat="server" Text="Address : "></asp:Label>
                                <div class="col-sm-9">
                                    <asp:TextBox ID="txtsnewaddress" placeholder="Enter Here" TextMode="MultiLine"  class="form-control" runat="server"></asp:TextBox>
                            </div>
                            </div>
                            <div class="form-group">
                            <div class="col-sm-offset-3 col-sm-9">

                            <asp:Button ID="btnadd" runat="server" CssClass="btn btn-default" Text="Add" Width="120px" OnClick="btnadd_Click" /><br />
                            <asp:Label ID="lbladderror" runat="server" Text=""></asp:Label>
                                </div>
                            </div>




                       

                    </div>
                    </div>
                    

                </div>
                
                <br />




                    <div class="panel panel-default" style="height:100%; width:100%;">
                    <div class="panel-heading" style="text-align:center" ><b>New Faculty</b></div>
                    <div class="panel-body" style="padding:15px">

                        <div class="form-horizontal" style="margin-left:-100px">

                            <div class="form-group">
                                <asp:Label ID="Label11" class="control-label col-sm-3" runat="server" Text="Full Name : "></asp:Label>
                                <div class="col-sm-9">
                                    <asp:TextBox ID="txtfnewname" placeholder="Enter Here"  class="form-control" runat="server"></asp:TextBox>
                            </div>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="Label19" class="control-label col-sm-3" runat="server" Text="User Type : "></asp:Label>
                                <div class="col-sm-9">
                                    <asp:TextBox ID="txtfnewtype" placeholder="Enter Here"  class="form-control" runat="server"></asp:TextBox>
                            </div>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="Label20" class="control-label col-sm-3" runat="server" Text="Branch : "></asp:Label>
                                <div class="col-sm-9">
                                    <asp:TextBox ID="txtfbranch" placeholder="Enter Here"  class="form-control" runat="server"></asp:TextBox>
                            </div>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="Label21" class="control-label col-sm-3" runat="server" Text="Designation : "></asp:Label>
                                <div class="col-sm-9">
                                    <asp:TextBox ID="txtfnewdesig" placeholder="Enter Here"  class="form-control" runat="server"></asp:TextBox>
                            </div>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="Label22" class="control-label col-sm-3" runat="server" Text="Birthdate : "></asp:Label>
                                <div class="col-sm-9">
                                    <asp:TextBox ID="txtfnewbdate" placeholder="Enter Here" TextMode="Date" class="form-control" runat="server"></asp:TextBox>
                            </div>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="Label23" class="control-label col-sm-3" runat="server" Text="Email ID : "></asp:Label>
                                <div class="col-sm-9">
                                    <asp:TextBox ID="txtfnewemail" placeholder="Enter Here"  class="form-control" runat="server"></asp:TextBox>
                            </div>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="Label24" class="control-label col-sm-3" runat="server" Text="Contact No. : "></asp:Label>
                                <div class="col-sm-9">
                                    <asp:TextBox ID="txtfnewcontact" placeholder="Enter Here"  class="form-control" runat="server"></asp:TextBox>
                            </div>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="Label25" class="control-label col-sm-3" runat="server" Text="Address : "></asp:Label>
                                <div class="col-sm-9">
                                    <asp:TextBox ID="txtfnewadd" placeholder="Enter Here" TextMode="MultiLine"  class="form-control" runat="server"></asp:TextBox>
                            </div>
                            </div>
                            <div class="form-group">
                            <div class="col-sm-offset-3 col-sm-9">

                            <asp:Button ID="btnfadd" runat="server" CssClass="btn btn-default" Text="Add" Width="120px" OnClick="btnfadd_Click" /><br />
                            <asp:Label ID="lblfadderror" runat="server" Text=""></asp:Label>
                                </div>
                            </div>




                       

                    </div>
                    </div>
                    




                </div>

            
            </fieldset>
            </asp:View>
    </asp:MultiView>



        </div>
    <br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
</asp:Content>
