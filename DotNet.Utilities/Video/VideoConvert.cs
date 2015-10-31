/// <summary>
/// �s �X �H�GĬ��
/// �pô�覡�G361983679  
/// ��s�����Ghttp://www.sufeinet.com/thread-655-1-1.html
/// </summary>
using System.Web;
using System.Configuration;

namespace DotNet.Utilities
{
    //if (this.fload.HasFile)
    //{
    //    string upFileName = HttpContext.Current.Server.MapPath("~/savefile") + "\\" + this.fload.PostedFile.FileName;
    //    string saveName   = DateTime.Now.ToString("yyyyMMddHHmmssffff");
    //    string playFile   = Server.MapPath(VideoConvert.savefile + saveName);
    //    string imgFile    = Server.MapPath(VideoConvert.savefile + saveName);

    //    VideoConvert pm = new VideoConvert();
    //    string m_strExtension = VideoConvert.GetExtension(this.fload.PostedFile.FileName).ToLower();
    //    if (m_strExtension == "flv")
    //    {
    //        System.IO.File.Copy(upFileName, playFile + ".flv");
    //        pm.CatchImg(upFileName, imgFile);
    //    }
    //    string Extension = pm.CheckExtension(m_strExtension);
    //    if (Extension == "ffmpeg")
    //    {
    //        pm.ChangeFilePhy(upFileName, playFile, imgFile);
    //    }
    //    else if (Extension == "mencoder")
    //    {
    //        pm.MChangeFilePhy(upFileName, playFile, imgFile);
    //    }
    //}
    public class VideoConvert : System.Web.UI.Page
    {
        public VideoConvert()
        { }

        string[] strArrMencoder = new string[] { "wmv", "rmvb", "rm" };
        string[] strArrFfmpeg = new string[] { "asf", "avi", "mpg", "3gp", "mov" };

        #region �t�m
        public static string ffmpegtool = ConfigurationManager.AppSettings["ffmpeg"];
        public static string mencodertool = ConfigurationManager.AppSettings["mencoder"];
        public static string savefile = ConfigurationManager.AppSettings["savefile"] + "/";
        public static string sizeOfImg = ConfigurationManager.AppSettings["CatchFlvImgSize"];
        public static string widthOfFile = ConfigurationManager.AppSettings["widthSize"];
        public static string heightOfFile = ConfigurationManager.AppSettings["heightSize"];
        #endregion

        #region �����󪺦W�r
        /// <summary>
        /// �����󪺦W�r
        /// </summary>
        public static string GetFileName(string fileName)
        {
            int i = fileName.LastIndexOf("\\") + 1;
            string Name = fileName.Substring(i);
            return Name;
        }
        #endregion

        #region �������X�i�W
        /// <summary>
        /// �������X�i�W
        /// </summary>
        public static string GetExtension(string fileName)
        {
            int i = fileName.LastIndexOf(".") + 1;
            string Name = fileName.Substring(i);
            return Name;
        }
        #endregion

        #region ����������
        /// <summary>
        /// ����������
        /// </summary>
        public string CheckExtension(string extension)
        {
            string m_strReturn = "";
            foreach (string var in this.strArrFfmpeg)
            {
                if (var == extension)
                {
                    m_strReturn = "ffmpeg"; break;
                }
            }
            if (m_strReturn == "")
            {
                foreach (string var in strArrMencoder)
                {
                    if (var == extension)
                    {
                        m_strReturn = "mencoder"; break;
                    }
                }
            }
            return m_strReturn;
        }
        #endregion

        #region ���W�榡�ରFlv
        /// <summary>
        /// ���W�榡�ରFlv
        /// </summary>
        /// <param name="vFileName">����W���a�}</param>
        /// <param name="ExportName">�ͦ��᪺Flv���a�}</param>
        public bool ConvertFlv(string vFileName, string ExportName)
        {
            if ((!System.IO.File.Exists(ffmpegtool)) || (!System.IO.File.Exists(HttpContext.Current.Server.MapPath(vFileName))))
            {
                return false;
            }
            vFileName = HttpContext.Current.Server.MapPath(vFileName);
            ExportName = HttpContext.Current.Server.MapPath(ExportName);
            string Command = " -i \"" + vFileName + "\" -y -ab 32 -ar 22050 -b 800000 -s  480*360 \"" + ExportName + "\""; //Flv�榡     
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = ffmpegtool;
            p.StartInfo.Arguments = Command;
            p.StartInfo.WorkingDirectory = HttpContext.Current.Server.MapPath("~/tools/");
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = false;
            p.Start();
            p.BeginErrorReadLine();
            p.WaitForExit();
            p.Close();
            p.Dispose();
            return true;
        }
        #endregion

