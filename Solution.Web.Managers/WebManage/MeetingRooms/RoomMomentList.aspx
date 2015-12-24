<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoomMomentCal.aspx.cs" Inherits="Solution.Web.Managers.WebManage.MeetingRooms.RoomMomentCal" %>

<%@ Import Namespace="DotNet.Utilities" %>

<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <title>會議室使用列表</title>
    <link href="../Css/common.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server" AutoSizePanelID="Panel1"/>
        <f:Panel ID="Panel1" runat="server" Title="會議室已休列表" EnableFrame="false" BodyPadding="10px" 
            EnableCollapse="True">
            <Toolbars>
                <f:Toolbar ID="toolBar" runat="server">
                    <Items>
                        <f:Button ID="ButtonRefresh" runat="server" Text="刷新" Icon="ArrowRefresh" OnClick="ButtonRefresh_Click" CssClass="inline"></f:Button>
                        <f:Button ID="ButtonSearch" runat="server" Text="查詢" Icon="Magnifier" OnClick="ButtonSearch_Click"></f:Button>
                        <f:Button ID="ButtonAdd" runat="server" Text="添加" Icon="Add" OnClick="ButtonAdd_Click"></f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Items>
                <f:SimpleForm ID="SimpleForm1" BodyPadding="5px" runat="server" EnableFrame="false" EnableCollapse="true"
                    ShowBorder="True" ShowHeader="False">
                    <Items>
                        <f:DatePicker runat="server" Label="查詢日期" ID="dpStart" DateFormatString="yyyy-MM-dd" Width="260px" EmptyText="查詢指定日期記錄" />
                    </Items>
                </f:SimpleForm>
                <f:Grid ID="Grid1" Title="會議室申請" EnableFrame="false" EnableCollapse="true" AllowSorting="true" IsDatabasePaging="True" Height="420px" SortField="Id" SortDirection="DESC"
                    PageSize="15" ShowBorder="true" ShowHeader="False" AllowPaging="true" runat="server" EnableCheckBoxSelect="false" DataKeyNames="Id" EnableColumnLines="true"
                    OnPageIndexChange="Grid1_PageIndexChange" OnPreRowDataBound="Grid1_PreRowDataBound" OnRowCommand="Grid1_RowCommand" OnSort="Grid1_Sort">
                    <Columns>
                        <f:RowNumberField />
                        <f:BoundField DataField="Id" HeaderText="ID" Width="50px" Hidden="true" />
                        <f:BoundField DataField="RoomDate" SortField="RoomDate" HeaderText="日期" DataFormatString="{0:yyyy-MM-dd}" Width="100px" />
                        <f:BoundField DataField="MeetingRoom_Name" SortField="MeetingRoom_Name" HeaderText="會議室" Width="100px" />
                        <f:LinkButtonField Width="60px" runat="server" HeaderText="08:00" Icon="BulletCross" TextAlign="Center" ToolTip="點擊申請會議室" ID="T0800" CommandName="T0800" />
                        <f:LinkButtonField Width="60px" runat="server" HeaderText="08:30" Icon="BulletCross" TextAlign="Center" ToolTip="點擊申請會議室" ID="T0830" CommandName="T0830" />
                        <f:LinkButtonField Width="60px" runat="server" HeaderText="09:00" Icon="BulletCross" TextAlign="Center" ToolTip="點擊申請會議室" ID="T0900" CommandName="T0900" />
                        <f:LinkButtonField Width="60px" runat="server" HeaderText="09:30" Icon="BulletCross" TextAlign="Center" ToolTip="點擊申請會議室" ID="T0930" CommandName="T0930" />
                        <f:LinkButtonField Width="60px" runat="server" HeaderText="10:00" Icon="BulletCross" TextAlign="Center" ToolTip="點擊申請會議室" ID="T1000" CommandName="T1000" />
                        <f:LinkButtonField Width="60px" runat="server" HeaderText="10:30" Icon="BulletCross" TextAlign="Center" ToolTip="點擊申請會議室" ID="T1030" CommandName="T1030" />
                        <f:LinkButtonField Width="60px" runat="server" HeaderText="11:00" Icon="BulletCross" TextAlign="Center" ToolTip="點擊申請會議室" ID="T1100" CommandName="T1100" />
                        <f:LinkButtonField Width="60px" runat="server" HeaderText="11:30" Icon="BulletCross" TextAlign="Center" ToolTip="點擊申請會議室" ID="T1130" CommandName="T1130" />
                        <f:LinkButtonField Width="60px" runat="server" HeaderText="12:00" Icon="BulletCross" TextAlign="Center" ToolTip="點擊申請會議室" ID="T1200" CommandName="T1200" />
                        <f:LinkButtonField Width="60px" runat="server" HeaderText="12:30" Icon="BulletCross" TextAlign="Center" ToolTip="點擊申請會議室" ID="T1230" CommandName="T1230" />
                        <f:LinkButtonField Width="60px" runat="server" HeaderText="13:00" Icon="BulletCross" TextAlign="Center" ToolTip="點擊申請會議室" ID="T1300" CommandName="T1300" />
                        <f:LinkButtonField Width="60px" runat="server" HeaderText="13:30" Icon="BulletCross" TextAlign="Center" ToolTip="點擊申請會議室" ID="T1330" CommandName="T1330" />
                        <f:LinkButtonField Width="60px" runat="server" HeaderText="14:00" Icon="BulletCross" TextAlign="Center" ToolTip="點擊申請會議室" ID="T1400" CommandName="T1400" />
                        <f:LinkButtonField Width="60px" runat="server" HeaderText="14:30" Icon="BulletCross" TextAlign="Center" ToolTip="點擊申請會議室" ID="T1430" CommandName="T1430" />
                        <f:LinkButtonField Width="60px" runat="server" HeaderText="15:00" Icon="BulletCross" TextAlign="Center" ToolTip="點擊申請會議室" ID="T1500" CommandName="T1500" />
                        <f:LinkButtonField Width="60px" runat="server" HeaderText="15:30" Icon="BulletCross" TextAlign="Center" ToolTip="點擊申請會議室" ID="T1530" CommandName="T1530" />
                        <f:LinkButtonField Width="60px" runat="server" HeaderText="16:00" Icon="BulletCross" TextAlign="Center" ToolTip="點擊申請會議室" ID="T1600" CommandName="T1600" />
                        <f:LinkButtonField Width="60px" runat="server" HeaderText="16:30" Icon="BulletCross" TextAlign="Center" ToolTip="點擊申請會議室" ID="T1630" CommandName="T1630" />
                        <f:LinkButtonField Width="60px" runat="server" HeaderText="17:00" Icon="BulletCross" TextAlign="Center" ToolTip="點擊申請會議室" ID="T1700" CommandName="T1700" />
                        <f:LinkButtonField Width="60px" runat="server" HeaderText="17:30" Icon="BulletCross" TextAlign="Center" ToolTip="點擊申請會議室" ID="T1730" CommandName="T1730" />
                        <f:LinkButtonField Width="60px" runat="server" HeaderText="18:00" Icon="BulletCross" TextAlign="Center" ToolTip="點擊申請會議室" ID="T1800" CommandName="T1800" />
                        <f:LinkButtonField Width="60px" runat="server" HeaderText="18:30" Icon="BulletCross" TextAlign="Center" ToolTip="點擊申請會議室" ID="T1830" CommandName="T1830" />
                        <f:LinkButtonField Width="60px" runat="server" HeaderText="19:00" Icon="BulletCross" TextAlign="Center" ToolTip="點擊申請會議室" ID="T1900" CommandName="T1900" />
                        <f:LinkButtonField Width="60px" runat="server" HeaderText="19:30" Icon="BulletCross" TextAlign="Center" ToolTip="點擊申請會議室" ID="T1930" CommandName="T1930" Hidden="true"/>
                        <f:LinkButtonField Width="60px" runat="server" HeaderText="20:00" Icon="BulletCross" TextAlign="Center" ToolTip="點擊申請會議室" ID="T2000" CommandName="T2000" Hidden="true"/>
                        <f:LinkButtonField Width="60px" runat="server" HeaderText="20:30" Icon="BulletCross" TextAlign="Center" ToolTip="點擊申請會議室" ID="T2030" CommandName="T2030" Hidden="true"/>
                        <f:LinkButtonField Width="60px" runat="server" HeaderText="21:00" Icon="BulletCross" TextAlign="Center" ToolTip="點擊申請會議室" ID="T2100" CommandName="T2100" Hidden="true"/>
                        <f:LinkButtonField Width="60px" runat="server" HeaderText="21:30" Icon="BulletCross" TextAlign="Center" ToolTip="點擊申請會議室" ID="T2130" CommandName="T2130" Hidden="true"/>
                    </Columns>
                </f:Grid>
                <f:Label runat="server" ID="lblSpendingTime" Text=""></f:Label>
            </Items>
        </f:Panel>
        <f:Window ID="Window1" Width="520px" Height="500px" Icon="TagBlue" Title="編輯" Hidden="True"
            EnableMaximize="True" CloseAction="HidePostBack" OnClose="Window1_Close" EnableCollapse="true"
            runat="server" EnableResize="true" BodyPadding="5px" EnableFrame="True" IFrameUrl="about:blank"
            EnableIFrame="true" EnableClose="true" IsModal="True" >
        </f:Window>
    </form>
</body>
</html>
