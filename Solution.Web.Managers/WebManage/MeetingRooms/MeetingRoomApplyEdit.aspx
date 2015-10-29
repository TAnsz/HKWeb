<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MeetingRoomApplyEdit.aspx.cs" Inherits="Solution.Web.Managers.WebManage.MeetingRooms.MeetingRoomApplyEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>會議室申請單編輯</title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server" />
        <f:Panel ID="Panel1" runat="server" EnableFrame="false" BodyPadding="10px" EnableCollapse="True" ShowHeader="False">
            <Toolbars>
                <f:Toolbar ID="toolBar" runat="server">
                    <Items>
                        <f:Button ID="ButtonSave" runat="server" Text="保存" Icon="Disk" OnClick="ButtonSave_Click"></f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Items>
                <f:Panel ID="Panel2" runat="server" EnableFrame="false" BodyPadding="5px" EnableCollapse="True" ShowHeader="False" ShowBorder="False">
                    <Items>
                        <f:SimpleForm ID="SimpleForm1" ShowBorder="false" ShowHeader="false"
                            AutoScroll="true" BodyPadding="5px" runat="server" EnableCollapse="True">
                            <Items>
                                <f:DropDownList Label="會議室選擇" runat="server" ID="dllRoomMoment" Width="400px"
                                    >
                                </f:DropDownList>
                                <f:TextBox runat="server" Label="編號" ID="txtCode" Width="400px" Readonly="True"></f:TextBox>
                                <f:TextBox runat="server" Label="名稱" ID="txtName" ShowRedStar="true" Width="400px"></f:TextBox>
                                <f:DatePicker runat="server" Label="會議日期" ID="dpDate" ShowRedStar="true" Width="300px" />
                                <f:DropDownList Label="開始時間" runat="server" ID="dllStart" Width="250px">
                                    <f:ListItem Text="08:30" Value="08:30" />
                                    <f:ListItem Text="09:00" Value="09:00" />
                                    <f:ListItem Text="09:30" Value="09:30" />
                                    <f:ListItem Text="10:00" Value="10:00" />
                                    <f:ListItem Text="10:30" Value="10:30" />
                                    <f:ListItem Text="11:00" Value="11:00" />
                                    <f:ListItem Text="11:30" Value="11:30" />
                                    <f:ListItem Text="12:00" Value="12:00" />
                                    <f:ListItem Text="12:30" Value="12:30" />
                                    <f:ListItem Text="13:00" Value="13:00" />
                                    <f:ListItem Text="13:30" Value="13:30" />
                                    <f:ListItem Text="14:00" Value="14:00" />
                                    <f:ListItem Text="14:30" Value="14:30" />
                                    <f:ListItem Text="15:00" Value="15:00" />
                                    <f:ListItem Text="15:30" Value="15:30" />
                                    <f:ListItem Text="16:00" Value="16:00" />
                                    <f:ListItem Text="16:30" Value="16:30" />
                                    <f:ListItem Text="17:00" Value="17:00" />
                                    <f:ListItem Text="17:30" Value="17:30" />
                                    <f:ListItem Text="18:00" Value="18:00" />
                                    <f:ListItem Text="18:30" Value="18:30" />
                                    <f:ListItem Text="19:00" Value="19:00" />
                                    <f:ListItem Text="19:30" Value="19:30" />
                                    <f:ListItem Text="20:00" Value="20:00" />
                                    <f:ListItem Text="20:30" Value="20:30" />
                                    <f:ListItem Text="21:00" Value="21:00" />
                                </f:DropDownList>
                                <f:DropDownList Label="結束時間" runat="server" ID="dllEnd" Width="250px">
                                    <f:ListItem Text="09:00" Value="09:00" />
                                    <f:ListItem Text="09:30" Value="09:30" />
                                    <f:ListItem Text="10:00" Value="10:00" />
                                    <f:ListItem Text="10:30" Value="10:30" />
                                    <f:ListItem Text="11:00" Value="11:00" />
                                    <f:ListItem Text="11:30" Value="11:30" />
                                    <f:ListItem Text="12:00" Value="12:00" />
                                    <f:ListItem Text="12:30" Value="12:30" />
                                    <f:ListItem Text="13:00" Value="13:00" />
                                    <f:ListItem Text="13:30" Value="13:30" />
                                    <f:ListItem Text="14:00" Value="14:00" />
                                    <f:ListItem Text="14:30" Value="14:30" />
                                    <f:ListItem Text="15:00" Value="15:00" />
                                    <f:ListItem Text="15:30" Value="15:30" />
                                    <f:ListItem Text="16:00" Value="16:00" />
                                    <f:ListItem Text="16:30" Value="16:30" />
                                    <f:ListItem Text="17:00" Value="17:00" />
                                    <f:ListItem Text="17:30" Value="17:30" />
                                    <f:ListItem Text="18:00" Value="18:00" />
                                    <f:ListItem Text="18:30" Value="18:30" />
                                    <f:ListItem Text="19:00" Value="19:00" />
                                    <f:ListItem Text="19:30" Value="19:30" />
                                    <f:ListItem Text="20:00" Value="20:00" />
                                    <f:ListItem Text="20:30" Value="20:30" />
                                    <f:ListItem Text="21:00" Value="21:00" />
                                    <f:ListItem Text="21:30" Value="21:30" />
                                </f:DropDownList>
                                <f:Label runat="server" Width="400px" ID="txtEmpId" Label="申請員工編號" Readonly="True" />
                                <f:Label runat="server" Width="400px" ID="txtEmpName" Label="申請人" Readonly="True" />
                                <f:Label runat="server" Width="400px" ID="txtDepartId" Label="申請部門編號" Readonly="True" />
                                <f:Label runat="server" Width="400px" ID="txtDepartName" Label="申請部門" Readonly="True" />
                                <f:TextArea runat="server" Label="備註" ID="txtRemark" Width="400px" Height="60px" ></f:TextArea>
                                <f:RadioButtonList ID="rblIsVaild" Label="是否有效" ColumnNumber="2" runat="server"
                                    ShowRedStar="true" Required="true">
                                    <f:RadioItem Text="有效" Value="1" Selected="true" />
                                    <f:RadioItem Text="無效" Value="0" />
                                </f:RadioButtonList>
                                <f:Label runat="server" Text="注:非本人錄入單據，無法修改！" ID="lbtips" CssClass="redlabel" Hidden="true" />
                                <f:HiddenField runat="server" ID="hidId" Text="0"></f:HiddenField>
                            </Items>
                        </f:SimpleForm>
                    </Items>
                </f:Panel>
            </Items>
        </f:Panel>
    </form>
</body>
</html>
