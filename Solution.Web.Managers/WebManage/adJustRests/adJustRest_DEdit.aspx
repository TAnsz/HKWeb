<%@ Page Language="C#" ValidateRequest="false" AutoEventWireup="true" CodeBehind="adJustRest_DEdit.aspx.cs"
    Inherits="Solution.Web.Managers.WebManage.adJustRests.adJustRest_DEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>調休申請單編輯</title>
</head>
<body>
    <form id="form1" runat="server">
        <f:HiddenField runat="server" ID="hidId" Text="0">
        </f:HiddenField>
        <f:PageManager ID="PageManager1" runat="server" EnableFormChangeConfirm="true"/>
        <f:Panel ID="Panel1" runat="server" EnableFrame="false" BodyPadding="10px" EnableCollapse="True"
            ShowHeader="False">
            <Toolbars>
                <f:Toolbar ID="toolBar" runat="server">
                    <Items>
                        <f:Button ID="ButtonSave" runat="server" Text="保存" Icon="Disk" OnClick="ButtonSave_Click">
                        </f:Button>
                        <f:Button ID="ButtonAccept" runat="server" Text="一級審核" Icon="Disk" OnClick="ButtonAccept_Click">
                        </f:Button>
                        <f:Button ID="ButtonAccept2" runat="server" Text="二級審核" Icon="Disk" OnClick="ButtonAccept2_Click">
                        </f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Items>
                <f:Panel ID="Panel2" runat="server" EnableFrame="false" BodyPadding="5px" EnableCollapse="True"
                    ShowHeader="False" ShowBorder="False">
                    <Items>
                        <f:Form ID="extForm1" ShowBorder="false" ShowHeader="false" BodyPadding="5px" runat="server">
                            <Rows>
                                <f:FormRow ID="FormRow1" runat="server">
                                    <Items>
                                        <f:TriggerBox runat="server" ID="tbxEmp" Label="員工編號" Width="300px" Text="" ShowRedStar="true" EmptyText="請選擇員工"
                                            MaxLength="50" TriggerIcon="Search" EnableEdit="false" OnTriggerClick="tbxEmp_TriggerClick"/>
                                        <f:TextBox runat="server" ID="txtEmpName" Label="姓名" Width="300px" Text="" ShowRedStar="true" Readonly="True"
                                            MaxLength="100" />
                                    </Items>
                                </f:FormRow>
                                <f:FormRow ID="FormRow2" runat="server">
                                    <Items>
                                        <f:TextBox runat="server" ID="txtDeptId" Label="部門ID" Width="50px" Text="" Hidden="true"
                                            MaxLength="50" />
                                        <f:TextBox runat="server" ID="txtDept" Label="部門" Width="600px" Text="" Readonly="True"
                                            MaxLength="50" />
                                    </Items>
                                </f:FormRow>
                                <f:FormRow ID="FormRow3" runat="server">
                                    <Items>
                                        <f:DropDownList Label="調休類型" AutoPostBack="true" CompareType="String" EnableSimulateTree="true"
                                            runat="server" ID="ddladJustRest_D" Width="300px" ShowRedStar="true" OnSelectedIndexChanged="ddladJustRest_D_SelectedIndexChanged">
                                        </f:DropDownList>
                                        <%--<f:TextBox runat="server" ID="txtDays" Label="天數" Width="200px" Text="" Readonly="True"
                                            MaxLength="50" />--%>
                                    </Items>
                                </f:FormRow>
                                <f:FormRow ID="FormRow4" runat="server">
                                    <Items>
                                        <f:DatePicker ID="dpStartTime" Label="加班日期" Width="300px" Required="true" runat="server" EmptyText="請選擇加班日期"
                                            ShowRedStar="true" />
                                        <f:DatePicker ID="dpEndTime" Label="調休日期" Width="300px" Required="true" runat="server" EmptyText="請選擇調休日期"
                                            CompareControl="dpStartTime" CompareOperator="GreaterThan" CompareMessage="調休日期应该大于加班日期" ShowRedStar="true" />
                                    </Items>
                                </f:FormRow>
                                <f:FormRow ID="FormRow11" runat="server">
                                    <Items>
                                        <f:DropDownList Label="時段" AutoPostBack="true" CompareType="String" EnableSimulateTree="true"
                                            runat="server" ID="ddlType" Width="300px" ShowRedStar="true" OnSelectedIndexChanged="ddlType_SelectedIndexChanged">
                                            <f:ListItem Text ="全天" Value="0" />
                                            <f:ListItem Text ="上午" Value="1" />
                                            <f:ListItem Text ="下午" Value="2" />
                                            <f:ListItem Text ="按時間" Value="3" />
                                        </f:DropDownList>
                                    </Items>
                                </f:FormRow>
                                <f:FormRow ID="FormRow7" runat="server">
                                    <Items>
                                        <f:TextBox runat="server" ID="txtchecker" Label="一級審核人" Width="300px" Text="" ShowRedStar="true" Readonly="True"
                                            MaxLength="100" />
                                        <f:TextBox runat="server" ID="txtchecker2" Label="二級審核人" Width="300px" Text="" ShowRedStar="true" Readonly="True"
                                            MaxLength="100" />
                                    </Items>
                                </f:FormRow>
                                <f:FormRow ID="FormRow8" runat="server">
                                    <Items>
                                        <f:CheckBox ID="cbIsCheck1" Label="是否一級審核" runat="server" Readonly="True"
                                            Width="300px">
                                        </f:CheckBox>
                                        <f:CheckBox ID="cbIsCheck2" Label="是否二級審核" runat="server" Readonly="True"
                                            Width="300px">
                                        </f:CheckBox>
                                    </Items>
                                </f:FormRow>
                                <f:FormRow ID="FormRow5" runat="server">
                                    <Items>
                                        <f:TextArea runat="server" Label="原因" ID="txtMemo" Width="600px"
                                            Height="75px">
                                        </f:TextArea>
                                    </Items>
                                </f:FormRow>
                            </Rows>
                        </f:Form>
                    </Items>
                </f:Panel>
            </Items>
        </f:Panel>
        <f:Window ID="Window2" Width="500px" Height="400px" Icon="TagBlue" Title="選擇" Hidden="True"
            EnableMaximize="True" CloseAction="HidePostBack" OnClose="Window2_Close" EnableCollapse="true"
            runat="server" EnableResize="true" BodyPadding="5px" EnableFrame="True" IFrameUrl="about:blank"
            EnableIFrame="true" EnableClose="true" IsModal="True">
        </f:Window>
    </form>
</body>
</html>
