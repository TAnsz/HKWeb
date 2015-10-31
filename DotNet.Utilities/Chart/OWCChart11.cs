///// <summary>
///// 類說明：進行作統計圖的封裝類
///// 聯繫方式：361983679  
///// 更新網站：http://www.sufeinet.com/thread-655-1-1.html
///// </summary>
//using System;
//using System.Data;
//using System.Text;

//namespace DotNet.Utilities
//{
//    /// <summary>
//    /// 進行作統計圖的封裝類。
//    /// </summary>
//    public class OWCChart
//    {

//        #region 屬性
//        private string _phaysicalimagepath;
//        private string _title;
//        private string _seriesname;
//        private int _picwidth;
//        private int _pichight;
//        private DataTable _datasource;
//        private string strCategory;
//        private string strValue;

//        public string PhaysicalImagePath
//        {
//            set { _phaysicalimagepath = value; }
//            get { return _phaysicalimagepath; }
//        }
//        public string Title
//        {
//            set { _title = value; }
//            get { return _title; }
//        }
//        public string SeriesName
//        {
//            set { _seriesname = value; }
//            get { return _seriesname; }
//        }

//        public int PicWidth
//        {
//            set { _picwidth = value; }
//            get { return _picwidth; }
//        }

//        public int PicHight
//        {
//            set { _pichight = value; }
//            get { return _pichight; }
//        }
//        public DataTable DataSource
//        {
//            set
//            {
//                _datasource = value;
//                strCategory = GetColumnsStr(_datasource);
//                strValue = GetValueStr(_datasource);
//            }
//            get { return _datasource; }
//        }

//        private string GetColumnsStr(System.Data.DataTable dt)
//        {
//            StringBuilder strList = new StringBuilder();
//            foreach (DataRow r in dt.Rows)
//            {
//                strList.Append(r[0].ToString() + '\t');
//            }
//            return strList.ToString();
//        }
//        private string GetValueStr(DataTable dt)
//        {
//            StringBuilder strList = new StringBuilder();
//            foreach (DataRow r in dt.Rows)
//            {
//                strList.Append(r[1].ToString() + '\t');
//            }
//            return strList.ToString();
//        }

//        #endregion


//        public OWCChart()
//        {
//        }
//        public OWCChart(string PhaysicalImagePath, string Title, string SeriesName)
//        {
//            _phaysicalimagepath = PhaysicalImagePath;
//            _title = Title;
//            _seriesname = SeriesName;
//        }


//        /// <summary>
//        /// 柱形圖
//        /// </summary>
//        /// <returns></returns>
//        public string CreateColumn()
//        {
//            Microsoft.Office.Interop.Owc11.ChartSpace objCSpace = new Microsoft.Office.Interop.Owc11.ChartSpaceClass();//創建ChartSpace對像來放置圖表			
//            Microsoft.Office.Interop.Owc11.ChChart objChart = objCSpace.Charts.Add(0);//在ChartSpace對像中添加圖表，Add方法返回chart對像

//            //指定圖表的類型。類型由OWC.ChartChartTypeEnum枚舉值得到//Microsoft.Office.Interop.OWC.ChartChartTypeEnum
//            objChart.Type = Microsoft.Office.Interop.Owc11.ChartChartTypeEnum.chChartTypeColumnClustered;

//            //指定圖表是否需要圖例
//            objChart.HasLegend = true;

//            //標題
//            objChart.HasTitle = true;
//            objChart.Title.Caption = _title;
//            //			objChart.Title.Font.Bold=true;
//            //			objChart.Title.Font.Color="blue";


//            #region 樣式設置

//            //			//旋轉
//            //			objChart.Rotation  = 360;//表示指定三維圖表的旋轉角度
//            //			objChart.Inclination = 10;//表示指定三維圖表的視圖斜率。有效範圍為 -90 到 90

//            //背景顏色
//            //			objChart.PlotArea.Interior.Color = "red";

//            //底座顏色
//            //			objChart.PlotArea.Floor.Interior.Color = "green";
//            // 
//            //			objChart.Overlap = 50;//單個類別中標誌之間的重疊量

//            #endregion

