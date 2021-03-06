<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UploadTypeEdit.aspx.cs" Inherits="Solution.Web.Managers.WebManage.Systems.Set.UploadTypeEdit" %>

<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <title>上傳類型編輯</title>
</head>
<body>
    <form id="form1" runat="server">
    <f:pagemanager id="PageManager1" runat="server" EnableFormChangeConfirm="true"/>
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
                            <f:TextBox runat="server" Label="名稱" ID="txtName" ShowRedStar="true" Width="300px"></f:TextBox>
                            <f:TextBox runat="server" Label="關鍵字" ID="txtTypeKey" ShowRedStar="true" Width="300px" ></f:TextBox>
                            <f:TextArea runat="server" Label="綁定擴展名" ID="txtExt" ShowRedStar="True" Width="300px" Height="100px"></f:TextArea>
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
