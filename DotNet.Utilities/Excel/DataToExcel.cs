/// <summary>
///  ˵÷㺄ataToExcel
/// ᠠ« ȋ㺋շɍ
/// jϵ罊���361983679  
/// 輐蕾㺨ttp://www.sufeinet.com/thread-655-1-1.html
/// </summary>
using System;
using System.Diagnostics;
//using Excel;
namespace DotNet.Utilities
{
    /// <summary>
    /// ♗煘CEL弳抽豭儀͊    /// </summary>
    public class DataToExcel
    {
        public DataToExcel()
        {
        }

        #region ♗煘CEL儒븶 (ҪExcel.dll֧㖩

        private int titleColorindex = 15;
        /// <summary>
        /// ᪌ⱳ덊        /// </summary>
        public int TitleColorIndex
        {
            set { titleColorindex = value; }
            get { return titleColorindex; }
        }

        private DateTime beforeTime;			//Excelƴ毖ʱ줍
        private DateTime afterTime;				//Excelƴ毖ʱ줍

        #region 䴽蒻超xcelʾ=
        /// <summary>
        /// 䴽蒻超xcelʾ=
        /// </summary>
        public void CreateExcel()
        {
            //Excel.Application excel = new Excel.Application();
            //excel.Application.Workbooks.Add(true);
            //excel.Cells[1, 1] = "戲戲P";
            //excel.Cells[1, 2] = "戲嚲P";
            //excel.Cells[2, 1] = "嚲戲P";
            //excel.Cells[2, 2] = "嚲嚲P";
            //excel.Cells[3, 1] = "嚳戲P";
            //excel.Cells[3, 2] = "嚳嚲P";

            ////ᣴ捊            //excel.ActiveWorkbook.SaveAs("./tt.xls", XlFileFormat.xlExcel9795, null, null, false, false, Excel.XlSaveAsAccessMode.xlNoChange, null, null, null, null, null);
            ////䲿ꏔʾ
            //excel.Visible = true;
            ////			excel.Quit();
            ////			excel=null;            
            ////			GC.Collect();//,븻؊Ս
        }
        #endregion

        #region ���ataTable儊���弳ʾΪᨱ퍊        /// <summary>
        /// ���ataTable儊���弳ʾΪᨱ퍊        /// </summary>
        /// <param name="dt">Ҫ弳淨ʽ/param>
        /// <param name="strTitle">弳汨᭵ıꌢ</param>
        /// <param name="FilePath">ᣴ掄쾵Ă羶</param>
        /// <returns></returns>
        //public string OutputExcel(System.Data.DataTable dt, string strTitle, string FilePath)
        //{
        //    beforeTime = DateTime.Now;

        //    Excel.Application excel;
        //    Excel._Workbook xBk;
        //    Excel._Worksheet xSt;

        //    int rowIndex = 4;
        //    int colIndex = 1;

        //    excel = new Excel.ApplicationClass();
        //    xBk = excel.Workbooks.Add(true);
        //    xSt = (Excel._Worksheet)xBk.ActiveSheet;

        //    //ȡ僁ꌢ			
        //    foreach (DataColumn col in dt.Columns)
        //    {
        //        colIndex++;
        //        excel.Cells[4, colIndex] = col.ColumnName;

        //        //ɨփ᪌⸱ʽΪԆ덊        //        xSt.get_Range(excel.Cells[4, colIndex], excel.Cells[4, colIndex]).Font.Bold = true;
        //        xSt.get_Range(excel.Cells[4, colIndex], excel.Cells[4, colIndex]).HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
        //        xSt.get_Range(excel.Cells[4, colIndex], excel.Cells[4, colIndex]).Select();
        //        xSt.get_Range(excel.Cells[4, colIndex], excel.Cells[4, colIndex]).Interior.ColorIndex = titleColorindex;//19;//ɨփΪǳ놉룬鲼Ɠ6֖
        //    }


