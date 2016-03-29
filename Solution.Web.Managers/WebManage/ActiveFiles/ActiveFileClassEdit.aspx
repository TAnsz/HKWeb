<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ActiveFileClassEdit.aspx.cs" Inherits="Solution.Web.Managers.WebManage.ActiveFiles.ActiveFileClassEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>文件位置編輯</title>
</head>
<body>
    <form id="form1" runat="server">
    <f:pagemanager id="PageManager1" runat="server" AutoSizePanelID="Panel1" EnableFormChangeConfirm="true"/>
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
                    <f:SimpleForm ID="SimpleForm1" ShowBorder="false" ShowHeader="false" BodyPadding="5px" runat="server" EnableCollapse="True">
                        <Items>
                            <f:TextBox runat="server" ID="txtName" Label="名稱" ShowRedStar="true" Width="250px">
                            </f:TextBox>
                            <f:TextBox runat="server" ID="txtKey" Label="關鍵字" ShowRedStar="true" Width="250px">
                            </f:TextBox>
                            <f:DropDownList Label="所屬類別選擇" AutoPostBack="true" Required="true" CompareType="String"
                                EnableSimulateTree="true" runat="server" ID="ddlParentId" Width="250px" OnSelectedIndexChanged="ddlParentId_SelectedIndexChanged">
                            </f:DropDownList>
                            <f:TextBox Readonly="true" runat="server" ID="txtParent" Label="父Id" EmptyText="對應的父類Id"
                                Width="250px" Text="0">
                            </f:TextBox>
                            <f:TextBox runat="server" ID="txtSort" Label="排序" Width="250px" Text="0"></f:TextBox>
                            <f:RadioButtonList ID="rblIsDisplay" Label="是否顯示" ColumnNumber="2" runat="server"
                                ShowRedStar="true" Required="true">
                                <f:RadioItem Text="顯示" Value="1" Selected="true"/>
                                <f:RadioItem Text="不顯示" Value="0" />
                            </f:RadioButtonList>
                            <f:Button ID="ButtonDelMapImg" runat="server" Text="刪除文件" OnClick="ButtonDelMapImg_Click"></f:Button>
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
