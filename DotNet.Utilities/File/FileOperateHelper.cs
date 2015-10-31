/// <summary>
/// 類說明：Assistant
/// 編 碼 人：蘇飛
/// 聯繫方式：361983679  
/// 更新網站：http://www.sufeinet.com/thread-655-1-1.html
/// </summary>
using System;
using System.Text;
using System.Web;
using System.IO;

namespace DotNet.Utilities
{
    /// <summary>
    /// 文件操作類
    /// </summary>
    public class FileOperateHelper
    {
        #region 寫文件
        protected void Write_Txt(string FileName, string Content)
        {
            Encoding code = Encoding.GetEncoding("gb2312");
            string htmlfilename = HttpContext.Current.Server.MapPath("Precious\\" + FileName + ".txt");　//保存文件的路徑
            string str = Content;
            StreamWriter sw = null;
            {
                try
                {
                    sw = new StreamWriter(htmlfilename, false, code);
                    sw.Write(str);
                    sw.Flush();
                }
                catch { }
            }
            sw.Close();
            sw.Dispose();

        }
        #endregion

        #region 讀文件
        protected string Read_Txt(string filename)
        {

            Encoding code = Encoding.GetEncoding("gb2312");
            string temp = HttpContext.Current.Server.MapPath("Precious\\" + filename + ".txt");
            string str = "";
            if (File.Exists(temp))
            {
                StreamReader sr = null;
                try
                {
                    sr = new StreamReader(temp, code);
                    str = sr.ReadToEnd(); // 讀取文件
                }
                catch { }
                sr.Close();
                sr.Dispose();
            }
            else
            {
                str = "";
            }


            return str;
        }
        #endregion

        #region 取得文件後綴名
        /****************************************
         * 函數名稱：GetPostfixStr
         * 功能說明：取得文件後綴名
         * 參    數：filename:文件名稱
         * 調用示列：
         *           string filename = "aaa.aspx";        
         *           string s = DotNet.Utilities.FileOperate.GetPostfixStr(filename);         
        *****************************************/
        /// <summary>
        /// 取後綴名
        /// </summary>
        /// <param name="filename">文件名</param>
        /// <returns>.gif|.html格式</returns>
        public static string GetPostfixStr(string filename)
        {
            int start = filename.LastIndexOf(".");
            int length = filename.Length;
            string postfix = filename.Substring(start, length - start);
            return postfix;
        }
        #endregion

        #region 寫文件
        /****************************************
         * 函數名稱：WriteFile
         * 功能說明：當文件不存時，則創建文件，並追加文件
         * 參    數：Path:文件路徑,Strings:文本內容
         * 調用示列：
         *           string Path = Server.MapPath("Default2.aspx");       
         *           string Strings = "這是我寫的內容啊";
         *           DotNet.Utilities.FileOperate.WriteFile(Path,Strings);
        *****************************************/
        /// <summary>
        /// 寫文件
        /// </summary>
        /// <param name="Path">文件路徑</param>
        /// <param name="Strings">文件內容</param>
        public static void WriteFile(string Path, string Strings)
        {

            if (!System.IO.File.Exists(Path))
            {
                System.IO.FileStream f = System.IO.File.Create(Path);
                f.Close();
                f.Dispose();
            }
            System.IO.StreamWriter f2 = new System.IO.StreamWriter(Path, true, System.Text.Encoding.UTF8);
            f2.WriteLine(Strings);
            f2.Close();
            f2.Dispose();


        }
        #endregion

        #region 讀文件
        /****************************************
         * 函數名稱：ReadFile
         * 功能說明：讀取文本內容
         * 參    數：Path:文件路徑
         * 調用示列：
         *           string Path = Server.MapPath("Default2.aspx");       
         *           string s = DotNet.Utilities.FileOperate.ReadFile(Path);
        *****************************************/
        /// <summary>
        /// 讀文件
        /// </summary>
        /// <param name="Path">文件路徑</param>
        /// <returns></returns>
        public static string ReadFile(string Path)
        {
            string s = "";
            if (!System.IO.File.Exists(Path))
                s = "不存在相應的目錄";
            else
            {
                StreamReader f2 = new StreamReader(Path, System.Text.Encoding.GetEncoding("gb2312"));
                s = f2.ReadToEnd();
                f2.Close();
                f2.Dispose();
            }

            return s;
        }
        #endregion

