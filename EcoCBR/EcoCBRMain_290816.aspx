<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="EcoCBRMain.aspx.cs" Inherits="EcoBR.EcoCBRMain" MaintainScrollPositionOnPostback="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            color: #CC3300;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:TextBox ID="txtTest" runat="server" Visible="false"></asp:TextBox>
        <asp:Label ID="lblTitle" runat="server" Text="ECO-CBR" Font-Size="Larger"></asp:Label>        
        <table width="80%">
            <tr>
                <td>
                    <div>
                        <table width="50%">
                            <tr>
                                <td colspan="3" class="auto-style1">Material and Manufacturing Process</td>
                            </tr>
                            <tr>
                                <td colspan="2">&nbsp;</td>
                                <td>Weight</td>
                            </tr>
                            <tr>
                                <td align="left" valign="top">Type</td>
                                <td align="left" valign="top">
                                    <asp:DropDownList ID="ddlMMType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMMType_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td colspan="1">
                                    <asp:TextBox ID="txtMMTypeWeight" runat="server" Width="28px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td align="left" valign="top">Process</td>
                                <td align="left" valign="top">
                                    <asp:DropDownList ID="ddlMMProcess" runat="server">
                                    </asp:DropDownList>
                                </td>
                                <td colspan="1">
                                    <asp:TextBox ID="txtMMProcessWeight" runat="server" Width="28px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td align="left" valign="top">Product Weight</td>
                                <td align="left" valign="top">
                                    <asp:TextBox ID="txtMMProduct" runat="server"></asp:TextBox></td>
                                <td align="left" valign="top">
                                    <asp:TextBox ID="txtMMProductWeight" runat="server" Width="28px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td align="left" valign="top">&nbsp;</td>
                                <td align="left" valign="top">&nbsp;</td>
                                <td align="left" valign="top">
                                    <asp:Button ID="btnMMSearch" runat="server" Text="Search" OnClick="btnMMSearch_Click" />
                                </td>
                            </tr>
                        </table>
                        <asp:GridView ID="grvMaterialManifacturing" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:TemplateField HeaderText="Case No">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCaseNo" runat="server" Text='<%#Eval("Case No") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Material Type">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMaterialType" runat="server" Text='<%#Eval("Material Type") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Process">
                                    <ItemTemplate>
                                        <asp:Label ID="lblProcess" runat="server" Text='<%#Eval("Process") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Product Weight(gram)">
                                    <ItemTemplate>
                                        <asp:Label ID="lblProductWeight" runat="server" Text='<%# DataBinder.GetPropertyValue(Container.DataItem, "Product Weight(gram)") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Product Numerical Local Similarity">
                                    <ItemTemplate>
                                        <asp:Label ID="lblproductNumericalLS" runat="server" Text='<%#Eval("productNumericalLS", "{0:0.0000000000}") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Global Similarity">
                                    <ItemTemplate>
                                        <asp:Label ID="lblGlobalS" runat="server" Text='<%#Eval("GlobalS", "{0:0.0000000000}") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EditRowStyle BackColor="#999999" />
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                        </asp:GridView>
                    </div>
                    <div>
                        <table width="50%">
                            <tr>
                                <td colspan="3" class="auto-style1">Transportion</td>
                            </tr>
                            <tr>
                                <td colspan="2">&nbsp;</td>
                                <td>Weight</td>
                            </tr>
                            <tr>
                                <td align="left" valign="top">Origin</td>
                                <td align="left" valign="top">
                                    <asp:DropDownList ID="ddlTOrigin" runat="server">
                                    </asp:DropDownList>
                                </td>
                                <td colspan="1">
                                    <asp:TextBox ID="txtTOriginWeight" runat="server" Width="28px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td align="left" valign="top">Destination</td>
                                <td align="left" valign="top">
                                    <asp:DropDownList ID="ddlTDestination" runat="server">
                                    </asp:DropDownList>
                                </td>
                                <td colspan="1">
                                    <asp:TextBox ID="txtTDestinationWeight" runat="server" Width="28px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td align="left" valign="top">Type</td>
                                <td align="left" valign="top">
                                    <asp:DropDownList ID="ddlTType" runat="server">
                                    </asp:DropDownList>
                                </td>
                                <td align="left" valign="top">
                                    <asp:TextBox ID="txtTTypeWeight" runat="server" Width="28px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td align="left" valign="top">Distance</td>
                                <td align="left" valign="top">
                                    <asp:TextBox ID="txtTDistance" runat="server"></asp:TextBox></td>
                                <td align="left" valign="top">
                                    <asp:TextBox ID="txtTDistanceWeight" runat="server" Width="28px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td align="left" valign="top">&nbsp;</td>
                                <td align="left" valign="top">&nbsp;</td>
                                <td align="left" valign="top">
                                    <asp:Button ID="txtTSearch" runat="server" Text="Search" OnClick="txtTSearch_Click" />
                                </td>
                            </tr>
                        </table>
                        <asp:GridView ID="grvTransportation" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="false">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:TemplateField HeaderText="Case No">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCaseNo" runat="server" Text='<%#Eval("Case No") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Origin">
                                    <ItemTemplate>
                                        <asp:Label ID="lblOrigin" runat="server" Text='<%#Eval("Origin") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Destination">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDestination" runat="server" Text='<%#Eval("Destination") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Transport Type">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTransportType" runat="server" Text='<%#Eval("Transport Type") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Distance (km)">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDistance" runat="server" Text='<%# DataBinder.GetPropertyValue(Container.DataItem, "Distance(km)") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Product Weight(gram)">
                                    <ItemTemplate>
                                        <asp:Label ID="lblProductWeight" runat="server" Text='<%# DataBinder.GetPropertyValue(Container.DataItem, "Product Weight(gram)") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Product Distance Local Similarity">
                                    <ItemTemplate>
                                        <asp:Label ID="lblproductDistanceLS" runat="server" Text='<%#Eval("productDistanceLS", "{0:0.0000000000}") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Product Numerical Local Similarity">
                                    <ItemTemplate>
                                        <asp:Label ID="lblproductNumericalLS" runat="server" Text='<%#Eval("productNumericalLS", "{0:0.0000000000}") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Global Similarity">
                                    <ItemTemplate>
                                        <asp:Label ID="lblGlobalS" runat="server" Text='<%#Eval("GlobalS", "{0:0.0000000000}") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EditRowStyle BackColor="#999999" />
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                        </asp:GridView>
                    </div>
                    <div>
                        <table style="width: 583px">
                            <tr>
                                <td colspan="3" class="auto-style1">End of Life</td>
                            </tr>
                            <tr>
                                <td colspan="2">&nbsp;</td>
                                <td>Weight</td>
                            </tr>
                            <tr>
                                <td align="left" valign="top">Recycle</td>
                                <td align="left" valign="top">
                                    <asp:TextBox ID="txtEOLRecycle" runat="server"></asp:TextBox>
                                </td>
                                <td colspan="1">
                                    <asp:TextBox ID="txtEOLRecycleWeight" runat="server" Width="28px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td align="left" valign="top">Incinerated</td>
                                <td align="left" valign="top">
                                    <asp:TextBox ID="txtEOLIncinerated" runat="server"></asp:TextBox>
                                </td>
                                <td align="left" valign="top">
                                    <asp:TextBox ID="txtEOLIncineratedWeight" runat="server" Width="28px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td align="left" valign="top">Landfill</td>
                                <td align="left" valign="top">
                                    <asp:TextBox ID="txtEOLLandfill" runat="server"></asp:TextBox></td>
                                <td align="left" valign="top">
                                    <asp:TextBox ID="txtEOLLandfillWeight" runat="server" Width="28px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td align="left" valign="top">&nbsp;</td>
                                <td align="left" valign="top">&nbsp;</td>
                                <td align="left" valign="top">
                                    <asp:Button ID="btnEOLSearch" runat="server" Text="Search" OnClick="btnEOLSearch_Click" />
                                </td>
                            </tr>
                        </table>
                        <asp:GridView ID="grvEndOfLife" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="false">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:TemplateField HeaderText="Case No">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCaseNo" runat="server" Text='<%#Eval("Case No") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Recycled (%)">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRecycled" runat="server" Text='<%# DataBinder.GetPropertyValue(Container.DataItem, "Recycled(%)") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Incinerated (%)">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIncinerated" runat="server" Text='<%# DataBinder.GetPropertyValue(Container.DataItem, "Incinerated (%)") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Landfill (%)">
                                    <ItemTemplate>
                                        <asp:Label ID="lblLandfill" runat="server" Text='<%# DataBinder.GetPropertyValue(Container.DataItem, "Landfill (%)") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Product Weight(gram)">
                                    <ItemTemplate>
                                        <asp:Label ID="lblProductWeight" runat="server" Text='<%# DataBinder.GetPropertyValue(Container.DataItem, "Product Weight(gram)") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Recycle Numerical Local Similarity">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRecycleNumericalLS" runat="server" Text='<%#Eval("RecycleNumericalLS", "{0:0.0000000000}") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Incinerated Numerical Local Similarity">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIncineratedNumericalLS" runat="server" Text='<%#Eval("IncineratedNumericalLS", "{0:0.0000000000}") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Landfill Numerical Local Similarity">
                                    <ItemTemplate>
                                        <asp:Label ID="lblLandfillNumericalLS" runat="server" Text='<%#Eval("LandfillNumericalLS", "{0:0.0000000000}") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Product Numerical Local Similarity">
                                    <ItemTemplate>
                                        <asp:Label ID="lblproductNumericalLS" runat="server" Text='<%#Eval("productNumericalLS", "{0:0.0000000000}") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Global Similarity">
                                    <ItemTemplate>
                                        <asp:Label ID="lblGlobalS" runat="server" Text='<%#Eval("GlobalS", "{0:0.0000000000}") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EditRowStyle BackColor="#999999" />
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                        </asp:GridView>
                    </div>
                    <div>
                        <table>
                            <tr>
                                <td colspan="3" class="auto-style1">Product Design</td>
                            </tr>
                            <tr>
                                <td colspan="2">&nbsp;</td>
                                <td>Weight</td>
                            </tr>
                            <tr>
                                <td align="left" valign="top">Thickness (Thin Region)</td>
                                <td align="left" valign="top">
                                    <asp:TextBox ID="txtPDThickThin" runat="server"></asp:TextBox>
                                </td>
                                <td colspan="1">
                                    <asp:TextBox ID="txtPDThickThinWeight" runat="server" Width="28px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td align="left" valign="top">Thickness (Thick Region)</td>
                                <td align="left" valign="top">
                                    <asp:TextBox ID="txtPDThickThick" runat="server"></asp:TextBox>
                                </td>
                                <td align="left" valign="top">
                                    <asp:TextBox ID="txtPDThickThickWeight" runat="server" Width="28px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td align="left" valign="top">Height</td>
                                <td align="left" valign="top">
                                    <asp:TextBox ID="txtPDHeight" runat="server"></asp:TextBox></td>
                                <td align="left" valign="top">
                                    <asp:TextBox ID="txtPDHeightWeight" runat="server" Width="28px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td align="left" valign="top">Surface Area</td>
                                <td align="left" valign="top">
                                    <asp:TextBox ID="txtPDSurface" runat="server"></asp:TextBox>
                                </td>
                                <td colspan="1">
                                    <asp:TextBox ID="txtPDSurfaceWeight" runat="server" Width="28px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td align="left" valign="top">Volume</td>
                                <td align="left" valign="top">
                                    <asp:TextBox ID="txtPDVolume" runat="server"></asp:TextBox>
                                </td>
                                <td align="left" valign="top">
                                    <asp:TextBox ID="txtPDVolumeWeight" runat="server" Width="28px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td align="left" valign="top">Perimeter</td>
                                <td align="left" valign="top">
                                    <asp:TextBox ID="txtPDPerimeter" runat="server"></asp:TextBox></td>
                                <td align="left" valign="top">
                                    <asp:TextBox ID="txtPDPerimeterWeight" runat="server" Width="28px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td align="left" valign="top">&nbsp;</td>
                                <td align="left" valign="top">&nbsp;</td>
                                <td align="left" valign="top">
                                    <asp:Button ID="btnPDSearch" runat="server" Text="Search" OnClick="btnPDSearch_Click" />
                                </td>
                            </tr>
                        </table>
                        <asp:GridView ID="grvProductDesign" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="false">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:TemplateField HeaderText="Case No">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCaseNo" runat="server" Text='<%#Eval("Case No") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Thin Region (mm)">
                                    <ItemTemplate>
                                        <asp:Label ID="lblThinRegion" runat="server" Text='<%# DataBinder.GetPropertyValue(Container.DataItem, "Thin Region(mm)") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Thick Region (mm)">
                                    <ItemTemplate>
                                        <asp:Label ID="lblThickRegion" runat="server" Text='<%# DataBinder.GetPropertyValue(Container.DataItem, "Thick Region(mm)") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Height (mm)">
                                    <ItemTemplate>
                                        <asp:Label ID="lblHeight" runat="server" Text='<%# DataBinder.GetPropertyValue(Container.DataItem, "Height(mm)") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Surface Area (mm2)">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSurfaceArea" runat="server" Text='<%# DataBinder.GetPropertyValue(Container.DataItem, "Surface Area(mm2)") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Volume (mm3)">
                                    <ItemTemplate>
                                        <asp:Label ID="lblVolume" runat="server" Text='<%# DataBinder.GetPropertyValue(Container.DataItem, "Volume(mm3)") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Perimeter (mm)">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPerimeter" runat="server" Text='<%# DataBinder.GetPropertyValue(Container.DataItem, "Perimeter(mm)") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Product Weight(gram)">
                                    <ItemTemplate>
                                        <asp:Label ID="lblProductWeight" runat="server" Text='<%# DataBinder.GetPropertyValue(Container.DataItem, "Product Weight(gram)") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Thin Region Numerical Local Similarity">
                                    <ItemTemplate>
                                        <asp:Label ID="lblThinRegionNumericalLS" runat="server" Text='<%#Eval("ThinRegionNumericalLS", "{0:0.0000000000}") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Thick Region Numerical Local Similarity">
                                    <ItemTemplate>
                                        <asp:Label ID="lblThickRegionNumericalLS" runat="server" Text='<%#Eval("ThickRegionNumericalLS", "{0:0.0000000000}") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Height Numerical Local Similarity">
                                    <ItemTemplate>
                                        <asp:Label ID="lblHeightNumericalLS" runat="server" Text='<%#Eval("HeightNumericalLS", "{0:0.0000000000}") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Surface Area Numerical Local Similarity">
                                    <ItemTemplate>
                                        <asp:Label ID="SurfaceAreaNumericalLS" runat="server" Text='<%#Eval("SurfaceAreaNumericalLS", "{0:0.0000000000}") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Volume Numerical Local Similarity">
                                    <ItemTemplate>
                                        <asp:Label ID="lblVolumeNumericalLS" runat="server" Text='<%#Eval("VolumeNumericalLS", "{0:0.0000000000}") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Perimeter Numerical Local Similarity">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPerimeterNumericalLS" runat="server" Text='<%#Eval("PerimeterNumericalLS", "{0:0.0000000000}") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Product Numerical Local Similarity">
                                    <ItemTemplate>
                                        <asp:Label ID="lblproductNumericalLS" runat="server" Text='<%#Eval("productNumericalLS", "{0:0.0000000000}") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Global Similarity">
                                    <ItemTemplate>
                                        <asp:Label ID="lblGlobalS" runat="server" Text='<%#Eval("GlobalS", "{0:0.0000000000}") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EditRowStyle BackColor="#999999" />
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                        </asp:GridView>
                    </div>
                    <div>
                        <table>
                            <tr>
                                <td colspan="3"></td>
                            </tr>
                            <tr>
                                <td align="left" valign="top" colspan="2">
                                    <asp:Button ID="btnEnvironmentalImpact" runat="server" Text="Environment Impact Solution" OnClick="btnEnvironmentalImpact_Click" /></td>
                                <td align="left" valign="top">
                                    <asp:Button ID="btnReset" runat="server" Text="Reset Value" OnClick="btnReset_Click" />
                                </td>
                            </tr>
                        </table>
                        <asp:GridView ID="grvImpact" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:TemplateField HeaderText="Solution">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSolution" runat="server" Text='<%#Eval("Solution") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Carbon Footprint">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCarbonFootprint" runat="server" Text='<%#Eval("CarbonFootprint", "{0:0.0000000000}") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Energy Consumption">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEnergyConsumption" runat="server" Text='<%#Eval("EnergyConsumption", "{0:0.0000000000}") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Air Acidification">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAirAcidification" runat="server" Text='<%#Eval("AirAcidification", "{0:0.0000000000}") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Water Euthrophication">
                                    <ItemTemplate>
                                        <asp:Label ID="lblWaterEuthrophication" runat="server" Text='<%#Eval("WaterEuthrophication", "{0:0.0000000000}") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EditRowStyle BackColor="#999999" />
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                        </asp:GridView>

                        <asp:GridView ID="grvImpactTwo" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:TemplateField HeaderText="Solution">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSolution" runat="server" Text='<%#Eval("Solution") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Carbon Footprint">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtCarbonFootprint" runat="server" Text='<%#Eval("CarbonFootprint", "{0:0.0000000000}") %>'></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Energy Consumption">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtEnergyConsumption" runat="server" Text='<%#Eval("EnergyConsumption", "{0:0.0000000000}") %>'></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Air Acidification">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtAirAcidification" runat="server" Text='<%#Eval("AirAcidification", "{0:0.0000000000}") %>'></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Water Euthrophication">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtWaterEuthrophication" runat="server" Text='<%#Eval("WaterEuthrophication", "{0:0.0000000000}") %>'></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EditRowStyle BackColor="#999999" />
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                        </asp:GridView>

                        <table>
                            <tr>
                                <td colspan="3"></td>
                            </tr>
                            <tr>
                                <td align="left" valign="top" colspan="2">
                                    <asp:Button ID="btnReviseSolution" runat="server" Text="Revise Solution" OnClick="btnReviseSolution_Click" /></td>
                                <td align="left" valign="top">
                                    <asp:Button ID="btnAddToLibrary" runat="server" Text="Add To Library" OnClick="btnAddToLibrary_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">                                                                     
                                    <asp:Label ID="lblResult" runat="server" Text="Inserted" Visible="false"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
