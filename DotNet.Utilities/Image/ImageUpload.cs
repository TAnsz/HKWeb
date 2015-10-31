/// <summary>
/// 類說明：Assistant
/// 編 碼 人：蘇飛
/// 聯繫方式：361983679  
/// 更新網站：http://www.sufeinet.com/thread-655-1-1.html
/// </summary>
using System;
using System.IO;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Drawing;

namespace DotNet.Utilities
{
    /// <summary>
    /// 文件類型
    /// </summary>
    public enum FileExtension
    {
        JPG = 255216,
        GIF = 7173,
        BMP = 6677,
        PNG = 13780,
        RAR = 8297,
        jpg = 255216,
        exe = 7790,
        xml = 6063,
        html = 6033,
        aspx = 239187,
        cs = 117115,
        js = 119105,
        txt = 210187,
        sql = 255254
    }

    /// <summary>
    /// 圖片檢測類
    /// </summary>
    public static class FileValidation
    {
        #region 上傳圖片檢測類
        /// <summary>
        /// 是否允許
        /// </summary>
        public static bool IsAllowedExtension(HttpPostedFile oFile, FileExtension[] fileEx)
        {
            int fileLen = oFile.ContentLength;
            byte[] imgArray = new byte[fileLen];
            oFile.InputStream.Read(imgArray, 0, fileLen);
            MemoryStream ms = new MemoryStream(imgArray);
            System.IO.BinaryReader br = new System.IO.BinaryReader(ms);
            string fileclass = "";
            byte buffer;
            try
            {
                buffer = br.ReadByte();
                fileclass = buffer.ToString();
                buffer = br.ReadByte();
                fileclass += buffer.ToString();
            }
            catch { }
            br.Close();
            ms.Close();
            foreach (FileExtension fe in fileEx)
            {
                if (Int32.Parse(fileclass) == (int)fe) return true;
            }
            return false;
        }

        /// <summary>
        /// 上傳前的圖片是否可靠
        /// </summary>
        public static bool IsSecureUploadPhoto(HttpPostedFile oFile)
        {
            bool isPhoto = false;
            string fileExtension = System.IO.Path.GetExtension(oFile.FileName).ToLower();
            string[] allowedExtensions = { ".gif", ".png", ".jpeg", ".jpg", ".bmp" };
            for (int i = 0; i < allowedExtensions.Length; i++)
            {
                if (fileExtension == allowedExtensions[i])
                {
                    isPhoto = true;
                    break;
                }
            }
            if (!isPhoto)
            {
                return true;
            }
            FileExtension[] fe = { FileExtension.BMP, FileExtension.GIF, FileExtension.JPG, FileExtension.PNG };

            if (IsAllowedExtension(oFile, fe))
                return true;
            else
                return false;
        }

        /// <summary>
        /// 上傳後的圖片是否安全
        /// </summary>
        /// <param name="photoFile">物理地址</param>
        public static bool IsSecureUpfilePhoto(string photoFile)
        {
            bool isPhoto = false;
            string Img = "Yes";
            string fileExtension = System.IO.Path.GetExtension(photoFile).ToLower();
            string[] allowedExtensions = { ".gif", ".png", ".jpeg", ".jpg", ".bmp" };
            for (int i = 0; i < allowedExtensions.Length; i++)
            {
                if (fileExtension == allowedExtensions[i])
                {
                    isPhoto = true;
                    break;
                }
            }

            if (!isPhoto)
            {
                return true;
            }
            StreamReader sr = new StreamReader(photoFile, System.Text.Encoding.Default);
            string strContent = sr.ReadToEnd();
            sr.Close();
            string str = "request|<script|.getfolder|.createfolder|.deletefolder|.createdirectory|.deletedirectory|.saveas|wscript.shell|script.encode|server.|.createobject|execute|activexobject|language=";
            foreach (string s in str.Split('|'))
            {
                if (strContent.ToLower().IndexOf(s) != -1)
                {
                    File.Delete(photoFile);
                    Img = "No";
                    break;
                }
            }
            return (Img == "Yes");
        }
        #endregion
    }

