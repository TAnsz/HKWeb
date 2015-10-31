using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using DotNet.Utilities;
using FineUI;
using Solution.DataAccess.DataModel;
using Solution.DataAccess.DbHelper;
using Solution.Logic.Managers;
using Solution.Web.Managers.WebManage.Application;
using SubSonic.Query;

 /***********************************************************************
  *   作    者：AllEmpty（陳煥）-- 1654937@qq.com
  *   博    客：http://www.cnblogs.com/EmptyFS/
  *   技 術 群：327360708
  *  
  *   創建日期：2014-06-17
  *   文件名稱：Main.aspx.cs
  *   描    述：後端首頁
  *             
  *   修 改 人：
  *   修改日期：
  *   修改原因：
  ***********************************************************************/
namespace Solution.Web.Managers
{
    public partial class Main : PageBase
    {
        //用戶頁面操作權限
        string _pagePower = "";

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //添加萬年曆按鍵事件，在主窗口中添加新選項卡
                btnCalendar.OnClientClick = mainTabStrip.GetAddTabReference("calendar_tab", "/WebManage/Help/wannianli.htm", "萬年曆", IconHelper.GetIconUrl(Icon.Calendar), true);

                //加載信息
                LoadData();
            }
        }
        #endregion

        #region 接口函數，用於UI頁面初始化，給邏輯層對像、列表等對像賦值
        public override void Init()
        {

        }
        #endregion

        #region 加載數據

        /// <summary>讀取數據</summary>
        public override void LoadData()
        {
            #region 展示用戶信息

            //在線人數
            txtOnlineUserCount.Text = OnlineUsersBll.GetInstence().GetUserOnlineCount() + "";

            //當前用戶信息
            var model = OnlineUsersBll.GetInstence().GetOnlineUsersModel();
            if (model == null)
                return;

            //用戶名稱
            txtUser.Text = model.Manager_CName + " [" + IpHelper.GetUserIp() + "]";

            //部門
            txtBranchName.Text = model.Branch_Name;
            //職位
            txtPositionInfoName.Text = model.Position_Name;
            #endregion
            
            #region 菜單欄數據綁定
            //獲取用戶頁面操作權限
            _pagePower = OnlineUsersBll.GetInstence().GetPagePower();


            //創建查詢條件
            var wheres = new List<ConditionHelper.SqlqueryCondition>();
            //條件：只查詢出需要顯示的菜單,暫時顯示全部
            wheres.Add(new ConditionHelper.SqlqueryCondition(ConstraintType.And, MenuInfoTable.IsDisplay, Comparison.Equals, "1"));
            //進行查詢，獲取DataTable
            var dt = MenuInfoBll.GetInstence().GetDataTable(false, 0, null, 0, 0, wheres);
            //綁定樹列表
            BandingTree(dt);

            #endregion

            #region 開啟時鐘檢測
            Timer1.Enabled = true;
            #endregion

        }
        #endregion

        #region 頁面按鍵

        #region 清空緩存並重新加載
        /// <summary>
        /// 清空緩存並重新加載
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnClearCache_Click(object sender, EventArgs e)
        {
            //清空全部後端緩存HttpRuntime.Cache（在線列表緩存除外）
            CacheHelper.RemoveManagersAllCache();

            FineUI.Alert.ShowInTop("緩存清除成功！", "提示", MessageBoxIcon.Information);
        }
        #endregion

        #region 退出系統
        /// <summary>
        /// 退出系統
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnExit_Click(object sender, EventArgs e)
        {
            OnlineUsersBll.GetInstence().UserExit(this);

            FineUI.Alert.ShowInTop("成功退出系統！", "安全退出", MessageBoxIcon.Information, "top.location='Login.aspx'");
        }
        #endregion

        #endregion

        #region 定時器
        /// <summary>
        /// 定時執行方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Timer1_Tick(object sender, EventArgs e)
        {
            Timer1.Enabled = false;

            #region 檢測當前用戶是否退出
            OnlineUsersBll.GetInstence().IsTimeOut();
            #endregion

            #region 檢測用戶登錄的有效性（是否被系統踢下線或管理員踢下線）
            if (OnlineUsersBll.GetInstence().IsOffline(this))
                return;
            #endregion

            #region 更新信息（在線人數，未讀取的短消息）
            if (HttpRuntime.Cache == null)
            {
                txtOnlineUserCount.Text = "--";
            }
            else
            {
                //更新當前在線用戶數量
                txtOnlineUserCount.Text = OnlineUsersBll.GetInstence().GetUserOnlineCount() + "";
            }
            #endregion

            #region 修改用戶最後在線時間

            //修改用戶最後在線時間
            OnlineUsersBll.GetInstence().UpdateTime();

            #endregion

            Timer1.Enabled = true;
        }
        #endregion
        
        #region FineUI控件之--樹控件（Tree）

        #region 綁定樹控件
        /// <summary>樹控件（Tree）
        /// </summary>
        /// <param name="dataTable">DataTable數據源</param>
        /// <returns>樹控件（Tree）</returns>
        public void BandingTree(DataTable dataTable)
        {
            try
            {
                //檢查指定的列是否在數據源中能否找到
                if (dataTable.Rows.Count == 0)
                {
                    return;
                }
                //篩選出全部一級節點
                DataTable dtRoot = DataTableHelper.GetFilterData(dataTable, MenuInfoTable.ParentId, "0", MenuInfoTable.Sort, "Asc");
                //判斷是否有節點存在
                if (dtRoot.Rows.Count != 0)
                {
                    //循環讀取節點
                    foreach (DataRow dr in dtRoot.Rows)
                    {
                        //判斷當前節點是否有權限訪問，沒有則跳過本次循環
                        //暫時先註釋掉權限判斷，等添加相關權限後再開啟
                        if (_pagePower.IndexOf("," + dr[MenuInfoTable.Id].ToString() + ",") < 0)
                        {
                            continue;
                        }

                        //創建樹節點
                        var treenode = new FineUI.TreeNode();
                        //設置節點ID
                        treenode.NodeID = dr[MenuInfoTable.Id].ToString();
                        //設置節點名稱
                        treenode.Text = dr[MenuInfoTable.Name].ToString();
                        treenode.Target = "mainRegion";
                        //判斷當前節點是否為最終節點
                        if (int.Parse(dr[MenuInfoTable.IsMenu].ToString()) != 0)
                        {
                            //設置節點鏈接地址，並在Url後面添加頁面加密參數
                            treenode.NavigateUrl = dr[MenuInfoTable.Url].ToString() + "?" + MenuInfoBll.GetInstence().PageUrlEncryptString();
                            treenode.Leaf = true;
                        }
                        else
                        {
                            treenode.NavigateUrl = "";
                            treenode.Leaf = false;
                            //設置樹節點收縮起來
                            treenode.Expanded = false;
                        }

                        //添加子節點
                        AddChildrenNode(dataTable, treenode, dr[MenuInfoTable.Id].ToString());
                        //將節點加入樹列表中
                        leftMenuTree.Nodes.Add(treenode);
                    }
                }
            }
            catch (Exception ex)
            {
                CommonBll.WriteLog("", ex);
            }
        }
        #endregion

        #region 添加子節點
        /// <summary>
        /// 添加子節點
        /// </summary>
        /// <param name="dt">數據表</param>
        /// <param name="treenode">當前樹節點</param>
        /// <param name="parentID">父節點ID值</param>
        private void AddChildrenNode(DataTable dt, FineUI.TreeNode treenode, string parentID)
        {
            //篩選出當前節點下面的子節點
            DataTable Childdt = DataTableHelper.GetFilterData(dt, MenuInfoTable.ParentId, parentID, MenuInfoTable.Sort, "Asc");
            //判斷是否有節點存在
            if (Childdt.Rows.Count > 0)
            {
                //循環讀取節點
                foreach (DataRow dr in Childdt.Rows)
                {
                    //判斷當前節點是否有權限訪問，沒有則跳過本次循環
                    if (_pagePower.IndexOf("," + dr[MenuInfoTable.Id].ToString() + ",") < 0)
                    {
                        continue;
                    }

                    //創建子節點
                    var TreeChildNode = new FineUI.TreeNode();
                    //設置節點ID
                    TreeChildNode.NodeID = dr[MenuInfoTable.Id].ToString();
                    //設置節點名稱
                    TreeChildNode.Text = dr[MenuInfoTable.Name].ToString();
                    TreeChildNode.Target = "mainRegion";
                    //判斷當前節點是否為最終節點
                    if (int.Parse(dr[MenuInfoTable.IsMenu].ToString()) != 0)
                    {
                        //設置節點鏈接地址
                        if (dr[MenuInfoTable.Url].ToString().IndexOf("?") > 0)
                        {
                            TreeChildNode.NavigateUrl = dr[MenuInfoTable.Url].ToString() + "&" + MenuInfoBll.GetInstence().PageUrlEncryptString();
                        }
                        else
                        {
                            TreeChildNode.NavigateUrl = dr[MenuInfoTable.Url].ToString() + "?" + MenuInfoBll.GetInstence().PageUrlEncryptString();
                        }
                        //TreeChildNode.NavigateUrl = dr[MenuInfoTable.Url].ToString() + "?" + MenuInfoBll.PageURLEncryptString();
                        TreeChildNode.Leaf = true;
                    }
                    else
                    {
                        TreeChildNode.NavigateUrl = "";
                        TreeChildNode.Leaf = false;
                        //設置樹節點擴張
                        TreeChildNode.Expanded = true;
                    }
                    //將節點添加進樹列表中
                    treenode.Nodes.Add(TreeChildNode);

                    //遞歸添加子節點
                    AddChildrenNode(dt, TreeChildNode, dr[MenuInfoTable.Id].ToString());

                }

            }

        }

        #endregion

        #endregion

    }
}