/// <summary>
/// 編 碼 人：蘇飛
/// 聯繫方式：361983679  
/// 更新網站：http://www.sufeinet.com/thread-655-1-1.html
/// </summary>
using System;
using System.Text;
using System.IO;
using System.Web;

namespace DotNet.Utilities
{
    /// <summary>
    /// 文件操作夾
    /// </summary>
    public static class DirFileHelper
    {
        #region 檢測指定目錄是否存在
        /// <summary>
        /// 檢測指定目錄是否存在
        /// </summary>
        /// <param name="directoryPath">目錄的絕對路徑</param>
        /// <returns></returns>
        public static bool IsExistDirectory(string directoryPath)
        {
            return Directory.Exists(directoryPath);
        }
        #endregion

        #region 檢測指定文件是否存在,如果存在返回true
        /// <summary>
        /// 檢測指定文件是否存在,如果存在則返回true。
        /// </summary>
        /// <param name="filePath">文件的絕對路徑</param>        
        public static bool IsExistFile(string filePath)
        {
            if (string.IsNullOrEmpty(filePath)) return false;

            if (filePath.IndexOf(":", System.StringComparison.Ordinal) < 0) { filePath = GetMapPath(filePath); }

            return File.Exists(filePath);
        }

        #endregion

        #region 獲取指定目錄中的文件列表
        /// <summary>
        /// 獲取指定目錄中所有文件列表
        /// </summary>
        /// <param name="directoryPath">指定目錄的絕對路徑</param>        
        public static string[] GetFileNames(string directoryPath)
        {
            //如果目錄不存在，則拋出異常
            if (!IsExistDirectory(directoryPath))
            {
                throw new FileNotFoundException();
            }

            //獲取文件列表
            return Directory.GetFiles(directoryPath);
        }
        #endregion

