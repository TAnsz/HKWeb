<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PhoneMain.aspx.cs" Inherits="Solution.Web.Managers.PhoneMain" %>

<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <title>香港信息網絡系統</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=no, minimum-scale=1.0, maximum-scale=5.0" />
    <style type="text/css">
        body.f-theme-neptune .header {
            background-color: #005999;
            border-bottom: 1px solid #1E95EC;
        }

            body.f-theme-neptune .header .x-panel-body {
                background-color: transparent;
            }

            body.f-theme-neptune .header .title a {
                font-weight: bold;
                font-size: 24px;
                text-decoration: none;
                line-height: 50px;
                margin-left: 10px;
            }

        .label {
            color: #80ACCC;
        }

        .content {
            color: #fff;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server" />

        <f:Panel ID="Panel1" runat="server" EnableFrame="false" BodyPadding="10px" EnableCollapse="True" ShowHeader="False">
            <Toolbars>
                <f:Toolbar ID="Toolbar1" Position="Top" runat="server" CssClass="topbar content"
                    CssStyle="border-bottom: 1px solid #1E95EC;background-color: #005999;">
                    <Items>
                        <f:ToolbarText ID="ToolbarText1" Text="歡迎您：" runat="server" CssClass="label">
                        </f:ToolbarText>
                        <f:ToolbarText ID="txtUser" runat="server" CssClass="content">
                        </f:ToolbarText>
                    </Items>
                </f:Toolbar>
                <f:Toolbar ID="Toolbar2" Position="Top" runat="server" CssClass="topbar content"
                    CssStyle="border-bottom: 1px solid #1E95EC;background-color: #005999;">
                    <Items>
                        <f:ToolbarFill runat="server"></f:ToolbarFill>
                        <f:Button ID="btnExit" runat="server" Icon="UserRed" Text="安全退出" ConfirmText="確定退出系統？"
                            OnClick="btnExit_Click" CssStyle="background-color: transparent;background-image: none !important;border-width: 0 !important;">
                        </f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Items>
                <f:Tree runat="server" ShowBorder="true" ShowHeader="true" EnableArrows="true" Title="菜單" 
                    EnableLines="true" ID="leftMenuTree">
                </f:Tree>
            </Items>
        </f:Panel>
    </form>
</body>
</html>
