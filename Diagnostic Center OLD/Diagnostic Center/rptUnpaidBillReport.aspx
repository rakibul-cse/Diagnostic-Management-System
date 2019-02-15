<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rptUnpaidBillReport.aspx.cs" Inherits="Diagnostic_Center.rptUnpaidBillReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <div class="row">

        <div class="col-lg-3 col-md-3 col-xs-12 col-sm-12" style="margin: 0; padding: 0; vertical-align: middle;">
        </div>

        <div class="col-lg-6 col-md-6 col-xs-12 col-sm-12" style="border: 1px solid #AFC7BA; margin-top: 10px; margin-bottom: 10px; background-color: #DCFAEA; height: auto;">
            <fieldset>
                <legend>Unpaid bill Report</legend>
                <div class="col-lg-12 col-md-12 col-xs-12 col-sm-12" style="margin: 0; padding: 0; vertical-align: middle;">
                    <div class="col-lg-6 col-md-6 col-xs-12 col-sm-12" style="margin: 0; padding: 0; vertical-align: middle;" align="right">
                        <div class="form-group">
                            <asp:Label ID="label1" runat="server" CssClass="form-control" BorderStyle="None">From Date</asp:Label>
                        </div>
                    </div>                    
                    <div class="col-lg-6 col-md-6 col-xs-12 col-sm-12" style="margin: 0; padding: 0; vertical-align: middle;">
                        <div class="form-group">
                            <asp:TextBox ID="txtFromdate" CssClass="form-control" placeHolder="dd/MM/yyyy" runat="server"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender runat="server" ID="Calendarextender1" TargetControlID="txtFromdate" Format="dd/MM/yyyy" />
                        </div>
                    </div>

                    <div class="col-lg-6 col-md-6 col-xs-12 col-sm-12" style="margin: 0; padding: 0; vertical-align: middle;" align="right">
                        <div class="form-group">
                            <asp:Label ID="label2" runat="server" CssClass="form-control" BorderStyle="None">To Date</asp:Label>
                        </div>
                    </div>                  
                    <div class="col-lg-6 col-md-6 col-xs-12 col-sm-12" style="margin: 0; padding: 0; vertical-align: middle;">
                        <div class="form-group">
                            <asp:TextBox ID="txtToDate" CssClass="form-control" placeHolder="dd/MM/yyyy" runat="server"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender runat="server" ID="Calendarextender2" TargetControlID="txtToDate" Format="dd/MM/yyyy" />
                        </div>
                    </div>

                    <div class="col-lg-4 col-md-4 col-xs-12 col-sm-12" style="margin: 0; padding: 0; vertical-align: middle;">
                        <div class="form-group">
                        </div>
                    </div>
                    <div class="col-lg-4 col-md-4 col-xs-12 col-sm-12" style="margin: 0; padding: 0; vertical-align: middle;">
                        <div class="form-group">
                        </div>
                    </div>
                    <div class="col-lg-2 col-md-2 col-xs-12 col-sm-12" style="margin: 0; padding: 0; vertical-align: middle;" align="right">
                        <div class="form-group">
                            <asp:Button ID="txtShow" Text="Show" runat="server" CssClass="btn btn-success"  />
                        </div>
                    </div>
                    <div class="col-lg-2 col-md-2 col-xs-12 col-sm-12" style="margin: 0; padding: 0; vertical-align: middle;" align="right">
                        <div class="form-group">
                            <asp:Button ID="btnClear" Text="Clear" runat="server" CssClass="btn btn-primary"  />
                        </div>
                    </div>
                </div>
            </fieldset>
            <div class="col-lg-12 col-md-12 col-xs-12 col-sm-12" style="margin: 0; padding: 0; vertical-align: middle;">
                <asp:GridView ID="dgTestHistory" Width="100%" CssClass="table" runat="server" ></asp:GridView>
            </div>
            <div class="col-lg-12 col-md-12 col-xs-12 col-sm-12" style="margin: 0; padding: 0; vertical-align: middle;" align="right">
                <div class="form-group">
                    <asp:Button ID="btnPdf" runat="server" CssClass="btn btn-warning" Text="PDF"  />
                </div>
            </div>
        </div>
        <div class="col-lg-3 col-md-3 col-xs-12 col-sm-12" style="margin: 0; padding: 0; vertical-align: middle;">
        </div>
    </div>
</asp:Content>
