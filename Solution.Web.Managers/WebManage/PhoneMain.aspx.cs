using System;
using DotNet.Utilities;
using Solution.DataAccess.DataModel;
using Solution.Logic.Managers;
using Solution.Web.Managers.WebManage.Application;
using System.Data;
using Solution.DataAccess.DbHelper;
using SubSonic.Query;
using System.Collections.Generic;


/***********************************************************************
 *   作    者：AllEmpty（陳煥）-- 1654937@qq.com
 *   博    客：http://www.cnblogs.com/EmptyFS/
 *   技 術 群：327360708
 *  
 *   創建日期：2014-06-19
 *   文件名稱：MeetingRoomEdit.aspx.cs
 *   描    述：會議室編輯頁面
 *             
 *   修 改 人：
 *   修改日期：
 *   修改原因：
 ***********************************************************************/
namespace Solution.Web.Managers.WebManage
{
    public partial class PhoneMain : PageBase
    {
        //用户页面操作权限
        string _pagePower = "";
        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //加載數據
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
            //获取用户页面操作权限
            _pagePower = OnlineUsersBll.GetInstence().GetPagePower();


            //创建查询条件
            var wheres = new List<ConditionHelper.SqlqueryCondition>();
            //条件：只查询出需要显示的菜单,暫時顯示全部
            wheres.Add(new ConditionHelper.SqlqueryCondition(ConstraintType.And, MenuInfoTable.IsDisplay, Comparison.Equals, "1"));
            //进行查询，获取DataTable
            var dt = MenuInfoBll.GetInstence().GetDataTable(false, 0, null, 0, 0, wheres);
            //绑定树列表
            BandingTree(dt);
        }

        #region FineUI控件之--树控件（Tree）

        #region 绑定树控件
        /// <summary>树控件（Tree）
        /// </summary>
        /// <param name="dataTable">DataTable数据源</param>
        /// <returns>树控件（Tree）</returns>
        public void BandingTree(DataTable dataTable)
        {
            try
            {
                //检查指定的列是否在数据源中能否找到
                if (dataTable.Rows.Count == 0)
                {
                    return;
                }
                //筛选出全部一级节点
                DataTable dtRoot = DataTableHelper.GetFilterData(dataTable, MenuInfoTable.ParentId, "0", MenuInfoTable.Sort, "Asc");
                //判断是否有节点存在
                if (dtRoot.Rows.Count != 0)
                {
                    //循环读取节点
                    foreach (DataRow dr in dtRoot.Rows)
                    {
                        //判断当前节点是否有权限访问，没有则跳过本次循环
                        //暂时先注释掉权限判断，等添加相关权限后再开启
                        if (_pagePower.IndexOf("," + dr[MenuInfoTable.Id].ToString() + ",") < 0)
                        {
                            continue;
                        }

                        //创建树节点
                        var treenode = new FineUI.TreeNode();
                        //设置节点ID
                        treenode.NodeID = dr[MenuInfoTable.Id].ToString();
                        //设置节点名称
                        treenode.Text = dr[MenuInfoTable.Name].ToString();
                        treenode.Target = "mainRegion";
                        //判断当前节点是否为最终节点
                        if (int.Parse(dr[MenuInfoTable.IsMenu].ToString()) != 0)
                        {
                            //设置节点链接地址，并在Url后面添加页面加密参数
                            treenode.NavigateUrl = dr[MenuInfoTable.Url].ToString() + "?" + MenuInfoBll.GetInstence().PageUrlEncryptString();
                            treenode.Leaf = true;
                        }
                        else
                        {
                            treenode.NavigateUrl = "";
                            treenode.Leaf = false;
                            //设置树节点收缩起来
                            treenode.Expanded = false;
                        }

                        //添加子节点
                        AddChildrenNode(dataTable, treenode, dr[MenuInfoTable.Id].ToString());
                        //将节点加入树列表中
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

        #region 添加子节点
        /// <summary>
        /// 添加子节点
        /// </summary>
        /// <param name="dt">数据表</param>
        /// <param name="treenode">当前树节点</param>
        /// <param name="parentID">父节点ID值</param>
        private void AddChildrenNode(DataTable dt, FineUI.TreeNode treenode, string parentID)
        {
            //筛选出当前节点下面的子节点
            DataTable Childdt = DataTableHelper.GetFilterData(dt, MenuInfoTable.ParentId, parentID, MenuInfoTable.Sort, "Asc");
            //判断是否有节点存在
            if (Childdt.Rows.Count > 0)
            {
                //循环读取节点
                foreach (DataRow dr in Childdt.Rows)
                {
                    //判断当前节点是否有权限访问，没有则跳过本次循环
                    if (_pagePower.IndexOf("," + dr[MenuInfoTable.Id].ToString() + ",") < 0)
                    {
                        continue;
                    }

                    //创建子节点
                    var TreeChildNode = new FineUI.TreeNode();
                    //设置节点ID
                    TreeChildNode.NodeID = dr[MenuInfoTable.Id].ToString();
                    //设置节点名称
                    TreeChildNode.Text = dr[MenuInfoTable.Name].ToString();
                    TreeChildNode.Target = "mainRegion";
                    //判断当前节点是否为最终节点
                    if (int.Parse(dr[MenuInfoTable.IsMenu].ToString()) != 0)
                    {
                        //设置节点链接地址
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
                        //设置树节点扩张
                        TreeChildNode.Expanded = true;
                    }
                    //将节点添加进树列表中
                    treenode.Nodes.Add(TreeChildNode);

                    //递归添加子节点
                    AddChildrenNode(dt, TreeChildNode, dr[MenuInfoTable.Id].ToString());

                }

            }

        }

        #endregion

        #endregion
        #endregion
    }
}