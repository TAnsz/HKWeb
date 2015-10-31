/// <summary>
/// 類說明：Assistant
/// 編 碼 人：蘇飛
/// 聯繫方式：361983679  
/// 更新網站：http://www.sufeinet.com/thread-655-1-1.html
/// </summary>
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;

namespace DotNet.Utilities
{
    /// <summary>
    /// 數據展示控件 綁定數據類
    /// </summary>
    public class BindDataControl
    {
        #region 綁定服務器數據控件 簡單綁定DataList
        /// <summary>
        /// 簡單綁定DataList
        /// </summary>
        /// <param name="ctrl">控件ID</param>
        /// <param name="mydv">數據視圖</param>
        public static void BindDataList(Control ctrl, DataView mydv)
        {
            ((DataList)ctrl).DataSourceID = null;
            ((DataList)ctrl).DataSource = mydv;
            ((DataList)ctrl).DataBind();
        }
        #endregion

        #region 綁定服務器數據控件 SqlDataReader簡單綁定DataList
        /// <summary>
        /// SqlDataReader簡單綁定DataList
        /// </summary>
        /// <param name="ctrl">控件ID</param>
        /// <param name="mydv">數據視圖</param>
        public static void BindDataReaderList(Control ctrl, SqlDataReader mydv)
        {
            ((DataList)ctrl).DataSourceID = null;
            ((DataList)ctrl).DataSource = mydv;
            ((DataList)ctrl).DataBind();
        }
        #endregion

        #region 綁定服務器數據控件 簡單綁定GridView
        /// <summary>
        /// 簡單綁定GridView
        /// </summary>
        /// <param name="ctrl">控件ID</param>
        /// <param name="mydv">數據視圖</param>
        public static void BindGridView(Control ctrl, DataView mydv)
        {
            ((GridView)ctrl).DataSourceID = null;
            ((GridView)ctrl).DataSource = mydv;
            ((GridView)ctrl).DataBind();
        }
        #endregion

        /// <summary>
        /// 綁定服務器控件 簡單綁定Repeater
        /// </summary>
        /// <param name="ctrl">控件ID</param>
        /// <param name="mydv">數據視圖</param>
        public static void BindRepeater(Control ctrl, DataView mydv)
        {
            ((Repeater)ctrl).DataSourceID = null;
            ((Repeater)ctrl).DataSource = mydv;
            ((Repeater)ctrl).DataBind();
        }
    }
}
