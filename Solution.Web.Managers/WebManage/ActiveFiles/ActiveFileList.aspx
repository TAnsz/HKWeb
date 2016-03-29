<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ActiveFileList.aspx.cs" Inherits="Solution.Web.Managers.WebManage.ActiveFiles.ActiveFileList" %>
<%@ Import Namespace="DotNet.Utilities" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>文件列表</title>
</head>
<body>
    <form id="form1" runat="server">
    <f:pagemanager id="PageManager1" runat="server" />
    <f:panel id="Panel1" runat="server" title="文件列表" enableframe="false" bodypadding="10px"
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
                            <f:TextBox runat="server" ID="txtName" Label="文件名稱" Width="260px" Text="" MaxLength="20"  />
                            <%--<f:TextBox runat="server" ID="txtKeyword" Label="Key" Width="260px" Text="" MaxLength="20"  />--%>
                            <f:DropDownList CompareType="String" Label="文件位置" EnableSimulateTree="true" runat="server" ID="dllActiveFileClass" Width="260px" />
                            <f:Label runat="server"></f:Label>
                        </Items>
                    </f:FormRow>
                    <f:FormRow ID="FormRow3" runat="server">
                        <Items>
                            <f:DatePicker runat="server" Label="查詢日期" ID="dpStart" DateFormatString="yyyy-M-d HH:mm:ss" Width="260px" EmptyText="查詢指定日期" />
                            <f:DropDownList CompareType="String" Label="顯示狀態"
                                runat="server" ID="ddlIsDisplay" Width="260px" >
                                <f:ListItem Text="==全部==" Value="" />
                                <f:ListItem Text="顯示" Value="1" />
                                <f:ListItem Text="不顯示" Value="0" />
                            </f:DropDownList>
                            <f:Label runat="server"></f:Label>
                        </Items>
                    </f:FormRow>
                </Rows>
            </f:Form>
            <f:Grid ID="Grid1" Title="文件列表" EnableFrame="false" EnableCollapse="true" AllowSorting="true" IsDatabasePaging="True" Height="420px" AllowPaging="True"
            PageSize="15" ShowBorder="true" ShowHeader="False" runat="server" EnableCheckBoxSelect="True" DataKeyNames="Id" EnableColumnLines="true"
            OnPageIndexChange="Grid1_PageIndexChange" OnPreRowDataBound="Grid1_PreRowDataBound" OnRowCommand="Grid1_RowCommand" OnSort="Grid1_Sort">
                <Columns>
                    <f:TemplateField RenderAsRowExpander="true">
                        <ItemTemplate>
                            <div class="expander">
                                <table width="800px">
                                    <tr>
                                        <td style="width: 200px;padding-top: 10px;">
                                            <strong>修改人員：</strong><%# Eval("Employee_CName")%>
                                        </td>
                                        <td style="padding-top: 10px;">
                                            <strong>修改時間：</strong><%# Eval("UpdateDate")%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" style="padding-top: 10px;">
                                            <strong>鏈接URL：</strong><a href="<%# Eval("Url")%>" target="_blank"><%# Eval("Url")%></a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" style="padding-top: 10px;">
                                            <strong>備註：</strong><%# Eval("Content")%>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </ItemTemplate>
                    </f:TemplateField>
                    <f:BoundField DataField="Id" SortField="Id" HeaderText="Id" Width="50px" Hidden="True"/>
                    <f:BoundField DataField="Name" SortField="[Name]" HeaderText="文件標題" Width="150px" />
                    <f:BoundField DataField="ActiveFileClass_Name" SortField="ActiveFileClass_Id" HeaderText="文件類別" Width="150px" />
                    <f:BoundField DataField="Keyword" SortField="Keyword" HeaderText="文件Key" Width="100px" Hidden="True"/>
                    <f:BoundField DataField="DownloadCount" SortField="DownloadCount" HeaderText="下載數" Width="60px" Hidden="true"/>
                    <f:LinkButtonField ColumnID="IsDisplay" SortField="IsDisplay" HeaderText="顯示" TextAlign="Center" CommandName="IsDisplay" Width="40px"  Hidden="True"/>
                    <f:HyperLinkField HeaderText="下載" Text="點擊下載" DataNavigateUrlFields="Url" DataNavigateUrlFormatString="../../{0}" TextAlign="Center" UrlEncode="False" ToolTip="點擊下載當前文件"  runat="server"/>
<%--                    <f:LinkButtonField Width="100px" HeaderText="下載" TextAlign="Center" ToolTip="點擊下載當前文件" ColumnID="ButtonDownload" CommandName="ButtonDownload" />--%>
                    <f:LinkButtonField Width="100px" HeaderText="操作" TextAlign="Center" ToolTip="點擊修改當前記錄" ColumnID="ButtonEdit" CommandName="ButtonEdit" />
                </Columns>
            </f:Grid>
            <f:Label runat="server" ID="lblSpendingTime" Text=""></f:Label>
            <f:HiddenField runat="server" ID="SortColumn" Text="Id"></f:HiddenField>
        </items>
    </f:panel>
    <f:window id="Window1" width="680px" height="350px" icon="TagBlue" title="編輯" hidden="True"
        enablemaximize="True" closeaction="HidePostBack" onclose="Window1_Close" enablecollapse="true"
        runat="server" enableresize="true" bodypadding="5px" enableframe="True" iframeurl="about:blank"
        enableiframe="true" enableclose="true" ismodal="True" >
    </f:window>
    </form>
</body>
</html>
