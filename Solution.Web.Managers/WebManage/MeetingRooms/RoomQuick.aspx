<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoomQuick.aspx.cs" Inherits="Solution.Web.Managers.WebManage.MeetingRooms.RoomQuick" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" href="../css/plugin/main.css">
    <link rel="stylesheet" href="../css/form.css">
    <link rel="stylesheet" href="../css/plugin/dp.css">
    <link rel="stylesheet" href="../css/plugin/dropdown.css">
</head>
<body>
    <div class="editPanel">
        <a id="closeDailog" href="javascript:void(0);" class="closeDailog"></a>
        <form id="fmEdit">
            <div class="rowctl">
                <div class="atomctl">
                    <label class="_w90"><span>*</span></label>
                    <input type="text" id="tbSubject" name="Subject" placeholder="placeholder_subject" value="" class="_w400">
                </div>
            </div>
            <div class="rowctl">
                <div class="atomctl">
                    <label class="_w90">&nbsp;              </label>
                    <input type="checkbox" id="cbIsAllDayEvent" name="是否全天事件" value="True" checked="">
                    <label for="cbIsAllDayEvent" class="labelforcb">是否全天事件</label>
                </div>
            </div>
            <div class="rowctl">
                <div class="atomctl">
                    <label class="_w90"><span>*</span></label>
                    <input runat="server" type="text" id="tbStartDate" name="开始日期" value="" class="_w110" />
                    <input runat="server" type="text" id="tbStartTime" name="开始时间" style="width: 35px;" maxlength="5" value="" />
                </div>
                <div class="atomctl">
                    <label style="width: 25px;">到</label>
                    <input runat="server" type="text" id="tbEndDate" name="结束日期" value="" class="_w110" />
                    <input runat="server" type="text" id="tbEndTime" name="结束时间" style="width: 35px;" maxlength="5" value="" />
                </div>
            </div>
            <div class="rowctl">
                <div class="atomctl">
                    <label class="_w90">颜色:</label>
                    <div id="dvcolorpanel" class="colorpanel"></div>
                    <input type="hidden" id="tbCategory" name="Category" value="">
                </div>
            </div>
            <div class="rowctl">
                <div class="atomctl">
                    <label class="_w90">位置:</label>
                    <input type="text" id="tbLocation" name="Location" placeholder="" value="" class="_w400">
                </div>
            </div>
            <div class="rowctl">
                <div class="atomctl">
                    <label class="_w90">说明:</label>
                    <textarea id="tbDescription" name="Description" placeholder="" class="_w400"></textarea>
                </div>
            </div>
            <div class="rowctl">
                <div class="atomctl">
                    <label class="_w90">参加人员:</label>
                    <input type="text" id="tbAttendeeNames" name="AttendeeNames" value="" placeholder="" class="_w400">
                </div>
            </div>
            <div class="rowctl">
                <div class="btnpanel">
                    <button type="submit" class="btn btn-danger" >保存</button>
                    <button id="btnClose" type="button" class="btn">取消</button>
                </div>
            </div>
            <div style="display: none">
                <input type="hidden" id="tbTimeZone" name="TimeZone" runat="server" />
            </div>
            <div style="display: none">
                <input type="hidden" id="Id" name="Id" runat="server" />
            </div>
        </form>
        <script type="text/javascript" src="../Js/sea.js"></script>
        <script type="text/javascript" src="../Js/seaconfig.js"></script>
        <script>
            seajs.use('page/editcal', function (app) {
                app.init();
            });
        </script>
    </div>
</body>
</html>
