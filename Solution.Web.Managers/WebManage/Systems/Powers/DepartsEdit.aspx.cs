using System;
using DotNet.Utilities;
using Solution.DataAccess.DataModel;
using Solution.Logic.Managers;
using Solution.Web.Managers.WebManage.Application;


/***********************************************************************
 *   作    者：AllEmpty（陳煥）-- 1654937@qq.com
 *   博    客：http://www.cnblogs.com/EmptyFS/
 *   技 術 群：327360708
 *  
 *   創建日期：2014-06-21
 *   文件名稱：DepartsEdit.aspx.cs
 *   描    述：部門編輯頁面
 *             
 *   修 改 人：
 *   修改日期：
 *   修改原因：
 ***********************************************************************/
namespace Solution.Web.Managers.WebManage.Systems.Powers
{
    public partial class DepartsEdit : PageBase
    {

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //獲取ID值
                hidId.Text = RequestHelper.GetInt0("Id") + "";

                //綁定下拉列表
                DepartsBll.GetInstence().BandDropDownListShowAll(this, ddlParentId);

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
            int id = ConvertHelper.Cint0(hidId.Text);

            if (id != 0)
            {
                //獲取指定ID的部門內容
                var model = DepartsBll.GetInstence().GetModelForCache(x => x.Id == id);
                if (model == null)
                    return;

                //對頁面窗體進行賦值
                txtName.Text = model.depart_name;
                //設置下拉列表選擇項
                //ddlParentId.SelectedValue = model.ParentId + "";
                //編輯時不給改變上級部門
                ddlParentId.Enabled = false;
                //設置部門編碼
                txtCode.Text = model.depart_id;
                //設置父ID
                txtParent.Text = model.Up_ID + "";
                //設置排序
                txtSort.Text = model.inside_id + "";
                //設置注備
                txtNotes.Text = model.remark;
            }
        }

        #endregion

        #region 頁面控件綁定
        /// <summary>下拉列表改變事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlParentId_SelectedIndexChanged(object sender, EventArgs e)
        {
            //獲取當前節點的父節點Id
            txtParent.Text = ddlParentId.SelectedValue;
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
            int id = ConvertHelper.Cint0(hidId.Text);

            try
            {
                #region 數據驗證

                if (string.IsNullOrEmpty(txtName.Text.Trim()))
                {
                    return txtName.Label + "不能為空！";
                }
                var sName = StringHelper.Left(txtName.Text, 50);
                if (DepartsBll.GetInstence().Exist(x => x.depart_name == sName && x.Id != id))
                {
                    return txtName.Label + "已存在！請重新輸入！";
                }

                #endregion

                #region 賦值
                //定義是否更新其他關聯表變量
                bool isUpdate = false;

                //獲取實體
                var model = new Departs(x => x.Id == id);

                //判斷是否有改變名稱
                //if (id > 0 && sName != model.Name)
                //{
                //    isUpdate = true;
                //}

                //修改時間與管理員
                //model.op = DateTime.Now;
                //model.Manager_Id = OnlineUsersBll.GetInstence().GetManagerId();
                //model.Manager_CName = OnlineUsersBll.GetInstence().GetManagerCName();

                //設置名稱
                model.depart_name = sName;
                //對應的父類id
                model.Up_ID = txtParent.Text;
                //設置備註
                model.remark = StringHelper.Left(txtNotes.Text, 100);

                //由於限制了編輯時不能修改父節點，所以這裡只對新建記錄時處理
                if (id == 0)
                {
                    //設定當前的深度與設定當前的層數級
                    if (string.IsNullOrEmpty(model.Up_ID))
                    {
                        //設定當前的層數
                        model.TreeLevel = 0;
                    }
                    else
                    {
                        //設定當前的層數級
                        model.TreeLevel = ConvertHelper.Cint0(DepartsBll.GetInstence().GetFieldValue(ConvertHelper.Cint0(ddlParentId.SelectedValue), DepartsTable.TreeLevel)) + 1;
                    }
                }

                //設置排序
                if (txtSort.Text == "0")
                {
                    model.inside_id = DepartsBll.GetInstence().GetSortMax(model.Up_ID) + 10;
                }
                else
                {
                    model.inside_id = ConvertHelper.Cint0(txtSort.Text);
                }

                //新創建部門時，生成對應的部門編碼
                //if (id == 0)
                //{
                //    model.depart_id = SPs.P_Departs_GetMaxDepartsCode(model.Depth + 1, model.ParentId).ExecuteScalar().ToString();
                //}

                #endregion

                //----------------------------------------------------------
                //存儲到數據庫
                DepartsBll.GetInstence().Save(this, model);

                //如果本次修改改變了相關名稱，則同步更新其他關聯表的對應名稱
                //if (isUpdate)
                //{
                //    PositionBll.GetInstence().UpdateValue_For_Departs_Id(this, model.Id, PositionTable.Departs_Name, model.Name);
                //    ManagerBll.GetInstence().UpdateValue_For_Departs_Id(this, model.Id, ManagerTable.Departs_Name, model.Name);
                //}
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