<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContBody" Runat="Server">


<div class="container">
<div class="row">
<div class="col-md-12">

</div>
 </div>

<div class="row">
<div class="col-md-3">
<h4> January </h4>
    <asp:GridView ID="G1" runat="server" CssClass="" 
        class="table table-striped table-bordered no-footer" 
         onrowdatabound="G1_RowDataBound">
    </asp:GridView>
</div>
<div class="col-md-3">
<h4> February </h4>
<asp:GridView ID="G2" runat="server" CssClass="" class="table table-striped table-bordered no-footer" onrowdatabound="G1_RowDataBound">
    </asp:GridView>
</div>
<div class="col-md-3">
<h4> March </h4>
<asp:GridView ID="G3" runat="server" CssClass="" class="table table-striped table-bordered no-footer" onrowdatabound="G1_RowDataBound">
    </asp:GridView>
</div>
<div class="col-md-3">
<h4> April </h4>
<asp:GridView ID="G4" runat="server" CssClass="" class="table table-striped table-bordered no-footer" onrowdatabound="G1_RowDataBound">
    </asp:GridView>
</div>
 </div>


<div class="row">
<div class="col-md-3">
<h4> May  </h4>
<asp:GridView ID="G5" runat="server" CssClass="" class="table table-striped table-bordered no-footer" onrowdatabound="G1_RowDataBound">
    </asp:GridView>
</div>
<div class="col-md-3">
<h4> June </h4>
<asp:GridView ID="G6" runat="server" CssClass="" class="table table-striped table-bordered no-footer" onrowdatabound="G1_RowDataBound">
    </asp:GridView>
</div>
<div class="col-md-3">
<h4> July </h4>
<asp:GridView ID="G7" runat="server" CssClass="" class="table table-striped table-bordered no-footer" onrowdatabound="G1_RowDataBound">
    </asp:GridView>
</div>
<div class="col-md-3">
<h4> August </h4>
<asp:GridView ID="G8" runat="server" CssClass="" class="table table-striped table-bordered no-footer" onrowdatabound="G1_RowDataBound">
    </asp:GridView>
</div>
 </div>
 <div class="row">
<div class="col-md-3">
<h4> Septemper </h4>
<asp:GridView ID="G9" runat="server" CssClass="" class="table table-striped table-bordered no-footer" onrowdatabound="G1_RowDataBound">
    </asp:GridView>
</div>
<div class="col-md-3">
<h4> October </h4>
<asp:GridView ID="G10" runat="server" CssClass="" class="table table-striped table-bordered no-footer" onrowdatabound="G1_RowDataBound">
    </asp:GridView>
</div>
<div class="col-md-3">
<h4> November </h4>
<asp:GridView ID="G11" runat="server" CssClass="" class="table table-striped table-bordered no-footer" onrowdatabound="G1_RowDataBound">
    </asp:GridView>
</div>
<div class="col-md-3">
<h4> December </h4>
<asp:GridView ID="G12" runat="server" CssClass="" class="table table-striped table-bordered no-footer" onrowdatabound="G1_RowDataBound">
    </asp:GridView>
</div>
 </div>

</div>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContFooter" Runat="Server">
</asp:Content>

