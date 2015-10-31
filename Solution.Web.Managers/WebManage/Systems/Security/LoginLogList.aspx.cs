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
 *   創建日期：2014-06-22
 *   文件名稱：LoginLogList.aspx.cs
 *   描    述：登陸日誌列表文件
 *             
 *   修 改 人：
 *   修改日期：
 *   修改原因：
 ***********************************************************************/
using SubSonic.Query;

namespace Solution.Web.Managers.WebManage.Systems.Security
{
    public partial class LoginLogList : PageBase
    {
        int _id = 0;

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            //獲取管理員Id——用於查詢指定管理員日誌
            _id = RequestHelper.GetInt0("Id");

            if (!IsPostBack)
            {
                //設定初始化時間
                dpStart.Text = DateTime.Now.ToString("yyyy-M-d");
                dpEnd.Text = DateTime.Now.AddDays(1).ToString("yyyy-M-d");

                LoadData();
            }
        }
        #endregion

        #region 接口函數，用於UI頁面初始化，給邏輯層對像、列表等對像賦值
        public override void Init()
        {
            //邏輯對像賦值
            bll = LoginLogBll.GetInstence();
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
            LoginLogBll.GetInstence().BindGrid(Grid1, Grid1.PageIndex + 1, Grid1.PageSize, InquiryCondition(), sortList);
        }

        /// <summary>
        /// 查詢條件
        /// </summary>
        /// <returns></returns>
        private List<ConditionHelper.SqlqueryCondition> InquiryCondition()
        {
            var wheres = new List<ConditionHelper.SqlqueryCondition>();

            //如果Id有值時，即表示查詢的是指定管理員的操作日誌
            if (_id != 0)
            {
                wheres.Add(new ConditionHelper.SqlqueryCondition(ConstraintType.Where, LoginLogTable.Manager_Id, Comparison.Equals, _id));
            }

            //起始時間
            if (!string.IsNullOrEmpty(dpStart.Text.Trim()))
            {
                wheres.Add(new ConditionHelper.SqlqueryCondition(ConstraintType.And, LoginLogTable.AddDate, Comparison.GreaterOrEquals, StringHelper.FilterSql(dpStart.Text)));
                //終止時間
                if (!string.IsNullOrEmpty(dpEnd.Text.Trim()))
                {
                    wheres.Add(new ConditionHelper.SqlqueryCondition(ConstraintType.And, LoginLogTable.AddDate, Comparison.LessOrEquals, StringHelper.FilterSql(dpEnd.Text)));
                }
            }

            //ip地址
            if (!string.IsNullOrEmpty(txtIp.Text.Trim()))
            {
                wheres.Add(new ConditionHelper.SqlqueryCondition(ConstraintType.And, LoginLogTable.Ip, Comparison.Equals, StringHelper.FilterSql(txtIp.Text)));
            }
            //登錄備註信息
            if (!string.IsNullOrEmpty(txtloginfo.Text.Trim()))
            {
                wheres.Add(new ConditionHelper.SqlqueryCondition(ConstraintType.And, LoginLogTable.Notes, Comparison.Like, "%" + StringHelper.FilterSql(txtloginfo.Text) + "%"));
            }

            return wheres;
        }

        #endregion
        
    }
}