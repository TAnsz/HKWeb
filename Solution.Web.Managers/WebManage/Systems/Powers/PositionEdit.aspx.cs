using System;
using System.Data;
using DotNet.Utilities;
using Solution.DataAccess.DataModel;
using Solution.Logic.Managers;
using Solution.Web.Managers.WebManage.Application;


/***********************************************************************
 *   作    者：AllEmpty（陈焕）-- 1654937@qq.com
 *   博    客：http://www.cnblogs.com/EmptyFS/
 *   技 术 群：327360708
 *  
 *   创建日期：2014-06-22
 *   文件名称：PositionEdit.aspx.cs
 *   描    述：职位编辑页面
 *             
 *   修 改 人：
 *   修改日期：
 *   修改原因：
 ***********************************************************************/
namespace Solution.Web.Managers.WebManage.Systems.Powers
{
    public partial class PositionEdit : PageBase
    {
        private string _pagePower = "";
        private string _controlPower = "";
        protected const string TABLE = "AUTH";
        string _hidPositionPagePower;
        string _hidPositionControlPower;

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            _hidPositionPagePower = ",";
            _hidPositionControlPower = ",";

            if (!IsPostBack)
            {
                //获取ID值
                hidPositionId.Text = RequestHelper.GetInt0("Id") + "";

                //加载数据
                LoadData();
            }
        }
        #endregion

        #region 接口函数，用于UI页面初始化，给逻辑层对象、列表等对象赋值
        public override void Init()
        {

        }
        #endregion

        #region 加载数据
        /// <summary>读取数据</summary>
        public override void LoadData()
        {
            int positionId = ConvertHelper.Cint0(hidPositionId.Text);

            if (positionId != 0)
            {
                //获取指定ID的职位内容
                var model = T_TABLE_DBll.GetInstence().GetModelForCache(x => x.Id == positionId && x.TABLES.Equals(TABLE));
                if (model == null)
                    return;

                //对页面窗体进行赋值
                txtCode.Text = model.CODE;
                txtName.Text = model.DESCR;
                HidTables.Text = model.TABLES;
                //设置下拉列表选择项
                //labBranchName.Text = model.Branch_Name;
                //设置页面权限
                _pagePower = model.PagePower;
                //设置页面控件权限
                _controlPower = model.ControlPower;
            }
            else
            {
                //设置类型
                HidTables.Text = TABLE;
            }

            //创建树节点
            var tnode = new FineUI.TreeNode();
            //设置节点名称
            tnode.Text = "菜单";
            //设置节点ID
            tnode.NodeID = "0";
            //设置当前节点是否为最终节点
            tnode.Leaf = false;
            //是否可以选择（打勾）
            tnode.EnableCheckBox = true;
            //是否已经选择
            tnode.Checked = true;
            //是否自动扩大
            tnode.Expanded = true;
            //开启点击节点全选或取消事件
            tnode.EnableCheckEvent = true;

            //根据指定的父ID去查询相关的子集ID
            var dt = MenuInfoBll.GetInstence().GetDataTable();
            //获取全部页面权限
            var pgdt = PagePowerSignBll.GetInstence().GetDataTable();

            //从一级菜单开始添加
            AddNode(dt, pgdt, tnode, "0");

            MenuTree.Nodes.Add(tnode);
        }

        #endregion

        #region 树列表操作

        /// <summary>
        /// 全选反选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void MenuTree_NodeCheck(object sender, FineUI.TreeCheckEventArgs e)
        {
            //全选当前节点以下了所有子节点
            if (e.Checked)
            {
                MenuTree.CheckAllNodes(e.Node.Nodes);
                CheckNode(e.Node);
            }
            //取消当前节点以下的所有子节点选择
            else
            {
                MenuTree.UncheckAllNodes(e.Node.Nodes);
            }
        }

