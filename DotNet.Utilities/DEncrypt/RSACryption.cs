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
	/// RSA�[�K�ѱK��RSAñ�W�M����
	/// </summary> 
	public class RSACryption 
	{ 		
		public RSACryption() 
		{ 			
		} 
		

		#region RSA �[�K�ѱK 

		#region RSA ���K�_���� 
	
		/// <summary>
		/// RSA ���K�_���� ���ͨp�_ �M���_ 
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

		#region RSA���[�K��� 
		//############################################################################## 
		//RSA �覡�[�K 
		//����KEY�����OXML���榡,��^���O�r�Ŧ� 
		//�b���@�I�ݭn�����I�I�ӥ[�K�覡�� ���� ����I�I 
		//############################################################################## 

		//RSA���[�K���  string
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
		//RSA���[�K��� byte[]
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

		#region RSA���ѱK��� 
		//RSA���ѱK���  string
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

		//RSA���ѱK���  byte
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

		#region RSA�Ʀrñ�W 

		#region ���Hash�y�z�� 
		//���Hash�y�z�� 
		public bool GetHash(string m_strSource, ref byte[] HashData) 
		{ 			
			//�q�r�Ŧꤤ���oHash�y�z 
			byte[] Buffer; 
			System.Security.Cryptography.HashAlgorithm MD5 = System.Security.Cryptography.HashAlgorithm.Create("MD5"); 
			Buffer = System.Text.Encoding.GetEncoding("GB2312").GetBytes(m_strSource); 
			HashData = MD5.ComputeHash(Buffer); 

			return true; 			
		} 

		//���Hash�y�z�� 
		public bool GetHash(string m_strSource, ref string strHashData) 
		{ 
			
			//�q�r�Ŧꤤ���oHash�y�z 
			byte[] Buffer; 
			byte[] HashData; 
			System.Security.Cryptography.HashAlgorithm MD5 = System.Security.Cryptography.HashAlgorithm.Create("MD5"); 
			Buffer = System.Text.Encoding.GetEncoding("GB2312").GetBytes(m_strSource); 
			HashData = MD5.ComputeHash(Buffer); 

			strHashData = Convert.ToBase64String(HashData); 
			return true; 
			
		} 

		//���Hash�y�z�� 
		public bool GetHash(System.IO.FileStream objFile, ref byte[] HashData) 
		{ 
			
			//�q��󤤨��oHash�y�z 
			System.Security.Cryptography.HashAlgorithm MD5 = System.Security.Cryptography.HashAlgorithm.Create("MD5"); 
			HashData = MD5.ComputeHash(objFile); 
			objFile.Close(); 

			return true; 
			
		} 

		//���Hash�y�z�� 
		public bool GetHash(System.IO.FileStream objFile, ref string strHashData) 
		{ 
			
			//�q��󤤨��oHash�y�z 
			byte[] HashData; 
			System.Security.Cryptography.HashAlgorithm MD5 = System.Security.Cryptography.HashAlgorithm.Create("MD5"); 
			HashData = MD5.ComputeHash(objFile); 
			objFile.Close(); 

			strHashData = Convert.ToBase64String(HashData); 

			return true; 
			
		} 
		#endregion 

		#region RSAñ�W 
		//RSAñ�W 
		public bool SignatureFormatter(string p_strKeyPrivate, byte[] HashbyteSignature, ref byte[] EncryptedSignatureData) 
		{ 
			
				System.Security.Cryptography.RSACryptoServiceProvider RSA = new System.Security.Cryptography.RSACryptoServiceProvider(); 

				RSA.FromXmlString(p_strKeyPrivate); 
				System.Security.Cryptography.RSAPKCS1SignatureFormatter RSAFormatter = new System.Security.Cryptography.RSAPKCS1SignatureFormatter(RSA); 
				//�]�mñ�W����k��MD5 
				RSAFormatter.SetHashAlgorithm("MD5"); 
				//����ñ�W 
				EncryptedSignatureData = RSAFormatter.CreateSignature(HashbyteSignature); 

				return true; 
			
		} 

		//RSAñ�W 
		public bool SignatureFormatter(string p_strKeyPrivate, byte[] HashbyteSignature, ref string m_strEncryptedSignatureData) 
		{ 
			
				byte[] EncryptedSignatureData; 

				System.Security.Cryptography.RSACryptoServiceProvider RSA = new System.Security.Cryptography.RSACryptoServiceProvider(); 

				RSA.FromXmlString(p_strKeyPrivate); 
				System.Security.Cryptography.RSAPKCS1SignatureFormatter RSAFormatter = new System.Security.Cryptography.RSAPKCS1SignatureFormatter(RSA); 
				//�]�mñ�W����k��MD5 
				RSAFormatter.SetHashAlgorithm("MD5"); 
				//����ñ�W 
				EncryptedSignatureData = RSAFormatter.CreateSignature(HashbyteSignature); 

				m_strEncryptedSignatureData = Convert.ToBase64String(EncryptedSignatureData); 

				return true; 
			
		} 

		//RSAñ�W 
		public bool SignatureFormatter(string p_strKeyPrivate, string m_strHashbyteSignature, ref byte[] EncryptedSignatureData) 
		{ 
			
				byte[] HashbyteSignature; 

				HashbyteSignature = Convert.FromBase64String(m_strHashbyteSignature); 
				System.Security.Cryptography.RSACryptoServiceProvider RSA = new System.Security.Cryptography.RSACryptoServiceProvider(); 

				RSA.FromXmlString(p_strKeyPrivate); 
				System.Security.Cryptography.RSAPKCS1SignatureFormatter RSAFormatter = new System.Security.Cryptography.RSAPKCS1SignatureFormatter(RSA); 
				//�]�mñ�W����k��MD5 
				RSAFormatter.SetHashAlgorithm("MD5"); 
				//����ñ�W 
				EncryptedSignatureData = RSAFormatter.CreateSignature(HashbyteSignature); 

				return true; 
			
		} 

		//RSAñ�W 
		public bool SignatureFormatter(string p_strKeyPrivate, string m_strHashbyteSignature, ref string m_strEncryptedSignatureData) 
		{ 
			
				byte[] HashbyteSignature; 
				byte[] EncryptedSignatureData; 

				HashbyteSignature = Convert.FromBase64String(m_strHashbyteSignature); 
				System.Security.Cryptography.RSACryptoServiceProvider RSA = new System.Security.Cryptography.RSACryptoServiceProvider(); 

				RSA.FromXmlString(p_strKeyPrivate); 
				System.Security.Cryptography.RSAPKCS1SignatureFormatter RSAFormatter = new System.Security.Cryptography.RSAPKCS1SignatureFormatter(RSA); 
				//�]�mñ�W����k��MD5 
				RSAFormatter.SetHashAlgorithm("MD5"); 
				//����ñ�W 
				EncryptedSignatureData = RSAFormatter.CreateSignature(HashbyteSignature); 

				m_strEncryptedSignatureData = Convert.ToBase64String(EncryptedSignatureData); 

				return true; 
			
		} 
		#endregion 

		#region RSA ñ�W���� 

		public bool SignatureDeformatter(string p_strKeyPublic, byte[] HashbyteDeformatter, byte[] DeformatterData) 
		{ 
			
				System.Security.Cryptography.RSACryptoServiceProvider RSA = new System.Security.Cryptography.RSACryptoServiceProvider(); 

				RSA.FromXmlString(p_strKeyPublic); 
				System.Security.Cryptography.RSAPKCS1SignatureDeformatter RSADeformatter = new System.Security.Cryptography.RSAPKCS1SignatureDeformatter(RSA); 
				//���w�ѱK���ɭ�HASH��k��MD5 
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
				//���w�ѱK���ɭ�HASH��k��MD5 
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
				//���w�ѱK���ɭ�HASH��k��MD5 
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
				//���w�ѱK���ɭ�HASH��k��MD5 
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
