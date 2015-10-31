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
 *   創建日期：2014-06-23
 *   文件名稱：OnlineUsersList.aspx.cs
 *   描    述：在線用戶列表文件
 *             
 *   修 改 人：
 *   修改日期：
 *   修改原因：
 ***********************************************************************/
using SubSonic.Query;

namespace Solution.Web.Managers.WebManage.Systems.Security
{
    public partial class OnlineUsersList : PageBase
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
            bll = OnlineUsersBll.GetInstence();
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
            OnlineUsersBll.GetInstence().BindGrid(Grid1, Grid1.PageIndex + 1, Grid1.PageSize, null, sortList);
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
            //綁定是否編輯列
            var lbfGetOut = Grid1.FindColumn("ButtonGetOut") as LinkButtonField;
            lbfGetOut.Enabled = MenuInfoBll.GetInstence().CheckControlPower(this, "ButtonGetOut");
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
            //獲取主鍵ID
            var id = ConvertHelper.Cint0(gr.DataKeys[0].ToString());
            //獲取在線用戶實體
            var model = OnlineUsersBll.GetInstence().GetModelForCache(id);
            if (model == null)
                return;

            switch (e.CommandName)
            {
                case "GetOut":
                    //從在線表中刪除用戶
                    OnlineUsersBll.GetInstence().UserExit(this, model.UserHashKey);
                    //刷新當前頁面
                    FineUI.PageContext.Refresh();
                    break;
                case "ManagerColumn":
                    Window1.IFrameUrl = "../../Employees/ManagerView.aspx?Id=" + model.Manager_Id + "&" + MenuInfoBll.GetInstence().PageUrlEncryptStringNoKey(model.Manager_Id + "");
                    Window1.Hidden = false;
                    break;
                case "LoginLog":
                    Window1.IFrameUrl = "LoginLogList.aspx?Id=" + model.Manager_Id + "&" + MenuInfoBll.GetInstence().PageUrlEncryptStringNoKey(model.Manager_Id + "");
                    Window1.Hidden = false;
                    break;
                case "UserLog":
                    Window1.IFrameUrl = "UseLogList.aspx?Id=" + model.Manager_Id + "&" + MenuInfoBll.GetInstence().PageUrlEncryptStringNoKey(model.Manager_Id + "");
                    Window1.Hidden = false;
                    break;
            }
        }
        #endregion

        #endregion



    }
}