        /// <summary>
        /// 添加子节点
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="node"></param>
        /// <param name="nodeid"></param>
        public void AddNode(DataTable dt, DataTable pgdt, FineUI.TreeNode node, string nodeid)
        {
            //筛选出当前节点下面的子节点
            var childdt = DataTableHelper.GetFilterData(dt, MenuInfoTable.ParentId, nodeid, MenuInfoTable.Sort, "Asc");
            //判断是否有节点存在
            if (childdt.Rows.Count > 0)
            {
                foreach (DataRow item in childdt.Rows)
                {
                    bool ispage = int.Parse(item[MenuInfoTable.IsMenu].ToString()) != 0;
                    var tnode = new FineUI.TreeNode();
                    //设置节点名称
                    tnode.Text = item[MenuInfoTable.Name].ToString();
                    //设置节点ID
                    tnode.NodeID = item[MenuInfoTable.Id].ToString();
                    //开启点击节点全选或取消事件
                    tnode.EnableCheckEvent = true;

                    //判断当前节点是否为最终节点
                    if (ispage)
                    {
                        //添加页面权限
                        //筛选出当前节点下面的页面权限节点
                        DataTable cdt = DataTableHelper.GetFilterData(pgdt, PagePowerSignTable.MenuInfo_Id, item[MenuInfoTable.Id].ToString(), null, null);
                        //判断当前节点下是否有设置页面权限
                        if (cdt == null || cdt.Rows.Count == 0)
                        {
                            tnode.Leaf = true;
                        }
                        else
                        {
                            //设置为非最终节点
                            tnode.Leaf = false;
                            //循环添加页面权限节点
                            for (int i = 0; i < cdt.Rows.Count; i++)
                            {
                                var tn = new FineUI.TreeNode();
                                //设置节点名称
                                tn.Text = cdt.Rows[i][PagePowerSignTable.CName].ToString();
                                //设置节点ID
                                tn.NodeID = item[MenuInfoTable.Id].ToString() + "|" + cdt.Rows[i][PagePowerSignTable.PagePowerSignPublic_Id].ToString();
                                tn.Leaf = true;
                                //是否可以选择（打勾）
                                tn.EnableCheckBox = true;
                                //是否已经选择
                                if (_controlPower.IndexOf("," + tn.NodeID + ",") >= 0)
                                {
                                    tn.Checked = true;
                                }
                                tnode.Nodes.Add(tn);
                            }
                        }
                    }
                    //是否可以选择（打勾）
                    tnode.EnableCheckBox = true;
                    //是否已经选择
                    if (_pagePower.IndexOf("," + tnode.NodeID + ",") >= 0)
                    {
                        tnode.Checked = true;
                    }
                    //是否自动扩大
                    tnode.Expanded = true;

                    //if (!MenuTree.Nodes.Contains(tnode))
                    node.Nodes.Add(tnode);

                    //递归添加子节点
                    AddNode(dt, pgdt, tnode, item[MenuInfoTable.Id].ToString());

                }
            }

        }

        /// <summary>
        /// 勾选当前节点
        /// </summary>
        /// <param name="node"></param>
        public void CheckNode(FineUI.TreeNode node)
        {
            FineUI.TreeNode pnode = node.ParentNode;

            while (pnode != null)
            {
                pnode.Checked = true;
                pnode = pnode.ParentNode;
            }
        }



        /// <summary>
        /// 获取Tree中选中的项
        /// </summary>
        /// <returns>字符串组成的Tree</returns>
        public void GetCheckTreeNode(FineUI.TreeNodeCollection node)
        {
            for (int i = 0; i < node.Count; i++)
            {
                if (node[i].Checked)
                {
                    if (node[i].NodeID != "0")
                    {
                        if (node[i].NodeID.IndexOf("|") < 0)
                        {
                            _hidPositionPagePower += node[i].NodeID + ",";
                        }
                        else
                        {
                            _hidPositionControlPower += node[i].NodeID + ",";
                        }

                    }

                    GetCheckTreeNode(node[i].Nodes);

                }
            }


        }
        #endregion

        #region 保存
        /// <summary>
        /// 数据保存
        /// </summary>
        /// <returns></returns>
        public override string Save()
        {
            string result = string.Empty;
            var positionId = ConvertHelper.Cint0(hidPositionId.Text);
            try
            {
                #region 数据验证


                if (string.IsNullOrEmpty(txtName.Text.Trim()))
                {
                    return txtName.Label + "不能为空！";
                }
                if (string.IsNullOrEmpty(txtCode.Text.Trim()))
                {
                    return txtCode.Label + "不能为空！";
                }
                //角色编号和名称不能相同
                var sCode = StringHelper.Left(txtCode.Text, 30);
                var sName = StringHelper.Left(txtName.Text, 30);
                if (T_TABLE_DBll.GetInstence().Exist(x => (x.CODE == sCode || x.DESCR == sName) && x.TABLES == TABLE && x.Id != positionId))
                {
                    return String.Format("{0}或{1}已存在！请重新输入！", txtCode.Label, txtName.Label);
                }
                #endregion

                #region 赋值


                //获取实体
                var model = new T_TABLE_D(x => x.Id == positionId && x.TABLES==TABLE);

                ////判断是否有改变名称
                //if (positionId > 0 && sName != model.DESCR)
                //{
                //    isUpdate = true;
                //}

                //修改时间与修改人
                model.EDIT_DATE = DateTime.Now;
                model.EDIT_BY = OnlineUsersBll.GetInstence().GetManagerCName();

                //设置名称
                //model.CODE = sCode;
                model.DESCR = sName;
                //model.TABLES = TABLE;

                //设置职位权限
                //从树列表中获取勾选的节点
                GetCheckTreeNode(MenuTree.Nodes);
                //赋予权限
                model.PagePower = StringHelper.FilterSql(_hidPositionPagePower);
                model.ControlPower = StringHelper.FilterSql(_hidPositionControlPower);

                #endregion

                //----------------------------------------------------------
                //存储到数据库
                T_TABLE_DBll.GetInstence().Save(this, model);
                //清空字段修改標記
                PageContext.RegisterStartupScript(Panel1.GetClearDirtyReference());
            }
            catch (Exception e)
            {
                result = "保存失败！";

                //出现异常，保存出错日志信息
                CommonBll.WriteLog(result, e);
            }

            return result;
        }
        #endregion
    }
}