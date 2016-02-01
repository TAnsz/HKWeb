<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MeetingRoomList.aspx.cs" Inherits="Solution.Web.Managers.WebManage.MeetingRooms.MeetingRoomList" %>

<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <title>會議室列表</title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server" AutoSizePanelID="Panel1"/>
        <f:Panel ID="Panel1" runat="server" Title="菜單(頁面)列表" EnableFrame="false" BodyPadding="10px"
            EnableCollapse="True" AutoScroll="true">
            <Toolbars>
                <f:Toolbar ID="toolBar" runat="server">
                    <Items>
                        <f:Button ID="ButtonRefresh" runat="server" Text="刷新" Icon="ArrowRefresh" OnClick="ButtonRefresh_Click" CssClass="inline"></f:Button>
                        <f:Button ID="ButtonSearch" runat="server" Text="查詢" Icon="Magnifier" OnClick="ButtonSearch_Click"></f:Button>
                        <f:Button ID="ButtonAdd" runat="server" Text="添加" Icon="Add" OnClick="ButtonAdd_Click"></f:Button>
                        <f:Button ID="ButtonEdit" runat="server" Text="編輯" Icon="BulletEdit" OnClick="ButtonEdit_Click"
                            OnClientClick="if(!F('Panel1_Grid1').getSelectionModel().hasSelection()|| F('Panel1_Grid1').getSelectionModel().getCount()>=2){F.alert('您沒有選擇編輯項或只能選擇一項進行編輯！'); return false; }">
                        </f:Button>
                        <f:Button ID="ButtonDelete" runat="server" Text="刪除" Icon="Delete" OnClick="ButtonDelete_Click" ConfirmTitle="刪除提示" ConfirmText="是否刪除記錄？"
                            OnClientClick="if (!F('Panel1_Grid1').getSelectionModel().hasSelection() ) { F.alert('刪除時必須選擇一條將要刪除的記錄！'); return false; }  if (F('Panel1_Grid1').getSelectionModel().getCount() >= 2) { F.alert('只能選擇一條記錄進行刪除！');return false; }">
                        </f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Items>
                <f:Grid ID="Grid1" Title="會議室列表" EnableFrame="false" EnableCollapse="true" AllowSorting="true" SortField="Id" SortDirection="DESC"
                    PageSize="15" ShowBorder="true" ShowHeader="False" runat="server" EnableCheckBoxSelect="True" DataKeyNames="Id" EnableColumnLines="true"
                    OnPageIndexChange="Grid1_PageIndexChange" OnPreRowDataBound="Grid1_PreRowDataBound" OnRowCommand="Grid1_RowCommand">
                    <Columns>
                        <f:RowNumberField />
                        <f:BoundField DataField="Id" HeaderText="ID" Hidden="True" />
                        <f:BoundField Width="75px" DataField="Code" HeaderText="編號" />
                        <f:BoundField Width="100px" DataField="Name" HeaderText="名稱" />
                        <f:BoundField DataField="Qty" HeaderText="可容納人數" />
                        <f:BoundField Width="150px" DataField="Address" HeaderText="地址" />
                        <f:BoundField Width="200px" DataField="Remark" HeaderText="備註" />
                        <f:LinkButtonField HeaderText="是否有效" Icon="BulletCross" TextAlign="Center" ToolTip="點擊修改是否有效" ColumnID="isVaild" CommandName="isVaild" />
                        <f:LinkButtonField HeaderText="操作" TextAlign="Center" ToolTip="點擊修改當前記錄" ColumnID="ButtonEdit" CommandName="ButtonEdit" />
                    </Columns>
                </f:Grid>
                <f:Label runat="server" ID="lblSpendingTime" Text=""></f:Label>
            </Items>
        </f:Panel>
        <f:Window ID="Window1" Width="480px" Height="360px" Icon="TagBlue" Title="編輯" Hidden="True"
            EnableMaximize="True" CloseAction="HidePostBack" OnClose="Window1_Close" EnableCollapse="true"
            runat="server" EnableResize="true" BodyPadding="5px" EnableFrame="True" IFrameUrl="about:blank"
            EnableIFrame="true" EnableClose="true" IsModal="True" >
        </f:Window>
    </form>
</body>
</html>
