/// <summary>
/// 類說明：Assistant
/// 編 碼 人：蘇飛
/// 聯繫方式：361983679  
/// 更新網站：http://www.sufeinet.com/thread-655-1-1.html
/// </summary>
using System;
using System.Media;

namespace DotNet.Utilities
{
    /// <summary>
    /// 處理多媒體的公共類
    /// </summary>
    public class MediaHandler
    {
        #region 同步播放wav文件
        /// <summary>
        /// 以同步方式播放wav文件
        /// </summary>
        /// <param name="sp">SoundPlayer對像</param>
        /// <param name="wavFilePath">wav文件的路徑</param>
        public static void SyncPlayWAV(SoundPlayer sp, string wavFilePath)
        {
            try
            {
                //設置wav文件的路徑 
                sp.SoundLocation = wavFilePath;

                //使用異步方式加載wav文件
                sp.LoadAsync();

                //使用同步方式播放wav文件
                if (sp.IsLoadCompleted)
                {
                    sp.PlaySync();
                }
            }
            catch (Exception ex)
            {
                string errStr = ex.Message;
                throw ex;
            }
        }

        /// <summary>
        /// 以同步方式播放wav文件
        /// </summary>
        /// <param name="wavFilePath">wav文件的路徑</param>
        public static void SyncPlayWAV(string wavFilePath)
        {
            try
            {
                //創建一個SoundPlaryer類，並設置wav文件的路徑
                SoundPlayer sp = new SoundPlayer(wavFilePath);

                //使用異步方式加載wav文件
                sp.LoadAsync();

                //使用同步方式播放wav文件
                if (sp.IsLoadCompleted)
                {
                    sp.PlaySync();
                }
            }
            catch (Exception ex)
            {
                string errStr = ex.Message;
                throw ex;
            }
        }
        #endregion

        #region 異步播放wav文件
        /// <summary>
        /// 以異步方式播放wav文件
        /// </summary>
        /// <param name="sp">SoundPlayer對像</param>
        /// <param name="wavFilePath">wav文件的路徑</param>
        public static void ASyncPlayWAV(SoundPlayer sp, string wavFilePath)
        {
            try
            {
                //設置wav文件的路徑 
                sp.SoundLocation = wavFilePath;

                //使用異步方式加載wav文件
                sp.LoadAsync();

                //使用異步方式播放wav文件
                if (sp.IsLoadCompleted)
                {
                    sp.Play();
                }
            }
            catch (Exception ex)
            {
                string errStr = ex.Message;
                throw ex;
            }
        }

        /// <summary>
        /// 以異步方式播放wav文件
        /// </summary>
        /// <param name="wavFilePath">wav文件的路徑</param>
        public static void ASyncPlayWAV(string wavFilePath)
        {
            try
            {
                //創建一個SoundPlaryer類，並設置wav文件的路徑
                SoundPlayer sp = new SoundPlayer(wavFilePath);

                //使用異步方式加載wav文件
                sp.LoadAsync();

                //使用異步方式播放wav文件
                if (sp.IsLoadCompleted)
                {
                    sp.Play();
                }
            }
            catch (Exception ex)
            {
                string errStr = ex.Message;
                throw ex;
            }
        }
        #endregion

        #region 停止播放wav文件
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sp">SoundPlayer對像</param>
        public static void StopWAV(SoundPlayer sp)
        {
            sp.Stop();
        }
        #endregion
    }
}
