﻿using System;
using System.Collections;
using System.Web;
using System.Web.UI;
using DotNet.Utilities;
using Solution.DataAccess.DataModel;

/***********************************************************************
 *   作    者：AllEmpty（陈焕）-- 1654937@qq.com
 *   博    客：http://www.cnblogs.com/EmptyFS/
 *   技 术 群：327360708
 *  
 *   创建日期：2014-06-22
 *   文件名称：T_TABLE_DBll.cs
 *   描    述：错误日志逻辑类
 *             
 *   修 改 人：
 *   修改日期：
 *   修改原因：
 ***********************************************************************/
using System.Data;
namespace Solution.Logic.Managers
{
    /// <summary>
    /// T_TABLE_DBll逻辑类
    /// </summary>
    public partial class T_TABLE_DBll : LogicBase
    {
        /***********************************************************************
		 * 自定义函数                                                          *
		 ***********************************************************************/

        #region 自定义函数

        #region 绑定列表
        public void BandDropDownList(Page page, FineUI.DropDownList ddl)
        {
            var dt = DataTableHelper.GetFilterData(GetDataTable(), null, null, null, null);

            //显示值
            ddl.DataTextField = T_TABLE_DTable.DESCR;
            ddl.DataValueField = T_TABLE_DTable.CODE;

            //绑定数据源
            ddl.DataSource = dt;
            ddl.DataBind();
        }
        /// <summary>
        /// 綁定下拉列表
        /// </summary>
        /// <param name="page"></param>
        /// <param name="ddl"></param>
        /// <param name="table">明細類型</param>
        public void BandDropDownList(Page page, FineUI.DropDownList ddl, string colName,params string[] colValue)
        {
            var dt = new DataTable();
            var dt2 = GetDataTable();
            for (int i = 0; i < colValue.Length; i++)
            {
                var dt1 = DataTableHelper.GetFilterData(dt2, colName, colValue[i], null, null);
                if (dt1!=null)
                {
                dt.Merge(dt1);  
                }
            }

            //显示值
            ddl.DataTextField = T_TABLE_DTable.DESCR;
            ddl.DataValueField = T_TABLE_DTable.CODE;

            //绑定数据源
            ddl.DataSource = dt;
            ddl.DataBind();
            //ddl.Items.Insert(0, new FineUI.ListItem("请选择菜单", "0"));
            //ddl.SelectedValue = "0";
        }

        /// <summary>
        /// 綁定單選列表
        /// </summary>
        /// <param name="page"></param>
        /// <param name="ddl"></param>
        /// <param name="table">明細類型</param>
        public void BandRadioButtonList(Page page, FineUI.RadioButtonList rbl, string colName,params string[] colValue)
        {
            var dt = new DataTable();
            var dt2 = GetDataTable();
            for (int i = 0; i < colValue.Length; i++)
            {
                var dt1 = DataTableHelper.GetFilterData(dt2, colName, colValue[i], null, null);
                if (dt1!=null)
                {
                dt.Merge(dt1);  
                }
            }

            //显示值
            rbl.DataTextField = T_TABLE_DTable.DESCR;
            rbl.DataValueField = T_TABLE_DTable.CODE;

            //绑定数据源
            rbl.DataSource = dt;
            rbl.DataBind();
            //ddl.Items.Insert(0, new FineUI.ListItem("请选择菜单", "0"));
            //ddl.SelectedValue = "0";
        }
        #endregion

        #region 获取用户权限并记录到用户Session里
        /// <summary>
        /// 获取用户权限并存储到用户Session里
        /// </summary>
        /// <param name="positionId"></param>
        public void SetUserPower(string positionId)
        {
            if (!string.IsNullOrEmpty(positionId))
            {
                //去掉两边的逗号
                positionId = StringHelper.DelStrSign(positionId);

                //因用户有的拥有多个职位，所以将用户职位取出并存入数组
                string[] arr = positionId.Split(new char[] { ',' });

                //循环读取用户职位权限
                for (int i = 0; i < arr.Length; i++)
                {
                    var group = arr[i];
                    //取得职位实体对象
                    var model = T_TABLE_DBll.GetInstence().GetModelForCache(x => x.CODE == group && x.TABLES.Equals("AUTH"));
                    if (model != null)
                    {
                        //将用户权限记录到用户Session里
                        SetPagePower(model.PagePower);
                        SetControlPower(model.ControlPower);
                    }
                }
            }
        }

