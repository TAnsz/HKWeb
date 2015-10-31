/// <summary>
/// �������GSegList
/// �s �X �H�GĬ��
/// �pô�覡�G361983679  
/// ��s�����Ghttp://www.sufeinet.com/thread-655-1-1.html
/// </summary>
using System;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;

namespace DotNet.Utilities
{
    /// <summary>
    /// �������U��
    /// </summary>
    public class SegList
    {
        public int MaxLength;
        private ArrayList m_seg;

        public int Count
        {
            get
            {
                return m_seg.Count;
            }
        }

        public SegList()
        {
            m_seg = new ArrayList();
            MaxLength = 0;
        }

        public void Add(object obj)
        {
            m_seg.Add(obj);
            if (MaxLength < obj.ToString().Length)
            {
                MaxLength = obj.ToString().Length;
            }
        }

        public object GetElem(int i)
        {
            if (i < this.Count)
                return m_seg[i];
            else
                return null;
        }

        public void SetElem(int i, object obj)
        {
            m_seg[i] = obj;
        }

        public bool Contains(object obj)
        {
            return m_seg.Contains(obj);
        }

        /// <summary>
        /// �����ױƧ�
        /// </summary>
        public void Sort()
        {
            Sort(this);
        }

        /// <summary>
        /// �����ױƧ�
        /// </summary>
        public void Sort(SegList list)
        {
            int max = 0;
            for (int i = 0; i < list.Count - 1; ++i)
            {
                max = i;
                for (int j = i + 1; j < list.Count; ++j)
                {

                    string str1 = list.GetElem(j).ToString();
                    string str2 = list.GetElem(max).ToString();
                    int l1;
                    int l2;
                    if (str1 == "null")
                        l1 = 0;
                    else
                        l1 = str1.Length;

                    if (str2 == "null")
                        l2 = 0;
                    else
                        l2 = str2.Length;

                    if (l1 > l2)
                        max = j;
                }
                object o = list.GetElem(max);
                list.SetElem(max, list.GetElem(i));
                list.SetElem(i, o);
            }
        }
    }

    /// <summary>
    /// ������
    /// </summary>
    //----------------�ե�----------------------
    //Segment seg = new Segment();
    //seg.InitWordDics();
    //seg.EnablePrefix = true;
    //seg.Separator =" ";
    //seg.SegmentText("�r�Ŧ�", false).Trim();
    //-------------------------------------------
    public class Segment
    {
        #region �p���r�q
        private string m_DicPath = System.Web.HttpContext.Current.Server.MapPath("bin/ShootSeg/sDict.dic");
        private string m_NoisePath = System.Web.HttpContext.Current.Server.MapPath("bin/ShootSeg/sNoise.dic");
        private string m_NumberPath = System.Web.HttpContext.Current.Server.MapPath("bin/ShootSeg/sNumber.dic");
        private string m_WordPath = System.Web.HttpContext.Current.Server.MapPath("bin/ShootSeg/sWord.dic");
        private string m_PrefixPath = System.Web.HttpContext.Current.Server.MapPath("bin/ShootSeg/sPrefix.dic");
        private Hashtable htWords;
        private ArrayList alNoise;
        private ArrayList alNumber;
        private ArrayList alWord;
        private ArrayList alPrefix;
        private double m_EventTime = 0;

        /// <summary>
        /// ���j��
        /// </summary>
        private string m_Separator = " ";

        /// <summary>
        /// �Ω����Һ~�r�����h��F��
        /// </summary>
        private string strChinese = "[\u4e00-\u9fa5]";
        #endregion

        #region �����ݩ�
        /// <summary>
        /// �򥻵�����|
        /// </summary>
        public string DicPath
        {
            get
            {
                return m_DicPath;
            }
            set
            {
                m_DicPath = value;
            }
        }

        /// <summary>
        /// �ƾڽw�s���
        /// </summary>
        /// <param name="key">������</param>
        /// <param name="val">�w�s���ƾ�</param>
        private static void SetCache(string key, object val)
        {
            if (val == null) val = " ";
            System.Web.HttpContext.Current.Application.Lock();
            System.Web.HttpContext.Current.Application.Set(key, val);
            System.Web.HttpContext.Current.Application.UnLock();
        }

