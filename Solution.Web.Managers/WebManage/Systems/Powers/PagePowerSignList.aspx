<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PagePowerSignList.aspx.cs"
    Inherits="Solution.Web.Managers.WebManage.Systems.Powers.PagePowerSignList" %>

<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <title>頁面控件權限標識管理</title>
</head>
<body>
    <form id="form1" runat="server">
    <f:pagemanager id="PageManager1" runat="server" />
    <f:panel id="Panel2" runat="server" width="870px" showborder="True"
        enableframe="false" enablecollapse="true" bodypadding="5px" layout="Column" showheader="True"
        title="頁面控件權限標識管理">
        <items>
        <f:Panel ID="Panel1" Width="250px" runat="server" BodyPadding="5px" ShowBorder="False" ShowHeader="false">
            <Items>
                <f:Tree runat="server" Title="菜單樹列表" ShowBorder="True" ShowHeader="True" EnableArrows="False" AutoLeafIdentification="false"
                    EnableLines="true" ID="MenuTree" OnNodeCommand="MenuTree_NodeCommand">
                </f:Tree>
            </Items>
        </f:Panel>
        <f:Panel ID="Panel4" Title="頁面權限說明" Width="600px" runat="server" BodyPadding="10px" ShowBorder="False" ShowHeader="True">
            <Items>
                <f:Label ID="labelClassDesc" runat="server" Text="頁面權限指的是頁面中的那些按鍵或鏈接，在這裡可以將這些按鍵與頁面綁定在一起，
                未綁定的頁面控件，默認用戶無操作權限（按鍵處於禁用狀態），只有綁定後才能在職位（角色）編輯時賦予其操作權限。
                在綁定頁面按鍵權限時，左欄樹列表中的頁面類型菜單才可以綁定頁面控件。">
                </f:Label>
                <f:HiddenField runat="server" ID="hidId" Text="0"></f:HiddenField>
            </Items>
        </f:Panel>
        <f:Panel ID="Panel9" Width="600px" Title="頁面控件權限管理" runat="server" BodyPadding="10px" ShowBorder="False" ShowHeader="True" Layout="Column">
            <Items>
                <f:Panel ID="Panel5" Width="200px" ShowHeader="false" BodyPadding="10px" ShowBorder="false" runat="server">
                    <Items>
                        <f:Grid ID="Grid1" Title="公用頁面權限標識列表" EnableFrame="false" EnableCollapse="true"
                            ShowBorder="true" ShowHeader="False" AllowPaging="False" runat="server" DataKeyNames="Id" Width="180px" Height="300px">
                                <Columns>
                                    <f:BoundField Width="150px" DataField="Cname" SortField="CName" HeaderText="未綁定控件列表"  />
                                </Columns>
                            </f:Grid>
                    </Items>
                </f:Panel>
                <f:Panel ID="Panel7" Width="50px" Height="300px" ShowHeader="false" ShowBorder="false" runat="server" Layout="VBox">
                    <Items>
                        <f:Label runat="server" Height="70px"></f:Label>
                        <f:Button ID="ButtonEmpower" runat="server" Text="&nbsp; > > &nbsp;" OnClick="ButtonEmpower_Click"></f:Button>
                        <f:Label runat="server" Height="20px"></f:Label>
                        <f:Button ID="ButtonCancel" runat="server" Text="&nbsp; < < &nbsp;" OnClick="ButtonCancel_Click"></f:Button>
                        <f:Label runat="server" Height="20px"></f:Label>
                        <f:Button ID="ButtonEmpty" runat="server" Text="清 空" OnClick="ButtonEmpty_Click"></f:Button>
                    </Items>
                </f:Panel>
                <f:Panel ID="Panel6" Width="200px" ShowHeader="false" BodyPadding="10px" ShowBorder="false" runat="server">
                    <Items>
                            <f:Grid ID="Grid2" Title="公用頁面權限標識列表" EnableFrame="false" EnableCollapse="true"
                            ShowBorder="true" ShowHeader="False" AllowPaging="False" runat="server" DataKeyNames="Id" Width="180px" Height="300px">
                                <Columns>
                                    <f:BoundField Width="150px" DataField="Cname" SortField="CName" HeaderText="已綁定控件列表"  />
                                </Columns>
                            </f:Grid>
                    </Items>
                </f:Panel>
            </Items>
        </f:Panel>
        </items>
    </f:panel>
    </form>
</body>
</html>
