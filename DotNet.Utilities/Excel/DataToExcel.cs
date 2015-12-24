/// <summary>
/// �������GDataToExcel
/// �s �X �H�GĬ��
/// �pô�覡�G361983679  
/// ��s�����Ghttp://www.sufeinet.com/thread-655-1-1.html
/// </summary>
using System;
using System.Diagnostics;
//using Excel;
namespace DotNet.Utilities
{
    /// <summary>
    /// �ާ@EXCEL�ɥX�ƾڳ�����
    /// </summary>
    public class DataToExcel
    {
        public DataToExcel()
        {
        }

        #region �ާ@EXCEL���@����(�ݭnExcel.dll���)

        private int titleColorindex = 15;
        /// <summary>
        /// ���D�I����
        /// </summary>
        public int TitleColorIndex
        {
            set { titleColorindex = value; }
            get { return titleColorindex; }
        }

        private DateTime beforeTime;			//Excel�Ұʤ��e�ɶ�
        private DateTime afterTime;				//Excel�Ұʤ���ɶ�

        #region �Ыؤ@��Excel�ܨ�
        /// <summary>
        /// �Ыؤ@��Excel�ܨ�
        /// </summary>
        public void CreateExcel()
        {
            //Excel.Application excel = new Excel.Application();
            //excel.Application.Workbooks.Add(true);
            //excel.Cells[1, 1] = "��1���1�C";
            //excel.Cells[1, 2] = "��1���2�C";
            //excel.Cells[2, 1] = "��2���1�C";
            //excel.Cells[2, 2] = "��2���2�C";
            //excel.Cells[3, 1] = "��3���1�C";
            //excel.Cells[3, 2] = "��3���2�C";

            ////�O�s
            //excel.ActiveWorkbook.SaveAs("./tt.xls", XlFileFormat.xlExcel9795, null, null, false, false, Excel.XlSaveAsAccessMode.xlNoChange, null, null, null, null, null);
            ////���}���
            //excel.Visible = true;
            ////			excel.Quit();
            ////			excel=null;            
            ////			GC.Collect();//�U���^��
        }
        #endregion

        #region �NDataTable���ƾھɥX��ܬ�����
        /// <summary>
        /// �NDataTable���ƾھɥX��ܬ�����
        /// </summary>
        /// <param name="dt">�n�ɥX���ƾ�</param>
        /// <param name="strTitle">�ɥX�������D</param>
        /// <param name="FilePath">�O�s��󪺸��|</param>
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

        //    //���o�C���D			
        //    foreach (DataColumn col in dt.Columns)
        //    {
        //        colIndex++;
        //        excel.Cells[4, colIndex] = col.ColumnName;

        //        //�]�m���D�榡���~�����
        //        xSt.get_Range(excel.Cells[4, colIndex], excel.Cells[4, colIndex]).Font.Bold = true;
        //        xSt.get_Range(excel.Cells[4, colIndex], excel.Cells[4, colIndex]).HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
        //        xSt.get_Range(excel.Cells[4, colIndex], excel.Cells[4, colIndex]).Select();
        //        xSt.get_Range(excel.Cells[4, colIndex], excel.Cells[4, colIndex]).Interior.ColorIndex = titleColorindex;//19;//�]�m���L����A�@�p��56��
        //    }


        //    //���o��椤���ƾ�			
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
        //                xSt.get_Range(excel.Cells[rowIndex, colIndex], excel.Cells[rowIndex, colIndex]).HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;//�]�m��������r�q�榡���~�����
        //            }
        //            else
        //                if (col.DataType == System.Type.GetType("System.String"))
        //                {
        //                    excel.Cells[rowIndex, colIndex] = "'" + row[col.ColumnName].ToString();
        //                    xSt.get_Range(excel.Cells[rowIndex, colIndex], excel.Cells[rowIndex, colIndex]).HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;//�]�m�r�ū����r�q�榡���~�����
        //                }
        //                else
        //                {
        //                    excel.Cells[rowIndex, colIndex] = row[col.ColumnName].ToString();
        //                }
        //        }
        //    }

