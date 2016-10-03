<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="AddMembers.aspx.cs" Inherits="AddMembers" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContBody" Runat="Server">
    <h2>Blank Page</h2>   
                        <h5>Welcome. </h5>

 <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" Updatemode="Conditional">
             <Triggers>
                   <asp:AsyncPostBackTrigger ControlID = "GVSearch" eventname="SelectedIndexChanged" />
                   <asp:AsyncPostBackTrigger ControlID = "btnAdd" eventname="Click" />
                   <asp:AsyncPostBackTrigger ControlID = "btnClear" eventname="Click" />
                   
                      <asp:PostBackTrigger ControlID="btnUpload"  />
                 <%--  <asp:AsyncPostBackTrigger ControlID = "txtSearch" eventname="TextChanged" />--%>
                   
             </Triggers>
            <ContentTemplate>

<div class="row">
<div class="col-md-6 form-group">
<div class="panel panel-default">
<div class="panel-heading">Add Members</div>
<div class="panel-body">
<div class="row"><div class="col-md-6">
 <asp:Image ID="Image1" runat="server" CssClass="img-rounded img-responsive" Width="100" Height="100"/>
</div><div class="col-md-6">
 <asp:FileUpload ID="FileUpload1" runat="server" /><br />
         
<asp:Button ID="btnUpload" runat="server" Text="Upload" CssClass="btn btn-warning"
    onclick="btnUpload_Click" />
        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
</div></div>
    <asp:Label ID="lblUserRID" runat="server" Text="" Visible="false"></asp:Label>
    <asp:Label ID="lblRID" runat="server" Text="" Visible=false></asp:Label>
    <asp:Label ID="Label1" runat="server" Text="Name "></asp:Label>
    <asp:TextBox ID="txtName" runat="server" CssClass="form-control" required="required"></asp:TextBox> 
       <asp:Label ID="Label3" runat="server" Text="Email id "></asp:Label>
    <asp:TextBox ID="txtEmailid" runat="server" CssClass="form-control" required="required" type="Email" ></asp:TextBox> 

     <asp:Label ID="Label4" runat="server" Text="Mobile Number "></asp:Label>
    <asp:TextBox ID="txtMobile" runat="server" CssClass="form-control"></asp:TextBox> 
     <asp:Label ID="Label5" runat="server" Text="Group "></asp:Label>
    <asp:DropDownList ID="ddlUserGroup" runat="server" CssClass="form-control">
    </asp:DropDownList>
       <asp:Label ID="Label2" runat="server" Text="Gender "></asp:Label>
       <div class="row"><div class="col-md-3">   <asp:RadioButton ID="RadioButton1" runat="server" Text="Male" GroupName="gender" CssClass="radio" Checked="true"/></div>
       <div class="col-md-6"><asp:RadioButton ID="RadioButton2" Text="Fe-male" GroupName="gender" CssClass="radio" runat="server" /></div></div>

     <asp:Label ID="Label7" runat="server" Text="Date of Birth "></asp:Label>
    <asp:TextBox ID="txtDOB" runat="server" CssClass="form-control" type="Date"></asp:TextBox> 
     <asp:Label ID="Label6" runat="server" Text="Address"></asp:Label>
    <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" 
        TextMode="MultiLine"></asp:TextBox> 
    <asp:CheckBox ID="ChkIsActive" runat="server" Checked="true" CssClass="checkbox" Text="Is Active " />
    <br />
    <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-success" 
        onclick="btnAdd_Click" Text="Save" />
    <asp:Button ID="btnClear" runat="server" CssClass="btn btn-danger" 
        onclick="btnClear_Click" Text="Clear" />
    <asp:Label ID="LBLINSERMSG" runat="server" CssClass="text-danger" Text=""></asp:Label>
    


    </div>
</div>
</div>

<div class="col-md-6">
<%--<div class="form-group input-group"><span class="input-group-btn"><button class="btn btn-default" type="button"><i class="fa fa-search"></i> </button> </span>
<asp:TextBox ID="txtSearch" runat="server" class="form-control" 
        placeholder="Search" ontextchanged="txtSearch_TextChanged" 
        Visible="False" ></asp:TextBox>
</div>--%>
<div style="max-height:600px;overflow:scroll">
    <asp:GridView ID="GVSearch" runat="server" 
        class="table table-striped table-bordered table-hover dataTable no-footer" 
        onrowdatabound="GVSearch_RowDataBound" 
        onselectedindexchanged="GVSearch_SelectedIndexChanged">
    </asp:GridView>

    </div>
</div>

</div>

 </ContentTemplate></asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContFooter" Runat="Server">
</asp:Content>

