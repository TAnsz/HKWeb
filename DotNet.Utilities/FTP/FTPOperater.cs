/// <summary>
/// 類說明：CacheHelper
/// 聯繫方式：361983679  
/// 更新網站：http://www.sufeinet.com/thread-655-1-1.html
/// </summary>
using System;
using System.Text;
using System.IO;

namespace DotNet.Utilities
{
    /// <summary>
    /// FTP操作類
    /// </summary>
    public class FTPOperater
    {
        #region 屬性
        private FTPClient ftp;
        /// <summary>
        /// 全局FTP訪問變量
        /// </summary>
        public FTPClient Ftp
        {
            get { return ftp; }
            set { ftp = value; }
        }

        private string _server;
        /// <summary>
        /// Ftp服務器
        /// </summary>
        public string Server
        {
            get { return _server; }
            set { _server = value; }
        }

        private string _User;
        /// <summary>
        /// Ftp用戶
        /// </summary>
        public string User
        {
            get { return _User; }
            set { _User = value; }
        }

        private string _Pass;
        /// <summary>
        /// Ftp密碼
        /// </summary>
        public string Pass
        {
            get { return _Pass; }
            set { _Pass = value; }
        }

        private string _FolderZJ;
        /// <summary>
        /// Ftp密碼
        /// </summary>
        public string FolderZJ
        {
            get { return _FolderZJ; }
            set { _FolderZJ = value; }
        }

        private string _FolderWX;
        /// <summary>
        /// Ftp密碼
        /// </summary>
        public string FolderWX
        {
            get { return _FolderWX; }
            set { _FolderWX = value; }
        }
        #endregion

        /// <summary>
        /// 得到文件列表
        /// </summary>
        /// <returns></returns>
        public string[] GetList(string strPath)
        {
            if (ftp == null) ftp = this.getFtpClient();
            ftp.Connect();
            ftp.ChDir(strPath);
            return ftp.Dir("*");
        }

        /// <summary>
        /// 下載文件
        /// </summary>
        /// <param name="ftpFolder">ftp目錄</param>
        /// <param name="ftpFileName">ftp文件名</param>
        /// <param name="localFolder">本地目錄</param>
        /// <param name="localFileName">本地文件名</param>
        public bool GetFile(string ftpFolder, string ftpFileName, string localFolder, string localFileName)
        {
            try
            {
                if (ftp == null) ftp = this.getFtpClient();
                if (!ftp.Connected)
                {
                    ftp.Connect();
                    ftp.ChDir(ftpFolder);
                }
                ftp.Get(ftpFileName, localFolder, localFileName);

                return true;
            }
            catch
            {
                try
                {
                    ftp.DisConnect();
                    ftp = null;
                }
                catch { ftp = null; }
                return false;
            }
        }