        #region 追加文件
        /****************************************
         * 函數名稱：FileAdd
         * 功能說明：追加文件內容
         * 參    數：Path:文件路徑,strings:內容
         * 調用示列：
         *           string Path = Server.MapPath("Default2.aspx");     
         *           string Strings = "新追加內容";
         *           DotNet.Utilities.FileOperate.FileAdd(Path, Strings);
        *****************************************/
        /// <summary>
        /// 追加文件
        /// </summary>
        /// <param name="Path">文件路徑</param>
        /// <param name="strings">內容</param>
        public static void FileAdd(string Path, string strings)
        {
            StreamWriter sw = File.AppendText(Path);
            sw.Write(strings);
            sw.Flush();
            sw.Close();
            sw.Dispose();
        }
        #endregion

        #region 拷貝文件
        /****************************************
         * 函數名稱：FileCoppy
         * 功能說明：拷貝文件
         * 參    數：OrignFile:原始文件,NewFile:新文件路徑
         * 調用示列：
         *           string OrignFile = Server.MapPath("Default2.aspx");     
         *           string NewFile = Server.MapPath("Default3.aspx");
         *           DotNet.Utilities.FileOperate.FileCoppy(OrignFile, NewFile);
        *****************************************/
        /// <summary>
        /// 拷貝文件
        /// </summary>
        /// <param name="OrignFile">原始文件</param>
        /// <param name="NewFile">新文件路徑</param>
        public static void FileCoppy(string OrignFile, string NewFile)
        {
            File.Copy(OrignFile, NewFile, true);
        }

        #endregion

        #region 刪除文件
        /****************************************
         * 函數名稱：FileDel
         * 功能說明：刪除文件
         * 參    數：Path:文件路徑
         * 調用示列：
         *           string Path = Server.MapPath("Default3.aspx");    
         *           DotNet.Utilities.FileOperate.FileDel(Path);
        *****************************************/
        /// <summary>
        /// 刪除文件
        /// </summary>
        /// <param name="Path">路徑</param>
        public static void FileDel(string Path)
        {
            File.Delete(Path);
        }
        #endregion

        #region 移動文件
        /****************************************
         * 函數名稱：FileMove
         * 功能說明：移動文件
         * 參    數：OrignFile:原始路徑,NewFile:新文件路徑
         * 調用示列：
         *            string OrignFile = Server.MapPath("../說明.txt");    
         *            string NewFile = Server.MapPath("../../說明.txt");
         *            DotNet.Utilities.FileOperate.FileMove(OrignFile, NewFile);
        *****************************************/
        /// <summary>
        /// 移動文件
        /// </summary>
        /// <param name="OrignFile">原始路徑</param>
        /// <param name="NewFile">新路徑</param>
        public static void FileMove(string OrignFile, string NewFile)
        {
            File.Move(OrignFile, NewFile);
        }
        #endregion

        #region 在當前目錄下創建目錄
        /****************************************
         * 函數名稱：FolderCreate
         * 功能說明：在當前目錄下創建目錄
         * 參    數：OrignFolder:當前目錄,NewFloder:新目錄
         * 調用示列：
         *           string OrignFolder = Server.MapPath("test/");    
         *           string NewFloder = "new";
         *           DotNet.Utilities.FileOperate.FolderCreate(OrignFolder, NewFloder); 
        *****************************************/
        /// <summary>
        /// 在當前目錄下創建目錄
        /// </summary>
        /// <param name="OrignFolder">當前目錄</param>
        /// <param name="NewFloder">新目錄</param>
        public static void FolderCreate(string OrignFolder, string NewFloder)
        {
            Directory.SetCurrentDirectory(OrignFolder);
            Directory.CreateDirectory(NewFloder);
        }

        /// <summary>
        /// 創建文件夾
        /// </summary>
        /// <param name="Path"></param>
        public static void FolderCreate(string Path)
        {
            // 判斷目標目錄是否存在如果不存在則新建之
            if (!Directory.Exists(Path))
                Directory.CreateDirectory(Path);
        }