    /// <summary>
    /// 圖片上傳類
    /// </summary>
    //----------------調用-------------------
    //imageUpload iu = new imageUpload();
    //iu.AddText = "";
    //iu.CopyIamgePath = "";
    //iu.DrawString_x = ;
    //iu.DrawString_y = ;
    //iu.DrawStyle = ;
    //iu.Font = "";
    //iu.FontSize = ;
    //iu.FormFile = File1;
    //iu.IsCreateImg =;
    //iu.IsDraw = ;
    //iu.OutFileName = "";
    //iu.OutThumbFileName = "";
    //iu.SavePath = @"~/image/";
    //iu.SaveType = ;
    //iu.sHeight  = ;
    //iu.sWidth   = ;
    //iu.Upload();
    //--------------------------------------
    public class ImageUpload
    {
        #region 私有成員
        private int _Error = 0;//返回上傳狀態。 
        private int _MaxSize = 1024 * 1024;//最大單個上傳文件 (默認)
        private string _FileType = "jpg;gif;bmp;png";//所支持的上傳類型用"/"隔開 
        private string _SavePath = System.Web.HttpContext.Current.Server.MapPath(".") + "\\";//保存文件的實際路徑 
        private int _SaveType = 0;//上傳文件的類型，0代表自動生成文件名 
        private HtmlInputFile _FormFile;//上傳控件。 
        private string _InFileName = "";//非自動生成文件名設置。 
        private string _OutFileName = "";//輸出文件名。 
        private bool _IsCreateImg = true;//是否生成縮略圖。 
        private bool _Iss = false;//是否有縮略圖生成.
        private int _Height = 0;//獲取上傳圖片的高度 
        private int _Width = 0;//獲取上傳圖片的寬度 
        private int _sHeight = 120;//設置生成縮略圖的高度 
        private int _sWidth = 120;//設置生成縮略圖的寬度
        private bool _IsDraw = false;//設置是否加水印
        private int _DrawStyle = 0;//設置加水印的方式０：文字水印模式，１：圖片水印模式,2:不加
        private int _DrawString_x = 10;//繪製文本的Ｘ坐標（左上角）
        private int _DrawString_y = 10;//繪製文本的Ｙ坐標（左上角）
        private string _AddText = "GlobalNatureCrafts";//設置水印內容
        private string _Font = "細明體";//設置水印字體
        private int _FontSize = 12;//設置水印字大小
        private int _FileSize = 0;//獲取已經上傳文件的大小
        private string _CopyIamgePath = System.Web.HttpContext.Current.Server.MapPath(".") + "/images/5dm_new.jpg";//圖片水印模式下的覆蓋圖片的實際地址
        #endregion

        #region 公有屬性
        /// <summary>
        /// Error返回值
        /// 1、沒有上傳的文件
        /// 2、類型不允許
        /// 3、大小超限
        /// 4、未知錯誤
        /// 0、上傳成功。 
        /// </summary>
        public int Error
        {
            get { return _Error; }
        }

        /// <summary>
        /// 最大單個上傳文件
        /// </summary>
        public int MaxSize
        {
            set { _MaxSize = value; }
        }

        /// <summary>
        /// 所支持的上傳類型用";"隔開 
        /// </summary>
        public string FileType
        {
            set { _FileType = value; }
        }

        /// <summary>
        /// 保存文件的實際路徑 
        /// </summary>
        public string SavePath
        {
            set { _SavePath = System.Web.HttpContext.Current.Server.MapPath(value); }
            get { return _SavePath; }
        }

        /// <summary>
        /// 上傳文件的類型，0代表自動生成文件名
        /// </summary>
        public int SaveType
        {
            set { _SaveType = value; }
        }

        /// <summary>
        /// 上傳控件
        /// </summary>
        public HtmlInputFile FormFile
        {
            set { _FormFile = value; }
        }

        /// <summary>
        /// 非自動生成文件名設置。
        /// </summary>
        public string InFileName
        {
            set { _InFileName = value; }
        }

        /// <summary>
        /// 輸出文件名
        /// </summary>
        public string OutFileName
        {
            get { return _OutFileName; }
            set { _OutFileName = value; }
        }

        /// <summary>
        /// 輸出的縮略圖文件名
        /// </summary>
        public string OutThumbFileName
        {
            get;
            set;
        }

