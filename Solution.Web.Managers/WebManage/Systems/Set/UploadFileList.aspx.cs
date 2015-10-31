using System;
using DotNet.Utilities;
using FineUI;
using Solution.DataAccess.DataModel;
using Solution.Logic.Managers;
using Solution.Web.Managers.WebManage.Application;

/***********************************************************************
 *   作    者：AllEmpty（陳煥）-- 1654937@qq.com
 *   博    客：http://www.cnblogs.com/EmptyFS/
 *   技 術 群：327360708
 *  
 *   創建日期：2014-06-27
 *   文件名稱：UploadFileList.aspx.cs
 *   描    述：上傳文件列表管理
 *             
 *   修 改 人：
 *   修改日期：
 *   修改原因：
 ***********************************************************************/
namespace Solution.Web.Managers.WebManage.Systems.Set
{
    public partial class UploadFileList : PageBase
    {
        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }
        #endregion

        #region 接口函數，用於UI頁面初始化，給邏輯層對像、列表等對像賦值
        public override void Init()
        {
            //邏輯對像賦值
            bll = UploadFileBll.GetInstence();
            //表格對像賦值
            grid = Grid1;
        }
        #endregion

        #region 加載數據
        /// <summary>讀取數據</summary>
        public override void LoadData()
        {
            //設置排序
            if (sortList == null)
            {
                Sort(null);
            }

            //綁定Grid表格
            bll.BindGrid(Grid1, Grid1.PageIndex + 1, Grid1.PageSize, null, sortList);
        }

        #endregion
        
        #region 列表屬性綁定

        #region 列表按鍵綁定——修改列表控件屬性
        /// <summary>
        /// 列表按鍵綁定——修改列表控件屬性
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Grid1_PreRowDataBound(object sender, FineUI.GridPreRowEventArgs e)
        {
            //綁定用戶類型
            GridRow gr = Grid1.Rows[e.RowIndex];
            if (((System.Data.DataRowView)(gr.DataItem)).Row.Table.Rows[e.RowIndex][UploadFileTable.UserType].ToString() == "1")
            {
                var lbf = Grid1.FindColumn("UserType") as LinkButtonField;
                lbf.Text = "管理員";
                lbf.Enabled = false;
            }
            else
            {
                var lbf = Grid1.FindColumn("UserType") as LinkButtonField;
                lbf.Text = "會員";
                lbf.Enabled = false;
            }
        }
        #endregion
        
        #endregion

        #region 刪除記錄
        /// <summary>
        /// 刪除記錄
        /// </summary>
        /// <returns></returns>
        public override string Delete()
        {
            //獲取要刪除的Id組
            var id = GridViewHelper.GetSelectedKeyIntArray(Grid1);
            
            //如果沒有選擇記錄，則直接退出
            if (id == null)
            {
                return "請選擇要刪除的記錄。";
            }

            try
            {
                //逐個文件刪除
                foreach (var i in id)
                {
                    //獲取文件路徑
                    var path = UploadFileBll.GetInstence().GetFieldValue(i, UploadFileTable.Path) + "";
                    //刪除文件與對應的記錄
                    UploadFileBll.GetInstence().Upload_OneDelPic(path);
                    //刪除記錄
                    bll.Delete(this, i);
                }
                
                return "刪除編號Id為[" + string.Join(",", id) + "]的數據記錄成功。";
            }
            catch (Exception e)
            {
                string result = "嘗試刪除編號ID為[" + string.Join(",", id) +"]的數據記錄失敗！";

                //出現異常，保存出錯日誌信息
                CommonBll.WriteLog(result, e);

                return result;
            }
        }
        #endregion

        #region 全部圖片重新生成
        /// <summary>
        /// 全部圖片重新生成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonImageRegenerate_Click(object sender, EventArgs e)
        {
            try
            {
                UploadFileBll.GetInstence().fix_PicSizeAll();
                FineUI.Alert.ShowInParent("全部圖片重新生成成功", FineUI.MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                //出現異常，保存出錯日誌信息
                CommonBll.WriteLog("重新生成圖片失敗", ex);
                FineUI.Alert.ShowInParent("重新生成圖片失敗", FineUI.MessageBoxIcon.Information);
            }
        }
        #endregion

        #region 檢查擴展名，判斷是否是圖片
        /// <summary>
        /// 檢查擴展名，判斷是否是圖片
        /// </summary>
        /// <param name="ext">擴展名</param>
        /// <returns></returns>
        protected string CheckPic(object ext, object path)
        {
            if (ext == null || path == null) return "";

            if (",jpg,gif,png,".IndexOf("," + ext + ",") > -1)
            {
                return "<img src=\"" + path + "\" />"; ;
            }

            return path.ToString();
        }
        #endregion
    }
}