        /// <summary>
        /// Ū���w�s
        /// </summary>
        private static object GetCache(string key)
        {
            return System.Web.HttpContext.Current.Application.Get(key);
        }

        /// <summary>
        /// �ȮɵL��
        /// </summary>
        public string NoisePath
        {
            get
            {
                return m_NoisePath;
            }
            set
            {
                m_NoisePath = value;
            }
        }

        /// <summary>
        /// �Ʀr������|
        /// </summary>
        public string NumberPath
        {
            get
            {
                return m_NumberPath;
            }
            set
            {
                m_NumberPath = value;
            }
        }

        /// <summary>
        /// �r��������|
        /// </summary>
        public string WordPath
        {
            get
            {
                return m_WordPath;
            }
            set
            {
                m_WordPath = value;
            }
        }

        /// <summary>
        /// �m�W�e��r�� �Ω�ȿ��m�W
        /// </summary>
        public string PrefixPath
        {
            get
            {
                return m_PrefixPath;
            }
            set
            {
                m_PrefixPath = value;
            }
        }

        /// <summary>
        /// �O�_�}�ҩm�W�ȿ��\��
        /// </summary>
        public bool EnablePrefix
        {
            get
            {
                if (alPrefix.Count == 0)
                    return false;
                else
                    return true;
            }
            set
            {
                if (value)
                    alPrefix = LoadWords(PrefixPath, alPrefix);
                else
                    alPrefix = new ArrayList();
            }
        }

        /// <summary>
        /// �ήɨC���i��[���Τ����ʧ@����ݩʪ�ܬ��W�@���ʧ@�ҥήɶ�
        /// �w��T��@��������ާ@�b�r�Ŧ���u�ɥi�ର0
        /// </summary>
        public double EventTime
        {
            get
            {
                return m_EventTime;
            }
        }

        /// <summary>
        /// ���j��,�q�{���Ů�
        /// </summary>
        public string Separator
        {
            get
            {
                return m_Separator;
            }
            set
            {
                if (value != "" && value != null) m_Separator = value;
            }
        }
        #endregion

        #region �c�y��k
        /// <summary>
        /// �c�y��k
        /// </summary>
        public Segment()
        { }

        /// <summary>
        /// �c�y��k
        /// </summary>
        public Segment(string p_DicPath, string p_NoisePath, string p_NumberPath, string p_WordPath)
        {
            m_WordPath = p_DicPath;
            m_WordPath = p_NoisePath;
            m_WordPath = p_NumberPath;
            m_WordPath = p_WordPath;
            this.InitWordDics();
        }
        #endregion

        #region ������k
        /// <summary>
        /// �[�����C��
        /// </summary>
        public void InitWordDics()
        {
            DateTime start = DateTime.Now;
            if (GetCache("jcms_dict") == null)
            {
                htWords = new Hashtable();
                Hashtable father = htWords;
                Hashtable forfather = htWords;

                string strChar1;
                string strChar2;

                StreamReader reader = new StreamReader(DicPath, System.Text.Encoding.UTF8);
                string strline = reader.ReadLine();

                SegList list;
                Hashtable child = new Hashtable();

                long i = 0;
                while (strline != null && strline.Trim() != "")
                {
                    i++;
                    strChar1 = strline.Substring(0, 1);
                    strChar2 = strline.Substring(1, 1);
                    if (!htWords.ContainsKey(strChar1))
                    {
                        father = new Hashtable();
                        htWords.Add(strChar1, father);
                    }
                    else
                    {
                        father = (Hashtable)htWords[strChar1];
                    }

                    if (!father.ContainsKey(strChar2))
                    {
                        list = new SegList();
                        if (strline.Length > 2)
                            list.Add(strline.Substring(2));
                        else
                            list.Add("null");
                        father.Add(strChar2, list);
                    }
                    else
                    {
                        list = (SegList)father[strChar2];
                        if (strline.Length > 2)
                        {
                            list.Add(strline.Substring(2));
                        }
                        else
                        {
                            list.Add("null");
                        }
                        father[strChar2] = list;
                    }
                    htWords[strChar1] = father;
                    strline = reader.ReadLine();
                }
                try
                {
                    reader.Close();
                }
                catch
                { }
                SetCache("jcms_dict", htWords);
            }
            htWords = (Hashtable)GetCache("jcms_dict");

            alNoise = LoadWords(NoisePath, alNoise);
            alNumber = LoadWords(NumberPath, alNumber);
            alWord = LoadWords(WordPath, alWord);
            alPrefix = LoadWords(PrefixPath, alPrefix);

            TimeSpan duration = DateTime.Now - start;
            m_EventTime = duration.TotalMilliseconds;
        }

