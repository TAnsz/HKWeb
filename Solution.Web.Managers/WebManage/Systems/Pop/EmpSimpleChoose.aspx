<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmpSimpleChoose.aspx.cs" Inherits="Solution.Web.Managers.WebManage.Systems.Pop.EmpSimpleChoose" %>

<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <title>人員選擇</title>
</head>
<body>
    <form id="form1" runat="server">
    <f:pagemanager id="PageManager1" runat="server"/>
    <f:Panel ID="Panel1" runat="server" EnableFrame="false" BodyPadding="10px" EnableCollapse="True" ShowHeader="False">
        <Toolbars>
            <f:Toolbar ID="toolBar" runat="server" CssStyle="position:fixed;">
                <Items>
                    <f:Button ID="ButtonOK" runat="server" Text="確定" Icon="Accept" OnClick="ButtonOK_Click"></f:Button>
                </Items>
            </f:Toolbar>
        </Toolbars>
        <Items>
            <f:Panel ID="Panel2" runat="server" EnableFrame="false" BodyPadding="5px" EnableCollapse="True" ShowHeader="False" ShowBorder="False">
                <Items>
                    <f:TextBox runat="server" ID="txtFind" Label="查找" OnTextChanged="txtFind_TextChanged" AutoPostBack="true" ></f:TextBox>
                    <f:SimpleForm ID="SimpleForm1" ShowBorder="false" ShowHeader="false"
                        AutoScroll="true" BodyPadding="5px" runat="server" EnableCollapse="True">
                        <Items>
                            <f:Tree runat="server" ID="MenuTree" EnableMultiSelect="false"
                                EnableArrows="true" EnableLines="true"></f:Tree>
                            <f:HiddenField runat="server" ID="hEmpid" Text=""></f:HiddenField>
                            <f:HiddenField runat="server" ID="hidId" Text=""></f:HiddenField>
                        </Items>
                    </f:SimpleForm>
                </Items>
            </f:Panel>
        </Items>
    </f:Panel>
    </form>
</body>
</html>
