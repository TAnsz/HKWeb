/// <summary>
/// 類說明：Assistant
/// 編 碼 人：蘇飛
/// 聯繫方式：361983679  
/// 更新網站：http://www.sufeinet.com/thread-655-1-1.html
/// </summary>

using System;
using System.Globalization;

namespace DotNet.Utilities
{
    /// <summary>
    ///	BUBaseAppMessage
    /// </author> 
    /// </summary>
    public class AppMessage
    {
        /// <summary>
        /// 提示信息.
        /// </summary>
        public static string MSG0000 = "提示信息";

        /// <summary>
        /// 發生未知錯誤.
        /// </summary>
        public static string MSG0001 = "發生未知錯誤。";

        /// <summary>
        /// 數據庫聯接不正常.
        /// </summary>
        public static string MSG0002 = "數據庫聯接不正常。";

        /// <summary>
        /// WebService聯接不正常.
        /// </summary>
        public static string MSG0003 = "WebService 聯接不正常。";

        /// <summary>
        /// 任何數據未被修改.
        /// </summary>
        public static string MSG0004 = "任何數據未被修改。";

        /// <summary>
        /// 記錄未找到,可能已被其他人刪除.
        /// </summary>
        public static string MSG0005 = "記錄未找到，可能已被其他人刪除。";

        /// <summary>
        /// 數據已被其他人修改,請按F5鍵,重新刷新獲得數據.
        /// </summary>
        public static string MSG0006 = "數據已被其他人修改,請按F5鍵,重新刷新獲得數據。";

        /// <summary>
        /// '{O}'不允許為空,請輸入.
        /// </summary>
        public static string MSG0007 = "{0} 不允許為空，請輸入。";

        /// <summary>
        /// {0} 已存在,不可以重複.
        /// </summary>
        public static string MSG0008 = "{0} 已存在，不可以重複。";

        /// <summary>
        /// 新增成功.
        /// </summary>
        public static string MSG0009 = "新增成功。";

        /// <summary>
        /// 更新成功.
        /// </summary>
        public static string MSG0010 = "更新成功。";

        /// <summary>
        /// 保存成功.
        /// </summary>
        public static string MSG0011 = "保存成功。";

        /// <summary>
        /// 批量保存成功.
        /// </summary>
        public static string MSG0012 = "批量保存成功。";

        /// <summary>
        /// 刪除成功.
        /// </summary>
        public static string MSG0013 = "刪除成功。";

        /// <summary>
        /// 批量刪除成功.
        /// </summary>
        public static string MSG0014 = "批量刪除成功。";

        /// <summary>
        /// 您確認刪除嗎?
        /// </summary>
        public static string MSG0015 = "您確認刪除嗎？";

        /// <summary>
        /// 您確認刪除 '{0}'嗎?
        /// </summary>
        public static string MSG0016 = "您確認刪除 {0} 嗎？";

        /// <summary>
        /// 當前記錄不允許被刪除.
        /// </summary>
        public static string MSG0017 = "當前記錄不允許被刪除。";

        /// <summary>
        /// 當前記錄 '{0}' 不允許被刪除.
        /// </summary>
        public static string MSG0018 = "當前記錄 {0} 不允許被刪除。";

        /// <summary>
        /// 當前記錄不允許被編輯,請按F5鍵,重新獲取數據最新數據.
        /// </summary>
        public static string MSG0019 = "當前記錄不允許被編輯，請按F5鍵,重新獲取數據最新數據。";

        /// <summary>
        /// 當前記錄 '{0}' 不允許被編輯,請按F5鍵,重新獲取數據最新數據.
        /// </summary>
        public static string MSG0020 = "當前記錄 {0} 不允許被編輯，請按F5鍵，重新獲取數據最新數據。";

        /// <summary>
        /// 當前記錄已是第一條記錄.
        /// </summary>
        public static string MSG0021 = "當前記錄已是第一條記錄。";

        /// <summary>
        /// 當前記錄已是最後一條記錄.
        /// </summary>
        public static string MSG0022 = "當前記錄已是最後一條記錄。";

        /// <summary>
        /// 請至少選擇一項.
        /// </summary>
        public static string MSG0023 = "請選擇一條記錄。";

        /// <summary>
        /// 請至少選擇一項 '{0}'.
        /// </summary>
        public static string MSG0024 = "請至少選擇一條記錄。";

