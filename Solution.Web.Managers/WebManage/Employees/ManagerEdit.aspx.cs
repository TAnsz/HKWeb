using System;
using DotNet.Utilities;
using FineUI;
using Solution.DataAccess.DataModel;
using Solution.Logic.Managers;
using Solution.Web.Managers.WebManage.Application;

/***********************************************************************
 *   作    者：AllEmpty（陳煥）-- 1654937@qq.com
 *   博    客：http://www.cnblogs.com/EmptyFS/
 *   技 術 群：327360708
 *  
 *   創建日期：2014-06-27
 *   文件名稱：ManagerEdit.aspx.cs
 *   描    述：員工編輯頁面
 *             
 *   修 改 人：
 *   修改日期：
 *   修改原因：
 ***********************************************************************/
namespace Solution.Web.Managers.WebManage.Employees
{
    public partial class ManagerEdit : PageBase
    {
        //生成一個隨機的key值
        protected string RndKey = RandomHelper.GetRndKey();

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //獲取ID值
                hidId.Text = RequestHelper.GetInt0("Id") + "";
                //綁定下拉列表
                //綁定部門
                DepartsBll.GetInstence().BandDropDownList(this, ddlBranch_Id);
                T_TABLE_DBll.GetInstence().BandDropDownList(this,ddlPosition,T_TABLE_DTable.TABLES,"'JOBS'");

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