        //    //�[���@�ӦX�p��			
        //    int rowSum = rowIndex + 1;
        //    int colSum = 2;
        //    excel.Cells[rowSum, 2] = "�X�p";
        //    xSt.get_Range(excel.Cells[rowSum, 2], excel.Cells[rowSum, 2]).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
        //    //�]�m�襤���������C��			
        //    xSt.get_Range(excel.Cells[rowSum, colSum], excel.Cells[rowSum, colIndex]).Select();
        //    //xSt.get_Range(excel.Cells[rowSum,colSum],excel.Cells[rowSum,colIndex]).Interior.ColorIndex =Assistant.GetConfigInt("ColorIndex");// 1;//�]�m���L����A�@�p��56��

        //    //���o��ӳ������D			
        //    excel.Cells[2, 2] = strTitle;

        //    //�]�m��ӳ������D�榡			
        //    xSt.get_Range(excel.Cells[2, 2], excel.Cells[2, 2]).Font.Bold = true;
        //    xSt.get_Range(excel.Cells[2, 2], excel.Cells[2, 2]).Font.Size = 22;

        //    //�]�m�����欰�̾A���e��			
        //    xSt.get_Range(excel.Cells[4, 2], excel.Cells[rowSum, colIndex]).Select();
        //    xSt.get_Range(excel.Cells[4, 2], excel.Cells[rowSum, colIndex]).Columns.AutoFit();

        //    //�]�m��ӳ������D����C�~��			
        //    xSt.get_Range(excel.Cells[2, 2], excel.Cells[2, colIndex]).Select();
        //    xSt.get_Range(excel.Cells[2, 2], excel.Cells[2, colIndex]).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenterAcrossSelection;

        //    //ø�s���			
        //    xSt.get_Range(excel.Cells[4, 2], excel.Cells[rowSum, colIndex]).Borders.LineStyle = 1;
        //    xSt.get_Range(excel.Cells[4, 2], excel.Cells[rowSum, 2]).Borders[Excel.XlBordersIndex.xlEdgeLeft].Weight = Excel.XlBorderWeight.xlThick;//�]�m����u�[��
        //    xSt.get_Range(excel.Cells[4, 2], excel.Cells[4, colIndex]).Borders[Excel.XlBordersIndex.xlEdgeTop].Weight = Excel.XlBorderWeight.xlThick;//�]�m�W��u�[��
        //    xSt.get_Range(excel.Cells[4, colIndex], excel.Cells[rowSum, colIndex]).Borders[Excel.XlBordersIndex.xlEdgeRight].Weight = Excel.XlBorderWeight.xlThick;//�]�m�k��u�[��
        //    xSt.get_Range(excel.Cells[rowSum, 2], excel.Cells[rowSum, colIndex]).Borders[Excel.XlBordersIndex.xlEdgeBottom].Weight = Excel.XlBorderWeight.xlThick;//�]�m�U��u�[��



        //    afterTime = DateTime.Now;

        //    //��ܮĪG			
        //    //excel.Visible=true;			
        //    //excel.Sheets[0] = "sss";

        //    ClearFile(FilePath);
        //    string filename = DateTime.Now.ToString("yyyyMMddHHmmssff") + ".xls";
        //    excel.ActiveWorkbook.SaveAs(FilePath + filename, Excel.XlFileFormat.xlExcel9795, null, null, false, false, Excel.XlSaveAsAccessMode.xlNoChange, null, null, null, null, null);

        //    //wkbNew.SaveAs strBookName;
        //    //excel.Save(strExcelFileName);

        //    #region  ����Excel�i�{

        //    //�ݭn��Excel��DCOM�ﹳ�i��t�m:dcomcnfg


        //    //excel.Quit();
        //    //excel=null;            

        //    xBk.Close(null, null, null);
        //    excel.Workbooks.Close();
        //    excel.Quit();


