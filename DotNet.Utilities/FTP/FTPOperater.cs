/// <summary>
/// �������GCacheHelper
/// �pô�覡�G361983679  
/// ��s�����Ghttp://www.sufeinet.com/thread-655-1-1.html
/// </summary>
using System;
using System.Text;
using System.IO;

namespace DotNet.Utilities
{
    /// <summary>
    /// FTP�ާ@��
    /// </summary>
    public class FTPOperater
    {
        #region �ݩ�
        private FTPClient ftp;
        /// <summary>
        /// ����FTP�X���ܶq
        /// </summary>
        public FTPClient Ftp
        {
            get { return ftp; }
            set { ftp = value; }
        }

        private string _server;
        /// <summary>
        /// Ftp�A�Ⱦ�
        /// </summary>
        public string Server
        {
            get { return _server; }
            set { _server = value; }
        }

        private string _User;
        /// <summary>
        /// Ftp�Τ�
        /// </summary>
        public string User
        {
            get { return _User; }
            set { _User = value; }
        }

        private string _Pass;
        /// <summary>
        /// Ftp�K�X
        /// </summary>
        public string Pass
        {
            get { return _Pass; }
            set { _Pass = value; }
        }

        private string _FolderZJ;
        /// <summary>
        /// Ftp�K�X
        /// </summary>
        public string FolderZJ
        {
            get { return _FolderZJ; }
            set { _FolderZJ = value; }
        }

        private string _FolderWX;
        /// <summary>
        /// Ftp�K�X
        /// </summary>
        public string FolderWX
        {
            get { return _FolderWX; }
            set { _FolderWX = value; }
        }
        #endregion

        /// <summary>
        /// �o����C��
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
        /// �U�����
        /// </summary>
        /// <param name="ftpFolder">ftp�ؿ�</param>
        /// <param name="ftpFileName">ftp���W</param>
        /// <param name="localFolder">���a�ؿ�</param>
        /// <param name="localFileName">���a���W</param>
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
        /// �ק���
        /// </summary>
        /// <param name="ftpFolder">���a�ؿ�</param>
        /// <param name="ftpFileName">���a���Wtemp</param>
        /// <param name="localFolder">���a�ؿ�</param>
        /// <param name="localFileName">���a���W</param>
        public bool AddMSCFile(string ftpFolder, string ftpFileName, string localFolder, string localFileName, string BscInfo)
        {
            string sLine = "";
            string sResult = "";
            string path = "��o���ε{�ǩҦb�����㪺���|";
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
        /// �R�����
        /// </summary>
        /// <param name="ftpFolder">ftp�ؿ�</param>
        /// <param name="ftpFileName">ftp���W</param>
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
        /// �W�Ǥ��
        /// </summary>
        /// <param name="ftpFolder">ftp�ؿ�</param>
        /// <param name="ftpFileName">ftp���W</param>
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
        /// �U�����
        /// </summary>
        /// <param name="ftpFolder">ftp�ؿ�</param>
        /// <param name="ftpFileName">ftp���W</param>
        /// <param name="localFolder">���a�ؿ�</param>
        /// <param name="localFileName">���a���W</param>
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
        /// �o��FTP�W���H��
        /// </summary>
        /// <param name="ftpFolder">FTP�ؿ�</param>
        /// <param name="ftpFileName">ftp���W</param>
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
        /// ����FTP�A�Ⱦ��O�_�i�n��
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
        /// �o��FTP�W���H��
        /// </summary>
        /// <param name="ftpFolder">FTP�ؿ�</param>
        /// <param name="ftpFileName">ftp���W</param>
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
        /// �o����C��
        /// </summary>
        /// <param name="ftpFolder">FTP�ؿ�</param>
        /// <returns>FTP�q�t�Ÿ�</returns>
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
        ///�o��FTP�ǿ�ﹳ
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