        #endregion

        #region 創建目錄
        public static void FileCreate(string Path)
        {
            FileInfo CreateFile = new FileInfo(Path); //創建文件 
            if (!CreateFile.Exists)
            {
                FileStream FS = CreateFile.Create();
                FS.Close();
            }
        }
        #endregion

        #region 遞歸刪除文件夾目錄及文件
        /****************************************
         * 函數名稱：DeleteFolder
         * 功能說明：遞歸刪除文件夾目錄及文件
         * 參    數：dir:文件夾路徑
         * 調用示列：
         *           string dir = Server.MapPath("test/");  
         *           DotNet.Utilities.FileOperate.DeleteFolder(dir);       
        *****************************************/
        /// <summary>
        /// 遞歸刪除文件夾目錄及文件
        /// </summary>
        /// <param name="dir"></param>  
        /// <returns></returns>
        public static void DeleteFolder(string dir)
        {
            if (Directory.Exists(dir)) //如果存在這個文件夾刪除之 
            {
                foreach (string d in Directory.GetFileSystemEntries(dir))
                {
                    if (File.Exists(d))
                        File.Delete(d); //直接刪除其中的文件                        
                    else
                        DeleteFolder(d); //遞歸刪除子文件夾 
                }
                Directory.Delete(dir, true); //刪除已空文件夾                 
            }
        }

        #endregion

        #region 將指定文件夾下面的所有內容copy到目標文件夾下面 果目標文件夾為只讀屬性就會報錯。
        /****************************************
         * 函數名稱：CopyDir
         * 功能說明：將指定文件夾下面的所有內容copy到目標文件夾下面 果目標文件夾為只讀屬性就會報錯。
         * 參    數：srcPath:原始路徑,aimPath:目標文件夾
         * 調用示列：
         *           string srcPath = Server.MapPath("test/");  
         *           string aimPath = Server.MapPath("test1/");
         *           DotNet.Utilities.FileOperate.CopyDir(srcPath,aimPath);   
        *****************************************/
        /// <summary>
        /// 指定文件夾下面的所有內容copy到目標文件夾下面
        /// </summary>
        /// <param name="srcPath">原始路徑</param>
        /// <param name="aimPath">目標文件夾</param>
        public static void CopyDir(string srcPath, string aimPath)
        {
            try
            {
                // 檢查目標目錄是否以目錄分割字符結束如果不是則添加之
                if (aimPath[aimPath.Length - 1] != Path.DirectorySeparatorChar)
                    aimPath += Path.DirectorySeparatorChar;
                // 判斷目標目錄是否存在如果不存在則新建之
                if (!Directory.Exists(aimPath))
                    Directory.CreateDirectory(aimPath);
                // 得到源目錄的文件列表，該裡面是包含文件以及目錄路徑的一個數組
                //如果你指向copy目標文件下面的文件而不包含目錄請使用下面的方法
                //string[] fileList = Directory.GetFiles(srcPath);
                string[] fileList = Directory.GetFileSystemEntries(srcPath);
                //遍歷所有的文件和目錄
                foreach (string file in fileList)
                {
                    //先當作目錄處理如果存在這個目錄就遞歸Copy該目錄下面的文件

                    if (Directory.Exists(file))
                        CopyDir(file, aimPath + Path.GetFileName(file));
                    //否則直接Copy文件
                    else
                        File.Copy(file, aimPath + Path.GetFileName(file), true);
                }
            }
            catch (Exception ee)
            {
                throw new Exception(ee.ToString());
            }
        }
        #endregion

        #region 獲取指定文件夾下所有子目錄及文件(樹形)
        /****************************************
         * 函數名稱：GetFoldAll(string Path)
         * 功能說明：獲取指定文件夾下所有子目錄及文件(樹形)
         * 參    數：Path:詳細路徑
         * 調用示列：
         *           string strDirlist = Server.MapPath("templates");       
         *           this.Literal1.Text = DotNet.Utilities.FileOperate.GetFoldAll(strDirlist);  
        *****************************************/
        /// <summary>
        /// 獲取指定文件夾下所有子目錄及文件
        /// </summary>
        /// <param name="Path">詳細路徑</param>
        public static string GetFoldAll(string Path)
        {

            string str = "";
            DirectoryInfo thisOne = new DirectoryInfo(Path);
            str = ListTreeShow(thisOne, 0, str);
            return str;

        }

