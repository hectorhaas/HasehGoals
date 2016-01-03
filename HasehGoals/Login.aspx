<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HasehGoals.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link href="_css/bootstrap.css" rel="stylesheet" />
    <link href="_css/bootstrap-theme.css" rel="stylesheet" />
    <link href="_css/jquery-ui.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <h1>Login</h1>
            </div>
        </div>
        <div class="row">&nbsp;</div>
        <div class="row">
            <div class="col-md-1">
                <asp:Label ID="Label1" runat="server" Text="Username" CssClass="label label-default"></asp:Label>
            </div>
            <div class="col-md-11">
                <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row">&nbsp;</div>
        <div class="row">
            <div class="col-md-1">
                <asp:Label ID="Label2" runat="server" Text="Password" CssClass="label label-default"></asp:Label>
            </div>
            <div class="col-md-11">
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
            </div>
        </div>
        <div class="row">&nbsp;</div>
        <div class="row">
            <div class="col-md-1">

            </div>
            <div class="col-md-11">
                <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-primary" OnClick="btnLogin_Click" />
                <br />
                <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red"></asp:Label>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
