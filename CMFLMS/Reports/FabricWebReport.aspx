<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FabricWebReport.aspx.cs" Inherits="CMFLMS.Reports.FabricWebReport" %>

<!DOCTYPE html>
<link href="../Content/bootstrap.css" rel="stylesheet" />
<script src="../Scripts/jquery-1.10.2.min.js"></script>
<script src="../Scripts/bootstrap.min.js"></script>
<script src="../Scripts/jquery.tablesorter.min.js"></script>
<link href="../Content/bootstrap-cerulean.css" rel="stylesheet" />
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="form-horizontal" role="form" style="padding-top: 25px;">
            <div class="panel panel-default">
                <div class="panel-body">
                    <div class="row">
                        <%--Column 1--%>
                        <div class="col-md-2">
                            <div class="form-group">
                                <div class="col-md-4">
                                       <asp:TextBox ID="txtFabId" runat="server" CssClass="form-control" Width="175px" AutoPostBack="True" Placeholder="Fabric ID" OnTextChanged="txtFabId_TextChanged"/>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-1">
                                    <asp:TextBox ID="txtWidthInch" runat="server" CssClass="form-control" Width="175px" AutoPostBack="True" Placeholder="Width (Inches)" OnTextChanged="txtWidthInch_TextChanged"/>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-1">
                                    <asp:TextBox ID="txtFactory" runat="server" CssClass="form-control" Width="175px" AutoPostBack="True" Placeholder="Factory" />
                                </div>
                            </div>
                        </div>
                        <%--Column 2--%>
                        <div class="col-md-2">
                            <div class="form-group">
                                <div class="col-md-1">
                                    <asp:TextBox ID="txtSupplier" runat="server" CssClass="form-control" Width="175px" AutoPostBack="True" Placeholder="Supplier"/>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-1">
                                    <asp:TextBox ID="txtWidthCm" runat="server" CssClass="form-control" Width="175px" AutoPostBack="True" Placeholder="Width (Centimeters)"/>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-1">
                                    <asp:TextBox ID="txtFabricCategory" runat="server" CssClass="form-control" Width="175px" AutoPostBack="True" Placeholder="Fabric Category" />
                                </div>
                            </div>
                        </div>
                        <%--Column 3--%>
                        <div class="col-md-2">
                            <div class="form-group">
                                    <div class="col-md-1">
                                        <asp:TextBox ID="txtQuality" runat="server" CssClass="form-control" Width="175px" AutoPostBack="True" Placeholder="Quality"/>
                                    </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-1">
                                    <asp:TextBox ID="txtLocation" runat="server" CssClass="form-control" Width="175px" AutoPostBack="True" Placeholder="Location"/>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-1">
                                    <asp:TextBox ID="txtFinishingCategory" runat="server" CssClass="form-control" Width="175px" AutoPostBack="True" Placeholder="Finishing Category" />
                                </div>
                            </div>
                        </div>
                        <%--Column 4--%>
                        <div class="col-md-2">
                            <div class="form-group">
                                <div class="col-md-1">
                                    <asp:TextBox ID="txtComposition" runat="server" CssClass="form-control" Width="175px" AutoPostBack="True" Placeholder="Composition"/>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-1">
                                    <asp:TextBox ID="txtKnitType" runat="server" CssClass="form-control" Width="175px" AutoPostBack="True" Placeholder="Knit Type"/>
                                </div>
                            </div>
                             <div class="form-group">
                                 <div class="col-md-1">
                                     <asp:TextBox ID="txtRemarks" runat="server" CssClass="form-control" Width="175px" AutoPostBack="True" Placeholder="Remarks" />
                                 </div>
                             </div>
                        </div>
                        <%--Column 5--%>
                        <div class="col-md-2">
                            <div class="form-group">
                                <div class="col-md-1">
                                    <asp:TextBox ID="txtConstruction" runat="server" CssClass="form-control" Width="175px" AutoPostBack="True" Placeholder="Construction"/>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-1">
                                    <asp:TextBox ID="txtStructure" runat="server" CssClass="form-control" Width="175px" AutoPostBack="True" Placeholder="Structure"/>
                                </div>
                            </div>
                        </div>
                        <%--Column 6--%>
                        <div class="col-md-2">
                            <div class="form-group">
                                <div class="col-md-1">
                                    <asp:TextBox ID="txtYranCount" runat="server" CssClass="form-control" Width="175px" AutoPostBack="True" Placeholder="Yarn Count"/>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-1">
                                    <asp:TextBox ID="txtColour" runat="server" CssClass="form-control" Width="175px" AutoPostBack="True" Placeholder="Colour"/>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-1">
                                    <asp:Button ID="btnToExcel" runat="server" Text="Export To Excel" Width="175px" height="40px" Style="background-color: #044d94; color:white; border-radius:0 10px; font-weight:bold"/>
                                </div>
                            </div>
                             </div>
                        </div>
                    </div>
                </div>
            </div>
        <div class="panel panel-default">
            <div class="panel-body">
                <div class="row">
                    <div class="form-group">
                        <asp:GridView CssClass="NewClass" ID="gvInfo"  HeaderStyle-BackColor="midnightblue" HeaderStyle-Font-Names="Georgia" HeaderStyle-ForeColor="White" runat="server" GridLines="Vertical" CellPadding="3" BorderWidth="1px">
                            <Columns>
                                <asp:BoundField DataField="FabricId" HeaderText="FabricId" SortExpression="FabricId" />
                            </Columns>
                            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#0000A9" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#000065" />    
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>

    </form>
</body>
</html>
<style type="text/css">
    table.NewClass {
            width: 100%;
        }
    </style>
<script type="text/javascript">
    $(function changeID() { });
    $("[id*=txtFabId]").live("change", function () {
        if (isNaN(parseInt($(this).val()))) {
            $(this).val('0');
        } else {
            $(this).val(parseInt($(this).val()).toString());
        }
    });
    $("[id*=txtFabId]").live("keyup", function () {
        if (!jQuery.trim($(this).val()) == '') {
            if (!isNaN(parseFloat($(this).val()))) {
                var row = $(this).closest("tr");
                $("[id*=lblTotal]", row).html(parseFloat($("[id*=lblPrice]", row).html()) * parseFloat($(this).val()));
            }
        } else {
            $(this).val('');
        }
    });
    </script>