        /// <summary>
        /// 獲取指定文件夾下所有子目錄及文件函數
        /// </summary>
        /// <param name="theDir">指定目錄</param>
        /// <param name="nLevel">默認起始值,調用時,一般為0</param>
        /// <param name="Rn">用於迭加的傳入值,一般為空</param>
        /// <returns></returns>
        public static string ListTreeShow(DirectoryInfo theDir, int nLevel, string Rn)//遞歸目錄 文件
        {
            DirectoryInfo[] subDirectories = theDir.GetDirectories();//獲得目錄
            foreach (DirectoryInfo dirinfo in subDirectories)
            {

                if (nLevel == 0)
                {
                    Rn += "├";
                }
                else
                {
                    string _s = "";
                    for (int i = 1; i <= nLevel; i++)
                    {
                        _s += "│&nbsp;";
                    }
                    Rn += _s + "├";
                }
                Rn += "<b>" + dirinfo.Name.ToString() + "</b><br />";
                FileInfo[] fileInfo = dirinfo.GetFiles();   //目錄下的文件
                foreach (FileInfo fInfo in fileInfo)
                {
                    if (nLevel == 0)
                    {
                        Rn += "│&nbsp;├";
                    }
                    else
                    {
                        string _f = "";
                        for (int i = 1; i <= nLevel; i++)
                        {
                            _f += "│&nbsp;";
                        }
                        Rn += _f + "│&nbsp;├";
                    }
                    Rn += fInfo.Name.ToString() + " <br />";
                }
                Rn = ListTreeShow(dirinfo, nLevel + 1, Rn);


            }
            return Rn;
        }



        /****************************************
         * 函數名稱：GetFoldAll(string Path)
         * 功能說明：獲取指定文件夾下所有子目錄及文件(下拉框形)
         * 參    數：Path:詳細路徑
         * 調用示列：
         *            string strDirlist = Server.MapPath("templates");      
         *            this.Literal2.Text = DotNet.Utilities.FileOperate.GetFoldAll(strDirlist,"tpl","");
        *****************************************/
        /// <summary>
        /// 獲取指定文件夾下所有子目錄及文件(下拉框形)
        /// </summary>
        /// <param name="Path">詳細路徑</param>
        ///<param name="DropName">下拉列表名稱</param>
        ///<param name="tplPath">默認選擇模板名稱</param>
        public static string GetFoldAll(string Path, string DropName, string tplPath)
        {
            string strDrop = "<select name=\"" + DropName + "\" id=\"" + DropName + "\"><option value=\"\">--請選擇詳細模板--</option>";
            string str = "";
            DirectoryInfo thisOne = new DirectoryInfo(Path);
            str = ListTreeShow(thisOne, 0, str, tplPath);
            return strDrop + str + "</select>";

        }

        /// <summary>
        /// 獲取指定文件夾下所有子目錄及文件函數
        /// </summary>
        /// <param name="theDir">指定目錄</param>
        /// <param name="nLevel">默認起始值,調用時,一般為0</param>
        /// <param name="Rn">用於迭加的傳入值,一般為空</param>
        /// <param name="tplPath">默認選擇模板名稱</param>
        /// <returns></returns>
        public static string ListTreeShow(DirectoryInfo theDir, int nLevel, string Rn, string tplPath)//遞歸目錄 文件
        {
            DirectoryInfo[] subDirectories = theDir.GetDirectories();//獲得目錄

            foreach (DirectoryInfo dirinfo in subDirectories)
            {

                Rn += "<option value=\"" + dirinfo.Name.ToString() + "\"";
                if (tplPath.ToLower() == dirinfo.Name.ToString().ToLower())
                {
                    Rn += " selected ";
                }
                Rn += ">";

                if (nLevel == 0)
                {
                    Rn += "├";
                }
                else
                {
                    string _s = "";
                    for (int i = 1; i <= nLevel; i++)
                    {
                        _s += "│&nbsp;";
                    }
                    Rn += _s + "├";
                }
                Rn += "" + dirinfo.Name.ToString() + "</option>";


                FileInfo[] fileInfo = dirinfo.GetFiles();   //目錄下的文件
                foreach (FileInfo fInfo in fileInfo)
                {
                    Rn += "<option value=\"" + dirinfo.Name.ToString() + "/" + fInfo.Name.ToString() + "\"";
                    if (tplPath.ToLower() == fInfo.Name.ToString().ToLower())
                    {
                        Rn += " selected ";
                    }
                    Rn += ">";

                    if (nLevel == 0)
                    {
                        Rn += "│&nbsp;├";
                    }
                    else
                    {
                        string _f = "";
                        for (int i = 1; i <= nLevel; i++)
                        {
                            _f += "│&nbsp;";
                        }
                        Rn += _f + "│&nbsp;├";
                    }
                    Rn += fInfo.Name.ToString() + "</option>";
                }
                Rn = ListTreeShow(dirinfo, nLevel + 1, Rn, tplPath);


            }
            return Rn;
        }
        #endregion

