using System;
using System.Data;
using System.Text;

namespace DotNet.Utilities
{
    /// <summary>
    /// 對DataTable進行處理
    /// </summary>
    public class DataTableHelper
    {

        #region 從DataTable查找指定值
        /// <summary>從DataTable查找指定值</summary>
        /// <param name="dt">要查找的DataTable</param>
        /// <param name="where">條件</param>
        /// <param name="retField">返回值的字段名</param>
        /// <returns></returns>
        public static object DataTable_Find_Value(DataTable dt, string where, string retField)
        {
            if (dt == null || dt.Rows.Count == 0)
            {
                return "";
            }

            if (string.IsNullOrEmpty(where) || string.IsNullOrEmpty(retField))
            {
                return "";
            }

            DataRow[] foundRows = dt.Select(where);
            int ti = foundRows.Length;
            string ret = "";

            if (ti > 0)
            {
                return foundRows[0][retField];

            }

            return null;
        }

        /// <summary>從DataTable查找指定行</summary>
        /// <param name="dt">要查找的DataTable</param>
        /// <param name="str">比較條件：當前的值，比如：ClassID = 1</param>
        /// <param name="findField">查找的字段："ClassID"</param>
        /// <returns></returns>
        public static DataRow DataTable_SelectDataRow(DataTable dt, string str, string findField)
        {
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }

            int ti = dt.Rows.Count;
            for (int i = 0; i < ti; i++)
            {
                if (dt.Rows[i][findField].ToString() == str)
                {
                    return dt.Rows[i];
                }
            }
            return null;
        }

        /// <summary>從DataTable查找指定id list</summary>
        /// <param name="dt">要查找的DataTable</param>
        /// <param name="sWhere">在dataTable中查找到定條件的記錄，並返回新的DataTable，例如： IsPost=1 and IsShow=1</param>
        /// <param name="retField">返回的字段："ClassID"</param>
        /// <returns></returns>
        public static string DataTable_GetIdList(DataTable dt, string sWhere, string retField)
        {
            if (dt == null || dt.Rows.Count == 0)
            {
                return "";
            }

            if (string.IsNullOrEmpty(sWhere) || string.IsNullOrEmpty(retField))
            {
                return "";
            }

            DataRow[] foundRows = dt.Select(sWhere);
            int ti = foundRows.Length;
            string ret = "";

            if (ti > 0)
            {
                var sb = new StringBuilder();
                for (int i = 0; i < ti; i++)
                {
                    sb.Append(foundRows[i][retField]);
                    sb.Append(",");
                }
                ret = sb.ToString().Trim(',');
            }
            return ret;
        }

        #endregion

        #region 篩選函數，將數據表裡面指定的值查找出來
        /// <summary>
        /// 在dataTable中查找到定條件的記錄，並返回新的DataTable
        /// </summary>
        /// <param name="dt">數據表</param>
        /// <param name="colName">要找查的名稱（條件名，為空時表示查詢全部）</param>
        /// <param name="colValue">要查找的值</param>
        /// <param name="sortName">排序字段名</param>
        /// <param name="orderby">升序或降序（Asc/Desc）</param>
        /// <returns>返回篩選後的數據表</returns>
        public static DataTable GetFilterData(DataTable dt, string colName, string colValue, string sortName, string orderby)
        {
            var wheres = string.IsNullOrEmpty(colName) ? "" : colName + (string.IsNullOrEmpty(colValue) ? " is null" : "=" + colValue);
            string sort = null;
            if (!string.IsNullOrEmpty(sortName))
            {
                sort = sortName + " " + orderby;
            }
            return GetFilterData(dt, wheres, sort);
        }


        /// <summary>
        /// 篩選函數，將數據表裡面指定的值查找出來
        /// </summary>
        /// <param name="dt">數據表</param>
        /// <param name="wheres">條件，例：Id=100 and xx=20</param>
        /// <param name="sort">排序，例：Id Desc</param>
        /// <returns>返回篩選後的數據表</returns>
        public static DataTable GetFilterData(DataTable dt, string wheres, string sort)
        {
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            try
            {
                DataTable _dt = null;
                DataRow[] drs = null;
                //查詢
                if (!string.IsNullOrEmpty(wheres))
                {
                    //內存表中查詢數據
                    drs = dt.Select(wheres);
                    //CopyToDataTable 必須 引用 System.Data.DataSetExtensions
                    _dt = drs.Length > 0 ? drs.CopyToDataTable() : dt.Clone();
                }
                else
                {
                    _dt = dt;
                }
                //設置排序
                if (!string.IsNullOrEmpty(sort))
                {
                    _dt.DefaultView.Sort = sort;
                    _dt = _dt.DefaultView.ToTable();
                }

                dt.Dispose();
                return _dt;
            }
            catch
            {
                // ignored
            }

            return null;
        }
        #endregion

