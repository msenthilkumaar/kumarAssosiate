<%@ Page Title="" Language="C#" MasterPageFile="~/SubAdmin.master" AutoEventWireup="true" CodeFile="AdAttent.aspx.cs" Inherits="AdAttent" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script type="text/javascript" language="javascript">
    function CheckAllEmp(Checkbox) {
        var GridVwHeaderChckbox = document.getElementById("<%=GVMembers.ClientID %>");
        for (i = 1; i < GridVwHeaderChckbox.rows.length; i++) {
            GridVwHeaderChckbox.rows[i].cells[3].getElementsByTagName("INPUT")[0].checked = Checkbox.checked;
        }
    }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContBody" Runat="Server">
 
    <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server">
    </telerik:RadStyleSheetManager>
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
<div class="col-md-6 well-lg">
 <asp:Label ID="Label2" runat="server" Text="Select Group "></asp:Label>
    <asp:DropDownList ID="ddlGroup" runat="server" CssClass="form-control"  AutoPostBack="true"
        onselectedindexchanged="ddlGroup_SelectedIndexChanged">
    </asp:DropDownList>
</div>
<div class="col-md-6 well-lg">
    <asp:Label ID="Label1" runat="server" Text="Select Event "></asp:Label> 
    <telerik:RadDropDownList ID="ddlEvent" runat="server" AutoPostBack="True" 
        DefaultMessage="Select Event ..." 
        onselectedindexchanged="ddlEvent_SelectedIndexChanged1">
    </telerik:RadDropDownList>
    <br /> <br />
     <asp:Button ID="btnPresent" runat="server" Text="Present" 
        CssClass="btn btn-success" onclick="btnPresent_Click" />
    <asp:Button ID="btnAbsent" runat="server" Text="Absent" 
        CssClass="btn btn-danger" onclick="btnAbsent_Click" />
</div></div>
<div class="row">
<div class="col-md-12">
<div style="max-height:400px;overflow:scroll">
<asp:GridView ID="GVMembers" runat="server" 
        class="table table-striped table-bordered table-hover dataTable no-footer" AutoGenerateColumns="false" >


        <Columns>
        <asp:BoundField DataField="rid" HeaderText="ID"  />
        <asp:BoundField DataField="Name" HeaderText="Name"  />
        <asp:BoundField DataField="MobileNumber" HeaderText="Mobile"  />

        <asp:TemplateField>
         <HeaderTemplate>
                            <asp:CheckBox ID="chkboxSelectAll" runat="server" onclick="CheckAllEmp(this);" />
         </HeaderTemplate>
            <ItemTemplate>
                <asp:CheckBox ID="chkRow" runat="server" />
            </ItemTemplate>
        </asp:TemplateField>
        
       
    </Columns>

    </asp:GridView>
   

        </div>
</div>
<div class="col-md-12">
<div class="col-md-6">
<div style="max-height:300px;overflow:scroll">

<h3>Present </h3>
<asp:GridView ID="GVPresent" runat="server" 
        class="table table-striped table-bordered no-footer" >
    </asp:GridView>
</div>
</div>
<div class="col-md-6">
<div style="max-height:300px;overflow:scroll">

<h3>Absent </h3>
<asp:GridView ID="GVApsent" runat="server" 
        class="table table-striped table-bordered no-footer" >
    </asp:GridView>
</div>
</div>

</div>
</div>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContFooter" Runat="Server">
</asp:Content>