        #region �ͦ�Flv���W���Y����
        /// <summary>
        /// �ͦ�Flv���W���Y����
        /// </summary>
        /// <param name="vFileName">���W���a�}</param>
        public string CatchImg(string vFileName)
        {
            if ((!System.IO.File.Exists(ffmpegtool)) || (!System.IO.File.Exists(HttpContext.Current.Server.MapPath(vFileName)))) return "";
            try
            {
                string flv_img_p = vFileName.Substring(0, vFileName.Length - 4) + ".jpg";
                string Command = " -i " + HttpContext.Current.Server.MapPath(vFileName) + " -y -f image2 -t 0.1 -s " + sizeOfImg + " " + HttpContext.Current.Server.MapPath(flv_img_p);
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo.FileName = ffmpegtool;
                p.StartInfo.Arguments = Command;
                p.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                try
                {
                    p.Start();
                }
                catch
                {
                    return "";
                }
                finally
                {
                    p.Close();
                    p.Dispose();
                }
                System.Threading.Thread.Sleep(4000);

                //�`�N:�Ϥ��I�����\��,�ƾڥѤ��s�w�s�g��ϽL�ݭn�ɶ�����,�j���b3,4��Ʀܧ��;
                if (System.IO.File.Exists(HttpContext.Current.Server.MapPath(flv_img_p)))
                {
                    return flv_img_p;
                }
                return "";
            }
            catch
            {
                return "";
            }
        }
        #endregion

        #region �B��FFMpeg�����W�ѽX(������|)
        /// <summary>
        /// �ഫ���ëO�s�b���w��󧨤U
        /// </summary>
        /// <param name="fileName">�W�ǵ��W��󪺸��|�]����^</param>
        /// <param name="playFile">�ഫ�᪺��󪺸��|�]����������^</param>
        /// <param name="imgFile">�q���W��󤤧�����Ϥ����|</param>
        /// <returns>���\:��^�Ϥ������a�};����:��^�Ŧr�Ŧ�</returns>
        public string ChangeFilePhy(string fileName, string playFile, string imgFile)
        {
            string ffmpeg = Server.MapPath(VideoConvert.ffmpegtool);
            if ((!System.IO.File.Exists(ffmpeg)) || (!System.IO.File.Exists(fileName)))
            {
                return "";
            }
            string flv_file = System.IO.Path.ChangeExtension(playFile, ".flv");
            string FlvImgSize = VideoConvert.sizeOfImg;
            System.Diagnostics.ProcessStartInfo FilestartInfo = new System.Diagnostics.ProcessStartInfo(ffmpeg);
            FilestartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            FilestartInfo.Arguments = " -i " + fileName + " -ab 56 -ar 22050 -b 500 -r 15 -s " + widthOfFile + "x" + heightOfFile + " " + flv_file;
            try
            {
                System.Diagnostics.Process.Start(FilestartInfo);//�ഫ
                CatchImg(fileName, imgFile); //�I��
            }
            catch
            {
                return "";
            }
            return "";
        }

        public string CatchImg(string fileName, string imgFile)
        {
            string ffmpeg = Server.MapPath(VideoConvert.ffmpegtool);
            string flv_img = imgFile + ".jpg";
            string FlvImgSize = VideoConvert.sizeOfImg;
            System.Diagnostics.ProcessStartInfo ImgstartInfo = new System.Diagnostics.ProcessStartInfo(ffmpeg);
            ImgstartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            ImgstartInfo.Arguments = "   -i   " + fileName + "  -y  -f  image2   -ss 2 -vframes 1  -s   " + FlvImgSize + "   " + flv_img;
            try
            {
                System.Diagnostics.Process.Start(ImgstartInfo);
            }
            catch
            {
                return "";
            }
            if (System.IO.File.Exists(flv_img))
            {
                return flv_img;
            }
            return "";
        }
        #endregion

