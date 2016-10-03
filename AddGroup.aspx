<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="AddGroup.aspx.cs" Inherits="AddGroup" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContBody" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" Updatemode="Conditional">
             <Triggers>
                   <asp:AsyncPostBackTrigger ControlID = "GVGroupname" eventname="SelectedIndexChanged" />
                   <asp:AsyncPostBackTrigger ControlID = "btnSave" eventname="Click" />
                  
                 <%--  <asp:AsyncPostBackTrigger ControlID = "txtSearch" eventname="TextChanged" />--%>
                   
             </Triggers>
            <ContentTemplate>

<div class="row">
<div class="col-md-6">
    Group Name
    <asp:Label ID="lblRID" runat="server" Visible="false"></asp:Label>
    &nbsp;<asp:TextBox ID="txtUserName" runat="server" CssClass="form-control" required="required"></asp:TextBox>
    <br />
    Admin Name
    <asp:DropDownList ID="ddlAdmin" CssClass="form-control" runat="server">
    </asp:DropDownList><br />
    <asp:CheckBox ID="CheckBox1" runat="server" Text="Is Active" /><br /><br />
    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-success" 
        onclick="btnSave_Click"/>
    <asp:Button ID="Button1" runat="server" Text="Clear" CssClass="btn btn-danger" 
        onclick="Button1_Click" />
</div>
<div class="col-md-6">
    <asp:GridView ID="GVGroupname" runat="server" CssClass="table"
        onrowdatabound="GVGroupname_RowDataBound" 
        onselectedindexchanged="GVGroupname_SelectedIndexChanged" >
    </asp:GridView>

</div>
</div>
<br />
                <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
</ContentTemplate>
</asp:UpdatePanel>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContFooter" Runat="Server">
</asp:Content>

