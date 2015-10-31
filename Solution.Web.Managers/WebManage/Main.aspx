<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="Solution.Web.Managers.Main" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head2" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=yes minimum-scale=0.5, maximum-scale=4.0"/>
    <title>香港信息網絡系統</title>
    <style type="text/css">
        body.f-theme-neptune .header
        {
            background-color: #005999;
            border-bottom: 1px solid #1E95EC;
        }
        
        body.f-theme-neptune .header .x-panel-body
        {
            background-color: transparent;
        }
        
        body.f-theme-neptune .header .title a
        {
            font-weight: bold;
            font-size: 24px;
            text-decoration: none;
            line-height: 50px;
            margin-left: 10px;
        }
        .label
        {
            color: #80ACCC;
        }
        .content
        {
            color: #fff;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <f:PageManager ID="PageManager1" AutoSizePanelID="regionPanel" runat="server" />
    <f:Timer ID="Timer1" Interval="120" Enabled="false" OnTick="Timer1_Tick" runat="server">
    </f:Timer>
    <f:RegionPanel ID="regionPanel" ShowBorder="false" runat="server">
        <Regions>
            <f:Region ID="regionTop" ShowBorder="false" ShowHeader="false" Position="Top" Layout="Fit"
                runat="server">
                <Toolbars>
                    <f:Toolbar ID="Toolbar1" Position="Bottom" runat="server" CssClass="topbar content"
                        CssStyle="border-bottom: 1px solid #1E95EC;background-color: #005999;">
                        <Items>
                            <f:ToolbarText ID="ToolbarText1" Text="歡迎您：" runat="server" CssClass="label">
                            </f:ToolbarText>
                            <f:ToolbarText ID="txtUser" runat="server" CssClass="content">
                            </f:ToolbarText>
                            <f:ToolbarText ID="ToolbarText2" Text="部門：" runat="server" CssClass="label">
                            </f:ToolbarText>
                            <f:ToolbarText ID="txtBranchName" runat="server" CssClass="content">
                            </f:ToolbarText>
                            <f:ToolbarText ID="ToolbarText3" Text="職位：" runat="server" CssClass="label">
                            </f:ToolbarText>
                            <f:ToolbarText ID="txtPositionInfoName" runat="server" CssClass="content">
                            </f:ToolbarText>
                            <f:ToolbarText ID="ToolbarText4" Text="在線人數：" runat="server" CssClass="label">
                            </f:ToolbarText>
                            <f:ToolbarText ID="txtOnlineUserCount" runat="server" CssClass="content">
                            </f:ToolbarText>
                            <f:ToolbarFill ID="ToolbarFill1" runat="server" />
                            <f:Button ID="btnClearCache" runat="server" Icon="controlblank" Text="清除後端緩存" OnClick="btnClearCache_Click"
                                CssStyle="background-color: transparent;background-image: none !important;border-width: 0 !important;">
                            </f:Button>
                            <f:Button ID="btnCalendar" runat="server" Icon="Calendar" Text="萬年曆" EnablePostBack="false"
                                CssStyle="background-color: transparent;background-image: none !important;border-width: 0 !important;">
                            </f:Button>
                            <f:Button ID="btnHelp" EnablePostBack="false" Icon="Help" Text="幫助" runat="server"
                                CssStyle="background-color: transparent;background-image: none !important;border-width: 0 !important;">
                            </f:Button>
                            <f:Button ID="btnExit" runat="server" Icon="UserRed" Text="安全退出" ConfirmText="確定退出系統？"
                                OnClick="btnExit_Click" CssStyle="background-color: transparent;background-image: none !important;border-width: 0 !important;">
                            </f:Button>
                        </Items>
                    </f:Toolbar>
                </Toolbars>
            </f:Region>
            <f:Region ID="Region2" Split="true" Width="200px" ShowHeader="true" Title="菜單" EnableCollapse="true" Expanded="false"
                Layout="Fit" Position="Left" runat="server">
                <Items>
                    <f:Tree runat="server" ShowBorder="false" ShowHeader="false" EnableArrows="true"
                        EnableLines="true" ID="leftMenuTree">
                    </f:Tree>
                </Items>
            </f:Region>
            <f:Region ID="mainRegion" ShowHeader="false" Layout="Fit" Position="Center" runat="server">
                <Items>
                    <f:TabStrip ID="mainTabStrip" EnableTabCloseMenu="true" ShowBorder="false" runat="server">
                        <Tabs>
                            <f:Tab ID="Tab1" Title="首頁" Layout="Fit" Icon="House" runat="server">
                                <Items>
                                    <f:ContentPanel ID="ContentPanel2" ShowBorder="false" BodyPadding="10px" ShowHeader="false"
                                        AutoScroll="true" runat="server">
                                        <h2>
                                            人事考勤</h2>
                                        現階段隻包含請假/出差/調休單的查看和審批！<br />
                                        <h2>會議室</h2>
                                        會議室的申請查看！<br />
                                        <h2>訂餐</h2>
                                        中餐預訂
                                        <br />
                                        </f:ContentPanel>
                                </Items>
                            </f:Tab>
                        </Tabs>
                    </f:TabStrip>
                </Items>
            </f:Region>
        </Regions>
    </f:RegionPanel>
    <f:Window ID="Window1" runat="server" IsModal="true" Hidden="true" EnableIFrame="true"
        EnableResize="true" EnableMaximize="true" IFrameUrl="about:blank" Width="650px"
        Height="450px">
    </f:Window>
    </form>
    <script>
        var menuClientID = '<%= leftMenuTree.ClientID %>';
        var tabStripClientID = '<%= mainTabStrip.ClientID %>';

        // 頁面控件初始化完畢後，會調用用戶自定義的onReady函數
        F.ready(function () {

            // 初始化主框架中的樹(或者Accordion+Tree)和選項卡互動，以及地址欄的更新
            // treeMenu： 主框架中的樹控件實例，或者內嵌樹控件的手風琴控件實例
            // mainTabStrip： 選項卡實例
            // createToolbar： 創建選項卡前的回調函數（接受tabConfig參數）
            // updateLocationHash: 切換Tab時，是否更新地址欄Hash值
            // refreshWhenExist： 添加選項卡時，如果選項卡已經存在，是否刷新內部IFrame
            // refreshWhenTabChange: 切換選項卡時，是否刷新內部IFrame
            F.util.initTreeTabStrip(F(menuClientID), F(tabStripClientID), null, true, false, false);

        });
    </script>
</body>
</html>
