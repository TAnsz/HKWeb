<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OutWorkRecordList.aspx.cs" Inherits="Solution.Web.Managers.WebManage.OutWorks.OutWorkRecordList" %>

<%@ Import Namespace="DotNet.Utilities" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>請假出差列表</title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server" AutoSizePanelID="Panel1" />
        <f:Panel ID="Panel1" runat="server" Title="請假出差列表" EnableFrame="false" BodyPadding="10px"
            EnableCollapse="True">
            <Toolbars>
                <f:Toolbar ID="toolBar" runat="server">
                    <Items>
                        <f:Button ID="ButtonRefresh" runat="server" Text="刷新" Icon="ArrowRefresh" OnClick="ButtonRefresh_Click" CssClass="inline"></f:Button>
                        <f:Button ID="ButtonSearch" runat="server" Text="查詢" Icon="Magnifier" OnClick="ButtonSearch_Click"></f:Button>
                        <f:Button ID="ButtonAdd" runat="server" Text="添加" Icon="Add" OnClick="ButtonAdd_Click"></f:Button>
                        <f:Button ID="ButtonDelete" runat="server" Text="刪除" Icon="Delete" OnClick="ButtonDelete_Click" ConfirmTitle="刪除提示" ConfirmText="是否刪除記錄？"
                            OnClientClick="if (!F('Panel1_Grid1').getSelectionModel().hasSelection() ) { F.alert('請選擇你想要刪除的記錄！'); return false; } ">
                        </f:Button>
                        <f:Button ID="ButtonAccept" runat="server" Text="一級審批" Icon="Accept" OnClick="ButtonAccept_Click" ConfirmTitle="審批提示" ConfirmText="是否一級審批選中記錄？"
                            OnClientClick="if (!F('Panel1_Grid1').getSelectionModel().hasSelection() ) { F.alert('請選擇你想要審批的記錄！'); return false; } ">
                        </f:Button>
                        <f:Button ID="ButtonAccept2" runat="server" Text="二級審批" Icon="Accept" OnClick="ButtonAccept2_Click" ConfirmTitle="審批提示" ConfirmText="是否二級審批選中記錄？"
                            OnClientClick="if (!F('Panel1_Grid1').getSelectionModel().hasSelection() ) { F.alert('請選擇你想要審批的記錄！'); return false; } ">
                        </f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Items>
                <f:Form ID="Form6" ShowBorder="True" BodyPadding="5px" ShowHeader="False" runat="server">
                    <Rows>
                        <f:FormRow ID="FormRow1" runat="server">
                            <Items>
                                <f:TextBox runat="server" ID="txtName" Label="員工編號" Width="260px" Text="" />
                                <f:DropDownList CompareType="String" Label="類型" runat="server" ID="ddlOutWorkRecord" Width="260px">
                                    <f:ListItem Text="==全部==" Value="" />
                                    <f:ListItem Text="請假申請單" Value="leav" />
                                    <f:ListItem Text="出差申請單" Value="tral" />
                                </f:DropDownList>
                                <f:Label runat="server"></f:Label>
                            </Items>
                        </f:FormRow>
                        <f:FormRow ID="FormRow2" runat="server">
                            <Items>
                                <f:DatePicker runat="server" Label="查詢日期" ID="dpStart" DateFormatString="yyyy-MM-dd" Width="260px" EmptyText="查詢指定日期後記錄" />
                                <f:DropDownList CompareType="String" Label="審批狀態"
                                    runat="server" ID="ddlIsDisplay" Width="260px">
                                    <f:ListItem Text="==全部==" Value="" />
                                    <f:ListItem Text="已審批" Value="1" />
                                    <f:ListItem Text="未審批" Value="0" />
                                </f:DropDownList>
                                <f:Label runat="server"></f:Label>
                            </Items>
                        </f:FormRow>
                    </Rows>
                </f:Form>
                <f:Grid ID="Grid1" Title="請假出差列表" EnableFrame="false" EnableCollapse="true" AllowSorting="true" IsDatabasePaging="True" AllowPaging="True"
                    PageSize="20" ShowBorder="true" ShowHeader="False" runat="server" EnableCheckBoxSelect="True" DataKeyNames="Id" EnableColumnLines="true"
                    OnPageIndexChange="Grid1_PageIndexChange" OnPreRowDataBound="Grid1_PreRowDataBound" OnRowCommand="Grid1_RowCommand">
                    <Columns>
                        <f:TemplateField RenderAsRowExpander="true">
                            <ItemTemplate>
                                <div class="expander">
                                    <table width="1100px" style="padding-left: 50px;">
                                        <tr>
                                            <td style="width: 600px; padding-top: 10px;">
                                                <strong>修改人員：</strong><%# Eval(Solution.DataAccess.DataModel.OutWork_DTable.op_user)%>
                                            </td>
                                            <td style="width: 400px; padding-top: 10px;">
                                                <strong>修改時間：</strong><%# Eval(Solution.DataAccess.DataModel.OutWork_DTable.op_date,"{0:yyyy-MM-dd}")%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 600px; padding-top: 5px;">
                                                <strong>一級審批人員：</strong><%# Solution.Logic.Managers.EmployeeBll.GetInstence().GetEmpName(
                                                                        Eval(Solution.DataAccess.DataModel.OutWork_DTable.checker))%>
                                            </td>
                                            <td style="width: 400px; padding-top: 5px;">
                                                <strong>一級審批時間：</strong><%# Eval(Solution.DataAccess.DataModel.OutWork_DTable.check_date,"{0:yyyy-MM-dd}")%>
                                            </td>
                                            <td style="width: 600px; padding-top: 5px;">
                                                <strong>二級審批人員：</strong><%# Solution.Logic.Managers.EmployeeBll.GetInstence().GetEmpName(
                                                                        Eval(Solution.DataAccess.DataModel.OutWork_DTable.CHECKER2))%>
                                            </td>
                                            <td style="width: 400px; padding-top: 5px;">
                                                <strong>二級審批時間：</strong><%# Eval(Solution.DataAccess.DataModel.OutWork_DTable.check_date2,"{0:yyyy-MM-dd}")%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3" style="padding-top: 10px;">
                                                <strong>原因：</strong><%# Eval("memo")%>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </ItemTemplate>
                        </f:TemplateField>
                        <f:BoundField DataField="emp_id" SortField="emp_id" HeaderText="員工編號" Width="100px" />
                        <f:TemplateField Width="200px" HeaderText="姓名" TextAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Solution.Logic.Managers.EmployeeBll.GetInstence().GetEmpName(Eval("emp_id")) %>'></asp:Label>
                            </ItemTemplate>
                        </f:TemplateField>
                        <f:BoundField DataField="bill_date" SortField="bill_date" HeaderText="開始日期" DataFormatString="{0:yyyy-MM-dd}" Width="130px" />
                        <f:BoundField DataField="Re_date" SortField="Re_date" HeaderText="返程日期" DataFormatString="{0:yyyy-MM-dd}" Width="130px" />
                        <f:BoundField DataField="work_days" SortField="work_days" HeaderText="天數" DataFormatString="{0:N2}" Width="50px" />
                        <f:TemplateField Width="100px" HeaderText="時段" TextAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Solution.Logic.Managers.CommonBll.GetWorkType(Eval("work_type").ToString()) %>'></asp:Label>
                            </ItemTemplate>
                        </f:TemplateField>
                        <f:TemplateField Width="100px" HeaderText="類型" TextAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Solution.Logic.Managers.T_TABLE_DBll.GetInstence().GetDescr(Eval("leave_id"),Eval("outwork_type")) %>'></asp:Label>
                            </ItemTemplate>
                        </f:TemplateField>
                        <f:LinkButtonField HeaderText="是否一級審批" Icon="BulletCross" TextAlign="Center" ToolTip="點擊修改是否一級審批" ColumnID="audit" CommandName="IsAudit" />
                        <f:LinkButtonField HeaderText="是否二級審批" Icon="BulletCross" TextAlign="Center" ToolTip="點擊修改是否二級審批" ColumnID="audit2" CommandName="IsAudit2" />
                        <f:LinkButtonField Width="100px" HeaderText="操作" TextAlign="Center" ToolTip="點擊修改當前記錄" ColumnID="ButtonEdit" CommandName="ButtonEdit" />
                    </Columns>
                </f:Grid>
                <f:Label runat="server" ID="lblSpendingTime" Text=""></f:Label>
                <f:HiddenField runat="server" ID="SortColumn" Text="Id"></f:HiddenField>
            </Items>
        </f:Panel>
        <f:Window ID="Window1" Width="700px" Height="450px" Icon="TagBlue" Title="編輯" Hidden="True"
            EnableMaximize="True" CloseAction="HidePostBack" OnClose="Window1_Close" EnableCollapse="true"
            runat="server" EnableResize="true" BodyPadding="5px" EnableFrame="True" IFrameUrl="about:blank"
            EnableIFrame="true" EnableClose="true" IsModal="True">
        </f:Window>
    </form>
</body>
</html>
