
/***********************************************************************
 *   作    者：AllEmpty（陳煥）-- 1654937@qq.com
 *   博    客：http://www.cnblogs.com/EmptyFS/
 *   技 術 群：327360708
 *  
 *   創建日期：2014-06-17
 *   文件名稱：IPageBase.cs
 *   描    述：UI頁面接口類——主要用於列表（Grid）頁
 *             
 *   修 改 人：
 *   修改日期：
 *   修改原因：
 ***********************************************************************/
namespace Solution.Web.Managers.WebManage.Application
{
    /// <summary>
    /// UI頁面接口類——主要用於列表（Grid）頁
    /// </summary>
    public interface IPageBase
    {
        #region 用於UI頁面初始化，給邏輯層對像、列表等對像賦值，主要是列表（Grid）頁面使用

        void Init();

        #endregion
    }
}