        /// <summary>
        /// 是否有縮略圖生成.
        /// </summary>
        public bool Iss
        {
            get { return _Iss; }
        }

        /// <summary>
        /// 獲取上傳圖片的寬度
        /// </summary>
        public int Width
        {
            get { return _Width; }
        }

        /// <summary>
        /// 獲取上傳圖片的高度
        /// </summary>
        public int Height
        {
            get { return _Height; }
        }

        /// <summary>
        /// 設置縮略圖的寬度
        /// </summary>
        public int sWidth
        {
            get { return _sWidth; }
            set { _sWidth = value; }
        }

        /// <summary>
        /// 設置縮略圖的高度
        /// </summary>
        public int sHeight
        {
            get { return _sHeight; }
            set { _sHeight = value; }
        }

        /// <summary>
        /// 是否生成縮略圖
        /// </summary>
        public bool IsCreateImg
        {
            get { return _IsCreateImg; }
            set { _IsCreateImg = value; }
        }

        /// <summary>
        /// 是否加水印
        /// </summary>
        public bool IsDraw
        {
            get { return _IsDraw; }
            set { _IsDraw = value; }
        }

        /// <summary>
        /// 設置加水印的方式
        /// 0:文字水印模式
        /// 1:圖片水印模式
        /// 2:不加
        /// </summary>
        public int DrawStyle
        {
            get { return _DrawStyle; }
            set { _DrawStyle = value; }
        }

        /// <summary>
        /// 繪製文本的Ｘ坐標（左上角）
        /// </summary>
        public int DrawString_x
        {
            get { return _DrawString_x; }
            set { _DrawString_x = value; }
        }

        /// <summary>
        /// 繪製文本的Ｙ坐標（左上角）
        /// </summary>
        public int DrawString_y
        {
            get { return _DrawString_y; }
            set { _DrawString_y = value; }
        }

        /// <summary>
        /// 設置文字水印內容
        /// </summary>
        public string AddText
        {
            get { return _AddText; }
            set { _AddText = value; }
        }

        /// <summary>
        /// 設置文字水印字體
        /// </summary>
        public string Font
        {
            get { return _Font; }
            set { _Font = value; }
        }

        /// <summary>
        /// 設置文字水印字的大小
        /// </summary>
        public int FontSize
        {
            get { return _FontSize; }
            set { _FontSize = value; }
        }

        /// <summary>
        /// 文件大小
        /// </summary>
        public int FileSize
        {
            get { return _FileSize; }
            set { _FileSize = value; }
        }

        /// <summary>
        /// 圖片水印模式下的覆蓋圖片的實際地址
        /// </summary>
        public string CopyIamgePath
        {
            set { _CopyIamgePath = System.Web.HttpContext.Current.Server.MapPath(value); }
        }

        #endregion

        #region 私有方法
        /// <summary>
        /// 獲取文件的後綴名 
        /// </summary>
        private string GetExt(string path)
        {
            return Path.GetExtension(path);
        }

        /// <summary>
        /// 獲取輸出文件的文件名
        /// </summary>
        private string FileName(string Ext)
        {
            if (_SaveType == 0 || _InFileName.Trim() == "")
                return DateTime.Now.ToString("yyyyMMddHHmmssfff") + Ext;
            else
                return _InFileName;
        }

        /// <summary>
        /// 檢查上傳的文件的類型，是否允許上傳。
        /// </summary>
        private bool IsUpload(string Ext)
        {
            Ext = Ext.Replace(".", "");
            bool b = false;
            string[] arrFileType = _FileType.Split(';');
            foreach (string str in arrFileType)
            {
                if (str.ToLower() == Ext.ToLower())
                {
                    b = true;
                    break;
                }
            }
            return b;
        }
        #endregion

