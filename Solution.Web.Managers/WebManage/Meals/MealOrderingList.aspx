<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MealOrderingList.aspx.cs" Inherits="Solution.Web.Managers.WebManage.Meals.MealOrderingList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>會議室列表</title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server" />
        <f:Panel ID="Panel1" runat="server" Title="菜單(頁面)列表" EnableFrame="false" BodyPadding="10px"
            EnableCollapse="True">
            <Toolbars>
                <f:Toolbar ID="toolBar" runat="server">
                    <Items>
                        <f:Button ID="ButtonRefresh" runat="server" Text="刷新" Icon="ArrowRefresh" OnClick="ButtonRefresh_Click" CssClass="inline"></f:Button>
                        <f:Button ID="ButtonSearch" runat="server" Text="查詢" Icon="Magnifier" OnClick="ButtonSearch_Click"></f:Button>
                        <f:Button ID="ButtonAdd" runat="server" Text="添加" Icon="Add" OnClick="ButtonAdd_Click"></f:Button>
                        <f:Button ID="ButtonEdit" runat="server" Text="編輯" Icon="BulletEdit" OnClick="ButtonEdit_Click"
                            OnClientClick="if(!F('Panel1_Grid1').getSelectionModel().hasSelection()|| F('Panel1_Grid1').getSelectionModel().getCount()>=2){F.alert('您沒有選擇編輯項或只能選擇一項進行編輯！'); return false; }">
                        </f:Button>
                        <f:Button ID="ButtonDelete" runat="server" Text="刪除" Icon="Delete" OnClick="ButtonDelete_Click" ConfirmTitle="刪除提示" ConfirmText="是否刪除記錄？"
                            OnClientClick="if (!F('Panel1_Grid1').getSelectionModel().hasSelection() ) { F.alert('刪除時必須選擇一條將要刪除的記錄！'); return false; }  if (F('Panel1_Grid1').getSelectionModel().getCount() >= 2) { F.alert('只能選擇一條記錄進行刪除！');return false; }">
                        </f:Button>
                        <f:Button ID="ButtonPrint" runat="server" Text="列印" Icon="printer" EnablePostBack="false" OnClientClick="ShowWindow()"></f:Button>
                        <f:Button ID="Button1" runat="server" Text="查看菜單" Icon="printer" EnablePostBack="false" OnClientClick="window.open('../../UploadFile/menu.jpg')"></f:Button>
                        <f:FileUpload runat="server" ID="filePhoto" ButtonText="上传菜單" AcceptFileTypes="image/*.jpg" ButtonOnly="true"
                            AutoPostBack="true" OnFileSelected="filePhoto_FileSelected">
                        </f:FileUpload>
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Items>
                <f:Form ID="extForm1" BodyPadding="5px" runat="server" EnableFrame="false" EnableCollapse="true"
                    ShowBorder="True" ShowHeader="False">
                    <Rows>
                        <f:FormRow>
                            <Items>
                                <f:TextBox runat="server" ID="txtName" Label="員工編號" Width="260px" Text="" />
                                <f:DatePicker runat="server" Label="查詢日期" ID="dpStart" DateFormatString="yyyy-MM-dd" Width="260px" EmptyText="查詢指定日期後記錄" />
                                <f:Label runat="server"></f:Label>
                            </Items>
                        </f:FormRow>
                    </Rows>
                </f:Form>
                <f:Grid ID="Grid1" Title="訂餐列表" EnableFrame="false" EnableCollapse="true" AllowSorting="true" SortField="Id" SortDirection="DESC"
                    PageSize="15" ShowBorder="true" ShowHeader="False" runat="server" EnableCheckBoxSelect="True" DataKeyNames="Id" EnableColumnLines="true"
                    OnPageIndexChange="Grid1_PageIndexChange" OnPreRowDataBound="Grid1_PreRowDataBound" OnRowCommand="Grid1_RowCommand">
                    <Columns>
                        <f:RowNumberField />
                        <f:BoundField DataField="Id" HeaderText="ID" Hidden="True" />
                        <f:BoundField Width="100px" DataField="Code" SortField="Code" HeaderText="編號" />
                        <f:BoundField Width="100px" DataField="ApplyDate" SortField="ApplyDate" HeaderText="申請日期" DataFormatString="{0:yyyy-MM-dd}" />
                        <f:BoundField Width="100px" DataField="Employee_EmpId" SortField="Employee_EmpId" HeaderText="申請人編號" />
                        <f:BoundField Width="150px" DataField="Employee_Name" SortField="Employee_Name" HeaderText="申請人" />
                        <f:BoundField Width="100px" DataField="DepartId" SortField="DepartId" HeaderText="部門編號" />
                        <f:BoundField Width="150px" DataField="DepartName" SortField="DepartName" HeaderText="部門名稱" />
                        <f:BoundField Width="100px" DataField="FoodCode" SortField="FoodCode" HeaderText="飯類" />
                        <f:BoundField Width="100px" DataField="DrinkCode" SortField="DrinkCode" HeaderText="餐飲" />
                        <f:BoundField Width="200px" DataField="Remark" HeaderText="備註" />
                        <f:LinkButtonField HeaderText="是否有效" Icon="BulletCross" TextAlign="Center" ToolTip="點擊修改是否有效" ColumnID="IsVaild" CommandName="IsVaild" />
                        <f:LinkButtonField HeaderText="操作" TextAlign="Center" ToolTip="點擊修改當前記錄" ColumnID="ButtonEdit" CommandName="ButtonEdit" />
                    </Columns>
                </f:Grid>
                <f:Label runat="server" ID="lblSpendingTime" Text=""></f:Label>
            </Items>
        </f:Panel>
        <f:Window ID="Window1" Width="800px" Height="450px" Icon="TagBlue" Title="編輯" Hidden="True"
            EnableMaximize="True" CloseAction="HidePostBack" OnClose="Window1_Close" EnableCollapse="true"
            runat="server" EnableResize="true" BodyPadding="5px" EnableFrame="True" IFrameUrl="about:blank"
            EnableIFrame="true" EnableClose="true" IsModal="True" >
        </f:Window>
        <f:Window ID="Window2" Width="800px" Height="700px" Icon="TagBlue" Title="列印" Hidden="True"
            EnableMaximize="True" CloseAction="HidePostBack" OnClose="Window1_Close" EnableCollapse="true"
            runat="server" EnableResize="true" BodyPadding="5px" EnableFrame="True" IFrameUrl="about:blank"
            EnableIFrame="true" EnableClose="true" IsModal="True" >
        </f:Window>
    </form>
    <script>
        function ShowWindow() {
            F('<% =Window2.ClientID %>').f_show('./Report.aspx', '列印', 800, 700);
        }
    </script>
</body>
</html>
