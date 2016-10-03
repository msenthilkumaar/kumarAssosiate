<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.master" AutoEventWireup="true" CodeFile="UserHome.aspx.cs" Inherits="UserHome" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
.rsCategoryBlue
{
    background-color:Red;
}
.rsCategoryOrange
{
    background-color:Orange;
}
.rsCategoryGreen
{
    background-color:Green;
}
.rsCategoryRed
{
    background-color:Red;
}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContBody" Runat="Server">

    <telerik:RadScriptManager runat="server" ID="RadScriptManager1" />
    <telerik:RadSkinManager ID="RadSkinManager1" runat="server" ShowChooser="false" />
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadScheduler1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadScheduler1" LoadingPanelID="RadAjaxLoadingPanel1">
                    </telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
    </telerik:RadAjaxLoadingPanel>


    <div class="row">
    <div class="col-md-12">
        <asp:Label ID="lblGroup" runat="server" Text="Select Group"></asp:Label><br />
        <asp:DropDownList ID="ddlGroup" runat="server" CssClass="form-control" 
            AutoPostBack="True" onselectedindexchanged="ddlGroup_SelectedIndexChanged">
        </asp:DropDownList>
    </div>
    </div>
    <br />

     <div class="demo-container no-bg">
        <telerik:RadScheduler runat="server" ID="RadScheduler1" AdvancedForm-Enabled="true"
             DataKeyField="D_rid" DataSubjectField="Place" EnableAdvancedForm="true"
            DataStartField="D_Time" DataEndField="D_Time2" DataSourceID="SqlDataSource1"
            OverflowBehavior="Auto" Height="" DataDescriptionField="Remarks" 
             DataReminderField="D_Date" EnableViewState="true" 
             SelectedView="MonthView" AllowDelete="false" AllowInsert="false" 
             EnableTheming="False">
             <%--<ResourceStyles>
                <telerik:ResourceStyleMapping Type="Calendar" Text="1" BackColor="#D0ECBB"
                    BorderColor="#B0CC9B"></telerik:ResourceStyleMapping>
                <telerik:ResourceStyleMapping Type="Calendar" Text="2" BackColor="red"
                    BorderColor="Black"></telerik:ResourceStyleMapping>
                <telerik:ResourceStyleMapping Type="Calendar" Text="Work" ApplyCssClass="rsCategoryGreen"></telerik:ResourceStyleMapping>
                <telerik:ResourceStyleMapping Type="Calendar" Text="Personal" ApplyCssClass="rsCategoryRed"></telerik:ResourceStyleMapping>
            </ResourceStyles>--%>
        </telerik:RadScheduler>
       
         <br />
         <asp:Label ID="lblErrors" runat="server" Text="" ForeColor="Red"></asp:Label>
         <br />
         <div class="row"><br />
         <div class="alert-info" style="height:150px">
             <asp:Label ID="Label1" runat="server" Text="Send Message to Admin"></asp:Label>
             <asp:TextBox ID="txtMessage" runat="server" TextMode="MultiLine" Width="80%" style="height:100px"></asp:TextBox>
             <asp:Button ID="Button1" runat="server" Text="Send" CssClass="btn btn-info" 
                 onclick="Button1_Click" />
         </div>
         </div>

         <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
             ConnectionString="<%$ ConnectionStrings:AssoConnString %>" 
            >
         </asp:SqlDataSource>
    </div>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContFooter" Runat="Server">
</asp:Content>

