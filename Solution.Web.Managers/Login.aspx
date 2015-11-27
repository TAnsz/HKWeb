<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Solution.Web.Managers.Login" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>香港信息網絡系統</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=no, minimum-scale=1.0, maximum-scale=1.0" />
    <link href="WebManage/Css/login.css" rel="stylesheet" />
    <style type="text/css">
        .x-body {
            background-image: url(WebManage/Images/main.jpg);
            background-attachment: fixed;
            background-repeat: no-repeat;
            background-color: #ccd5de;
            background-position: center center;
        }

        .btnlarge {
            width: 150px;
            background-image: none;
        }
    </style>
</head>

<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server" />
        <f:Window ID="LoginWin" runat="server" Title="登錄系統" IsModal="false" EnableClose="false" Width="350px">
            <Items>
                <f:SimpleForm ID="SimpleForm1" runat="server" ShowBorder="false" BodyPadding="10px"
                    LabelWidth="60px" ShowHeader="false">
                    <Items>
                        <%-- <f:Image runat="server" ImageUrl="Images/logintop.png" ImageHeight="70" >
                                </f:Image>--%>
                        <f:TextBox ID="txtUser" Label="用戶名" EmptyText="請輸入工號或姓名" runat="server" Height="32px" FocusOnPageLoad="true"
                            NextFocusControl="txtPassword" EnableBlurEvent="true" OnBlur="txtUser_TextChanged" Required="true" Hidden="true">
                        </f:TextBox>
                        <f:DropDownList runat="server" ID="ddlUser" Label="用戶名" EmptyText="請輸入工號或姓名" Required="true"
                            EnableEdit="true" NextFocusControl="txtPassword" ForceSelection="false" AutoSelectFirstItem="false" Height="32px"></f:DropDownList>
                        <f:TextBox ID="txtPassword" Label="密   碼" EmptyText="輸入密碼" TextMode="Password" runat="server" Height="32px"
                            NextFocusControl="Button1">
                        </f:TextBox>

                        <%-- <f:Panel ID="Panel1" CssStyle="padding-left:10px;" ShowBorder="false" ShowHeader="false"
                            Height="50px" runat="server" Layout="HBox">
                            <Items>
                                <f:TextBox ID="txtCaptcha" ShowLabel="false" EmptyText="輸入右側驗證碼" runat="server" Height="32px">
                                </f:TextBox>
                               
                                
                                <f:LinkButton CssStyle="float:center;margin-top:8px;margin-right:100px;" ID="btnRefresh"
                                    Text="看不清？" runat="server" OnClick="btnRefresh_Click">
                                </f:LinkButton>
                            </Items>
                        </f:Panel>--%>
                    </Items>
                </f:SimpleForm>
            </Items>
            <Toolbars>
                <f:Toolbar ID="Toolbar1" runat="server" ToolbarAlign="Center" Position="Bottom">
                    <Items>
                        <f:Button ID="Button1" CssClass="btnlarge" Size="Large" Text="登    錄" Type="Submit" ValidateForms="SimpleForm1" ValidateTarget="Top"
                            runat="server" OnClick="BtnLogin_Click"/>
                    </Items>
                </f:Toolbar>
            </Toolbars>
        </f:Window>
        <f:Image ID="imgCaptcha" runat="server" ImageWidth="100px"
            ImageHeight="32px" Hidden="true">
        </f:Image>
    </form>
</body>
</html>
