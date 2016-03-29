<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoomMomentCal.aspx.cs" Inherits="Solution.Web.Managers.WebManage.MeetingRooms.RoomMomentCal" %>

<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <title>會議室使用列表</title>
    <%--<link href="../Css/common.css" rel="stylesheet" />--%>
    <link href="../Css/plugin/calendar.css" rel="stylesheet" />
    <%--<link href="../Css/plugin/dailog.css" rel="stylesheet" />--%>
    <%--<link href="../Css/plugin/dp.css" rel="stylesheet" />--%>
    <%--<link href="../Css/plugin/dropdown.css" rel="stylesheet" />--%>
    <link href="../Css/plugin/minical.css" rel="stylesheet" />
    <link href="../Css/plugin/main.css" rel="stylesheet" />
    <link href="../Css/plugin/ui-select.css" rel="stylesheet" />
    <%--<link href="../Css/form.css" rel="stylesheet" />--%>
    <style>
        .cals div {
            box-sizing: content-box;
            -webkit-box-sizing: content-box;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server" AutoSizePanelID="Panel1" />
        <f:Panel ID="Panel1" runat="server" Title="會議室使用列表" EnableFrame="false" BodyPadding="10px"
            EnableCollapse="True" AutoScroll="true">
            <Toolbars>
                <f:Toolbar ID="toolBar" runat="server">
                    <Items>
                        <f:Button ID="ButtonRefresh" runat="server" Text="刷新" Icon="ArrowRefresh" OnClick="ButtonRefresh_Click" CssClass="inline"></f:Button>
                        <f:Button ID="ButtonSearch" runat="server" Text="查詢" Icon="Magnifier" OnClick="ButtonSearch_Click"></f:Button>
                        <f:Button ID="ButtonAdd" runat="server" Text="添加" Icon="Add" OnClick="ButtonAdd_Click"></f:Button>
                        <f:Button ID="ButtonPrint" runat="server" Text="列印" Icon="printer" EnablePostBack="false" OnClientClick="printdiv()"></f:Button>

                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Items>
                <%--<f:SimpleForm ID="SimpleForm1" BodyPadding="5px" runat="server" EnableFrame="false" EnableCollapse="true"
                    ShowBorder="True" ShowHeader="False">
                    <Items>
                        <f:DropDownList runat="server" Label="選擇會議室" ID="ddlRoom" Width="260px" EmptyText="請選擇會議室" AutoSelectFirstItem="false"/>
                    </Items>
                </f:SimpleForm>--%>
                <f:ContentPanel runat="server" ID="cp1">
                    <div id="mainpanel" class="cals">
                        <div id="toppanel">
                            <div id="loadingpannel" style="display: none;">操作成功!</div>
                            <div id="errorpannel" style="display: none;">非常抱歉，无法加载您的活动，请稍后再试</div>
                            <p class="logo">會議室日程安排</p>
                            <div class="calbtnp1">
                                <button class="btn" id="todaybtn" type="button">今天</button>
                                <div class="btngroup">
                                    <span class="btn prevbtn" id="prevbtn" type="button"><em></em></span>
                                    <span class="btn nextbtn" id="nextbtn" type="button"><em></em></span>
                                </div>
                                <div id="dateshow"></div>
                            </div>
                            <%--<div class="calbtnp3">
                                <div>
                                    <a id="langch" href="?lang=zh-cn">中文</a>
                                    <span>|</span>
                                    <a id="langen" href="?lang=en-us">English</a>
                                </div>
                            </div>--%>
                            <div class="calbtnp2">
                                <div class="btngroup" id="viewswithbtn">
                                    <button class="btn" id="daybtn" type="button">
                                        日                       
                                    </button>
                                    <button class="btn current" id="weekbtn" type="button">
                                        周                       
                                    </button>
                                    <button class="btn" id="monthbtn" type="button">
                                        月                       
                                    </button>
                                </div>
                            </div>
                        </div>
                        <div id="leftpanel">
                            <%--<div class="addbtnp">
                                <button class="btn btn-danger" id="addcalbtn" type="button">
                                    新建                   
                                </button>
                            </div>--%>
                            <div class="minical minicalendar" id="minical"></div>
                        </div>
                        <div id="rightpanel">
                            <div id="xgcalendarp"></div>
                        </div>
                    </div>
                </f:ContentPanel>
            </Items>
        </f:Panel>
        <f:Window ID="Window1" Width="520px" Height="500px" Icon="TagBlue" Title="編輯" Hidden="True"
            EnableMaximize="True" CloseAction="HidePostBack" OnClose="Window1_Close" EnableCollapse="true"
            runat="server" EnableResize="true" BodyPadding="5px" EnableFrame="True" IFrameUrl="about:blank"
            EnableIFrame="true" EnableClose="true" IsModal="True">
        </f:Window>
    </form>
    <script src="../Js/sea.js"></script>
    <script src="../Js/seaconfig.js?0004"></script>
    <script type="text/javascript">
        var loadingmsg = '數據加載中，請稍後...';
        var sucessmsg = '數據加載成功';
        var processdatamsg = '查詢中...';
        seajs.use('page/index', function (app) {
            app.init();
        });
        function ShowWindow(url) {
            F('<% =Window1.ClientID %>').f_show(url, '編輯', 520, 500);
        }
        function printdiv() {
            $("#xgcalendarp").jqprint();
            //var headstr = "<html><head><title></title></head><body>";  
            //var footstr = "</body>";  
            //var printData = document.getElementById("xgcalendarp").innerHTML;
            //var oldstr = document.body.innerHTML;  
            //document.body.innerHTML = headstr + printData + footstr;
            //window.print();  
            //document.body.innerHTML = oldstr;  

            //var cssStr = '<link href="../Css/plugin/calendar.css" rel="stylesheet" />';
            //var newWindow = window.open("打印窗口", "_blank");//打印窗口要换成页面的url
            //var docStr = document.getElementById("xgcalendarp").innerHTML;
            //newWindow.document.write(cssStr + docStr);
            //newWindow.document.close();
            //newWindow.print();
            //newWindow.close();

        }

    </script>

</body>
</html>
