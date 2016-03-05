<%@ Page Language="C#" ValidateRequest="false" AutoEventWireup="true" CodeBehind="InformationEdit.aspx.cs" Inherits="Solution.Web.Managers.WebManage.Informations.InformationEdit" %>

<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <title>信息編輯</title>
    <link rel="stylesheet" type="text/css" href="../Css/main.css" />
    <script type="text/javascript" src="../Js/jquery-1.6.4.min.js"></script>
    <script type="text/javascript" src="../Js/tools.js"></script>
    <script type="text/javascript" src="../Js/ke4/kindeditor-min.js" charset="utf-8"></script>
    <script type="text/javascript">
        var oFCKeditor1 = null;

        $(document).ready(function () {
            setTimeout(function () { New_Editor() }, 300);
        });

        function New_Editor() {
            var key = $('#txtRndKey-inputEl').val();
            if (key) {
                $('#FCKeditor1').val($('#txtText-inputEl').val());
                $('#FCKeditor1___UpFileList').val(decodeURIComponent($('#txtUpload-inputEl').val()));
                //下一行執行的Js函數CreateKindEditor('FCKeditor1', x, key)中，其中x代表的是上傳配置表（UploadConfig）中對應的記錄Id
                oFCKeditor1 = CreateKindEditor('FCKeditor1', 4, key);
            } else {
                setTimeout(function () { New_Editor() }, 3000);
            }
        }

        //編輯器提交必須調用
        function Keditor_GetHtml() {
            var html = oFCKeditor1.html();
            $('#txtText-inputEl').val(html);
            $('#txtUpload-inputEl').val($('#FCKeditor1___UpFileList').val());
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server" EnableFormChangeConfirm="true" AutoSizePanelID="Panel1" />
        <f:Panel ID="Panel1" runat="server" EnableFrame="false" BodyPadding="5px" EnableCollapse="True" ShowHeader="False">
            <Toolbars>
                <f:Toolbar ID="toolBar" runat="server">
                    <Items>
                        <f:Button ID="ButtonSave" runat="server" Text="保存" Icon="Disk" OnClick="ButtonSave_Click" OnClientClick="Keditor_GetHtml();">
                        </f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Items>
                <f:Panel ID="Panel2" runat="server" EnableFrame="false" BodyPadding="5px" EnableCollapse="True" AutoScroll="true"
                    ShowHeader="False" ShowBorder="False">
                    <Items>
                        <f:Form ID="extForm1" ShowBorder="false" ShowHeader="false" BodyPadding="5px" runat="server">
                            <Rows>
                                <f:FormRow ID="FormRow1" runat="server">
                                    <Items>
                                        <f:TextBox runat="server" ID="txtTitle" Label="文章標題" Width="300px" Text=""
                                            ShowRedStar="true" Required="true" MaxLength="100" />
                                        <f:DropDownList Label="所屬欄目" AutoPostBack="true" ShowRedStar="true" Required="true"
                                            CompareType="String" EnableSimulateTree="true" runat="server" ID="ddlInformationClass_Id"
                                            Width="300px" />
                                    </Items>
                                </f:FormRow>
                                <f:FormRow ID="FormRow2" runat="server">
                                    <Items>
                                        <f:TextBox runat="server" ID="txtAuthor" Label="發佈人" Width="300px" Text=""
                                            MaxLength="50" />
                                        <f:Panel runat="server" ShowBorder="false" Layout="HBox" >
                                            <Items>
                                                <f:DatePicker ID="dpNewsTime" Label="起止時間" Required="true" runat="server"  Width="235px"/>
                                                <f:DatePicker runat="server" ID="dpEndTime" Width="130px" EmptyText="請輸入結束日期" CompareControl="dpNewsTime" Margin="0 5px"
                                                    CompareOperator="GreaterThan" CompareMessage="结束時間应该大于發佈時間">
                                                </f:DatePicker>
                                            </Items>
                                        </f:Panel>
                                    </Items>
                                </f:FormRow>
                                <f:FormRow ID="FormRow11" runat="server">
                                    <Items>
                                        <f:RadioButtonList ID="rblIsDisplay" Label="是否顯示" ColumnNumber="2" runat="server" Width="300px">
                                            <f:RadioItem Text="顯示" Value="1" Selected="true" />
                                            <f:RadioItem Text="不顯示" Value="0" />
                                        </f:RadioButtonList>
                                        <f:RadioButtonList ID="rblIsTop" Label="是否置頂" ColumnNumber="2" runat="server" Width="300px">
                                            <f:RadioItem Text="是" Value="1" />
                                            <f:RadioItem Text="否" Value="0" Selected="true" />
                                        </f:RadioButtonList>
                                    </Items>
                                </f:FormRow>
                                <f:FormRow ID="FormRow7" runat="server">
                                    <Items>
                                        <f:TextArea runat="server" ID="txtNotes" Label="內容簡介" Width="716px" Text=""
                                            MaxLength="200" Height="50px" />
                                    </Items>
                                </f:FormRow>
                                <f:FormRow ID="FormRow4" runat="server">
                                    <Items>
                                        <f:ContentPanel ID="ContentPanel1" runat="server" Width="800px" Height="370px"
                                            ShowBorder="false" ShowHeader="false">
                                            <textarea name="FCKeditor1" id="FCKeditor1" style="width: 100%; height: 360px; display: none;"></textarea>
                                            <input type="hidden" id="FCKeditor1___UpFileList" name="FCKeditor1___UpFileList"
                                                value="" />
                                        </f:ContentPanel>
                                    </Items>
                                </f:FormRow>
                            </Rows>
                        </f:Form>
                    </Items>
                </f:Panel>
            </Items>
        </f:Panel>
        <!--編輯器提交必須調用的控件-->
        <f:TextBox runat="server" ID="txtText" Text="" Hidden="true" />
        <f:TextBox runat="server" ID="txtUpload" Text="" Hidden="true" />
        <f:TextBox runat="server" ID="txtRndKey" Text="" Hidden="true" />
        <f:HiddenField runat="server" ID="hidId" Text="0">
        </f:HiddenField>
    </form>
</body>
</html>
