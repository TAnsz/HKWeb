function extend(defaultObject, extentObject) { //擴展object
    for (var a in extentObject) {
        defaultObject[a] = extentObject[a];
    }
    return defaultObject;
}
var i18n = extend(i18n || {}, {
    xgcalendar: {
        dateformat: {
            "fulldaykey": "yyyyMMdd",
            "fulldayshow": "yyyy年M月d日",
            "fulldayvalue": "yyyy-M-d",
            "Md": "M/d (W)",
            "Md3": "M月d日",
            "AM": "上午",
            "PM": "下午",
            "separator": "-",
            "year_index": 0,
            "month_index": 1,
            "day_index": 2,
            "day": "d日",
            "sun": "週日",
            "mon": "週一",
            "tue": "週二",
            "wed": "週三",
            "thu": "週四",
            "fri": "週五",
            "sat": "週六",
            "jan": "一月",
            "feb": "二月",
            "mar": "三月",
            "apr": "四月",
            "may": "五月",
            "jun": "六月",
            "jul": "七月",
            "aug": "八月",
            "sep": "九月",
            "oct": "十月",
            "nov": "十一月",
            "dec": "十二月"
        },
        "no_implemented": "沒有實現",
        "to_date_view": "點擊轉到該日期的日視圖",
        "i_undefined": "未設置",
        "allday_event": "全天日程",
        "repeat_event": "跨天日程",
        "time": "時  間",
        "event": "會議室",
        "location": "說明",
        "participant": "詳細",
        "get_data_exception": "獲取數據發生異常",
        "new_event": "新會議日程",
        "confirm_delete_event": "確定刪除該會議日程嗎？",
        "confrim_delete_event_or_all": "刪除此序列還是單個事件？\r\n點擊[確定]刪除事件,點擊[取消]刪除序列",
        "data_format_error": "數據格式錯誤！",
        "invalid_title": "日程標題不能為空且不能包含符號($<>)",
        "view_no_ready": "視圖未準備就緒",
        "example": "例如：有個辦公會議",
        "content": "選擇會議室",
        "create_event": "創 建",
        "update_detail": "修改詳細信息",
        "click_to_detail": "點擊查看詳細",
        "i_delete": "刪除",
        "day_plural": "天",
        "others": "另外",
        "item": "個"
    }
});

extend(i18n || {}, {
    datepicker: {
        dateformat: {
            "fulldayvalue": "yyyy-M-d",
            "separator": "-",
            "year_index": 0,
            "month_index": 1,
            "day_index": 2,
            "sun": "日",
            "mon": "一",
            "tue": "二",
            "wed": "三",
            "thu": "四",
            "fri": "五",
            "sat": "六",
            "jan": "一",
            "feb": "二",
            "mar": "三",
            "apr": "四",
            "may": "五",
            "jun": "六",
            "jul": "七",
            "aug": "八",
            "sep": "九",
            "oct": "十",
            "nov": "十一",
            "dec": "十二",
            "postfix": "月"
        },
        ok: " 確定 ",
        cancel: " 取消 ",
        today: "今天",
        prev_month_title: "上一月",
        next_month_title: "下一月"
    }
});
extend(i18n || {}, {
    minicalendar: {
        dateformat: {
            "dateValueFormat": "yyyy-M-d",
            "dateShowFormat": "yyyy年M月",
            "sun": "日",
            "mon": "一",
            "tue": "二",
            "wed": "三",
            "thu": "四",
            "fri": "五",
            "sat": "六",
            "jan": "一",
            "feb": "二",
            "mar": "三",
            "apr": "四",
            "may": "五",
            "jun": "六",
            "jul": "七",
            "aug": "八",
            "sep": "九",
            "oct": "十",
            "nov": "十一",
            "dec": "十二",
            "postfix": "月"
        }
    }
});

