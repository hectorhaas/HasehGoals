<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HasehGoals.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .maxWidthText {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row clearfix">
            <div class="col-md-12 column" style="background-image: url('_img/swiss1.jpg'); background-attachment: fixed;">
                <h1 class="text-center">Hector and Eevee's Goals
                </h1>
            </div>
        </div>
        <div class="row clearfix">
            <div id="divMainTabs" class="col-md-12 column">
                <ul>
                    <li><a href="#tabAddNew">Add New</a></li>
                    <li><a href="#tabCurrentGoals">Current Goals</a></li>
                    <li><a href="#tabPastGoals">Past Goals</a></li>
                </ul>
                <!--Add New Panel-->
                <div id="tabAddNew" class="panel panel-default">
                    <div class="panel-heading" role="tab">
                        <h3 class="panel-title">Add New</h3>
                    </div>
                    <div class="panel-body">
                        <asp:TextBox ID="txtGoal" runat="server" TextMode="MultiLine" CssClass="maxWidthText"></asp:TextBox>
                        <br />
                        <table>
                            <tr>
                                <td>Select a Goal Owner</td>
                                <td>
                                    <asp:DropDownList ID="ddlOwner" runat="server" CssClass="text-success">
                                        <asp:ListItem Text="Evonne" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Hector" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="Both" Value="3"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>Select a Goal Date</td>
                                <td>
                                    <asp:TextBox ID="txtDate" runat="server" Enabled="true"></asp:TextBox>
                                </td>
                            </tr>
                        </table>


                        <br />


                        <br />
                        <asp:Label ID="errorLabel" runat="server" Text="" CssClass="text-danger"></asp:Label>
                        <br />
                        <asp:Button ID="btnSubmitGoal" runat="server" Text="Submit Goal" CssClass="btn btn-success" OnClick="btnSubmitGoal_Click" />
                    </div>
                </div>
                <!--Current Goals-->
                <div id="tabCurrentGoals" class="panel panel-default">
                    <div class="panel-heading" role="tab">
                        <h3 class="panel-title">Current Goals</h3>
                    </div>
                    <div class="panel-body">
                        <div id="divGoalsTable" runat="server"></div>
                    </div>
                </div>
                <!--Past Goals-->
                <div id="tabPastGoals" class="panel panel-default">
                    <div class="panel-heading" role="tab">
                        <h3 class="panel-title">Past Goals</h3>
                    </div>
                    <div class="panel-body">
                        <div id="divPastGoalsTable" runat="server"></div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        $(function () {
            $("#ContentPlaceHolder1_txtDate").datepicker({
                showOn: "button",
                buttonImage: "_img/calendar.gif",
                buttonImageOnly: true,
                buttonText: "Select date"
            });
        });
        $(function () {
            $("#divMainTabs").tabs();
        });
    </script>
</asp:Content>