        #region 取得數組
        /// <summary>根據DataTable,返回指定列數據列表，用「，」進行分隔</summary>
        /// <param name="dt">DataTable</param>
        /// <param name="colName">列名</param>
        /// <returns></returns>
        public static string GetColList(DataTable dt, string colName)
        {
            string sRet = "";
            if (dt == null || dt.Rows.Count == 0)
            {
                return sRet;
            }

            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            int t = dt.Rows.Count;
            for (int i = 0; i < t; i++)
            {
                sb.Append(dt.Rows[i][colName].ToString() + ",");
            }
            dt.Dispose();

            sRet = sb.ToString();
            if (sRet.Length > 0)
            {
                return StringHelper.DelLastComma(sRet);
            }
            return sRet;
        }

        /// <summary>根據DataTable,返回指定列數據的string[]</summary>
        /// <param name="dt">DataTable</param>
        /// <returns></returns>
        public static string[] GetArrayString(DataTable dt, string colName)
        {
            if (dt == null || dt.Rows.Count == 0)
            {
                return new string[0] { };
            }

            int t = dt.Rows.Count;
            string[] arr = new string[t];
            for (int i = 0; i < t; i++)
            {
                arr[i] = dt.Rows[i][colName].ToString();
            }
            dt.Dispose();
            return arr;
        }

        /// <summary>根據DataTable,返回指定列數據的int[]</summary>
        /// <param name="dt">DataTable</param>
        /// <returns></returns>
        public static int[] GetArrayInt(DataTable dt, string colName)
        {
            if (dt == null || dt.Rows.Count == 0)
            {
                return new int[0] { };
            }

            int t = dt.Rows.Count;
            var arr = new int[t];
            for (int i = 0; i < t; i++)
            {
                arr[i] = ConvertHelper.Cint0(dt.Rows[i][colName].ToString());
            }
            dt.Dispose();
            return arr;
        }

        /// <summary>根據DataTable,返回第一行,各列數據到string[]</summary>
        /// <param name="dt">DataTable</param>
        /// <returns></returns>
        public static string[] GetColumnsString(DataTable dt)
        {
            if (dt == null || dt.Rows.Count == 0)
            {
                return new string[0] { };
            }

            int ti = dt.Columns.Count;
            string[] arr = new string[ti];
            for (int i = 0; i < ti; i++)
            {
                arr[i] = dt.Rows[0][i].ToString();
            }
            dt.Dispose();
            return arr;
        }

