<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="Solution.Web.Managers.WebManage.Report" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <title>香港信息網絡系統</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" CssClass="ReportFont"  Width="100%" Height="100%"
             ZoomMode="PageWidth" ShowBackButton="true"  SizeToReportContent="True" Font-Size="8pt" InteractiveDeviceInfos="(Collection)"  ShowPrintButton="true">
            <LocalReport ReportPath="WebManage\Meals\ReportMeal.rdlc">
            </LocalReport>
        </rsweb:ReportViewer>
    </form>
</body>
</html>
