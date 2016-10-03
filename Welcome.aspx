<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.master" AutoEventWireup="true" CodeFile="Welcome.aspx.cs" Inherits="Welcome" EnableEventValidation="false" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style>
.panelGrid
{
    margin-left:10px;
    min-height:50px;
}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContBody" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
<telerik:RadWindowManager RenderMode="Lightweight" ID="RadWindowManager1" runat="server" EnableShadow="true">
        </telerik:RadWindowManager>

<div class="container">

<div class="row">
<div class="col-md-3 alert-success panelGrid">
<h4> January </h4>
    <asp:GridView ID="G1" runat="server" CssClass="" 
        class="table table-striped table-bordered no-footer" 
         onrowdatabound="G1_RowDataBound" 
        onselectedindexchanged="G1_SelectedIndexChanged" 
        EmptyDataText="No Event For this Month">
    </asp:GridView>
</div>
<div class="col-md-2 alert-danger panelGrid">
<h4> February </h4>
<asp:GridView ID="G2" runat="server" CssClass="" 
        class="table table-striped table-bordered no-footer" 
        EmptyDataText="No Event For this Month" 
        onselectedindexchanged="G2_SelectedIndexChanged" 
        onrowdatabound="G2_RowDataBound1" >
    </asp:GridView>
</div>
<div class="col-md-2 alert-success panelGrid">
<h4> March </h4>
<asp:GridView ID="G3" runat="server" CssClass="" 
        class="table table-striped table-bordered no-footer" 
        EmptyDataText="No Event For this Month" onrowdatabound="G3_RowDataBound" 
        onselectedindexchanged="G3_SelectedIndexChanged">
    </asp:GridView>
</div>
<div class="col-md-3  alert-danger panelGrid">
<h4> April </h4>
<asp:GridView ID="G4" runat="server" CssClass="" 
        class="table table-striped table-bordered no-footer" 
        EmptyDataText="No Event For this Month" onrowdatabound="G4_RowDataBound" 
        onselectedindexchanged="G4_SelectedIndexChanged" >
    </asp:GridView>
</div>
 </div>

 <br />
<div class="row">
<div class="col-md-2 alert-danger panelGrid">
<h4> May  </h4>
<asp:GridView ID="G5" runat="server" CssClass="" 
        class="table table-striped table-bordered no-footer" 
        EmptyDataText="No Event For this Month" onrowdatabound="G5_RowDataBound" 
        onselectedindexchanged="G5_SelectedIndexChanged" >
    </asp:GridView>
</div>
<div class="col-md-3 alert-success panelGrid">
<h4> June </h4>
<asp:GridView ID="G6" runat="server" CssClass="" 
        class="table table-striped table-bordered no-footer" 
        EmptyDataText="No Event For this Month" onrowdatabound="G6_RowDataBound" 
        onselectedindexchanged="G6_SelectedIndexChanged" >
    </asp:GridView>
</div>
<div class="col-md-3 alert alert-danger panelGrid">
<h4> July </h4>
<asp:GridView ID="G7" runat="server" CssClass="" 
        class="table table-striped table-bordered no-footer" 
        EmptyDataText="No Event For this Month" onrowdatabound="G7_RowDataBound" 
        onselectedindexchanged="G7_SelectedIndexChanged" >
    </asp:GridView>
</div>
<div class="col-md-2 alert-success panelGrid">
<h4> August </h4>
<asp:GridView ID="G8" runat="server" CssClass="" 
        class="table table-striped table-bordered no-footer" 
        EmptyDataText="No Event For this Month" onrowdatabound="G8_RowDataBound" 
        onselectedindexchanged="G8_SelectedIndexChanged" >
    </asp:GridView>
</div>
 </div>
 <br />
 <div class="row">
<div class="col-md-3 alert-success panelGrid">
<h4> Septemper </h4>
<asp:GridView ID="G9" runat="server" CssClass="" 
        class="table table-striped table-bordered no-footer" 
        EmptyDataText="No Event For this Month" onrowdatabound="G9_RowDataBound" 
        onselectedindexchanged="G9_SelectedIndexChanged" >
    </asp:GridView>
</div>
<div class="col-md-2 alert-danger panelGrid">
<h4> October </h4>
<asp:GridView ID="G10" runat="server" CssClass="" 
        class="table table-striped table-bordered no-footer" 
        EmptyDataText="No Event For this Month" onrowdatabound="G10_RowDataBound" 
        onselectedindexchanged="G10_SelectedIndexChanged">
    </asp:GridView>
</div>
<div class="col-md-2 alert-success panelGrid">
<h4> November </h4>
<asp:GridView ID="G11" runat="server" CssClass="" 
        class="table table-striped table-bordered no-footer" 
        EmptyDataText="No Event For this Month" onrowdatabound="G11_RowDataBound" 
        onselectedindexchanged="G11_SelectedIndexChanged">
    </asp:GridView>
</div>
<div class="col-md-3 alert-danger panelGrid">
<h4> December </h4>
<asp:GridView ID="G12" runat="server" CssClass="" 
        class="table table-striped table-bordered no-footer" 
        EmptyDataText="No Event For this Month" onrowdatabound="G12_RowDataBound" 
        onselectedindexchanged="G12_SelectedIndexChanged">
    </asp:GridView>
</div>
 </div>

</div>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContFooter" Runat="Server">


</asp:Content>

