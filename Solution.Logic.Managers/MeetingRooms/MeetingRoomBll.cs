using System;
using System.Web.UI;
using DotNet.Utilities;
using Solution.DataAccess.DataModel;
using Solution.DataAccess.DbHelper;
using System.Collections.Generic;
using System.Linq;
using Solution.DataAccess.Model;
using SubSonic.Query;

namespace Solution.Logic.Managers
{
    /// <summary>
    /// Employee（用户表逻辑类）逻辑类
    /// </summary>
    public partial class MeetingRoomBll : LogicBase
    {
        /***********************************************************************
         * 自定义函数                                                          *
         ***********************************************************************/
        #region 自定义函数

        #region 绑定下拉列表
        /// <summary>
        /// 绑定下拉列表——显示所有
        /// </summary>
        public void BandDropDownListShowAll(Page page, FineUI.DropDownList ddl)
        {

            //筛选记录
            var dt = GetDataTable(false, 0, null, 0, 0, null);

            try
            {
                //显示值
                ddl.DataTextField = MeetingRoomTable.Name;
                //绑定Id
                ddl.DataValueField = MeetingRoomTable.Code;

                //绑定数据源
                ddl.DataSource = dt;
                ddl.DataBind();
                //ddl.SelectedIndex = 0;

                //ddl.Items.Insert(0, new FineUI.ListItem("請選擇會議室", "0"));
                //ddl.SelectedValue = "0";
            }
            catch (Exception e)
            {
                // 记录日志
                CommonBll.WriteLog("", e);
            }
        }
        #endregion
        
        #endregion 自定义函数

    }
}