        //    //ȡ僱���֐儊���			
        //    foreach (DataRow row in dt.Rows)
        //    {
        //        rowIndex++;
        //        colIndex = 1;
        //        foreach (DataColumn col in dt.Columns)
        //        {
        //            colIndex++;
        //            if (col.DataType == System.Type.GetType("System.DateTime"))
        //            {
        //                excel.Cells[rowIndex, colIndex] = (Convert.ToDateTime(row[col.ColumnName].ToString())).ToString("yyyy-MM-dd");
        //                xSt.get_Range(excel.Cells[rowIndex, colIndex], excel.Cells[rowIndex, colIndex]).HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;//ɨփȕƚЍ儗ֶθኽΪԆ덊        //            }
        //            else
        //                if (col.DataType == System.Type.GetType("System.String"))
        //                {
        //                    excel.Cells[rowIndex, colIndex] = "'" + row[col.ColumnName].ToString();
        //                    xSt.get_Range(excel.Cells[rowIndex, colIndex], excel.Cells[rowIndex, colIndex]).HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;//ɨփז紿͵ėֶθኽΪԆ덊        //                }
        //                else
        //                {
        //                    excel.Cells[rowIndex, colIndex] = row[col.ColumnName].ToString();
        //                }
        //        }
        //    }

        //    //쓔ؒ븶ꏼƐЉ		
        //    int rowSum = rowIndex + 1;
        //    int colSum = 2;
        //    excel.Cells[rowSum, 2] = "ꏼƢ;
        //    xSt.get_Range(excel.Cells[rowSum, 2], excel.Cells[rowSum, 2]).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
        //    //ɨփѡ֐儲﷖儑Չ뉉	
        //    xSt.get_Range(excel.Cells[rowSum, colSum], excel.Cells[rowSum, colIndex]).Select();
        //    //xSt.get_Range(excel.Cells[rowSum,colSum],excel.Cells[rowSum,colIndex]).Interior.ColorIndex =Assistant.GetConfigInt("ColorIndex");// 1;//ɨփΪǳ놉룬鲼Ɠ6֖

        //    //ȡ僕븶ᨱ���᪌≉	
        //    excel.Cells[2, 2] = strTitle;

        //    //ɨփջ趲豭儱ꌢ豊퉉	
        //    xSt.get_Range(excel.Cells[2, 2], excel.Cells[2, 2]).Font.Bold = true;
        //    xSt.get_Range(excel.Cells[2, 2], excel.Cells[2, 2]).Font.Size = 22;

        //    //ɨփᨱ���豎ꗮʊӦﭶȉ		
        //    xSt.get_Range(excel.Cells[4, 2], excel.Cells[rowSum, colIndex]).Select();
        //    xSt.get_Range(excel.Cells[4, 2], excel.Cells[rowSum, colIndex]).Columns.AutoFit();

        //    //ɨփջ趲豭儱ꌢΪ療ӖЉ		
        //    xSt.get_Range(excel.Cells[2, 2], excel.Cells[2, colIndex]).Select();
        //    xSt.get_Range(excel.Cells[2, 2], excel.Cells[2, colIndex]).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenterAcrossSelection;

        //    //릖Ʊ߿≉	
        //    xSt.get_Range(excel.Cells[4, 2], excel.Cells[rowSum, colIndex]).Borders.LineStyle = 1;
        //    xSt.get_Range(excel.Cells[4, 2], excel.Cells[rowSum, 2]).Borders[Excel.XlBordersIndex.xlEdgeLeft].Weight = Excel.XlBorderWeight.xlThick;//ɨփ׳៏߼Ӵ֍
        //    xSt.get_Range(excel.Cells[4, 2], excel.Cells[4, colIndex]).Borders[Excel.XlBordersIndex.xlEdgeTop].Weight = Excel.XlBorderWeight.xlThick;//ɨփɏ៏߼Ӵ֍
        //    xSt.get_Range(excel.Cells[4, colIndex], excel.Cells[rowSum, colIndex]).Borders[Excel.XlBordersIndex.xlEdgeRight].Weight = Excel.XlBorderWeight.xlThick;//ɨփӒ៏߼Ӵ֍
        //    xSt.get_Range(excel.Cells[rowSum, 2], excel.Cells[rowSum, colIndex]).Borders[Excel.XlBordersIndex.xlEdgeBottom].Weight = Excel.XlBorderWeight.xlThick;//ɨփς៏߼Ӵ֍



        //    afterTime = DateTime.Now;

        //    //ϔʾ黌		
        //    //excel.Visible=true;			
        //    //excel.Sheets[0] = "sss";

        //    ClearFile(FilePath);
        //    string filename = DateTime.Now.ToString("yyyyMMddHHmmssff") + ".xls";
        //    excel.ActiveWorkbook.SaveAs(FilePath + filename, Excel.XlFileFormat.xlExcel9795, null, null, false, false, Excel.XlSaveAsAccessMode.xlNoChange, null, null, null, null, null);

        //    //wkbNew.SaveAs strBookName;
        //    //excel.Save(strExcelFileName);

        //    #region  ���腸cel���̍

        //    //Ҫ攢xcel億COM攏㽸Ťփ:dcomcnfg


