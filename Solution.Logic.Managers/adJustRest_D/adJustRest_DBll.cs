using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using DotNet.Utilities;
using Solution.DataAccess.DataModel;
using Solution.DataAccess.DbHelper;
using System.Diagnostics;
using System.Web;
using SubSonic.Query;
using System.Text;

/***********************************************************************
 *   作    者：AllEmpty（陳煥）-- 1654937@qq.com
 *   博    客：http://www.cnblogs.com/EmptyFS/
 *   技 術 群：327360708
 *  
 *   創建日期：2014-06-29
 *   文件名稱：adJustRest_DBll.cs
 *   描    述：調休申請單邏輯類
 *             
 *   修 改 人：
 *   修改日期：
 *   修改原因：
 ***********************************************************************/
namespace Solution.Logic.Managers
{
    /// <summary>
    /// adJustRest_DBll邏輯類
    /// </summary>
    public partial class adJustRest_DBll : LogicBase
    {
        public delegate string delCheckEventHandler(int p, ref adJustRest_D m);
        /***********************************************************************
		 * 自定義函數                                                          *
		 ***********************************************************************/

        #region 自定義函數

        #region 綁定類型下拉列表
        /// <summary>
        /// 綁定下拉列表
        /// </summary>
        public void BandDropDownList(Page page, System.Web.UI.WebControls.DropDownList ddl, string s)
        {
            //判斷需要綁定的下拉框

        }

        #endregion
        #region 審批單據
        public string Accept(Page page, int id, int updateValue, delCheckEventHandler del, bool isAddUseLog = true)
        {
            string result = null;
            //判斷是否可以審批
            var model = new adJustRest_D(x => x.Id == id);
            if (model.Id == 0)
            {
                return "記錄不存在！";
            }
            result = del(updateValue, ref model);
            if (!string.IsNullOrEmpty(result))
            {
                return result;
            }

            Save(page, model);
            //發送郵件
            if (updateValue == 1)
            {
                result = SendMail(page, model);
            }

            //判斷是否?用緩存
            if (CommonBll.IsUseCache())
            {
                //刪除?部緩存	
                DelAllCache();
                //重新載?緩存
                GetList();
            }

            if (isAddUseLog)
            {
                UseLogBll.GetInstence().Save(page, "{0}" + (updateValue == 1 ? "" : "反") + "審批了adJustRest_D表Id為" + id + "的記錄！");
            }
            return result;
        }

        /// <summary>
        /// 一級審批判斷，修改內容
        /// </summary>
        /// <param name="p"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static string Check1(int p, ref adJustRest_D model)
        {
            if (model.audit == 0 && p == 0)
            {
                return "一級未審批，無需反審批";
            }
            if (model.audit == 1 && p == 1)
            {
                return "一級已審批，無需重新審批";
            }
            if (model.checker != OnlineUsersBll.GetInstence().GetManagerEmpId())
            {
                return "你不是該申請單的一級審批人，無法審批！";
            }
            model.audit = ConvertHelper.StringToByte(p.ToString());
            model.check_date = DateTime.Now;
            return null;
        }

        /// <summary>
        /// 二級審批判斷修改內容
        /// </summary>
        /// <param name="p"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static string Check2(int p, ref adJustRest_D model)
        {
            if (model.audit == 0 && p == 1)
            {
                return "一級未審批，無法二級審批";
            }
            if (model.audit2 == 1 && p == 1)
            {
                return "二級已審批，無需重新審批";
            }
            if (model.CHECKER2 != OnlineUsersBll.GetInstence().GetManagerEmpId())
            {
                return "你不是該申請單的二級審批人，無法審批！";
            }
            model.audit2 = ConvertHelper.StringToByte(p.ToString());
            model.check_date2 = DateTime.Now;
            return null;
        }

