<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebConfigSet.aspx.cs" Inherits="Solution.Web.Managers.WebManage.Systems.Set.WebConfigSet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>系統配置編輯</title>
</head>
<body>
    <form id="form1" runat="server">
    <f:pagemanager id="PageManager1" runat="server" />
    <f:Panel ID="Panel1" runat="server" EnableFrame="false" BodyPadding="10px" EnableCollapse="True" ShowHeader="False" Width="600px">
        <Toolbars>
            <f:Toolbar ID="toolBar" runat="server">
                <Items>
                    <f:Button ID="ButtonSave" runat="server" Text="保存" Icon="Disk" OnClick="ButtonSave_Click"></f:Button>
                </Items>
            </f:Toolbar>
        </Toolbars>
        <Items>
            <f:Panel ID="Panel2" runat="server" EnableFrame="false" BodyPadding="5px" EnableCollapse="True" ShowHeader="False" ShowBorder="False" Width="600px">
                <Items>
                    <f:GroupPanel ID="GroupPanel1" runat="server" BoxConfigAlign="Center" Width="570px"
                        EnableCollapse="True" Title="網站基礎信息">
                        <Items>
                            <f:TextBox ID="txtWebName" Label="網站名稱" runat="server" Width="500px">
                            </f:TextBox>
                            <f:TextBox ID="txtWebDomain" Label="網站地址" runat="server" Width="500px">
                            </f:TextBox>
                            <f:TextBox ID="txtWebEmail" Label="管理員郵箱" runat="server" Width="500px">
                            </f:TextBox>
                            <f:TextBox ID="TextBox1" Label="Seo標題" runat="server" Width="500px">
                            </f:TextBox>
                            <f:TextBox ID="TextBox2" Label="Seo關鍵字" runat="server" Width="500px">
                            </f:TextBox>
                            <f:TextBox ID="TextBox3" Label="Seo說明" runat="server" Width="500px">
                            </f:TextBox>
                        </Items>
                    </f:GroupPanel>
                    
                    <f:GroupPanel ID="Manage" runat="server" BoxConfigAlign="Center" Width="570px"
                        EnableCollapse="True" Title="後端參數設置">
                        <Items>
                            <f:SimpleForm ID="SimpleForm1" BodyPadding="5px" runat="server" ShowBorder="false" Title="表單"  ShowHeader="false">
                                <Items>
                                    <f:RadioButtonList ID="rblIsStopWeb" runat="server" ShowRedStar="true" Required="true" Width="400px"
                                        Label="網站是否暫停">
                                        <f:RadioItem Text="正常使用" Value="0" />
                                        <f:RadioItem Text="暫停網站" Value="1" />
                                    </f:RadioButtonList>
                                    <f:TextBox ID="txtIsStopText" Label="暫停原因" runat="server" Required="true" Width="500px">
                                    </f:TextBox>
                                    <f:RadioButtonList ID="rblIsStopUserReg" runat="server" ShowRedStar="true" Required="true" Width="400px"
                                        Label="註冊會員">
                                        <f:RadioItem Text="可以註冊" Value="0" />
                                        <f:RadioItem Text="暫停註冊" Value="1" />
                                    </f:RadioButtonList>
                                    <f:RadioButtonList ID="rblIsPostReg" runat="server" ShowRedStar="true" Required="true" Width="400px"
                                        Label="會員註冊審核方式">
                                        <f:RadioItem Text="自動通過" Value="1" />
                                        <f:RadioItem Text="Email審核" Value="2" />
                                        <f:RadioItem Text="人工審核" Value="3" />
                                    </f:RadioButtonList>
                                   <f:RadioButtonList ID="rblRegIsEmailAlert" runat="server" ShowRedStar="true" Required="true" Width="400px"
                                        Label="是否發送歡迎郵件">
                                        <f:RadioItem Text="不發送" Value="0" />
                                        <f:RadioItem Text="發送" Value="1" />
                                    </f:RadioButtonList>
                                   <f:RadioButtonList ID="rblIsPostArticle" runat="server" ShowRedStar="true" Required="true" Width="400px"
                                        Label="用戶評論是否需要審核">
                                        <f:RadioItem Text="不審核" Value="0" />
                                        <f:RadioItem Text="審核" Value="1" />
                                    </f:RadioButtonList>
                                    <f:NumberBox ID="txtLoginLogReserveTime" Label="登陸日誌" runat="server" Width="300px">
                                    </f:NumberBox>
                                    <f:Label runat="server" Label="說明" Text="系統登陸日誌保留時間，0=無限制，N（數字）= X月"></f:Label>
                                    <f:NumberBox ID="txtUseLogReserveTime" Label="操作日誌" runat="server" Width="300px">
                                    </f:NumberBox>
                                    <f:Label runat="server" Label="說明" Text="系統操作日誌保留時間，0=無限制，N（數字）= X月"></f:Label>
                                </Items>
                            </f:SimpleForm>
                        </Items>
                    </f:GroupPanel>
                    <f:GroupPanel ID="EmailSet" runat="server" BoxConfigAlign="Center" Width="570px"
                        Title="郵件設置" EnableCollapse="True">
                        <Items>
                            <f:SimpleForm ID="SimpleForm2" BodyPadding="5px" runat="server" ShowBorder="false" ShowHeader="false">
                                <Items>
                                    <f:TextBox runat="server" Label="SMTP服務器" ID="txtEmailSmtp" Width="300px">
                                    </f:TextBox>
                                    <f:TextBox runat="server" Label="SMTP賬號" ID="txtEmailUserName" Width="300px">
                                    </f:TextBox>
                                    <f:TextBox runat="server" Label="SMTP密碼" ID="txtEmailPassWord" Width="300px" TextMode="Password">
                                    </f:TextBox>
                                    <f:CheckBox ID="chkSendTest" ShowLabel="false" runat="server" Text="保存後發送測試郵件到管理員郵箱"  Checked="false" AutoPostBack="True">
                                    </f:CheckBox>
                                </Items>
                            </f:SimpleForm>
                        </Items>
                    </f:GroupPanel>
                </Items>
            </f:Panel>
        </Items>
    </f:Panel>
    </form>
</body>
</html>
