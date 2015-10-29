using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web;
using DotNet.Utilities;
using Solution.DataAccess.DataModel;
using Solution.Logic.Managers;
using Microsoft.Reporting.WebForms;
using Solution.DataAccess.DbHelper;
using System.Collections.Generic;
using SubSonic.Query;

/***********************************************************************
 *   作    者：AllEmpty（陈焕）-- 1654937@qq.com
 *   博    客：http://www.cnblogs.com/EmptyFS/
 *   技 术 群：327360708
 *  
 *   创建日期：2014-06-17
 *   文件名称：Login.aspx.cs
 *   描    述：后端登陆页面
 *             
 *   修 改 人：
 *   修改日期：
 *   修改原因：
 ***********************************************************************/
namespace Solution.Web.Managers.WebManage
{
    public partial class Report : System.Web.UI.Page
    {
        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                #region 报表测试
                //显示当天的记录
                var wheres = new List<ConditionHelper.SqlqueryCondition>();
                wheres.Add(new ConditionHelper.SqlqueryCondition(ConstraintType.And, MealOrderingTable.ApplyDate, Comparison.Equals, DateTime.Now.Date));
                var dt = MealOrderingBll.GetInstence().GetDataTable(false,0,null,0,0,wheres);
                ReportViewer1.LocalReport.EnableExternalImages = true;
                //ReportViewer1.LocalReport.ReportPath = @"WebManage\Meals\ReportMeal.rdlc";
                //ReportViewer1.LocalReport.SetParameters(new ReportParameter(ReportParameter1, Guid.NewGuid().ToString()));
                ReportDataSource rds = new ReportDataSource("DataSet1", dt);
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(rds);
                ReportViewer1.LocalReport.Refresh();
                #endregion
            }
        }
        #endregion

    }
}