        //    //�`�N�G�o�̥Ψ쪺�Ҧ�Excel��H���n����o�Ӿާ@�A�_�h�������FExcel�i�{
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
        //    GC.Collect();//�U���^��
        //    #endregion

        //    return filename;

        //}
        #endregion

        #region Kill Excel�i�{

        /// <summary>
        /// ����Excel�i�{
        /// </summary>
        public void KillExcelProcess()
        {
            Process[] myProcesses;
            DateTime startTime;
            myProcesses = Process.GetProcessesByName("Excel");

            //�o����Excel�i�{ID�A�Ȯɥu��P�_�i�{�Ұʮɶ�
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

        #region �NDataTable���ƾھɥX��ܬ�����(���ϥ�Excel��H�A�ϥ�COM.Excel)

        #region �ϥΥܨ�
        /*�ϥΥܨҡG
         * DataSet ds=(DataSet)Session["AdBrowseHitDayList"];
            string ExcelFolder=Assistant.GetConfigString("ExcelFolder");
            string FilePath=Server.MapPath(".")+"\\"+ExcelFolder+"\\";
			
            //�ͦ��C�����������
            Hashtable nameList = new Hashtable();
            nameList.Add("ADID", "�s�i�s�X");
            nameList.Add("ADName", "�s�i�W��");
            nameList.Add("year", "�~");
            nameList.Add("month", "��");
            nameList.Add("browsum", "��ܼ�");
            nameList.Add("hitsum", "�I����");
            nameList.Add("BrowsinglIP", "�W��IP���");
            nameList.Add("HitsinglIP", "�W��IP�I��");
            //�Q��excel�ﹳ
            DataToExcel dte=new DataToExcel();
            string filename="";
            try
            {			
                if(ds.Tables[0].Rows.Count>0)
                {
                    filename=dte.DataExcel(ds.Tables[0],"���D",FilePath,nameList);
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
        /// �NDataTable���ƾھɥX��ܬ�����(���ϥ�Excel�ﹳ)
        /// </summary>
        /// <param name="dt">�ƾ�DataTable</param>
        /// <param name="strTitle">���D</param>
        /// <param name="FilePath">�ͦ���󪺸��|</param>
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
        //    string font = "�ө���";
        //    short fontsize = 9;
        //    excel.SetFont(ref font, ref fontsize, ref ff);

        //    byte b1 = 1,
        //        b2 = 12;
        //    short s3 = 12;
        //    excel.SetColumnWidth(ref b1, ref b2, ref s3);

        //    string header = "����";
        //    string footer = "���}";
        //    excel.SetHeader(ref header);
        //    excel.SetFooter(ref footer);


        //    COM.Excel.cExcelFile.ValueTypes vt = COM.Excel.cExcelFile.ValueTypes.xlsText;
        //    COM.Excel.cExcelFile.CellFont cf = COM.Excel.cExcelFile.CellFont.xlsFont0;
        //    COM.Excel.cExcelFile.CellAlignment ca = COM.Excel.cExcelFile.CellAlignment.xlsCentreAlign;
        //    COM.Excel.cExcelFile.CellHiddenLocked chl = COM.Excel.cExcelFile.CellHiddenLocked.xlsNormal;

        //    // ������D
        //    int cellformat = 1;
        //    //			int rowindex = 1,colindex = 3;					
        //    //			object title = (object)strTitle;
        //    //			excel.WriteValue(ref vt, ref cf, ref ca, ref chl,ref rowindex,ref colindex,ref title,ref cellformat);

        //    int rowIndex = 1;//�_�l��
        //    int colIndex = 0;



        //    //���o�C���D				
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

        //    //���o��椤���ƾ�			
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
        //    //				//MessageBox.Show(this,"�Х��}���c:\\test.xls!");
        //    //			}
        //    return filename;

        //}

        #endregion

        #region  �M�z�L�ɪ�Excel���

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
