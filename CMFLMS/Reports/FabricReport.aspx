<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FabricReport.aspx.cs" Inherits="CMFLMS.Reports.FabricReport" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>
<link href="../Content/bootstrap.css" rel="stylesheet" />
<script src="../Scripts/jquery-1.10.2.js"></script>
<script src="../Scripts/jquery-1.10.2.min.js"></script>

<link href="../Content/bootstrap-cerulean.css" rel="stylesheet" />
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    </head>
<body>
    <form id="form1" runat="server">
        <div class="form-horizontal">
            <div class="panel panel-default">
                <div class="panel-body">
                    <br>
                    <div class="row">
                        <div class="col-md-4">
                            <div class="form-group">
                                <div class="col-md-2">
                                    <label id="Label5" runat="server">Factory</label>
                                </div>
                                <div class="col-md-1">
                                    <asp:DropDownList ID="ddlFactory" runat="server" CssClass="form-control" Width="200px" AppendDataBoundItems="true" OnSelectedIndexChanged="ddlFactory_SelectedIndexChanged" AutoPostBack="True">
                                        <Items>
                                            <asp:ListItem Text="Select Factory" Value="" />
                                        </Items>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-2">
                                </div>
                                <div class="col-md-12">
                                    <label id="lblMessage" runat="server" style="color: red"><b></b></label>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <asp:Button ID="btnDetails" runat="server" Text="Generate Report" CssClass="btn btn-default" Style="background-color:gainsboro; color:black; border-radius:0 10px; font-weight:bold" Width="150px" OnClick="btnDetails_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
        <div class="container-fluid">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <div class="row" style="padding-top: 20px; padding-bottom: 10px;">
                <rsweb:ReportViewer ID="rvFabrics" runat="server" AsyncRendering="False" SizeToReportContent="True"></rsweb:ReportViewer>
            </div>
        </div>
    </form>
</body>
</html>
