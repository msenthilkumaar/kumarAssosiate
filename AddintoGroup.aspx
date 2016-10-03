<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="AddintoGroup.aspx.cs" Inherits="AddintoGroup" %>

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
<%--<div class="col-md-6">
<h4>Select the User</h4>
    <asp:DropDownList ID="ddlUserGroup" runat="server" CssClass="dropdown">
    </asp:DropDownList>
</div>--%>
<div class="col-md-6">
<h4>Select Group</h4>
    <asp:DropDownList ID="ddlGroup" runat="server" 
        AutoPostBack="True" onselectedindexchanged="ddlGroup_SelectedIndexChanged" CssClass="form-control">
    </asp:DropDownList>
    <br />
</div>
</div>
<div class="row">
<div class="col-md-5">
<h4>To be add</h4>
    <telerik:RadGrid ID="radTOBE" runat="server" CellSpacing="0" GridLines="None" AutoGenerateColumns="false">
    <GroupingSettings CaseSensitive="false" />
     <MasterTableView>
                        <Columns>
                          <telerik:GridBoundColumn DataField="rid" HeaderText="ID."
                                SortExpression="rid" UniqueName="rid" Display="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Name" HeaderText="Name."
                                SortExpression="name" UniqueName="name" Visible="true">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="MobileNumber" HeaderText="Mobile Number" SortExpression="MobileNumber"
                                UniqueName="MobileNumber" Visible="true">
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn>
                                <ItemTemplate>
                                    <asp:CheckBox ID="ChkAdd" runat="server" />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>
                    </MasterTableView>

    </telerik:RadGrid>
</div>
<div class="col-md-2">
<br /><br /><br /><br />
  <asp:Button ID="btnAdd" runat="server" Text="Assign ->" class="btn btn-success" Width="100px"
                    OnClick="btnAdd_Click" />
                <br />
                <br />
                <asp:Button ID="btnRemove" runat="server" Text="<- Remove" class="btn btn-danger"
                    Width="100px" OnClick="btnRemove_Click" />


</div>
<div class="col-md-5">
<h4> Added List </h4>
<telerik:RadGrid ID="radAdded" runat="server" AutoGenerateColumns="false">
<GroupingSettings CaseSensitive="false" />
     <MasterTableView>
                        <Columns>
                          <telerik:GridBoundColumn DataField="rid" HeaderText="ID."
                                SortExpression="rid" UniqueName="rid" Display="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Name" HeaderText="Name."
                                SortExpression="name" UniqueName="name" Visible="true">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="MobileNumber" HeaderText="Mobile Number" SortExpression="MobileNumber"
                                UniqueName="MobileNumber" Visible="true">
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn>
                                <ItemTemplate>
                                    <asp:CheckBox ID="ChkRemove" runat="server" />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>
    </MasterTableView>
    </telerik:RadGrid>
</div>
</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContFooter" Runat="Server">
</asp:Content>