        /// <summary>
        /// '{0}'不能大於'{1}'.
        /// </summary>
        public static string MSG0025 = "{0} 不能大於{1}。";

        /// <summary>
        /// '{0}'不能小於'{1}'.
        /// </summary>
        public static string MSG0026 = "{0} 不能小於 {1}。";

        /// <summary>
        /// '{0}'不能等於'{1}'.
        /// </summary>
        public static string MSG0027 = "{0} 不能等於 {1}。";

        /// <summary>
        /// 輸入的'{0}'不是有效的日期.
        /// </summary>
        public static string MSG0028 = "輸入的 {0} 不是有效的日期。";

        /// <summary>
        /// 輸入的'{0}'不是有效的字符.
        /// </summary>
        public static string MSG0029 = "輸入的 {0} 不是有效的字符。";

        /// <summary>
        /// 輸入的'{0}'不是有效的數字.
        /// </summary>
        public static string MSG0030 = "輸入的 {0} 不是有效的數字。";

        /// <summary>
        /// 輸入的'{0}'不是有效的金額.
        /// </summary>
        public static string MSG0031 = "輸入的 {0} 不是有效的金額。";

        /// <summary>
        /// '{0}'名不能包含：\ / : * ? " < > |
        /// </summary>
        public static string MSG0032 = "{0} 名包含非法字符。";

        /// <summary>
        /// 數據已經被引用,有關聯數據在
        /// </summary>
        public static string MSG0033 = "數據已經被引用，有關聯數據在。";

        /// <summary>
        /// 數據已經被引用,有關聯數據在.是否強制刪除數據?
        /// </summary>
        public static string MSG0034 = "數據已經被引用，有關聯數據在，是否強制刪除數據？";

        /// <summary>
        /// {0} 有子節點不允許被刪除.
        /// </summary>
        public static string MSG0035 = "{0} 有子節點不允許被刪除，有子節點還未被刪除。";

        /// <summary>
        /// {0} 不能移動到 {1}.
        /// </summary>
        public static string MSG0036 = "{0} 不能移動到 {1}。";

        /// <summary>
        /// {0} 下的子節點不能移動到 {1}.
        /// </summary>
        public static string MSG0037 = "{0} 下的子節點不能移動到 {1}。";

        /// <summary>
        /// 確認移動 {0} 到 {1} 嗎?
        /// </summary>
        public static string MSG0038 = "確認移動 {0} 到 {1} 嗎？";

        /// <summary>
        /// '{0}'不等於'{1}'.
        /// </summary>
        public static string MSG0039 = "{0} 不等於 {1}。";

        /// <summary>
        /// {0} 錯誤.
        /// </summary>
        public static string MSG0040 = "{0} 錯誤。";

        /// <summary>
        /// 確認審核通過嗎?.
        /// </summary>
        public static string MSG0041 = "確認審核通過嗎？";

        /// <summary>
        /// 確認駁回嗎?.
        /// </summary>
        public static string MSG0042 = "確認審核駁回嗎？";

        /// <summary>
        /// 成功鎖定數據.
        /// </summary>
        public static string MSG0043 = "不能鎖定數據。";

        /// <summary>
        /// 不能鎖定數據.
        /// </summary>
        public static string MSG0044 = "成功鎖定數據。";

        /// <summary>
        /// 數據被修改提示
        /// </summary>
        public static string MSG0045 = "數據已經改變，想保存數據嗎？";

        /// <summary>
        /// 最近 {0} 次內密碼不能重複。
        /// </summary>
        public static string MSG0046 = "最近 {0} 次內密碼不能重複。";

        /// <summary>
        /// 密碼已過期，賬戶被鎖定，請聯繫系統管理員。
        /// </summary>
        public static string MSG0047 = "密碼已過期，賬戶被鎖定，請聯繫系統管理員。";

        /// <summary>
        /// 數據已經改變，不保存數據？
        /// </summary>
        public static string MSG0065 = "數據已經改變，不保存數據？";

        public static string MSG0048 = "拒絕登錄，用戶已經在線上。";
        public static string MSG0049 = "拒絕登錄，網卡Mac地址不符限制條件。";
        public static string MSG0050 = "拒絕登錄，IP地址不符限制條件";
        public static string MSG0051 = "已到在線用戶最大數量限制。";


        public static string MSG0060 = "請先創建該職員的登錄系統的用戶信息。";

