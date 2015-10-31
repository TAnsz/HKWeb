<%@ Page Language="C#" ValidateRequest="false" AutoEventWireup="true" CodeBehind="OutWorkRecordEdit.aspx.cs"
    Inherits="Solution.Web.Managers.WebManage.OutWorks.OutWorkRecordEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>請假出差編輯</title>
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
                        <f:Button ID="ButtonAccept" runat="server" Text="" Icon="Disk" OnClick="ButtonAccept_Click">
                        </f:Button>
                        <f:Button ID="ButtonAccept2" runat="server" Text="二級審批" Icon="Disk" OnClick="ButtonAccept2_Click">
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
                                        <f:TextBox runat="server" ID="txtEmpId" Label="員工編號" Width="300px" Text="" ShowRedStar="true"
                                            MaxLength="50" />
                                        <f:TextBox runat="server" ID="txtEmpName" Label="姓名" Width="300px" Text="" ShowRedStar="true" Readonly="True"
                                            MaxLength="100" />
                                    </Items>
                                </f:FormRow>
                                <f:FormRow ID="FormRow2" runat="server">
                                    <Items>
                                        <f:TextBox runat="server" ID="txtDept" Label="部門" Width="610px" Text="" Readonly="True"
                                            MaxLength="50" />
                                    </Items>
                                </f:FormRow>
                                <f:FormRow ID="FormRow3" runat="server">
                                    <Items>
                                        <f:DropDownList Label="請假出差類型" AutoPostBack="true" CompareType="String" EnableSimulateTree="true"
                                            runat="server" ID="ddlOutWorkRecord" Width="300px" ShowRedStar="true" OnSelectedIndexChanged="ddlOutWorkRecord_SelectedIndexChanged">
                                        </f:DropDownList>
                                        <f:TextBox runat="server" ID="txtDays" Label="天數" Width="200px" Text="" Readonly="True"
                                            MaxLength="50" />
                                    </Items>
                                </f:FormRow>
                                <f:FormRow ID="FormRow4" runat="server">
                                    <Items>
                                        <f:DatePicker ID="dpStartTime" Label="開始時間" Width="300px" Required="true" runat="server"
                                            ShowRedStar="true" />
                                        <f:DatePicker ID="dpEndTime" Label="結束時間" Width="300px" Required="true" runat="server"
                                            ShowRedStar="true" />
                                    </Items>
                                </f:FormRow>
                                <f:FormRow ID="FormRow11" runat="server">
                                    <Items>
                                        <f:DropDownList Label="時段" AutoPostBack="true" CompareType="String" EnableSimulateTree="true"
                                            runat="server" ID="ddlType" Width="300px" ShowRedStar="true" OnSelectedIndexChanged="ddlType_SelectedIndexChanged">
                                            <f:ListItem Text="全天" Value="0" />
                                            <f:ListItem Text="上午" Value="1" />
                                            <f:ListItem Text="下午" Value="2" />
                                            <f:ListItem Text="按時間" Value="3" />
                                        </f:DropDownList>
                                    </Items>
                                </f:FormRow>
                                <f:FormRow ID="FormRow7" runat="server">
                                    <Items>
                                        <f:TextBox runat="server" ID="txtchecker" Label="一級審批人" Width="300px" Text="" ShowRedStar="true" Readonly="True"
                                            MaxLength="100" />
                                        <f:TextBox runat="server" ID="txtchecker2" Label="二級審批人" Width="300px" Text="" ShowRedStar="true" Readonly="True"
                                            MaxLength="100" />
                                    </Items>
                                </f:FormRow>
                                <f:FormRow ID="FormRow8" runat="server">
                                    <Items>
                                        <f:CheckBox ID="cbIsCheck1" Label="是否一級審批" runat="server" Readonly="True"
                                            Width="300px">
                                        </f:CheckBox>
                                        <f:CheckBox ID="cbIsCheck2" Label="是否二級審批" runat="server" Readonly="True"
                                            Width="300px">
                                        </f:CheckBox>
                                    </Items>
                                </f:FormRow>
                                <f:FormRow ID="FormRow5" runat="server">
                                    <Items>
                                        <f:TextArea runat="server" Label="原因" ID="txtMemo" Width="610px"
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
    </form>
</body>
</html>
