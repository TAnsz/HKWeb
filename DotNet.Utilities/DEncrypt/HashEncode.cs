/// <summary>
/// �������GAssistant
/// �s �X �H�GĬ��
/// �pô�覡�G361983679  
/// ��s�����Ghttp://www.sufeinet.com/thread-655-1-1.html
/// </summary>

using System;
using System.Text;
using System.Security.Cryptography;
namespace DotNet.Utilities
{
	/// <summary>
	/// �o���H���w���X�]���ƥ[�K�^�C
	/// </summary>
	public class HashEncode
	{
		public HashEncode()
		{
			//
			// TODO: �b���B�K�[�c�y����޿�
			//
		}
		/// <summary>
		/// �o���H�����ƥ[�K�r�Ŧ�
		/// </summary>
		/// <returns></returns>
		public static string GetSecurity()
		{			
			string Security = HashEncoding(GetRandomValue());		
			return Security;
		}
		/// <summary>
		/// �o��@���H���ƭ�
		/// </summary>
		/// <returns></returns>
		public static string GetRandomValue()
		{			
			Random Seed = new Random();
			string RandomVaule = Seed.Next(1, int.MaxValue).ToString();
			return RandomVaule;
		}
		/// <summary>
		/// ���ƥ[�K�@�Ӧr�Ŧ�
		/// </summary>
		/// <param name="Security"></param>
		/// <returns></returns>
		public static string HashEncoding(string Security)
		{						
			byte[] Value;
			UnicodeEncoding Code = new UnicodeEncoding();
			byte[] Message = Code.GetBytes(Security);
			SHA512Managed Arithmetic = new SHA512Managed();
			Value = Arithmetic.ComputeHash(Message);
			Security = "";
			foreach(byte o in Value)
			{
				Security += (int) o + "O";
			}
			return Security;
		}
	}
}
