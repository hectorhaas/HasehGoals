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
    <asp:Button ID="btnGoBack" runat="server" Text="Go Back" CssClass="btn btn-info" OnClick="btnGoBack_Click" />
    <asp:Panel ID="panelLogin" runat="server" Visible="true">
        <div class="container" runat="server" id="divLoginContainer">
            <div class="row clearfix">
                <div class="col-md-12 column">
                    <div class="panel panel-default">
                        <div class="panel-heading" role="tab">
                            <h2 class="panel-title">Select a User</h2>
                        </div>
                        <div class="panel-body">
                            <div style="clear:both;"></div>
                            <div style="width:70%; margin:auto;">
                                <div style="width:25%;float:left;">
                                    <img src="_img/chi.jpg" style="width:100%" />
                                    <asp:Button ID="txtEvonne" CssClass="btn btn-primary" runat="server" Text="Eevee" OnClick="txtEvonne_Click" />
                                </div>
                                <div style="width:25%;float:right;">
                                    <img src="_img/retard.jpg" style="width:100%"/>
                                    <asp:Button ID="txtHector" CssClass="btn btn-primary" runat="server" Text="Hector" OnClick="txtHector_Click" />
                                </div>
                            </div>
                            <div style="clear:both;"></div>
                        </div>
                    </div>
                </div>

            </div>

        </div>
    </asp:Panel>
    <asp:Panel ID="panelMainContent" runat="server" Visible="false">
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
    <asp:HiddenField ID="ownerID" runat="server" />
</asp:Content>
