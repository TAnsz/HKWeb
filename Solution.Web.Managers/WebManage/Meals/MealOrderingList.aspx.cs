using System;
using System.Collections.Generic;
using System.Data;
using DotNet.Utilities;
using FineUI;
using Solution.DataAccess.DataModel;
using Solution.Logic.Managers;
using Solution.Web.Managers.WebManage.Application;
using Solution.DataAccess.DbHelper;
using SubSonic.Query;

/***********************************************************************
 *   作    者：AllEmpty（陳煥）-- 1654937@qq.com
 *   博    客：http://www.cnblogs.com/EmptyFS/
 *   技 術 群：327360708
 *  
 *   創建日期：2014-06-19
 *   文件名稱：MealOrderingList.aspx.cs
 *   描    述：菜單列表文件
 *             
 *   修 改 人：
 *   修改日期：
 *   修改原因：
 ***********************************************************************/
namespace Solution.Web.Managers.WebManage.Meals
{
    public partial class MealOrderingList : PageBase
    {
        protected static readonly List<string> ValidFileTypes = new List<string> { ".jpg", ".bmp", ".gif", ".jpeg", ".png" };
        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //設置默認日期
                dpStart.SelectedDate = DateTime.Now.Date;
                dpEnd.SelectedDate = DateTime.Now.Date;

