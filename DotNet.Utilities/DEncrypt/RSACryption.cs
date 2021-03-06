/// <summary>
/// 類說明：Assistant
/// 編 碼 人：蘇飛
/// 聯繫方式：361983679  
/// 更新網站：http://www.sufeinet.com/thread-655-1-1.html
/// </summary>
using System; 
using System.Text; 
using System.Security.Cryptography;
namespace DotNet.Utilities
{ 
	/// <summary> 
	/// RSA加密解密及RSA簽名和驗證
	/// </summary> 
	public class RSACryption 
	{ 		
		public RSACryption() 
		{ 			
		} 
		

		#region RSA 加密解密 

		#region RSA 的密鑰產生 
	
		/// <summary>
		/// RSA 的密鑰產生 產生私鑰 和公鑰 
		/// </summary>
		/// <param name="xmlKeys"></param>
		/// <param name="xmlPublicKey"></param>
		public void RSAKey(out string xmlKeys,out string xmlPublicKey) 
		{ 			
				System.Security.Cryptography.RSACryptoServiceProvider rsa=new RSACryptoServiceProvider(); 
				xmlKeys=rsa.ToXmlString(true); 
				xmlPublicKey = rsa.ToXmlString(false); 			
		} 
		#endregion 

		#region RSA的加密函數 
		//############################################################################## 
		//RSA 方式加密 
		//說明KEY必須是XML的行式,返回的是字符串 
		//在有一點需要說明！！該加密方式有 長度 限制的！！ 
		//############################################################################## 

		//RSA的加密函數  string
		public string RSAEncrypt(string xmlPublicKey,string m_strEncryptString ) 
		{ 
			
			byte[] PlainTextBArray; 
			byte[] CypherTextBArray; 
			string Result; 
			RSACryptoServiceProvider rsa=new RSACryptoServiceProvider(); 
			rsa.FromXmlString(xmlPublicKey); 
			PlainTextBArray = (new UnicodeEncoding()).GetBytes(m_strEncryptString); 
			CypherTextBArray = rsa.Encrypt(PlainTextBArray, false); 
			Result=Convert.ToBase64String(CypherTextBArray); 
			return Result; 
			
		} 
		//RSA的加密函數 byte[]
		public string RSAEncrypt(string xmlPublicKey,byte[] EncryptString ) 
		{ 
			
			byte[] CypherTextBArray; 
			string Result; 
			RSACryptoServiceProvider rsa=new RSACryptoServiceProvider(); 
			rsa.FromXmlString(xmlPublicKey); 
			CypherTextBArray = rsa.Encrypt(EncryptString, false); 
			Result=Convert.ToBase64String(CypherTextBArray); 
			return Result; 
			
		} 
		#endregion 

		#region RSA的解密函數 
		//RSA的解密函數  string
		public string RSADecrypt(string xmlPrivateKey, string m_strDecryptString ) 
		{			
			byte[] PlainTextBArray; 
			byte[] DypherTextBArray; 
			string Result; 
			System.Security.Cryptography.RSACryptoServiceProvider rsa=new RSACryptoServiceProvider(); 
			rsa.FromXmlString(xmlPrivateKey); 
			PlainTextBArray =Convert.FromBase64String(m_strDecryptString); 
			DypherTextBArray=rsa.Decrypt(PlainTextBArray, false); 
			Result=(new UnicodeEncoding()).GetString(DypherTextBArray); 
			return Result; 
			
		} 

		//RSA的解密函數  byte
		public string RSADecrypt(string xmlPrivateKey, byte[] DecryptString ) 
		{			
			byte[] DypherTextBArray; 
			string Result; 
			System.Security.Cryptography.RSACryptoServiceProvider rsa=new RSACryptoServiceProvider(); 
			rsa.FromXmlString(xmlPrivateKey); 
			DypherTextBArray=rsa.Decrypt(DecryptString, false); 
			Result=(new UnicodeEncoding()).GetString(DypherTextBArray); 
			return Result; 
			
		} 
		#endregion 

		#endregion 

		#region RSA數字簽名 

		#region 獲取Hash描述表 
		//獲取Hash描述表 
		public bool GetHash(string m_strSource, ref byte[] HashData) 
		{ 			
			//從字符串中取得Hash描述 
			byte[] Buffer; 
			System.Security.Cryptography.HashAlgorithm MD5 = System.Security.Cryptography.HashAlgorithm.Create("MD5"); 
			Buffer = System.Text.Encoding.GetEncoding("GB2312").GetBytes(m_strSource); 
			HashData = MD5.ComputeHash(Buffer); 

			return true; 			
		} 

