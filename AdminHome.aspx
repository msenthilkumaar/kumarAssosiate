<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="AdminHome.aspx.cs" Inherits="AdminHome" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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


  
    <br />

     <div class="demo-container no-bg">
        <telerik:RadScheduler runat="server" ID="RadScheduler1" AdvancedForm-Enabled="true"
             DataKeyField="D_rid" DataSubjectField="Place" EnableAdvancedForm="true"
            DataStartField="D_Time" DataEndField="D_Time2" DataSourceID="SqlDataSource1"
            OverflowBehavior="Auto" Height="" DataDescriptionField="Remarks" 
             DataReminderField="D_Date" EnableViewState="true" 
             SelectedView="MonthView" AllowDelete="false" AllowInsert="false" 
             EnableTheming="False">
            
        </telerik:RadScheduler>
       
         <br />
         <br />
       
         <asp:Label ID="lblErrors" runat="server" Text="" ForeColor="Red"></asp:Label>
       
         <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
             ConnectionString="<%$ ConnectionStrings:AssoConnString %>" 
            >
         </asp:SqlDataSource>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContFooter" Runat="Server">
</asp:Content>