        //    //excel.Quit();
        //    //excel=null;            

        //    xBk.Close(null, null, null);
        //    excel.Workbooks.Close();
        //    excel.Quit();


        //    //עҢ㺕 Ӄ迤ċ銬Excel攏㶼Ҫִբ趲ٗ磬籔⽡ʸ⻁˅xcel���̍
        //    //			if(rng != null)
        //    //			{
        //    //				System.Runtime.InteropServices.Marshal.ReleaseComObject(rng);
        //    //				rng = null;
        //    //			}
        //    //			if(tb != null)
        //    //			{
        //    //				System.Runtime.InteropServices.Marshal.ReleaseComObject(tb);
        //    //				tb = null;
        //    //			}
        //    if (xSt != null)
        //    {
        //        System.Runtime.InteropServices.Marshal.ReleaseComObject(xSt);
        //        xSt = null;
        //    }
        //    if (xBk != null)
        //    {
        //        System.Runtime.InteropServices.Marshal.ReleaseComObject(xBk);
        //        xBk = null;
        //    }
        //    if (excel != null)
        //    {
        //        System.Runtime.InteropServices.Marshal.ReleaseComObject(excel);
        //        excel = null;
        //    }
        //    GC.Collect();//,븻؊Ս
        //    #endregion

        //    return filename;

        //}
        #endregion

        #region Kill Excel���̍

        /// <summary>
        /// ���腸cel���̍
        /// </summary>
        public void KillExcelProcess()
        {
            Process[] myProcesses;
            DateTime startTime;
            myProcesses = Process.GetProcessesByName("Excel");

            //仙뵽Excel���̉D㬔݊ᖻĜŐ攬賌ƴ毊ἤ
            foreach (Process myProcess in myProcesses)
            {
                startTime = myProcess.StartTime;
                if (startTime > beforeTime && startTime < afterTime)
                {
                    myProcess.Kill();
                }
            }
        }
        #endregion

        #endregion

        #region ���ataTable儊���弳ʾΪᨱ���늹ӃExcel攏㣬ʹӃCOM.Excel)

        #region ʹӃʾ=
        /*ʹӃʾ=㺍
         * DataSet ds=(DataSet)Session["AdBrowseHitDayList"];
            string ExcelFolder=Assistant.GetConfigString("ExcelFolder");
            string FilePath=Server.MapPath(".")+"\\"+ExcelFolder+"\\";
			
            //ɺ休ĖЎĶԓ汭
            Hashtable nameList = new Hashtable();
            nameList.Add("ADID", "饕池«");
            nameList.Add("ADName", "饕惻ㆢ);
            nameList.Add("year", "Ī");
            nameList.Add("month", "Ԃ");
            nameList.Add("browsum", "ϔʾʽ");
            nameList.Add("hitsum", "婿犽");
            nameList.Add("BrowsinglIP", "態≐ϔʾ");
            nameList.Add("HitsinglIP", "態≐婿碩;
            //;Ӄexcel攏㍊            DataToExcel dte=new DataToExcel();
            string filename="";
            try
            {			
                if(ds.Tables[0].Rows.Count>0)
                {
                    filename=dte.DataExcel(ds.Tables[0],"᪌⢬FilePath,nameList);
                }
            }
            catch
            {
                //dte.KillExcelProcess();
            }
			
            if(filename!="")
            {
                Response.Redirect(ExcelFolder+"\\"+filename,true);
            }
         * 
         * */

        #endregion

        /// <summary>
        /// ���ataTable儊���弳ʾΪᨱ���늹ӃExcel攏㩍
        /// </summary>
        /// <param name="dt">ʽataTable</param>
        /// <param name="strTitle">᪌⼯param>
        /// <param name="FilePath">ɺ㉎ļ·/param>
        /// <param name="nameList"></param>
        /// <returns></returns>
        //public string DataExcel(System.Data.DataTable dt, string strTitle, string FilePath, Hashtable nameList)
        //{
        //    COM.Excel.cExcelFile excel = new COM.Excel.cExcelFile();
        //    ClearFile(FilePath);
        //    string filename = DateTime.Now.ToString("yyyyMMddHHmmssff") + ".xls";
        //    excel.CreateFile(FilePath + filename);
        //    excel.PrintGridLines = false;

