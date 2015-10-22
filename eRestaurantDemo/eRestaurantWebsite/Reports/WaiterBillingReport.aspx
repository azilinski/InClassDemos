﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="WaiterBillingReport.aspx.cs" Inherits="Reports_WaiterBillingReport" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

    <br /><br /><br /><br /><br /><br /><br /><br />
    <h1>Report Waiter Billing</h1>
    <rsweb:ReportViewer ID="WaiterBIllingRV" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="100%">
        <LocalReport ReportPath="UserControls\WaiterBillings.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="ODSWaiterBilling" Name="WaiterBilling" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>
    <asp:ObjectDataSource ID="ODSWaiterBilling" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetWaiterBillingReport" TypeName="eResturauntSystem.BLL.AdminController"></asp:ObjectDataSource>
</asp:Content>