            if (id > 0)
            {
                //獲取指定Id的管理員實體
                var model = EmployeeBll.GetInstence().GetModelForCache(x => x.Id == id);
                if (model == null)
                    return;

                //給頁面控件賦值
                //if (!string.IsNullOrEmpty(model.PhotoImg) && model.PhotoImg.Length > 4)
                //imgPhoto.ImageUrl = model.PhotoImg;

                txtCName.Text = model.EMP_FNAME;
                txtEName.Text = model.EN_NAME;

                //編輯時，登陸賬號不能進行修改操作
                txtLoginName.Enabled = false;

                rblSex.SelectedValue = model.SEX;
                ddlBranch_Id.SelectedValue = model.DEPART_ID + "";
                //職位
                hidPositionId.Text = model.POST_CODE;
                //txtPosition.Text = model.Position_Name;

                dpBirthday.Text = model.JOIN_DATE.ToString();
                rblIsEnable.SelectedValue = model.KIND + "";
                rblIsMultiUser.SelectedValue = model.IS_SHEBAO + "";

               // txtNationalName.Text = model.NationalName;

                txtMobile.Text = model.PHONE_CODE;
                txtTel.Text = model.DEF1;
                txtAddress.Text = model.ADDRESS;
                txtLoginName.Text = model.EMP_ID;
                //txtNativePlace.Text = model.NativePlace;
                //txtRecord.Text = model.Record;
                //txtGraduateCollege.Text = model.GraduateCollege;
                //txtGraduateSpecialty.Text = model.GraduateSpecialty;
                //txtTel.Text = model.Tel;
                //txtQq.Text = model.Qq;
                //txtMsn.Text = model.Msn;
                txtEmail.Text = model.EMAIL;
                txtContent.Text = model.REMARK;

                //綁定選擇職位按鍵
                //ButtonSelectPosition.OnClientClick = SelectWindows.GetSaveStateReference(hidPositionId.ClientID) + SelectWindows.GetShowReference("../Systems/Powers/PositionSelect.aspx?Id=" + hidPositionId.Text + "&" + MenuInfoBll.GetInstence().PageUrlEncryptStringNoKey(hidPositionId.Text));
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
            int id = ConvertHelper.Cint0(hidId.Text);

            try
            {
                #region 數據驗證

                if (string.IsNullOrEmpty(txtLoginName.Text.Trim()))
                {
                    return txtLoginName.Label + "不能為空！";
                }
                var logName = StringHelper.Left(txtLoginName.Text, 20);
                if (Employee.Exists(x => x.EMP_ID == logName && x.Id != id))
                {
                    return txtLoginName.Label + "已存在！請重新輸入！";
                }

                //新增用戶時，密碼不能為空
                if (id == 0 && string.IsNullOrEmpty(txtLoginPass.Text.Trim()))
                {
                    return "密碼不能為空！";
                }
                //密碼長度不能短於6位
                if (!string.IsNullOrEmpty(txtLoginPass.Text.Trim()) && txtLoginPass.Text.Trim().Length < 6)
                {
                    return "密碼長度必須6位以上，請重新輸入！";
                }
                if (!txtLoginPass.Text.Equals(txtLoginPassaAgin.Text))
                    return "兩次輸入的密碼不一樣，請重新輸入！";

                if (string.IsNullOrEmpty(txtCName.Text.Trim()))
                {
                    return txtCName.Label + "不能為空！";
                }
                //所屬部門
                if (ConvertHelper.Cint0(ddlBranch_Id.SelectedValue) < 1)
                {
                    return ddlBranch_Id.Label + "為必選項，請選擇！";
                }
                ////所屬職位
                //if (string.IsNullOrEmpty(hidPositionId.Text))
                //{
                //    return txtPosition.Label + "為必選項，請選擇！";
                //}
                #endregion

                #region 賦值
                //獲取實體
                var model = new Employee(x => x.Id == id);
                model.EMP_ID = logName;

                //如果是添加管理員
                if (id == 0)
                {
                    model.OP_DATE = DateTime.Now;
                    //model.UpdateTime = DateTime.Now;
                    //model.Manager_Id = OnlineUsersBll.GetInstence().GetManagerId();
                    model.OP_USER = OnlineUsersBll.GetInstence().GetManagerCName();
                    //model.LoginPass = Encrypt.Md5(Encrypt.Md5(txtLoginPass.Text));
                    //model.IsWork = 1;
                }
                else
                {
                    //修改時間與管理員
                    model.OP_DATE = DateTime.Now;
                    model.OP_USER = OnlineUsersBll.GetInstence().GetManagerEmpId();
                   // model.Manager_CName = OnlineUsersBll.GetInstence().GetManagerCName();

                    //修改用戶時，填寫了密碼，則更新密碼
                    //if (txtLoginPass.Text.Trim().Length >= 6)
                    //{
                    //    model.LoginPass = Encrypt.Md5(Encrypt.Md5(txtLoginPass.Text));
                    //}

                }
                model.DEPART_ID = ddlBranch_Id.SelectedValue;
                var branch = DepartsBll.GetInstence().GetModelForCache(x => x.depart_id == model.DEPART_ID);
                if (branch != null)
                {
                    model.DEPART_ID = branch.depart_id;
                    //model.Branch_Name = branch.depart_name;
                }

                model.POST_CODE = StringHelper.Left(hidPositionId.Text, 100);
                //model.Position_Name = StringHelper.Left(txtPosition.Text, 500);

                model.EMP_FNAME = StringHelper.Left(txtCName.Text, 20);
                model.EN_NAME = StringHelper.Left(txtEName.Text, 50);
                model.SEX = StringHelper.Left(rblSex.SelectedValue, 4);
                model.JOIN_DATE = Convert.ToDateTime(StringHelper.Left(dpBirthday.Text, 20));
                //model.Record = StringHelper.Left(txtRecord.Text, 25);
                //model.GraduateCollege = StringHelper.Left(txtGraduateCollege.Text, 30);
                //model.GraduateSpecialty = StringHelper.Left(txtGraduateSpecialty.Text, 50);
                model.PHONE_CODE = StringHelper.Left(txtTel.Text, 30);
               // model.Mobile = StringHelper.Left(txtMobile.Text, 30);
                model.DEF1 = txtTel.Text;
                model.EMAIL = StringHelper.Left(txtEmail.Text, 50);
                //model.Qq = StringHelper.Left(txtQq.Text, 30);
                //model.Msn = StringHelper.Left(txtMsn.Text, 30);
                model.ADDRESS = StringHelper.Left(txtAddress.Text, 100);
                model.KIND = ConvertHelper.Ctinyint(rblIsEnable.SelectedValue);
                model.IS_SHEBAO = rblIsMultiUser.SelectedValue=="1";
                model.REMARK = StringHelper.Left(txtContent.Text, 0);
                //model.NationalName = StringHelper.Left(txtNationalName.Text, 50);
                //model.NativePlace = StringHelper.Left(txtNativePlace.Text, 100);

                #region 上傳圖片
                //if (this.fuSinger_AvatarPath.HasFile && this.fuSinger_AvatarPath.FileName.Length > 3)
                //{
                //    int vid = 1;   //1	管理員頭像(頭像圖片)
                //    //---------------------------------------------------
                //    var upload = new UploadFile();
                //    result = new UploadFileBll().Upload_AspNet(this.fuSinger_AvatarPath.PostedFile, vid, RndKey, OnlineUsersBll.GetInstence().GetManagerId(), OnlineUsersBll.GetInstence().GetManagerCName(), upload);
                //    this.fuSinger_AvatarPath.Dispose();
                //    //---------------------------------------------------
                //    if (result.Length == 0)//上傳成功
                //    {
                //        model.PhotoImg = upload.Path;
                //    }
                //    else
                //    {
                //        CommonBll.WriteLog("上傳管理員頭像圖片未成功：" + result, null);//收集異常信息
                //        return "上傳管理員頭像圖片未成功！" + result;
                //    }
                //}
                ////如果是修改，檢查用戶是否重新上傳過封面圖片，如果是刪除舊的圖片
                //if (model.Id > 0)
                //{
                //    UploadFileBll.GetInstence().Upload_DiffFile(ManagerTable.Id, ManagerTable.PhotoImg, ManagerTable.TableName, model.Id, model.PhotoImg);

                //    //同步UploadFile上傳表
                //    UploadFileBll.GetInstence().Upload_UpdateRs(RndKey, ManagerTable.TableName, model.Id);
                //}
                #endregion



                #endregion

                //----------------------------------------------------------
                //存儲到數據庫
                EmployeeBll.GetInstence().Save(this, model);
                //清空字段修改標記
                PageContext.RegisterStartupScript(Panel1.GetClearDirtyReference());
                #region 同步更新上傳圖片表綁定Id
                //if (id == 0)
                //{
                //    //同步UploadFile上傳表記錄，綁定剛剛上傳成功的文件Id為當前記錄Id
                //    UploadFileBll.GetInstence().Upload_UpdateRs(RndKey, ManagerTable.TableName, model.Id);
                //}

                #endregion
                
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

        #region 關閉子窗口事件
        /// <summary>
        /// 關閉子窗口事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void SelectWindows_Close(object sender, WindowCloseEventArgs e)
        {
            //讀取新選擇的職位名稱
            //txtPosition.Text = T_TABLE_DBll.GetInstence().GetName(hidPositionId.Text);

            //綁定選擇職位按鍵
            //ButtonSelectPosition.OnClientClick = SelectWindows.GetSaveStateReference(hidPositionId.ClientID) + SelectWindows.GetShowReference("../Systems/Powers/PositionSelect.aspx?Id=" + hidPositionId.Text + "&" + MenuInfoBll.GetInstence().PageUrlEncryptStringNoKey(hidPositionId.Text));
        }
        #endregion
    }
}