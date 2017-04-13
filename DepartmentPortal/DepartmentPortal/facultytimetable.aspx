<%@ Page Title="" Language="C#" MasterPageFile="~/Faculty.Master" AutoEventWireup="true" CodeBehind="facultytimetable.aspx.cs" Inherits="DepartmentPortal.facultytimetable" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div class="container-fluid">
<div class="row">
    <div class="col-sm-12">
        <fieldset>
            <legend>Manage TimeTable</legend>
            <div class="form-horizontal" style="margin-left:-150px">

                <fieldset><legend>Search</legend>
                <div class="form-group">
                            <asp:Label ID="Label34" class="control-label col-sm-3" runat="server" Text="Semester : "></asp:Label>
                            <div class="col-sm-9">
                                <asp:DropDownList ID="ddlsrchsem" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                <div class="form-group">
                            <asp:Label ID="Label35" class="control-label col-sm-3" runat="server" Text="Enter Branch : "></asp:Label>
                            <div class="col-sm-9">
                                <asp:DropDownList ID="ddlsrchbranch" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                <div class="form-group">
                            <asp:Label ID="Label36" class="control-label col-sm-3" runat="server" Text="Enter Division : "></asp:Label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="txtsrchdiv" placeholder="Enter Division" class="form-control" runat="server"></asp:TextBox> 
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="Label37" class="control-label col-sm-3" runat="server" Text="Enter Batch : "></asp:Label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="txtsrchbatch" placeholder="Enter Batch" class="form-control" runat="server"></asp:TextBox> 
                            </div>
                        </div>

                    <div class="form-group">
                            <div class="col-sm-offset-3 col-sm-9">

                            <asp:Button ID="btnsearch" runat="server" CssClass="btn btn-default" Text="Submit" Width="120px" OnClick="btnsearch_Click" />&nbsp;&nbsp;
                            <asp:Label ID="lblsrch" runat="server" Text=""></asp:Label>
                                <br />
                                <asp:GridView ID="gvtimetable" RowStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="Medium" OnRowDataBound="gvtimetable_RowDataBound" CellPadding="8" Width="1000px" runat="server" HeaderStyle-Height="20px" HeaderStyle-Wrap="False" RowStyle-Wrap="false"></asp:GridView>
                        </div>
                        </div>

                    </fieldset>

            </div>
        
        <fieldset>
            <legend>Create TimeTable</legend>            
            <div class="form-horizontal" style="margin-left:-150px">

                    <div class="form-group">
                            <asp:Label ID="Label9" class="control-label col-sm-3" runat="server" Text="Semester : "></asp:Label>
                            <div class="col-sm-9">
                                <asp:DropDownList ID="ddlsem" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="Label1" class="control-label col-sm-3" runat="server" Text="Enter Branch : "></asp:Label>
                            <div class="col-sm-9">
                                <asp:DropDownList ID="ddlbranch" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="Label2" class="control-label col-sm-3" runat="server" Text="Enter Division : "></asp:Label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="txtdiv" placeholder="Enter Division" class="form-control" runat="server"></asp:TextBox> 
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="Label3" class="control-label col-sm-3" runat="server" Text="Enter Batch : "></asp:Label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="txtbatch" placeholder="Enter Batch" class="form-control" runat="server"></asp:TextBox> 
                            </div>
                        </div>


                        <div class="form-group">
                            <asp:Label ID="Label4" class="control-label col-sm-3" runat="server" Text="Enter Slot 1 Time : "></asp:Label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txts1durfrom" TextMode="Time" placeholder="Enter Time From" class="form-control" runat="server"></asp:TextBox> 
                            </div>
                            <div class="col-sm-1">
                                <span>&nbsp;&nbsp&nbsp;&nbsp; TO &nbsp;&nbsp&nbsp;</span>
                            </div>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txts1durto" TextMode="Time" placeholder="Enter Time To" class="form-control" runat="server"></asp:TextBox> 
                            </div>
                            </div>

                        <div class="form-group">
                            <asp:Label ID="Label22" class="control-label col-sm-3" runat="server" Text="Enter Slot 2 Time : "></asp:Label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txts2durfrom" TextMode="Time" placeholder="Enter Time From" class="form-control" runat="server"></asp:TextBox> 
                            </div>
                            <div class="col-sm-1">
                                <span>&nbsp;&nbsp&nbsp;&nbsp; TO &nbsp;&nbsp&nbsp;</span>
                            </div>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txts2durto" TextMode="Time" placeholder="Enter Time To" class="form-control" runat="server"></asp:TextBox> 
                            </div>
                            </div>

                        <div class="form-group">
                            <asp:Label ID="Label23" class="control-label col-sm-3" runat="server" Text="Enter Slot 3 Time : "></asp:Label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txts3durfrom" TextMode="Time" placeholder="Enter Time From" class="form-control" runat="server"></asp:TextBox> 
                            </div>
                            <div class="col-sm-1">
                                <span>&nbsp;&nbsp&nbsp;&nbsp; TO &nbsp;&nbsp&nbsp;</span>
                            </div>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txts3durto" TextMode="Time" placeholder="Enter Time To" class="form-control" runat="server"></asp:TextBox> 
                            </div>
                            </div>

                        <div class="form-group">
                            <asp:Label ID="Label24" class="control-label col-sm-3" runat="server" Text="Enter Slot 4 Time : "></asp:Label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txts4durfrom" TextMode="Time" placeholder="Enter Time From" class="form-control" runat="server"></asp:TextBox> 
                            </div>
                            <div class="col-sm-1">
                                <span>&nbsp;&nbsp&nbsp;&nbsp; TO &nbsp;&nbsp&nbsp;</span>
                            </div>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txts4durto" TextMode="Time" placeholder="Enter Time To" class="form-control" runat="server"></asp:TextBox> 
                            </div>
                            </div>

                        <div class="form-group">
                            <asp:Label ID="Label25" class="control-label col-sm-3" runat="server" Text="Enter Slot 5 Time : "></asp:Label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txts5durfrom" TextMode="Time" placeholder="Enter Time From" class="form-control" runat="server"></asp:TextBox> 
                            </div>
                            <div class="col-sm-1">
                                <span>&nbsp;&nbsp&nbsp;&nbsp; TO &nbsp;&nbsp&nbsp;</span>
                            </div>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txts5durto" TextMode="Time" placeholder="Enter Time To" class="form-control" runat="server"></asp:TextBox> 
                            </div>
                            </div>

                        <div class="form-group">
                            <asp:Label ID="Label26" class="control-label col-sm-3" runat="server" Text="Enter Slot 6 Time : "></asp:Label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txts6durfrom" TextMode="Time" placeholder="Enter Time From" class="form-control" runat="server"></asp:TextBox> 
                            </div>
                            <div class="col-sm-1">
                                <span>&nbsp;&nbsp&nbsp;&nbsp; TO &nbsp;&nbsp&nbsp;</span>
                            </div>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txts6durto" TextMode="Time" placeholder="Enter Time To" class="form-control" runat="server"></asp:TextBox> 
                            </div>
                            </div>

                        <div class="form-group">
                            <asp:Label ID="Label27" class="control-label col-sm-3" runat="server" Text="Enter Slot 7 Time : "></asp:Label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txts7durfrom" TextMode="Time" placeholder="Enter Time From" class="form-control" runat="server"></asp:TextBox> 
                            </div>
                            <div class="col-sm-1">
                                <span>&nbsp;&nbsp&nbsp;&nbsp; TO &nbsp;&nbsp&nbsp;</span>
                            </div>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txts7durto" TextMode="Time" placeholder="Enter Time To" class="form-control" runat="server"></asp:TextBox> 
                            </div>
                            </div>


                        <div class="form-group">
                            <asp:Label ID="Label5" class="control-label col-sm-3" runat="server" Text="Enter Day : "></asp:Label>
                            <div class="col-sm-9">
                                <asp:DropDownList ID="ddlday" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                        </div>

                        <fieldset>
                            <legend>Slot 1</legend>
                            <div class="form-horizontal" style="margin-left:-150px">

                            <div class="form-group">
                            <asp:Label ID="Label7" class="control-label col-sm-3" runat="server" Text="Enter Subject Name : "></asp:Label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="txts1subname"  class="form-control" runat="server"></asp:TextBox> 
                            </div>
                            </div>
                            <div class="form-group">
                            <asp:Label ID="Label8" class="control-label col-sm-3" runat="server" Text="Enter Faculty : "></asp:Label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="txts1facname"  class="form-control" runat="server"></asp:TextBox> 
                            </div>
                            </div>
                            <div class="form-group">
                            <asp:Label ID="Label6" class="control-label col-sm-3" runat="server" Text="Is Lab? : "></asp:Label>
                            <div class="col-sm-9">
                                <asp:CheckBox ID="cbks1lab" runat="server" />
                            </div>
                            </div>
                            </div>
                        </fieldset>



                        <fieldset>
                            <legend>Slot 2</legend>
                            <div class="form-horizontal" style="margin-left:-150px">

                            <div class="form-group">
                            <asp:Label ID="Label12" class="control-label col-sm-3" runat="server" Text="Enter Subject Name : "></asp:Label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="txts2subname" class="form-control" runat="server"></asp:TextBox> 
                            </div>
                            </div>
                            <div class="form-group">
                            <asp:Label ID="Label13" class="control-label col-sm-3" runat="server" Text="Enter Faculty : "></asp:Label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="txts2facname" class="form-control" runat="server"></asp:TextBox> 
                            </div>
                            </div>
                            <div class="form-group">
                            <asp:Label ID="Label11" class="control-label col-sm-3" runat="server" Text="Is Lab? : "></asp:Label>
                            <div class="col-sm-9">
                                <asp:CheckBox ID="cbks2lab" runat="server" />
                            </div>
                            </div>
                            </div>
                        </fieldset>



                        <fieldset>
                            <legend>Slot 3</legend>
                            <div class="form-horizontal" style="margin-left:-150px">

                            <div class="form-group">
                            <asp:Label ID="Label16" class="control-label col-sm-3" runat="server" Text="Enter Subject Name : "></asp:Label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="txts3subname" class="form-control" runat="server"></asp:TextBox> 
                            </div>
                            </div>
                            <div class="form-group">
                            <asp:Label ID="Label17" class="control-label col-sm-3" runat="server" Text="Enter Faculty : "></asp:Label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="txts3facname"  class="form-control" runat="server"></asp:TextBox> 
                            </div>
                            </div>
                            <div class="form-group">
                            <asp:Label ID="Label15" class="control-label col-sm-3" runat="server" Text="Is Lab? : "></asp:Label>
                            <div class="col-sm-9">
                                <asp:CheckBox ID="cbks3lab" runat="server" />
                            </div>
                            </div>
                            </div>
                        </fieldset>
                        



                        <fieldset>
                            <legend>Slot 4</legend>
                            <div class="form-horizontal" style="margin-left:-150px">

                            <div class="form-group">
                            <asp:Label ID="Label20" class="control-label col-sm-3" runat="server" Text="Enter Subject Name : "></asp:Label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="txts4subname"  class="form-control" runat="server"></asp:TextBox> 
                            </div>
                            </div>
                            <div class="form-group">
                            <asp:Label ID="Label21" class="control-label col-sm-3" runat="server" Text="Enter Faculty : "></asp:Label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="txts4facname"  class="form-control" runat="server"></asp:TextBox> 
                            </div>
                            </div>

                            <div class="form-group">
                            <asp:Label ID="Label19" class="control-label col-sm-3" runat="server" Text="Is Lab? : "></asp:Label>
                            <div class="col-sm-9">
                                <asp:CheckBox ID="cbks4lab" runat="server" />
                            </div>
                            </div>
                            </div>
                        </fieldset>



                        <fieldset>
                            <legend>Slot 5</legend>
                            <div class="form-horizontal" style="margin-left:-150px">

                            <div class="form-group">
                            <asp:Label ID="Label10" class="control-label col-sm-3" runat="server" Text="Enter Subject Name : "></asp:Label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="txts5subname"  class="form-control" runat="server"></asp:TextBox> 
                            </div>
                            </div>
                            <div class="form-group">
                            <asp:Label ID="Label14" class="control-label col-sm-3" runat="server" Text="Enter Faculty : "></asp:Label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="txts5facname" class="form-control" runat="server"></asp:TextBox> 
                            </div>
                            </div>
                            <div class="form-group">
                            <asp:Label ID="Label18" class="control-label col-sm-3" runat="server" Text="Is Lab? : "></asp:Label>
                            <div class="col-sm-9">
                                <asp:CheckBox ID="cbks5lab" runat="server" />
                            </div>
                            </div>
                            </div>
                        </fieldset>


                        <fieldset>
                            <legend>Slot 6</legend>
                            <div class="form-horizontal" style="margin-left:-150px">

                            <div class="form-group">
                            <asp:Label ID="Label28" class="control-label col-sm-3" runat="server" Text="Enter Subject Name : "></asp:Label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="txts6subname" class="form-control" runat="server"></asp:TextBox> 
                            </div>
                            </div>
                            <div class="form-group">
                            <asp:Label ID="Label29" class="control-label col-sm-3" runat="server" Text="Enter Faculty : "></asp:Label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="txts6facname" class="form-control" runat="server"></asp:TextBox> 
                            </div>
                            </div>
                            <div class="form-group">
                            <asp:Label ID="Label30" class="control-label col-sm-3" runat="server" Text="Is Lab? : "></asp:Label>
                            <div class="col-sm-9">
                                <asp:CheckBox ID="cbks6lab"  runat="server" />
                            </div>
                            </div>
                            </div>
                        </fieldset>



                        <fieldset>
                            <legend>Slot 7</legend>
                            <div class="form-horizontal" style="margin-left:-150px">

                            <div class="form-group">
                            <asp:Label ID="Label31" class="control-label col-sm-3" runat="server" Text="Enter Subject Name : "></asp:Label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="txts7subname"  class="form-control" runat="server"></asp:TextBox> 
                            </div>
                            </div>
                            <div class="form-group">
                            <asp:Label ID="Label32" class="control-label col-sm-3" runat="server" Text="Enter Faculty : "></asp:Label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="txts7facname" class="form-control" runat="server"></asp:TextBox> 
                            </div>
                            </div>
                            <div class="form-group">
                            <asp:Label ID="Label33" class="control-label col-sm-3" runat="server" Text="Is Lab? : "></asp:Label>
                            <div class="col-sm-9">
                                <asp:CheckBox ID="cbks7lab" runat="server" />
                            </div>
                            </div>
                            </div>
                        </fieldset>
                        <div class="form-horizontal" style="margin-left:-150px">

                        <div class="form-group">
                            <div class="col-sm-offset-3 col-sm-9">

                            <asp:Button ID="btnsubmit" runat="server" CssClass="btn btn-default" Text="Submit" Width="120px" OnClick="btnsubmit_Click" />&nbsp;&nbsp;
                            <asp:Label ID="lblsubmiterror" runat="server" Text=""></asp:Label>
                        </div>
                        </div>
                        </div>
                   
        </fieldset>
            </fieldset>
    </div>
</div>
</div>
    

</asp:Content>