//            //x,y軸的圖示說明
//            objChart.Axes[0].HasTitle = true;
//            objChart.Axes[0].Title.Caption = "X ： 類別";
//            objChart.Axes[1].HasTitle = true;
//            objChart.Axes[1].Title.Caption = "Y ： 數量";


//            //添加一個series
//            Microsoft.Office.Interop.Owc11.ChSeries ThisChSeries = objChart.SeriesCollection.Add(0);


//            //給定series的名字
//            ThisChSeries.SetData(Microsoft.Office.Interop.Owc11.ChartDimensionsEnum.chDimSeriesNames,
//                Microsoft.Office.Interop.Owc11.ChartSpecialDataSourcesEnum.chDataLiteral.GetHashCode(), SeriesName);
//            //給定分類
//            ThisChSeries.SetData(Microsoft.Office.Interop.Owc11.ChartDimensionsEnum.chDimCategories,
//                Microsoft.Office.Interop.Owc11.ChartSpecialDataSourcesEnum.chDataLiteral.GetHashCode(), strCategory);
//            //給定值
//            ThisChSeries.SetData(Microsoft.Office.Interop.Owc11.ChartDimensionsEnum.chDimValues,
//                Microsoft.Office.Interop.Owc11.ChartSpecialDataSourcesEnum.chDataLiteral.GetHashCode(), strValue);

//            Microsoft.Office.Interop.Owc11.ChDataLabels dl = objChart.SeriesCollection[0].DataLabelsCollection.Add();
//            dl.HasValue = true;
//            //			dl.Position=Microsoft.Office.Interop.Owc11.ChartDataLabelPositionEnum.chLabelPositionOutsideEnd;


//            string filename = DateTime.Now.ToString("yyyyMMddHHmmssff") + ".gif";
//            string strAbsolutePath = _phaysicalimagepath + "\\" + filename;
//            objCSpace.ExportPicture(strAbsolutePath, "GIF", _picwidth, _pichight);//輸出成GIF文件.

//            return filename;

//        }


//        /// <summary>
//        /// 餅圖
//        /// </summary>
//        /// <returns></returns>
//        public string CreatePie()
//        {
//            Microsoft.Office.Interop.Owc11.ChartSpace objCSpace = new Microsoft.Office.Interop.Owc11.ChartSpaceClass();//創建ChartSpace對像來放置圖表			
//            Microsoft.Office.Interop.Owc11.ChChart objChart = objCSpace.Charts.Add(0);//在ChartSpace對像中添加圖表，Add方法返回chart對像


//            //指定圖表的類型
//            objChart.Type = Microsoft.Office.Interop.Owc11.ChartChartTypeEnum.chChartTypePie;

//            //指定圖表是否需要圖例
//            objChart.HasLegend = true;

//            //標題
//            objChart.HasTitle = true;
//            objChart.Title.Caption = _title;


//            //添加一個series
//            Microsoft.Office.Interop.Owc11.ChSeries ThisChSeries = objChart.SeriesCollection.Add(0);

//            //給定series的名字
//            ThisChSeries.SetData(Microsoft.Office.Interop.Owc11.ChartDimensionsEnum.chDimSeriesNames,
//                Microsoft.Office.Interop.Owc11.ChartSpecialDataSourcesEnum.chDataLiteral.GetHashCode(), SeriesName);
//            //給定分類
//            ThisChSeries.SetData(Microsoft.Office.Interop.Owc11.ChartDimensionsEnum.chDimCategories,
//                Microsoft.Office.Interop.Owc11.ChartSpecialDataSourcesEnum.chDataLiteral.GetHashCode(), strCategory);
//            //給定值
//            ThisChSeries.SetData(Microsoft.Office.Interop.Owc11.ChartDimensionsEnum.chDimValues,
//                Microsoft.Office.Interop.Owc11.ChartSpecialDataSourcesEnum.chDataLiteral.GetHashCode(), strValue);


//            //表示系列或趨勢線上的單個數據標誌
//            Microsoft.Office.Interop.Owc11.ChDataLabels dl = objChart.SeriesCollection[0].DataLabelsCollection.Add();
//            dl.HasValue = true;
//            dl.HasPercentage = true;
//            //圖表繪圖區的圖例放置在右側。
//            //			dl.Position=Microsoft.Office.Interop.Owc11.ChartDataLabelPositionEnum.chLabelPositionRight;