        /// <summary>
        /// 将用户的页面访问权限记录到Session["PagePower"]里
        /// </summary>
        /// <param name="pagePower">页面访问权限</param>
        private void SetPagePower(string pagePower)
        {
            //如果页面访问权限Session为空，则直接赋值
            if (HttpContext.Current.Session["PagePower"] == null)
            {
                HttpContext.Current.Session["PagePower"] = pagePower;
            }
            else
            {
                //从Session中读取出已存储的权限字串
                string spp = HttpContext.Current.Session["PagePower"] + "";

                //将传入的变量存入数组pp
                string[] pp = pagePower.Split(new char[] { ',' });
                //循环逐个判断权限是否存在
                for (int i = 0; i < pp.Length; i++)
                {
                    //权限不存在的，则加入该权限
                    if (spp.IndexOf("," + pp[i] + ",") < 0 && pp[i] != "")
                    {
                        spp += pp[i] + ",";
                    }
                }
                //将添加了其他职位权限后的权限字符串存入Session
                HttpContext.Current.Session["PagePower"] = spp;
            }
        }

        /// <summary>
        /// 将用户页面的控件访问权限记录到Session["ControlPower"]里
        /// </summary>
        /// <param name="controlPower">页面的控件访问权限</param>
        private void SetControlPower(string controlPower)
        {
            //如果页面访问权限Session为空，则直接赋值
            if (HttpContext.Current.Session["ControlPower"] == null)
            {
                HttpContext.Current.Session["ControlPower"] = controlPower;
            }
            else
            {
                //从Session中读取出已存储的权限字串
                string spp = Convert.ToString(HttpContext.Current.Session["ControlPower"]);

                //将传入的变量存入数组pp
                string[] pp = controlPower.Split(new char[] { '|' });
                //循环逐个判断权限是否存在
                for (int i = 0; i < pp.Length; i++)
                {
                    //权限不存在的，则加入该权限
                    if (spp.IndexOf("|" + pp[i] + "|") < 0 && pp[i] != "")
                    {
                        spp += pp[i] + "|";
                    }
                }
                //将添加了其他职位权限后的权限字符串存入Session
                HttpContext.Current.Session["ControlPower"] = spp;
            }
        }
        #endregion

        #region 获取职位名称
        /// <summary>
        /// 获取职位名称
        /// </summary>
        /// <param name="positionId">职位Id字符串</param>
        /// <returns></returns>
        public string GetName(string positionId)
        {
            string name = "";

            if (!string.IsNullOrEmpty(positionId))
            {
                //去掉两边的逗号
                positionId = StringHelper.DelStrSign(positionId);

                //因用户有的拥有多个职位，所以将用户职位取出并存入数组
                string[] arr = StringHelper.GetArrayStr(positionId);

                //循环读取用户职位权限
                for (int i = 0; i < arr.Length; i++)
                {
                    //取得职位实体对象
                    var model = T_TABLE_DBll.GetInstence().GetModelForCache(x => x.CODE == arr[i] && x.TABLES.Equals("AUTH"));
                    if (model != null)
                    {
                        name += model.DESCR + ", ";
                    }
                }
            }

            //去除后面的逗号
            if (!string.IsNullOrEmpty(name))
            {
                name = StringHelper.DelLastComma(name);
            }

            return name;
        }
        #endregion
        /// <summary>
        /// 获取显示值
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetDescr(object id, object type)
        {
            if (id == null)
            {
                return "";
            }
            var name = GetFieldValue(T_TABLE_DTable.DESCR,
                (x => x.CODE.ToUpper() == id.ToString().ToUpper() && x.TABLES.ToUpper() == type.ToString().ToUpper()));
            return name == null ? id.ToString() : name.ToString();
        }
        #endregion 自定义函数
    }
}
