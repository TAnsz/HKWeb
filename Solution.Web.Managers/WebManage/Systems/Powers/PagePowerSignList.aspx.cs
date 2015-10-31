using System;
using System.Collections.Generic;
using System.Data;
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
 *   創建日期：2014-06-21
 *   文件名稱：PagePowerSignList.aspx.cs
 *   描    述：頁面控件權限管理
 *             
 *   修 改 人：
 *   修改日期：
 *   修改原因：
 ***********************************************************************/
using SubSonic.Query;

namespace Solution.Web.Managers.WebManage.Systems.Powers
{
    public partial class PagePowerSignList : PageBase
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

        }
        #endregion

        #region 加載數據
        /// <summary>讀取數據</summary>
        public override void LoadData()
        {
            if (MenuTree.Nodes.Count == 0)
            {
                //創建樹節點
                var tnode = new FineUI.TreeNode();
                //設置節點名稱
                tnode.Text = "菜單";
                //設置節點ID
                tnode.NodeID = "0";
                //設置當前節點是否為最終節點
                tnode.Leaf = false;
                //是否自動擴大
                tnode.Expanded = true;

                //根據指定的父ID去查詢相關的子集ID
                var dt = MenuInfoBll.GetInstence().GetDataTable();
                //從一級菜單開始添加
                AddNode(dt, tnode, "0");

                MenuTree.Nodes.Add(tnode);
            }

            BindGrid();
        }

        private void BindGrid()
        {
            var index = ConvertHelper.Cint0(hidId.Text);
            if (index == 0)
            {
                return;
            }

            //設置查詢條件
            var wheres = new List<ConditionHelper.SqlqueryCondition>();
            wheres.Add(new ConditionHelper.SqlqueryCondition(ConstraintType.And, PagePowerSignTable.MenuInfo_Id, Comparison.Equals, index));

            //設置排序
            var _order = new List<string>();
            _order.Add(PagePowerSignTable.Id);

            //獲取DataTable
            var dt = PagePowerSignBll.GetInstence().GetDataTable(false, 0, null, 0, 0, wheres, _order);

            if (dt == null || dt.Rows.Count == 0)
            {
                Grid2.DataSource = null;
                Grid2.DataBind();
                PagePowerSignPublicBll.GetInstence().BindGrid(Grid1, 0, 0, null, _order);
            }
            else
            {
                //綁定到表格——已綁定控件列表
                //PagePowerSignBll.GetInstence().BindGrid(Grid2, 0, 0, list, _order);
                Grid2.DataSource = dt;
                Grid2.DataBind();

                var id = DataTableHelper.GetArrayInt(dt, PagePowerSignTable.PagePowerSignPublic_Id);

                wheres = new List<ConditionHelper.SqlqueryCondition>();
                wheres.Add(new ConditionHelper.SqlqueryCondition(ConstraintType.And, PagePowerSignPublicTable.Id, Comparison.NotIn, id));

                PagePowerSignPublicBll.GetInstence().BindGrid(Grid1, 0, 0, wheres, _order);

            }
        }

        #region 添加子節點
        /// <summary>
        /// 添加子節點
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="node"></param>
        /// <param name="nodeid"></param>
        private void AddNode(DataTable dt, FineUI.TreeNode node, string nodeid)
        {
            //篩選出當前節點下面的子節點
            var Childdt = DataTableHelper.GetFilterData(dt, MenuInfoTable.ParentId, nodeid, MenuInfoTable.Sort, "Asc");
            //判斷是否有節點存在
            if (Childdt.Rows.Count > 0)
            {
                foreach (DataRow item in Childdt.Rows)
                {
                    bool ispage = int.Parse(item[MenuInfoTable.IsMenu].ToString()) == 0 ? false : true;
                    var tnode = new FineUI.TreeNode();
                    //設置節點名稱
                    tnode.Text = item[MenuInfoTable.Name].ToString();
                    //設置節點ID
                    tnode.NodeID = item[MenuInfoTable.Id].ToString();

                    //判斷當前節點是否為最終節點
                    if (ispage)
                    {
                        tnode.Leaf = true;
                        tnode.EnableClickEvent = true;
                    }
                    else
                    {
                        tnode.EnableClickEvent = false;
                        tnode.Enabled = false;
                    }
                    //是否自動擴大
                    tnode.Expanded = true;

                    //if (!TreeMenu.Nodes.Contains(tnode))
                    node.Nodes.Add(tnode);

                    //遞歸添加子節點
                    AddNode(dt, tnode, item[MenuInfoTable.Id].ToString());

                }
            }

        }
        #endregion

        #endregion

        #region 列表屬性綁定
        /// <summary>
        /// 樹列表點擊事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void MenuTree_NodeCommand(object sender, FineUI.TreeCommandEventArgs e)
        {
            hidId.Text = e.Node.NodeID;
            BindGrid();
        }
        #endregion

        #region 按鍵事件

        /// <summary>
        /// 頁面綁定控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonEmpower_Click(object sender, EventArgs e)
        {
            //獲取當前選擇的菜單項
            var index = ConvertHelper.Cint0(hidId.Text);
            //獲取當前用戶選擇的全部記錄Id
            var id = GridViewHelper.GetSelectedKeyIntArray(Grid1);
            //如果沒有選擇項，則直接退出
            if (index == 0 || id == null || id.Length == 0)
                return;

            //添加到綁定表中
            foreach (var i in id)
            {
                //檢查當前控件是否已添加
                //添加前判斷一下本權限標籤是否已添加過了，沒有則進行添加
                if (!PagePowerSignBll.GetInstence().Exist(x => x.MenuInfo_Id == index && x.PagePowerSignPublic_Id == i))
                {
                    var ppsp = PagePowerSignPublicBll.GetInstence().GetModelForCache(i);
                    if (ppsp == null)
                    {
                        continue;
                    }

                    var model = new PagePowerSign();
                    model.MenuInfo_Id = index;
                    model.PagePowerSignPublic_Id = i;
                    model.CName = ppsp.CName;
                    model.EName = ppsp.EName;

                    PagePowerSignBll.GetInstence().Save(this, model);
                }
            }

            BindGrid();
        }

        /// <summary>
        /// 取消綁定控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            //獲取當前選擇的菜單項
            var index = ConvertHelper.Cint0(hidId.Text);
            //獲取當前用戶選擇的全部記錄Id
            var id = GridViewHelper.GetSelectedKeyIntArray(Grid2);
            //如果沒有選擇項，則直接退出
            if (index == 0 || id == null || id.Length == 0)
                return;

            //刪除已綁定控件
            PagePowerSignBll.GetInstence().Delete(this, id);

            BindGrid();
        }

        /// <summary>
        /// 清空綁定控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonEmpty_Click(object sender, EventArgs e)
        {
            //獲取當前選擇的菜單項
            var index = ConvertHelper.Cint0(hidId.Text);
            //如果沒有選擇項，則直接退出
            if (index == 0)
                return;

            //刪除已綁定控件
            PagePowerSignBll.GetInstence().Delete(this, x => x.MenuInfo_Id == index);

            BindGrid();
        }
        #endregion
    }
}