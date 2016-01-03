<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Goal.aspx.cs" Inherits="HasehGoals.Goal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .maxWidthText {
            width: 100%;
        }
    </style>
    <link href="_css/jquery.dataTables.min.css" rel="stylesheet" />
    <script src="_scripts/jquery.dataTables.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <asp:Button ID="btnGoBack" runat="server" Text="Go Back" CssClass="btn btn-info" OnClick="btnGoBack_Click" Visible="false" />
    <asp:Panel ID="panelMainContent" runat="server" Visible="true">
        <div class="container">
            <div class="row clearfix">
                <div class="col-md-12 column">
                    <!--GOal Info-->
                    <div class="panel panel-default">
                        <div class="panel-heading" role="tab">
                            <h2 class="panel-title">Goal</h2>
                        </div>
                        <div class="panel-body">
                            
                            <div id="divGoalInfo" runat="server"></div>
                            <br />
                            <asp:Button ID="btnEditGoal" runat="server" Text="Edit" CssClass="btn btn-sm btn-info" OnClick="btnEditGoal_Click"/>
                            <asp:Button ID="btnUpdateGoal" runat="server" Text="Button" CssClass="btn btn-sm btn-success"  Visible="false"/>
                            <asp:Button ID="btnCancelGoal" runat="server" Text="Button" CssClass="btn btn-sm btn-danger" Visible="false"/>
                        </div>
                    </div>
                    <!--Comments-->
                    <div class="panel panel-default">
                        <div class="panel-heading" role="tab">
                            <h3 class="panel-title">Comments</h3>
                        </div>
                        <div class="panel-body">
                            
                            <asp:TextBox ID="txtComment" runat="server" TextMode="MultiLine" CssClass="maxWidthText"></asp:TextBox>
                            <asp:Button ID="btnAddComment" runat="server" Text="Add Comment" CssClass="btn btn-success" OnClick="btnAddComment_Click" />
                            <br />
                            <br />
                            <div id="divComments" runat="server"></div>
                        </div>
                    </div>
                    <!--Pictures-->
                    <div class="panel panel-default">
                        <div class="panel-heading" role="tab">
                            <h3 class="panel-title">Pictures</h3>
                        </div>
                        <div class="panel-body">
                            
                            <asp:TextBox ID="txtPictureComment" runat="server" TextMode="MultiLine" CssClass="maxWidthText"></asp:TextBox>
                            <asp:FileUpload ID="FileUploadPictures" runat="server" />
                            <asp:Button ID="btnPictureUpload" runat="server" Text="Add Picture" CssClass="btn btn-success" OnClick="btnPictureUpload_Click" />
                            <br />
                            <br />
                            <div id="divPictures" runat="server"></div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
    <!--HiddenFields-->
    </asp:Content>