        #region 獲取指定目錄中所有子目錄列表,若要搜索嵌套的子目錄列表,請使用重載方法.
        /// <summary>
        /// 獲取指定目錄中所有子目錄列表,若要搜索嵌套的子目錄列表,請使用重載方法.
        /// </summary>
        /// <param name="directoryPath">指定目錄的絕對路徑</param>        
        public static string[] GetDirectories(string directoryPath)
        {
            try
            {
                return Directory.GetDirectories(directoryPath);
            }
            catch (IOException ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 獲取指定目錄及子目錄中所有文件列表
        /// <summary>
        /// 獲取指定目錄及子目錄中所有文件列表
        /// </summary>
        /// <param name="directoryPath">指定目錄的絕對路徑</param>
        /// <param name="searchPattern">模式字符串，"*"代表0或N個字符，"?"代表1個字符。
        /// 範例："Log*.xml"表示搜索所有以Log開頭的Xml文件。</param>
        /// <param name="isSearchChild">是否搜索子目錄</param>
        public static string[] GetFileNames(string directoryPath, string searchPattern, bool isSearchChild)
        {
            //如果目錄不存在，則拋出異常
            if (!IsExistDirectory(directoryPath))
            {
                throw new FileNotFoundException();
            }

            try
            {
                if (isSearchChild)
                {
                    return Directory.GetFiles(directoryPath, searchPattern, SearchOption.AllDirectories);
                }
                else
                {
                    return Directory.GetFiles(directoryPath, searchPattern, SearchOption.TopDirectoryOnly);
                }
            }
            catch (IOException ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 檢測指定目錄是否為空
        /// <summary>
        /// 檢測指定目錄是否為空
        /// </summary>
        /// <param name="directoryPath">指定目錄的絕對路徑</param>        
        public static bool IsEmptyDirectory(string directoryPath)
        {
            try
            {
                //判斷是否存在文件
                string[] fileNames = GetFileNames(directoryPath);
                if (fileNames.Length > 0)
                {
                    return false;
                }

                //判斷是否存在文件夾
                string[] directoryNames = GetDirectories(directoryPath);
                if (directoryNames.Length > 0)
                {
                    return false;
                }

                return true;
            }
            catch
            {
                //這裡記錄日誌
                //LogHelper.WriteTraceLog(TraceLogLevel.Error, ex.Message);
                return true;
            }
        }
        #endregion

        #region 檢測指定目錄中是否存在指定的文件
        /// <summary>
        /// 檢測指定目錄中是否存在指定的文件,若要搜索子目錄請使用重載方法.
        /// </summary>
        /// <param name="directoryPath">指定目錄的絕對路徑</param>
        /// <param name="searchPattern">模式字符串，"*"代表0或N個字符，"?"代表1個字符。
        /// 範例："Log*.xml"表示搜索所有以Log開頭的Xml文件。</param>        
        public static bool Contains(string directoryPath, string searchPattern)
        {
            try
            {
                //獲取指定的文件列表
                string[] fileNames = GetFileNames(directoryPath, searchPattern, false);

                //判斷指定文件是否存在
                if (fileNames.Length == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                //LogHelper.WriteTraceLog(TraceLogLevel.Error, ex.Message);
            }
        }

        /// <summary>
        /// 檢測指定目錄中是否存在指定的文件
        /// </summary>
        /// <param name="directoryPath">指定目錄的絕對路徑</param>
        /// <param name="searchPattern">模式字符串，"*"代表0或N個字符，"?"代表1個字符。
        /// 範例："Log*.xml"表示搜索所有以Log開頭的Xml文件。</param> 
        /// <param name="isSearchChild">是否搜索子目錄</param>
        public static bool Contains(string directoryPath, string searchPattern, bool isSearchChild)
        {
            try
            {
                //獲取指定的文件列表
                string[] fileNames = GetFileNames(directoryPath, searchPattern, true);

                //判斷指定文件是否存在
                if (fileNames.Length == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                //LogHelper.WriteTraceLog(TraceLogLevel.Error, ex.Message);
            }
        }
        #endregion

        #region 創建目錄
        /// <summary>
        /// 創建目錄
        /// </summary>
        /// <param name="dir">要創建的目錄路徑包括目錄名</param>
        public static void CreateDir(string dir)
        {
            if (dir.Length == 0) return;
            if (!Directory.Exists(System.Web.HttpContext.Current.Request.PhysicalApplicationPath + "\\" + dir))
                Directory.CreateDirectory(System.Web.HttpContext.Current.Request.PhysicalApplicationPath + "\\" + dir);
        }
        #endregion

        #region 刪除目錄
        /// <summary>
        /// 刪除目錄
        /// </summary>
        /// <param name="dir">要刪除的目錄路徑和名稱</param>
        public static void DeleteDir(string dir)
        {
            if (dir.Length == 0) return;
            if (Directory.Exists(System.Web.HttpContext.Current.Request.PhysicalApplicationPath + "\\" + dir))
                Directory.Delete(System.Web.HttpContext.Current.Request.PhysicalApplicationPath + "\\" + dir);
        }
        #endregion

        #region 刪除文件
        /// <summary>
        /// 刪除文件
        /// </summary>
        /// <param name="file">要刪除的文件路徑和名稱</param>
        public static bool DeleteFile(string file)
        {
            if (string.IsNullOrEmpty(file)) return false;
            if (file.IndexOf(":") < 0) { file = GetMapPath(file); }

            if (File.Exists(file))
            {
                try
                {
                    File.Delete(file);
                    return (!File.Exists(file));
                }
                catch
                {
                    return false;
                }
            }
            return false;

            //if (File.Exists(System.Web.HttpContext.Current.Request.PhysicalApplicationPath + file))
            //    File.Delete(System.Web.HttpContext.Current.Request.PhysicalApplicationPath + file);
        }
        #endregion

        #region 創建文件
        /// <summary>
        /// 創建文件
        /// </summary>
        /// <param name="dir">帶後綴的文件名</param>
        /// <param name="pagestr">文件內容</param>
        public static void CreateFile(string dir, string pagestr)
        {
            dir = dir.Replace("/", "\\");
            if (dir.IndexOf("\\") > -1)
                CreateDir(dir.Substring(0, dir.LastIndexOf("\\")));
            System.IO.StreamWriter sw = new System.IO.StreamWriter(System.Web.HttpContext.Current.Request.PhysicalApplicationPath + "\\" + dir, false, System.Text.Encoding.GetEncoding("GB2312"));
            sw.Write(pagestr);
            sw.Close();
        }
        #endregion

        #region 移動文件(剪貼--粘貼)
        /// <summary>
        /// 移動文件(剪貼--粘貼)
        /// </summary>
        /// <param name="dir1">要移動的文件的路徑及全名(包括後綴)</param>
        /// <param name="dir2">文件移動到新的位置,並指定新的文件名</param>
        public static void MoveFile(string dir1, string dir2)
        {
            dir1 = dir1.Replace("/", "\\");
            dir2 = dir2.Replace("/", "\\");
            if (File.Exists(System.Web.HttpContext.Current.Request.PhysicalApplicationPath + "\\" + dir1))
                File.Move(System.Web.HttpContext.Current.Request.PhysicalApplicationPath + "\\" + dir1, System.Web.HttpContext.Current.Request.PhysicalApplicationPath + "\\" + dir2);
        }
        #endregion

        #region 複製文件
        ///// <summary>
        ///// 複製文件
        ///// </summary>
        ///// <param name="dir1">要複製的文件的路徑已經全名(包括後綴)</param>
        ///// <param name="dir2">目標位置,並指定新的文件名</param>
        //public static void CopyFile(string dir1, string dir2)
        //{
        //    dir1 = dir1.Replace("/", "\\");
        //    dir2 = dir2.Replace("/", "\\");
        //    if (File.Exists(System.Web.HttpContext.Current.Request.PhysicalApplicationPath + "\\" + dir1))
        //    {
        //        File.Copy(System.Web.HttpContext.Current.Request.PhysicalApplicationPath + "\\" + dir1, System.Web.HttpContext.Current.Request.PhysicalApplicationPath + "\\" + dir2, true);
        //    }
        //}

        /// <summary>複製文件</summary>
        /// <param name="oldFile">原始文件名(包括完整路徑)</param>
        /// <param name="newFile">目標文件名(包括完整路徑)</param>
        /// <returns></returns>
        public static bool CopyFile(string oldFile, string newFile)
        {
            if (string.IsNullOrEmpty(oldFile)) return false;
            if (oldFile.IndexOf(":") < 0) { oldFile = GetMapPath(oldFile); }
            if (newFile.IndexOf(":") < 0) { newFile = GetMapPath(newFile); }

            if (File.Exists(oldFile))
            {
                try
                {
                    File.Copy(oldFile, newFile, true);
                    return (File.Exists(newFile));
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }
        #endregion

        #region 根據時間得到目錄名 / 格式:yyyyMMdd 或者 HHmmssff
        /// <summary>
        /// 根據時間得到目錄名yyyyMMdd
        /// </summary>
        /// <returns></returns>
        public static string GetDateDir()
        {
            return DateTime.Now.ToString("yyyyMMdd");
        }
        /// <summary>
        /// 根據時間得到文件名HHmmssff
        /// </summary>
        /// <returns></returns>
        public static string GetDateFile()
        {
            return DateTime.Now.ToString("HHmmssff");
        }
        #endregion

        #region 複製文件夾
        /// <summary>
        /// 複製文件夾(遞歸)
        /// </summary>
        /// <param name="varFromDirectory">源文件夾路徑</param>
        /// <param name="varToDirectory">目標文件夾路徑</param>
        public static void CopyFolder(string varFromDirectory, string varToDirectory)
        {
            Directory.CreateDirectory(varToDirectory);

            if (!Directory.Exists(varFromDirectory)) return;

            string[] directories = Directory.GetDirectories(varFromDirectory);

            if (directories.Length > 0)
            {
                foreach (string d in directories)
                {
                    CopyFolder(d, varToDirectory + d.Substring(d.LastIndexOf("\\")));
                }
            }
            string[] files = Directory.GetFiles(varFromDirectory);
            if (files.Length > 0)
            {
                foreach (string s in files)
                {
                    File.Copy(s, varToDirectory + s.Substring(s.LastIndexOf("\\")), true);
                }
            }
        }
        #endregion

        #region 檢查文件,如果文件不存在則創建
        /// <summary>
        /// 檢查文件,如果文件不存在則創建  
        /// </summary>
        /// <param name="FilePath">路徑,包括文件名</param>
        public static void ExistsFile(string FilePath)
        {
            //if(!File.Exists(FilePath))    
            //File.Create(FilePath);    
            //以上寫法會報錯,詳細解釋請看下文.........   
            if (!File.Exists(FilePath))
            {
                FileStream fs = File.Create(FilePath);
                fs.Close();
            }
        }
        #endregion

        #region 刪除指定文件夾對應其他文件夾裡的文件
        /// <summary>
        /// 刪除指定文件夾對應其他文件夾裡的文件
        /// </summary>
        /// <param name="varFromDirectory">指定文件夾路徑</param>
        /// <param name="varToDirectory">對應其他文件夾路徑</param>
        public static void DeleteFolderFiles(string varFromDirectory, string varToDirectory)
        {
            Directory.CreateDirectory(varToDirectory);

            if (!Directory.Exists(varFromDirectory)) return;

            string[] directories = Directory.GetDirectories(varFromDirectory);

            if (directories.Length > 0)
            {
                foreach (string d in directories)
                {
                    DeleteFolderFiles(d, varToDirectory + d.Substring(d.LastIndexOf("\\")));
                }
            }


            string[] files = Directory.GetFiles(varFromDirectory);

            if (files.Length > 0)
            {
                foreach (string s in files)
                {
                    File.Delete(varToDirectory + s.Substring(s.LastIndexOf("\\")));
                }
            }
        }
        #endregion

        #region 從文件的絕對路徑中獲取文件名( 包含擴展名 )
        ///// <summary>
        ///// 從文件的絕對路徑中獲取文件名( 包含擴展名 )
        ///// </summary>
        ///// <param name="filePath">文件的絕對路徑</param>        
        //public static string GetFileName(string filePath)
        //{
        //    //獲取文件的名稱
        //    FileInfo fi = new FileInfo(filePath);
        //    return fi.Name;
        //}

        /// <summary>從路徑中抽取文件名(包括擴展名)</summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetFileName(string str)
        {
            if (string.IsNullOrEmpty(str)) return "";

            if (str.Length > 0)
            {
                if (str.LastIndexOf("/") > 0)
                {
                    str = str.Substring(str.LastIndexOf("/") + 1);
                }
                else if (str.LastIndexOf("\\") > 0)
                {
                    str = str.Substring(str.LastIndexOf("\\") + 1);
                }
            }
            return str;
        }

        /// <summary>從路徑中抽取文件名(是否包含擴展名)</summary>
        /// <param name="str"></param>
        /// <param name="noExt">=true時(不包括擴展名)</param>
        /// <returns></returns>
        public static string GetFileName(string str, bool noExt = false)
        {
            if (string.IsNullOrEmpty(str)) return "";

            if (str.Length > 0)
            {
                str = GetFileName(str);
                if (noExt & str.LastIndexOf(".") > 0)
                {
                    str = str.Substring(0, str.LastIndexOf("."));
                }
            }
            return str;
        }
        #endregion

        
        #region 創建一個目錄
        /// <summary>
        /// 創建一個目錄
        /// </summary>
        /// <param name="directoryPath">目錄的絕對路徑</param>
        public static void CreateDirectory(string directoryPath)
        {
            //如果目錄不存在則創建該目錄
            if (!IsExistDirectory(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
        }
        #endregion

        #region 創建一個文件
        /// <summary>
        /// 創建一個文件。
        /// </summary>
        /// <param name="filePath">文件的絕對路徑</param>
        public static void CreateFile(string filePath)
        {
            try
            {
                //如果文件不存在則創建該文件
                if (!IsExistFile(filePath))
                {
                    //創建一個FileInfo對像
                    FileInfo file = new FileInfo(filePath);

                    //創建文件
                    FileStream fs = file.Create();

                    //關閉文件流
                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                //LogHelper.WriteTraceLog(TraceLogLevel.Error, ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// 創建一個文件,並將字節流寫入文件。
        /// </summary>
        /// <param name="filePath">文件的絕對路徑</param>
        /// <param name="buffer">二進制流數據</param>
        public static void CreateFile(string filePath, byte[] buffer)
        {
            try
            {
                //如果文件不存在則創建該文件
                if (!IsExistFile(filePath))
                {
                    //創建一個FileInfo對像
                    FileInfo file = new FileInfo(filePath);

                    //創建文件
                    FileStream fs = file.Create();

                    //寫入二進制流
                    fs.Write(buffer, 0, buffer.Length);

                    //關閉文件流
                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                //LogHelper.WriteTraceLog(TraceLogLevel.Error, ex.Message);
                throw ex;
            }
        }
        #endregion

        #region 獲取文本文件的行數
        /// <summary>
        /// 獲取文本文件的行數
        /// </summary>
        /// <param name="filePath">文件的絕對路徑</param>        
        public static int GetLineCount(string filePath)
        {
            //將文本文件的各行讀到一個字符串數組中
            string[] rows = File.ReadAllLines(filePath);

            //返回行數
            return rows.Length;
        }
        #endregion

        #region 獲取一個文件的長度
        /// <summary>
        /// 獲取一個文件的長度,單位為Byte
        /// </summary>
        /// <param name="filePath">文件的絕對路徑</param>        
        public static int GetFileSize(string filePath)
        {
            //創建一個文件對像
            FileInfo fi = new FileInfo(filePath);

            //獲取文件的大小
            return (int)fi.Length;
        }
        #endregion

        #region 獲取指定目錄中的子目錄列表
        /// <summary>
        /// 獲取指定目錄及子目錄中所有子目錄列表
        /// </summary>
        /// <param name="directoryPath">指定目錄的絕對路徑</param>
        /// <param name="searchPattern">模式字符串，"*"代表0或N個字符，"?"代表1個字符。
        /// 範例："Log*.xml"表示搜索所有以Log開頭的Xml文件。</param>
        /// <param name="isSearchChild">是否搜索子目錄</param>
        public static string[] GetDirectories(string directoryPath, string searchPattern, bool isSearchChild)
        {
            try
            {
                if (isSearchChild)
                {
                    return Directory.GetDirectories(directoryPath, searchPattern, SearchOption.AllDirectories);
                }
                else
                {
                    return Directory.GetDirectories(directoryPath, searchPattern, SearchOption.TopDirectoryOnly);
                }
            }
            catch (IOException ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 向文本文件寫入內容

        /// <summary>
        /// 向文本文件中寫入內容
        /// </summary>
        /// <param name="filePath">文件的絕對路徑</param>
        /// <param name="text">寫入的內容</param>
        /// <param name="encoding">編碼</param>
        public static void WriteText(string filePath, string text, Encoding encoding)
        {
            //向文件寫入內容
            File.WriteAllText(filePath, text, encoding);
        }
        #endregion

        #region 向文本文件的尾部追加內容
        /// <summary>
        /// 向文本文件的尾部追加內容
        /// </summary>
        /// <param name="filePath">文件的絕對路徑</param>
        /// <param name="content">寫入的內容</param>
        public static void AppendText(string filePath, string content)
        {
            File.AppendAllText(filePath, content);
        }
        #endregion

        #region 將現有文件的內容複製到新文件中
        /// <summary>
        /// 將源文件的內容複製到目標文件中
        /// </summary>
        /// <param name="sourceFilePath">源文件的絕對路徑</param>
        /// <param name="destFilePath">目標文件的絕對路徑</param>
        public static void Copy(string sourceFilePath, string destFilePath)
        {
            File.Copy(sourceFilePath, destFilePath, true);
        }
        #endregion

        #region 將文件移動到指定目錄
        /// <summary>
        /// 將文件移動到指定目錄
        /// </summary>
        /// <param name="sourceFilePath">需要移動的源文件的絕對路徑</param>
        /// <param name="descDirectoryPath">移動到的目錄的絕對路徑</param>
        public static void Move(string sourceFilePath, string descDirectoryPath)
        {
            //獲取源文件的名稱
            string sourceFileName = GetFileName(sourceFilePath);

            if (IsExistDirectory(descDirectoryPath))
            {
                //如果目標中存在同名文件,則刪除
                if (IsExistFile(descDirectoryPath + "\\" + sourceFileName))
                {
                    DeleteFile(descDirectoryPath + "\\" + sourceFileName);
                }
                //將文件移動到指定目錄
                File.Move(sourceFilePath, descDirectoryPath + "\\" + sourceFileName);
            }
        }
        #endregion

        #region 從文件的絕對路徑中獲取文件名( 不包含擴展名 )
        /// <summary>
        /// 從文件的絕對路徑中獲取文件名( 不包含擴展名 )
        /// </summary>
        /// <param name="filePath">文件的絕對路徑</param>        
        public static string GetFileNameNoExtension(string filePath)
        {
            //獲取文件的名稱
            FileInfo fi = new FileInfo(filePath);
            return fi.Name.Split('.')[0];
        }
        #endregion

        #region 從文件的絕對路徑中獲取擴展名
        /// <summary>
        /// 從文件的絕對路徑中獲取擴展名
        /// </summary>
        /// <param name="filePath">文件的絕對路徑</param>        
        public static string GetExtension(string filePath)
        {
            //獲取文件的名稱
            FileInfo fi = new FileInfo(filePath);
            return fi.Extension;
        }

        /// <summary>從文件名中抽取擴展名</summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetFileExtension(string str)
        {
            if (string.IsNullOrEmpty(str)) return "";

            if (str.Length > 0)
            {
                if (str.LastIndexOf(".") > 0)
                {
                    str = str.Substring(str.LastIndexOf(".") + 1);
                }
                else
                {
                    str = "";
                }
            }
            return str;
        }
        #endregion

        #region 清空指定目錄
        /// <summary>
        /// 清空指定目錄下所有文件及子目錄,但該目錄依然保存.
        /// </summary>
        /// <param name="directoryPath">指定目錄的絕對路徑</param>
        public static void ClearDirectory(string directoryPath)
        {
            if (IsExistDirectory(directoryPath))
            {
                //刪除目錄中所有的文件
                string[] fileNames = GetFileNames(directoryPath);
                for (int i = 0; i < fileNames.Length; i++)
                {
                    DeleteFile(fileNames[i]);
                }

                //刪除目錄中所有的子目錄
                string[] directoryNames = GetDirectories(directoryPath);
                for (int i = 0; i < directoryNames.Length; i++)
                {
                    DeleteDirectory(directoryNames[i]);
                }
            }
        }
        #endregion

        #region 清空文件內容
        /// <summary>
        /// 清空文件內容
        /// </summary>
        /// <param name="filePath">文件的絕對路徑</param>
        public static void ClearFile(string filePath)
        {
            //刪除文件
            File.Delete(filePath);

            //重新創建該文件
            CreateFile(filePath);
        }
        #endregion

        #region 刪除指定目錄
        /// <summary>
        /// 刪除指定目錄及其所有子目錄
        /// </summary>
        /// <param name="directoryPath">指定目錄的絕對路徑</param>
        public static void DeleteDirectory(string directoryPath)
        {
            if (IsExistDirectory(directoryPath))
            {
                Directory.Delete(directoryPath, true);
            }
        }
        #endregion

        #region 修正路徑右邊缺少"/"
        /// <summary>修正路徑右邊缺少"/"</summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string FixDirPath(string str)
        {
            if (string.IsNullOrEmpty(str)) return "";

            if (str.Length > 0)
            {
                str = str.Replace("\\", "/");

                if (!str.EndsWith("/")) { str += "/"; }
            }
            return str;
        }
        #endregion

        #region 創建目錄,如果父目錄不存在,將一級級生成
        /// <summary>創建目錄,如果父目錄不存在,將一級級生成.</summary>
        /// <param name="sCheckPath">/newsfile/2009/07/</param>
        /// <returns>返回創建目錄是否成功</returns>
        public static bool CheckSaveDir(string sCheckPath)
        {
            if (sCheckPath == "")
            {
                return false;
            }

            string fPath = sCheckPath;
            if (!fPath.EndsWith("/"))
            {
                fPath += "/";
            }

            fPath = GetMapPath(fPath);
            if (Directory.Exists(fPath))
            {
                return true;
            }
            else
            {
                int iRootCount = GetMapPath("\\").Split('\\').Length;
                int iDirCount = fPath.Split('\\').Length;

                string[] aPathRs = fPath.Split('\\');
                string tPath = aPathRs[0] + "\\";

                for (int i = 1; i < iDirCount; i++)
                {
                    tPath += aPathRs[i] + "\\";
                    if (i >= iRootCount && i <= iDirCount)
                    {
                        try
                        {
                            if (!Directory.Exists(tPath)) Directory.CreateDirectory(tPath);
                        }
                        catch
                        {
                            return false;
                        }
                    }
                }
                return Directory.Exists(fPath);
            }
        }
        #endregion

        #region 獲得當前絕對路徑
        /// <summary>獲得當前絕對路徑</summary>
        /// <param name="strPath">指定的路徑</param>
        /// <returns>絕對路徑</returns>
        public static string GetMapPath(string strPath)
        {
            try
            {
                if (HttpContext.Current != null)
                {
                    return HttpContext.Current.Server.MapPath(strPath);
                }
                else
                {
                    return HttpContext.Current.Server.MapPath("/");
                }
            }
            catch (Exception)
            {
                return "";
            }
        }
        #endregion

        #region 從文件名中加後綴字符,組成新文件名,用於縮略圖
        /// <summary>從文件名中加後綴字符,組成新文件名,用於縮略圖<para />
        /// 例如:getFileNamePostfix("090801.gif","s") return "090801s.gif" <para />
        /// </summary>
        /// <param name="sFileName">文件名</param>
        /// <param name="sPostfix">後綴字符</param>
        /// <returns></returns>
        public static string GetFileNamePostfix(string sFileName, string sPostfix)
        {
            if (string.IsNullOrEmpty(sFileName)) return "";

            //如果是路徑,則抽取文件名
            string str = GetFileName(sFileName);

            if (str.Length > 0)
            {
                if (str.LastIndexOf(".") > 0)
                {
                    int iTmp = str.LastIndexOf(".");

                    str = str.Substring(0, iTmp) + sPostfix + str.Substring(iTmp);
                }
                else
                {
                    str += sPostfix;
                }
            }
            return str;
        }

        /// <summary>從文件名中加後綴字符,組成新文件名,用於縮略圖,(包括路徑)<para />
        /// 例如:getFilePathPostfix("090801.gif","s") return "090801s.gif" <para />
        /// </summary>
        /// <param name="sFileName">文件名</param>
        /// <param name="sPostfix">後綴字符</param>
        /// <returns></returns>
        public static string GetFilePathPostfix(string sFileName, string sPostfix)
        {
            if (string.IsNullOrEmpty(sFileName)) return "";

            string str = sFileName;

            if (str.Length > 0)
            {
                if (str.LastIndexOf(".") > 0)
                {
                    int iTmp = str.LastIndexOf(".");

                    str = str.Substring(0, iTmp) + sPostfix + str.Substring(iTmp);
                }
                else
                {
                    str += sPostfix;
                }
            }
            return str;
        }
        #endregion

        #region 刪除圖片文件,連同相關的大型圖,中型圖,微型圖一併刪除
        /// <summary>刪除圖片文件,連同相關的大型圖,中型圖,微型圖一併刪除</summary>
        /// <param name="filename">文件名(包括完整路徑)</param>
        /// <returns></returns>
        public static bool DelPicFile(string filename)
        {
            if (string.IsNullOrEmpty(filename)) return false;

            string bigImg = GetFilePathPostfix(filename, "b");
            string midImg = GetFilePathPostfix(filename, "m");
            string minImg = GetFilePathPostfix(filename, "s");
            string orgImg = GetFilePathPostfix(filename, "o");
            string hotImg = GetFilePathPostfix(filename, "h");

            DeleteFile(filename);
            DeleteFile(bigImg);
            DeleteFile(midImg);
            DeleteFile(minImg);
            DeleteFile(orgImg);
            DeleteFile(hotImg);

            return true;
        }
        #endregion

        #region 返回文件文件大小（Size）的字符格式
        /// <summary>返回文件Size的字符格式</summary>
        /// <param name="bytes">bytes</param>
        /// <returns>例如:1024=1Kb</returns>
        public static string FmtFileSize(long bytes)
        {
            if (bytes >= 1073741824)
            {
                return ((double)(bytes / 1073741824)).ToString("0") + "GB";
            }
            if (bytes >= 1048576)
            {
                return ((double)(bytes / 1048576)).ToString("0") + "MB";
            }
            if (bytes >= 1024)
            {
                return ((double)(bytes / 1024)).ToString("0") + "KB";
            }
            return bytes.ToString() + "bytes";
        }

        /// <summary>返回文件Size的字符格式（注意：傳入參數為kb）</summary>
        /// <param name="kb">kb</param>
        /// <returns>例如:1024=1Kb</returns>
        public static string FmtFileSize2(int kb)
        {
            if (kb >= 1048576)
            {
                return ((double)(kb / 1048576)).ToString("0") + "G";
            }
            if (kb >= 1024)
            {
                return ((double)(kb / 1024)).ToString("0") + "M";
            }
            return kb.ToString() + "K";
        }
        #endregion

        #region 從(路徑+文件名)中抽取路徑
        /// <summary>從(路徑+文件名)中抽取路徑</summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetFilePath(string str)
        {
            if (string.IsNullOrEmpty(str)) return "";

            if (str.Length > 0)
            {
                if (str.LastIndexOf("/") > 0)
                {
                    str = str.Substring(0, str.LastIndexOf("/"));
                }
                else if (str.LastIndexOf("\\") > 0)
                {
                    str = str.Substring(0, str.LastIndexOf("\\"));
                }
                else
                {
                    str = "";
                }
            }
            return str;
        }
        #endregion

        #region 取得隨機文件名(原文件名),用yyMMddhhmmss + (xxx),共15位數字
        /// <summary> 取得隨機文件名(原文件名),用yyMMddhhmmss + (xxx),共15位數字</summary>
        /// <param name="fileName">原文件名或文件擴展名</param>
        /// <returns></returns>
        public static string GetRndFileName(string fileName)
        {
            string sDate = RandomHelper.GetDateRnd();
            string fileExt = "";

            if (fileName.LastIndexOf(".") > 0)
            {
                fileExt = fileName.Substring(fileName.LastIndexOf("."));
            }
            else
            {
                fileExt = fileName;
            }
            return sDate + fileExt;
        }
        #endregion
    }
}
