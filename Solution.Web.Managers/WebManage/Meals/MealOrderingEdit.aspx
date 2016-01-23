<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MealOrderingEdit.aspx.cs" Inherits="Solution.Web.Managers.WebManage.Meals.MealOrderingEdit" %>

<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <title>訂餐記錄編輯</title>
    <link href="../res/css/main.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .redlabel span {
            color: red;
            font-weight: bold;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">

        <f:PageManager ID="PageManager1" runat="server" EnableFormChangeConfirm="true" />
        <f:Panel ID="Panel1" runat="server" EnableFrame="false" BodyPadding="5px" EnableCollapse="True" ShowHeader="False">
            <Toolbars>
                <f:Toolbar ID="toolBar" runat="server">
                    <Items>
                        <f:Button ID="ButtonSave" runat="server" Text="保存" Icon="Disk" OnClick="ButtonSave_Click" ValidateForms="extForm1"></f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Items>
                <f:Panel ID="Panel2" runat="server" EnableFrame="false" BodyPadding="5px" EnableCollapse="True" ShowHeader="False" ShowBorder="False">
                    <Items>
                        <f:Form ID="extForm1" ShowBorder="false" ShowHeader="false" BodyPadding="5px" runat="server">
                            <Rows>
                                <f:FormRow ID="FormRow1" runat="server">
                                    <Items>
                                        <f:DatePicker runat="server" ID="dpDate" Label="日期" Width="300px" Text="" ShowRedStar="true" />
                                    </Items>
                                </f:FormRow>
                                <f:FormRow ID="FormRow2" runat="server">
                                    <Items>
                                        <f:TriggerBox runat="server" ID="tbxEmp" Label="員工編號" Width="300px" Text="" ShowRedStar="true" EmptyText="請選擇員工"   
                                            MaxLength="50" TriggerIcon="Search" EnablePostBack="true" OnTriggerClick="tbxEmp_TriggerClick"/>
                                        <f:TextBox runat="server" ID="txtEmpName" Label="姓名" Width="300px" Text="" ShowRedStar="true" Readonly="True"
                                            MaxLength="100" />
                                    </Items>
                                </f:FormRow>
                                <f:FormRow ID="FormRow3" runat="server">
                                    <Items>
                                        <f:TextBox runat="server" ID="txtDeptId" Label="部門編號" Width="300px" Text="" ShowRedStar="true" Readonly="True"
                                            MaxLength="50" />
                                        <f:TextBox runat="server" ID="txtDeptName" Label="部門" Width="300px" Text="" ShowRedStar="true" Readonly="True"
                                            MaxLength="100" />
                                    </Items>
                                </f:FormRow>
                                <f:FormRow ID="FormRow4" runat="server">
                                    <Items>
                                        <f:RadioButtonList ID="rblFood" Label="飯類" ColumnNumber="3" runat="server" ShowRedStar="true">
                                        </f:RadioButtonList>
                                    </Items>
                                </f:FormRow>
                                <f:FormRow ID="FormRow6" runat="server">
                                    <Items>
                                        <f:RadioButtonList ID="rblDrink" Label="餐飲" ColumnNumber="3" runat="server" ShowRedStar="true" >
                                        </f:RadioButtonList>
                                    </Items>
                                </f:FormRow>
                                <f:FormRow ID="FormRow5" runat="server">
                                    <Items>
                                        <f:TextArea runat="server" Label="備註" ID="txtRemark"
                                            Height="75px">
                                        </f:TextArea>
                                    </Items>
                                </f:FormRow>
                            </Rows>
                        </f:Form>
                        <f:HiddenField runat="server" ID="hidId" Text="0">
                        </f:HiddenField>
                        <f:HiddenField runat="server" ID="hidCode" Text="">
                        </f:HiddenField>
                    </Items>
                    <Items>
                        <f:Panel ID="Panel5" Layout="HBox" BoxConfigAlign="Stretch" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                            <Items>
                                <f:Label runat="server" Label="錄入" Enabled="false" />
                                <f:Label runat="server" ID="lbuser" Enabled="false" BoxFlex="2" />
                                <f:Label runat="server" ID="lbdate" Enabled="false" BoxFlex="3" />
                            </Items>
                        </f:Panel>
                        <f:Label runat="server" ID="redtips" CssClass="redlabel" Text="注意：當天訂餐系統已鎖定，無法修改和增加當天的訂餐信息！"></f:Label>
                    </Items>
                </f:Panel>
            </Items>
        </f:Panel>
        <br />
        <f:Window ID="Window2" Width="500px" Height="400px" Icon="TagBlue" Title="選擇" Hidden="True"
            EnableMaximize="True" CloseAction="HidePostBack" OnClose="Window2_Close" EnableCollapse="true"
            runat="server" EnableResize="true" BodyPadding="5px" EnableFrame="True" IFrameUrl="about:blank"
            EnableIFrame="true" EnableClose="true" IsModal="True">
        </f:Window>
    </form>
</body>
</html>
