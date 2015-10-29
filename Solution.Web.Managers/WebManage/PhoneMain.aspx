<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PhoneMain.aspx.cs" Inherits="Solution.Web.Managers.WebManage.PhoneMain" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>香港信息網絡系統</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=no, minimum-scale=1.0, maximum-scale=1.0"/>
</head>
<body>
    <form id="form1" runat="server">
    <f:pagemanager id="PageManager1" runat="server" />
    <f:Panel ID="Panel1" runat="server" EnableFrame="false" BodyPadding="10px" EnableCollapse="True" ShowHeader="False">
       <Items>
           <f:Tree runat="server" ShowBorder="false" ShowHeader="false" EnableArrows="true"
                        EnableLines="true" ID="leftMenuTree">
           </f:Tree>
       </Items>
    </f:Panel>
    </form>
</body>
</html>