                LoadData();

            }
        }
        #endregion

        #region 接口函數，用於UI頁面初始化，給邏輯層對像、列表等對像賦值
        public override void Init()
        {
            //邏輯對像賦值
            bll = MealOrderingBll.GetInstence();
            //表格對像賦值
            grid = Grid1;
        }
        #endregion

        #region 加載數據
        /// <summary>讀取數據</summary>
        public override void LoadData()
        {

            //綁定Grid表格
            bll.BindGrid(Grid1, Grid1.PageIndex + 1, Grid1.PageSize, InquiryCondition());
        }

        /// <summary>
        /// 查詢條件
        /// </summary>
        /// <returns></returns>
        private List<ConditionHelper.SqlqueryCondition> InquiryCondition()
        {
            var wheres = new List<ConditionHelper.SqlqueryCondition>();
            //隻顯示有效的記錄
            wheres.Add(new ConditionHelper.SqlqueryCondition(ConstraintType.And, MealOrderingTable.IsVaild, Comparison.Equals, 1));

            //員工編號
            if (!string.IsNullOrEmpty(ttbxEmp.Text.Trim()))
            {
                wheres.Add(new ConditionHelper.SqlqueryCondition(ConstraintType.And, MealOrderingTable.Employee_EmpId, Comparison.Equals, StringHelper.FilterSql(ttbxEmp.Text)));
            }
            //起始時間
            if (string.IsNullOrEmpty(dpStart.Text.Trim())) return wheres;
            wheres.Add(new ConditionHelper.SqlqueryCondition(ConstraintType.And, MealOrderingTable.ApplyDate, Comparison.GreaterOrEquals, StringHelper.FilterSql(dpStart.Text)));
            wheres.Add(new ConditionHelper.SqlqueryCondition(ConstraintType.And, MealOrderingTable.ApplyDate, Comparison.LessOrEquals, StringHelper.FilterSql(dpEnd.Text)));

            return wheres;
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
            DataRowView row = e.DataItem as DataRowView;
            if (row != null)
            {

                //綁定是否有效列
                if (row.Row.Table.Rows[e.RowIndex][MealOrderingTable.IsVaild].ToString() == "0")
                {
                    var lbf = Grid1.FindColumn("IsVaild") as LinkButtonField;
                    if (lbf != null)
                    {
                        lbf.Icon = Icon.BulletCross;
                        lbf.CommandArgument = "1";
                    }
                }
                else
                {
                    var lbf = Grid1.FindColumn("IsVaild") as LinkButtonField;
                    if (lbf != null)
                    {
                        lbf.Icon = Icon.BulletTick;
                        lbf.CommandArgument = "0";
                    }
                }
            }

            //綁定是否編輯列
            var lbfEdit = Grid1.FindColumn("ButtonEdit") as LinkButtonField;
            if (lbfEdit == null) return;
            lbfEdit.Text = "編輯";
            lbfEdit.Enabled = MenuInfoBll.GetInstence().CheckControlPower(this, "ButtonEdit");
        }
        #endregion

        #region Grid點擊事件
        /// <summary> 
        /// Grid點擊事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Grid1_RowCommand(object sender, FineUI.GridCommandEventArgs e)
        {
            GridRow gr = Grid1.Rows[e.RowIndex];
            //獲取當前點擊列的主鍵ID
            object id = gr.DataKeys[0];

            switch (e.CommandName)
            {
                case "IsVaild":
                    //更新狀態
                    MealOrderingBll.GetInstence().UpdateIsVaild(this, ConvertHelper.Cint0(id), ConvertHelper.Cint0(e.CommandArgument));
                    //重新加載
                    LoadData();

                    break;
                case "ButtonEdit":
                    //打開編輯窗口
                    Window1.IFrameUrl = "MealOrderingEdit.aspx?Id=" + id + "&" + MenuInfoBll.GetInstence().PageUrlEncryptStringNoKey(id + "");
                    Window1.Height = 450;
                    Window1.Hidden = false;
                    break;
            }
        }
        #endregion

        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonPrint_Click(object sender, EventArgs e)
        {
            Window1.IFrameUrl = "Report.aspx?" + MenuInfoBll.GetInstence().PageUrlEncryptStringNoKey("");
            Window1.Hidden = false;
        }
        #endregion

        #region 添加新記錄
        /// <summary>
        /// 添加新記錄
        /// </summary>
        public override void Add()
        {
            Window1.IFrameUrl = "MealOrderingEdit.aspx?" + MenuInfoBll.GetInstence().PageUrlEncryptString();
            Window1.Hidden = false;
        }
        #endregion

        #region 編輯記錄
        /// <summary>
        /// 編輯記錄
        /// </summary>
        public override void Edit()
        {
            string id = GridViewHelper.GetSelectedKey(Grid1, true);

            Window1.IFrameUrl = "MealOrderingEdit.aspx?Id=" + id + "&" + MenuInfoBll.GetInstence().PageUrlEncryptStringNoKey(id);
            Window1.Hidden = false;
        }
        #endregion

        #region 刪除記錄
        /// <summary>
        /// 刪除記錄
        /// </summary>
        /// <returns></returns>
        public override string Delete()
        {
            //獲取要刪除的ID
            int id = ConvertHelper.Cint0(GridViewHelper.GetSelectedKey(Grid1, true));

            //如果沒有選擇記錄，則直接退出
            if (id == 0)
            {
                return "請選擇要刪除的記錄。";
            }

            try
            {

                //刪除記錄
                // bll.Delete(this, id);

                //刪除改成設置成無效狀態
                var setValue = new Dictionary<string, object>();
                setValue[MealOrderingTable.IsVaild] = 0;
                MealOrderingBll.GetInstence().UpdateValue(this, id, setValue);

                return "刪除編號ID為[" + id + "]的數據記錄成功。";
            }
            catch (Exception e)
            {
                string result = "嘗試刪除編號ID為[" + id + "]的數據記錄失敗！";

                //出現異常，保存出錯日誌信息
                CommonBll.WriteLog(result, e);

                return result;
            }
        }
        #endregion

        #region 上傳圖片
        protected void filePhoto_FileSelected(object sender, EventArgs e)
        {
            if (!filePhoto.HasFile) return;
            string fileName = filePhoto.ShortFileName;

            if (!ValidFileTypes.Contains(FileOperateHelper.GetPostfixStr(fileName)))
            {
                FineUI.Alert.ShowInParent("無效的文件類型，請上傳後綴爲jpg的文件！", FineUI.MessageBoxIcon.Information);
                return;
            }


            filePhoto.SaveAs(Server.MapPath("~/UploadFile/menu.jpg"));

            //imgPhoto.ImageUrl = "~/upload/" + fileName;

            // 清空文件上传组件
            filePhoto.Reset();
            FineUI.Alert.ShowInParent("上傳成功", FineUI.MessageBoxIcon.Information);
        }
        #endregion


        #region 員工選擇
        /// <summary>
        /// 彈出員工選擇界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ttbxEmp_Trigger2Click(object sender, EventArgs e)
        {
            Window3.IFrameUrl = "/WebManage/Systems/Pop/EmpChoose.aspx?" + MenuInfoBll.GetInstence().PageUrlEncryptString();
            Window3.Hidden = false;
            ttbxEmp.ShowTrigger1 = true;
        }
        /// <summary>
        /// 清除員工選擇
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ttbxEmp_Trigger1Click(object sender, EventArgs e)
        {
            ttbxEmp.Text = "";
            ttbxEmp.ShowTrigger1 = false;
        }
        #endregion

        #region 子窗口關閉事件
        /// <summary>
        /// 關閉子窗口事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void Window3_Close(object sender, WindowCloseEventArgs e)
        {
            if (!e.CloseArgument.StartsWith("Emp=")) return;
            string provinceName = e.CloseArgument.Substring("Emp=".Length);
            ttbxEmp.Text = provinceName;
        }
        #endregion

    }
}