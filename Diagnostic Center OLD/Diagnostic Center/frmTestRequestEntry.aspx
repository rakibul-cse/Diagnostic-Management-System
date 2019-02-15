<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmTestRequestEntry.aspx.cs" Inherits="Diagnostic_Center.frmTestRequestEntry" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <div class="row">
        <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
        </div>
        <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12" style="border: 1px solid #AFC7BA; margin-top: 10px; margin-bottom: 10px; background-color: #DCFAEA; height: auto;">
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                <fieldset>
                    <asp:HiddenField ID="hfMstID" runat="server" />
                    <legend>Patient Information</legend>
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="margin: 0; padding: 0; vertical-align: middle;">
                        <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12" style="margin: 0; padding: 0; vertical-align: middle;">
                            <div class="form-group">
                                <asp:Label ID="labelTestType" CssClass="form-control" BorderStyle="None" runat="server" Text="Patient Name"></asp:Label>
                            </div>
                        </div>
                        <div class="col-lg-7 col-md-7 col-sm-12 col-xs-12" style="margin: 0; padding: 0; vertical-align: middle;">
                            <div class="form-group">
                                <asp:TextBox ID="txtPatientName" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12" style="margin: 0; padding: 0; vertical-align: middle;">
                            <div class="form-group">
                                <asp:Label ID="Label5" runat="server" Text="*" Font-Bold="True" Font-Size="Large" ForeColor="#CC3300"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="margin: 0; padding: 0; vertical-align: middle;">
                        <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12" style="margin: 0; padding: 0; vertical-align: middle; top: 0px; left: 0px;">
                            <div class="form-group">
                                <asp:Label ID="label1" CssClass="form-control" BorderStyle="None" runat="server" Text="Date Of Dirth"></asp:Label>
                            </div>
                        </div>

                        <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12" style="margin: 0; padding: 0; vertical-align: middle; top: 0px; left: 0px;">
                            <div class="form-group">
                                <asp:TextBox ID="txtDBO"  placeHolder="dd/MM/yyyy" CssClass="form-control" runat="server"></asp:TextBox>
                                <ajaxtoolkit:calendarextender runat="server" ID="Calendarextender1" TargetControlID="txtDBO" Format="dd/MM/yyyy"/>
                            </div>

                        </div>
                        <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12" style="margin: 0; padding: 0; vertical-align: middle;">
                            <div class="form-group">
                                <asp:Label ID="label2" CssClass="form-control" BorderStyle="None" runat="server" Text="Mobile No."></asp:Label>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12" style="margin: 0; padding: 0; vertical-align: middle;">
                            <div class="form-group">
                                <asp:TextBox ID="txtMobileNo" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>

                        </div>
                    </div>
                    </fieldset>
                    <fieldset>
                    <legend>Test Information</legend>
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="margin: 0; padding: 0; vertical-align: middle;">
                        <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12" style="margin: 0; padding: 0; vertical-align: middle;">
                            <div class="form-group">
                                <asp:Label ID="label3" CssClass="form-control" BorderStyle="None" runat="server" Text="Select Test"></asp:Label>
                            </div>
                        </div>

                        <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12" style="margin: 0; padding: 0; vertical-align: middle;">
                            <div class="form-group">
                                <asp:DropDownList ID="ddlTest" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlTest_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                         <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12" style="margin: 0; padding: 0; vertical-align: middle;">
                            <div class="form-group">
                                <asp:Label ID="label4" CssClass="form-control" BorderStyle="None" runat="server" Text="Fees"></asp:Label>
                            </div>
                        </div>
                        <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12" style="margin: 0; padding: 0; vertical-align: middle;">
                            <div class="form-group">
                                <asp:TextBox ID="txtFees" Enabled="false" style="text-align:right" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>

                        </div>
                    </div>
                   </fieldset>
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="margin: 0; padding: 0;">
                        <div class="col-lg-8 col-md-8 col-sm-12 col-xs-12" style="margin: 0; padding: 0; vertical-align: middle;">
                            <div class="form-group" style="margin: 0; padding: 0;"></div>
                        </div>
                        <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12" style="margin: 0; padding: 0; text-align: right;">
                            <div class="form-group">
                                <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-success" Text="ADD" OnClick="btnAdd_Click" />
                            </div>
                        </div>
                        <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12" style="margin: 0; padding: 0; text-align: right;">
                            <div class="form-group">
                                <asp:Button ID="btnClear" runat="server" CssClass="btn btn-primary" Text="Clear" OnClick="btnClear_Click" />
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="margin: 0; padding: 0;">
                        <div class="form-group">

                            <asp:GridView ID="dgAddItems" runat="server" Width="100%" CssClass="table" OnRowDataBound="dgAddItems_RowDataBound" CellPadding="4" ForeColor="#333333">
                                <AlternatingRowStyle BackColor="White" />
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
                    </div>
                 <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="margin: 0; padding: 0;">
                        <div class="form-group" align="right">                           
                            <asp:Button ID="btnSave" CssClass="btn btn-success" runat="server" Text="Save" OnClick="btnSave_Click" />
                        </div>
                    </div>
            </div>
        </div>
        <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
        </div>

    </div>
</asp:Content>
