using System;
using DotNet.Utilities;
using Newtonsoft.Json;
using Solution.DataAccess.Model;

namespace Solution.Web.Managers.WebManage.MeetingRooms
{
    public partial class RoomQuick : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //獲取ID值
                int id = RequestHelper.GetInt0("Id");
                Id.Value = id + "";
                //DateTime st, et;
                //DateTime.TryParse(RequestHelper.GetString("CalendarStartTime"), out st);
                //DateTime.TryParse(RequestHelper.GetString("CalendarEndTime"), out et);
                tbStartDate.Value = RequestHelper.GetString("start");
                tbEndDate.Value = RequestHelper.GetString("end");
                //加載數據
                //LoadData();
            }
        }

        #region 加載數據
        /// <summary>讀取數據</summary>
        public void LoadData()
        {

        }
        #endregion

        protected void Btn_Click(object sender, EventArgs e)
        {
            Response.Write("<script>window.opener=null;window.close();</script>");
            //相关业务  
            //var msg = new JsonReturnMessages
            //{
            //    IsSuccess = true,
            //    Msg = "刪除成功！"
            //};
            //var data = JsonConvert.SerializeObject(msg);
            //Response.Write(data);
            Response.End();
        }
    }
}