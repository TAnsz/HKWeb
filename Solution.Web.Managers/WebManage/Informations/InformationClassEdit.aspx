<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InformationClassEdit.aspx.cs" Inherits="Solution.Web.Managers.WebManage.Informations.InformationClassEdit" %>

<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <title>信息分類編輯</title>
</head>
<body>
    <form id="form1" runat="server">
    <f:pagemanager id="PageManager1" runat="server" EnableFormChangeConfirm="true"/>
    <f:Panel ID="Panel1" runat="server" EnableFrame="false" BodyPadding="10px" EnableCollapse="True" ShowHeader="False">
        <Toolbars>
            <f:Toolbar ID="toolBar" runat="server">
                <Items>
                    <f:Button ID="ButtonSave" runat="server" Text="保存" Icon="Disk" OnClick="ButtonSave_Click"></f:Button>
                    <f:Button ID="ButtonDeleteImage" runat="server" Text="刪除圖片" Icon="Delete" OnClick="ButtonDeleteImage_Click"
                        ConfirmTitle="刪除提示" ConfirmText="是否刪除圖片？" />
                </Items>
            </f:Toolbar>
        </Toolbars>
        <Items>
            <f:Panel ID="Panel2" runat="server" EnableFrame="false" BodyPadding="5px" EnableCollapse="True" ShowHeader="False" ShowBorder="False">
                <Items>
                    <f:SimpleForm ID="SimpleForm1" ShowBorder="false" ShowHeader="false" BodyPadding="5px" runat="server" EnableCollapse="True">
                        <Items>
                            <f:TextBox runat="server" Label="名稱" ID="txtName" ShowRedStar="true" Width="250px"></f:TextBox>
                            <f:DropDownList Label="信息分類節點選擇" AutoPostBack="true" Required="true" CompareType="String"
                                EnableSimulateTree="true" runat="server" ID="ddlParentId" Width="250px"
                                OnSelectedIndexChanged="ddlParentId_SelectedIndexChanged">
                            </f:DropDownList>
                            <f:TextBox Readonly="true" runat="server" ID="txtParent" Label="父Id" EmptyText="對應的父類Id" Width="250px" Text="0"></f:TextBox>
                            <f:TextBox runat="server" ID="txtSort" Label="排序" Width="250px" Text="0"></f:TextBox>
                            <f:RadioButtonList ID="rblIsShow" Label="是否顯示" ColumnNumber="2" runat="server"
                                ShowRedStar="true" Required="true">
                                <f:RadioItem Text="顯示" Value="1" Selected="true"/>
                                <f:RadioItem Text="不顯示" Value="0" />
                            </f:RadioButtonList>
                            <f:RadioButtonList ID="rblIsPage" Label="是否單頁" ColumnNumber="2" runat="server"
                                ShowRedStar="true" Required="true">
                                <f:RadioItem Text="單頁（沒有評論）" Value="1" Selected="true" />
                                <f:RadioItem Text="不是（一般文章）" Value="0" />
                            </f:RadioButtonList>
                            <f:TextBox runat="server" ID="txtSeoTitle" Label="Seo標題" Width="400px" Text="" MaxLength="100" Hidden="True"/>
                            <f:TextBox runat="server" ID="txtSeoKey" Label="SEO關鍵字" Width="400px" Text="" MaxLength="100" Hidden="True"/>
                            <f:TextArea runat="server" ID="txtSeoDesc" Label="SEO說明" Width="400px" Height="60px" Text="" MaxLength="200" Hidden="True"/>
                            <f:FileUpload runat="server" ID="fuClassImg" Label="分類圖" Width="400px" />
                            <f:Image runat="server" ID="imgClassImg">
                            </f:Image>
                            <f:TextArea runat="server" Label="備註" ID="txtNotes" Width="400px" Height="60px"></f:TextArea>
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
