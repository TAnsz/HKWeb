<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PositionEdit.aspx.cs" Inherits="Solution.Web.Managers.WebManage.Systems.Powers.PositionEdit" %>

<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <title>角色編輯</title>
</head>
<body>
    <form id="form1" runat="server">
    <f:pagemanager id="PageManager1" runat="server" EnableFormChangeConfirm="true"/>
    <f:Panel ID="Panel1" runat="server" EnableFrame="false" BodyPadding="10px" EnableCollapse="True" ShowHeader="False">
        <Toolbars>
            <f:Toolbar ID="toolBar" runat="server" >
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
                            <f:TextBox runat="server" Label="角色編號" ID="txtCode" ShowRedStar="true" Width="250px"></f:TextBox>
                            <f:TextBox runat="server" Label="角色名稱" ID="txtName" ShowRedStar="true" Width="250px"></f:TextBox>
                            <f:Tree runat="server" Title="菜單（頁面）樹狀圖" ShowBorder="True" ShowHeader="True" EnableArrows="true" AutoLeafIdentification="false"
                                Width="340px" EnableLines="true" ID="MenuTree" OnNodeCheck="MenuTree_NodeCheck">
                            </f:Tree>
                            <f:HiddenField runat="server" ID="hidPositionId" Text="0"></f:HiddenField>
                            <f:HiddenField runat="server" ID="HidTables" Text="0"></f:HiddenField>
                        </Items>
                    </f:SimpleForm>
                </Items>
            </f:Panel>
        </Items>
    </f:Panel>
    </form>
</body>
</html>
