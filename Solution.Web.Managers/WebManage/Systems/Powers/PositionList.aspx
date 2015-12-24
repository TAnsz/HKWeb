<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PositionList.aspx.cs" Inherits="Solution.Web.Managers.WebManage.Systems.Powers.PositionList" %>

<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <title>角色管理</title>
</head>
<body>
    <form id="form1" runat="server">
    <f:PageManager ID="PageManager1" runat="server" />
    <f:Panel ID="Panel1" runat="server" Width="870px" ShowBorder="True" EnableFrame="false"
        EnableCollapse="true" BodyPadding="5px" Layout="Column" ShowHeader="True" Title="角色管理">
        <Items>
            <%--<f:Panel ID="Panel5" Width="250px" runat="server" BodyPadding="5px" ShowBorder="False"
                ShowHeader="false">
                <Items>
                    <f:Tree runat="server" Title="部門列表" ShowBorder="True" ShowHeader="True" EnableArrows="False"
                        AutoLeafIdentification="false" EnableLines="true" ID="BranchTree" OnNodeCommand="BranchTree_NodeCommand">
                    </f:Tree>
                </Items>
            </f:Panel>--%>
            <f:Panel ID="Panel4" Title="角色權限說明" Width="600px" runat="server" BodyPadding="10px"
                ShowBorder="False" ShowHeader="True">
                <Items>
                    <f:Label ID="labelClassDesc" runat="server" Text="角色權限管理，是將員工和菜單、頁面控件等權限捆綁到一塊進行綜合管理，
                以保護系統的安全。在設置菜單、頁面訪問操作權限時，要基於這樣一個原則，使用戶操作界面裡顯示最少的菜單項，
                用戶不應該有的或可有可沒有的項就不要給用戶開這個權限，讓界面簡單、明瞭、易用。">
                    </f:Label>
                </Items>
            </f:Panel>
            <f:Panel ID="Panel2" Width="600px" Title="角色權限管理" runat="server" BodyPadding="10px"
                ShowBorder="False" ShowHeader="True">
                <Toolbars>
                    <f:Toolbar ID="toolBar" runat="server">
                        <Items>
                            <f:Button ID="ButtonAdd" runat="server" Text="添加" Icon="Add" OnClick="ButtonAdd_Click">
                            </f:Button>
                            <f:Button ID="ButtonDelete" runat="server" Text="刪除" Icon="Delete" OnClick="ButtonDelete_Click"
                                ConfirmTitle="刪除提示" ConfirmText="是否刪除記錄？" OnClientClick="if (!F('Panel1_Panel2_Grid1').getSelectionModel().hasSelection() ) { F.alert('請選擇你想要刪除的記錄！'); return false; } ">
                            </f:Button>
                        </Items>
                    </f:Toolbar>
                </Toolbars>
                <Items>
                    <f:Grid ID="Grid1" EnableFrame="false" EnableCollapse="true" PageSize="15" ShowBorder="true"
                        ShowHeader="False" runat="server" EnableCheckBoxSelect="True"
                        DataKeyNames="Id" EnableColumnLines="true" OnPageIndexChange="Grid1_PageIndexChange"
                        OnPreRowDataBound="Grid1_PreRowDataBound" OnRowCommand="Grid1_RowCommand">
                        <Columns>
                            <f:BoundField Width="50px" DataField="Id" SortField="Id" HeaderText="ID" TextAlign="Center" />
                            <f:BoundField DataField="CODE" HeaderText="角色編號" Width="150px" />
                            <f:BoundField DataField="DESCR" HeaderText="角色名稱" Width="200px" />
                            <f:LinkButtonField HeaderText="操作" TextAlign="Center" ToolTip="點擊修改當前記錄" ColumnID="ButtonEdit"
                                CommandName="ButtonEdit" Width="70px" />
                        </Columns>
                    </f:Grid>
                </Items>
            </f:Panel>
        </Items>
    </f:Panel>
    <f:Window ID="Window1" Width="450px" Height="550px" Icon="TagBlue" Title="編輯" Hidden="True"
        EnableMaximize="True" CloseAction="HidePostBack" OnClose="Window1_Close" EnableCollapse="true"
        runat="server" EnableResize="true" BodyPadding="5px" EnableFrame="True" IFrameUrl="about:blank"
        EnableIFrame="true" EnableClose="true" IsModal="True" >
    </f:Window>
    </form>
</body>
</html>
