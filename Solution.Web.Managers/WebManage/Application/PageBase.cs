using System;
using System.Collections.Generic;
using System.Web.UI;
using DotNet.Utilities;
using FineUI;
using Solution.Logic.Managers;
using Solution.Logic.Managers.Application;

/***********************************************************************
 *   作    者：AllEmpty（陳煥）-- 1654937@qq.com
 *   博    客：http://www.cnblogs.com/EmptyFS/
 *   技 術 群：327360708
 *  
 *   創建日期：2014-06-17
 *   文件名稱：PageBase.cs
 *   描    述：Web層頁面父類
 *             封裝了各種常用函數，減少重複代碼的編寫
 *   修 改 人：
 *   修改日期：
 *   修改原因：
 ***********************************************************************/
namespace Solution.Web.Managers.WebManage.Application
{
    /// <summary>
    /// Web層頁面父類
    /// </summary>
    public abstract class PageBase : System.Web.UI.Page, IPageBase
    {
        #region 定義對像
        //邏輯層接口對像
        protected ILogicBase bll = null;
        //定義列表對像
        protected FineUI.Grid grid = null;
        //頁面排序容器
        protected List<string> sortList = null;

        #endregion

        #region 初始化函數
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            //檢測用戶是否超時退出
            OnlineUsersBll.GetInstence().IsTimeOut();
            //檢測用戶登錄的有效性（是否被系統踢下線或管理員踢下線）
            if (OnlineUsersBll.GetInstence().IsOffline(this))
                return;

            if (!IsPostBack)
            {
                //檢測當前頁面是否有訪問權限
                MenuInfoBll.GetInstence().CheckPagePower(this);

                #region 設置頁面按鍵權限
                try
                {
                    //定義按鍵控件
                    //找到頁面放置按鍵控件的位置
                    ControlCollection controls = MenuInfoBll.GetInstence().GetControls(Controls, "toolBar");
                    //逐個讀取出來
                    for (int i = 0; i < controls.Count; i++)
                    {
                        //取出控件
                        var btnControl = controls[i];
                        //判斷是否除了刷新、查詢和關閉以外的按鍵
                        if (btnControl.ID == "ButtonRefresh" || btnControl.ID == "ButtonSearch" ||
                            btnControl.ID == "ButtonClose" || btnControl.ID == "ButtonReset") continue;
                        //是的話檢查該按鍵當前用戶是否有控件權限，沒有的話則禁用該按鍵
                        var s = MenuInfoBll.GetInstence().CheckControlPower(this, btnControl.ID);
                        if (btnControl is FineUI.Button)
                        {
                            ((FineUI.Button) btnControl).Enabled = s;
                        }
                        if (btnControl is FineUI.FileUpload)
                        {
                            ((FineUI.FileUpload)btnControl).Enabled = s;
                        }
                    }
                }
                catch (Exception)
                {
                    // ignored
                }

                #endregion

                //記錄用戶當前所在的頁面位置
                CommonBll.UserRecord(this);
            }

            //運行UI頁面初始化函數，子類繼承後需要重寫本函數，以提供給本初始化函數調用
            Init();

            //如果列表項不為空時，綁定空數據顯示內容
            if (grid != null)
                grid.EmptyText = string.Format("<img src=\"{0}\" alt=\"No Data Found!\"/>", ResolveUrl("/WebManage/Images/no_data_found.jpg"));
        }


        /// <summary>
        /// 對頁面或其控件的內容進行最後更改
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreRender(EventArgs e)
        {
            //利用反射的方式給頁面控件賦值
            //查找指定名稱控件
            var control = MenuInfoBll.GetInstence().FindControl(this.Controls, "lblSpendingTime");
            if (control != null)
            {
                //判斷是否是FineUI.HiddenField類型
                var type = control.GetType();
                if (type.FullName == "FineUI.Label")
                {
                    //存儲排序列字段名稱
                    ((FineUI.Label)control).Text = "執行耗時：" + Session["SpendingTime"] + "秒";
                }
            }

            base.OnPreRender(e);
        }
        #endregion

        #region 接口函數，用於UI頁面初始化，給邏輯層對像、列表等對像賦值

        /// <summary>
        /// 接口函數，用於UI頁面初始化，給邏輯層對像、列表等對像賦值
        /// </summary>
        public abstract void Init();

        #endregion

        #region 頁面各種按鍵事件

        /// <summary>
        /// 刷新按鈕事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonRefresh_Click(object sender, EventArgs e)
        {
            FineUI.PageContext.RegisterStartupScript("window.location.reload()");
        }

