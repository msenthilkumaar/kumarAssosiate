<%@ Page Title="" Language="C#" MasterPageFile="~/SubAdmin.master" AutoEventWireup="true" CodeFile="AdViewMessage.aspx.cs" Inherits="AdViewMessage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContBody" Runat="Server">
<div class="row">
<div class="col-md-12">
    <asp:GridView ID="GVMessages" runat="server" CssClass="table table-responsive table-bordered">
    </asp:GridView>
</div>
</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContFooter" Runat="Server">
</asp:Content>

