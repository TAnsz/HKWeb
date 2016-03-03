using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using DotNet.Utilities;
using FineUI;
using Solution.DataAccess.DataModel;
using Solution.DataAccess.DbHelper;
using SubSonic.Query;
using Solution.Logic.Managers;
using Solution.Web.Managers.WebManage.Application;

/***********************************************************************
 *   作    者：AllEmpty（陳煥）-- 1654937@qq.com
 *   博    客：http://www.cnblogs.com/EmptyFS/
 *   技 術 群：327360708
 *  
 *   創建日期：2014-07-09
 *   文件名稱：OutWorkRecordList.aspx.cs
 *   描    述：請假出差列表管理
 *             
 *   修 改 人：
 *   修改日期：
 *   修改原因：
 ***********************************************************************/

namespace Solution.Web.Managers.WebManage.OutWorks
{
    public partial class OutWorkRecordLotList : PageBase
    {
        public enum AccType
        {
            [Description("一級")]
            Accept1,
            [Description("二級")]
            Accept2,
        };
        #region Page_Load
        protected new void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //綁定下拉列表
                //EmployeeBll.GetInstence().BandDropDownList(this, ddlEmp);
                LoadData();
            }
        }
        #endregion
        #region 接口函數，用於UI頁面初始化，給邏輯層對像、列表等對像賦值
        public override void Init()
        {
            //邏輯對像賦值
            bll = OutWork_DBll.GetInstence();
            //表格對像賦值
            grid = Grid1;
            //初始化默認排序
            if (grid != null && grid.AllowSorting)
            {
                sortList = new List<string> { "audit ASC", grid.SortField + " " + grid.SortDirection };
            }
            //設置默認日期，兩個月以內的記錄
            dpStart.SelectedDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-01"));
            dpEnd.SelectedDate = TimeHelper.GetMonthLastDate(DateTime.Now.AddMonths(1));
            //pc界面自動縮放
            PageManager1.AutoSizePanelID = CommonBll.IsPC(this) ? "Panel1" : "";
        }
        #endregion

        #region 加載數據
        /// <summary>讀取數據</summary>
        public override void LoadData()
        {
            //綁定Grid表格
            bll.BindGrid(Grid1, Grid1.PageIndex + 1, Grid1.PageSize, InquiryCondition(), sortList);
        }

        /// <summary>
        /// 查詢條件
        /// </summary>
        /// <returns></returns>
        private List<ConditionHelper.SqlqueryCondition> InquiryCondition()
        {
            var wheres = new List<ConditionHelper.SqlqueryCondition>();

            //默認顯示所有單據
            //員工編號
            if (!string.IsNullOrEmpty(ttbxEmp.Text))
            {
                //轉換成數組
                var s = ttbxEmp.Text.Trim().Split(',');
                wheres.Add(new ConditionHelper.SqlqueryCondition(ConstraintType.And, OutWork_DTable.emp_id, Comparison.In, s, true));
                wheres.Add(new ConditionHelper.SqlqueryCondition());//加右括號
            }

            //單據類別
            if (!string.IsNullOrEmpty(ddlOutWorkRecord.SelectedValue))
            {
                wheres.Add(new ConditionHelper.SqlqueryCondition(ConstraintType.And, OutWork_DTable.outwork_type, Comparison.Equals, StringHelper.FilterSql(ddlOutWorkRecord.SelectedValue)));
            }
            //起始時間
            if (dpStart.SelectedDate.HasValue)
            {
                wheres.Add(new ConditionHelper.SqlqueryCondition(ConstraintType.And, OutWork_DTable.bill_date, Comparison.GreaterOrEquals, dpStart.SelectedDate.Value.Date));
                wheres.Add(new ConditionHelper.SqlqueryCondition(ConstraintType.And, OutWork_DTable.bill_date, Comparison.LessOrEquals, dpEnd.SelectedDate));
            }

            //是否審批
            if (!string.IsNullOrEmpty(ddlIsDisplay.SelectedValue))
            {
                wheres.Add(new ConditionHelper.SqlqueryCondition(ConstraintType.And, OutWork_DTable.audit, Comparison.Equals,
                    StringHelper.FilterSql(ddlIsDisplay.SelectedValue)));
            }

            return wheres;
        }
        #endregion

        #region 添加新記錄
        /// <summary>
        /// 添加新記錄
        /// </summary>
        public override void Add()
        {
            Window1.IFrameUrl = "OutWorkRecordLotEdit.aspx?" + MenuInfoBll.GetInstence().PageUrlEncryptString();
            Window1.Hidden = false;
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
            Window2.IFrameUrl = "/WebManage/Systems/Pop/EmpChoose.aspx?" + MenuInfoBll.GetInstence().PageUrlEncryptString();
            Window2.Hidden = false;
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
        #region 審批單據
        /// <summary>
        /// 審批選中記錄
        /// </summary>
        protected void ButtonAccept_Click(object sender, EventArgs e)
        {
            AcceptRecord(AccType.Accept1);
            LoadData();
        }

        /// <summary>
        /// 審批選中記錄
        /// </summary>
        protected void ButtonAccept2_Click(object sender, EventArgs e)
        {
            AcceptRecord(AccType.Accept2);
            LoadData();
        }

        /// <summary>
        /// 審批記錄
        /// </summary>
        /// <param name="p">0為一級審批 ，1為二級審批</param>
        private void AcceptRecord(AccType p)
        {
            string result = "";
            //獲取要審批的Id組
            var id = GridViewHelper.GetSelectedKeyIntArray(Grid1);

            //如果沒有選擇記錄，則直接退出
            if (id == null)
            {
                result = "請選擇要審批的記錄。";
                FineUI.Alert.ShowInParent(result, FineUI.MessageBoxIcon.Information);
                return;
            }
            //將數組轉為逗號分隔的字串
            foreach (int t in id)
            {
                try
                {
                    switch (p)
                    {
                        case AccType.Accept1:
                            result += OutWork_DBll.GetInstence().Accept1(this, t, 1, false,false);
                            break;
                        case AccType.Accept2:
                            result += OutWork_DBll.GetInstence().Accept2(this, t, 1, false, false);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException("p", p, null);
                    }
                }
                catch (Exception ex)
                {
                    string s = string.Format("{0}審批編號Id為[{1}]的數據記錄出錯。", CommonBll.GetDescription(p), t.ToString());
                    result += s;
                    CommonBll.WriteLog(s, ex);
                }
            }
            result = string.IsNullOrEmpty(result) ? string.Format("{0}審批編號Id為[{1}]的數據並發送郵件記錄成功。", CommonBll.GetDescription(p), string.Join(",", id)) : result;
            FineUI.Alert.ShowInParent(result, FineUI.MessageBoxIcon.Information);
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
            //綁定是否顯示
            DataRowView row = e.DataItem as DataRowView;
            if (row != null)
            {
                var lbf = Grid1.FindColumn("audit") as LinkButtonField;
                if (lbf != null)
                {
                    if (row.Row.Table.Rows[e.RowIndex][OutWork_DTable.audit].ToString() == "1")
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
                var lbf2 = Grid1.FindColumn("audit2") as LinkButtonField;
                if (lbf2 != null)
                {
                    if (row.Row.Table.Rows[e.RowIndex][OutWork_DTable.audit2].ToString() == "1")
                    {
                        lbf2.Icon = Icon.BulletTick;
                        lbf2.CommandArgument = "0";
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(row.Row.Table.Rows[e.RowIndex][OutWork_DTable.CHECKER2].ToString()))
                        {
                            lbf2.Icon = Icon.PageWhite;
                            lbf2.CommandArgument = "2";
                        }
                        else
                        {
                            lbf2.Icon = Icon.BulletCross;
                            lbf2.CommandArgument = "1";
                        }
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
            string result = null;
            int value = ConvertHelper.Cint0(e.CommandArgument);
            switch (e.CommandName)
            {
                case "IsAudit":
                    if (value > 1)
                    {
                        return;
                    }
                    //更新狀態
                    result = OutWork_DBll.GetInstence().Accept1(this, ConvertHelper.Cint0(id), value);
                    result = string.IsNullOrEmpty(result)
                        ? string.Format("一級{0}審批成功。", value == 0 ? "反" : "")
                        : result;
                    FineUI.Alert.ShowInParent(result, FineUI.MessageBoxIcon.Information);
                    //重新加載
                    LoadData();
                    break;
                case "IsAudit2":
                    if (value > 1)
                    {
                        return;
                    }
                    //更新狀態
                    result = OutWork_DBll.GetInstence().Accept2(this, ConvertHelper.Cint0(id), value);
                    result = string.IsNullOrEmpty(result)
                        ? string.Format("二級{0}審批成功。", value == 0 ? "反" : "")
                        : result;
                    FineUI.Alert.ShowInParent(result, FineUI.MessageBoxIcon.Information);
                    //重新加載
                    LoadData();
                    break;
                case "ButtonEdit":
                    //打開編輯窗口
                    Window1.IFrameUrl = "OutWorkRecordLotEdit.aspx?Id=" + id + "&" +
                                        MenuInfoBll.GetInstence().PageUrlEncryptStringNoKey(id + "");
                    Window1.Hidden = false;
                    break;
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

        #region 子窗口關閉事件

        /// <summary>
        /// 關閉子窗口事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void Window2_Close(object sender, WindowCloseEventArgs e)
        {
            if (e.CloseArgument.StartsWith("Emp="))
            {
                string provinceName = e.CloseArgument.Substring("Emp=".Length);
                ttbxEmp.Text = provinceName;
            }
            //LoadData();
        }

        #endregion
    }
}