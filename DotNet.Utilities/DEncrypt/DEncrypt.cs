/// <summary>
/// 聯繫方式：361983679  
/// 更新網站：http://www.sufeinet.com/thread-655-1-1.html
/// </summary>
using System;
using System.Security.Cryptography;
using System.Text;
namespace DotNet.Utilities
{
    /// <summary>
    /// Encrypt 的摘要說明。
    /// </summary>
    public class DEncrypt
    {
        /// <summary>
        /// 構造方法
        /// </summary>
        public DEncrypt()
        {

        }

        #region 使用 缺省密鑰字符串 加密/解密string

        /// <summary>
        /// 使用缺省密鑰字符串加密string
        /// </summary>
        /// <param name="original">明文</param>
        /// <returns>密文</returns>
        public static string Encrypt(string original)
        {
            return Encrypt(original, "MATICSOFT");
        }
        /// <summary>
        /// 使用缺省密鑰字符串解密string
        /// </summary>
        /// <param name="original">密文</param>
        /// <returns>明文</returns>
        public static string Decrypt(string original)
        {
            return Decrypt(original, "MATICSOFT", System.Text.Encoding.Default);
        }

        #endregion

        #region 使用 給定密鑰字符串 加密/解密string
        /// <summary>
        /// 使用給定密鑰字符串加密string
        /// </summary>
        /// <param name="original">原始文字</param>
        /// <param name="key">密鑰</param>
        /// <param name="encoding">字符編碼方案</param>
        /// <returns>密文</returns>
        public static string Encrypt(string original, string key)
        {
            byte[] buff = System.Text.Encoding.Default.GetBytes(original);
            byte[] kb = System.Text.Encoding.Default.GetBytes(key);
            return Convert.ToBase64String(Encrypt(buff, kb));
        }
        /// <summary>
        /// 使用給定密鑰字符串解密string
        /// </summary>
        /// <param name="original">密文</param>
        /// <param name="key">密鑰</param>
        /// <returns>明文</returns>
        public static string Decrypt(string original, string key)
        {
            return Decrypt(original, key, System.Text.Encoding.Default);
        }

        /// <summary>
        /// 使用給定密鑰字符串解密string,返回指定編碼方式明文
        /// </summary>
        /// <param name="encrypted">密文</param>
        /// <param name="key">密鑰</param>
        /// <param name="encoding">字符編碼方案</param>
        /// <returns>明文</returns>
        public static string Decrypt(string encrypted, string key, Encoding encoding)
        {
            byte[] buff = Convert.FromBase64String(encrypted);
            byte[] kb = System.Text.Encoding.Default.GetBytes(key);
            return encoding.GetString(Decrypt(buff, kb));
        }
        #endregion

        #region 使用 缺省密鑰字符串 加密/解密/byte[]
        /// <summary>
        /// 使用缺省密鑰字符串解密byte[]
        /// </summary>
        /// <param name="encrypted">密文</param>
        /// <param name="key">密鑰</param>
        /// <returns>明文</returns>
        public static byte[] Decrypt(byte[] encrypted)
        {
            byte[] key = System.Text.Encoding.Default.GetBytes("MATICSOFT");
            return Decrypt(encrypted, key);
        }
        /// <summary>
        /// 使用缺省密鑰字符串加密
        /// </summary>
        /// <param name="original">原始數據</param>
        /// <param name="key">密鑰</param>
        /// <returns>密文</returns>
        public static byte[] Encrypt(byte[] original)
        {
            byte[] key = System.Text.Encoding.Default.GetBytes("MATICSOFT");
            return Encrypt(original, key);
        }
        #endregion

        #region  使用 給定密鑰 加密/解密/byte[]

        /// <summary>
        /// 生成MD5摘要
        /// </summary>
        /// <param name="original">數據源</param>
        /// <returns>摘要</returns>
        public static byte[] MakeMD5(byte[] original)
        {
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            byte[] keyhash = hashmd5.ComputeHash(original);
            hashmd5 = null;
            return keyhash;
        }

        /// <summary>
        /// 使用給定密鑰加密
        /// </summary>
        /// <param name="original">明文</param>
        /// <param name="key">密鑰</param>
        /// <returns>密文</returns>
        public static byte[] Encrypt(byte[] original, byte[] key)
        {
            TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
            des.Key = MakeMD5(key);
            des.Mode = CipherMode.ECB;

            return des.CreateEncryptor().TransformFinalBlock(original, 0, original.Length);
        }

        /// <summary>
        /// 使用給定密鑰解密數據
        /// </summary>
        /// <param name="encrypted">密文</param>
        /// <param name="key">密鑰</param>
        /// <returns>明文</returns>
        public static byte[] Decrypt(byte[] encrypted, byte[] key)
        {
            TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
            des.Key = MakeMD5(key);
            des.Mode = CipherMode.ECB;

            return des.CreateDecryptor().TransformFinalBlock(encrypted, 0, encrypted.Length);
        }

        #endregion
    }
}