        #region 獲取文件夾大小
        /****************************************
         * 函數名稱：GetDirectoryLength(string dirPath)
         * 功能說明：獲取文件夾大小
         * 參    數：dirPath:文件夾詳細路徑
         * 調用示列：
         *           string Path = Server.MapPath("templates"); 
         *           Response.Write(DotNet.Utilities.FileOperate.GetDirectoryLength(Path));       
        *****************************************/
        /// <summary>
        /// 獲取文件夾大小
        /// </summary>
        /// <param name="dirPath">文件夾路徑</param>
        /// <returns></returns>
        public static long GetDirectoryLength(string dirPath)
        {
            if (!Directory.Exists(dirPath))
                return 0;
            long len = 0;
            DirectoryInfo di = new DirectoryInfo(dirPath);
            foreach (FileInfo fi in di.GetFiles())
            {
                len += fi.Length;
            }
            DirectoryInfo[] dis = di.GetDirectories();
            if (dis.Length > 0)
            {
                for (int i = 0; i < dis.Length; i++)
                {
                    len += GetDirectoryLength(dis[i].FullName);
                }
            }
            return len;
        }
        #endregion

        #region 獲取指定文件詳細屬性
        /****************************************
         * 函數名稱：GetFileAttibe(string filePath)
         * 功能說明：獲取指定文件詳細屬性
         * 參    數：filePath:文件詳細路徑
         * 調用示列：
         *           string file = Server.MapPath("robots.txt");  
         *            Response.Write(DotNet.Utilities.FileOperate.GetFileAttibe(file));         
        *****************************************/
        /// <summary>
        /// 獲取指定文件詳細屬性
        /// </summary>
        /// <param name="filePath">文件詳細路徑</param>
        /// <returns></returns>
        public static string GetFileAttibe(string filePath)
        {
            string str = "";
            System.IO.FileInfo objFI = new System.IO.FileInfo(filePath);
            str += "詳細路徑:" + objFI.FullName + "<br>文件名稱:" + objFI.Name + "<br>文件長度:" + objFI.Length.ToString() + "字節<br>創建時間" + objFI.CreationTime.ToString() + "<br>最後訪問時間:" + objFI.LastAccessTime.ToString() + "<br>修改時間:" + objFI.LastWriteTime.ToString() + "<br>所在目錄:" + objFI.DirectoryName + "<br>擴展名:" + objFI.Extension;
            return str;
        }
        #endregion

        #region 判断是否IMG文件
        /// <summary>
        /// 判断是否IMG文件 bmp/JPEG/GIF/PNG 按前几个字节比较
        /// </summary>
        /// <param name="filename">string扩展</param>
        /// <returns></returns>
        public static bool IsImgFile(string filename)
        {
            if (!File.Exists(filename)) return false;

            ushort code = BitConverter.ToUInt16(File.ReadAllBytes(filename), 0);
            switch (code)
            {
                case 0x4D42://bmp
                    return true;
                case 0xD8FF://JPEG 
                    return true;
                case 0x4947://GIF 
                    return true;
                case 0x5089://PNG 
                    return true;
                default:
                    return false;
            }
        }
        #endregion
    }
}