		//獲取Hash描述表 
		public bool GetHash(string m_strSource, ref string strHashData) 
		{ 
			
			//從字符串中取得Hash描述 
			byte[] Buffer; 
			byte[] HashData; 
			System.Security.Cryptography.HashAlgorithm MD5 = System.Security.Cryptography.HashAlgorithm.Create("MD5"); 
			Buffer = System.Text.Encoding.GetEncoding("GB2312").GetBytes(m_strSource); 
			HashData = MD5.ComputeHash(Buffer); 

			strHashData = Convert.ToBase64String(HashData); 
			return true; 
			
		} 

		//獲取Hash描述表 
		public bool GetHash(System.IO.FileStream objFile, ref byte[] HashData) 
		{ 
			
			//從文件中取得Hash描述 
			System.Security.Cryptography.HashAlgorithm MD5 = System.Security.Cryptography.HashAlgorithm.Create("MD5"); 
			HashData = MD5.ComputeHash(objFile); 
			objFile.Close(); 

			return true; 
			
		} 

		//獲取Hash描述表 
		public bool GetHash(System.IO.FileStream objFile, ref string strHashData) 
		{ 
			
			//從文件中取得Hash描述 
			byte[] HashData; 
			System.Security.Cryptography.HashAlgorithm MD5 = System.Security.Cryptography.HashAlgorithm.Create("MD5"); 
			HashData = MD5.ComputeHash(objFile); 
			objFile.Close(); 

			strHashData = Convert.ToBase64String(HashData); 

			return true; 
			
		} 
		#endregion 

		#region RSA簽名 
		//RSA簽名 
		public bool SignatureFormatter(string p_strKeyPrivate, byte[] HashbyteSignature, ref byte[] EncryptedSignatureData) 
		{ 
			
				System.Security.Cryptography.RSACryptoServiceProvider RSA = new System.Security.Cryptography.RSACryptoServiceProvider(); 

				RSA.FromXmlString(p_strKeyPrivate); 
				System.Security.Cryptography.RSAPKCS1SignatureFormatter RSAFormatter = new System.Security.Cryptography.RSAPKCS1SignatureFormatter(RSA); 
				//設置簽名的算法為MD5 
				RSAFormatter.SetHashAlgorithm("MD5"); 
				//執行簽名 
				EncryptedSignatureData = RSAFormatter.CreateSignature(HashbyteSignature); 

				return true; 
			
		} 

		//RSA簽名 
		public bool SignatureFormatter(string p_strKeyPrivate, byte[] HashbyteSignature, ref string m_strEncryptedSignatureData) 
		{ 
			
				byte[] EncryptedSignatureData; 

				System.Security.Cryptography.RSACryptoServiceProvider RSA = new System.Security.Cryptography.RSACryptoServiceProvider(); 

				RSA.FromXmlString(p_strKeyPrivate); 
				System.Security.Cryptography.RSAPKCS1SignatureFormatter RSAFormatter = new System.Security.Cryptography.RSAPKCS1SignatureFormatter(RSA); 
				//設置簽名的算法為MD5 
				RSAFormatter.SetHashAlgorithm("MD5"); 
				//執行簽名 
				EncryptedSignatureData = RSAFormatter.CreateSignature(HashbyteSignature); 

				m_strEncryptedSignatureData = Convert.ToBase64String(EncryptedSignatureData); 

				return true; 
			
		} 

		//RSA簽名 
		public bool SignatureFormatter(string p_strKeyPrivate, string m_strHashbyteSignature, ref byte[] EncryptedSignatureData) 
		{ 
			
				byte[] HashbyteSignature; 

				HashbyteSignature = Convert.FromBase64String(m_strHashbyteSignature); 
				System.Security.Cryptography.RSACryptoServiceProvider RSA = new System.Security.Cryptography.RSACryptoServiceProvider(); 

				RSA.FromXmlString(p_strKeyPrivate); 
				System.Security.Cryptography.RSAPKCS1SignatureFormatter RSAFormatter = new System.Security.Cryptography.RSAPKCS1SignatureFormatter(RSA); 
				//設置簽名的算法為MD5 
				RSAFormatter.SetHashAlgorithm("MD5"); 
				//執行簽名 
				EncryptedSignatureData = RSAFormatter.CreateSignature(HashbyteSignature); 

				return true; 
			
		} 

