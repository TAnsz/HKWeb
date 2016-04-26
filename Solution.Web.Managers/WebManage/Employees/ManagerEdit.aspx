<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManagerEdit.aspx.cs" Inherits="Solution.Web.Managers.WebManage.Employees.ManagerEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>員工編輯</title>
</head>
<body>
    <form id="form1" runat="server">
    <f:PageManager ID="PageManager1" runat="server" EnableFormChangeConfirm="true" />
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
                    <f:HiddenField runat="server" ID="hidId" Text="0">
                    </f:HiddenField>
                    <f:GroupPanel ID="UserInfoAccount" runat="server" BoxConfigAlign="Center" Title="創建系統賬戶"
                        EnableCollapse="True">
                        <Items>
                            <f:SimpleForm ID="SimpleForm2" BodyPadding="5px" runat="server" ShowBorder="false"
                                Width="450px" ShowHeader="false">
                                <Items>
                                    <f:TextBox runat="server" Label="賬號" EmptyText="當前系統所用的賬戶" ID="txtLoginName" ShowRedStar="true">
                                    </f:TextBox>
                                    <f:TextBox runat="server" Label="賬號密碼" EmptyText="用戶賬號登錄使用密碼" TextMode="Password"
                                        ID="txtLoginPass">
                                    </f:TextBox>
                                    <f:TextBox runat="server" Label="確認密碼" EmptyText="再次輸入賬號登錄密碼" TextMode="Password"
                                        ID="txtLoginPassaAgin" CompareOperator="Equal" CompareControl="txtLoginPass"
                                        CompareMessage="兩次密碼不一致">
                                    </f:TextBox>
                                    <f:RadioButtonList ID="rblIsEnable" Label="賬號狀態" ColumnNumber="2" runat="server"
                                        Required="true">
                                        <f:RadioItem Text="啟用" Value="1" Selected="true" />
                                        <f:RadioItem Text="禁用" Value="0" />
                                    </f:RadioButtonList>
                                    <f:RadioButtonList ID="rblIsMultiUser" Label="是否禁止同一帳號多人使用" ColumnNumber="2" runat="server"
                                        Required="true">
                                        <f:RadioItem Text="是" Value="0" Selected="true" />
                                        <f:RadioItem Text="否" Value="1" />
                                    </f:RadioButtonList>
                                    <f:Label runat="server" Label="說明" Text="是否禁止同一帳號多人使用，是=只能單個在線，否1=可以多人同時在線">
                                    </f:Label>
                                </Items>
                            </f:SimpleForm>
                        </Items>
                    </f:GroupPanel>
                    <f:GroupPanel ID="BasicUserInfo" runat="server" BoxConfigAlign="Center" EnableCollapse="True"
                        Title="員工基本信息">
                        <Items>
                            <f:SimpleForm ID="SimpleForm1" BodyPadding="5px" runat="server" ShowBorder="false"
                                Title="表單" Width="450px" ShowHeader="false">
                                <Items>
                                    <%--<f:Image ID="imgPhoto" CssClass="photo" ImageWidth="200px" ImageHeight="150px" ImageUrl="../images/blank.png"
                                        runat="server">
                                    </f:Image>
                                    <f:FileUpload ID="fuSinger_AvatarPath" runat="server" Width="430px" ShowLabel="true"
                                        Label="頭像上傳">
                                    </f:FileUpload>--%>
                                    <f:TextBox ID="txtCName" Label="姓名(中)" EmptyText="中文名稱" runat="server" ShowRedStar="true"
                                        Required="true">
                                    </f:TextBox>
                                    <f:TextBox ID="txtEName" Label="姓名(英)" EmptyText="英文名稱" runat="server">
                                    </f:TextBox>
                                    <f:RadioButtonList ID="rblSex" runat="server" Required="true" Label="性別">
                                        <f:RadioItem Text="男" Value="男" Selected="true" />
                                        <f:RadioItem Text="女" Value="女" />
                                    </f:RadioButtonList>
                                    <f:DropDownList runat="server" ID="ddlBranch_Id" Label="所屬部門" ShowRedStar="true" AutoSelectFirstItem="False"
                                        Required="true">
                                    </f:DropDownList>
                                    <f:HiddenField ID="hidPositionId" runat="server">
                                    </f:HiddenField>
                                    <f:DropDownList runat="server" Label="所屬職位" ID="ddlPosition" AutoSelectFirstItem="False">
                                    </f:DropDownList>
                                    <f:DropDownList runat="server" Label="考勤班次" ID="ddlShift" AutoSelectFirstItem="False">
                                    </f:DropDownList>
                                    <f:DropDownList runat="server" Label="考勤規則" ID="ddlRule" AutoSelectFirstItem="False">
                                    </f:DropDownList>
                                    <f:DropDownList runat="server" Label="權限組" ID="ddlGroup" AutoSelectFirstItem="False">
                                    </f:DropDownList>
                                    <f:DropDownList runat="server" Label="長短周" ID="ddlShort" AutoSelectFirstItem="False">
                                    </f:DropDownList>
                                    <f:DropDownList runat="server" Label="審核人" ID="ddlChecker1" AutoSelectFirstItem="False">
                                    </f:DropDownList>
                                    <f:DropDownList runat="server" Label="二級審核人" ID="ddlChecker2" AutoSelectFirstItem="False">
                                    </f:DropDownList>
                                    <%--<f:Button ID="ButtonSelectPosition" runat="server" Text="選擇職位" Icon="Magnifier" EnablePostBack="False">
                                    </f:Button>--%>
                                    <f:DatePicker runat="server" Label="入職日期" ID="dpBirthday" DateFormatString="yyyy-M-d">
                                    </f:DatePicker>
                                </Items>
                            </f:SimpleForm>
                        </Items>
                    </f:GroupPanel>
                    <f:GroupPanel ID="GroupPanel2" runat="server" Title="完整個人信息" EnableCollapse="True">
                        <Items>
                            <f:SimpleForm ID="SimpleForm3" BodyPadding="5px" runat="server" ShowBorder="false"
                                Width="450px" ShowHeader="false">
                                <Items>
                                    <f:TextBox runat="server" Label="民族" ID="txtNationalName">
                                    </f:TextBox>
                                    <f:TextBox runat="server" Label="手提電話" ID="txtMobile">
                                    </f:TextBox>
                                    <f:TextBox runat="server" Label="公司直綫" ID="txtTel">
                                    </f:TextBox><f:TextBox runat="server" Label="Fax地址" ID="txtFax">
                                    </f:TextBox>
                                    <f:TextBox runat="server" Label="聯繫地址" ID="txtAddress">
                                    </f:TextBox>
                                    <f:TextBox runat="server" Label="籍貫" ID="txtNativePlace">
                                    </f:TextBox>
                                    <f:TextBox runat="server" Label="學歷" ID="txtRecord">
                                    </f:TextBox>
                                    <f:TextBox runat="server" Label="專業" ID="txtGraduateSpecialty">
                                    </f:TextBox>
                                    <f:TextBox runat="server" Label="畢業學院" ID="txtGraduateCollege">
                                    </f:TextBox>
                                    <f:TextBox runat="server" Label="聯繫郵箱" ID="txtEmail">
                                    </f:TextBox>
                                    <f:HtmlEditor runat="server" Label="備註信息" ID="txtContent">
                                    </f:HtmlEditor>
                                </Items>
                            </f:SimpleForm>
                        </Items>
                    </f:GroupPanel>
                </Items>
            </f:Panel>
        </Items>
    </f:Panel>
    <f:Window ID="SelectWindows" Title="編輯" Hidden="true" EnableIFrame="true" runat="server" CloseAction="HidePostBack" 
        EnableMaximize="true" EnableResize="true" Target="Parent" OnClose="SelectWindows_Close" EnableClose="true"
        IsModal="True" Width="468px" Height="413px">
    </f:Window>
    <f:Window ID="Window1" Hidden="True"
        CloseAction="HidePostBack" OnClose="Window1_Close" EnableCollapse="true"
        runat="server" EnableResize="true" BodyPadding="5px" EnableFrame="True" IFrameUrl="about:blank"
        EnableIFrame="true" EnableClose="true"  IsModal="True" >
    </f:Window>
    </form>
</body>
</html>
