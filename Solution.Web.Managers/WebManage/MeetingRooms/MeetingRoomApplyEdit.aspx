<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MeetingRoomApplyEdit.aspx.cs" Inherits="Solution.Web.Managers.WebManage.MeetingRooms.MeetingRoomApplyEdit" %>

<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <title>會議室申請單編輯</title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server" EnableFormChangeConfirm="true" />
        <f:Panel ID="Panel1" runat="server" EnableFrame="false" BodyPadding="10px" EnableCollapse="True" ShowHeader="False">
            <Toolbars>
                <f:Toolbar ID="toolBar" runat="server">
                    <Items>
                        <f:Button ID="ButtonSave" runat="server" Text="保存" Icon="Disk" OnClick="ButtonSave_Click"></f:Button>
                        <f:Button ID="ButtonDelete" runat="server" Text="刪除" Icon="Delete" OnClick="ButtonDelete_Click" ConfirmTitle="刪除提示" ConfirmText="是否刪除記錄？"/>
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Items>
                <f:Panel ID="Panel2" runat="server" EnableFrame="false" BodyPadding="5px" EnableCollapse="True" ShowHeader="False" ShowBorder="False">
                    <Items>
                        <f:SimpleForm ID="SimpleForm1" ShowBorder="false" ShowHeader="false"
                            AutoScroll="true" BodyPadding="5px" runat="server" EnableCollapse="True">
                            <Items>
                                <f:DropDownList Label="會議室選擇" runat="server" ID="dllRoomMoment" Width="400px" AutoSelectFirstItem="false" EmptyText="請選擇會議室" 
                                    Required="true" ShowRedStar="true"></f:DropDownList>
                                <%--<f:TextBox runat="server" Label="編號" ID="txtCode" Width="400px" Readonly="True"></f:TextBox>--%>
                                <%--<f:TextBox runat="server" Label="名稱" ID="txtName" ShowRedStar="true" Width="400px"></f:TextBox>--%>
                                <f:DatePicker runat="server" Label="會議日期" ID="dpDate" ShowRedStar="true" Width="300px" Required="true"/>
                                <f:DropDownList Label="開始時間" runat="server" ID="dllStart" Width="250px">
                                    <f:ListItem Text="08:00" Value="08:00" />
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
                                </f:DropDownList>
                                <f:DropDownList Label="結束時間" runat="server" ID="dllEnd" Width="250px">
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
                                </f:DropDownList>
                                <f:Label runat="server" Width="400px" ID="txtEmpId" Label="申請員工編號" Readonly="True" />
                                <f:Label runat="server" Width="400px" ID="txtEmpName" Label="申請人" Readonly="True" />
                                <f:Label runat="server" Width="400px" ID="txtDepartId" Label="申請部門編號" Readonly="True" />
                                <f:Label runat="server" Width="400px" ID="txtDepartName" Label="申請部門" Readonly="True" />
                                <f:RadioButtonList ID="rblIsVideo" Label="是否視頻會議" ColumnNumber="2" runat="server">
                                    <f:RadioItem Text="是" Value="1" />
                                    <f:RadioItem Text="不是" Value="0" Selected="true" />
                                </f:RadioButtonList>
                                <f:TextArea runat="server" Label="備註" ID="txtRemark" Width="400px" Height="60px" />
                                <f:Label runat="server" Text="注:非本人錄入單據，無法修改！" ID="lbtips" CssClass="redlabel" Hidden="true" />
                                <f:HiddenField runat="server" ID="hidId" Text="0" />
                                <f:HiddenField runat="server" ID="hidCode" Text="" />
                            </Items>
                        </f:SimpleForm>
                    </Items>
                </f:Panel>
            </Items>
        </f:Panel>
    </form>
</body>
</html>