        #endregion
        #region 發送郵件
        public string SendMail(Page page, adJustRest_D model)
        {
            //獲取申請人郵箱
            string mail = EmployeeBll.GetInstence().GetFieldValue(EmployeeTable.EMAIL, x => x.EMP_ID == model.emp_id).ToString();
            string sto = "";
            string title;
            const string stype = "調休申請單";
            var name = EmployeeBll.GetInstence().GetFieldValue(EmployeeTable.EMP_FNAME, x => x.EMP_ID == model.emp_id).ToString();
            var outtype = T_TABLE_DBll.GetInstence().GetFieldValue(T_TABLE_DTable.DESCR, x => x.CODE == model.kind && (x.TABLES == "ADJU")).ToString();
            StringBuilder msg = new StringBuilder();
            if (model == null)
            {
                return "記錄不存在！";
            }
            if (model.audit2 == 1 || model.audit2 == 4)
            {
                //組合標題信息
                sto = mail;
                title = model.audit2 == 1 ? "二級審批通過" : "二級審批不通過";
            }
            else if (model.audit == 1 || model.audit == 4)
            {
                //組合標題信息
                if (model.audit == 1)
                {
                    title = "一級審批通過";
                    if (!string.IsNullOrEmpty(model.CHECKER2))
                    {
                        title += ",需要二級審批!";
                        var mail2 = EmployeeBll.GetInstence().GetFieldValue(EmployeeTable.EMAIL, x => x.EMP_ID == model.CHECKER2).ToString();
                        if ((!string.IsNullOrEmpty(mail2)) && sto.IndexOf(mail2, StringComparison.Ordinal) > 0)
                        {
                            sto = mail + ";" + mail2;
                        }
                    }
                }
                else
                {
                    sto = EmployeeBll.GetInstence().GetFieldValue(EmployeeTable.EMAIL, x => x.EMP_ID == model.checker).ToString();
                    title = "一級審批不通過";
                }
            }
            else
            {
                title = "需要你審批!";
                sto = mail;
            }

            msg.AppendLine(string.Format("單號:{0}", model.bill_id));
            msg.AppendLine(string.Format("姓名:{0} 的{1}", name, stype + title));
            msg.AppendLine();
            msg.AppendLine(string.Format("調休日期:{0}加班日期:{1}", model.rest_date.ToShortDateString(), ((DateTime)model.ori_date).ToShortDateString()));
            msg.AppendLine();
            msg.AppendLine(outtype + "  " + CommonBll.GetWorkType(model.all_day.ToString()));
            msg.AppendLine();
            msg.AppendLine(model.memo);
            msg.AppendLine("申請人郵箱:" + mail);
            msg.AppendLine();
            msg.AppendLine("詳細信息請進入人事考勤系統進行查看，謝謝！");
            msg.AppendLine("打開系統:http://192.168.0.10！");

            return MailBll.GetInstence().SendMail(sto, stype + title, msg.ToString());
        }
        #endregion

        #region 判斷是否重複申請
        public string IsRepetition(adJustRest_D model)
        {
            //取得請假出差表中數據
            var mod = OutWork_DBll.GetInstence().GetModelForCache(x => ((model.ori_date >= x.bill_date && model.ori_date <= x.Re_date) || (model.rest_date >= x.bill_date && model.rest_date <= x.Re_date))
                && x.Id != model.Id && x.emp_id == model.emp_id);
            if (mod != null)
            {
                if (model.all_day.ToString() == mod.work_type || model.all_day == 0 || mod.work_type == "0")
                {
                    return string.Format("當天已申請{0}單，單號爲{1}，請檢查修改！", mod.outwork_type.ToLower() == "tral" ? "出差" : "請假", mod.bill_id);
                }
            }
            //取得調休單信息
            var amod = GetModelForCache(x =>
                (x.ori_date == model.ori_date || x.ori_date == model.rest_date || x.rest_date == model.ori_date || x.rest_date == model.rest_date) && x.Id != model.Id && x.emp_id == model.emp_id);
            if (amod == null) return null;
            if (amod.all_day == model.all_day || model.all_day == 0 || amod.all_day == 0)
            {
                return string.Format("當天已申請調休單，單號爲{0}，請檢查修改！", amod.bill_id);
            }
            return null;
        }
        #endregion
        #endregion 自定義函數
    }
}
