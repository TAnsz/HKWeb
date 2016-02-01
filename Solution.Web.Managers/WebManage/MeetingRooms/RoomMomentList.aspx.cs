using System;
using System.Collections.Generic;
using DotNet.Utilities;
using FineUI;
using Solution.DataAccess.DataModel;
using Solution.DataAccess.DbHelper;
using Solution.Logic.Managers;
using Solution.Web.Managers.WebManage.Application;
/***********************************************************************
 *   作    者：AllEmpty（陳煥）-- 1654937@qq.com
 *   博    客：http://www.cnblogs.com/EmptyFS/
 *   技 術 群：327360708
 *  
 *   創建日期：2014-07-01
 *   文件名稱：RoomMomentList.aspx.cs
 *   描    述：會議室已休列表管理
 *             
 *   修 改 人：
 *   修改日期：
 *   修改原因：
 ***********************************************************************/
using SubSonic.Query;
using System.Data;

namespace Solution.Web.Managers.WebManage.MeetingRooms
{
    public partial class RoomMomentList : PageBase
    {
        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //綁定下拉框
                //MeetingRoomBll.GetInstence().BandDropDownListShowAll(this, ddlRoomMoment);

                LoadData();
            }
        }
        #endregion

        #region 接口函數，用於UI頁面初始化，給邏輯層對像、列表等對像賦值
        public override void Init()
        {
            //邏輯對像賦值
            bll = RoomMomentBll.GetInstence();
            //表格對像賦值
            grid = Grid1;
            //設置默認日期，當天的
            dpStart.SelectedDate = DateTime.Now.Date;
            //pc界面自動縮放
            PageManager1.AutoSizePanelID = CommonBll.IsPC(this) ? "Panel1" : "";
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
            bll.BindGrid(Grid1, Grid1.PageIndex + 1, Grid1.PageSize, InquiryCondition(), sortList);
        }

        //條件
        private List<ConditionHelper.SqlqueryCondition> InquiryCondition()
        {
            var wheres = new List<ConditionHelper.SqlqueryCondition>();

            //會議室
            //if (!string.IsNullOrEmpty(ddlRoomMoment.SelectedValue.Trim()) && !ddlRoomMoment.SelectedValue.Equals("0"))
            //{
            //    wheres.Add(new ConditionHelper.SqlqueryCondition(ConstraintType.And, RoomMomentTable.MeetingRoom_Code, Comparison.Equals, ddlRoomMoment.SelectedValue));
            //}
            //日期
            if (!string.IsNullOrEmpty(dpStart.Text.Trim()))
            {
                wheres.Add(new ConditionHelper.SqlqueryCondition(ConstraintType.And, RoomMomentTable.RoomDate, Comparison.Equals, StringHelper.FilterSql(dpStart.Text)));
            }
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
                int r = 800;
                for (int i = 0; i < 27; i++)
                {
                    //根據時間進行進位
                    r += 30 + (i % 2 == 0 ? 0 : 40);
                    string xh = r.ToString().PadLeft(4, '0');
                    string s = "T" + xh;
                    string t1 = "txt" + xh + "01";
                    string t2 = "txt" + xh + "02";
                    var lbf = Grid1.FindControl(s) as LinkButtonField;
                    if (row.Row.Table.Rows[e.RowIndex][s].ToString() == "1")
                    {
                        lbf.Icon = Icon.BulletTick;
                        lbf.CommandArgument = "0";
                    }
                    else
                    {
                        lbf.Icon = Icon.BulletCross;
                        lbf.CommandArgument = "1";
                    }
                }

            }
        }

        #region 下拉列表改變事件
        /// <summary>下拉列表改變事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void dllRoomMoment_SelectedIndexChanged(object sender, EventArgs e)
        {

            LoadData();
        }
        #endregion
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

            if (e.CommandName[0].Equals('T'))
            {
                //打開編輯窗口
                string s = e.CommandName.Substring(1, 2) + ":" + e.CommandName.Substring(3, 2);
                Window1.IFrameUrl = "MeetingRoomApplyEdit.aspx?Id=" + id + "&Time=" + s+ "&" + MenuInfoBll.GetInstence().PageUrlEncryptStringNoKey(id + "");
                Window1.Hidden = false;
            }

        }
        #endregion

        #region 保存自動排序
        /// <summary>
        /// 保存自動排序
        /// </summary>
        public override void SaveAutoSort()
        {
            if (bll.UpdateAutoSort(this))
            {
                Alert.ShowInParent("保存成功", "保存自動排序成功", "window.location.reload();");
            }
            else
            {
                Alert.ShowInParent("保存失敗", "保存自動排序失敗");
            }
        }
        #endregion

        #endregion

        #region 添加新記錄
        /// <summary>
        /// 添加新記錄
        /// </summary>
        public override void Add()
        {
            Window1.IFrameUrl = "MeetingRoomApplyEdit.aspx?" + MenuInfoBll.GetInstence().PageUrlEncryptString();
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
            //獲取要刪除的Id組
            var id = GridViewHelper.GetSelectedKeyIntArray(Grid1);

            //如果沒有選擇記錄，則直接退出
            if (id == null)
            {
                return "請選擇要刪除的記錄。";
            }

            try
            {

                //刪除記錄
                bll.Delete(this, id);

                return "刪除編號Id為[" + string.Join(",", id) + "]的數據記錄成功。";
            }
            catch (Exception e)
            {
                string result = "嘗試刪除編號ID為[" + string.Join(",", id) + "]的數據記錄失敗！";

                //出現異常，保存出錯日誌信息
                CommonBll.WriteLog(result, e);

                return result;
            }
        }
        #endregion

    }
}