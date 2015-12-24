<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UploadConfigEdit.aspx.cs"
    Inherits="Solution.Web.Managers.WebManage.Systems.Set.UploadConfigEdit" %>

<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <title>上傳類型編輯</title>
</head>
<body>
    <form id="form1" runat="server">
    <f:PageManager ID="PageManager1" runat="server" EnableFormChangeConfirm="true"/>
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
                    <f:HiddenField runat="server" ID="hidId" Text="0"></f:HiddenField>
                    <f:Form ID="Form6" ShowBorder="True" BodyPadding="5px" ShowHeader="False" runat="server">
                        <Rows>
                            <f:FormRow ID="FormRow1" runat="server">
                                <Items>
                                    <f:TextBox runat="server" Label="名稱" ID="txtName" ShowRedStar="true" Width="300px">
                                    </f:TextBox>
                                    <f:TextBox runat="server" Label="關聯表名" ID="txtJoinName" ShowRedStar="true" Width="300px">
                                    </f:TextBox>
                                </Items>
                            </f:FormRow>
                            <f:FormRow ID="FormRow2" runat="server">
                                <Items>
                                    <f:RadioButtonList ID="rblUserType" Label="用戶類別" ColumnNumber="2" runat="server" Required="true">
                                        <f:RadioItem Text="管理員上傳" Value="1" Selected="true" />
                                        <f:RadioItem Text="會員上傳" Value="2" />
                                    </f:RadioButtonList>
                                    <f:DropDownList Label="上傳類型" Required="true" CompareType="String" runat="server" ID="ddlUploadTypeId" Width="300px" ShowRedStar="True">
                                    </f:DropDownList>
                                </Items>
                            </f:FormRow>
                            <f:FormRow ID="FormRow3" runat="server">
                                <Items>
                                    <f:TextBox runat="server" Label="圖片上傳限制" ID="txtPicSize" ShowRedStar="true" Width="300px" EmptyText="單位為KB">
                                    </f:TextBox>
                                    <f:TextBox runat="server" Label="附件上傳限制" ID="txtFileSize" ShowRedStar="true" Width="300px" EmptyText="單位為KB">
                                    </f:TextBox>
                                </Items>
                            </f:FormRow>
                            <f:FormRow ID="FormRow4" runat="server">
                                <Items>
                                    <f:TextBox runat="server" Label="存儲路徑" ID="txtSaveDir" ShowRedStar="true" Width="300px">
                                    </f:TextBox>
                                </Items>
                            </f:FormRow>
                            <f:FormRow ID="FormRow19" runat="server">
                                <Items>
                                    <f:Label runat="server"></f:Label>
                                </Items>
                            </f:FormRow>
                            <f:FormRow ID="FormRow9" runat="server">
                                <Items>
                                    <f:RadioButtonList ID="rblIsPost" Label="是否啟用" ColumnNumber="2" runat="server" Required="true">
                                        <f:RadioItem Text="禁用" Value="0" />
                                        <f:RadioItem Text="啟用" Value="1" Selected="true" />
                                    </f:RadioButtonList>
                                    <f:RadioButtonList ID="rblIsEditor" Label="類型" ColumnNumber="2" runat="server" Required="true">
                                        <f:RadioItem Text="控件上傳" Value="0" />
                                        <f:RadioItem Text="編輯器上傳" Value="1" Selected="true" />
                                    </f:RadioButtonList>
                                </Items>
                            </f:FormRow>
                            <f:FormRow ID="FormRow5" runat="server">
                                <Items>
                                    <f:RadioButtonList ID="rblIsSwf" Label="上傳方式" ColumnNumber="2" runat="server" Required="true">
                                        <f:RadioItem Text="Web上傳" Value="0" Selected="true" />
                                        <f:RadioItem Text="Flash上傳" Value="1" />
                                    </f:RadioButtonList>
                                    <f:RadioButtonList ID="brlIsChkSrcPost" Label="是否檢查入口" ColumnNumber="2" runat="server" Required="true">
                                        <f:RadioItem Text="否" Value="0" />
                                        <f:RadioItem Text="是" Value="1" Selected="true" />
                                    </f:RadioButtonList>
                                </Items>
                            </f:FormRow>
                            <f:FormRow ID="FormRow6" runat="server">
                                <Items>
                                    <f:RadioButtonList ID="rblIsFixPic" Label="按比例生成" ColumnNumber="2" runat="server" Required="true">
                                        <f:RadioItem Text="否" Value="0" />
                                        <f:RadioItem Text="是" Value="1" Selected="true" />
                                    </f:RadioButtonList>
                                     <f:DropDownList Label="生成方式" CompareType="String" runat="server" ID="ddlCutType" Width="300px">
                                         <f:ListItem Text="按比例生成寬高" Value="0" Selected="true" />
                                         <f:ListItem Text="固定圖片寬高" Value="1" />
                                         <f:ListItem Text="固定背景寬高，圖片按比例生成" Value="2" />
                                    </f:DropDownList>
                                </Items>
                            </f:FormRow>
                            <f:FormRow ID="FormRow7" runat="server">
                                <Items>
                                    <f:TextBox runat="server" Label="最大寬度" ID="txtPicWidth" Width="300px" EmptyText="超過本設置將按比例進行縮放">
                                    </f:TextBox>
                                    <f:TextBox runat="server" Label="最大高度" ID="txtPicHeight" Width="300px" EmptyText="超過本設置將按比例進行縮放">
                                    </f:TextBox>
                                </Items>
                            </f:FormRow>
                            <f:FormRow ID="FormRow8" runat="server">
                                <Items>
                                    <f:TextBox runat="server" Label="圖片質量" ID="txtPicQuality" Width="300px">
                                    </f:TextBox>
                                    <f:Label runat="server" Label="說明" Text="圖片質量，0=使用默認值，>0指定質量值（指定值的情況下，範圍：50-100）"></f:Label>
                                </Items>
                            </f:FormRow>
                            <f:FormRow ID="FormRow20" runat="server">
                                <Items>
                                    <f:Label ID="Label1" runat="server"></f:Label>
                                </Items>
                            </f:FormRow>
                            <f:FormRow ID="FormRow10" runat="server">
                                <Items>
                                    <f:RadioButtonList ID="rblIsBigPic" Label="是否創建大圖" ColumnNumber="2" runat="server" Required="true">
                                        <f:RadioItem Text="否" Value="0" />
                                        <f:RadioItem Text="是" Value="1" Selected="true" />
                                    </f:RadioButtonList>
                                    <f:TextBox runat="server" Label="大圖寬度" ID="txtBigWidth" Width="300px">
                                    </f:TextBox>
                                </Items>
                            </f:FormRow>
                            <f:FormRow ID="FormRow11" runat="server">
                                <Items>
                                    <f:TextBox runat="server" Label="大圖高度" ID="txtBigHeight" Width="300px">
                                    </f:TextBox>
                                    <f:TextBox runat="server" Label="大圖壓縮質量" ID="txtBigQuality" Width="300px">
                                    </f:TextBox>
                                </Items>
                            </f:FormRow>
                            <f:FormRow ID="FormRow12" runat="server">
                                <Items>
                                    <f:RadioButtonList ID="rblIsMidPic" Label="是否創建中圖" ColumnNumber="2" runat="server" Required="true">
                                        <f:RadioItem Text="否" Value="0" Selected="true" />
                                        <f:RadioItem Text="是" Value="1" />
                                    </f:RadioButtonList>
                                    <f:TextBox runat="server" Label="中圖寬度" ID="txtMidWidth" Width="300px">
                                    </f:TextBox>
                                </Items>
                            </f:FormRow>
                            <f:FormRow ID="FormRow13" runat="server">
                                <Items>
                                    <f:TextBox runat="server" Label="中圖高度" ID="txtMidHeight" Width="300px">
                                    </f:TextBox>
                                    <f:TextBox runat="server" Label="中圖壓縮質量" ID="txtMidQuality" Width="300px">
                                    </f:TextBox>
                                </Items>
                            </f:FormRow>
                            <f:FormRow ID="FormRow14" runat="server">
                                <Items>
                                    <f:RadioButtonList ID="rblIsMinPic" Label="是否創建小圖" ColumnNumber="2" runat="server" Required="true">
                                        <f:RadioItem Text="否" Value="0" Selected="true" />
                                        <f:RadioItem Text="是" Value="1" />
                                    </f:RadioButtonList>
                                    <f:TextBox runat="server" Label="小圖寬度" ID="txtMinWidth" Width="300px">
                                    </f:TextBox>
                                </Items>
                            </f:FormRow>
                            <f:FormRow ID="FormRow15" runat="server">
                                <Items>
                                    <f:TextBox runat="server" Label="小圖高度" ID="txtMinHeight" Width="300px">
                                    </f:TextBox>
                                    <f:TextBox runat="server" Label="小圖壓縮質量" ID="txtMinQuality" Width="300px">
                                    </f:TextBox>
                                </Items>
                            </f:FormRow>
                            <f:FormRow ID="FormRow16" runat="server">
                                <Items>
                                    <f:RadioButtonList ID="rblIsHotPic" Label="是否創建推薦圖" ColumnNumber="2" runat="server" Required="true">
                                        <f:RadioItem Text="否" Value="0" Selected="true" />
                                        <f:RadioItem Text="是" Value="1" />
                                    </f:RadioButtonList>
                                    <f:TextBox runat="server" Label="推薦圖寬度" ID="txtHotWidth" Width="300px">
                                    </f:TextBox>
                                </Items>
                            </f:FormRow>
                            <f:FormRow ID="FormRow17" runat="server">
                                <Items>
                                    <f:TextBox runat="server" Label="推薦圖高度" ID="txtHotHeight" Width="300px">
                                    </f:TextBox>
                                    <f:TextBox runat="server" Label="推薦圖壓縮質量" ID="txtHotQuality" Width="300px">
                                    </f:TextBox>
                                </Items>
                            </f:FormRow>
                            <f:FormRow ID="FormRow18" runat="server">
                                <Items>
                                    <f:RadioButtonList ID="rblIsWaterPic" Label="是否加水印" ColumnNumber="2" runat="server" Required="true" Width="300px">
                                        <f:RadioItem Text="否" Value="0" Selected="true" />
                                        <f:RadioItem Text="是" Value="1" />
                                    </f:RadioButtonList>
                                    <f:Label ID="Label2" runat="server" Label="說明" Text="水印圖片路徑在配置文件裡設置"></f:Label>
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