        #region �B��FFMpeg�����W�ѽX(�۹���|)
        /// <summary>
        /// �ഫ���ëO�s�b���w��󧨤U
        /// </summary>
        /// <param name="fileName">�W�ǵ��W��󪺸��|�]����^</param>
        /// <param name="playFile">�ഫ�᪺��󪺸��|�]����������^</param>
        /// <param name="imgFile">�q���W��󤤧�����Ϥ����|</param>
        /// <returns>���\:��^�Ϥ������a�};����:��^�Ŧr�Ŧ�</returns>
        public string ChangeFileVir(string fileName, string playFile, string imgFile)
        {
            string ffmpeg = Server.MapPath(VideoConvert.ffmpegtool);
            if ((!System.IO.File.Exists(ffmpeg)) || (!System.IO.File.Exists(fileName)))
            {
                return "";
            }
            string flv_img = System.IO.Path.ChangeExtension(Server.MapPath(imgFile), ".jpg");
            string flv_file = System.IO.Path.ChangeExtension(Server.MapPath(playFile), ".flv");
            string FlvImgSize = VideoConvert.sizeOfImg;

            System.Diagnostics.ProcessStartInfo ImgstartInfo = new System.Diagnostics.ProcessStartInfo(ffmpeg);
            ImgstartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            ImgstartInfo.Arguments = "   -i   " + fileName + "   -y   -f   image2   -t   0.001   -s   " + FlvImgSize + "   " + flv_img;

            System.Diagnostics.ProcessStartInfo FilestartInfo = new System.Diagnostics.ProcessStartInfo(ffmpeg);
            FilestartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            FilestartInfo.Arguments = " -i " + fileName + " -ab 56 -ar 22050 -b 500 -r 15 -s " + widthOfFile + "x" + heightOfFile + " " + flv_file;
            try
            {
                System.Diagnostics.Process.Start(FilestartInfo);
                System.Diagnostics.Process.Start(ImgstartInfo);
            }
            catch
            {
                return "";
            }

            ///�`�N:�Ϥ��I�����\��,�ƾڥѤ��s�w�s�g��ϽL�ݭn�ɶ�����,�j���b3,4��Ʀܧ��;   
            ///�o��ݭn���ɫ�A�˴�,�ڪA�Ⱦ�����8��,�Y�p�G�W�L8��Ϥ������s�b,�{���I�ϥ���;    
            if (System.IO.File.Exists(flv_img))
            {
                return flv_img;
            }
            return "";
        }
        #endregion

        #region �B��mencoder�����W�ѽX���ഫ(������|)
        /// <summary>
        /// �B��mencoder�����W�ѽX���ഫ
        /// </summary>
        public string MChangeFilePhy(string vFileName, string playFile, string imgFile)
        {
            string tool = Server.MapPath(VideoConvert.mencodertool);
            if ((!System.IO.File.Exists(tool)) || (!System.IO.File.Exists(vFileName)))
            {
                return "";
            }
            string flv_file = System.IO.Path.ChangeExtension(playFile, ".flv");
            string FlvImgSize = VideoConvert.sizeOfImg;
            System.Diagnostics.ProcessStartInfo FilestartInfo = new System.Diagnostics.ProcessStartInfo(tool);
            FilestartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            FilestartInfo.Arguments = " " + vFileName + " -o " + flv_file + " -of lavf -lavfopts i_certify_that_my_video_stream_does_not_use_b_frames -oac mp3lame -lameopts abr:br=56 -ovc lavc -lavcopts vcodec=flv:vbitrate=200:mbd=2:mv0:trell:v4mv:cbp:last_pred=1:dia=-1:cmp=0:vb_strategy=1 -vf scale=" + widthOfFile + ":" + heightOfFile + " -ofps 12 -srate 22050";
            try
            {
                System.Diagnostics.Process.Start(FilestartInfo);
                CatchImg(flv_file, imgFile);
            }
            catch
            {
                return "";
            }
            return "";
        }
        #endregion
    }
}