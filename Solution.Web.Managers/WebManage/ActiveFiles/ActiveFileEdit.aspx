<%@ Page Language="C#" ValidateRequest="false" AutoEventWireup="true" CodeBehind="ActiveFileEdit.aspx.cs"
    Inherits="Solution.Web.Managers.WebManage.ActiveFiles.ActiveFileEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>文件編輯</title>
</head>
<body>
    <form id="form1" runat="server">
    <f:HiddenField runat="server" ID="hidId" Text="0">
    </f:HiddenField>
    <f:PageManager ID="PageManager1" runat="server" AutoSizePanelID="Panel1" EnableFormChangeConfirm="true"/>
    <f:Panel ID="Panel1" runat="server" EnableFrame="false" BodyPadding="10px" EnableCollapse="True"
        ShowHeader="False">
        <Toolbars>
            <f:Toolbar ID="toolBar" runat="server">
                <Items>
                    <f:Button ID="ButtonSave" runat="server" Text="保存" Icon="Disk" OnClick="ButtonSave_Click">
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
                                    <f:TextBox runat="server" ID="txtName" Label="文件名稱" Width="300px" Text="" ShowRedStar="true"
                                        MaxLength="50" />
                                    <f:TextBox runat="server" ID="txtKeyword" Label="Key(非中文)" Width="300px" Text=""
                                        MaxLength="50" ShowRedStar="true" Readonly="True" Hidden="True"/>
                                </Items>
                            </f:FormRow>
                            <f:FormRow ID="FormRow2" runat="server">
                                <Items>
                                    <f:DropDownList Label="文件位置" AutoPostBack="true" CompareType="String" EnableSimulateTree="true"
                                        runat="server" ID="ddlActiveFileClass" Width="300px" ShowRedStar="true" OnSelectedIndexChanged="ddlActiveFileClass_SelectedIndexChanged">
                                    </f:DropDownList>
                                    <f:RadioButtonList ID="rblIsDisplay" Label="是否顯示" ColumnNumber="2" runat="server"
                                        Width="300px">
                                        <f:RadioItem Text="顯示" Value="1" Selected="true" />
                                        <f:RadioItem Text="不顯示" Value="0" />
                                    </f:RadioButtonList>
                                </Items>
                            </f:FormRow>
                            <f:FormRow ID="FormRow10" runat="server">
                                <Items>
                                    <f:FileUpload runat="server" ID="filePhoto" Label="文件" Width="300px" />
                                    <f:TextBox runat="server" ID="txtSort" Label="排序" Width="300px" Text="0" />
                                </Items>
                            </f:FormRow>
                            <f:FormRow ID="FormRow3" runat="server">
                                <Items>
                                    <f:TextArea runat="server" Label="說明" ID="txtContent" Width="610px" MaxLength="100"
                                        Height="50px">
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