        /// <summary>
        /// �[���奻���ը�ArrayList
        /// </summary>
        public ArrayList LoadWords(string strPath, ArrayList list)
        {
            StreamReader reader = new StreamReader(strPath, System.Text.Encoding.UTF8);
            list = new ArrayList();
            string strline = reader.ReadLine();
            while (strline != null)
            {
                list.Add(strline);
                strline = reader.ReadLine();
            }
            try
            {
                reader.Close();
            }
            catch
            { }
            return list;
        }

        /// <summary>
        /// ��X���C��
        /// </summary>
        public void OutWords()
        {
            IDictionaryEnumerator idEnumerator1 = htWords.GetEnumerator();
            while (idEnumerator1.MoveNext())
            {
                IDictionaryEnumerator idEnumerator2 = ((Hashtable)idEnumerator1.Value).GetEnumerator();
                while (idEnumerator2.MoveNext())
                {
                    SegList aa = (SegList)idEnumerator2.Value;
                    for (int i = 0; i < aa.Count; i++)
                    {
                        Console.WriteLine(idEnumerator1.Key.ToString() + idEnumerator2.Key.ToString() + aa.GetElem(i).ToString());
                    }
                }
            }
        }

        /// <summary>
        /// ��XArrayList
        /// </summary>
        public void OutArrayList(ArrayList list)
        {
            if (list == null) return;
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i].ToString());
            }
        }

        /// <summary>
        /// �����L�{,������^�� 
        /// </summary>
        /// <param name="strText">�n�������奻</param>
        /// <returns>�����᪺�奻</returns>
        public string SegmentText(string strText)
        {
            strText = (strText + "$").Trim();
            if (htWords == null) return strText;
            if (strText.Length < 3) return strText;
            DateTime start = DateTime.Now;
            int length = 0;
            int preFix = 0;
            bool word = false;
            bool number = false;
            string reText = "";
            string strPrefix = "";
            string strLastChar = "";
            string strLastWords = Separator;

            for (int i = 0; i < strText.Length - 1; i++)
            {
                #region ���C�@�Ӧr���B�z�L�{
                string strChar1 = strText.Substring(i, 1);
                string strChar2 = strText.Substring(i + 1, 1).Trim();
                bool yes;
                SegList l;
                Hashtable h;

                if (reText.Length > 0) strLastChar = reText.Substring(reText.Length - 1);

                if (strChar1 == " ")
                {
                    if ((number || word) && strLastChar != Separator) reText += this.Separator;
                    yes = true;
                }
                else
                    yes = false;

                int CharType = GetCharType(strChar1);
                switch (CharType)
                {
                    case 1:
                        #region  �p�G�O�Ʀr�A�p�G�Ʀr���W�@��O�r���n�M�᭱���Ʀr���}
                        if (word)
                        {
                            reText += Separator;
                        }
                        word = false;
                        number = true;
                        strLastWords = "";
                        break;
                        #endregion
                    case 2:
                    case 5:
                        #region �p�G�O�r��
                        if (number)
                            strLastWords = Separator;
                        else
                            strLastWords = "";

                        word = true;
                        number = false;
                        break;
                        #endregion
                    case 3:
                    case 4:
                        #region �Ĥ@�ū��ƪ�O�_�]�t����r�A���p�]�t�B�z�ĤG�ū��ƪ�
                        //�W�@�Ӧr�O�_���r��
                        if (word) reText += Separator;

                        #region �˴��W�@�ӬO�_�O�Ʀr�A�o�ӹL�{�O�Ω�ץ��Ʀr�᪺�q����
                        if (number && CharType != 4)
                        {
                            h = (Hashtable)htWords["n"];
                            if (h.ContainsKey(strChar1))
                            {
                                l = (SegList)h[strChar1];
                                if (l.Contains(strChar2))
                                {
                                    reText += strChar1 + strChar2 + Separator;
                                    yes = true;
                                    i++;
                                }
                                else if (l.Contains("null"))
                                {
                                    reText += strChar1 + Separator;
                                    yes = true;
                                }
                            }
                            else
                                reText += Separator;
                        }
                        #endregion

                        //�D�~�r�Ʀr���~�r
                        if (CharType == 3)
                        {
                            word = false;
                            number = false;
                            strLastWords = Separator;
                        }
                        else
                        {
                            word = false;
                            number = true;
                            strLastWords = "";
                        }

                        //�ĤG�ū��ƪ���X
                        h = (Hashtable)htWords[strChar1];

                        //�ĤG�ū��ƪ�O�_�]�t����r
                        if (h.ContainsKey(strChar2))
                        {
                            #region  �ĤG�ť]�t����r
                            //���XArrayList�ﹳ
                            l = (SegList)h[strChar2];

                            //�M���C�@�ӹﹳ �ݬO�_��զX����
                            for (int j = 0; j < l.Count; j++)
                            {
                                bool have = false;
                                string strChar3 = l.GetElem(j).ToString();

                                //���C�@�Ө��X�����i���˴�,�ݬO�_�ǰt�A���׫O�@
                                if ((strChar3.Length + i + 2) < strText.Length)
                                {
                                    //�Vi+2����Xm���ת��r
                                    string strChar = strText.Substring(i + 2, strChar3.Length).Trim();
                                    if (strChar3 == strChar && !yes)
                                    {
                                        if (strPrefix != "")
                                        {
                                            reText += strPrefix + Separator;
                                            strPrefix = "";
                                            preFix = 0;
                                        }
                                        reText += strChar1 + strChar2 + strChar;
                                        i += strChar3.Length + 1;
                                        have = true;
                                        yes = true;
                                        break;
                                    }
                                }
                                else if ((strChar3.Length + i + 2) == strText.Length)
                                {
                                    string strChar = strText.Substring(i + 2).Trim();
                                    if (strChar3 == strChar && !yes)
                                    {
                                        if (strPrefix != "")
                                        {
                                            reText += strPrefix + Separator;
                                            strPrefix = "";
                                            preFix = 0;
                                        }
                                        reText += strChar1 + strChar2 + strChar;
                                        i += strChar3.Length + 1;
                                        have = true;
                                        yes = true;
                                        break;
                                    }
                                }

                                if (!have && j == l.Count - 1 && l.Contains("null") && !yes)
                                {
                                    if (preFix == 1)
                                    {
                                        reText += strPrefix + strChar1 + strChar2;
                                        strPrefix = "";
                                        preFix = 0;
                                    }
                                    else if (preFix > 1)
                                    {
                                        reText += strPrefix + strLastWords + strChar1 + strChar2;
                                        strPrefix = "";
                                        preFix = 0;
                                    }
                                    else
                                    {
                                        if (CharType == 4) reText += strChar1 + strChar2;
                                        else reText += strChar1 + strChar2;
                                        strLastWords = this.Separator;
                                        number = false;
                                    }
                                    i++;
                                    yes = true;
                                    break;
                                }
                                else if (have)
                                {
                                    break;
                                }
                            }
                            #endregion

                            //�p�G�S���ǰt�٥i�঳�@�ر��p�A�o�ӵ��y�u����Ӧr�A�H�o��Ӧr�}�Y�����y���s�b
                            if (!yes && l.Contains("null"))
                            {
                                if (preFix == 1)
                                {
                                    reText += strPrefix + strChar1 + strChar2;
                                    strPrefix = "";
                                    preFix = 0;
                                }
                                else if (preFix > 1)
                                {
                                    reText += strPrefix + strLastWords + strChar1 + strChar2;
                                    strPrefix = "";
                                    preFix = 0;
                                }
                                else
                                {
                                    if (CharType == 4) reText += strChar1 + strChar2;
                                    else reText += strChar1 + strChar2;
                                    strLastWords = this.Separator;
                                    number = false;
                                }
                                i++;
                                yes = true;
                            }
                            if (reText.Length > 0) strLastChar = reText.Substring(reText.Length - 1);
                            if (CharType == 4 && GetCharType(strLastChar) == 4)
                            {
                                number = true;
                            }
                            else if (strLastChar != this.Separator) reText += this.Separator;
                        }
                        #endregion
                        break;
                    default:
                        #region �����r��,�i��O�ͻ��r,�]�i��O���I�ŦX����
                        if (word && !yes)
                        {
                            reText += Separator;
                        }
                        else if (number && !yes)
                        {
                            reText += Separator;
                        }
                        number = false;
                        word = false;
                        strLastWords = this.Separator;
                        break;
                        #endregion
                }
                if (!yes && number || !yes && word)
                {
                    reText += strChar1;
                    yes = true;
                }
                if (!yes)
                {
                    #region �B�z�m�W���D
                    if (preFix == 0)
                    {
                        if (alPrefix.Contains(strChar1 + strChar2))
                        {
                            i++;
                            strPrefix = strChar1 + strChar2;
                            preFix++;
                        }
                        else if (alPrefix.Contains(strChar1))
                        {
                            if (!number)
                            {
                                strPrefix = strChar1;
                                preFix++;
                            }
                            else
                            {
                                reText += strChar1 + strLastWords;
                                number = false;
                                word = false;
                            }
                        }
                        else
                        {
                            if (preFix == 3)
                            {
                                reText += strPrefix + Separator + strChar1 + Separator;
                                strPrefix = "";
                                preFix = 0;
                            }
                            else if (preFix > 0)
                            {
                                if (Regex.IsMatch(strChar1, strChinese))
                                {
                                    strPrefix += strChar1;
                                    preFix++;
                                }
                                else
                                {
                                    reText += strPrefix + Separator + strChar1 + Separator;
                                    strPrefix = "";
                                    preFix = 0;
                                }
                            }
                            else
                            {
                                reText += strChar1 + strLastWords;
                                number = false;
                                word = false;
                            }
                        }
                    }
                    else
                    {
                        if (preFix == 3)
                        {
                            reText += strPrefix + Separator + strChar1 + Separator;
                            strPrefix = "";
                            preFix = 0;
                        }
                        else if (preFix > 0)
                        {
                            if (Regex.IsMatch(strChar1, strChinese))
                            {
                                strPrefix += strChar1;
                                preFix++;
                            }
                            else
                            {
                                reText += strPrefix + Separator + strChar1 + Separator;
                                strPrefix = "";
                                preFix = 0;
                            }
                        }
                        else
                        {
                            reText += strChar1 + strLastWords;
                            number = false;
                        }
                    }
                    #endregion
                }
                length = i;
                #endregion
            }

            #region �̫ᨾ��̫�@�Ӧr���ᥢ
            if (length < strText.Length - 1)
            {
                string strLastChar1 = strText.Substring(strText.Length - 1).Trim();
                string strLastChar2 = strText.Substring(strText.Length - 2).Trim();

                if (reText.Length > 0) strLastChar = reText.Substring(reText.Length - 1);
                if (preFix != 0)
                {
                    reText += strPrefix + strLastChar1;
                }
                else
                {
                    switch (GetCharType(strLastChar1))
                    {
                        case 1:
                            if (strLastChar1 != "." && strLastChar1 != "�D")
                                reText += strLastChar1;
                            else
                                reText += Separator + strLastChar1;
                            break;
                        case 2:
                        case 5:
                            if (alWord.Contains(strLastChar2))
                                reText += strLastChar1;
                            break;
                        case 3:
                        case 4:
                            if ((number || word) && strLastChar != Separator)
                                reText += Separator + strLastChar1;
                            else
                                reText += strLastChar1;
                            break;
                        default:
                            if (strLastChar != Separator)
                                reText += Separator + strLastChar1;
                            else
                                reText += strLastChar1;
                            break;
                    }
                }
                if (reText.Length > 0) strLastChar = (reText.Substring(reText.Length - 1));
                if (strLastChar != this.Separator) reText += this.Separator;
            }
            #endregion

            TimeSpan duration = DateTime.Now - start;
            m_EventTime = duration.TotalMilliseconds;
            return reText.Replace(" $", ""); //�o�̥]�t�@�Ӧr���A�h�h��
        }

        /// <summary>
        /// ���������L�{,����^��
        /// </summary>
        public string SegmentText(string strText, bool Enter)
        {
            if (Enter)
            {
                DateTime start = DateTime.Now;
                string[] strArr = strText.Split('\n');

                string reText = "";
                for (int i = 0; i < strArr.Length; i++)
                {
                    reText += SegmentText(strArr[i]) + "\r\n";
                }

                TimeSpan duration = DateTime.Now - start;
                m_EventTime = duration.TotalMilliseconds;
                return reText;
            }
            else
            {
                return SegmentText(strText);
            }
        }

        #region �P�_�r������
        /// <summary>
        /// �P�_�r������,0������,1���Ʀr,2���r��,3���~�r,4���~�r�Ʀr
        /// </summary>
        private int GetCharType(string p_Char)
        {
            int CharType = 0;
            if (alNumber.Contains(p_Char)) CharType = 1;
            if (alWord.Contains(p_Char)) CharType = 2;
            if (htWords.ContainsKey(p_Char)) CharType += 3;
            return CharType;
        }
        #endregion

        #region ��[��������ƧǨí��s�g�J
        /// <summary>
        /// ��[��������ƧǨí��s�g�J
        /// </summary>
        public void SortDic()
        {
            SortDic(false);
        }

        /// <summary>
        /// ��[��������ƧǨí��s�g�J
        /// </summary>
        /// <param name="Reload">�O�_���s�[��</param>
        public void SortDic(bool Reload)
        {
            DateTime start = DateTime.Now;
            StreamWriter sw = new StreamWriter(DicPath, false, System.Text.Encoding.UTF8);

            IDictionaryEnumerator idEnumerator1 = htWords.GetEnumerator();
            while (idEnumerator1.MoveNext())
            {
                IDictionaryEnumerator idEnumerator2 = ((Hashtable)idEnumerator1.Value).GetEnumerator();
                while (idEnumerator2.MoveNext())
                {
                    SegList aa = (SegList)idEnumerator2.Value;
                    aa.Sort();
                    for (int i = 0; i < aa.Count; i++)
                    {
                        if (aa.GetElem(i).ToString() == "null")
                            sw.WriteLine(idEnumerator1.Key.ToString() + idEnumerator2.Key.ToString());
                        else
                            sw.WriteLine(idEnumerator1.Key.ToString() + idEnumerator2.Key.ToString() + aa.GetElem(i).ToString());
                    }
                }
            }
            sw.Close();

            if (Reload) InitWordDics();

            TimeSpan duration = DateTime.Now - start;
            m_EventTime = duration.TotalMilliseconds;
        }
        #endregion

        /// <summary>
        /// �R����槹���ۦP����,�ȮɵL��!
        /// </summary>
        /// <returns>�ۦP�����Ӽ�</returns>
        public int Optimize()
        {
            int l = 0;
            DateTime start = DateTime.Now;

            Hashtable htOptimize = new Hashtable();
            StreamReader reader = new StreamReader(DicPath, System.Text.Encoding.UTF8);
            string strline = reader.ReadLine();
            while (strline != null && strline.Trim() != "")
            {
                if (!htOptimize.ContainsKey(strline))
                    htOptimize.Add(strline, null);
                else
                    l++;
            }
            Console.WriteLine("ready");
            try
            {
                reader.Close();
            }
            catch { }
            StreamWriter sw = new StreamWriter(DicPath, false, System.Text.Encoding.UTF8);
            IDictionaryEnumerator ide = htOptimize.GetEnumerator();
            while (ide.MoveNext())
                sw.WriteLine(ide.Key.ToString());
            try
            {
                sw.Close();
            }
            catch { }
            TimeSpan duration = DateTime.Now - start;
            m_EventTime = duration.TotalMilliseconds;
            return l;
        }
        #endregion
    }
}