		//RSA簽名 
		public bool SignatureFormatter(string p_strKeyPrivate, string m_strHashbyteSignature, ref string m_strEncryptedSignatureData) 
		{ 
			
				byte[] HashbyteSignature; 
				byte[] EncryptedSignatureData; 

				HashbyteSignature = Convert.FromBase64String(m_strHashbyteSignature); 
				System.Security.Cryptography.RSACryptoServiceProvider RSA = new System.Security.Cryptography.RSACryptoServiceProvider(); 

				RSA.FromXmlString(p_strKeyPrivate); 
				System.Security.Cryptography.RSAPKCS1SignatureFormatter RSAFormatter = new System.Security.Cryptography.RSAPKCS1SignatureFormatter(RSA); 
				//設置簽名的算法為MD5 
				RSAFormatter.SetHashAlgorithm("MD5"); 
				//執行簽名 
				EncryptedSignatureData = RSAFormatter.CreateSignature(HashbyteSignature); 

				m_strEncryptedSignatureData = Convert.ToBase64String(EncryptedSignatureData); 

				return true; 
			
		} 
		#endregion 

		#region RSA 簽名驗證 

		public bool SignatureDeformatter(string p_strKeyPublic, byte[] HashbyteDeformatter, byte[] DeformatterData) 
		{ 
			
				System.Security.Cryptography.RSACryptoServiceProvider RSA = new System.Security.Cryptography.RSACryptoServiceProvider(); 

				RSA.FromXmlString(p_strKeyPublic); 
				System.Security.Cryptography.RSAPKCS1SignatureDeformatter RSADeformatter = new System.Security.Cryptography.RSAPKCS1SignatureDeformatter(RSA); 
				//指定解密的時候HASH算法為MD5 
				RSADeformatter.SetHashAlgorithm("MD5"); 

				if(RSADeformatter.VerifySignature(HashbyteDeformatter,DeformatterData)) 
				{ 
					return true; 
				} 
				else 
				{ 
					return false; 
				} 
			
		} 

		public bool SignatureDeformatter(string p_strKeyPublic, string p_strHashbyteDeformatter, byte[] DeformatterData) 
		{ 
			
				byte[] HashbyteDeformatter; 

				HashbyteDeformatter = Convert.FromBase64String(p_strHashbyteDeformatter); 

				System.Security.Cryptography.RSACryptoServiceProvider RSA = new System.Security.Cryptography.RSACryptoServiceProvider(); 

				RSA.FromXmlString(p_strKeyPublic); 
				System.Security.Cryptography.RSAPKCS1SignatureDeformatter RSADeformatter = new System.Security.Cryptography.RSAPKCS1SignatureDeformatter(RSA); 
				//指定解密的時候HASH算法為MD5 
				RSADeformatter.SetHashAlgorithm("MD5"); 

				if(RSADeformatter.VerifySignature(HashbyteDeformatter,DeformatterData)) 
				{ 
					return true; 
				} 
				else 
				{ 
					return false; 
				} 
			
		} 

		public bool SignatureDeformatter(string p_strKeyPublic, byte[] HashbyteDeformatter, string p_strDeformatterData) 
		{ 
			
				byte[] DeformatterData; 

				System.Security.Cryptography.RSACryptoServiceProvider RSA = new System.Security.Cryptography.RSACryptoServiceProvider(); 

				RSA.FromXmlString(p_strKeyPublic); 
				System.Security.Cryptography.RSAPKCS1SignatureDeformatter RSADeformatter = new System.Security.Cryptography.RSAPKCS1SignatureDeformatter(RSA); 
				//指定解密的時候HASH算法為MD5 
				RSADeformatter.SetHashAlgorithm("MD5"); 

				DeformatterData =Convert.FromBase64String(p_strDeformatterData); 

				if(RSADeformatter.VerifySignature(HashbyteDeformatter,DeformatterData)) 
				{ 
					return true; 
				} 
				else 
				{ 
					return false; 
				} 
			
		} 

		public bool SignatureDeformatter(string p_strKeyPublic, string p_strHashbyteDeformatter, string p_strDeformatterData) 
		{ 
			
				byte[] DeformatterData; 
				byte[] HashbyteDeformatter; 

				HashbyteDeformatter = Convert.FromBase64String(p_strHashbyteDeformatter); 
				System.Security.Cryptography.RSACryptoServiceProvider RSA = new System.Security.Cryptography.RSACryptoServiceProvider(); 

				RSA.FromXmlString(p_strKeyPublic); 
				System.Security.Cryptography.RSAPKCS1SignatureDeformatter RSADeformatter = new System.Security.Cryptography.RSAPKCS1SignatureDeformatter(RSA); 
				//指定解密的時候HASH算法為MD5 
				RSADeformatter.SetHashAlgorithm("MD5"); 

				DeformatterData =Convert.FromBase64String(p_strDeformatterData); 

				if(RSADeformatter.VerifySignature(HashbyteDeformatter,DeformatterData)) 
				{ 
					return true; 
				} 
				else 
				{ 
					return false; 
				} 
			
		} 


		#endregion 


		#endregion 

	} 
} 