//            string filename = DateTime.Now.Ticks.ToString() + ".gif";
//            string strAbsolutePath = _phaysicalimagepath + "\\" + filename;
//            objCSpace.ExportPicture(strAbsolutePath, "GIF", _picwidth, _pichight);//輸出成GIF文件.

//            return filename;
//        }

//        /// <summary>
//        /// 條形圖
//        /// </summary>
//        /// <returns></returns>
//        public string CreateBar()
//        {
//            Microsoft.Office.Interop.Owc11.ChartSpace objCSpace = new Microsoft.Office.Interop.Owc11.ChartSpaceClass();//創建ChartSpace對像來放置圖表			
//            Microsoft.Office.Interop.Owc11.ChChart objChart = objCSpace.Charts.Add(0);//在ChartSpace對像中添加圖表，Add方法返回chart對像

//            //指定圖表的類型。類型由OWC.ChartChartTypeEnum枚舉值得到//Microsoft.Office.Interop.OWC.ChartChartTypeEnum
//            objChart.Type = Microsoft.Office.Interop.Owc11.ChartChartTypeEnum.chChartTypeBarClustered;

//            //指定圖表是否需要圖例
//            objChart.HasLegend = true;

//            //標題
//            objChart.HasTitle = true;
//            objChart.Title.Caption = _title;
//            //			objChart.Title.Font.Bold=true;
//            //			objChart.Title.Font.Color="blue";


//            #region 樣式設置

//            //			//旋轉
//            //			objChart.Rotation  = 360;//表示指定三維圖表的旋轉角度
//            //			objChart.Inclination = 10;//表示指定三維圖表的視圖斜率。有效範圍為 -90 到 90

//            //背景顏色
//            //			objChart.PlotArea.Interior.Color = "red";

//            //底座顏色
//            //			objChart.PlotArea.Floor.Interior.Color = "green";
//            // 
//            //			objChart.Overlap = 50;//單個類別中標誌之間的重疊量

//            #endregion

//            //x,y軸的圖示說明
//            objChart.Axes[0].HasTitle = true;
//            objChart.Axes[0].Title.Caption = "X ： 類別";
//            objChart.Axes[1].HasTitle = true;
//            objChart.Axes[1].Title.Caption = "Y ： 數量";


//            //添加一個series
//            Microsoft.Office.Interop.Owc11.ChSeries ThisChSeries = objChart.SeriesCollection.Add(0);


//            //給定series的名字
//            ThisChSeries.SetData(Microsoft.Office.Interop.Owc11.ChartDimensionsEnum.chDimSeriesNames,
//                Microsoft.Office.Interop.Owc11.ChartSpecialDataSourcesEnum.chDataLiteral.GetHashCode(), SeriesName);
//            //給定分類
//            ThisChSeries.SetData(Microsoft.Office.Interop.Owc11.ChartDimensionsEnum.chDimCategories,
//                Microsoft.Office.Interop.Owc11.ChartSpecialDataSourcesEnum.chDataLiteral.GetHashCode(), strCategory);
//            //給定值
//            ThisChSeries.SetData(Microsoft.Office.Interop.Owc11.ChartDimensionsEnum.chDimValues,
//                Microsoft.Office.Interop.Owc11.ChartSpecialDataSourcesEnum.chDataLiteral.GetHashCode(), strValue);

//            Microsoft.Office.Interop.Owc11.ChDataLabels dl = objChart.SeriesCollection[0].DataLabelsCollection.Add();
//            dl.HasValue = true;
//            //			dl.Position=Microsoft.Office.Interop.Owc11.ChartDataLabelPositionEnum.chLabelPositionOutsideEnd;


//            string filename = DateTime.Now.ToString("yyyyMMddHHmmssff") + ".gif";
//            string strAbsolutePath = _phaysicalimagepath + "\\" + filename;
//            objCSpace.ExportPicture(strAbsolutePath, "GIF", _picwidth, _pichight);//輸出成GIF文件.

//            return filename;

//        }

//    }
//}
