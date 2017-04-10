<%@ Page Title="" Language="C#" MasterPageFile="~/Faculty.Master" AutoEventWireup="true" CodeBehind="updateresults.aspx.cs" Inherits="DepartmentPortal.updateresults" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<div class="container-fluid">
<div class="row">
    <div class="col-sm-8">
        <fieldset>
            <legend><h2>Update Results</h2></legend>            
            <div class="form-horizontal" style="margin-left:-120px">

                <asp:MultiView ID="mvsearhbtn" runat="server">
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

            
            <asp:MultiView ID="mvresults" runat="server">
                <asp:View runat="server"></asp:View>
                <asp:View runat="server">
                    <asp:GridView ID="gvsearch" OnSelectedIndexChanged="gvsearch_SelectedIndexChanged" AutoGenerateSelectButton="true" OnRowCreated="gvsearch_RowCreated" CellPadding="5" runat="server" OnRowDataBound="gvsearch_RowDataBound" AllowSorting="true" Width="700px"></asp:GridView>
                </asp:View>
                <asp:View runat="server">

                    <fieldset>
                        <legend><h4>Internals</h4></legend>

                        <asp:GridView ID="gvinternals" CellPadding="5" runat="server" OnRowDataBound="gvinternals_RowDataBound" AllowSorting="true" Width="700px"></asp:GridView>

                        <br /><br />
                       

                                <div class="panel panel-default" style="height:100%; width:100%;">
                                <div class="panel-heading" style="text-align:center" ><b>Update Results</b></div>
                                <div class="panel-body" style="padding:15px">

                                    
                                    <div class="container form-horizontal" style="margin-left:-100px">

                                        <div class="form-group">
                                        <asp:Label ID="lbls1" Font-Underline="true" Font-Bold="true" class="control-label col-sm-3" runat="server"></asp:Label>
                                            </div>
                                        <div class="form-group">
                                           <asp:Label ID="Label17" class="control-label col-sm-3" Text="Sess1 Marks" runat="server"></asp:Label>
                                           <div class="col-sm-9">
                                               <asp:TextBox ID="txts1m1" placeholder="Enter Sessional Marks " class="form-control" runat="server"></asp:TextBox>&nbsp;
                                           </div>
                                        </div>
                                        <div class="form-group">
                                           <asp:Label ID="Label10" class="control-label col-sm-3" Text="Sess2 Marks" runat="server"></asp:Label>
                                           <div class="col-sm-9">
                                               <asp:TextBox ID="txts1m2" placeholder="Enter Sessional Marks " class="form-control" runat="server"></asp:TextBox>&nbsp;
                                           </div>
                                        </div>
                                        <div class="form-group">
                                           <asp:Label ID="Label24" class="control-label col-sm-3" Text="Sess3 Marks" runat="server"></asp:Label>
                                           <div class="col-sm-9">
                                               <asp:TextBox ID="txts1m3" placeholder="Enter Sessional Marks " class="form-control" runat="server"></asp:TextBox>&nbsp;
                                           </div>
                                        </div>
                                        <div class="form-group">
                                           <asp:Label ID="Label31" class="control-label col-sm-3" Text="Block Marks" runat="server"></asp:Label>
                                           <div class="col-sm-9">
                                               <asp:TextBox ID="txts1bm" placeholder="Enter Sessional Marks " class="form-control" runat="server"></asp:TextBox>&nbsp;
                                           </div>
                                        </div>
                                        <div class="form-group">
                                           <asp:Label ID="Label38" class="control-label col-sm-3" Text="Remedial Marks" runat="server"></asp:Label>
                                           <div class="col-sm-9">
                                               <asp:TextBox ID="txts1rm" placeholder="Enter Sessional Marks " class="form-control" runat="server"></asp:TextBox>&nbsp;
                                           </div>
                                        </div>
                                        <br />



                                        <div class="form-group">
                                        <asp:Label ID="lbls2" Font-Underline="true" Font-Bold="true" class="control-label col-sm-3" runat="server"></asp:Label>
                                            </div>
                                        <div class="form-group">
                                           <asp:Label ID="Label46" class="control-label col-sm-3" Text="Sess1 Marks" runat="server"></asp:Label>
                                           <div class="col-sm-9">
                                               <asp:TextBox ID="txts2m1" placeholder="Enter Sessional Marks " class="form-control" runat="server"></asp:TextBox>&nbsp;
                                           </div>
                                        </div>
                                        <div class="form-group">
                                           <asp:Label ID="Label47" class="control-label col-sm-3" Text="Sess2 Marks" runat="server"></asp:Label>
                                           <div class="col-sm-9">
                                               <asp:TextBox ID="txts2m2" placeholder="Enter Sessional Marks " class="form-control" runat="server"></asp:TextBox>&nbsp;
                                           </div>
                                        </div>
                                        <div class="form-group">
                                           <asp:Label ID="Label48" class="control-label col-sm-3" Text="Sess3 Marks" runat="server"></asp:Label>
                                           <div class="col-sm-9">
                                               <asp:TextBox ID="txts2m3" placeholder="Enter Sessional Marks " class="form-control" runat="server"></asp:TextBox>&nbsp;
                                           </div>
                                        </div>
                                        <div class="form-group">
                                           <asp:Label ID="Label49" class="control-label col-sm-3" Text="Block Marks" runat="server"></asp:Label>
                                           <div class="col-sm-9">
                                               <asp:TextBox ID="txts2bm" placeholder="Enter Sessional Marks " class="form-control" runat="server"></asp:TextBox>&nbsp;
                                           </div>
                                        </div>
                                        <div class="form-group">
                                           <asp:Label ID="Label50" class="control-label col-sm-3" Text="Remedial Marks" runat="server"></asp:Label>
                                           <div class="col-sm-9">
                                               <asp:TextBox ID="txts2rm" placeholder="Enter Sessional Marks " class="form-control" runat="server"></asp:TextBox>&nbsp;
                                           </div>
                                        </div>
                                        <br />


                                        <div class="form-group">
                                        <asp:Label ID="lbls3" Font-Underline="true" Font-Bold="true" class="control-label col-sm-3" runat="server"></asp:Label>
                                            </div>
                                        <div class="form-group">
                                           <asp:Label ID="Label52" class="control-label col-sm-3" Text="Sess1 Marks" runat="server"></asp:Label>
                                           <div class="col-sm-9">
                                               <asp:TextBox ID="txts3m1" placeholder="Enter Sessional Marks " class="form-control" runat="server"></asp:TextBox>&nbsp;
                                           </div>
                                        </div>
                                        <div class="form-group">
                                           <asp:Label ID="Label53" class="control-label col-sm-3" Text="Sess2 Marks" runat="server"></asp:Label>
                                           <div class="col-sm-9">
                                               <asp:TextBox ID="txts3m2" placeholder="Enter Sessional Marks " class="form-control" runat="server"></asp:TextBox>&nbsp;
                                           </div>
                                        </div>
                                        <div class="form-group">
                                           <asp:Label ID="Label54" class="control-label col-sm-3" Text="Sess3 Marks" runat="server"></asp:Label>
                                           <div class="col-sm-9">
                                               <asp:TextBox ID="txts3m3" placeholder="Enter Sessional Marks " class="form-control" runat="server"></asp:TextBox>&nbsp;
                                           </div>
                                        </div>
                                        <div class="form-group">
                                           <asp:Label ID="Label55" class="control-label col-sm-3" Text="Block Marks" runat="server"></asp:Label>
                                           <div class="col-sm-9">
                                               <asp:TextBox ID="txts3bm" placeholder="Enter Sessional Marks " class="form-control" runat="server"></asp:TextBox>&nbsp;
                                           </div>
                                        </div>
                                        <div class="form-group">
                                           <asp:Label ID="Label56" class="control-label col-sm-3" Text="Remedial Marks" runat="server"></asp:Label>
                                           <div class="col-sm-9">
                                               <asp:TextBox ID="txts3rm" placeholder="Enter Sessional Marks " class="form-control" runat="server"></asp:TextBox>&nbsp;
                                           </div>
                                        </div>
                                        <br />



                                        <div class="form-group">
                                        <asp:Label ID="lbls4" Font-Underline="true" Font-Bold="true" class="control-label col-sm-3" runat="server"></asp:Label>
                                            </div>
                                        <div class="form-group">
                                           <asp:Label ID="Label58" class="control-label col-sm-3" Text="Sess1 Marks" runat="server"></asp:Label>
                                           <div class="col-sm-9">
                                               <asp:TextBox ID="txts4m1" placeholder="Enter Sessional Marks " class="form-control" runat="server"></asp:TextBox>&nbsp;
                                           </div>
                                        </div>
                                        <div class="form-group">
                                           <asp:Label ID="Label59" class="control-label col-sm-3" Text="Sess2 Marks" runat="server"></asp:Label>
                                           <div class="col-sm-9">
                                               <asp:TextBox ID="txts4m2" placeholder="Enter Sessional Marks " class="form-control" runat="server"></asp:TextBox>&nbsp;
                                           </div>
                                        </div>
                                        <div class="form-group">
                                           <asp:Label ID="Label60" class="control-label col-sm-3" Text="Sess3 Marks" runat="server"></asp:Label>
                                           <div class="col-sm-9">
                                               <asp:TextBox ID="txts4m3" placeholder="Enter Sessional Marks " class="form-control" runat="server"></asp:TextBox>&nbsp;
                                           </div>
                                        </div>
                                        <div class="form-group">
                                           <asp:Label ID="Label61" class="control-label col-sm-3" Text="Block Marks" runat="server"></asp:Label>
                                           <div class="col-sm-9">
                                               <asp:TextBox ID="txts4bm" placeholder="Enter Sessional Marks " class="form-control" runat="server"></asp:TextBox>&nbsp;
                                           </div>
                                        </div>
                                        <div class="form-group">
                                           <asp:Label ID="Label62" class="control-label col-sm-3" Text="Remedial Marks" runat="server"></asp:Label>
                                           <div class="col-sm-9">
                                               <asp:TextBox ID="txts4rm" placeholder="Enter Sessional Marks " class="form-control" runat="server"></asp:TextBox>&nbsp;
                                           </div>
                                        </div>
                                        <br />



                                        <div class="form-group">
                                        <asp:Label ID="lbls5" Font-Underline="true" Font-Bold="true" class="control-label col-sm-3" runat="server"></asp:Label>
                                            </div>
                                        <div class="form-group">
                                           <asp:Label ID="Label64" class="control-label col-sm-3" Text="Sess1 Marks" runat="server"></asp:Label>
                                           <div class="col-sm-9">
                                               <asp:TextBox ID="txts5m1" placeholder="Enter Sessional Marks " class="form-control" runat="server"></asp:TextBox>&nbsp;
                                           </div>
                                        </div>
                                        <div class="form-group">
                                           <asp:Label ID="Label65" class="control-label col-sm-3" Text="Sess2 Marks" runat="server"></asp:Label>
                                           <div class="col-sm-9">
                                               <asp:TextBox ID="txts5m2" placeholder="Enter Sessional Marks " class="form-control" runat="server"></asp:TextBox>&nbsp;
                                           </div>
                                        </div>
                                        <div class="form-group">
                                           <asp:Label ID="Label66" class="control-label col-sm-3" Text="Sess3 Marks" runat="server"></asp:Label>
                                           <div class="col-sm-9">
                                               <asp:TextBox ID="txts5m3" placeholder="Enter Sessional Marks " class="form-control" runat="server"></asp:TextBox>&nbsp;
                                           </div>
                                        </div>
                                        <div class="form-group">
                                           <asp:Label ID="Label67" class="control-label col-sm-3" Text="Block Marks" runat="server"></asp:Label>
                                           <div class="col-sm-9">
                                               <asp:TextBox ID="txts5bm" placeholder="Enter Sessional Marks " class="form-control" runat="server"></asp:TextBox>&nbsp;
                                           </div>
                                        </div>
                                        <div class="form-group">
                                           <asp:Label ID="Label68" class="control-label col-sm-3" Text="Remedial Marks" runat="server"></asp:Label>
                                           <div class="col-sm-9">
                                               <asp:TextBox ID="txts5rm" placeholder="Enter Sessional Marks " class="form-control" runat="server"></asp:TextBox>&nbsp;
                                           </div>
                                        </div>
                                        



                                        <asp:MultiView runat="server" ID="mvextrasubinternal">
                                            <asp:View runat="server"></asp:View>
                                            <asp:View runat="server">
                                                <br />
                                        

                                                    <div class="form-group">
                                        <asp:Label ID="lbls6" Font-Underline="true" Font-Bold="true" class="control-label col-sm-3" runat="server"></asp:Label>
                                            </div>
                                        <div class="form-group">
                                           <asp:Label ID="Label51" class="control-label col-sm-3" Text="Sess1 Marks" runat="server"></asp:Label>
                                           <div class="col-sm-9">
                                               <asp:TextBox ID="txts6m1" placeholder="Enter Sessional Marks " class="form-control" runat="server"></asp:TextBox>&nbsp;
                                           </div>
                                        </div>
                                        <div class="form-group">
                                           <asp:Label ID="Label57" class="control-label col-sm-3" Text="Sess2 Marks" runat="server"></asp:Label>
                                           <div class="col-sm-9">
                                               <asp:TextBox ID="txts6m2" placeholder="Enter Sessional Marks " class="form-control" runat="server"></asp:TextBox>&nbsp;
                                           </div>
                                        </div>
                                        <div class="form-group">
                                           <asp:Label ID="Label63" class="control-label col-sm-3" Text="Sess3 Marks" runat="server"></asp:Label>
                                           <div class="col-sm-9">
                                               <asp:TextBox ID="txts6m3" placeholder="Enter Sessional Marks " class="form-control" runat="server"></asp:TextBox>&nbsp;
                                           </div>
                                        </div>
                                        <div class="form-group">
                                           <asp:Label ID="Label69" class="control-label col-sm-3" Text="Block Marks" runat="server"></asp:Label>
                                           <div class="col-sm-9">
                                               <asp:TextBox ID="txts6bm" placeholder="Enter Sessional Marks " class="form-control" runat="server"></asp:TextBox>&nbsp;
                                           </div>
                                        </div>
                                        <div class="form-group">
                                           <asp:Label ID="Label70" class="control-label col-sm-3" Text="Remedial Marks" runat="server"></asp:Label>
                                           <div class="col-sm-9">
                                               <asp:TextBox ID="txts6rm" placeholder="Enter Sessional Marks " class="form-control" runat="server"></asp:TextBox>&nbsp;
                                           </div>
                                        </div>
                                        

                                            </asp:View>
                                        </asp:MultiView>

                                        <br />
                                        <div class="form-group">
                                            <div class="col-sm-offset-3 col-sm-9">
                                            <asp:Button ID="btnsave" runat="server" CssClass="btn btn-default" Text="Save" Width="120px" OnClick="btnsave_Click" />&nbsp;&nbsp;                                            
                                            <asp:Label ID="lblsaveerror" runat="server" Text=""></asp:Label>
                                            </div>
                                        </div>


                                    </div>

                                </div>
                                </div>

                    </fieldset>

                    <br />

                    <fieldset>
                        <legend><h4>Externals</h4></legend>

                        <asp:GridView ID="gvexterals" CellPadding="5" runat="server" OnRowDataBound="gvexterals_RowDataBound" AllowSorting="true" Width="700px"></asp:GridView>

                        <br /><br />

                        <div class="panel panel-default" style="height:100%; width:100%;">
                                <div class="panel-heading" style="text-align:center" ><b>Update Results</b></div>
                                <div class="panel-body" style="padding:15px">

                                    
                                    <div class="container form-horizontal" style="margin-left:-100px">


                                        <div class="form-group">
                                        <asp:Label ID="lbls1name" Font-Underline="true" Font-Bold="true" class="control-label col-sm-3" runat="server"></asp:Label>
                                            </div>
                                        <div class="form-group">
                                           <asp:Label ID="Label4" class="control-label col-sm-3" Text="Exam Marks" runat="server"></asp:Label>
                                           <div class="col-sm-9">
                                               <asp:TextBox ID="txts1m" placeholder="Enter External Marks " class="form-control" runat="server"></asp:TextBox>&nbsp;
                                           </div>
                                        </div>
                                        <div class="form-group">
                                           <asp:Label ID="Label5" class="control-label col-sm-3" Text="Practical Marks" runat="server"></asp:Label>
                                           <div class="col-sm-9">
                                               <asp:TextBox ID="txts1pm" placeholder="Enter External Marks " class="form-control" runat="server"></asp:TextBox>&nbsp;
                                           </div>
                                        </div>
                                        <div class="form-group">
                                           <asp:Label ID="Label6" class="control-label col-sm-3" Text="Rem1 Marks" runat="server"></asp:Label>
                                           <div class="col-sm-9">
                                               <asp:TextBox ID="txts1r1" placeholder="Enter External Marks " class="form-control" runat="server"></asp:TextBox>&nbsp;
                                           </div>
                                        </div>
                                        <div class="form-group">
                                           <asp:Label ID="Label7" class="control-label col-sm-3" Text="Rem2 Marks" runat="server"></asp:Label>
                                           <div class="col-sm-9">
                                               <asp:TextBox ID="txts1r2" placeholder="Enter External Marks " class="form-control" runat="server"></asp:TextBox>&nbsp;
                                           </div>
                                        </div>
                                        <div class="form-group">
                                           <asp:Label ID="Label8" class="control-label col-sm-3" Text="Grade" runat="server"></asp:Label>
                                           <div class="col-sm-9">
                                               <asp:TextBox ID="txts1grade" placeholder="Enter External Marks " class="form-control" runat="server"></asp:TextBox>&nbsp;
                                           </div>
                                        </div>
                                        <div class="form-group">
                                           <asp:Label ID="Label9" class="control-label col-sm-3" Text="Status" runat="server"></asp:Label>
                                           <div class="col-sm-9">
                                               <asp:TextBox ID="txts1stat" placeholder="Enter External Marks " class="form-control" runat="server"></asp:TextBox>&nbsp;
                                           </div>
                                        </div>
                                        
                                        <br />



                                        <div class="form-group">
                                        <asp:Label ID="lbls2name" class="control-label col-sm-3" Font-Underline="true" Font-Bold="true" runat="server"></asp:Label>
                                            </div>
                                        <div class="form-group">
                                           <asp:Label ID="Label11" class="control-label col-sm-3" Text="Exam Marks" runat="server"></asp:Label>
                                           <div class="col-sm-9">
                                               <asp:TextBox ID="txts2m" placeholder="Enter External Marks " class="form-control" runat="server"></asp:TextBox>&nbsp;
                                           </div>
                                        </div>
                                        <div class="form-group">
                                           <asp:Label ID="Label12" class="control-label col-sm-3" Text="Practical Marks" runat="server"></asp:Label>
                                           <div class="col-sm-9">
                                               <asp:TextBox ID="txts2pm" placeholder="Enter External Marks " class="form-control" runat="server"></asp:TextBox>&nbsp;
                                           </div>
                                        </div>
                                        <div class="form-group">
                                           <asp:Label ID="Label13" class="control-label col-sm-3" Text="Rem1 Marks" runat="server"></asp:Label>
                                           <div class="col-sm-9">
                                               <asp:TextBox ID="txts2r1" placeholder="Enter External Marks " class="form-control" runat="server"></asp:TextBox>&nbsp;
                                           </div>
                                        </div>
                                        <div class="form-group">
                                           <asp:Label ID="Label14" class="control-label col-sm-3" Text="Rem2 Marks" runat="server"></asp:Label>
                                           <div class="col-sm-9">
                                               <asp:TextBox ID="txts2r2" placeholder="Enter External Marks " class="form-control" runat="server"></asp:TextBox>&nbsp;
                                           </div>
                                        </div>
                                        <div class="form-group">
                                           <asp:Label ID="Label15" class="control-label col-sm-3" Text="Grade" runat="server"></asp:Label>
                                           <div class="col-sm-9">
                                               <asp:TextBox ID="txts2grade" placeholder="Enter External Marks " class="form-control" runat="server"></asp:TextBox>&nbsp;
                                           </div>
                                        </div>
                                        <div class="form-group">
                                           <asp:Label ID="Label16" class="control-label col-sm-3" Text="Status" runat="server"></asp:Label>
                                           <div class="col-sm-9">
                                               <asp:TextBox ID="txts2stat" placeholder="Enter External Marks " class="form-control" runat="server"></asp:TextBox>&nbsp;
                                           </div>
                                        </div>
                                       
                                        <br />


                                        <div class="form-group">
                                        <asp:Label ID="lbls3name" class="control-label col-sm-3"  Font-Underline="true" Font-Bold="true" runat="server"></asp:Label>
                                            </div>
                                        <div class="form-group">
                                           <asp:Label ID="Label18" class="control-label col-sm-3" Text="Exam Marks" runat="server"></asp:Label>
                                           <div class="col-sm-9">
                                               <asp:TextBox ID="txts3m" placeholder="Enter External Marks " class="form-control" runat="server"></asp:TextBox>&nbsp;
                                           </div>
                                        </div>
                                        <div class="form-group">
                                           <asp:Label ID="Label19" class="control-label col-sm-3" Text="Practical Marks" runat="server"></asp:Label>
                                           <div class="col-sm-9">
                                               <asp:TextBox ID="txts3pm" placeholder="Enter External Marks " class="form-control" runat="server"></asp:TextBox>&nbsp;
                                           </div>
                                        </div>
                                        <div class="form-group">
                                           <asp:Label ID="Label20" class="control-label col-sm-3" Text="Rem1 Marks" runat="server"></asp:Label>
                                           <div class="col-sm-9">
                                               <asp:TextBox ID="txts3r1" placeholder="Enter External Marks " class="form-control" runat="server"></asp:TextBox>&nbsp;
                                           </div>
                                        </div>
                                        <div class="form-group">
                                           <asp:Label ID="Label21" class="control-label col-sm-3" Text="Rem2 Marks" runat="server"></asp:Label>
                                           <div class="col-sm-9">
                                               <asp:TextBox ID="txts3r2" placeholder="Enter External Marks " class="form-control" runat="server"></asp:TextBox>&nbsp;
                                           </div>
                                        </div>
                                        <div class="form-group">
                                           <asp:Label ID="Label22" class="control-label col-sm-3" Text="Grade" runat="server"></asp:Label>
                                           <div class="col-sm-9">
                                               <asp:TextBox ID="txts3grade" placeholder="Enter External Marks " class="form-control" runat="server"></asp:TextBox>&nbsp;
                                           </div>
                                        </div>
                                        <div class="form-group">
                                           <asp:Label ID="Label23" class="control-label col-sm-3" Text="Status" runat="server"></asp:Label>
                                           <div class="col-sm-9">
                                               <asp:TextBox ID="txts3stat" placeholder="Enter External Marks " class="form-control" runat="server"></asp:TextBox>&nbsp;
                                           </div>
                                        </div>
                                        
                                        <br />


                                        <div class="form-group">
                                        <asp:Label ID="lbls4name" class="control-label col-sm-3" Font-Underline="true" Font-Bold="true" runat="server"></asp:Label>
                                            </div>
                                        <div class="form-group">
                                           <asp:Label ID="Label25" class="control-label col-sm-3" Text="Exam Marks" runat="server"></asp:Label>
                                           <div class="col-sm-9">
                                               <asp:TextBox ID="txts4m" placeholder="Enter External Marks " class="form-control" runat="server"></asp:TextBox>&nbsp;
                                           </div>
                                        </div>
                                        <div class="form-group">
                                           <asp:Label ID="Label26" class="control-label col-sm-3" Text="Practical Marks" runat="server"></asp:Label>
                                           <div class="col-sm-9">
                                               <asp:TextBox ID="txts4pm" placeholder="Enter External Marks " class="form-control" runat="server"></asp:TextBox>&nbsp;
                                           </div>
                                        </div>
                                        <div class="form-group">
                                           <asp:Label ID="Label27" class="control-label col-sm-3" Text="Rem1 Marks" runat="server"></asp:Label>
                                           <div class="col-sm-9">
                                               <asp:TextBox ID="txts4r1" placeholder="Enter External Marks " class="form-control" runat="server"></asp:TextBox>&nbsp;
                                           </div>
                                        </div>
                                        <div class="form-group">
                                           <asp:Label ID="Label28" class="control-label col-sm-3" Text="Rem2 Marks" runat="server"></asp:Label>
                                           <div class="col-sm-9">
                                               <asp:TextBox ID="txts4r2" placeholder="Enter External Marks " class="form-control" runat="server"></asp:TextBox>&nbsp;
                                           </div>
                                        </div>
                                        <div class="form-group">
                                           <asp:Label ID="Label29" class="control-label col-sm-3" Text="Grade" runat="server"></asp:Label>
                                           <div class="col-sm-9">
                                               <asp:TextBox ID="txts4grade" placeholder="Enter External Marks " class="form-control" runat="server"></asp:TextBox>&nbsp;
                                           </div>
                                        </div>
                                        <div class="form-group">
                                           <asp:Label ID="Label30" class="control-label col-sm-3" Text="Status" runat="server"></asp:Label>
                                           <div class="col-sm-9">
                                               <asp:TextBox ID="txts4stat" placeholder="Enter External Marks " class="form-control" runat="server"></asp:TextBox>&nbsp;
                                           </div>
                                        </div>
                                       
                                        <br />


                                        <div class="form-group">
                                        <asp:Label ID="lbls5name" class="control-label col-sm-3" Font-Underline="true" Font-Bold="true" runat="server"></asp:Label>
                                            </div>
                                        <div class="form-group">
                                           <asp:Label ID="Label32" class="control-label col-sm-3" Text="Exam Marks" runat="server"></asp:Label>
                                           <div class="col-sm-9">
                                               <asp:TextBox ID="txts5m" placeholder="Enter External Marks " class="form-control" runat="server"></asp:TextBox>&nbsp;
                                           </div>
                                        </div>
                                        <div class="form-group">
                                           <asp:Label ID="Label33" class="control-label col-sm-3" Text="Practical Marks" runat="server"></asp:Label>
                                           <div class="col-sm-9">
                                               <asp:TextBox ID="txts5pm" placeholder="Enter External Marks " class="form-control" runat="server"></asp:TextBox>&nbsp;
                                           </div>
                                        </div>
                                        <div class="form-group">
                                           <asp:Label ID="Label34" class="control-label col-sm-3" Text="Rem1 Marks" runat="server"></asp:Label>
                                           <div class="col-sm-9">
                                               <asp:TextBox ID="txts5r1" placeholder="Enter External Marks " class="form-control" runat="server"></asp:TextBox>&nbsp;
                                           </div>
                                        </div>
                                        <div class="form-group">
                                           <asp:Label ID="Label35" class="control-label col-sm-3" Text="Rem2 Marks" runat="server"></asp:Label>
                                           <div class="col-sm-9">
                                               <asp:TextBox ID="txts5r2" placeholder="Enter External Marks " class="form-control" runat="server"></asp:TextBox>&nbsp;
                                           </div>
                                        </div>
                                        <div class="form-group">
                                           <asp:Label ID="Label36" class="control-label col-sm-3" Text="Grade" runat="server"></asp:Label>
                                           <div class="col-sm-9">
                                               <asp:TextBox ID="txts5grade" placeholder="Enter External Marks " class="form-control" runat="server"></asp:TextBox>&nbsp;
                                           </div>
                                        </div>
                                        <div class="form-group">
                                           <asp:Label ID="Label37" class="control-label col-sm-3" Text="Status" runat="server"></asp:Label>
                                           <div class="col-sm-9">
                                               <asp:TextBox ID="txts5stat" placeholder="Enter External Marks " class="form-control" runat="server"></asp:TextBox>&nbsp;
                                           </div>
                                        </div>
                                        
                                        <asp:MultiView ID="mvexternalsubject" runat="server">
                                            <asp:View runat="server"></asp:View>
                                            <asp:View runat="server">

                                            
                                        <br />


                                        <div class="form-group">
                                        <asp:Label ID="lbls6name" class="control-label col-sm-3" Font-Underline="true" Font-Bold="true" runat="server"></asp:Label>
                                            </div>
                                        <div class="form-group">
                                           <asp:Label ID="Label39" class="control-label col-sm-3" Text="Exam Marks" runat="server"></asp:Label>
                                           <div class="col-sm-9">
                                               <asp:TextBox ID="txts6m" placeholder="Enter External Marks " class="form-control" runat="server"></asp:TextBox>&nbsp;
                                           </div>
                                        </div>
                                        <div class="form-group">
                                           <asp:Label ID="Label40" class="control-label col-sm-3" Text="Practical Marks" runat="server"></asp:Label>
                                           <div class="col-sm-9">
                                               <asp:TextBox ID="txts6pm" placeholder="Enter External Marks " class="form-control" runat="server"></asp:TextBox>&nbsp;
                                           </div>
                                        </div>
                                        <div class="form-group">
                                           <asp:Label ID="Label41" class="control-label col-sm-3" Text="Rem1 Marks" runat="server"></asp:Label>
                                           <div class="col-sm-9">
                                               <asp:TextBox ID="txts6r1" placeholder="Enter External Marks " class="form-control" runat="server"></asp:TextBox>&nbsp;
                                           </div>
                                        </div>
                                        <div class="form-group">
                                           <asp:Label ID="Label42" class="control-label col-sm-3" Text="Rem2 Marks" runat="server"></asp:Label>
                                           <div class="col-sm-9">
                                               <asp:TextBox ID="txts6r2" placeholder="Enter External Marks " class="form-control" runat="server"></asp:TextBox>&nbsp;
                                           </div>
                                        </div>
                                        <div class="form-group">
                                           <asp:Label ID="Label43" class="control-label col-sm-3" Text="Grade" runat="server"></asp:Label>
                                           <div class="col-sm-9">
                                               <asp:TextBox ID="txts6grade" placeholder="Enter External Marks " class="form-control" runat="server"></asp:TextBox>&nbsp;
                                           </div>
                                        </div>
                                        <div class="form-group">
                                           <asp:Label ID="Label44" class="control-label col-sm-3" Text="Status" runat="server"></asp:Label>
                                           <div class="col-sm-9">
                                               <asp:TextBox ID="txts6stat" placeholder="Enter External Marks " class="form-control" runat="server"></asp:TextBox>&nbsp;
                                           </div>
                                        </div>

                                            </asp:View>
                                        </asp:MultiView>

                                        
                                        
                                                <br />

                                        <div class="form-group">
                                            <div class="col-sm-offset-3 col-sm-9">
                                            <asp:Button ID="btnsaveex" runat="server" CssClass="btn btn-default" Text="Save" Width="120px" OnClick="btnsaveex_Click" />&nbsp;&nbsp;                                            
                                            <asp:Label ID="lblsaveexerror" runat="server" Text=""></asp:Label>
                                            </div>
                                        </div>

                                  </div>
                                </div>
                        </div>
                    </fieldset>
                </asp:View>
            </asp:MultiView>
        </fieldset>
    </div>
    <div class="col-sm-1"></div>
    <div class="col-sm-3">


        <br /><br /><br /><br /><br /><br /><br /><br />
        <asp:MultiView ID="mvadvancesemester" runat="server">
            <asp:View runat="server"></asp:View>
            <asp:View runat="server">


        <div class="panel panel-default" style="height:100%; width:100%;">
            <div class="panel-heading" style="text-align:center" ><b>Advance Semester</b></div>
            <div class="panel-body" style="padding:15px">
                                    
            <div class="container">

                <div class="form-group">
                   <asp:Label ID="Label45" class="control-label" Text="Attendance" runat="server"></asp:Label>                   
                  <asp:TextBox ID="txtattendance" OnTextChanged="txtattendance_TextChanged" placeholder="Enter Attendance" class="form-control" runat="server"></asp:TextBox>
                  
                </div>

                <div class="form-group">
                         <asp:Button ID="btnpass" runat="server" CssClass="btn btn-default" Text="Advance Semester" Width="180px" OnClick="btnpass_Click" />                                           
                         
                    </div>
                
                <div class="form-group">
                    <asp:Label ID="lblpasserror" runat="server" Text=""></asp:Label>
                </div>

                <asp:MultiView ID="mvnewsem" runat="server">
                    <asp:View runat="server"></asp:View>
                    <asp:View runat="server">

                        <div class="form-group">
                           <asp:Label ID="Label72" class="control-label" Text="Roll No." runat="server"></asp:Label>
                           
                              <asp:TextBox ID="txtrollno" placeholder="Enter New Roll No." class="form-control" runat="server"></asp:TextBox>
                           
                        </div>
                        <div class="form-group">
                           <asp:Label ID="Label73" class="control-label" Text="Class" runat="server"></asp:Label>
                           
                              <asp:TextBox ID="txtdiv"  placeholder="Enter New Class" class="form-control" runat="server"></asp:TextBox>
                           
                        </div>
                        <div class="form-group">
                            <asp:Label ID="Label74" class="control-label" Text="Batch" runat="server"></asp:Label>
                            
                                <asp:TextBox ID="txtbatch" placeholder="Enter New Batch" class="form-control" runat="server"></asp:TextBox>&nbsp;
                            
                        </div>
                        <div class="form-group">
                            <asp:Label ID="Label75" class="control-label" Text="Repeat" runat="server"></asp:Label>
                            
                                <asp:CheckBox ID="cbkattempt" runat="server" />
                            
                        </div>

                    <div class="form-group">
                    <div class="col-sm-offset-3 col-sm-9">
                         <asp:Button ID="btncreate" runat="server" CssClass="btn btn-default" Text="Save" Width="120px" OnClick="btncreate_Click" />&nbsp;&nbsp;                                            
                         <asp:Label ID="lblcreateerror" runat="server" Text=""></asp:Label>
                    </div>

                </div>

                    </asp:View>
                </asp:MultiView>



            </div>
            </div>
        </div>

                </asp:View>
        </asp:MultiView>

    </div>


</div>
</div>

<br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
</asp:Content>