        /// <summary>
        /// 關閉
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonClose_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());

        }
        /// <summary>
        /// 查詢
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            Add();
        }

        /// <summary>
        /// 編輯
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonEdit_Click(object sender, EventArgs e)
        {
            Edit();
        }

        /// <summary>
        /// 刪除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            //執行刪除操作，返回刪除結果
            string result = Delete();

            if (string.IsNullOrEmpty(result))
                return;
            //彈出提示框
            FineUI.Alert.ShowInParent(result, FineUI.MessageBoxIcon.Information);

            //重新加載頁面表格
            LoadData();
        }


        /// <summary>
        /// 保存數據
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            //執行保存操作，返回保存結果
            string result = Save();

            if (string.IsNullOrEmpty(result))
            {
                FineUI.Alert.ShowInParent("保存成功", "提示", FineUI.MessageBoxIcon.Information, ActiveWindow.GetHidePostBackReference());
            }
            else
            {
                //by july，部分頁面保存後，必須刷新原頁面的，把返回的值用 "{url}" + 跳轉地址的方式傳過來
                if (StringHelper.Left(result, 5) == "{url}")
                {
                    string url = result.Trim().Substring(5);
                    FineUI.Alert.ShowInParent("保存成功", "", FineUI.MessageBoxIcon.Information, "self.location='" + url + "'");
                }
                else
                {
                    FineUI.Alert.ShowInParent(result, FineUI.MessageBoxIcon.Information);
                }
            }
        }

        /// <summary>保存排序</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonSaveSort_Click(object sender, EventArgs e)
        {
            SaveSort();
        }

        /// <summary>自動排序</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonSaveAutoSort_Click(object sender, EventArgs e)
        {
            //默認使用多級分類
            SaveAutoSort();
        }

        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Grid1_Sort(object sender, FineUI.GridSortEventArgs e)
        {
            //生成排序關鍵字
            Sort(e);
            //刷新列表
            LoadData();
        }

        /// <summary>
        /// 分頁
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Grid1_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            if (grid != null)
            {
                grid.PageIndex = e.NewPageIndex;

                LoadData();
            }
        }

        #region 關閉子窗口事件
        /// <summary>
        /// 關閉子窗口事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void Window1_Close(object sender, WindowCloseEventArgs e)
        {
            LoadData();
        }

        /// <summary>
        /// 關閉子窗口事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void Window2_Close(object sender, WindowCloseEventArgs e)
        {
            LoadData();
        }

        /// <summary>
        /// 關閉子窗口事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void Window3_Close(object sender, WindowCloseEventArgs e)
        {
            LoadData();
        }
        #endregion

        #endregion

        #region 虛函數，主要給頁面各種按鍵事件調用，子類需要使用到相關功能時必須將它實現

        /// <summary>
        /// 加載事件
        /// </summary>
        public abstract void LoadData();

        /// <summary>
        /// 添加記錄
        /// </summary>
        public virtual void Add() { }

        /// <summary>
        /// 修改記錄
        /// </summary>
        public virtual void Edit() { }

        /// <summary>
        /// 刪除記錄
        /// </summary>
        /// <returns>返回刪除結果</returns>
        public virtual string Delete()
        {
            return null;
        }

        /// <summary>
        /// 保存數據
        /// </summary>
        /// <returns>返回保存結果</returns>
        public virtual string Save()
        {
            return "";
        }

        /// <summary>
        /// 保存排序
        /// </summary>
        /// <returns>返回保存結果</returns>
        public virtual void SaveSort()
        {
            //保存排序
            if (grid != null && bll != null)
            {
                //更新排序
                if (bll.UpdateSort(this, grid, "tbSort"))
                {
                    //重新加載列表
                    LoadData();

                    Alert.ShowInParent("操作成功", "保存排序成功", "window.location.reload();");
                }
                else
                {
                    Alert.ShowInParent("操作成失敗", "保存排序失敗");
                }
            }
        }

        /// <summary>
        /// 保存自動排序
        /// </summary>
        public virtual void SaveAutoSort()
        {
            if (bll == null)
            {
                Alert.ShowInParent("保存失敗", "邏輯層對像為null，請聯繫開發人員給當前頁面的邏輯層對像賦值");
                return;
            }

            if (bll.UpdateAutoSort(this, "", true))
            {
                //刷新列表
                LoadData();

                Alert.ShowInParent("保存成功", "保存自動排序成功", "window.location.reload();");
            }
            else
            {
                Alert.ShowInParent("保存失敗", "保存自動排序失敗");
            }
        }

        /// <summary>
        /// 生成排序關鍵字
        /// </summary>
        /// <param name="e"></param>
        public virtual void Sort(FineUI.GridSortEventArgs e)
        {
            //處理排序
            sortList = null;
            sortList = new List<string>();
            //排序列字段名稱
            string sortName = "";

            if (e != null && e.SortField.Length > 0)
            {
                //判斷是升序還是降序
                if (e.SortDirection != null && e.SortDirection.ToUpper() == "DESC")
                {
                    sortList.Add(e.SortField + " desc");
                }
                else
                {
                    sortList.Add(e.SortField + " asc");
                }
                sortName = e.SortField;
            }
            else
            {
                //使用默認排序——主鍵列降序排序
                sortList.Add("Id desc");
                sortName = "Id";
            }

            //利用反射的方式給頁面控件賦值
            //查找指定名稱控件
            var control = MenuInfoBll.GetInstence().FindControl(this.Controls, "SortColumn");
            if (control != null)
            {
                //判斷是否是FineUI.HiddenField類型
                var type = control.GetType();
                if (type.FullName == "FineUI.HiddenField")
                {
                    //存儲排序列字段名稱
                    ((FineUI.HiddenField)control).Text = sortName;
                }
            }
        }

        #endregion

    }
}