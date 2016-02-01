<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManagerList.aspx.cs" Inherits="Solution.Web.Managers.WebManage.Employees.ManagerList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>在職員工列表</title>
</head>
<body>
    <form id="form1" runat="server">
    <f:PageManager ID="PageManager1" runat="server" />
    <f:Panel ID="Panel1" runat="server" Title="在職員工列表" EnableFrame="false" BodyPadding="10px" AutoScroll="true"
        EnableCollapse="True">
        <Toolbars>
            <f:Toolbar ID="toolBar" runat="server">
                <Items>
                    <f:Button ID="ButtonRefresh" runat="server" Text="刷新" Icon="ArrowRefresh" OnClick="ButtonRefresh_Click"
                        CssClass="inline">
                    </f:Button>
                    <f:Button ID="ButtonSearch" runat="server" Text="查詢" Icon="Magnifier" OnClick="ButtonSearch_Click">
                    </f:Button>
                    <f:Button ID="ButtonAdd" runat="server" Text="添加" Icon="Add" OnClick="ButtonAdd_Click">
                    </f:Button>
                    <f:Button ID="ButtonStaffTurnover" runat="server" Text="離職" Icon="UserCross" OnClick="ButtonStaffTurnover_Click"
                        ConfirmTitle="提示" ConfirmText="該員工是否離職？" OnClientClick="if (!F('Panel1_Grid1').getSelectionModel().hasSelection() ) { F.alert('請選擇你要處理的記錄！'); return false; } ">
                    </f:Button>
                </Items>
            </f:Toolbar>
        </Toolbars>
        <Items>
            <f:Form ID="Form6" ShowBorder="false" BodyPadding="5px" ShowHeader="False" runat="server" >
                <Rows>
                    <f:FormRow ID="FormRow2" runat="server">
                        <Items>
                            <f:DropDownList runat="server" ID="ddlBranch_Id" Label="所屬部門" ShowRedStar="true" Required="true"  AutoSelectFirstItem ="false">
                            </f:DropDownList>
                            <f:TextBox Label="員工編號" ID="txtLoginName" runat="server"  />
                            <f:TextBox Label="員工名稱" ID="txtCName" runat="server"  />
                        </Items>
                    </f:FormRow>
                </Rows>
            </f:Form>
            <f:Grid ID="Grid1" Title="在職員工列表" EnableFrame="False" EnableCollapse="true" AllowSorting="true" SortField="EMP_ID" SortDirection="ASC"
                IsDatabasePaging="True" PageSize="15" ShowBorder="true" ShowHeader="False"
                AllowPaging="true" runat="server" EnableCheckBoxSelect="True" DataKeyNames="Id"
                EnableColumnLines="true" OnPageIndexChange="Grid1_PageIndexChange" OnPreRowDataBound="Grid1_PreRowDataBound"
                OnRowCommand="Grid1_RowCommand" OnSort="Grid1_Sort">
                <Columns>
                    <f:TemplateField RenderAsRowExpander="true">
                        <ItemTemplate>
                            <div class="expander">
                                <table width="900px">
                                    <%--<tr>
                                        <td rowspan="6" style="width: 120px; padding-top: 10px;">
                                            <%# Eval("PhotoImg").ToString().Length > 5 ? "<img width=\"100px\" height=\"100px\" src='" + DotNet.Utilities.DirFileHelper.GetFilePathPostfix(Eval("PhotoImg").ToString(), "") + "'>" : "<image width=\"100px\" height=\"75px\" src=\"../images/blank.png\"></image>"%>
                                        </td>
                                    </tr>--%>
                                    <tr>
                                        <td style="width: 250px; padding-top: 10px;">
                                            <strong>入職日期：<%# Eval("JOIN_DATE","{0:yyyy-MM-dd}")%></strong>
                                        </td>
                                        <td style="width: 250px; padding-top: 10px;">
                                            <strong>家庭電話：</strong><%# Eval("PHONE_CODE")%>
                                        </td>
                                        <%--<td style="padding-top: 10px;">
                                            <strong>學歷：</strong><%# Eval("Record")%>
                                        </td>--%>
                                    </tr>
                                    <tr>
                                        <td style="padding-top: 10px;">
                                            <strong>一級審核人：</strong><%# Solution.Logic.Managers.EmployeeBll.GetInstence().GetEmpName(Eval("LINK_MAN")) %>
                                        </td>
                                        <td style="padding-top: 10px;">
                                            <strong>二級審核人：</strong><%# Solution.Logic.Managers.EmployeeBll.GetInstence().GetEmpName(Eval("CHECKER2")) %>
                                        </td>
                                        <td style="padding-top: 10px;">
                                            <strong>Email：</strong><%# Eval("Email")%>
                                        </td>
                                    </tr>
                                  <%--  <tr>
                                        <td style="padding-top: 10px;">
                                            <strong>專業：</strong><%# Eval("GraduateSpecialty")%>
                                        </td>
                                        <td style="padding-top: 10px;">
                                            <strong>QQ：</strong><%# Eval("Qq")%>
                                        </td>
                                        <td style="padding-top: 10px;">
                                            <strong>籍貫：</strong><%# Eval("NativePlace")%>
                                        </td>
                                    </tr>--%>
                                    <%--<tr>
                                        <td style="padding-top: 10px;">
                                            <strong>MSN：</strong><%# Eval("Msn")%>
                                        </td>
                                        <td style="padding-top: 10px;">
                                            <strong>民族：</strong><%# Eval("NationalName")%>
                                        </td>
                                        <td style="padding-top: 10px;">
                                            <strong>聯繫地址：</strong><%# Eval("Address")%>
                                        </td>
                                    </tr>--%>
                                    <tr>
                                        <td colspan="3" style="padding-top: 10px;">
                                            <strong>員工描敘：</strong><%# Eval("REMARK")%>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </ItemTemplate>
                    </f:TemplateField>
                    <f:BoundField DataField="Id" SortField="Id" Width="60px" />
                    <f:BoundField DataField="EMP_ID" SortField="EMP_ID" HeaderText="員工ID" Width="80px" />
                    <f:BoundField DataField="EMP_FNAME" SortField="EMP_FNAME" HeaderText="姓名(中)" Width="220px" />
                    <f:BoundField DataField="EN_NAME" SortField="EN_NAME" HeaderText="姓名(英)" Width="80px" />
                    <%--<f:BoundField DataField="LoginName" SortField="LoginName" HeaderText="登錄名(系統)" Width="100px" />--%>
                    <f:BoundField DataField="Sex" SortField="Sex" HeaderText="性別" Width="60px" />
                    <f:TemplateField Width="180px" HeaderText="部門" TextAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Solution.Logic.Managers.DepartsBll.GetInstence().GetDeptName(Eval("DEPART_ID")) %>'></asp:Label>
                            </ItemTemplate>
                        </f:TemplateField>
                    <f:BoundField DataField="POST_CODE" HeaderText="職位" Width="200px" />
                    <%--<f:BoundField DataField="LoginTime" SortField="LoginTime" HeaderText="最後登錄時間" Width="140px" />--%>
                    <%--<f:BoundField DataField="LoginIP" HeaderText="最後登錄IP" Width="100px" />--%>
                    <%--<f:BoundField DataField="LoginCount" SortField="LoginCount" HeaderText="登錄次數" Width="80px" />--%>
                    <f:CheckBoxField RenderAsStaticField="true" DataField="KIND" SortField="KIND" HeaderText="狀態" Width="50px" />
                    <f:LinkButtonField HeaderText="登陸日誌" Icon="TableMultiple" ToolTip="查看當前用戶登陸日誌信息"
                        Width="80px" ColumnID="LoginLog" CommandName="LoginLog" />
                    <f:LinkButtonField HeaderText="操作日誌" Icon="TableMultiple" ToolTip="查看當前用戶操作日誌信息"
                        Width="80px" ColumnID="UserLog" CommandName="UserLog" />
                    <f:LinkButtonField Width="60px" HeaderText="操作" ToolTip="點擊修改當前記錄" ColumnID="ButtonEdit"
                        CommandName="ButtonEdit" />
                </Columns>
            </f:Grid>
            <f:Label runat="server" ID="lblSpendingTime" Text="">
            </f:Label>
            <f:HiddenField runat="server" ID="SortColumn" Text="Id">
            </f:HiddenField>
        </Items>
    </f:Panel>
    <f:Window ID="Window1" Width="600px" Height="500px" Icon="TagBlue" Title="編輯" Hidden="True"
        EnableMaximize="True" CloseAction="HidePostBack" OnClose="Window1_Close" EnableCollapse="true"
        runat="server" EnableResize="true" BodyPadding="5px" EnableFrame="True" IFrameUrl="about:blank"
        EnableIFrame="true" EnableClose="true" IsModal="True" >
    </f:Window>
    <f:window id="Window2" width="750px" height="500px" icon="TagBlue" title="查看" hidden="True"
        enablemaximize="True" closeaction="HidePostBack" onclose="Window1_Close" enablecollapse="true"
        runat="server" enableresize="true" bodypadding="5px" enableframe="True" iframeurl="about:blank"
        enableiframe="true" enableclose="true" IsModal="True" >
    </f:window>
    </form>
</body>
</html>