        /// <summary>根據DataTable,返回n行n列的數據到string[,]</summary>
        /// <param name="dt">DataTable</param>
        /// <returns></returns>
        public static string[,] GetArrayString(DataTable dt)
        {
            if (dt == null || dt.Rows.Count == 0)
            {
                string[,] a2 = new string[0, 2];
                return a2;
            }

            int rows = dt.Rows.Count;
            int cols = dt.Columns.Count;

            string[,] arr = new string[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    arr[i, j] = dt.Rows[i][j].ToString();
                }
            }
            dt.Dispose();
            return arr;
        }

        #endregion

        #region 整理dataTable數據，以便於在有層次感的數據容器中使用
        /// <summary>整理dataTable數據，以便於在有層次感的數據容器中使用
        /// </summary>
        /// <param name="dtable">DataTable數據源</param>
        /// <param name="pkFiled">主鍵ID列名</param>
        /// <param name="parentIdFiled">父級ID列名</param>
        /// <returns></returns>
        public static DataTable DataTableTidyUp(DataTable dtable, string pkFiled, string parentIdFiled)
        {
            return DataTableTidyUp(dtable, pkFiled, parentIdFiled, 0);
        }

        /// <summary>
        /// 整理dataTable數據，以便於在有層次感的數據容器中使用
        /// </summary>
        /// <param name="dtable">DataTable數據源</param>
        /// <param name="pkFiled">主鍵ID列名</param>
        /// <param name="parentIdFiled">父級ID列名</param>
        /// <param name="parentId">父ID值，用於查詢分類列表時，只顯示指定一級分類下面的全部分類</param>
        /// <returns></returns>
        public static DataTable DataTableTidyUp(DataTable dtable, string pkFiled, string parentIdFiled, int parentId)
        {

            //判斷當前內存表中是否存在指定的主鍵列
            if (!dtable.Columns.Contains(pkFiled) || !dtable.Columns.Contains(parentIdFiled))
            {
                //不存在指定的主鍵列
                return null;
            }
            //設定主鍵列
            dtable.PrimaryKey = new DataColumn[] { dtable.Columns[pkFiled] };

            //克隆內存表中的結構與約束
            DataTable tidyUpdata = dtable.Clone();

            //父ID列表，用於使用條件查詢時，只將指定父ID節點（根節點）以及它下面的子節點顯示出來，其他節點不顯示
            string parentIdList = ",";

            //循環讀取表中的記錄
            foreach (DataRow item in dtable.Rows)
            {
                //獲取父ID值
                var pid = (item[parentIdFiled] == null || string.IsNullOrEmpty(item[parentIdFiled].ToString())) ? 0 : int.Parse(item[parentIdFiled].ToString());
                //判斷當前的父ID是否為0（即是否是根節點），為0則直接加入,否則尋找其父id的位置
                if (pid == 0)
                {
                    //如果指定了只顯示指定根節點以及它的子節點，則判斷當前父節點是否為指定的父節點，不是則終止本次循環
                    if (parentId > 0 && int.Parse(item[pkFiled].ToString()) != parentId)
                    {
                        continue;
                    }
                    else
                    {
                        //如果指定了只顯示指定根節點以及它的子節點，則將當前節點ID加入列表
                        if (parentId > 0)
                        {
                            parentIdList += item[pkFiled].ToString() + ",";
                        }
                        //添加一行記錄
                        tidyUpdata.ImportRow(item);
                        continue;
                    }
                }

                //如果指定了只顯示指定根節點以及它的子節點，且當前父ID不存在父ID列表中，則終止本次循環
                if (parentId > 0 && parentIdList.IndexOf("," + pid + ",") < 0)
                {
                    continue;
                }
                //將當前ID加入列表中
                if (parentId > 0)
                {
                    parentIdList += item[pkFiled].ToString() + ",";
                }

                //尋找父id的位置
                DataRow pdrow = tidyUpdata.Rows.Find(pid);
                //獲取父ID所在行索引號
                int index = tidyUpdata.Rows.IndexOf(pdrow);
                //父ID不在索引中直接抛棄
                if (index < 0)
                {
                    index = tidyUpdata.Rows.Count + 1;
                }
                else
                {
                    int _pid = 0;
                    //查找下一個位置的父ID與當前行的父ID是否一樣，是的話將插入行向下移動
                    do
                    {
                        //索引號增加
                        index++;
                        try
                        {
                            //獲取下一行的父ID值
                            _pid = ConvertHelper.Cint0(tidyUpdata.Rows[index][parentIdFiled]);
                        }
                        catch (Exception)
                        {
                            _pid = 0;
                        }
                    }
                    //如果下一行的父ID值與當前要插入的ID值一樣，則循環繼續
                    while (pid != 0 && pid == _pid);
                }

                //當前行創建新行
                DataRow currentRow = tidyUpdata.NewRow();
                currentRow.ItemArray = item.ItemArray;

                //插入新行
                tidyUpdata.Rows.InsertAt(currentRow, index);
            }


            return tidyUpdata;

        }

        /// <summary>整理dataTable數據，以便於在有層次感的數據容器中使用
        /// </summary>
        /// <param name="dtable">DataTable數據源</param>
        /// <param name="pkFiled">主鍵ID列名</param>
        /// <param name="parentIDFiled">父級ID列名</param>
        /// <returns></returns>
        public static DataSet DataSetTidyUp(DataTable dtable, string pkFiled, string parentIDFiled)
        {

            DataSet dset = new DataSet();
            DataTable dt = DataTableTidyUp(dtable, pkFiled, parentIDFiled);
            dset.Tables.Add(dt);
            return dset;

        }
        #endregion

        #region dataTable 排序
        /// <summary>整理dataTable數據，以便於在有層次感的數據容器中使用，</summary>
        /// <param name="dtable">DataTable數據源</param>
        /// <param name="pkFiled">主鍵ID列名</param>
        /// <param name="parentIdFiled">父級ID列名</param>
        /// <param name="sortName">ParentID asc,SortId asc</param>
        /// <returns></returns>
        public static DataTable DataTableTreeSort(DataTable dtable, string pkFiled, string parentIdFiled = "ParentId", string sortName = "ParentId asc,SortId asc")
        {
            //判斷當前內存表中是否存在指定的主鍵列
            if (!dtable.Columns.Contains(pkFiled) || !dtable.Columns.Contains(parentIdFiled))
            {
                //不存在指定的主鍵列
                return dtable;
            }

            //設定主鍵列
            dtable.PrimaryKey = new DataColumn[] { dtable.Columns[pkFiled] };

            //---------------------------------------------
            //先排序
            DataRow[] rows = dtable.Select("", sortName);
            DataTable tmp = dtable.Clone();
            tmp.Rows.Clear();
            foreach (DataRow row in rows)
            {
                tmp.ImportRow(row);
            }
            dtable = tmp;
            //---------------------------------------------
            //克隆內存表中的結構與約束
            DataTable dt = dtable.Clone();//克隆表結構
            dt.Rows.Clear();
            int ti = dtable.Rows.Count;
            int tj = ti;
            int dtIndex = 0;
            string pid = "";

            for (int i = 0; i < ti; i++)
            {
                DataRow rs = dtable.Rows[i];

                if (rs[parentIdFiled].ToString() != pid)
                {
                    pid = rs[parentIdFiled].ToString();
                    dtIndex = 0;
                }

                if (rs[parentIdFiled].ToString() == "0")
                {
                    dt.ImportRow(rs);
                }
                else
                {
                    if (dtIndex > 0)
                    {
                        if (dtIndex < ti - 1)
                        {
                            DataRow dr2 = dt.NewRow();
                            dr2.ItemArray = rs.ItemArray;
                            dtIndex++;
                            dt.Rows.InsertAt(dr2, dtIndex);
                        }
                    }
                    else
                    {
                        DataRow dr1 = dt.Rows.Find(rs[parentIdFiled].ToString());
                        if (dr1 != null)
                        {
                            dtIndex = dt.Rows.IndexOf(dr1);

                            if (dtIndex < ti - 1)
                            {
                                DataRow dr2 = dt.NewRow();
                                dr2.ItemArray = rs.ItemArray;
                                dtIndex++;
                                dt.Rows.InsertAt(dr2, dtIndex);
                            }
                        }
                    }
                }
            }

            return dt;
        }


        #endregion

        #region 生成多選框 for Array

        /// <summary>根據idList，輸出復選框 CheckBox</summary>
        /// <param name="name">復選框指定名稱</param>
        /// <param name="arr">string[]</param>
        /// <param name="idList"></param>
        /// <param name="sFlag">後綴符號</param>
        /// <returns></returns>
        public static string Get_Html_CheckBox_Array(string name, string[,] arr, string idList, string sFlag = ", ")
        {
            if (arr == null) { return ""; }
            if (arr.GetLength(0) < 1) { return ""; }

            var sb = new StringBuilder();
            try
            {
                int ti = arr.GetLength(0);

                if (idList.Length > 0)
                {
                    idList = "," + idList + ",";
                    for (int i = 0; i < ti; i++)
                    {
                        if (arr[i, 0].Length > 0 && arr[i, 1].Length > 0)
                        {
                            if (idList.IndexOf("," + arr[i, 0] + ",") > -1)
                            {
                                sb.Append(Get_Html_CheckBox(name + "_" + arr[i, 0], name, arr[i, 0], arr[i, 1], true));
                            }
                            else
                            {
                                sb.Append(Get_Html_CheckBox(name + "_" + arr[i, 0], name, arr[i, 0], arr[i, 1], false));
                            }
                            sb.Append(sFlag);
                        }
                    }
                }
                else
                {

                    for (int i = 0; i < ti; i++)
                    {
                        if (arr[i, 0].Length > 0 && arr[i, 1].Length > 0)
                        {
                            sb.Append(Get_Html_CheckBox(name + "_" + arr[i, 0], name, arr[i, 0], arr[i, 1], false));
                            sb.Append(sFlag);
                        }
                    }
                }
            }
            catch
            {

            }

            return sb.ToString();
        }

        /// <summary> 輸出 checked 控件的html </summary>
        /// <param name="sId">checked 控件的id</param>
        /// <param name="sName">checked 控件的name</param>
        /// <param name="sValue">當前值</param>
        /// <param name="sText">顯示文本</param>
        /// <param name="bSel">true=已經選擇,false =沒有選擇</param>
        /// <returns></returns>
        public static string Get_Html_CheckBox(string sId, string sName, string sValue, string sText, bool bSel = false)
        {
            string sRet = "", sChecked = "", sCss = " class=\"txtChkBoxTxt\" ";
            if (sId == "") { sId = sName; }
            if (bSel)
            {
                sChecked = " checked=\"checked\" ";
                sCss = " class=\"txtChkBoxSel\" ";
            }

            sRet = "<span><input type=\"checkbox\" name=\"{1}\" id=\"{0}\" value=\"{2}\" {4} onclick=\"checkbox_ck(this,'{0}')\"  />"
            + "<label id=\"lbl_{0}\" for=\"{0}\" {5}>{3}</label></span>";
            return string.Format(sRet, sId, sName, sValue, sText, sChecked, sCss);
        }
        #endregion

        #region 生成多選框 for DataTable
        /// <summary>根據idList，輸出復選框 CheckBox</summary>
        /// <param name="sIdList">當前選擇的值 id list</param>
        /// <param name="sId">checked 控件的id</param>
        /// <param name="sName">checked 控件的name</param>
        /// <param name="dt">datatable</param>
        /// <param name="sFlag"></param>
        /// <returns></returns>
        public static string Get_Html_CheckBox_DataTable(string sIdList, string sId, string sName, DataTable dt, string sFlag = ", ")
        {
            if (dt == null || dt.Rows.Count == 0)
            {
                return "";
            }
            if (dt.Columns.Count < 2)
            {
                return "";
            }

            var sb = new StringBuilder();
            int ti = dt.Rows.Count;

            if (sIdList.Length > 0)
            {
                sIdList = "," + sIdList + ",";
                for (int i = 0; i < ti; i++)
                {
                    string s1 = dt.Rows[i][0].ToString();
                    string s2 = dt.Rows[i][1].ToString().Trim();

                    if (s1.Length <= 0 || s2.Length <= 0) continue;
                    bool bSel = (sIdList.IndexOf("," + s1 + ",", System.StringComparison.Ordinal) > -1);

                    sb.Append(Get_Html_CheckBox(sName + "_" + s1, sName, s1, s2, bSel));
                    sb.Append(sFlag);
                }
            }
            else
            {
                for (int i = 0; i < ti; i++)
                {
                    string s1 = dt.Rows[i][0].ToString();
                    string s2 = dt.Rows[i][1].ToString().Trim();

                    if (s1.Length <= 0 || s2.Length <= 0) continue;

                    sb.Append(Get_Html_CheckBox(sName + "_" + s1, sName, s1, s2, false));
                    sb.Append(sFlag);
                }
            }

            return sb.ToString();
        }
        #endregion

        #region OptionHtml
        /// <summary>
        /// '輸出option 下的列表的html (注:不包括select,只輸出option)
        /// Get_OptionHtml("男",string[,{id,name}])
        /// </summary>
        /// <param name="sValue">當前值</param>
        /// <param name="dt">dt</param>
        /// <param name="sFlag">後綴符號，例如：年、元等</param>
        /// <returns></returns>
        public static string Get_OptionHtml(string sValue, DataTable dt, string sFlag = "")
        {
            if (dt == null || dt.Rows.Count == 0)
            {
                return "";
            }
            if (dt.Columns.Count < 2)
            {
                return "";
            }

            int ti = dt.Rows.Count;
            var sb = new StringBuilder();

            for (int i = 0; i < ti; i++)
            {
                string s1 = dt.Rows[i][0].ToString();
                string s2 = dt.Rows[i][1].ToString().Trim();

                if (s1.Length <= 0 || s2.Length <= 0) continue;
                string css = (s1 == sValue) ? " selected class=\"txtChkBoxSel\" " : "";

                sb.AppendFormat("<option value=\"{0}\" {3} >{1}{2}</option>", s1, s2, sFlag, css);
            }
            dt.Dispose();
            return sb.ToString();
        }
        #endregion
    }
}
