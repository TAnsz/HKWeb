<%@ Page Language="C#" ValidateRequest="false" AutoEventWireup="true" CodeBehind="OutWorkRecordEdit.aspx.cs"
    Inherits="Solution.Web.Managers.WebManage.OutWorks.OutWorkRecordEdit" %>

<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <title>請假出差編輯</title>
</head>
<body>
    <form id="form1" runat="server">
        <f:HiddenField runat="server" ID="hbillId" Text="" />
        <f:HiddenField runat="server" ID="hidId" Text="0" />
        <f:HiddenField runat="server" ID="hjId" />
        <f:HiddenField runat="server" ID="hchecker1"></f:HiddenField>
        <f:HiddenField runat="server" ID="hchecker2"></f:HiddenField>
        <f:PageManager ID="PageManager1" runat="server" EnableFormChangeConfirm="true" AutoSizePanelID="Panel1" />
        <f:Panel ID="Panel1" runat="server" EnableFrame="false" BodyPadding="10px" EnableCollapse="True"
            ShowHeader="False">
            <Toolbars>
                <f:Toolbar ID="toolBar" runat="server">
                    <Items>
                        <f:Button ID="ButtonSave" runat="server" Text="保存" Icon="Disk" OnClick="ButtonSave_Click">
                        </f:Button>
                        <f:Button ID="ButtonAccept" runat="server" Text="一級審核" Icon="Accept" OnClick="ButtonAccept_Click">
                        </f:Button>
                        <f:Button ID="ButtonAccept2" runat="server" Text="二級審批" Icon="Accept" OnClick="ButtonAccept2_Click">
                        </f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Items>
                <f:Panel ID="Panel2" runat="server" EnableFrame="false" BodyPadding="5px" EnableCollapse="True"
                    ShowHeader="False" ShowBorder="false">
                    <Items>
                        <f:Form ID="extForm1" ShowBorder="false" ShowHeader="false" BodyPadding="5px" runat="server">
                            <Rows>
                                <f:FormRow ID="FormRow1" runat="server">
                                    <Items>
                                        <f:TriggerBox runat="server" ID="tbxEmp" Label="員工編號" Width="300px" Text="" ShowRedStar="true" EmptyText="請選擇員工"
                                            MaxLength="50" TriggerIcon="Search" EnableEdit="false" OnTriggerClick="tbxEmp_TriggerClick" />
                                        <f:TextBox runat="server" ID="txtEmpName" Label="姓名" Width="300px" Text="" ShowRedStar="true" Readonly="True"
                                            MaxLength="100" />
                                    </Items>
                                </f:FormRow>
                                <f:FormRow ID="FormRow2" runat="server">
                                    <Items>
                                        <f:TextBox runat="server" ID="txtDeptId" Label="部門ID" Width="50px" Text="" Hidden="true"
                                            MaxLength="50" />
                                        <f:TextBox runat="server" ID="txtDept" Label="部門" Width="610px" Text="" Readonly="True"
                                            MaxLength="50" />
                                    </Items>
                                </f:FormRow>
                                <f:FormRow ID="FormRow3" runat="server">
                                    <Items>
                                        <f:DropDownList Label="請假出差類型" AutoPostBack="true" AutoSelectFirstItem="false"
                                            runat="server" ID="ddlOutWorkRecord" Width="300px" ShowRedStar="true" OnSelectedIndexChanged="ddlOutWorkRecord_SelectedIndexChanged">
                                        </f:DropDownList>
                                        <f:TextBox runat="server" ID="txtDays" Label="天數" Width="200px" Text="" Readonly="True"
                                            MaxLength="50" />
                                    </Items>
                                </f:FormRow>
                                <f:FormRow ID="FormRow4" runat="server">
                                    <Items>
                                        <f:DatePicker ID="dpStartTime" Label="開始日期" Width="300px" Required="true" runat="server" AutoPostBack="true"
                                            ShowRedStar="true" OnTextChanged="dpStartTime_TextChanged"/>
                                        <f:DatePicker ID="dpEndTime" Label="結束日期" Width="300px" Required="true" runat="server" 
                                            CompareControl="dpStartTime" CompareOperator="GreaterThanEqual" CompareMessage="结束日期应该大于开始日期" ShowRedStar="true"
                                            AutoPostBack="true" OnTextChanged="dpEndTime_TextChanged"/>
                                    </Items>
                                </f:FormRow>
                                <f:FormRow ID="FormRow11" runat="server">
                                    <Items>
                                        <f:DropDownList Label="時段" AutoPostBack="true"
                                            runat="server" ID="ddlType" ShowRedStar="true" OnSelectedIndexChanged="ddlType_SelectedIndexChanged">
                                            <f:ListItem Text="全天" Value="0" />
                                            <f:ListItem Text="上午" Value="1" />
                                            <f:ListItem Text="下午" Value="2" />
                                            <f:ListItem Text="按時間" Value="3" />
                                        </f:DropDownList>
                                        <f:Panel runat="server" ID="Paneltp" ShowBorder="false" Layout="HBox" Hidden="true">
                                            <Items>
                                                <f:TimePicker runat="server" ID="tpStart" EmptyText="請輸入開始時間" MinTimeText="09:00" MaxTimeText="17:30"
                                                    Increment="30">
                                                </f:TimePicker>
                                                <f:TimePicker runat="server" ID="tpEnd" EmptyText="請輸入結束時間" MinTimeText="09:30" MaxTimeText="18:00" OnTextChanged="dpEndTime_TextChanged"
                                                    Increment="30" CompareControl="tpStart" CompareOperator="GreaterThan" CompareMessage="结束時間应该大于开始時間">
                                                </f:TimePicker>
                                            </Items>
                                        </f:Panel>
                                    </Items>
                                </f:FormRow>
                                <f:FormRow>
                                    <Items>
                                        <f:GroupPanel runat="server" ID="GP1" Title="出差相關信息" Layout="VBox" Hidden="true">
                                            <Items>
                                                <f:Panel runat="server" ID="Paneltrl1" ShowBorder="false" BodyPadding="5px">
                                                    <Items>
                                                        <f:Panel runat="server" ID="Panelt1" ShowBorder="false" Layout="VBox">
                                                            <Items>
                                                                <f:RadioButtonList runat="server" ID="RB1" Width="200px" Label="交通安排">
                                                                    <f:RadioItem Text="自行安排" Value="自行安排" />
                                                                    <f:RadioItem Text="派車" Value="派車" />
                                                                </f:RadioButtonList>
                                                                <f:RadioButtonList runat="server" ID="RB2" Width="200px" Label="接送地點">
                                                                    <f:RadioItem Text="南沙碼頭" Value="南沙碼頭" />
                                                                    <f:RadioItem Text="中山港碼頭" Value="中山港碼頭" />
                                                                </f:RadioButtonList>
                                                                <f:Panel runat="server" ID="Panel7" ShowBorder="false" Layout="Column">
                                                                    <Items>
                                                                        <f:DropDownList runat="server" ID="ddlSt" Label="出發船期" AutoSelectFirstItem="false">
                                                                            <f:ListItem Text="08:00" Value="08:00" />
                                                                            <f:ListItem Text="11:00" Value="11:00" />
                                                                            <f:ListItem Text="13:30" Value="13:30" />
                                                                            <f:ListItem Text="16:15" Value="16:15" />
                                                                        </f:DropDownList>
                                                                        <f:DropDownList runat="server" ID="ddlRe" Label="回程船期" AutoSelectFirstItem="false">
                                                                            <f:ListItem Text="09:15" Value="09:15" />
                                                                            <f:ListItem Text="11:10" Value="11:10" />
                                                                            <f:ListItem Text="16:00" Value="16:00" />
                                                                            <f:ListItem Text="18:00" Value="18:00" />
                                                                        </f:DropDownList>
                                                                        <f:NumberBox runat="server" ID="nbPeers" MaxValue="20" MinValue="0" NoDecimal="true" NoNegative="True" Label="人數"></f:NumberBox>
                                                                    </Items>
                                                                </f:Panel>
                                                                <f:TextArea runat="server" ID="txtRemark" Label="備注" AutoGrowHeight="true"></f:TextArea>
                                                                <f:Panel runat="server" ID="Panel3" ShowBorder="false" Layout="Column">
                                                                    <Items>
                                                                        <f:CheckBox runat="server" ID="cbxHostel" Text="安排宿舍,幾晚"></f:CheckBox>
                                                                        <f:NumberBox runat="server" ID="nbhotel" MaxValue="20" MinValue="0" NoDecimal="true" NoNegative="True" Width="100px"></f:NumberBox>
                                                                    </Items>
                                                                </f:Panel>
                                                            </Items>
                                                        </f:Panel>
                                                    </Items>
                                                </f:Panel>
                                                <f:Form ID="Form2" Layout="VBox" BoxConfigAlign="Stretch" LabelAlign="Top" BodyPadding="5px" ShowBorder="false" ShowHeader="false" runat="server">
                                                    <Items>
                                                        <f:Panel runat="server" ID="Panel4" ShowBorder="false" Layout="HBox" Width="600px">
                                                            <Items>
                                                                <f:TextBox runat="server" ID="txtA1" BoxFlex="2" Label="目的地"></f:TextBox>
                                                                <f:TextBox runat="server" ID="txtB1" BoxFlex="1" Label="日期"></f:TextBox>
                                                                <f:TextBox runat="server" ID="txtC1" BoxFlex="1" Label="總天數"></f:TextBox>
                                                            </Items>
                                                        </f:Panel>
                                                        <f:Panel runat="server" ID="Panel5" ShowBorder="false" Layout="HBox">
                                                            <Items>
                                                                <f:TextBox runat="server" ID="txtA2" BoxFlex="2" ShowLabel="false"></f:TextBox>
                                                                <f:TextBox runat="server" ID="txtB2" BoxFlex="1" ShowLabel="false"></f:TextBox>
                                                                <f:TextBox runat="server" ID="txtC2" BoxFlex="1" ShowLabel="false"></f:TextBox>
                                                            </Items>
                                                        </f:Panel>
                                                        <f:Panel runat="server" ID="Panel6" ShowBorder="false" Layout="HBox">
                                                            <Items>
                                                                <f:TextBox runat="server" ID="txtA3" BoxFlex="2" ShowLabel="false"></f:TextBox>
                                                                <f:TextBox runat="server" ID="txtB3" BoxFlex="1" ShowLabel="false"></f:TextBox>
                                                                <f:TextBox runat="server" ID="txtC3" BoxFlex="1" ShowLabel="false"></f:TextBox>
                                                            </Items>
                                                        </f:Panel>
                                                        <f:Panel runat="server" ID="Panel8" ShowBorder="false" Layout="HBox">
                                                            <Items>
                                                                <f:TextBox runat="server" ID="txtA4" BoxFlex="2" ShowLabel="false"></f:TextBox>
                                                                <f:TextBox runat="server" ID="txtB4" BoxFlex="1" ShowLabel="false"></f:TextBox>
                                                                <f:TextBox runat="server" ID="txtC4" BoxFlex="1" ShowLabel="false"></f:TextBox>
                                                            </Items>
                                                        </f:Panel>
                                                    </Items>
                                                </f:Form>
                                            </Items>
                                        </f:GroupPanel>
                                    </Items>
                                </f:FormRow>
                                <f:FormRow ID="FormRow7" runat="server">
                                    <Items>
                                        <f:TextBox runat="server" ID="txtchecker" Label="一級審批人" Width="300px" Readonly="True"/>
                                        <f:TextBox runat="server" ID="txtchecker2" Label="二級審批人" Width="300px" Readonly="True"/>
                                    </Items>
                                </f:FormRow>
                                <f:FormRow ID="FormRow8" runat="server">
                                    <Items>
                                        <f:CheckBox ID="cbIsCheck1" Label="是否一級審批" runat="server" Readonly="True"
                                            Width="300px">
                                        </f:CheckBox>
                                        <f:CheckBox ID="cbIsCheck2" Label="是否二級審批" runat="server" Readonly="True"
                                            Width="300px">
                                        </f:CheckBox>
                                    </Items>
                                </f:FormRow>
                                <f:FormRow ID="FormRow5" runat="server">
                                    <Items>
                                        <f:TextArea runat="server" Label="原因" ID="txtMemo" Width="610px" CssStyle="margin-bottom:0;"
                                            AutoGrowHeight="true">
                                        </f:TextArea>
                                    </Items>
                                </f:FormRow>
                            </Rows>
                        </f:Form>
                    </Items>
                </f:Panel>
            </Items>
        </f:Panel>
        <f:Window ID="Window2" Width="500px" Height="400px" Icon="TagBlue" Title="選擇" Hidden="True"
            EnableMaximize="True" CloseAction="HidePostBack" OnClose="Window2_Close" EnableCollapse="true"
            runat="server" EnableResize="true" BodyPadding="5px" EnableFrame="True" IFrameUrl="about:blank"
            EnableIFrame="true" EnableClose="true" IsModal="True">
        </f:Window>
    </form>
</body>
</html>