        /// <summary>
        /// 修改文件
        /// </summary>
        /// <param name="ftpFolder">本地目錄</param>
        /// <param name="ftpFileName">本地文件名temp</param>
        /// <param name="localFolder">本地目錄</param>
        /// <param name="localFileName">本地文件名</param>
        public bool AddMSCFile(string ftpFolder, string ftpFileName, string localFolder, string localFileName, string BscInfo)
        {
            string sLine = "";
            string sResult = "";
            string path = "獲得應用程序所在的完整的路徑";
            path = path.Substring(0, path.LastIndexOf("\\"));
            try
            {
                FileStream fsFile = new FileStream(ftpFolder + "\\" + ftpFileName, FileMode.Open);
                FileStream fsFileWrite = new FileStream(localFolder + "\\" + localFileName, FileMode.Create);
                StreamReader sr = new StreamReader(fsFile);
                StreamWriter sw = new StreamWriter(fsFileWrite);
                sr.BaseStream.Seek(0, SeekOrigin.Begin);
                while (sr.Peek() > -1)
                {
                    sLine = sr.ReadToEnd();
                }
                string[] arStr = sLine.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < arStr.Length - 1; i++)
                {
                    sResult += BscInfo + "," + arStr[i].Trim() + "\n";
                }
                sr.Close();
                byte[] connect = new UTF8Encoding(true).GetBytes(sResult);
                fsFileWrite.Write(connect, 0, connect.Length);
                fsFileWrite.Flush();
                sw.Close();
                fsFile.Close();
                fsFileWrite.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// 刪除文件
        /// </summary>
        /// <param name="ftpFolder">ftp目錄</param>
        /// <param name="ftpFileName">ftp文件名</param>
        public bool DelFile(string ftpFolder, string ftpFileName)
        {
            try
            {
                if (ftp == null) ftp = this.getFtpClient();
                if (!ftp.Connected)
                {
                    ftp.Connect();
                    ftp.ChDir(ftpFolder);
                }
                ftp.Delete(ftpFileName);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 上傳文件
        /// </summary>
        /// <param name="ftpFolder">ftp目錄</param>
        /// <param name="ftpFileName">ftp文件名</param>
        public bool PutFile(string ftpFolder, string ftpFileName)
        {
            try
            {
                if (ftp == null) ftp = this.getFtpClient();
                if (!ftp.Connected)
                {
                    ftp.Connect();
                    ftp.ChDir(ftpFolder);
                }
                ftp.Put(ftpFileName);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 下載文件
        /// </summary>
        /// <param name="ftpFolder">ftp目錄</param>
        /// <param name="ftpFileName">ftp文件名</param>
        /// <param name="localFolder">本地目錄</param>
        /// <param name="localFileName">本地文件名</param>
        public bool GetFileNoBinary(string ftpFolder, string ftpFileName, string localFolder, string localFileName)
        {
            try
            {
                if (ftp == null) ftp = this.getFtpClient();
                if (!ftp.Connected)
                {
                    ftp.Connect();
                    ftp.ChDir(ftpFolder);
                }
                ftp.GetNoBinary(ftpFileName, localFolder, localFileName);
                return true;
            }
            catch
            {
                try
                {
                    ftp.DisConnect();
                    ftp = null;
                }
                catch
                {
                    ftp = null;
                }
                return false;
            }
        }

        /// <summary>
        /// 得到FTP上文件信息
        /// </summary>
        /// <param name="ftpFolder">FTP目錄</param>
        /// <param name="ftpFileName">ftp文件名</param>
        public string GetFileInfo(string ftpFolder, string ftpFileName)
        {
            string strResult = "";
            try
            {
                if (ftp == null) ftp = this.getFtpClient();
                if (ftp.Connected) ftp.DisConnect();
                ftp.Connect();
                ftp.ChDir(ftpFolder);
                strResult = ftp.GetFileInfo(ftpFileName);
                return strResult;
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// 測試FTP服務器是否可登陸
        /// </summary>
        public bool CanConnect()
        {
            if (ftp == null) ftp = this.getFtpClient();
            try
            {
                ftp.Connect();
                ftp.DisConnect();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 得到FTP上文件信息
        /// </summary>
        /// <param name="ftpFolder">FTP目錄</param>
        /// <param name="ftpFileName">ftp文件名</param>
        public string GetFileInfoConnected(string ftpFolder, string ftpFileName)
        {
            string strResult = "";
            try
            {
                if (ftp == null) ftp = this.getFtpClient();
                if (!ftp.Connected)
                {
                    ftp.Connect();
                    ftp.ChDir(ftpFolder);
                }
                strResult = ftp.GetFileInfo(ftpFileName);
                return strResult;
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// 得到文件列表
        /// </summary>
        /// <param name="ftpFolder">FTP目錄</param>
        /// <returns>FTP通配符號</returns>
        public string[] GetFileList(string ftpFolder, string strMask)
        {
            string[] strResult;
            try
            {
                if (ftp == null) ftp = this.getFtpClient();
                if (!ftp.Connected)
                {
                    ftp.Connect();
                    ftp.ChDir(ftpFolder);
                }
                strResult = ftp.Dir(strMask);
                return strResult;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        ///得到FTP傳輸對像
        /// </summary>
        public FTPClient getFtpClient()
        {
            FTPClient ft = new FTPClient();
            ft.RemoteHost = this.Server;
            ft.RemoteUser = this.User;
            ft.RemotePass = this.Pass;
            return ft;
        }
    }
}