        #region 上傳圖片
        public void Upload()
        {
            HttpPostedFile hpFile = _FormFile.PostedFile;
            if (hpFile == null || hpFile.FileName.Trim() == "")
            {
                _Error = 1;
                return;
            }
            string Ext = GetExt(hpFile.FileName);
            if (!IsUpload(Ext))
            {
                _Error = 2;
                return;
            }
            int iLen = hpFile.ContentLength;
            if (iLen > _MaxSize)
            {
                _Error = 3;
                return;
            }
            try
            {
                if (!Directory.Exists(_SavePath)) Directory.CreateDirectory(_SavePath);
                byte[] bData = new byte[iLen];
                hpFile.InputStream.Read(bData, 0, iLen);
                string FName;
                FName = FileName(Ext);
                string TempFile = "";
                if (_IsDraw)
                {
                    TempFile = FName.Split('.').GetValue(0).ToString() + "_temp." + FName.Split('.').GetValue(1).ToString();
                }
                else
                {
                    TempFile = FName;
                }
                FileStream newFile = new FileStream(_SavePath + TempFile, FileMode.Create);
                newFile.Write(bData, 0, bData.Length);
                newFile.Flush();
                int _FileSizeTemp = hpFile.ContentLength;

                string ImageFilePath = _SavePath + FName;
                if (_IsDraw)
                {
                    if (_DrawStyle == 0)
                    {
                        System.Drawing.Image Img1 = System.Drawing.Image.FromStream(newFile);
                        Graphics g = Graphics.FromImage(Img1);
                        g.DrawImage(Img1, 100, 100, Img1.Width, Img1.Height);
                        Font f = new Font(_Font, _FontSize);
                        Brush b = new SolidBrush(Color.Red);
                        string addtext = _AddText;
                        g.DrawString(addtext, f, b, _DrawString_x, _DrawString_y);
                        g.Dispose();
                        Img1.Save(ImageFilePath);
                        Img1.Dispose();
                    }
                    else
                    {
                        System.Drawing.Image image = System.Drawing.Image.FromStream(newFile);
                        System.Drawing.Image copyImage = System.Drawing.Image.FromFile(_CopyIamgePath);
                        Graphics g = Graphics.FromImage(image);
                        g.DrawImage(copyImage, new Rectangle(image.Width - copyImage.Width - 5, image.Height - copyImage.Height - 5, copyImage.Width, copyImage.Height), 0, 0, copyImage.Width, copyImage.Height, GraphicsUnit.Pixel);
                        g.Dispose();
                        image.Save(ImageFilePath);
                        image.Dispose();
                    }
                }

                //獲取圖片的高度和寬度
                System.Drawing.Image Img = System.Drawing.Image.FromStream(newFile);
                _Width = Img.Width;
                _Height = Img.Height;

                //生成縮略圖部分 
                if (_IsCreateImg)
                {
                    #region 縮略圖大小只設置了最大範圍，並不是實際大小
                    float realbili = (float)_Width / (float)_Height;
                    float wishbili = (float)_sWidth / (float)_sHeight;

                    //實際圖比縮略圖最大尺寸更寬矮，以寬為準
                    if (realbili > wishbili)
                    {
                        _sHeight = (int)((float)_sWidth / realbili);
                    }
                    //實際圖比縮略圖最大尺寸更高長，以高為準
                    else
                    {
                        _sWidth = (int)((float)_sHeight * realbili);
                    }
                    #endregion

                    this.OutThumbFileName = FName.Split('.').GetValue(0).ToString() + "_s." + FName.Split('.').GetValue(1).ToString();
                    string ImgFilePath = _SavePath + this.OutThumbFileName;

                    System.Drawing.Image newImg = Img.GetThumbnailImage(_sWidth, _sHeight, null, System.IntPtr.Zero);
                    newImg.Save(ImgFilePath);
                    newImg.Dispose();
                    _Iss = true;
                }

                if (_IsDraw)
                {
                    if (File.Exists(_SavePath + FName.Split('.').GetValue(0).ToString() + "_temp." + FName.Split('.').GetValue(1).ToString()))
                    {
                        newFile.Dispose();
                        File.Delete(_SavePath + FName.Split('.').GetValue(0).ToString() + "_temp." + FName.Split('.').GetValue(1).ToString());
                    }
                }
                newFile.Close();
                newFile.Dispose();
                _OutFileName = FName;
                _FileSize = _FileSizeTemp;
                _Error = 0;
                return;
            }
            catch (Exception ex)
            {
                _Error = 4;
                return;
            }
        }
        #endregion
    }
}