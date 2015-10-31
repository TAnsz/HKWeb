using System;
using System.Data;
using DotNet.Utilities;
using Solution.DataAccess.DataModel;
using Solution.Logic.Managers;
using Solution.Web.Managers.WebManage.Application;
using FineUI;


/***********************************************************************
 *   作    者：AllEmpty（陳煥）-- 1654937@qq.com
 *   博    客：http://www.cnblogs.com/EmptyFS/
 *   技 術 群：327360708
 *  
 *   創建日期：2014-06-22
 *   文件名稱：PositionEdit.aspx.cs
 *   描    述：職位編輯頁面
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
                //獲取ID值
                hidPositionId.Text = RequestHelper.GetInt0("Id") + "";

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
            int positionId = ConvertHelper.Cint0(hidPositionId.Text);

            if (positionId != 0)
            {
                //獲取指定ID的職位內容
                var model = T_TABLE_DBll.GetInstence().GetModelForCache(x => x.Id == positionId && x.TABLES.Equals(TABLE));
                if (model == null)
                    return;

                //對頁面窗體進行賦值
                txtCode.Text = model.CODE;
                txtName.Text = model.DESCR;
                HidTables.Text = model.TABLES;
                //設置下拉列表選擇項
                //labBranchName.Text = model.Branch_Name;
                //設置頁面權限
                _pagePower = model.PagePower;
                //設置頁面控件權限
                _controlPower = model.ControlPower;
            }
            else
            {
                //設置類型
                HidTables.Text = TABLE;
            }

            //創建樹節點
            var tnode = new FineUI.TreeNode();
            //設置節點名稱
            tnode.Text = "菜單";
            //設置節點ID
            tnode.NodeID = "0";
            //設置當前節點是否為最終節點
            tnode.Leaf = false;
            //是否可以選擇（打勾）
            tnode.EnableCheckBox = true;
            //是否已經選擇
            tnode.Checked = true;
            //是否自動擴大
            tnode.Expanded = true;
            //開啟點擊節點全選或取消事件
            tnode.EnableCheckEvent = true;

            //根據指定的父ID去查詢相關的子集ID
            var dt = MenuInfoBll.GetInstence().GetDataTable();
            //獲取全部頁面權限
            var pgdt = PagePowerSignBll.GetInstence().GetDataTable();

            //從一級菜單開始添加
            AddNode(dt, pgdt, tnode, "0");

            MenuTree.Nodes.Add(tnode);
        }

        #endregion

        #region 樹列表操作

        /// <summary>
        /// 全選反選
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void MenuTree_NodeCheck(object sender, FineUI.TreeCheckEventArgs e)
        {
            //全選當前節點以下了所有子節點
            if (e.Checked)
            {
                MenuTree.CheckAllNodes(e.Node.Nodes);
                CheckNode(e.Node);
            }
            //取消當前節點以下的所有子節點選擇
            else
            {
                MenuTree.UncheckAllNodes(e.Node.Nodes);
            }
        }

        /// <summary>
        /// 添加子節點
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="node"></param>
        /// <param name="nodeid"></param>
        public void AddNode(DataTable dt, DataTable pgdt, FineUI.TreeNode node, string nodeid)
        {
            //篩選出當前節點下面的子節點
            var childdt = DataTableHelper.GetFilterData(dt, MenuInfoTable.ParentId, nodeid, MenuInfoTable.Sort, "Asc");
            //判斷是否有節點存在
            if (childdt.Rows.Count > 0)
            {
                foreach (DataRow item in childdt.Rows)
                {
                    bool ispage = int.Parse(item[MenuInfoTable.IsMenu].ToString()) != 0;
                    var tnode = new FineUI.TreeNode();
                    //設置節點名稱
                    tnode.Text = item[MenuInfoTable.Name].ToString();
                    //設置節點ID
                    tnode.NodeID = item[MenuInfoTable.Id].ToString();
                    //開啟點擊節點全選或取消事件
                    tnode.EnableCheckEvent = true;

                    //判斷當前節點是否為最終節點
                    if (ispage)
                    {
                        //添加頁面權限
                        //篩選出當前節點下面的頁面權限節點
                        DataTable cdt = DataTableHelper.GetFilterData(pgdt, PagePowerSignTable.MenuInfo_Id, item[MenuInfoTable.Id].ToString(), null, null);
                        //判斷當前節點下是否有設置頁面權限
                        if (cdt == null || cdt.Rows.Count == 0)
                        {
                            tnode.Leaf = true;
                        }
                        else
                        {
                            //設置為非最終節點
                            tnode.Leaf = false;
                            //循環添加頁面權限節點
                            for (int i = 0; i < cdt.Rows.Count; i++)
                            {
                                var tn = new FineUI.TreeNode();
                                //設置節點名稱
                                tn.Text = cdt.Rows[i][PagePowerSignTable.CName].ToString();
                                //設置節點ID
                                tn.NodeID = item[MenuInfoTable.Id].ToString() + "|" + cdt.Rows[i][PagePowerSignTable.PagePowerSignPublic_Id].ToString();
                                tn.Leaf = true;
                                //是否可以選擇（打勾）
                                tn.EnableCheckBox = true;
                                //是否已經選擇
                                if (_controlPower.IndexOf("," + tn.NodeID + ",") >= 0)
                                {
                                    tn.Checked = true;
                                }
                                tnode.Nodes.Add(tn);
                            }
                        }
                    }
                    //是否可以選擇（打勾）
                    tnode.EnableCheckBox = true;
                    //是否已經選擇
                    if (_pagePower.IndexOf("," + tnode.NodeID + ",") >= 0)
                    {
                        tnode.Checked = true;
                    }
                    //是否自動擴大
                    tnode.Expanded = true;

                    //if (!MenuTree.Nodes.Contains(tnode))
                    node.Nodes.Add(tnode);

                    //遞歸添加子節點
                    AddNode(dt, pgdt, tnode, item[MenuInfoTable.Id].ToString());

                }
            }

        }

        /// <summary>
        /// 勾選當前節點
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
        /// 獲取Tree中選中的項
        /// </summary>
        /// <returns>字符串組成的Tree</returns>
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
        /// 數據保存
        /// </summary>
        /// <returns></returns>
        public override string Save()
        {
            string result = string.Empty;
            var positionId = ConvertHelper.Cint0(hidPositionId.Text);
            try
            {
                #region 數據驗證


                if (string.IsNullOrEmpty(txtName.Text.Trim()))
                {
                    return txtName.Label + "不能為空！";
                }
                if (string.IsNullOrEmpty(txtCode.Text.Trim()))
                {
                    return txtCode.Label + "不能為空！";
                }
                //角色編號和名稱不能相同
                var sCode = StringHelper.Left(txtCode.Text, 30);
                var sName = StringHelper.Left(txtName.Text, 30);
                if (T_TABLE_DBll.GetInstence().Exist(x => (x.CODE == sCode || x.DESCR == sName) && x.TABLES == TABLE && x.Id != positionId))
                {
                    return String.Format("{0}或{1}已存在！請重新輸入！", txtCode.Label, txtName.Label);
                }
                #endregion

                #region 賦值


                //獲取實體
                var model = new T_TABLE_D(x => x.Id == positionId && x.TABLES==TABLE);

                ////判斷是否有改變名稱
                //if (positionId > 0 && sName != model.DESCR)
                //{
                //    isUpdate = true;
                //}

                //修改時間與修改人
                model.EDIT_DATE = DateTime.Now;
                model.EDIT_BY = OnlineUsersBll.GetInstence().GetManagerCName();

                //設置名稱
                //model.CODE = sCode;
                model.DESCR = sName;
                //model.TABLES = TABLE;

                //設置職位權限
                //從樹列表中獲取勾選的節點
                GetCheckTreeNode(MenuTree.Nodes);
                //賦予權限
                model.PagePower = StringHelper.FilterSql(_hidPositionPagePower);
                model.ControlPower = StringHelper.FilterSql(_hidPositionControlPower);

                #endregion

                //----------------------------------------------------------
                //存儲到數據庫
                T_TABLE_DBll.GetInstence().Save(this, model);
                //清空字段修改標記
                PageContext.RegisterStartupScript(Panel1.GetClearDirtyReference());
            }
            catch (Exception e)
            {
                result = "保存失敗！";

                //出現異常，保存出錯日誌信息
                CommonBll.WriteLog(result, e);
            }

            return result;
        }
        #endregion
    }
}