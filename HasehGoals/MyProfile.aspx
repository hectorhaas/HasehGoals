<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MyProfile.aspx.cs" Inherits="HasehGoals.MyProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <h1>My Profile</h1>
            </div>
        </div>
        <div class="row">
            <div class="col-md-1">
                <asp:Label ID="lblUsername" runat="server" Text="Username" CssClass="label label-default"></asp:Label>
            </div>
            <div class="col-md-11">
                <asp:TextBox ID="txtUserName" runat="server" Enabled="true" CssClass="input-lg"></asp:TextBox>
            </div>
        </div>
        <div class="row">&nbsp;</div>
        <div class="row">
            <div class="col-md-1">
                <asp:Label ID="lblPassword" runat="server" Text="Password" CssClass="label label-default"></asp:Label>
            </div>
            <div class="col-md-11">
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="input-lg"></asp:TextBox>
            </div>
        </div>
        <div class="row">&nbsp;</div>
        <div class="row">
            <div class="col-md-1">
                <asp:Label ID="lblEmail" runat="server" Text="Email" CssClass="label label-default"></asp:Label>
            </div>
            <div class="col-md-11">
                <asp:TextBox ID="txtEmail" runat="server" CssClass="input-lg"></asp:TextBox>
            </div>
        </div>
        <div class="row">&nbsp;</div>
        <div class="row">
            <div class="col-md-1">
                <asp:Label ID="lblCheckBox" runat="server" Text="Receive Emails" CssClass="label label-default"></asp:Label>
            </div>
            <div class="col-md-11">
                <asp:CheckBox ID="chkReceiveEmails" runat="server"/>
            </div>
        </div>
        <div class="row">&nbsp;</div>
        <div class="row">
            <div class="col-md-2">
                <asp:Label ID="Label1" runat="server" Text="Profile Picture" CssClass="label label-default"></asp:Label>
            </div>
            <div class="col-md-3">
                <asp:FileUpload ID="FileUploadPictures" runat="server" />
            </div>
            <div class="col-md-1">
                <div style="width:100%;" id="divProfilePic" runat="server"></div>
            </div>
            <div class="col-md-6">&nbsp;</div>
        </div>
        <div class="row">&nbsp;</div>
        <div class="row">
            <div class="col-md-1">
            </div>
            <div class="col-md-11">
                <asp:Label ID="lblMessage" runat="server" Text="" CssClass="label label-success"></asp:Label>
                <br />
                <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-primary" OnClick="btnUpdate_Click" />
            </div>
        </div>
        <div class="row">&nbsp;</div>
    </div>
</asp:Content>
