using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.UI;
using DotNet.Utilities;
using Solution.DataAccess.DataModel;
using System.Text;

/***********************************************************************
 *   作    者：AllEmpty（陳煥）-- 1654937@qq.com
 *   博    客：http://www.cnblogs.com/EmptyFS/
 *   技 術 群：327360708
 *  
 *   創建日期：2014-06-29
 *   文件名稱：OutWork_DBll.cs
 *   描    述：信息分類管理邏輯類
 *             
 *   修 改 人：
 *   修改日期：
 *   修改原因：
 ***********************************************************************/
namespace Solution.Logic.Managers
{
    /// <summary>
    /// OutWork_DBll邏輯類
    /// </summary>
    public partial class OutWork_DBll : LogicBase
    {
        public const string Tral = "tral";
        public const string Leave = "leav";
        public delegate string DelCheckEventHandler(int p, ref OutWork_D m);
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
        #region 修改隻緩存往前三個月以後的數據
        public new Expression<Func<OutWork_D, bool>> GetExpression<T>()
        {
            var d = DateTime.Now.Date.AddMonths(-3);
            return x => x.bill_date > d;
        }
        #endregion
        #region 審批單據
        public string Accept(Page page, int id, int updateValue, DelCheckEventHandler del, bool isSendMail = true, bool isAddUseLog = true)
        {
            //判斷是否可以審批
            var model = new OutWork_D(x => x.Id == id);
            if (model.Id == 0)
            {
                return "記錄不存在！";
            }
            var result = del(updateValue, ref model);
            if (!string.IsNullOrEmpty(result))
            {
                return result;
            }

            Save(page, model);
            //發送郵件
            if (updateValue == 1 && isSendMail)
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
                UseLogBll.GetInstence().Save(page, "{0}" + (updateValue == 1 ? "" : "反") + "審批了OutWork_D表Id為" + id.ToString() + "的記錄！");
            }
            return result;
        }

        /// <summary>
        /// 一級審批判斷，修改內容
        /// </summary>
        /// <param name="p"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static string Check1(int p, ref OutWork_D model)
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
        public static string Check2(int p, ref OutWork_D model)
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


