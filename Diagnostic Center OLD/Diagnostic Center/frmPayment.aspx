<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmPayment.aspx.cs" Inherits="Diagnostic_Center.frmPayment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

   <script language="javascript" type="text/javascript" >
       
       function isNumber(evt) {
           evt = (evt) ? evt : window.event;
           var charCode = (evt.which) ? evt.which : evt.keyCode;
           if (charCode != 46 && charCode > 31
               && (charCode < 48 || charCode > 57)) {
               return false;
           }
           return true;
       }
</script>
    <br />
    <asp:HiddenField ID="hfID" runat="server" />
    <div class="row">
        <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12" style="margin: 0; padding: 0;">
            <div class="form-group" style="margin: 0; padding: 0;"></div>
        </div>

        <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12" style="border: 1px solid #AFC7BA; margin-top: 50px; background-color: #DCFAEA; height: auto;">
            <fieldset>
                <legend>Pay Bill</legend>
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="margin: 0; padding: 0; vertical-align: middle;">

                    <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12" style="margin: 0; padding: 0; vertical-align: middle; top: 0px; left: 0px;">
                        <div class="form-group" style="margin: 0; padding: 0;">
                            <asp:Label ID="label1" runat="server" CssClass="form-control" BorderStyle="None">Bill No : </asp:Label>
                        </div>
                    </div>
                    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12" style="margin: 0; padding: 0; vertical-align: middle;">
                        <div class="form-group" style="margin: 0; padding: 0;">
                            <asp:TextBox ID="txtSearch" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12" align="right" style="margin: 0; padding: 0; vertical-align: middle;">
                        <div class="form-group" style="margin: 0; padding: 0;">
                            <asp:Button ID="btnSearch" Text="Search" CssClass="btn btn-primary" runat="server" OnClick="btnSearch_Click" />
                        </div>
                    </div>

                </div>

               
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="margin: 0; padding: 0; vertical-align: middle;">
                    <div class="form-group" style="margin: 0; padding: 10px;">
                        <asp:GridView ID="dgTestHistory" CssClass="table" runat="server"></asp:GridView>
                    </div>
                </div>

                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="margin: 0; padding: 0; vertical-align: middle;">
                    <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12" style="margin: 0; padding: 0; vertical-align: middle;">
                        <div class="form-group" style="margin: 0; padding: 0;"></div>
                    </div>
                    <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12" style="margin: 0; padding: 0; vertical-align: middle;">
                        <div class="form-group" style="margin: 0; padding: 0;">
                            <asp:Label ID="label12" runat="server" CssClass="form-control" BorderStyle="None">Bill Date</asp:Label>
                        </div>
                    </div>
                    <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12" style="margin: 0; padding: 0; vertical-align: middle;">
                        <div class="form-group" style="margin: 0; padding: 0;">
                            <asp:Label ID="lblDate" CssClass="form-control" BorderStyle="None" runat="server"></asp:Label>
                        </div>
                    </div>
                </div>

                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="margin: 0; padding: 0; vertical-align: middle;">
                    <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12" style="margin: 0; padding: 0; vertical-align: middle;">
                        <div class="form-group" style="margin: 0; padding: 0;"></div>
                    </div>
                    <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12" style="margin: 0; padding: 0; vertical-align: middle;">
                        <div class="form-group" style="margin: 0; padding: 0;">
                            <asp:Label ID="label3" runat="server" CssClass="form-control" BorderStyle="None">Total Fee</asp:Label>
                        </div>
                    </div>
                    <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12" style="margin: 0; padding: 0; vertical-align: middle;">
                        <div class="form-group" style="margin: 0; padding: 0;">
                            <asp:Label ID="lblTolatFee" Style="text-align: right" CssClass="form-control" BorderStyle="None" runat="server"></asp:Label>
                        </div>
                    </div>
                </div>

                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="margin: 0; padding: 0; vertical-align: middle;">
                    <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12" style="margin: 0; padding: 0; vertical-align: middle;">
                        <div class="form-group" style="margin: 0; padding: 0;"></div>
                    </div>
                    <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12" style="margin: 0; padding: 0; vertical-align: middle;">
                        <div class="form-group" style="margin: 0; padding: 0;">
                            <asp:Label ID="label5" runat="server" CssClass="form-control" BorderStyle="None">Paid Amount</asp:Label>
                        </div>
                    </div>
                    <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12" style="margin: 0; padding: 0; vertical-align: middle;">
                        <div class="form-group" style="margin: 0; padding: 0;">
                            <asp:Label ID="lblPaidAmount" CssClass="form-control" Style="text-align: right" BorderStyle="None" runat="server"></asp:Label>
                        </div>
                    </div>
                </div>

                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="margin: 0; padding: 0; vertical-align: middle;">
                    <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12" style="margin: 0; padding: 0; vertical-align: middle;">
                        <div class="form-group" style="margin: 0; padding: 0;"></div>
                    </div>
                    <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12" style="margin: 0; padding: 0; vertical-align: middle;">
                        <div class="form-group" style="margin: 0; padding: 0;">
                            <asp:Label ID="label22" runat="server" CssClass="form-control" BorderStyle="None">Due Amount</asp:Label>
                        </div>
                    </div>
                    <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12" style="margin: 0; padding: 0; vertical-align: middle;">
                        <div class="form-group" style="margin: 0; padding: 0;">
                            <asp:Label ID="lblDue" CssClass="form-control" BorderStyle="None" Style="text-align: right" runat="server"></asp:Label>
                        </div>
                    </div>
                </div>

                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="margin: 0; padding: 0; vertical-align: middle;">
                    <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12" style="margin: 0; padding: 0; vertical-align: middle;">
                        <div class="form-group" style="margin: 0; padding: 0;"></div>
                    </div>
                    <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12" style="margin: 0; padding: 0; vertical-align: middle;">
                        <div class="form-group" style="margin: 0; padding: 0;">
                            <asp:Label ID="label2" runat="server" CssClass="form-control" BorderStyle="None">Amount</asp:Label>
                        </div>
                    </div>
                    <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12" style="margin: 0; padding: 0; vertical-align: middle;">
                        <div class="form-group" style="margin: 0; padding: 0;">
                            <asp:TextBox ID="txtPayAmt" CssClass="form-control" onFocus="this.select()" onkeypress="return isNumber(event)" Style="text-align: right" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="margin: 0; padding: 0; vertical-align: middle;">
                    <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12" style="margin: 0; padding: 0; vertical-align: middle; top: 0; left: 0;">
                        <div class="form-group" style="margin: 0; padding: 10px;">
                            <asp:Button ID="btnPrint" runat="server" CssClass="btn btn-info" Text="Print" OnClick="btnPrint_Click" />
                        </div>
                    </div>
                    <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12" align="right" style="margin: 0px; text-align: right; padding: 0; vertical-align: middle; top: 0; left: 0;">
                        <div class="form-group" style="margin: 0; padding: 10px;">
                            <div class="form-group" style="margin: 0; padding: 0;">
                                <asp:Button ID="btnPay" runat="server" CssClass="btn btn-success" Text="Payment" OnClick="btnPay_Click" />
                            </div>

                        </div>
                    </div>
                    <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12" align="right" style="margin: 0; padding-top: 10px; padding-bottom: 10px; vertical-align: middle; top: 0; left: 0;">
                        <div class="form-group" style="margin: 0; padding: 0;">
                            <asp:Button ID="btnClear" runat="server" CssClass="btn btn-primary" Text="Clear" OnClick="btnClear_Click"  />
                        </div>
                    </div>
                </div>

            </fieldset>
        </div>

        <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
            <div class="form-group" style="margin: 0; padding: 0;"></div>
        </div>
    </div>
</asp:Content>
