<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmTestSetup.aspx.cs" Inherits="Diagnostic_Center.frmTestSetup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">

        <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
        </div>
        <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="border: 1px solid #AFC7BA; margin-top: 50px;  background-color: #DCFAEA; height:auto;">
                <fieldset><legend>Test Setup</legend>
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="border: 1px solid #6B7A72; padding: 50px 50px 20px 50px;  margin-bottom:20px; background-color: #ffffff; height:auto;">
                    <div class="form-group">
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="margin: 0; padding: 0;">
                            <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12" style="margin: 0; padding: 0; vertical-align: middle;">
                                <div class="form-group">
                                    <asp:Label ID="lbl1" Text="Test Name :" runat="server" CssClass="form-control" BorderStyle="None"></asp:Label>
                                </div>
                            </div>
                            <div class="col-lg-7 col-md-7 col-sm-12 col-xs-12" style="margin: 0; padding: 0;">
                                <div class="form-group">
                                    <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12" style="margin: 0; padding: 0;">
                            </div>
                        </div>
                    </div>

                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="margin: 0; padding: 0;">
                        <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12" style="margin: 0; padding: 0; vertical-align: middle;">
                            <div class="form-group">
                                <asp:Label ID="Label1" Text="Fee :" runat="server" CssClass="form-control" BorderStyle="None"></asp:Label>
                            </div>
                        </div>
                        <div class="col-lg-7 col-md-7 col-sm-12 col-xs-12" style="margin: 0; padding: 0;">
                            <div class="form-group">
                                <asp:TextBox ID="txtFee" style="text-align:right" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12" style="margin: 0; padding: 0; text-align: left; vertical-align: middle;">
                            <div class="form-group">
                                <asp:Label ID="Label2" Text="BDT" runat="server" CssClass="form-control" BorderStyle="None"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="margin: 0; padding: 0;">
                        <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12" style="margin: 0; padding: 0; vertical-align: middle;">
                            <div class="form-group">
                                <asp:Label ID="Label3" Text="Test Type" runat="server" CssClass="form-control" BorderStyle="None"></asp:Label>
                            </div>
                        </div>
                        <div class="col-lg-7 col-md-7 col-sm-12 col-xs-12" style="margin: 0; padding: 0;">
                            <div class="form-group">
                                <asp:DropDownList ID="ddlTestType" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12" style="margin: 0; padding: 0; text-align: left; vertical-align: middle;">
                            <div class="form-group">
                                
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="margin: 0; padding: 0;">
                        <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12" style="margin: 0; padding: 0; vertical-align: middle;">
                            <div class="form-group">
                               
                            </div>
                        </div>
                        <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12" style="margin: 0; padding: 0; text-align:right;">
                            <div class="form-group">
                                <asp:HiddenField ID="hfID" runat="server" />
                                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-success" Text="Save" OnClick="btnSave_Click" />
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12" style="margin: 0; padding: 0; text-align:right;">
                            <div class="form-group">
                                
                                <asp:Button ID="btnClear" runat="server" CssClass=" btn btn-primary" Text="Clear" OnClick="btnClear_Click" />
                            </div>
                        </div>
                        <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12" style="margin: 0; padding: 0; text-align: left; vertical-align: middle;">
                            <div class="form-group">
                                
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="margin: 0; padding: 0;">
                        
                        <asp:GridView ID="dgTestHistory" runat="server" CellPadding="4" ForeColor="#333333" Width="100%" OnRowDataBound="dgTestHistory_RowDataBound" OnSelectedIndexChanged="dgTestHistory_SelectedIndexChanged">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:CommandField ShowSelectButton="True" />
                            </Columns>
                            <EditRowStyle BackColor="#2461BF" />
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                        </asp:GridView>
                        
                    </div>
                </div></fieldset>
                
            </div>

        </div>
    <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
    </div>

    </div>
   

</asp:Content>
