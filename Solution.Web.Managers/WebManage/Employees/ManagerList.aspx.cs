using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.UI;
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
 *   創建日期：2014-06-27
 *   文件名稱：ManagerList.aspx.cs
 *   描    述：在職員工列表管理
 *             
 *   修 改 人：
 *   修改日期：
 *   修改原因：
 ***********************************************************************/
using SubSonic.Query;

namespace Solution.Web.Managers.WebManage.Employees
{
    public partial class ManagerList : PageBase
    {
        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //綁定部門
                DepartsBll.GetInstence().BandDropDownListShowAll(this, ddlBranch_Id);

                LoadData();
            }
        }
        #endregion

        #region 接口函數，用於UI頁面初始化，給邏輯層對像、列表等對像賦值
        public override void Init()
        {
            //邏輯對像賦值
            bll = EmployeeBll.GetInstence();
            //表格對像賦值
            grid = Grid1;
            //初始化默認排序
            if (grid != null && grid.AllowSorting)
            {
                sortList = new List<string> { grid.SortField + " " + grid.SortDirection };
            }
            //pc界面自動縮放
            PageManager1.AutoSizePanelID = CommonBll.IsPC(this) ? "Panel1" : "";
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
            if (bll != null) bll.BindGrid(Grid1, 0, 0, InquiryCondition(), sortList);
        }

        /// <summary>
        /// 查詢條件
        /// </summary>
        /// <returns></returns>
        private List<ConditionHelper.SqlqueryCondition> InquiryCondition()
        {
            var wheres = new List<ConditionHelper.SqlqueryCondition>();
            //添加條件：只顯示在職人員
            wheres.Add(new ConditionHelper.SqlqueryCondition(ConstraintType.And, EmployeeTable.KIND, Comparison.Equals,
                1));

            //默認不顯示無卡號員工
            wheres.Add(new ConditionHelper.SqlqueryCondition(ConstraintType.And, EmployeeTable.CARD_ID,
                    Comparison.GreaterThan, "''"));

            //登陸賬號
            if (!string.IsNullOrEmpty(txtLoginName.Text.Trim()))
            {
                wheres.Add(new ConditionHelper.SqlqueryCondition(ConstraintType.And, EmployeeTable.EMP_ID,
                    Comparison.Like, "%" + StringHelper.FilterSql(txtLoginName.Text) + "%"));
            }
            //中文名稱
            if (!string.IsNullOrEmpty(txtCName.Text.Trim()))
            {
                wheres.Add(new ConditionHelper.SqlqueryCondition(ConstraintType.And, EmployeeTable.EMP_FNAME, Comparison.Like,
                    "%" + StringHelper.FilterSql(txtCName.Text) + "%"));
            }
            //綁定部門編碼
            if (ddlBranch_Id.SelectedValue != "0")
            {
                wheres.Add(new ConditionHelper.SqlqueryCondition(ConstraintType.And, EmployeeTable.DEPART_ID, Comparison.StartsWith,
                    StringHelper.FilterSql(ddlBranch_Id.SelectedValue)));
            }

            return wheres;
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
            var lbfEdit = Grid1.FindColumn("ButtonEdit") as LinkButtonField;
            lbfEdit.Text = "編輯";
            lbfEdit.Enabled = MenuInfoBll.GetInstence().CheckControlPower(this, "ButtonEdit");
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
            //獲取當前點擊列的主鍵ID
            object id = gr.DataKeys[0];

            switch (e.CommandName)
            {
                case "LoginLog":
                    Window2.IFrameUrl = "../Systems/Security/LoginLogList.aspx?Id=" + id + "&" + MenuInfoBll.GetInstence().PageUrlEncryptStringNoKey(id + "");
                    Window2.Hidden = false;
                    break;
                case "UserLog":
                    Window2.IFrameUrl = "../Systems/Security/UseLogList.aspx?Id=" + id + "&" + MenuInfoBll.GetInstence().PageUrlEncryptStringNoKey(id + "");
                    Window2.Hidden = false;
                    break;
                case "ButtonEdit":
                    //打開編輯窗口
                    Window1.IFrameUrl = "ManagerEdit.aspx?Id=" + id + "&" + MenuInfoBll.GetInstence().PageUrlEncryptStringNoKey(id + "");
                    Window1.Hidden = false;

                    break;
            }
        }
        #endregion

        #endregion

        #region 添加新記錄
        /// <summary>
        /// 添加新記錄
        /// </summary>
        public override void Add()
        {
            Window1.IFrameUrl = "ManagerEdit.aspx?" + MenuInfoBll.GetInstence().PageUrlEncryptString();
            Window1.Hidden = false;
        }
        #endregion

        #region 設置員工離職
        /// <summary>
        /// 設置員工離職
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonStaffTurnover_Click(object sender, EventArgs e)
        {
            //獲取要操作的ID
            var id = GridViewHelper.GetSelectedKeyIntArray(Grid1);

            //如果沒有選擇記錄，則直接退出
            if (id == null)
            {
                FineUI.Alert.ShowInParent("請選擇你要處理的記錄", FineUI.MessageBoxIcon.Information);
            }

            try
            {
                //逐個設置離職
                foreach (var i in id)
                {
                    var name = EmployeeBll.GetInstence().GetEMP_FNAME(this, i);
                    EmployeeBll.GetInstence().UpdateValue(this, i, EmployeeTable.KIND, 0, EmployeeTable.ISSUED, 0, "{0}將員工" + name + "[" + i + "]設置為離職狀態");
                }

                LoadData();

                FineUI.Alert.ShowInParent("編號Id為[" + string.Join(",", id) + "]的員工已設置為離職", FineUI.MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                string result = "嘗試設置編號ID為[" + string.Join(",", id) + "]的員工離職失敗！";

                //出現異常，保存出錯日誌信息
                CommonBll.WriteLog(result, ex);

                FineUI.Alert.ShowInParent(result, FineUI.MessageBoxIcon.Information);
            }
        }
        #endregion

        protected void Button1_OnClick1_Click(object sender, EventArgs e)
        {
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=employee.xls");
            Response.ContentType = "application/excel";
            Response.ContentEncoding = Encoding.UTF8;
            var html = GetGridTableHtml(Grid1);
            Response.Write(html);
            Response.End();

        }
        private string GetGridTableHtml(Grid grid1)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("<meta http-equiv=\"content-type\" content=\"application/excel; charset=UTF-8\"/>");

            sb.Append("<table cellspacing=\"0\" rules=\"all\" border=\"1\" style=\"border-collapse:collapse;\">");

            sb.Append("<tr>");
            foreach (GridColumn column in grid1.Columns.TakeWhile(column => column.ColumnID != "LoginLog"))
            {
                sb.AppendFormat("<td>{0}</td>", column.HeaderText);
            }
            sb.Append("</tr>");


            foreach (GridRow row in grid1.Rows)
            {
                sb.Append("<tr>");
                foreach (object value in row.Values)
                {
                    string html = value.ToString();
                    if (html.Contains("LoginLog"))
                    {
                        break;
                    }
                    if (html.StartsWith(Grid.TEMPLATE_PLACEHOLDER_PREFIX))
                    {
                        // 模板列
                        string templateId = html.Substring(Grid.TEMPLATE_PLACEHOLDER_PREFIX.Length);
                        Control templateCtrl = row.FindControl(templateId);
                        html = GetRenderedHtmlSource(templateCtrl);
                    }
                    else
                    {
                        // 处理CheckBox
                        if (html.Contains("f-grid-static-checkbox"))
                        {
                            html = html.Contains("uncheck") ? "×" : "√";
                        }

                        // 处理图片
                        if (html.Contains("<img"))
                        {
                            string prefix = Request.Url.AbsoluteUri.Replace(Request.Url.AbsolutePath, "");
                            html = html.Replace("src=\"", "src=\"" + prefix);
                        }
                    }
                    //處理數字格式
                    sb.AppendFormat(
                        StringPlus.IsNumberId(html) ? "<td style='vnd.ms-excel.numberformat:@;'>{0}</td>" : "<td>{0}</td>",
                        html);
                }
                sb.Append("</tr>");
            }

            sb.Append("</table>");

            return sb.ToString();
        }

        /// <summary>
        /// 获取控件渲染后的HTML源代码
        /// </summary>
        /// <param name="ctrl"></param>
        /// <returns></returns>
        private string GetRenderedHtmlSource(Control ctrl)
        {
            if (ctrl == null) return string.Empty;
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter htw = new HtmlTextWriter(sw))
                {
                    ctrl.RenderControl(htw);

                    return sw.ToString();
                }
            }
        }

    }
}