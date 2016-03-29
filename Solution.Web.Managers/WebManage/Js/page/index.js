define(function (require, exports, module) {
    //参数名字不能改
    require("locales/zh-tw");
    var minicalendar = require("../plugin/minicalendar");
    require("plugin/xgcalendar");
    require("plugin/ui-select");
    require("jqmigrate");
    require("jqprint");
    exports.init = function () {
        var minical = new minicalendar({
            onchange: datechange
        });
        minical.init("#minical");
        var dataFeedUrl = "RoomData.ashx";
        var key = decodeURI(window.location.search);
        var op = {
            view: "week",
            theme: 1,
            autoload: true,
            //
            showday: new Date(),
            EditCmdhandler: edit,
            //DeleteCmdhandler:dcal,
            ViewCmdhandler: view,
            onWeekOrMonthToDay: wtd,
            onBeforeRequestData: cal_beforerequest,
            onAfterRequestData: cal_afterrequest,
            onRequestDataError: cal_onerror,
            url: dataFeedUrl + "?Method=List",
            quickAddUrl: dataFeedUrl + "?Method=Update",
            quickUpdateUrl: dataFeedUrl + "?Method=Update",
            quickDeleteUrl: dataFeedUrl + "?Method=Del",
            //快速删除日程的
            /* timeFormat:" hh:mm t", //t表示上午下午标识,h 表示12小时制的小时，H表示24小时制的小时,m表示分钟
            tgtimeFormat:"ht" //同上 */
            stime: 8,
            etime: 19,
            ClickCmdhandler: roomlist
        };
        // var _MH = document.documentElement.clientHeight;
        op.height = 600;
        // _MH - 200;
        op.eventItems = [];
        var p = $("#xgcalendarp").bcalendar(op).BcalGetOp();
        if (p && p.datestrshow) {
            $("#dateshow").text(p.datestrshow);
        }
        //$("#addcalbtn").click(function () {
        //    OpenModalDialog(dataFeedUrl + "?Method=Add", {
        //        caption: "创建活动", width: 580, height: 460, onclose: function () {
        //            $("#xgcalendarp").BCalReload();
        //        }
        //    });
        //});
        $("#daybtn").click(function () {
            switchview.call(this, "day");
        });
        $("#weekbtn").click(function () {
            switchview.call(this, "week");
        });
        $("#monthbtn").click(function () {
            switchview.call(this, "month");
        });
        $("#prevbtn").click(function () {
            var p = $("#xgcalendarp").BCalPrev().BcalGetOp();
            if (p && p.datestrshow) {
                $("#dateshow").text(p.datestrshow);
            }
        });
        $("#nextbtn").click(function () {
            var p = $("#xgcalendarp").BCalNext().BcalGetOp();
            if (p && p.datestrshow) {
                $("#dateshow").text(p.datestrshow);
            }
        });
        $("#todaybtn").click(function (e) {
            var p = $("#xgcalendarp").BCalGoToday().BcalGetOp();
            if (p && p.datestrshow) {
                $("#dateshow").text(p.datestrshow);
            }
        });
        function switchview(view) {
            $("#viewswithbtn button.current").each(function () {
                $(this).removeClass("current");
            });
            $(this).addClass("current");
            var p = $("#xgcalendarp").BCalSwtichview(view).BcalGetOp();
            if (p && p.datestrshow) {
                $("#dateshow").text(p.datestrshow);
            }
        }
        function datechange(r) {
            var p = $("#xgcalendarp").BCalGoToday(r).BcalGetOp();
            if (p && p.datestrshow) {
                $("#dateshow").text(p.datestrshow);
            }
        }
        function cal_beforerequest(type) {
            var t = loadingmsg;
            switch (type) {
                case 1:
                    t = loadingmsg;
                    break;

                case 2:
                case 3:
                case 4:
                    t = processdatamsg;
                    break;
            }
            $("#errorpannel").hide();
            $("#loadingpannel").html(t).show();
        }
        function cal_afterrequest(type) {
            switch (type) {
                case 1:
                    $("#loadingpannel").hide();
                    break;

                case 2:
                case 3:
                case 4:
                    $("#loadingpannel").html(sucessmsg);
                    window.setTimeout(function () {
                        $("#loadingpannel").hide();
                    }, 2e3);
                    break;
            }
        }
        function cal_onerror(type, data) {
            $("#errorpannel").html(data.Msg).show();
        }
        function edit(data) {
            if (data) {
                var url = StrFormat("MeetingRoomApplyEdit.aspx" + key + "&calId={0}&start={2}&end={3}&isallday={4}&title={1}", data);
                ShowWindow(url);
            }
        }
        function view(data) {
            if (data) {
                var url = StrFormat("MeetingRoomApplyEdit.aspx" + key + "&calId={0}", data);
                ShowWindow(url);
            }
        }
        function dcal(data, callback) { }
        function wtd(p) {
            if (p && p.datestrshow) {
                $("#txtdatetimeshow").text(p.datestrshow);
            }
            $("#viewswithbtn button.current").each(function () {
                $(this).removeClass("current");
            });
            $("#daybtn").addClass("current");
        }
        function GetQueryString(name) {
            var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
            var r = window.location.search.substr(1).match(reg);
            if (r != null) return unescape(r[2]);
            return null;
        }
        function roomlist() {
            $.get("RoomData.ashx" + "?Method=GetRoomList", function (data) {
                $("#bbit-cal-what").append(data);
                $(".ui-select").ui_select();
            }, "text");
        }
    };
});