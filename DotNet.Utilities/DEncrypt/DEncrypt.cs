/// <summary>
/// �pô�覡�G361983679  
/// ��s�����Ghttp://www.sufeinet.com/thread-655-1-1.html
/// </summary>
using System;
using System.Security.Cryptography;
using System.Text;
namespace DotNet.Utilities
{
    /// <summary>
    /// Encrypt ���K�n�����C
    /// </summary>
    public class DEncrypt
    {
        /// <summary>
        /// �c�y��k
        /// </summary>
        public DEncrypt()
        {

        }

        #region �ϥ� �ʬٱK�_�r�Ŧ� �[�K/�ѱKstring

        /// <summary>
        /// �ϥίʬٱK�_�r�Ŧ�[�Kstring
        /// </summary>
        /// <param name="original">����</param>
        /// <returns>�K��</returns>
        public static string Encrypt(string original)
        {
            return Encrypt(original, "MATICSOFT");
        }
        /// <summary>
        /// �ϥίʬٱK�_�r�Ŧ�ѱKstring
        /// </summary>
        /// <param name="original">�K��</param>
        /// <returns>����</returns>
        public static string Decrypt(string original)
        {
            return Decrypt(original, "MATICSOFT", System.Text.Encoding.Default);
        }

        #endregion

        #region �ϥ� ���w�K�_�r�Ŧ� �[�K/�ѱKstring
        /// <summary>
        /// �ϥε��w�K�_�r�Ŧ�[�Kstring
        /// </summary>
        /// <param name="original">��l��r</param>
        /// <param name="key">�K�_</param>
        /// <param name="encoding">�r�Žs�X���</param>
        /// <returns>�K��</returns>
        public static string Encrypt(string original, string key)
        {
            byte[] buff = System.Text.Encoding.Default.GetBytes(original);
            byte[] kb = System.Text.Encoding.Default.GetBytes(key);
            return Convert.ToBase64String(Encrypt(buff, kb));
        }
        /// <summary>
        /// �ϥε��w�K�_�r�Ŧ�ѱKstring
        /// </summary>
        /// <param name="original">�K��</param>
        /// <param name="key">�K�_</param>
        /// <returns>����</returns>
        public static string Decrypt(string original, string key)
        {
            return Decrypt(original, key, System.Text.Encoding.Default);
        }

        /// <summary>
        /// �ϥε��w�K�_�r�Ŧ�ѱKstring,��^���w�s�X�覡����
        /// </summary>
        /// <param name="encrypted">�K��</param>
        /// <param name="key">�K�_</param>
        /// <param name="encoding">�r�Žs�X���</param>
        /// <returns>����</returns>
        public static string Decrypt(string encrypted, string key, Encoding encoding)
        {
            byte[] buff = Convert.FromBase64String(encrypted);
            byte[] kb = System.Text.Encoding.Default.GetBytes(key);
            return encoding.GetString(Decrypt(buff, kb));
        }
        #endregion

        #region �ϥ� �ʬٱK�_�r�Ŧ� �[�K/�ѱK/byte[]
        /// <summary>
        /// �ϥίʬٱK�_�r�Ŧ�ѱKbyte[]
        /// </summary>
        /// <param name="encrypted">�K��</param>
        /// <param name="key">�K�_</param>
        /// <returns>����</returns>
        public static byte[] Decrypt(byte[] encrypted)
        {
            byte[] key = System.Text.Encoding.Default.GetBytes("MATICSOFT");
            return Decrypt(encrypted, key);
        }
        /// <summary>
        /// �ϥίʬٱK�_�r�Ŧ�[�K
        /// </summary>
        /// <param name="original">��l�ƾ�</param>
        /// <param name="key">�K�_</param>
        /// <returns>�K��</returns>
        public static byte[] Encrypt(byte[] original)
        {
            byte[] key = System.Text.Encoding.Default.GetBytes("MATICSOFT");
            return Encrypt(original, key);
        }
        #endregion

        #region  �ϥ� ���w�K�_ �[�K/�ѱK/byte[]

        /// <summary>
        /// �ͦ�MD5�K�n
        /// </summary>
        /// <param name="original">�ƾڷ�</param>
        /// <returns>�K�n</returns>
        public static byte[] MakeMD5(byte[] original)
        {
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            byte[] keyhash = hashmd5.ComputeHash(original);
            hashmd5 = null;
            return keyhash;
        }

        /// <summary>
        /// �ϥε��w�K�_�[�K
        /// </summary>
        /// <param name="original">����</param>
        /// <param name="key">�K�_</param>
        /// <returns>�K��</returns>
        public static byte[] Encrypt(byte[] original, byte[] key)
        {
            TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
            des.Key = MakeMD5(key);
            des.Mode = CipherMode.ECB;

            return des.CreateEncryptor().TransformFinalBlock(original, 0, original.Length);
        }

        /// <summary>
        /// �ϥε��w�K�_�ѱK�ƾ�
        /// </summary>
        /// <param name="encrypted">�K��</param>
        /// <param name="key">�K�_</param>
        /// <returns>����</returns>
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
