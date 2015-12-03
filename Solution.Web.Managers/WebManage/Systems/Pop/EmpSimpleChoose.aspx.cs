using System;
using DotNet.Utilities;
using Solution.DataAccess.DataModel;
using Solution.Logic.Managers;
using FineUI;
using System.Data;


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

namespace Solution.Web.Managers.WebManage.Systems.Pop
{
    public partial class EmpSimpleChoose : EmpChoose
    {
        #region Page_Load

        protected new void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var empid = RequestHelper.GetString("EmpId");
                hEmpid.Text = string.IsNullOrEmpty(empid) ? OnlineUsersBll.GetInstence().GetManagerEmpId() : empid;
                //加載數據
                LoadData();
            }
        }

        #endregion

        #region 接口函數，用於UI頁面初始化，給邏輯層對像、列表等對像賦值

        public void Init()
        {
        }

        #endregion

        /// <summary>讀取數據</summary>
        public new void LoadData()
        {
            //獲取總可顯示的人員列表
            var empid = hEmpid.Text;
            var dt = SPs.pro_USERAUTHORITY_REPORT(empid).ExecuteDataTable();
            if (dt == null) return;
            BandingTree(dt);
        }
        /// <summary>
        /// 綁定數據到樹
        /// </summary>
        /// <param name="dt"></param>
        public new void BandingTree(DataTable dt)
        {
            foreach (DataRow row in dt.Rows)
            {
                //判斷是否是父節點
                if (row[dt.Columns[4].ColumnName].ToString() == "1")
                {
                    continue;
                }
                TreeNode node = new TreeNode
                {
                    Expanded = true,
                    NodeID = row[dt.Columns[1].ColumnName].ToString(),
                    Text = row[dt.Columns[2].ColumnName].ToString(),
                };
                if (row[dt.Columns[3].ColumnName].ToString() == "0")
                {
                    node.Icon = Icon.UserMature;
                    node.Target = "0";
                }
                MenuTree.Nodes.Add(node);
                ResolveSubTree(dt, node);
            }
        }

        private void ResolveSubTree(DataTable dt, TreeNode treeNode)
        {
            var childdt = DataTableHelper.GetFilterData(dt, string.Format("{0}='{1}'", dt.Columns[0].ColumnName, treeNode.NodeID), "Id Asc");
            if (childdt == null) return;
            foreach (DataRow row in childdt.Rows)
            {
                TreeNode node = new TreeNode
                {
                    Expanded = false,
                    NodeID = row[dt.Columns[1].ColumnName].ToString(),
                    Text = row[dt.Columns[2].ColumnName].ToString(),
                };
                if (row[dt.Columns[3].ColumnName].ToString() == "0")
                {
                    node.Icon = Icon.UserMature;
                    node.Target = "0";
                }
                treeNode.Nodes.Add(node);
                ResolveSubTree(dt, node);
            }
            //取得人員列表
        }


        protected new void ButtonOK_Click(object sender, EventArgs e)
        {
            //從樹列表中獲取勾選的節點
            var s = MenuTree.SelectedNode;
            if (s == null || s.Target != "0")
            {
                FineUI.Alert.ShowInParent("請選擇員工!", FineUI.MessageBoxIcon.Information);
                return;
            }
            var str = "Emp=" + s.NodeID;
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference(str));
        }
    }
}