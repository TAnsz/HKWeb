<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="Solution.Web.Managers.Main" %>

<!DOCTYPE html>
<html>
<head id="Head2" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=yes minimum-scale=0.5, maximum-scale=4.0" />
    <title>香港信息網絡系統</title>
    <link href="WebManage/Css/main.css" rel="stylesheet" />
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
        <f:PageManager ID="PageManager1" AutoSizePanelID="regionPanel" runat="server" />
        <f:Timer ID="Timer1" Interval="600" Enabled="false" OnTick="Timer1_Tick" runat="server">
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
                                        <f:Panel runat="server" ID="Panel1" Title="歡迎使用該系統" ShowHeader="true" BoxConfigPadding="10px" Layout="HBox" BoxConfigChildMargin="0 5 0 0">
                                            <Items>
                                                <f:Panel runat="server" ID="Panel2" Title="功能模塊" ShowHeader="true" BodyPadding="10px" Width="280px" Height="100%" ShowBorder="true" EnableCollapse="True">
                                                    <Items>
                                                        <f:Form runat="server" ID="formMain" Layout="Vbox" ShowBorder="false" BoxConfigChildMargin="0 0 10 0">
                                                            <Items>

                                                                <%-- <f:Button ID="btnLeave" runat="server" Text="請假出差單管理" CssClass="btn red-stripe big"></f:Button>
                                                                <f:Button ID="btnAdju" runat="server" Text="調休申請單管理" CssClass="btn blue-stripe big"></f:Button>
                                                                <f:Button ID="btnMeeting" runat="server" Text="會議室使用管理" CssClass="btn purple-stripe big"></f:Button>
                                                                <f:Button ID="btnMeal" runat="server" Text="員工訂餐管理" CssClass="btn green-stripe big"></f:Button>--%>
                                                            </Items>
                                                        </f:Form>
                                                        <%-- <f:ContentPanel runat="server">
                                                        <div class="btn gray" style="background-color: #e5e5e5; width: 100%; margin: 10px; padding: 10px; font-size: large; border-left: 3px solid #1E95EC;"><strong>請假出差單管理</strong> <span style="color: #666; font-size: medium">人事模塊，請假和出差單的申請和一二級審核</span></div>
                                                        </f:ContentPanel>--%>
                                                    </Items>
                                                </f:Panel>
                                                <f:Panel runat="server" ID="Panel3" ShowBorder="false" Layout="VBox" BoxFlex="1">
                                                    <Items>
                                                        <f:Grid ID="Grid1" Title="今日請假/出差/調休列表" EnableFrame="false" EnableCollapse="true" AllowSorting="true" AllowPaging="false" BoxFlex="1"
                                                            ShowBorder="true" ShowHeader="true" runat="server" EnableCheckBoxSelect="false" DataKeyNames="emp_id" EnableColumnLines="true"
                                                            OnPreRowDataBound="Grid1_PreRowDataBound" SortField="EMP_FNAME" OnSort="Grid1_Sort">
                                                            <Columns>
                                                                <f:BoundField DataField="emp_id" SortField="emp_id" HeaderText="編號" Width="70px" />
                                                                <f:BoundField DataField="EMP_FNAME" SortField="EMP_FNAME" HeaderText="姓名" Width="250px" />
                                                                <f:BoundField DataField="emp_ename" SortField="emp_ename" HeaderText="英文名" Width="100px" />
                                                                <f:BoundField DataField="bill_date" SortField="bill_date" HeaderText="開始日期" DataFormatString="{0:yyyy-MM-dd}" Width="130px" />
                                                                <f:BoundField DataField="Re_date" SortField="Re_date" HeaderText="結束日期" DataFormatString="{0:yyyy-MM-dd}" Width="130px" />
                                                                <f:BoundField DataField="DESCR" SortField="DESCR" HeaderText="類型" Width="150px" />
                                                                <f:TemplateField Width="100px" HeaderText="時段" TextAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Label2" runat="server" Text='<%# Solution.Logic.Managers.CommonBll.GetWorkType(Eval("work_type").ToString()) %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </f:TemplateField>
                                                                <f:BoundField DataField="work_days" SortField="work_days" HeaderText="天數" DataFormatString="{0:N2}" Width="50px" />
                                                                <f:LinkButtonField HeaderText="一級審批" Icon="BulletCross" TextAlign="Center" ColumnID="audit" />
                                                                <f:LinkButtonField HeaderText="二級審批" Icon="BulletCross" TextAlign="Center" ColumnID="audit2" />
                                                            </Columns>
                                                        </f:Grid>
                                                                <f:Grid ID="Grid2" Title="今日考勤異常人員" EnableFrame="false" EnableCollapse="true" AllowSorting="true" ShowBorder="true" ShowHeader="true" runat="server" 
                                                                    EnableCheckBoxSelect="false" DataKeyNames="ENo" EnableColumnLines="true" AllowPaging="false" SortField="Name" OnSort="Grid2_Sort" BoxFlex="2">
                                                                    <Columns>
                                                                        <f:BoundField DataField="ENo" SortField="ENo" HeaderText="編號" Width="70px" />
                                                                        <f:BoundField DataField="Name" SortField="Name" HeaderText="姓名" Width="250px" />
                                                                        <f:BoundField DataField="EName" SortField="EName" HeaderText="英文名" Width="100px" />
                                                                        <f:BoundField DataField="CTime" SortField="CTime" HeaderText="上班時間" Width="100px" Hidden="true"/>
                                                                        <f:BoundField DataField="Ms" SortField="Ms" HeaderText="異常" Width="130px" />
                                                                    </Columns>
                                                                </f:Grid>
                                                            </Items>
                                                </f:Panel>
                                            </Items>
                                        </f:Panel>
                                        <%-- <div style="background-color: #e5e5e5; width: 100%; margin: 10px; padding: 10px; font-size: large; border-left: 3px solid #D84A38;"><strong>調休申請單管理</strong> <span style="color: #666; font-size: medium">人事模塊，人員調休的申請和一二級審核</span></div>
                                            <div style="background-color: #e5e5e5; width: 100%; margin: 10px; padding: 10px; font-size: large; border-left: 3px solid #D84A38;"><strong>會議室使用管理</strong> <span style="color: #666; font-size: medium">Web模塊，對公司會議室使用時間的管理，查看和預約各會議室的時間</span></div>
                                            <div style="background-color: #e5e5e5; width: 100%; margin: 10px; padding: 10px; font-size: large; border-left: 3px solid #D84A38;"><strong>員工訂餐管理</strong> <span style="color: #666; font-size: medium">Web模塊，員工中餐選擇和預定，可查看菜單及預定當天以後的中餐</span></div>--%>
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
            //debugger;
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
