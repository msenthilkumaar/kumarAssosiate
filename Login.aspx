<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
      <title>AS Dubai Welcomes you...</title>
      <meta http-equiv="X-UA-Compatible" content="IE=edge;" />
     <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="assets/css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/custom.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/font-awesome.css" rel="stylesheet" type="text/css" />
</head>
<body style="background-color:#f5f1e6;background-image:url(assets/img/img2.jpg);box-sizing:content-box;background-size:100% auto ;background-repeat: no-repeat;">
    <form id="form1" runat="server" >
    <div class="container">
    <br /><br /><br /><br />
    <div class="row">
    <div class="col-md-3 ">
    User Name
        <asp:TextBox ID="txtUser" runat="server" CssClass="form-control"></asp:TextBox><br />
        Password
        <asp:TextBox ID="txtpass"
            runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>  <br />
            
            <asp:Button ID="btnSumit" CssClass="btn btn-success" runat="server" 
            Text="Submit" onclick="btnSumit_Click" />
        <br />
        <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
    </div>
    </div>
    </div>
    </form>
     <script src="assets/js/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="assets/js/bootstrap.min.js" type="text/javascript"></script>
    <script src="assets/js/custom.js" type="text/javascript"></script>
  
    <script src="assets/js/jquery.metisMenu.js" type="text/javascript"></script>
</body>
</html>