        /// <summary>
        /// 您確認移除嗎?
        /// </summary>
        public static string MSG0075 = "您確認移除嗎？";

        /// <summary>
        /// 您確認移除 '{0}'嗎?
        /// </summary>
        public static string MSG0076 = "您確認移除 {0} 嗎？";

        public static string MSG0700 = "已經成功連接到目標數據。";

        public static string MSG9800 = "值";
        public static string MSG9900 = "公司";
        public static string MSG9901 = "部門";
        public static string MSG9956 = "未找到滿足條件的記錄。";
        public static string MSG9957 = "用戶名";
        public static string MSG9958 = "數據驗證錯誤。";
        public static string MSG9959 = "新密碼";
        public static string MSG9960 = "確認密碼";
        public static string MSG9961 = "原密碼";
        public static string MSG9962 = "修改 {0} 成功。";
        public static string MSG9963 = "設置 {0} 成功。";
        public static string MSG9964 = "密碼";
        public static string MSG9965 = "登錄成功。";
        public static string MSG9966 = "用戶沒有找到，請注意大小寫。";
        public static string MSG9967 = "密碼錯誤，請注意大小寫。";
        public static string MSG9968 = "登錄被拒絕，請與管理員聯繫。";
        public static string MSG9969 = "基礎編碼";
        public static string MSG9970 = "職員";
        public static string MSG9971 = "組織機構";
        public static string MSG9972 = "角色";
        public static string MSG9973 = "模塊";
        public static string MSG9974 = "文件夾";
        public static string MSG9975 = "權限";
        public static string MSG9976 = "代碼";
        public static string MSG9977 = "編號";
        public static string MSG9978 = "名稱";
        public static string MSG9979 = "父節點代碼";
        public static string MSG9980 = "父節點名稱";
        public static string MSG9981 = "功能分類代碼";
        public static string MSG9982 = "唯一識別代碼";
        public static string MSG9983 = "主題";
        public static string MSG9984 = "內容";
        public static string MSG9985 = "狀態碼";
        public static string MSG9986 = "次數";
        public static string MSG9987 = "有效";
        public static string MSG9988 = "備註";
        public static string MSG9989 = "排序碼";
        public static string MSG9990 = "創建者代碼";
        public static string MSG9991 = "創建時間";
        public static string MSG9992 = "最後修改者代碼";
        public static string MSG9993 = "最後修改時間";
        public static string MSG9994 = "排序";
        public static string MSG9995 = "代碼";
        public static string MSG9996 = "索引";
        public static string MSG9997 = "字段";
        public static string MSG9998 = "表";
        public static string MSG9999 = "數據庫";

        #region public static int GetLanguageResource() 從當前指定的語言包讀取信息
        /// <summary>
        /// 從當前指定的語言包讀取信息
        /// </summary>
        /// <returns></returns>
        //public static int GetLanguageResource()
        //{
        //    AppMessage AppMessage = new AppMessage();
        //    return BaseInterfaceLogic.GetLanguageResource(AppMessage);
        //}
        #endregion

        #region public static string Format(string value, params string[] messages) 格式化一個資源字符串
        /// <summary>
        /// 格式化一個資源字符串
        /// </summary>
        /// <param name="value">目標字符串</param>
        /// <param name="messages">傳入的信息</param>
        /// <returns>字符串</returns>
        public static string Format(string value, params string[] messages)
        {
            return String.Format(CultureInfo.CurrentCulture, value, messages);
        }
        #endregion

        #region public static string GetMessage(string id) 讀取一個資源定義
        /// <summary>
        /// 讀取一個資源定義
        /// </summary>
        /// <param name="id">資源代碼</param>
        /// <returns>字符串</returns>
        public static string GetMessage(string id)
        {
            string returnValue = string.Empty;
            returnValue = ResourceManagerWrapper.Instance.Get(id);
            return returnValue;
        }
        #endregion

        #region public static string GetMessage(string id, params string[] messages)
        /// <summary>
        /// 讀取一個資源定義
        /// </summary>
        /// <param name="id">資源代碼</param>
        /// <param name="messages">傳入的信息</param>
        /// <returns>字符串</returns>
        public static string GetMessage(string id, params string[] messages)
        {
            string returnValue = string.Empty;
            returnValue = ResourceManagerWrapper.Instance.Get(id);
            returnValue = String.Format(CultureInfo.CurrentCulture, returnValue, messages);
            return returnValue;
        }
        #endregion
    }
}