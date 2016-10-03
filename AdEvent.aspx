<%@ Page Title="" Language="C#" MasterPageFile="~/SubAdmin.master" AutoEventWireup="true" CodeFile="AdEvent.aspx.cs" Inherits="AdEvent" EnableEventValidation="false" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContBody" Runat="Server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    <Scripts>
        <asp:ScriptReference Assembly="Telerik.Web.UI" 
            Name="Telerik.Web.UI.Common.Core.js">
        </asp:ScriptReference>
        <asp:ScriptReference Assembly="Telerik.Web.UI" 
            Name="Telerik.Web.UI.Common.jQuery.js">
        </asp:ScriptReference>
        <asp:ScriptReference Assembly="Telerik.Web.UI" 
            Name="Telerik.Web.UI.Common.jQueryInclude.js">
        </asp:ScriptReference>
    </Scripts>
</telerik:RadScriptManager>
<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
</telerik:RadAjaxManager>
<div class="row">
<div class="col-md-6">
Select Periods
    <asp:DropDownList ID="ddlYear" runat="server" CssClass="form-control">
    <asp:ListItem>2016-2017 </asp:ListItem>
    <asp:ListItem>2017-2018 </asp:ListItem>
    <asp:ListItem>2018-2019 </asp:ListItem>
    <asp:ListItem>2019-2020 </asp:ListItem>
    <asp:ListItem>2020-2021 </asp:ListItem>
    <asp:ListItem>2021-2022 </asp:ListItem>
    <asp:ListItem>2022-2023 </asp:ListItem>
    <asp:ListItem>2023-2024 </asp:ListItem>
    <asp:ListItem>2024-2025 </asp:ListItem>
    <asp:ListItem>2025-2026 </asp:ListItem>

    </asp:DropDownList><br />
   
   Select Group
    
    <asp:DropDownList ID="ddlGroup" runat="server" CssClass="form-control">
    </asp:DropDownList>
    <br />
   
    <telerik:RadDatePicker ID="RadDatePicker1" runat="server" AutoPostBack="True" 
        onselecteddatechanged="RadDatePicker1_SelectedDateChanged">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" EnableWeekends="True"></Calendar>

<DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%" 
            AutoPostBack="True">
<EmptyMessageStyle Resize="None"></EmptyMessageStyle>

<ReadOnlyStyle Resize="None"></ReadOnlyStyle>

<FocusedStyle Resize="None"></FocusedStyle>

<DisabledStyle Resize="None"></DisabledStyle>

<InvalidStyle Resize="None"></InvalidStyle>

<HoveredStyle Resize="None"></HoveredStyle>

<EnabledStyle Resize="None"></EnabledStyle>
</DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
    </telerik:RadDatePicker>
   
&nbsp;&nbsp;&nbsp;
   
<telerik:RadTimePicker RenderMode="Lightweight" ID="RadTimePicker1" runat="server"  DateInput-Label="Star@:"
                        Width="150px" Font-Bold="True" Font-Size="Large">
                    </telerik:RadTimePicker>  


                      <telerik:RadTimePicker RenderMode="Lightweight" ID="RadTimePicker2" runat="server"  DateInput-Label="End@:"
                        Width="150px" Font-Bold="True" Font-Size="Large">
                    </telerik:RadTimePicker>
  <br />  <br />
    <asp:Label ID="Label3" runat="server" Text="Selected Date :  " 
        Font-Size="Large"></asp:Label>
    <asp:Label ID="lblDate" runat="server" Font-Bold="True" Font-Size="Large" 
        ForeColor="#000066"></asp:Label> <asp:Label ID="lblDay" runat="server" Text="" Visible="false">
   </asp:Label>
   

    <asp:Label ID="lblRID" runat="server" Text="" Visible="false">
   </asp:Label>

    <br />  
    <asp:Label ID="Label1" runat="server" Text="Place"></asp:Label><br />
    <asp:TextBox ID="txtPlace" runat="server" CssClass="form-control"></asp:TextBox>
    <asp:CheckBox ID="chkactive" runat="server" text="Is Active"/>
    <br /><asp:Label ID="Label2" runat="server" Text="Remarks"></asp:Label>
    <asp:TextBox ID="txtMessages" runat="server" CssClass="form-control" 
        TextMode="MultiLine"></asp:TextBox>
    <br />
    <asp:Button ID="btnSave" runat="server" Text="Make Event" CssClass="btn btn-success"
        onclick="btnSave_Click" />





  
&nbsp;<asp:Label ID="lblMessages" runat="server" Text=""></asp:Label>





  
</div>

<div class="col-md-6">
<h3>Active Events </h3>
 <asp:GridView ID="GVEvent" runat="server" onrowdatabound="GVEvent_RowDataBound"  class="table table-striped table-bordered table-hover dataTable no-footer" 
        onselectedindexchanged="GVEvent_SelectedIndexChanged">
    </asp:GridView>

</div>

</div>
<hr />

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContFooter" Runat="Server">
</asp:Content>

