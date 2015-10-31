<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdvertisingPositionEdit.aspx.cs" Inherits="Solution.Web.Managers.WebManage.Advertisements.AdvertisingPositionEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>廣告位置編輯</title>
</head>
<body>
    <form id="form1" runat="server">
    <f:pagemanager id="PageManager1" runat="server" />
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
                            <f:TextBox runat="server" ID="txtName" Label="位置名稱" ShowRedStar="true" Width="250px">
                            </f:TextBox>
                            <f:TextBox runat="server" ID="txtKey" Label="關鍵字" ShowRedStar="true" Width="250px">
                            </f:TextBox>
                            <f:DropDownList Label="所屬位置選擇" AutoPostBack="true" Required="true" CompareType="String"
                                EnableSimulateTree="true" runat="server" ID="ddlParentId" Width="250px" OnSelectedIndexChanged="ddlParentId_SelectedIndexChanged">
                            </f:DropDownList>
                            <f:TextBox Readonly="true" runat="server" ID="txtParent" Label="父Id" EmptyText="對應的父類Id"
                                Width="250px" Text="0">
                            </f:TextBox>
                            <f:TextBox runat="server" ID="txtWidth" Label="寬" Width="250px" Text="0"></f:TextBox>
                            <f:TextBox runat="server" ID="txtHeight" Label="高" Width="250px" Text="0"></f:TextBox>
                            <f:TextBox runat="server" ID="txtSort" Label="排序" Width="250px" Text="0"></f:TextBox>
                            <f:RadioButtonList ID="rblIsDisplay" Label="是否顯示" ColumnNumber="2" runat="server"
                                ShowRedStar="true" Required="true">
                                <f:RadioItem Text="顯示" Value="1" Selected="true"/>
                                <f:RadioItem Text="不顯示" Value="0" />
                            </f:RadioButtonList>
                            <f:FileUpload runat="server" ID="MapImg" Label="位置圖" Width="250px" /> 
                            <f:Button ID="ButtonDelMapImg" runat="server" Text="刪除位置圖" OnClick="ButtonDelMapImg_Click"></f:Button>
                            <f:Image runat="server" ID="imgMap"></f:Image>
                            <f:FileUpload runat="server" ID="PicImg" Label="默認廣告圖" Width="250px" /> 
                            <f:Button ID="ButtonDelPicImg" runat="server" Text="刪除默認圖" OnClick="ButtonDelPicImg_Click"></f:Button>
                            <f:Image runat="server" ID="imgPic"></f:Image>
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
