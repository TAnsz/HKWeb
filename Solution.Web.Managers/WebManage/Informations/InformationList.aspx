<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InformationList.aspx.cs" Inherits="Solution.Web.Managers.WebManage.Informations.InformationList" %>
<%@ Import Namespace="DotNet.Utilities" %>

<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <title>信息列表</title>
</head>
<body>
    <form id="form1" runat="server">
    <f:pagemanager id="PageManager1" runat="server" />
    <f:panel id="Panel1" runat="server" title="信息列表" enableframe="false" bodypadding="10px"
        enablecollapse="True">
        <toolbars>
            <f:Toolbar ID="toolBar" runat="server">
                <Items>
                    <f:Button ID="ButtonRefresh" runat="server" Text="刷新" Icon="ArrowRefresh" OnClick="ButtonRefresh_Click" CssClass="inline"></f:Button>
                    <f:Button ID="ButtonSearch" runat="server" Text="查詢" Icon="Magnifier" OnClick="ButtonSearch_Click"></f:Button>
                    <f:Button ID="ButtonAdd" runat="server" Text="添加" Icon="Add" OnClick="ButtonAdd_Click"></f:Button>
                    <f:Button ID="ButtonSaveAutoSort" runat="server" Text="自動排序" Icon="ArrowJoin" OnClick="ButtonSaveAutoSort_Click" ConfirmTitle="自動排序提示" ConfirmText="是否對所有數據進行自動排序？"></f:Button>
                    <f:Button ID="ButtonSaveSort" runat="server" Text="保存排序" Icon="Disk" OnClick="ButtonSaveSort_Click"></f:Button>
                    
                    <f:Button ID="ButtonDelete" runat="server" Text="刪除" Icon="Delete" OnClick="ButtonDelete_Click" ConfirmTitle="刪除提示" ConfirmText="是否刪除記錄？" 
                        OnClientClick="if (!F('Panel1_Grid1').getSelectionModel().hasSelection() ) { F.alert('請選擇你想要刪除的記錄！'); return false; } ">
                    </f:Button>
                </Items>
            </f:Toolbar>
        </toolbars>
        <items>
            <f:Form ID="Form6" ShowBorder="True" BodyPadding="5px" ShowHeader="False" runat="server">
                <Rows>
                    <f:FormRow ID="FormRow1" runat="server">
                        <Items>
                            <f:TextBox runat="server" ID="txtKey" Label="標題或Key" Width="260px" Text="" MaxLength="20"  />
                            <f:DropDownList CompareType="String" Label="所屬欄目" EnableSimulateTree="true" runat="server" ID="dllInformationClass" Width="260px" />
                            </Items>
                    </f:FormRow>
                    <f:FormRow ID="FormRow3" runat="server">
                        <Items>
                            <f:DropDownList CompareType="String" Label="顯示狀態"
                                runat="server" ID="ddlIsDisplay" Width="260px" >
                                <f:ListItem Text="==全部==" Value="" />
                                <f:ListItem Text="顯示" Value="1" />
                                <f:ListItem Text="未顯示" Value="0" />
                            </f:DropDownList>
                            <f:DropDownList CompareType="String" Label="推薦狀態"
                                runat="server" ID="ddlIsHot" Width="260px" >
                                <f:ListItem Text="==全部==" Value="" />
                                <f:ListItem Text="已推薦" Value="1" />
                                <f:ListItem Text="未推薦" Value="0" />
                            </f:DropDownList>
                        </Items>
                    </f:FormRow>
                    <f:FormRow ID="FormRow2" runat="server">
                        <Items>
                            <f:DatePicker runat="server" Label="起始日期" ID="dpStart" DateFormatString="yyyy-M-d" Width="260px" />
                            <f:DatePicker runat="server" Label="終止日期" ID="dpEnd" DateFormatString="yyyy-M-d" Width="260px" />
                        </Items>
                    </f:FormRow>
                </Rows>
            </f:Form>
            <f:Grid ID="Grid1" Title="信息列表" EnableFrame="false" EnableCollapse="true" AllowSorting="true" IsDatabasePaging="True" Height="420px"
            PageSize="15" ShowBorder="true" ShowHeader="False" AllowPaging="true" runat="server" EnableCheckBoxSelect="True" DataKeyNames="Id" EnableColumnLines="true"
            OnPageIndexChange="Grid1_PageIndexChange" OnPreRowDataBound="Grid1_PreRowDataBound" OnRowCommand="Grid1_RowCommand" OnSort="Grid1_Sort">
                <Columns>
                    <f:BoundField DataField="Id" SortField="Id" HeaderText="ID" Width="50px" />
                    <f:BoundField DataField="InformationClass_Name" SortField="InformationClass_Id"  HeaderText="分類" Width="100px" />
                    <f:BoundField DataField="Title" SortField="Title" HeaderText="文章標題" Width="250px" />
                    <f:BoundField DataField="ViewCount" SortField="ViewCount" HeaderText="瀏覽數" Width="60px" />
                    <f:TemplateField HeaderText="排序" Width="100px">
                        <ItemTemplate>
                            <asp:TextBox ID="tbSort" runat="server" Width="50px" Text='<%# Eval("Sort") %>' AutoPostBack="false"></asp:TextBox>
                        </ItemTemplate>
                    </f:TemplateField>
                    <f:LinkButtonField ColumnID="IsDisplay" SortField="IsDisplay" HeaderText="顯示" TextAlign="Center" CommandName="IsDisplay" Width="50px"  />
                    <f:LinkButtonField ColumnID="IsTop" SortField="IsTop" HeaderText="置頂" TextAlign="Center" CommandName="IsTop" Width="50px"  />
                    <f:BoundField DataField="UpdateDate" SortField="UpdateDate" HeaderText="更新時間" TextAlign="left" Width="150px" />
                    <f:BoundField DataField="Manager_CName" SortField="Manager_CName" HeaderText="更新人" TextAlign="left" Width="180px" />
                    <f:LinkButtonField Width="60px" HeaderText="操作" TextAlign="Center" ToolTip="點擊修改當前記錄" ColumnID="ButtonEdit" CommandName="ButtonEdit" />
                </Columns>
            </f:Grid>
            <f:Label runat="server" ID="lblSpendingTime" Text=""></f:Label>
            <f:HiddenField runat="server" ID="SortColumn" Text="Id"></f:HiddenField>
        </items>
    </f:panel>
    <f:window id="Window1" width="800px" height="620px" icon="TagBlue" title="編輯" hidden="True"
        enablemaximize="True" closeaction="HidePostBack" onclose="Window1_Close" enablecollapse="true"
        runat="server" enableresize="true" bodypadding="5px" enableframe="True" iframeurl="about:blank"
        enableiframe="true" enableclose="true" ismodal="True" >
    </f:window>
    </form>
</body>
</html>
