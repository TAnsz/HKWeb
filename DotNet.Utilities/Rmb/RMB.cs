/// <summary>
/// �������GAssistant
/// �s �X �H�GĬ��
/// �pô�覡�G361983679  
/// ��s�����Ghttp://www.sufeinet.com/thread-655-1-1.html
/// </summary>
using System;

namespace DotNet.Utilities
{
    /// <summary> 
    /// Rmb ���K�n�����C 
    /// </summary> 
    public class Rmb
    {
        /// <summary> 
        /// �ഫ�H�����j�p���B 
        /// </summary> 
        /// <param name="num">���B</param> 
        /// <returns>��^�j�g�Φ�</returns> 
        public static string CmycurD(decimal num)
        {
            string str1 = "�s���L�T�v��m�èh";            //0-9�ҹ������~�r 
            string str2 = "�U�a�լB���a�լB�U�a�լB������"; //�Ʀr��ҹ������~�r 
            string str3 = "";    //�q��num�Ȥ����X���� 
            string str4 = "";    //�Ʀr���r�Ŧ�Φ� 
            string str5 = "";  //�H�����j�g���B�Φ� 
            int i;    //�`���ܶq 
            int j;    //num���ȭ��H100���r�Ŧ���� 
            string ch1 = "";    //�Ʀr���~�yŪ�k 
            string ch2 = "";    //�Ʀr�쪺�~�rŪ�k 
            int nzero = 0;  //�Ψӭp��s�򪺹s�ȬO�X�� 
            int temp;            //�q��num�Ȥ����X���� 

            num = Math.Round(Math.Abs(num), 2);    //�Nnum������Ȩå|�ˤ��J��2��p�� 
            str4 = ((long)(num * 100)).ToString();        //�Nnum��100���ഫ���r�Ŧ�Φ� 
            j = str4.Length;      //��X�̰��� 
            if (j > 15) { return "���X"; }
            str2 = str2.Substring(15 - j);   //���X������ƪ�str2���ȡC�p�G200.55,j��5�ҥHstr2=�լB������ 

            //�`�����X�C�@��ݭn�ഫ���� 
            for (i = 0; i < j; i++)
            {
                str3 = str4.Substring(i, 1);          //���X���ഫ���Y�@�쪺�� 
                temp = Convert.ToInt32(str3);      //�ഫ���Ʀr 
                if (i != (j - 3) && i != (j - 7) && i != (j - 11) && i != (j - 15))
                {
                    //��Ҩ���Ƥ������B�U�B���B�U���W���Ʀr�� 
                    if (str3 == "0")
                    {
                        ch1 = "";
                        ch2 = "";
                        nzero = nzero + 1;
                    }
                    else
                    {
                        if (str3 != "0" && nzero != 0)
                        {
                            ch1 = "�s" + str1.Substring(temp * 1, 1);
                            ch2 = str2.Substring(i, 1);
                            nzero = 0;
                        }
                        else
                        {
                            ch1 = str1.Substring(temp * 1, 1);
                            ch2 = str2.Substring(i, 1);
                            nzero = 0;
                        }
                    }
                }
                else
                {
                    //�Ӧ�O�U���A���A�U�A���쵥����� 
                    if (str3 != "0" && nzero != 0)
                    {
                        ch1 = "�s" + str1.Substring(temp * 1, 1);
                        ch2 = str2.Substring(i, 1);
                        nzero = 0;
                    }
                    else
                    {
                        if (str3 != "0" && nzero == 0)
                        {
                            ch1 = str1.Substring(temp * 1, 1);
                            ch2 = str2.Substring(i, 1);
                            nzero = 0;
                        }
                        else
                        {
                            if (str3 == "0" && nzero >= 3)
                            {
                                ch1 = "";
                                ch2 = "";
                                nzero = nzero + 1;
                            }
                            else
                            {
                                if (j >= 11)
                                {
                                    ch1 = "";
                                    nzero = nzero + 1;
                                }
                                else
                                {
                                    ch1 = "";
                                    ch2 = str2.Substring(i, 1);
                                    nzero = nzero + 1;
                                }
                            }
                        }
                    }
                }
                if (i == (j - 11) || i == (j - 3))
                {
                    //�p�G�Ӧ�O����Τ���A�h�����g�W 
                    ch2 = str2.Substring(i, 1);
                }
                str5 = str5 + ch1 + ch2;

                if (i == j - 1 && str3 == "0")
                {
                    //�̫�@��]���^��0�ɡA�[�W�u��v 
                    str5 = str5 + '��';
                }
            }
            if (num == 0)
            {
                str5 = "�s����";
            }
            return str5;
        }

        /**/
        /// <summary> 
        /// �@�ӭ����A�N�r�Ŧ���ഫ���Ʀr�b�ե�CmycurD(decimal num) 
        /// </summary> 
        /// <param name="num">�Τ��J�����B�A�r�Ŧ�Φ����নdecimal</param> 
        /// <returns></returns> 
        public static string CmycurD(string numstr)
        {
            try
            {
                decimal num = Convert.ToDecimal(numstr);
                return CmycurD(num);
            }
            catch
            {
                return "�D�Ʀr�Φ��I";
            }
        }
    }

}