        public string Accept2(Page page, int id, int updateValue, bool isSendMail = true, bool isAddUseLog = true)
        {
            string result = null;
            //判斷是否可以審批
            var model = new OutWork_D(x => x.Id == id);
            if (model.Id == 0)
            {
                return "記錄不存在！";
            }
            if (model.audit == 0 && updateValue == 1)
            {
                return "一級未審批，無法二級審批";
            }
            if (model.audit2 == 1 && updateValue == 1)
            {
                return "二級已審批，無需重新審批";
            }

            model.audit2 = ConvertHelper.StringToByte(updateValue.ToString());
            model.check_date2 = DateTime.Now;

            Save(page, model);

            //發送郵件
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
                UseLogBll.GetInstence().Save(page, "{0}二級" + (updateValue == 1 ? "" : "反") + "審批了OutWork_D表Id為" + id + "的記錄！");
            }
            //發送郵件
            if (updateValue == 1 && isSendMail)
            {
                string ss = SendMail(page, model);
                result = ss;
            }
            return result;
        }
        #endregion
        #region 發送郵件
        public string SendMail(Page page, OutWork_D model)
        {
            if (model == null)
            {
                return "記錄不存在！";
            }
            //獲取申請人郵箱
            string mail = EmployeeBll.GetInstence().GetFieldValue(EmployeeTable.EMAIL, x => x.EMP_ID == model.emp_id).ToString();
            string sto = mail;
            string title = "";
            string stype = model.outwork_type.Equals(Tral) ? "出差申請單" : "請假申請單";
            var name = EmployeeBll.GetInstence().GetFieldValue(EmployeeTable.EMP_FNAME, x => x.EMP_ID == model.emp_id).ToString();
            var outtype = T_TABLE_DBll.GetInstence().GetFieldValue(T_TABLE_DTable.DESCR, x => x.CODE == model.leave_id && (x.TABLES == Tral.ToUpper() || x.TABLES == Leave.ToUpper())).ToString();
            StringBuilder msg = new StringBuilder();
            if (model.audit2 == 1 || model.audit2 == 4)
            {
                //組合標題信息
                title = model.audit2 == 1 ? "二級審批通過" : "二級審批不通過";
            }
            else if (model.audit == 1 || model.audit == 4)
            {
                //組合標題信息
                if (model.audit == 1)
                {
                    if (model.leave_id == "1001" || model.leave_id == "1002" || model.leave_id == "1003")
                    {
                        sto = EmployeeBll.GetInstence().GetFieldValue(EmployeeTable.EMAIL, x => x.EMP_ID == model.checker).ToString();
                    }
                    else
                    {
                        title = "一級審批通過";

                    }
                    //如果默認一級審核通過，發送郵件給一級審核人

                    if (!string.IsNullOrEmpty(model.CHECKER2))
                    {
                        title += ",需要二級審批!";
                        var mail2 = EmployeeBll.GetInstence().GetFieldValue(EmployeeTable.EMAIL, x => x.EMP_ID == model.CHECKER2).ToString();
                        sto += string.IsNullOrEmpty(mail2) || sto.IndexOf(mail2, StringComparison.Ordinal) >= 0 ? "" : (";" + mail2);
                    }
                }
                else
                {
                    //sto = EmployeeBll.GetInstence().GetFieldValue(EmployeeTable.EMAIL, x => x.EMP_ID == model.checker).ToString();
                    title = "一級審批不通過";
                }
            }
            else
            {
                title = "需要你審批!";
                //海外出差增加Mandy郵箱
                sto = EmployeeBll.GetInstence().GetFieldValue(EmployeeTable.EMAIL, x => x.EMP_ID == model.checker) + (model.leave_id.Equals("1004") ? ";mandy.chiang@kamhingintl.com" : "");
            }

            msg.AppendFormat(MailBll.Headtem, stype, title);
            msg.AppendFormat(MailBll.Bodytem, "單號:", model.bill_id);
            msg.AppendFormat(MailBll.Bodytem, "姓名:", name);
            msg.AppendFormat(MailBll.Bodytem, "單據類型:", outtype + "  " + CommonBll.GetWorkType(model.work_type));
            msg.AppendFormat(MailBll.Bodytem, "日期:", model.bill_date.ToShortDateString() + "--" + Convert.ToDateTime(model.Re_date).ToShortDateString());
            if (model.work_type == "3")
            {
                msg.AppendFormat(MailBll.Bodytem, "時間:", Convert.ToDateTime(model.begin_time).ToString("HH:mm") + "--" + Convert.ToDateTime(model.end_time).ToString("HH:mm"));
            }
            msg.AppendFormat(MailBll.Bodytem, "備注:", model.memo);
            msg.AppendFormat(MailBll.Bodytem, "申請人郵箱:", mail);
            msg.AppendFormat(MailBll.Bodytem, "詳細信息請進入系統查看，謝謝！", "");
            msg.Append(MailBll.Foottem);
            //如果需要派車住宿，給車隊發送郵件
            if (model.leave_id == "1001" || model.leave_id == "1002")
            {
                StringBuilder msg2 = new StringBuilder();
                //取出對應用戶組的郵件地址
                if (EmployeeBll.GetInstence().GetRecordCount(x => x.GROUPS == model.leave_id) > 0)
                {
                    var list = EmployeeBll.GetInstence().Find(x => x.GROUPS == model.leave_id);
                    if (list != null)
                    {
                        var mails = (from item in list where !string.IsNullOrEmpty(item.EMAIL) select item.EMAIL).ToArray();
                        msg2.AppendFormat(MailBll.Headtem, "出差單需要處理", "姓名:" + name);
                        msg2.AppendFormat(MailBll.Bodytem, "交通方式:", model.transportation);
                        if (model.transportation == "派車")
                        {
                            msg2.AppendFormat(MailBll.Bodytem, "接送地點:", model.hotel_type);
                            msg2.AppendFormat(MailBll.Bodytem, "船期:", model.Start_ag ?? "" + "--" + (model.re_ag ?? ""));
                        }
                        if (model.Hostel == 1)
                        {
                            msg2.AppendFormat(MailBll.Bodytem, "安排宿舍:", model.hotel + "晚");
                        }
                        MailBll.GetInstence().SendMail(string.Join(";", mails), "姓名:" + name + " 出差單需要處理", msg2.ToString(), true);
                    }
                }
            }

            return MailBll.GetInstence().SendMail(sto, stype + title, msg.ToString(), true);
        }
        #endregion
        #region 判斷是否重複申請
        public string IsRepetition(OutWork_D model)
        {
            string result = null;
            //取得請假出差表中數據
            var mod = GetInstence().GetModelForCache(x => ((model.bill_date > x.bill_date ? model.bill_date : x.bill_date) <=
               (model.Re_date < x.Re_date ? model.Re_date : x.Re_date)) && x.Id != model.Id && x.emp_id == model.emp_id);
            if (mod != null)
            {
                if (model.work_type == mod.work_type || model.work_type == "0" || mod.work_type == "0")
                {
                    result = string.Format("當天已申請{0}單，單號爲{1}，請檢查修改！", mod.outwork_type.ToLower() == "tral" ? "出差" : "請假", mod.bill_id);
                }
            }
            //取得調休單信息
            var amod = adJustRest_DBll.GetInstence().GetModelForCache(x =>
                ((x.ori_date >= model.bill_date && x.ori_date <= model.Re_date) || (x.rest_date >= model.bill_date && x.rest_date <= model.Re_date)) && x.Id != model.Id && x.emp_id == model.emp_id);
            if (amod == null) return result;
            if (amod.all_day.ToString() == model.work_type || model.work_type == "0" || amod.all_day == 0)
            {
                result = string.Format("當天已申請調休單，單號爲{0}，請檢查修改！", amod.bill_id);
            }
            return result;
        }
        #endregion
        #region 重新載入數據

        public void DelThisCache()
        {
            //判斷是否?用緩存
            if (CommonBll.IsUseCache())
            {
                //刪除?部緩存	
                DelAllCache();
                //重新載?緩存
                GetList();
            }
        }
        #endregion
        #endregion 自定義函數
    }
}