        //    COM.Excel.cExcelFile.MarginTypes mt1 = COM.Excel.cExcelFile.MarginTypes.xlsTopMargin;
        //    COM.Excel.cExcelFile.MarginTypes mt2 = COM.Excel.cExcelFile.MarginTypes.xlsLeftMargin;
        //    COM.Excel.cExcelFile.MarginTypes mt3 = COM.Excel.cExcelFile.MarginTypes.xlsRightMargin;
        //    COM.Excel.cExcelFile.MarginTypes mt4 = COM.Excel.cExcelFile.MarginTypes.xlsBottomMargin;

        //    double height = 1.5;
        //    excel.SetMargin(ref mt1, ref height);
        //    excel.SetMargin(ref mt2, ref height);
        //    excel.SetMargin(ref mt3, ref height);
        //    excel.SetMargin(ref mt4, ref height);

        //    COM.Excel.cExcelFile.FontFormatting ff = COM.Excel.cExcelFile.FontFormatting.xlsNoFormat;
        //    string font = "ˎ̥";
        //    short fontsize = 9;
        //    excel.SetFont(ref font, ref fontsize, ref ff);

        //    byte b1 = 1,
        //        b2 = 12;
        //    short s3 = 12;
        //    excel.SetColumnWidth(ref b1, ref b2, ref s3);

        //    string header = "ҳu";
        //    string footer = "ҳ텢;
        //    excel.SetHeader(ref header);
        //    excel.SetFooter(ref footer);


        //    COM.Excel.cExcelFile.ValueTypes vt = COM.Excel.cExcelFile.ValueTypes.xlsText;
        //    COM.Excel.cExcelFile.CellFont cf = COM.Excel.cExcelFile.CellFont.xlsFont0;
        //    COM.Excel.cExcelFile.CellAlignment ca = COM.Excel.cExcelFile.CellAlignment.xlsCentreAlign;
        //    COM.Excel.cExcelFile.CellHiddenLocked chl = COM.Excel.cExcelFile.CellHiddenLocked.xlsNormal;

        //    // ᨱ���̢
        //    int cellformat = 1;
        //    //			int rowindex = 1,colindex = 3;					
        //    //			object title = (object)strTitle;
        //    //			excel.WriteValue(ref vt, ref cf, ref ca, ref chl,ref rowindex,ref colindex,ref title,ref cellformat);

        //    int rowIndex = 1;//ưʼ
        //    int colIndex = 0;



        //    //ȡ僁ꌢ				
        //    foreach (DataColumn colhead in dt.Columns)
        //    {
        //        colIndex++;
        //        string name = colhead.ColumnName.Trim();
        //        object namestr = (object)name;
        //        IDictionaryEnumerator Enum = nameList.GetEnumerator();
        //        while (Enum.MoveNext())
        //        {
        //            if (Enum.Key.ToString().Trim() == name)
        //            {
        //                namestr = Enum.Value;
        //            }
        //        }
        //        excel.WriteValue(ref vt, ref cf, ref ca, ref chl, ref rowIndex, ref colIndex, ref namestr, ref cellformat);
        //    }

        //    //ȡ僱���֐儊���			
        //    foreach (DataRow row in dt.Rows)
        //    {
        //        rowIndex++;
        //        colIndex = 0;
        //        foreach (DataColumn col in dt.Columns)
        //        {
        //            colIndex++;
        //            if (col.DataType == System.Type.GetType("System.DateTime"))
        //            {
        //                object str = (object)(Convert.ToDateTime(row[col.ColumnName].ToString())).ToString("yyyy-MM-dd"); ;
        //                excel.WriteValue(ref vt, ref cf, ref ca, ref chl, ref rowIndex, ref colIndex, ref str, ref cellformat);
        //            }
        //            else
        //            {
        //                object str = (object)row[col.ColumnName].ToString();
        //                excel.WriteValue(ref vt, ref cf, ref ca, ref chl, ref rowIndex, ref colIndex, ref str, ref cellformat);
        //            }
        //        }
        //    }
        //    int ret = excel.CloseFile();

        //    //			if(ret!=0)
        //    //			{
        //    //				//MessageBox.Show(this,"Error!");
        //    //			}
        //    //			else
        //    //			{
        //    //				//MessageBox.Show(this,"ǫ䲿ꎄ쾣:\\test.xls!");
        //    //			}
        //    return filename;

        //}

        #endregion

        #region  ǥ-齊ᵄExcel΄쾍

        private void ClearFile(string FilePath)
        {
            String[] Files = System.IO.Directory.GetFiles(FilePath);
            if (Files.Length > 10)
            {
                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        System.IO.File.Delete(Files[i]);
                    }
                    catch
                    {
                    }

                }
            }
        }
        #endregion

    }
}
