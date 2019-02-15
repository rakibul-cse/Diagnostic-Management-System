<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmTestTypeSetup.aspx.cs" Inherits="Diagnostic_Center.frmTestTypeSetup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="row">
        <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12" style="margin: 0; padding: 0;">
        </div>
        <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12" style="border: 1px solid #AFC7BA; margin-top: 50px; background-color: #DCFAEA; height: auto;">
            <fieldset>
                <legend>Test Type Setup</legend>
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="margin: 0; padding: 0; vertical-align: middle;">
                    <div class="form-group">
                        <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12" style="margin: 0; padding: 0; vertical-align: middle;">
                             <div class="form-group" style="margin: 0; padding: 0;">
                            <asp:Label ID="labelTestType" CssClass="form-control" BorderStyle="None" runat="server" Text="Test Type Setup"></asp:Label>
                                 </div>
                        </div>
                        <div class="col-lg-7 col-md-7 col-sm-12 col-xs-12" style="margin: 0; padding: 0; vertical-align: middle;">
                            <div class="form-group" style="margin: 0; padding: 0;">
                            <asp:TextBox ID="txtTypeName" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="margin: 0; padding: 0;">
                    <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12" style="margin: 0; padding: 0; vertical-align: middle;">
                        <div class="form-group" style="margin: 0; padding: 0;">
                            <asp:HiddenField ID="hfID" runat="server" />
                        </div>
                    </div>

                    <div class="col-lg-8 col-md-8 col-sm-12 col-xs-12" style="margin: 0; padding: 0; text-align: right;">
                       <br />
                        <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12" style="margin: 0; padding: 0; text-align: right;">
                            <div class="form-group">
                               
                        </div>
                        </div>
                        <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12" style="margin: 0; padding: 0; text-align: right;">
                            <div class="form-group">
                                <asp:Button ID="btn" runat="server" CssClass="btn btn-success" Text="Save" OnClick="btnSave_Click" />
                            </div>
                        </div>
                        <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12" style="margin: 0; padding: 0; text-align: right;">
                            <div class="form-group">
                                <asp:Button ID="btnClear" runat="server" CssClass="btn btn-primary" Text="Clear" OnClick="btnClear_Click" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="  margin: 0; padding: 0; vertical-align: middle;  vertical-align:central; ">
                    <div class="form-group">

                        <asp:GridView  ID="GridView1" CssClass="table-responsive" runat="server" Width="98%" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged1"  OnRowDataBound="GridView1_RowDataBound" CellPadding="4" ForeColor="#333333">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:CommandField ShowSelectButton="True" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="10%">
                                    <HeaderStyle Width="15%"></HeaderStyle>

                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:CommandField>
                                <asp:BoundField DataField="Serial" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="10%" HeaderText="Serial">
<HeaderStyle HorizontalAlign="Center" Width="15%"></HeaderStyle>

                                     <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="TypeName" HeaderStyle-HorizontalAlign="Center" HeaderText="Type Name" >
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                     <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="ID" HeaderText="ID" />
                            </Columns>
                            <EditRowStyle BackColor="#7C6F57" />
                            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#E3EAEB" />
                            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F8FAFA" />
                            <SortedAscendingHeaderStyle BackColor="#246B61" />
                            <SortedDescendingCellStyle BackColor="#D4DFE1" />
                            <SortedDescendingHeaderStyle BackColor="#15524A" />
                        </asp:GridView>

                    </div>
                </div>
            </fieldset>
        </div>
        <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
        </div>
    </div>
</asp:Content>
