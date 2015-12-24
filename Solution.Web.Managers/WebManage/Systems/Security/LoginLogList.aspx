<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginLogList.aspx.cs" Inherits="Solution.Web.Managers.WebManage.Systems.Security.LoginLogList" %>

<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <title>登陸日誌列表</title>
</head>
<body>
    <form id="form1" runat="server">
    <f:pagemanager id="PageManager1" runat="server" />
    <f:panel id="Panel1" runat="server" title="登陸日誌列表" enableframe="false" bodypadding="10px"
        enablecollapse="True">
        <toolbars>
            <f:Toolbar ID="toolBar" runat="server">
                <Items>
                    <f:Button ID="ButtonRefresh" runat="server" Text="刷新" Icon="ArrowRefresh" OnClick="ButtonRefresh_Click" CssClass="inline"></f:Button>
                    <f:Button ID="ButtonSearch" runat="server" Text="查詢" Icon="Magnifier" OnClick="ButtonSearch_Click"></f:Button>
                </Items>
            </f:Toolbar>
        </toolbars>
        <items>
            <f:Form ID="Form6" ShowBorder="True" BodyPadding="5px" ShowHeader="False" runat="server">
                <Rows>
                    <f:FormRow ID="FormRow1" runat="server">
                        <Items>
                            <f:DatePicker runat="server" Label="起始日期" ID="dpStart" DateFormatString="yyyy-M-d H:i:s" Width="260px" />
                            <f:DatePicker runat="server" Label="終止日期" ID="dpEnd" DateFormatString="yyyy-M-d H:i:s" Width="260px" />
                        </Items>
                    </f:FormRow>
                    <f:FormRow ID="FormRow2" runat="server">
                        <Items>
                            <f:TextBox Label="IP地址" ID="txtIp" runat="server" Width="260px" />
                            <f:TextBox Label="日誌信息" ID="txtloginfo" runat="server" Width="260px" />
                        </Items>
                    </f:FormRow>
                </Rows>
            </f:Form>
            <f:Grid ID="Grid1" EnableFrame="false" EnableCollapse="true" AllowSorting="true" IsDatabasePaging="True" Height="420px"
            PageSize="15" ShowBorder="true" ShowHeader="False" AllowPaging="true" runat="server" DataKeyNames="Id" EnableColumnLines="true"
            OnPageIndexChange="Grid1_PageIndexChange" OnSort="Grid1_Sort">
                <Columns>
                    <f:RowNumberField Width="30px" />
                    <f:BoundField DataField="AddDate" SortField="AddDate" DataFormatString="{0:yyyy-MM-dd HH:mm}"
                        Width="160px" HeaderText="登錄時間" />
                    <f:BoundField Width="100px" DataField="Manager_CName" SortField="Manager_Id" HeaderText="用戶名稱" />
                    <f:BoundField Width="120px" DataField="Ip" SortField="Ip" HeaderText="登錄IP" />
                    <f:BoundField Width="250px" DataField="Notes" HeaderText="備註" ExpandUnusedSpace="true" />
                </Columns>
            </f:Grid>
            <f:Label runat="server" ID="lblSpendingTime" Text=""></f:Label>
            <f:HiddenField runat="server" ID="SortColumn" Text="Id"></f:HiddenField>
        </items>
    </f:panel>
    </form>
</body>
</html>
