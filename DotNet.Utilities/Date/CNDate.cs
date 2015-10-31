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
    /// �A���ݩ�
    /// </summary>
    public class CNDate
    {
        /// <summary>
        /// �A��~(�㫬)
        /// </summary>
        public int cnIntYear = 0;
        /// <summary>
        /// �A����(�㫬)
        /// </summary>
        public int cnIntMonth = 0;
        /// <summary>
        /// �A���(�㫬)
        /// </summary>
        public int cnIntDay = 0;
        /// <summary>
        /// �A��~(��F)
        /// </summary>
        public string cnStrYear = "";
        /// <summary>
        /// �A����(�r��)
        /// </summary>
        public string cnStrMonth = "";
        /// <summary>
        /// �A���(�r��)
        /// </summary>
        public string cnStrDay = "";
        /// <summary>
        /// �A���ݶH
        /// </summary>
        public string cnAnm = "";
        /// <summary>
        /// �G�Q�|�`��
        /// </summary>
        public string cnSolarTerm = "";
        /// <summary>
        /// ����`��
        /// </summary>
        public string cnFtvl = "";
        /// <summary>
        /// ����`��
        /// </summary>
        public string cnFtvs = "";
    }

    /// <summary>
    /// ������A��
    /// </summary>
    public class ChinaDate
    {
        #region �p����k
        private static long[] lunarInfo = new long[] { 0x04bd8, 0x04ae0, 0x0a570, 0x054d5, 0x0d260, 0x0d950, 0x16554,
															   0x056a0, 0x09ad0, 0x055d2, 0x04ae0, 0x0a5b6, 0x0a4d0, 0x0d250, 0x1d255, 0x0b540, 0x0d6a0, 0x0ada2, 0x095b0,
															   0x14977, 0x04970, 0x0a4b0, 0x0b4b5, 0x06a50, 0x06d40, 0x1ab54, 0x02b60, 0x09570, 0x052f2, 0x04970, 0x06566,
															   0x0d4a0, 0x0ea50, 0x06e95, 0x05ad0, 0x02b60, 0x186e3, 0x092e0, 0x1c8d7, 0x0c950, 0x0d4a0, 0x1d8a6, 0x0b550,
															   0x056a0, 0x1a5b4, 0x025d0, 0x092d0, 0x0d2b2, 0x0a950, 0x0b557, 0x06ca0, 0x0b550, 0x15355, 0x04da0, 0x0a5d0,
															   0x14573, 0x052d0, 0x0a9a8, 0x0e950, 0x06aa0, 0x0aea6, 0x0ab50, 0x04b60, 0x0aae4, 0x0a570, 0x05260, 0x0f263,
															   0x0d950, 0x05b57, 0x056a0, 0x096d0, 0x04dd5, 0x04ad0, 0x0a4d0, 0x0d4d4, 0x0d250, 0x0d558, 0x0b540, 0x0b5a0,
															   0x195a6, 0x095b0, 0x049b0, 0x0a974, 0x0a4b0, 0x0b27a, 0x06a50, 0x06d40, 0x0af46, 0x0ab60, 0x09570, 0x04af5,
															   0x04970, 0x064b0, 0x074a3, 0x0ea50, 0x06b58, 0x055c0, 0x0ab60, 0x096d5, 0x092e0, 0x0c960, 0x0d954, 0x0d4a0,
															   0x0da50, 0x07552, 0x056a0, 0x0abb7, 0x025d0, 0x092d0, 0x0cab5, 0x0a950, 0x0b4a0, 0x0baa4, 0x0ad50, 0x055d9,
															   0x04ba0, 0x0a5b0, 0x15176, 0x052b0, 0x0a930, 0x07954, 0x06aa0, 0x0ad50, 0x05b52, 0x04b60, 0x0a6e6, 0x0a4e0,
															   0x0d260, 0x0ea65, 0x0d530, 0x05aa0, 0x076a3, 0x096d0, 0x04bd7, 0x04ad0, 0x0a4d0, 0x1d0b6, 0x0d250, 0x0d520,
															   0x0dd45, 0x0b5a0, 0x056d0, 0x055b2, 0x049b0, 0x0a577, 0x0a4b0, 0x0aa50, 0x1b255, 0x06d20, 0x0ada0 };

        private static int[] year20 = new int[] { 1, 4, 1, 2, 1, 2, 1, 1, 2, 1, 2, 1 };
        private static int[] year19 = new int[] { 0, 3, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0 };
        private static int[] year2000 = new int[] { 0, 3, 1, 2, 1, 2, 1, 1, 2, 1, 2, 1 };
        private static String[] nStr1 = new String[] { "", "��", "�G", "�T", "�|", "��", "��", "�C", "�K", "�E", "�Q", "�Q�@", "�Q�G" };
        private static String[] Gan = new String[] { "��", "�A", "��", "�B", "��", "�v", "��", "��", "��", "��" };
        private static String[] Zhi = new String[] { "�l", "��", "�G", "�f", "��", "�x", "��", "��", "��", "��", "��", "��" };
        private static String[] Animals = new String[] { "��", "��", "��", "��", "�s", "�D", "��", "��", "�U", "��", "��", "��" };
        private static String[] solarTerm = new String[] { "�p�H", "�j�H", "�߬K", "�B��", "���h", "�K��", "�M��", "���B", "�߮L", "�p��", "�~��", "�L��", "�p��", "�j��", "�߬�", "�B��", "���S", "���", "�H�S", "����", "�ߥV", "�p��", "�j��", "�V��" };
        private static int[] sTermInfo = { 0, 21208, 42467, 63836, 85337, 107014, 128867, 150921, 173149, 195551, 218072, 240693, 263343, 285989, 308563, 331033, 353350, 375494, 397447, 419210, 440795, 462224, 483532, 504758 };
        private static String[] lFtv = new String[] { "0101�A��K�`", "0202 �s���Y�`", "0115 ���d�`", "0505 �ݤȸ`", "0707 �C�i���H�`", "0815 ����`", "0909 �����`", "1208 þ�K�`", "1114 ���g���ͥͤ�", "1224 �p�~", "0100���i" };
        private static String[] sFtv = new String[] { "0101 �s�~����",
														 "0202 �@����a��",
														 "0207 ����n���n�D��",
														 "0210 ��ڮ�H�`",
														 "0214 ���H�`",
														 "0301 ��ڮ��\��",
														 "0303 ����R�դ�",
														 "0308 ��ڰ��k�`",
														 "0312 �Ӿ�` �]���s�u�@������",
														 "0314 ���ĵ���",
														 "0315 ��ڮ��O���v�q��",
														 "0317 �������` ��گ����",
														 "0321 �@�ɴ˪L�� �����رڪ[����ڤ�",
														 "0321 �@�ɨ�q��",
														 "0322 �@�ɤ���",
														 "0323 �@�ɮ�H��",
														 "0324 �@�ɨ��v���֯f��",
														 "0325 ���ꤤ�p�ǥͦw���Ш|��",
														 "0330 �ڰǴ��Z��g��",
														 "0401 �M�H�` ����R��å͹B�ʤ�(�|��) �|���ŶǤ�(�|��)",
														 "0407 �@�ɽåͤ�",
														 "0422 �@�ɦa�y��",
														 "0423 �@�ɹϮѩM���v��",
														 "0424 �ȫD�s�D�u�@�̤�",
														 "0501 ��ڳҰʸ`",
														 "0504 ���꤭�|�C�~�`",
														 "0505 �K�ʥF�f���v��",
														 "0508 �@�ɬ��Q�r��",
														 "0512 ����@�h�`",
														 "0515 ��ڮa�x��",
														 "0517 �@�ɹq�H��",
														 "0518 ��ڳժ��]��",
														 "0520 ����ǥ���i��",
														 "0523 ��ڤ�����",
														 "0531 �@�ɵL�Ϥ�",
														 "0601 ��ڨൣ�`",
														 "0605 �@�����Ҥ�",
														 "0606 ����R����",
														 "0617 ���v��z�ƩM�����",
														 "0623 ��ڶ��L�ǫg��",
														 "0625 ����g�a��",
														 "0626 ��ڤϬr�~��",
														 "0701 ����@���ҫ��Ҥ� �@�ɫؿv��",
														 "0702 �����|�O�̤�",
														 "0707 ����H���ܤ�Ԫ�������",
														 "0711 �@�ɤH�f��",
														 "0730 �D�w���k��",
														 "0801 ����حx�`",
														 "0808 ����k�l�`(�����`)",
														 "0815 �饻�����ŧG�L����뭰��",
														 "0908 ��ڱ����� ��ڷs�D�u�@�̤�",
														 "0910 �Юv�`",
														 "0914 �@�ɲM��a�y��",
														 "0916 ��گ��h�O�@��",
														 "0918 �E�P�@�K���ܬ�����",
														 "0920 ����R����",
														 "0927 �@�ɮȹC��",
														 "1001 ��y�` �@�ɭ��֤� ��ڦѤH�`",
														 "1001 ��ڭ��֤�",
														 "1002 ��کM���P���D�ۥѰ�����",
														 "1004 �@�ɰʪ���",
														 "1008 ���갪������",
														 "1008 �@�ɵ�ı��",
														 "1009 �@�ɶl�F�� �U��l�p��",
														 "1010 ���譲�R������ �@�ɺ믫�åͤ�",
														 "1013 �@�ɫO���� ��ڱЮv�`",
														 "1014 �@�ɼзǤ�",
														 "1015 ��ڪ��H�`(�դ���`)",
														 "1016 �@��³����",
														 "1017 �@�ɮ����h�x��",
														 "1022 �@�ɶǲ����Ĥ�",
														 "1024 �p�X��� �@�ɵo�i�H����",
														 "1031 �@�ɶԻ���",
														 "1107 �Q����|�D�q���R������",
														 "1108 ����O�̤�",
														 "1109 ��������w���ŶǱШ|��",
														 "1110 �@�ɫC�~�`",
														 "1111 ��ڬ�ǻP�M���P(������ݪ��@�P)",
														 "1112 �]���s�Ϩ�������",
														 "1114 �@�ɿ}���f��",
														 "1117 ��ڤj�ǥ͸` �@�ɾǥ͸`",
														 "1121 �@�ɰݭԤ� �@�ɹq����",
														 "1129 ����n���ڰǴ��Z�H����ڤ�",
														 "1201 �@�ɦ���f��",
														 "1203 �@�ɴݯe�H��",
														 "1205 ��ڸg�٩M���|�o�i���@�H����",
														 "1208 ��ڨൣ�q����",
														 "1209 �@�ɨ��y��",
														 "1210 �@�ɤH�v��",
														 "1212 ��w���ܬ�����",
														 "1213 �n�ʤj�O��(1937�~)������I��O��\�v�I",
														 "1221 ����x�y��",
														 "1224 ���w�]",
														 "1225 �t�ϸ`",
														 "1226 ��D�u�Ϩ�",
														 "1229 ��ڥͪ��h�˩ʤ�" };


        /// <summary>
        /// �Ǧ^�A��y�~���`�Ѽ�
        /// </summary>
        private static int lYearDays(int y)
        {
            int i, sum = 348;
            for (i = 0x8000; i > 0x8; i >>= 1)
            {
                if ((lunarInfo[y - 1900] & i) != 0)
                    sum += 1;
            }
            return (sum + leapDays(y));
        }

        /// <summary>
        /// �Ǧ^�A��y�~�|�몺�Ѽ�
        /// </summary>
        private static int leapDays(int y)
        {
            if (leapMonth(y) != 0)
            {
                if ((lunarInfo[y - 1900] & 0x10000) != 0)
                    return 30;
                else
                    return 29;
            }
            else
                return 0;
        }

        /// <summary>
        /// �Ǧ^�A��y�~�|���Ӥ� 1-12 , �S�|�Ǧ^ 0
        /// </summary>
        private static int leapMonth(int y)
        {
            return (int)(lunarInfo[y - 1900] & 0xf);
        }

        /// <summary>
        /// �Ǧ^�A��y�~m�몺�`�Ѽ�
        /// </summary>
        private static int monthDays(int y, int m)
        {
            if ((lunarInfo[y - 1900] & (0x10000 >> m)) == 0)
                return 29;
            else
                return 30;
        }

        /// <summary>
        /// �Ǧ^�A��y�~���ͨv
        /// </summary>
        private static String AnimalsYear(int y)
        {
            return Animals[(y - 4) % 12];
        }

        /// <summary>
        /// �ǤJ��骺offset �Ǧ^�z��,0=�Ҥl
        /// </summary>
        private static String cyclicalm(int num)
        {
            return (Gan[num % 10] + Zhi[num % 12]);
        }

        /// <summary>
        /// �ǤJoffset �Ǧ^�z��, 0=�Ҥl
        /// </summary>
        private static String cyclical(int y)
        {
            int num = y - 1900 + 36;
            return (cyclicalm(num));
        }

        /// <summary>
        /// �ǥX�A��.year0 .month1 .day2 .yearCyl3 .monCyl4 .dayCyl5 .isLeap6
        /// </summary>
        private long[] Lunar(int y, int m)
        {
            long[] nongDate = new long[7];
            int i = 0, temp = 0, leap = 0;
            DateTime baseDate = new DateTime(1900 + 1900, 2, 31);
            DateTime objDate = new DateTime(y + 1900, m + 1, 1);
            TimeSpan ts = objDate - baseDate;
            long offset = (long)ts.TotalDays;
            if (y < 2000)
                offset += year19[m - 1];
            if (y > 2000)
                offset += year20[m - 1];
            if (y == 2000)
                offset += year2000[m - 1];
            nongDate[5] = offset + 40;
            nongDate[4] = 14;

            for (i = 1900; i < 2050 && offset > 0; i++)
            {
                temp = lYearDays(i);
                offset -= temp;
                nongDate[4] += 12;
            }
            if (offset < 0)
            {
                offset += temp;
                i--;
                nongDate[4] -= 12;
            }
            nongDate[0] = i;
            nongDate[3] = i - 1864;
            leap = leapMonth(i); // �|���Ӥ�
            nongDate[6] = 0;

            for (i = 1; i < 13 && offset > 0; i++)
            {
                // �|��
                if (leap > 0 && i == (leap + 1) && nongDate[6] == 0)
                {
                    --i;
                    nongDate[6] = 1;
                    temp = leapDays((int)nongDate[0]);
                }
                else
                {
                    temp = monthDays((int)nongDate[0], i);
                }

                // �Ѱ��|��
                if (nongDate[6] == 1 && i == (leap + 1))
                    nongDate[6] = 0;
                offset -= temp;
                if (nongDate[6] == 0)
                    nongDate[4]++;
            }

            if (offset == 0 && leap > 0 && i == leap + 1)
            {
                if (nongDate[6] == 1)
                {
                    nongDate[6] = 0;
                }
                else
                {
                    nongDate[6] = 1;
                    --i;
                    --nongDate[4];
                }
            }
            if (offset < 0)
            {
                offset += temp;
                --i;
                --nongDate[4];
            }
            nongDate[1] = i;
            nongDate[2] = offset + 1;
            return nongDate;
        }

        /// <summary>
        /// �ǥXy�~m��d��������A��.year0 .month1 .day2 .yearCyl3 .monCyl4 .dayCyl5 .isLeap6
        /// </summary>
        private static long[] calElement(int y, int m, int d)
        {
            long[] nongDate = new long[7];
            int i = 0, temp = 0, leap = 0;

            DateTime baseDate = new DateTime(1900, 1, 31);

            DateTime objDate = new DateTime(y, m, d);
            TimeSpan ts = objDate - baseDate;

            long offset = (long)ts.TotalDays;

            nongDate[5] = offset + 40;
            nongDate[4] = 14;

            for (i = 1900; i < 2050 && offset > 0; i++)
            {
                temp = lYearDays(i);
                offset -= temp;
                nongDate[4] += 12;
            }
            if (offset < 0)
            {
                offset += temp;
                i--;
                nongDate[4] -= 12;
            }
            nongDate[0] = i;
            nongDate[3] = i - 1864;
            leap = leapMonth(i); // �|���Ӥ�
            nongDate[6] = 0;

            for (i = 1; i < 13 && offset > 0; i++)
            {
                // �|��
                if (leap > 0 && i == (leap + 1) && nongDate[6] == 0)
                {
                    --i;
                    nongDate[6] = 1;
                    temp = leapDays((int)nongDate[0]);
                }
                else
                {
                    temp = monthDays((int)nongDate[0], i);
                }

                // �Ѱ��|��
                if (nongDate[6] == 1 && i == (leap + 1))
                    nongDate[6] = 0;
                offset -= temp;
                if (nongDate[6] == 0)
                    nongDate[4]++;
            }

            if (offset == 0 && leap > 0 && i == leap + 1)
            {
                if (nongDate[6] == 1)
                {
                    nongDate[6] = 0;
                }
                else
                {
                    nongDate[6] = 1;
                    --i;
                    --nongDate[4];
                }
            }
            if (offset < 0)
            {
                offset += temp;
                --i;
                --nongDate[4];
            }
            nongDate[1] = i;
            nongDate[2] = offset + 1;
            return nongDate;
        }

        private static String getChinaDate(int day)
        {
            String a = "";
            if (day == 10)
                return "��Q";
            if (day == 20)
                return "�G�Q";
            if (day == 30)
                return "�T�Q";
            int two = (int)((day) / 10);
            if (two == 0)
                a = "��";
            if (two == 1)
                a = "�Q";
            if (two == 2)
                a = "��";
            if (two == 3)
                a = "�T";
            int one = (int)(day % 10);
            switch (one)
            {
                case 1:
                    a += "�@";
                    break;
                case 2:
                    a += "�G";
                    break;
                case 3:
                    a += "�T";
                    break;
                case 4:
                    a += "�|";
                    break;
                case 5:
                    a += "��";
                    break;
                case 6:
                    a += "��";
                    break;
                case 7:
                    a += "�C";
                    break;
                case 8:
                    a += "�K";
                    break;
                case 9:
                    a += "�E";
                    break;
            }
            return a;
        }

        private static DateTime sTerm(int y, int n)
        {
            double ms = 31556925974.7 * (y - 1900);
            double ms1 = sTermInfo[n];
            DateTime offDate = new DateTime(1900, 1, 6, 2, 5, 0);
            offDate = offDate.AddMilliseconds(ms);
            offDate = offDate.AddMinutes(ms1);
            return offDate;
        }

        static string FormatDate(int m, int d)
        {
            return string.Format("{0:00}{1:00}", m, d);
        }
        #endregion

        #region ������k
        /// <summary>
        /// �Ǧ^����y�~m�몺�`�Ѽ�
        /// </summary>
        public static int GetDaysByMonth(int y, int m)
        {
            int[] days = new int[] { 31, DateTime.IsLeapYear(y) ? 29 : 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            return days[m - 1];
        }

        /// <summary>
        /// �ھڤ������o�g�@�����
        /// </summary>
        /// <param name="dt">��J���</param>
        /// <returns>�g�@�����</returns>
        public static DateTime GetMondayDateByDate(DateTime dt)
        {
            double d = 0;
            switch ((int)dt.DayOfWeek)
            {
                //case 1: d = 0; break;
                case 2: d = -1; break;
                case 3: d = -2; break;
                case 4: d = -3; break;
                case 5: d = -4; break;
                case 6: d = -5; break;
                case 0: d = -6; break;
            }
            return dt.AddDays(d);
        }

        /// <summary>
        /// ����A��
        /// </summary>
        public static CNDate getChinaDate(DateTime dt)
        {
            CNDate cd = new CNDate();
            int year = dt.Year;
            int month = dt.Month;
            int date = dt.Day;
            long[] l = calElement(year, month, date);
            cd.cnIntYear = (int)l[0];
            cd.cnIntMonth = (int)l[1];
            cd.cnIntDay = (int)l[2];
            cd.cnStrYear = cyclical(year);
            cd.cnAnm = AnimalsYear(year);
            cd.cnStrMonth = nStr1[(int)l[1]];
            cd.cnStrDay = getChinaDate((int)(l[2]));
            string smd = dt.ToString("MMdd");

            string lmd = FormatDate(cd.cnIntMonth, cd.cnIntDay);
            for (int i = 0; i < solarTerm.Length; i++)
            {
                string s1 = sTerm(dt.Year, i).ToString("MMdd");
                if (s1.Equals(dt.ToString("MMdd")))
                {
                    cd.cnSolarTerm = solarTerm[i];
                    break;
                }
            }
            foreach (string s in sFtv)
            {
                string s1 = s.Substring(0, 4);
                if (s1.Equals(smd))
                {
                    cd.cnFtvs = s.Substring(4, s.Length - 4);
                    break;
                }
            }
            foreach (string s in lFtv)
            {
                string s1 = s.Substring(0, 4);
                if (s1.Equals(lmd))
                {
                    cd.cnFtvl = s.Substring(4, s.Length - 4);
                    break;
                }
            }
            dt = dt.AddDays(1);
            year = dt.Year;
            month = dt.Month;
            date = dt.Day;
            l = calElement(year, month, date);
            lmd = FormatDate((int)l[1], (int)l[2]);
            if (lmd.Equals("0101")) cd.cnFtvl = "���i";
            return cd;
        }
        #endregion
    }

    /// <summary>
    /// ������
    /// </summary>
    //-------------------------------------------------------------------------------
    //�ե�:
    //ChineseCalendar c = new ChineseCalendar(new DateTime(1990, 01, 15));
    //StringBuilder dayInfo = new StringBuilder();
    //dayInfo.Append("����G" + c.DateString + "\r\n");
    //dayInfo.Append("�A��G" + c.ChineseDateString + "\r\n");
    //dayInfo.Append("�P���G" + c.WeekDayStr);
    //dayInfo.Append("�ɨ��G" + c.ChineseHour + "\r\n");
    //dayInfo.Append("�ݬۡG" + c.AnimalString + "\r\n");
    //dayInfo.Append("�`��G" + c.ChineseTwentyFourDay + "\r\n");
    //dayInfo.Append("�e�@�Ӹ`��G" + c.ChineseTwentyFourPrevDay + "\r\n");
    //dayInfo.Append("�U�@�Ӹ`��G" + c.ChineseTwentyFourNextDay + "\r\n");
    //dayInfo.Append("�`��G" + c.DateHoliday + "\r\n");
    //dayInfo.Append("�z��G" + c.GanZhiDateString + "\r\n");
    //dayInfo.Append("�P�J�G" + c.ChineseConstellation + "\r\n");
    //dayInfo.Append("�P�y�G" + c.Constellation + "\r\n");
    //-------------------------------------------------------------------------------
    public class ChineseCalendar
    {
        #region �������c
        /// <summary>
        /// ����
        /// </summary>
        private struct SolarHolidayStruct
        {
            public int Month;
            public int Day;
            public int Recess; //��������
            public string HolidayName;
            public SolarHolidayStruct(int month, int day, int recess, string name)
            {
                Month = month;
                Day = day;
                Recess = recess;
                HolidayName = name;
            }
        }

        /// <summary>
        /// �A��
        /// </summary>
        private struct LunarHolidayStruct
        {
            public int Month;
            public int Day;
            public int Recess;
            public string HolidayName;

            public LunarHolidayStruct(int month, int day, int recess, string name)
            {
                Month = month;
                Day = day;
                Recess = recess;
                HolidayName = name;
            }
        }

        private struct WeekHolidayStruct
        {
            public int Month;
            public int WeekAtMonth;
            public int WeekDay;
            public string HolidayName;

            public WeekHolidayStruct(int month, int weekAtMonth, int weekDay, string name)
            {
                Month = month;
                WeekAtMonth = weekAtMonth;
                WeekDay = weekDay;
                HolidayName = name;
            }
        }
        #endregion

        #region �����ܶq
        private DateTime _date;
        private DateTime _datetime;
        private int _cYear;
        private int _cMonth;
        private int _cDay;
        private bool _cIsLeapMonth; //���O�_�|��
        private bool _cIsLeapYear;  //��~�O�_���|��
        #endregion

        #region ��¦�ƾ�
        #region �򥻱`�q
        private const int MinYear = 1900;
        private const int MaxYear = 2050;
        private static DateTime MinDay = new DateTime(1900, 1, 30);
        private static DateTime MaxDay = new DateTime(2049, 12, 31);
        private const int GanZhiStartYear = 1864; //�z��p��_�l�~
        private static DateTime GanZhiStartDay = new DateTime(1899, 12, 22);//�_�l��
        private const string HZNum = "�s�@�G�T�|�����C�K�E";
        private const int AnimalStartYear = 1900; //1900�~�����~
        private static DateTime ChineseConstellationReferDay = new DateTime(2007, 9, 13);//28�P�J�Ѧҭ�,���鬰��
        #endregion

        #region ����ƾ�
        /// <summary>
        /// �ӷ�����W���A��ƾ�
        /// </summary>
        /// <remarks>
        /// �ƾڵ��c�p�U�A�@�ϥ�17��ƾ�
        /// ��17��G��ܶ|��ѼơA0���29��   1���30��
        /// ��16��-��5��]�@12��^���12�Ӥ�A�䤤��16���ܲĤ@��A�p�G�Ӥ묰30�ѫh��1�A29�Ѭ�0
        /// ��4��-��1��]�@4��^��ܶ|��O���Ӥ�A�p�G��~�S���|��A�h�m0
        ///</remarks>
        private static int[] LunarDateArray = new int[]{
                0x04BD8,0x04AE0,0x0A570,0x054D5,0x0D260,0x0D950,0x16554,0x056A0,0x09AD0,0x055D2,
                0x04AE0,0x0A5B6,0x0A4D0,0x0D250,0x1D255,0x0B540,0x0D6A0,0x0ADA2,0x095B0,0x14977,
                0x04970,0x0A4B0,0x0B4B5,0x06A50,0x06D40,0x1AB54,0x02B60,0x09570,0x052F2,0x04970,
                0x06566,0x0D4A0,0x0EA50,0x06E95,0x05AD0,0x02B60,0x186E3,0x092E0,0x1C8D7,0x0C950,
                0x0D4A0,0x1D8A6,0x0B550,0x056A0,0x1A5B4,0x025D0,0x092D0,0x0D2B2,0x0A950,0x0B557,
                0x06CA0,0x0B550,0x15355,0x04DA0,0x0A5B0,0x14573,0x052B0,0x0A9A8,0x0E950,0x06AA0,
                0x0AEA6,0x0AB50,0x04B60,0x0AAE4,0x0A570,0x05260,0x0F263,0x0D950,0x05B57,0x056A0,
                0x096D0,0x04DD5,0x04AD0,0x0A4D0,0x0D4D4,0x0D250,0x0D558,0x0B540,0x0B6A0,0x195A6,
                0x095B0,0x049B0,0x0A974,0x0A4B0,0x0B27A,0x06A50,0x06D40,0x0AF46,0x0AB60,0x09570,
                0x04AF5,0x04970,0x064B0,0x074A3,0x0EA50,0x06B58,0x055C0,0x0AB60,0x096D5,0x092E0,
                0x0C960,0x0D954,0x0D4A0,0x0DA50,0x07552,0x056A0,0x0ABB7,0x025D0,0x092D0,0x0CAB5,
                0x0A950,0x0B4A0,0x0BAA4,0x0AD50,0x055D9,0x04BA0,0x0A5B0,0x15176,0x052B0,0x0A930,
                0x07954,0x06AA0,0x0AD50,0x05B52,0x04B60,0x0A6E6,0x0A4E0,0x0D260,0x0EA65,0x0D530,
                0x05AA0,0x076A3,0x096D0,0x04BD7,0x04AD0,0x0A4D0,0x1D0B6,0x0D250,0x0D520,0x0DD45,
                0x0B5A0,0x056D0,0x055B2,0x049B0,0x0A577,0x0A4B0,0x0AA50,0x1B255,0x06D20,0x0ADA0,
                0x14B63        
                };

        #endregion

        #region �P�y�W��
        private static string[] _constellationName = 
                { 
                    "�զϮy", "�����y", "���l�y", 
                    "���ɮy", "��l�y", "�B�k�y", 
                    "�ѯ��y", "���Ȯy", "�g��y", 
                    "���~�y", "���~�y", "�����y"
                };
        #endregion

        #region �G�Q�|�`��
        private static string[] _lunarHolidayName = 
                    { 
                    "�p�H", "�j�H", "�߬K", "�B��", 
                    "���h", "�K��", "�M��", "���B", 
                    "�߮L", "�p��", "�~��", "�L��", 
                    "�p��", "�j��", "�߬�", "�B��", 
                    "���S", "���", "�H�S", "����", 
                    "�ߥV", "�p��", "�j��", "�V��"
                    };
        #endregion

        #region �G�Q�K�P�J
        private static string[] _chineseConstellationName =
            {
                  //�|        ��      ��         ��        �@      �G      �T  
                "�����","�����s","�k�g��","�Ф��","�ߤ몰","������","�ߤ��\",
                "����^","������","�¤g��","��鹫","�M��P","�Ǥ���","�����z",
                "����T","������","�G�g��","������","����Q","�C���U","�Ѥ���",
                "�����C","������","�h�g��","�P�鰨","�i���","�l���D","�H���C" 
            };
        #endregion

        #region �`��ƾ�
        private static string[] SolarTerm = new string[] { "�p�H", "�j�H", "�߬K", "�B��", "���h", "�K��", "�M��", "���B", "�߮L", "�p��", "�~��", "�L��", "�p��", "�j��", "�߬�", "�B��", "���S", "���", "�H�S", "����", "�ߥV", "�p��", "�j��", "�V��" };
        private static int[] sTermInfo = new int[] { 0, 21208, 42467, 63836, 85337, 107014, 128867, 150921, 173149, 195551, 218072, 240693, 263343, 285989, 308563, 331033, 353350, 375494, 397447, 419210, 440795, 462224, 483532, 504758 };
        #endregion

        #region �A������ƾ�
        private static string ganStr = "�ҤA���B���v�����Ь�";
        private static string zhiStr = "�l���G�f���x�ȥ��Ө�����";
        private static string animalStr = "��������s�D���ϵU������";
        private static string nStr1 = "��@�G�T�|�����C�K�E";
        private static string nStr2 = "��Q�ܤ�";
        private static string[] _monthString =
                {
                    "�X��","����","�G��","�T��","�|��","����","����","�C��","�K��","�E��","�Q��","�Q�@��","þ��"
                };
        #endregion

        #region �������p�⪺�`��
        private static SolarHolidayStruct[] sHolidayInfo = new SolarHolidayStruct[]{
            new SolarHolidayStruct(1, 1, 1, "����"),
            new SolarHolidayStruct(2, 2, 0, "�@����a��"),
            new SolarHolidayStruct(2, 10, 0, "��ڮ�H�`"),
            new SolarHolidayStruct(2, 14, 0, "���H�`"),
            new SolarHolidayStruct(3, 1, 0, "��ڮ��\��"),
            new SolarHolidayStruct(3, 5, 0, "�ǹp�W������"),
            new SolarHolidayStruct(3, 8, 0, "���k�`"), 
            new SolarHolidayStruct(3, 12, 0, "�Ӿ�` �]���s�u�@������"), 
            new SolarHolidayStruct(3, 14, 0, "���ĵ���"),
            new SolarHolidayStruct(3, 15, 0, "���O���v�q��"),
            new SolarHolidayStruct(3, 17, 0, "�������` ��گ����"),
            new SolarHolidayStruct(3, 21, 0, "�@�ɴ˪L�� �����رڪ[����ڤ� �@�ɨ�q��"),
            new SolarHolidayStruct(3, 22, 0, "�@�ɤ���"),
            new SolarHolidayStruct(3, 24, 0, "�@�ɨ��v���֯f��"),
            new SolarHolidayStruct(4, 1, 0, "�M�H�`"),
            new SolarHolidayStruct(4, 7, 0, "�@�ɽåͤ�"),
            new SolarHolidayStruct(4, 22, 0, "�@�ɦa�y��"),
            new SolarHolidayStruct(5, 1, 1, "�Ұʸ`"), 
            new SolarHolidayStruct(5, 2, 1, "�Ұʸ`����"),
            new SolarHolidayStruct(5, 3, 1, "�Ұʸ`����"),
            new SolarHolidayStruct(5, 4, 0, "�C�~�`"), 
            new SolarHolidayStruct(5, 8, 0, "�@�ɬ��Q�r��"),
            new SolarHolidayStruct(5, 12, 0, "����@�h�`"), 
            new SolarHolidayStruct(5, 31, 0, "�@�ɵL�Ϥ�"), 
            new SolarHolidayStruct(6, 1, 0, "��ڨൣ�`"), 
            new SolarHolidayStruct(6, 5, 0, "�@�����ҫO�@��"),
            new SolarHolidayStruct(6, 26, 0, "��ڸT�r��"),
            new SolarHolidayStruct(7, 1, 0, "���Ҹ` ����^�k���� �@�ɫؿv��"),
            new SolarHolidayStruct(7, 11, 0, "�@�ɤH�f��"),
            new SolarHolidayStruct(8, 1, 0, "�حx�`"), 
            new SolarHolidayStruct(8, 8, 0, "����k�l�` ���˸`"),
            new SolarHolidayStruct(8, 15, 0, "�ܤ�Ԫ��ӧQ����"),
            new SolarHolidayStruct(9, 9, 0, "��D�u�u�@����"), 
            new SolarHolidayStruct(9, 10, 0, "�Юv�`"), 
            new SolarHolidayStruct(9, 18, 0, "�E�P�@�K���ܬ�����"),
            new SolarHolidayStruct(9, 20, 0, "��ڷR����"),
            new SolarHolidayStruct(9, 27, 0, "�@�ɮȹC��"),
            new SolarHolidayStruct(9, 28, 0, "�դl�Ϩ�"),
            new SolarHolidayStruct(10, 1, 1, "��y�` ��ڭ��֤�"),
            new SolarHolidayStruct(10, 2, 1, "��y�`����"),
            new SolarHolidayStruct(10, 3, 1, "��y�`����"),
            new SolarHolidayStruct(10, 6, 0, "�ѤH�`"), 
            new SolarHolidayStruct(10, 24, 0, "�p�X���"),
            new SolarHolidayStruct(11, 10, 0, "�@�ɫC�~�`"),
            new SolarHolidayStruct(11, 12, 0, "�]���s�Ϩ�����"), 
            new SolarHolidayStruct(12, 1, 0, "�@�ɦ���f��"), 
            new SolarHolidayStruct(12, 3, 0, "�@�ɴݯe�H��"), 
            new SolarHolidayStruct(12, 20, 0, "�D���^�k����"), 
            new SolarHolidayStruct(12, 24, 0, "���w�]"), 
            new SolarHolidayStruct(12, 25, 0, "�t�ϸ`"), 
            new SolarHolidayStruct(12, 26, 0, "��D�u�Ϩ�����")
           };
        #endregion

        #region ���A��p�⪺�`��
        private static LunarHolidayStruct[] lHolidayInfo = new LunarHolidayStruct[]{
            new LunarHolidayStruct(1, 1, 1, "�K�`"), 
            new LunarHolidayStruct(1, 15, 0, "���d�`"), 
            new LunarHolidayStruct(5, 5, 0, "�ݤȸ`"), 
            new LunarHolidayStruct(7, 7, 0, "�C�i���H�`"),
            new LunarHolidayStruct(7, 15, 0, "�����` �����ָ`"), 
            new LunarHolidayStruct(8, 15, 0, "����`"), 
            new LunarHolidayStruct(9, 9, 0, "�����`"), 
            new LunarHolidayStruct(12, 8, 0, "þ�K�`"),
            new LunarHolidayStruct(12, 23, 0, "�_��p�~(����)"),
            new LunarHolidayStruct(12, 24, 0, "�n��p�~(帹�)"),
            //new LunarHolidayStruct(12, 30, 0, "���i")  //�`�N���i�ݭn�䥦��k�i��p��
        };
        #endregion

        #region ���Y��ĴX�ӬP���X
        private static WeekHolidayStruct[] wHolidayInfo = new WeekHolidayStruct[]{
            new WeekHolidayStruct(5, 2, 1, "���˸`"), 
            new WeekHolidayStruct(5, 3, 1, "����U�ݤ�"), 
            new WeekHolidayStruct(6, 3, 1, "���˸`"), 
            new WeekHolidayStruct(9, 3, 3, "��کM����"), 
            new WeekHolidayStruct(9, 4, 1, "���Ť�H�`"), 
            new WeekHolidayStruct(10, 1, 2, "��ڦ�Ф�"), 
            new WeekHolidayStruct(10, 1, 4, "��ڴ�۵M�a�`��"),
            new WeekHolidayStruct(11, 4, 5, "�P���`")
        };
        #endregion
        #endregion

        #region �c�y���
        #region ���������l��
        /// <summary>
        /// �Τ@�ӼзǪ���������Ӫ�Ϥ�
        /// </summary>
        public ChineseCalendar(DateTime dt)
        {
            int i;
            int leap;
            int temp;
            int offset;

            CheckDateLimit(dt);

            _date = dt.Date;
            _datetime = dt;

            //�A�����p�ⳡ��
            leap = 0;
            temp = 0;

            //�p���Ѫ��򥻮t�Z
            TimeSpan ts = _date - ChineseCalendar.MinDay;
            offset = ts.Days;

            for (i = MinYear; i <= MaxYear; i++)
            {
                //�D��~�A��~�Ѽ�
                temp = GetChineseYearDays(i);
                if (offset - temp < 1)
                    break;
                else
                {
                    offset = offset - temp;
                }
            }
            _cYear = i;

            //�p��Ӧ~�|���Ӥ�
            leap = GetChineseLeapMonth(_cYear);

            //�]�w��~�O�_���|��
            if (leap > 0)
            {
                _cIsLeapYear = true;
            }
            else
            {
                _cIsLeapYear = false;
            }

            _cIsLeapMonth = false;
            for (i = 1; i <= 12; i++)
            {
                //�|��
                if ((leap > 0) && (i == leap + 1) && (_cIsLeapMonth == false))
                {
                    _cIsLeapMonth = true;
                    i = i - 1;
                    temp = GetChineseLeapMonthDays(_cYear); //�p��|��Ѽ�
                }
                else
                {
                    _cIsLeapMonth = false;
                    temp = GetChineseMonthDays(_cYear, i);  //�p��D�|��Ѽ�
                }

                offset = offset - temp;
                if (offset <= 0) break;
            }

            offset = offset + temp;
            _cMonth = i;
            _cDay = offset;
        }
        #endregion

        #region �A������l��
        /// <summary>
        /// �ιA�䪺����Ӫ�Ϥ�
        /// </summary>
        /// <param name="cy">�A��~</param>
        /// <param name="cm">�A���</param>
        /// <param name="cd">�A���</param>
        /// <param name="LeapFlag">�|��лx</param>
        public ChineseCalendar(int cy, int cm, int cd, bool leapMonthFlag)
        {
            int i, leap, Temp, offset;

            CheckChineseDateLimit(cy, cm, cd, leapMonthFlag);

            _cYear = cy;
            _cMonth = cm;
            _cDay = cd;

            offset = 0;

            for (i = MinYear; i < cy; i++)
            {
                //�D��~�A��~�Ѽ�
                Temp = GetChineseYearDays(i);
                offset = offset + Temp;
            }

            //�p��Ӧ~���Ӷ|���Ӥ�
            leap = GetChineseLeapMonth(cy);
            if (leap != 0)
            {
                this._cIsLeapYear = true;
            }
            else
            {
                this._cIsLeapYear = false;
            }

            if (cm != leap)
            {
                //��e����ëD�|��
                _cIsLeapMonth = false;
            }
            else
            {
                //�ϥΥΤ��J���O�_�|����
                _cIsLeapMonth = leapMonthFlag;
            }

            //��~�S���|��||�p�����p��|��
            if ((_cIsLeapYear == false) || (cm < leap))
            {
                for (i = 1; i < cm; i++)
                {
                    Temp = GetChineseMonthDays(cy, i);//�p��D�|��Ѽ�
                    offset = offset + Temp;
                }

                //�ˬd����O�_�j��̤j��
                if (cd > GetChineseMonthDays(cy, cm))
                {
                    throw new Exception("���X�k���A����");
                }
                //�[�W��몺�Ѽ�
                offset = offset + cd;
            }

            //�O�|�~�A�B�p�����j��ε���|��
            else
            {
                for (i = 1; i < cm; i++)
                {
                    //�p��D�|��Ѽ�
                    Temp = GetChineseMonthDays(cy, i);
                    offset = offset + Temp;
                }

                //�p���j��|��
                if (cm > leap)
                {
                    Temp = GetChineseLeapMonthDays(cy);   //�p��|��Ѽ�
                    offset = offset + Temp;               //�[�W�|��Ѽ�

                    if (cd > GetChineseMonthDays(cy, cm))
                    {
                        throw new Exception("���X�k���A����");
                    }
                    offset = offset + cd;
                }

                //�p��뵥��|��
                else
                {
                    //�p�G�ݭn�p�⪺�O�|��A�h�������[�W�P�|����������q�몺�Ѽ�
                    if (this._cIsLeapMonth == true)         //�p��묰�|��
                    {
                        Temp = GetChineseMonthDays(cy, cm); //�p��D�|��Ѽ�
                        offset = offset + Temp;
                    }

                    if (cd > GetChineseLeapMonthDays(cy))
                    {
                        throw new Exception("���X�k���A����");
                    }
                    offset = offset + cd;
                }
            }
            _date = MinDay.AddDays(offset);
        }
        #endregion
        #endregion

        #region �p�����
        #region GetChineseMonthDays
        /// <summary>
        /// //�Ǧ^�A��y�~m�몺�`�Ѽ�
        /// </summary>
        private int GetChineseMonthDays(int year, int month)
        {
            if (BitTest32((LunarDateArray[year - MinYear] & 0x0000FFFF), (16 - month)))
            {
                return 30;
            }
            else
            {
                return 29;
            }
        }
        #endregion

        #region GetChineseLeapMonth
        /// <summary>
        /// �Ǧ^�A�� y�~�|���Ӥ� 1-12 , �S�|�Ǧ^ 0
        /// </summary>
        private int GetChineseLeapMonth(int year)
        {
            return LunarDateArray[year - MinYear] & 0xF;
        }
        #endregion

        #region GetChineseLeapMonthDays
        /// <summary>
        /// �Ǧ^�A��y�~�|�몺�Ѽ�
        /// </summary>
        private int GetChineseLeapMonthDays(int year)
        {
            if (GetChineseLeapMonth(year) != 0)
            {
                if ((LunarDateArray[year - MinYear] & 0x10000) != 0)
                {
                    return 30;
                }
                else
                {
                    return 29;
                }
            }
            else
            {
                return 0;
            }
        }
        #endregion

        #region GetChineseYearDays
        /// <summary>
        /// ���A��~�@�~���Ѽ�
        /// </summary>
        private int GetChineseYearDays(int year)
        {
            int i, f, sumDay, info;

            sumDay = 348; //29��*12�Ӥ�
            i = 0x8000;
            info = LunarDateArray[year - MinYear] & 0x0FFFF;

            //�p��12�Ӥ뤤���h�֤Ѭ�30��
            for (int m = 0; m < 12; m++)
            {
                f = info & i;
                if (f != 0)
                {
                    sumDay++;
                }
                i = i >> 1;
            }
            return sumDay + GetChineseLeapMonthDays(year);
        }
        #endregion

        #region GetChineseHour
        /// <summary>
        /// ��o��e�ɶ����ɨ�
        /// </summary> 
        private string GetChineseHour(DateTime dt)
        {
            int _hour, _minute, offset, i;
            int indexGan;
            string ganHour, zhiHour;
            string tmpGan;

            //�p��ɨ����a��
            _hour = dt.Hour;    //��o��e�ɶ��p��
            _minute = dt.Minute;  //��o��e�ɶ�����

            if (_minute != 0) _hour += 1;
            offset = _hour / 2;
            if (offset >= 12) offset = 0;
            //zhiHour = zhiStr[offset].ToString();

            //�p��Ѥz
            TimeSpan ts = this._date - GanZhiStartDay;
            i = ts.Days % 60;

            //ganStr[i % 10] ���骺�Ѥz,(n*2-1) %10�o�X�a�����,n�q1�}�l
            indexGan = ((i % 10 + 1) * 2 - 1) % 10 - 1;

            tmpGan = ganStr.Substring(indexGan) + ganStr.Substring(0, indexGan + 2);//���12��
            //ganHour = ganStr[((i % 10 + 1) * 2 - 1) % 10 - 1].ToString();

            return tmpGan[offset].ToString() + zhiStr[offset].ToString();
        }
        #endregion

        #region CheckDateLimit
        /// <summary>
        /// �ˬd��������O�_�ŦX�n�D
        /// </summary>
        private void CheckDateLimit(DateTime dt)
        {
            if ((dt < MinDay) || (dt > MaxDay))
            {
                throw new Exception("�W�X�i�ഫ�����");
            }
        }
        #endregion

        #region CheckChineseDateLimit
        /// <summary>
        /// �ˬd�A�����O�_�X�z
        /// </summary>
        private void CheckChineseDateLimit(int year, int month, int day, bool leapMonth)
        {
            if ((year < MinYear) || (year > MaxYear))
            {
                throw new Exception("�D�k�A����");
            }
            if ((month < 1) || (month > 12))
            {
                throw new Exception("�D�k�A����");
            }
            if ((day < 1) || (day > 30)) //���ꪺ��̦h30��
            {
                throw new Exception("�D�k�A����");
            }
            int leap = GetChineseLeapMonth(year);// �p��Ӧ~���Ӷ|���Ӥ�
            if ((leapMonth == true) && (month != leap))
            {
                throw new Exception("�D�k�A����");
            }
        }
        #endregion

        #region ConvertNumToChineseNum
        /// <summary>
        /// �N0-9�ন�~�r�Φ�
        /// </summary>
        private string ConvertNumToChineseNum(char n)
        {
            if ((n < '0') || (n > '9')) return "";
            switch (n)
            {
                case '0':
                    return HZNum[0].ToString();
                case '1':
                    return HZNum[1].ToString();
                case '2':
                    return HZNum[2].ToString();
                case '3':
                    return HZNum[3].ToString();
                case '4':
                    return HZNum[4].ToString();
                case '5':
                    return HZNum[5].ToString();
                case '6':
                    return HZNum[6].ToString();
                case '7':
                    return HZNum[7].ToString();
                case '8':
                    return HZNum[8].ToString();
                case '9':
                    return HZNum[9].ToString();
                default:
                    return "";
            }
        }
        #endregion

        #region BitTest32
        /// <summary>
        /// ���լY��O�_���u
        /// </summary>
        private bool BitTest32(int num, int bitpostion)
        {
            if ((bitpostion > 31) || (bitpostion < 0))
                throw new Exception("Error Param: bitpostion[0-31]:" + bitpostion.ToString());

            int bit = 1 << bitpostion;

            if ((num & bit) == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region ConvertDayOfWeek
        /// <summary>
        /// �N�P���X�ন�Ʀr���
        /// </summary>
        private int ConvertDayOfWeek(DayOfWeek dayOfWeek)
        {
            switch (dayOfWeek)
            {
                case DayOfWeek.Sunday:
                    return 1;
                case DayOfWeek.Monday:
                    return 2;
                case DayOfWeek.Tuesday:
                    return 3;
                case DayOfWeek.Wednesday:
                    return 4;
                case DayOfWeek.Thursday:
                    return 5;
                case DayOfWeek.Friday:
                    return 6;
                case DayOfWeek.Saturday:
                    return 7;
                default:
                    return 0;
            }
        }
        #endregion

        #region CompareWeekDayHoliday
        /// <summary>
        /// �����ѬO���O���w���ĩP�X
        /// </summary>
        private bool CompareWeekDayHoliday(DateTime date, int month, int week, int day)
        {
            bool ret = false;

            if (date.Month == month) //����ۦP
            {
                if (ConvertDayOfWeek(date.DayOfWeek) == day) //�P���X�ۦP
                {
                    DateTime firstDay = new DateTime(date.Year, date.Month, 1);//�ͦ����Ĥ@��
                    int i = ConvertDayOfWeek(firstDay.DayOfWeek);
                    int firWeekDays = 7 - ConvertDayOfWeek(firstDay.DayOfWeek) + 1; //�p��Ĥ@�P�Ѿl�Ѽ�

                    if (i > day)
                    {
                        if ((week - 1) * 7 + day + firWeekDays == date.Day)
                        {
                            ret = true;
                        }
                    }
                    else
                    {
                        if (day + firWeekDays + (week - 2) * 7 == date.Day)
                        {
                            ret = true;
                        }
                    }
                }
            }

            return ret;
        }
        #endregion
        #endregion

        #region  �ݩ�
        #region �`��
        #region newCalendarHoliday
        /// <summary>
        /// �p�⤤��A��`��
        /// </summary>
        public string newCalendarHoliday
        {
            get
            {
                string tempStr = "";
                if (this._cIsLeapMonth == false) //�|�뤣�p��`��
                {
                    foreach (LunarHolidayStruct lh in lHolidayInfo)
                    {
                        if ((lh.Month == this._cMonth) && (lh.Day == this._cDay))
                        {

                            tempStr = lh.HolidayName;
                            break;

                        }
                    }

                    //�ﰣ�i�i��S�O�B�z
                    if (this._cMonth == 12)
                    {
                        int i = GetChineseMonthDays(this._cYear, 12); //�p���~�A��12�몺�`�Ѽ�
                        if (this._cDay == i) //�p�G���̫�@��
                        {
                            tempStr = "���i";
                        }
                    }
                }
                return tempStr;
            }
        }
        #endregion

        #region WeekDayHoliday
        /// <summary>
        /// ���Y��ĴX�P�ĴX��p�⪺�`��
        /// </summary>
        public string WeekDayHoliday
        {
            get
            {
                string tempStr = "";
                foreach (WeekHolidayStruct wh in wHolidayInfo)
                {
                    if (CompareWeekDayHoliday(_date, wh.Month, wh.WeekAtMonth, wh.WeekDay))
                    {
                        tempStr = wh.HolidayName;
                        break;
                    }
                }
                return tempStr;
            }
        }
        #endregion

        #region DateHoliday
        /// <summary>
        /// ��������p�⪺�`��
        /// </summary>
        public string DateHoliday
        {
            get
            {
                string tempStr = "";

                foreach (SolarHolidayStruct sh in sHolidayInfo)
                {
                    if ((sh.Month == _date.Month) && (sh.Day == _date.Day))
                    {
                        tempStr = sh.HolidayName;
                        break;
                    }
                }
                return tempStr;
            }
        }
        #endregion
        #endregion

        #region �������
        #region Date
        /// <summary>
        /// ���������������
        /// </summary>
        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }
        #endregion

        #region WeekDay
        /// <summary>
        /// ���P���X
        /// </summary>
        public DayOfWeek WeekDay
        {
            get { return _date.DayOfWeek; }
        }
        #endregion

        #region WeekDayStr
        /// <summary>
        /// �P�X���r��
        /// </summary>
        public string WeekDayStr
        {
            get
            {
                switch (_date.DayOfWeek)
                {
                    case DayOfWeek.Sunday:
                        return "�P����";
                    case DayOfWeek.Monday:
                        return "�P���@";
                    case DayOfWeek.Tuesday:
                        return "�P���G";
                    case DayOfWeek.Wednesday:
                        return "�P���T";
                    case DayOfWeek.Thursday:
                        return "�P���|";
                    case DayOfWeek.Friday:
                        return "�P����";
                    default:
                        return "�P����";
                }
            }
        }
        #endregion

        #region DateString
        /// <summary>
        /// ������������ܪk �p�@�E�E�C�~�C��@��
        /// </summary>
        public string DateString
        {
            get
            {
                return "����" + this._date.ToLongDateString();
            }
        }
        #endregion

        #region IsLeapYear
        /// <summary>
        /// ��e�O�_�����|�~
        /// </summary>
        public bool IsLeapYear
        {
            get
            {
                return DateTime.IsLeapYear(this._date.Year);
            }
        }
        #endregion

        #region ChineseConstellation
        /// <summary>
        /// 28�P�J�p��
        /// </summary>
        public string ChineseConstellation
        {
            get
            {
                int offset = 0;
                int modStarDay = 0;

                TimeSpan ts = this._date - ChineseConstellationReferDay;
                offset = ts.Days;
                modStarDay = offset % 28;
                return (modStarDay >= 0 ? _chineseConstellationName[modStarDay] : _chineseConstellationName[27 + modStarDay]);
            }
        }
        #endregion

        #region ChineseHour
        /// <summary>
        /// �ɨ�
        /// </summary>
        public string ChineseHour
        {
            get
            {
                return GetChineseHour(_datetime);
            }
        }
        #endregion

        #endregion

        #region �A����
        #region IsChineseLeapMonth
        /// <summary>
        /// �O�_�|��
        /// </summary>
        public bool IsChineseLeapMonth
        {
            get { return this._cIsLeapMonth; }
        }
        #endregion

        #region IsChineseLeapYear
        /// <summary>
        /// ��~�O�_���|��
        /// </summary>
        public bool IsChineseLeapYear
        {
            get
            {
                return this._cIsLeapYear;
            }
        }
        #endregion

        #region ChineseDay
        /// <summary>
        /// �A���
        /// </summary>
        public int ChineseDay
        {
            get { return this._cDay; }
        }
        #endregion

        #region ChineseDayString
        /// <summary>
        /// �A��餤����
        /// </summary>
        public string ChineseDayString
        {
            get
            {
                switch (this._cDay)
                {
                    case 0:
                        return "";
                    case 10:
                        return "��Q";
                    case 20:
                        return "�G�Q";
                    case 30:
                        return "�T�Q";
                    default:
                        return nStr2[(int)(_cDay / 10)].ToString() + nStr1[_cDay % 10].ToString();

                }
            }
        }
        #endregion

        #region ChineseMonth
        /// <summary>
        /// �A�䪺���
        /// </summary>
        public int ChineseMonth
        {
            get { return this._cMonth; }
        }
        #endregion

        #region ChineseMonthString
        /// <summary>
        /// �A�����r�Ŧ�
        /// </summary>
        public string ChineseMonthString
        {
            get
            {
                return _monthString[this._cMonth];
            }
        }
        #endregion

        #region ChineseYear
        /// <summary>
        /// ���A��~��
        /// </summary>
        public int ChineseYear
        {
            get { return this._cYear; }
        }
        #endregion

        #region ChineseYearString
        /// <summary>
        /// ���A��~�r�Ŧ�p�A�@�E�E�C�~
        /// </summary>
        public string ChineseYearString
        {
            get
            {
                string tempStr = "";
                string num = this._cYear.ToString();
                for (int i = 0; i < 4; i++)
                {
                    tempStr += ConvertNumToChineseNum(num[i]);
                }
                return tempStr + "�~";
            }
        }
        #endregion

        #region ChineseDateString
        /// <summary>
        /// ���A������ܪk�G�A��@�E�E�C�~����줭
        /// </summary>
        public string ChineseDateString
        {
            get
            {
                if (this._cIsLeapMonth == true)
                {
                    return "�A��" + ChineseYearString + "�|" + ChineseMonthString + ChineseDayString;
                }
                else
                {
                    return "�A��" + ChineseYearString + ChineseMonthString + ChineseDayString;
                }
            }
        }
        #endregion

        #region ChineseTwentyFourDay
        /// <summary>
        /// �w��k�p��G�Q�|�`��,�G�Q�|�`��O���a�y����ӭp�⪺�A�ëD�O����p�⪺
        /// </summary>
        /// <remarks>
        /// �`�𪺩w�k����ءC�j�N��k�ĥΪ��٬�"���"�A�Y���ɶ���@�~������24���A
        /// �C�@�`�𥭧��o15�Ѧ��l�A�ҥH�S��"����"�C�{�N�A��ĥΪ��٬�"�w��"�A�Y
        /// ���a�y�b�y�D�W����m���зǡA�@�P360�X�A��`�𤧶��۹j15�X�C�ѩ�V�ܮɦa
        /// �y������I����A�B�ʳt�׸��֡A�]�ӤӶ��b���D�W����15�X���ɶ�����15�ѡC
        /// �L�ܫe�᪺���p���n�ۤϡA�Ӷ��b���D�W���ʸ��C�A�@�Ӹ`��F16�Ѥ��h�C�ĥ�
        /// �w��ɥi�H�O�ҬK�B�������M�b�ީ]����������ѡC
        /// </remarks>
        public string ChineseTwentyFourDay
        {
            get
            {
                DateTime baseDateAndTime = new DateTime(1900, 1, 6, 2, 5, 0); //#1/6/1900 2:05:00 AM#
                DateTime newDate;
                double num;
                int y;
                string tempStr = "";

                y = this._date.Year;

                for (int i = 1; i <= 24; i++)
                {
                    num = 525948.76 * (y - 1900) + sTermInfo[i - 1];

                    newDate = baseDateAndTime.AddMinutes(num);//�������p��
                    if (newDate.DayOfYear == _date.DayOfYear)
                    {
                        tempStr = SolarTerm[i - 1];
                        break;
                    }
                }
                return tempStr;
            }
        }

        //��e����e�@�ӳ̪�`��
        public string ChineseTwentyFourPrevDay
        {
            get
            {
                DateTime baseDateAndTime = new DateTime(1900, 1, 6, 2, 5, 0); //#1/6/1900 2:05:00 AM#
                DateTime newDate;
                double num;
                int y;
                string tempStr = "";

                y = this._date.Year;

                for (int i = 24; i >= 1; i--)
                {
                    num = 525948.76 * (y - 1900) + sTermInfo[i - 1];

                    newDate = baseDateAndTime.AddMinutes(num);//�������p��

                    if (newDate.DayOfYear < _date.DayOfYear)
                    {
                        tempStr = string.Format("{0}[{1}]", SolarTerm[i - 1], newDate.ToString("yyyy-MM-dd"));
                        break;
                    }
                }

                return tempStr;
            }

        }

        //��e�����@�ӳ̪�`��
        public string ChineseTwentyFourNextDay
        {
            get
            {
                DateTime baseDateAndTime = new DateTime(1900, 1, 6, 2, 5, 0); //#1/6/1900 2:05:00 AM#
                DateTime newDate;
                double num;
                int y;
                string tempStr = "";

                y = this._date.Year;

                for (int i = 1; i <= 24; i++)
                {
                    num = 525948.76 * (y - 1900) + sTermInfo[i - 1];

                    newDate = baseDateAndTime.AddMinutes(num);//�������p��

                    if (newDate.DayOfYear > _date.DayOfYear)
                    {
                        tempStr = string.Format("{0}[{1}]", SolarTerm[i - 1], newDate.ToString("yyyy-MM-dd"));
                        break;
                    }
                }
                return tempStr;
            }

        }
        #endregion
        #endregion

        #region �P�y
        /// <summary>
        /// �p����w������P�y�Ǹ� 
        /// </summary>
        public string Constellation
        {
            get
            {
                int index = 0;
                int y, m, d;
                y = _date.Year;
                m = _date.Month;
                d = _date.Day;
                y = m * 100 + d;

                if (((y >= 321) && (y <= 419))) { index = 0; }
                else if ((y >= 420) && (y <= 520)) { index = 1; }
                else if ((y >= 521) && (y <= 620)) { index = 2; }
                else if ((y >= 621) && (y <= 722)) { index = 3; }
                else if ((y >= 723) && (y <= 822)) { index = 4; }
                else if ((y >= 823) && (y <= 922)) { index = 5; }
                else if ((y >= 923) && (y <= 1022)) { index = 6; }
                else if ((y >= 1023) && (y <= 1121)) { index = 7; }
                else if ((y >= 1122) && (y <= 1221)) { index = 8; }
                else if ((y >= 1222) || (y <= 119)) { index = 9; }
                else if ((y >= 120) && (y <= 218)) { index = 10; }
                else if ((y >= 219) && (y <= 320)) { index = 11; }
                else { index = 0; }

                return _constellationName[index];
            }
        }
        #endregion

        #region �ݬ�
        #region Animal
        /// <summary>
        /// �p���ݬ۪����ޡA�`�N���M�ݬ۬O�H�A��~�ӰϧO���A���O�ثe�b��ڨϥΤ��O�������ӭp�⪺
        /// ���~��1,�䥦����
        /// </summary>
        public int Animal
        {
            get
            {
                int offset = _date.Year - AnimalStartYear;
                return (offset % 12) + 1;
            }
        }
        #endregion

        #region AnimalString
        /// <summary>
        /// ���ݬۦr�Ŧ�
        /// </summary>
        public string AnimalString
        {
            get
            {
                int offset = _date.Year - AnimalStartYear; //����p��
                //int offset = this._cYear - AnimalStartYear;�@�A��p��
                return animalStr[offset % 12].ToString();
            }
        }
        #endregion
        #endregion

        #region �Ѥz�a��
        #region GanZhiYearString
        /// <summary>
        /// ���A��~���z���ܪk�p �A���~
        /// </summary>
        public string GanZhiYearString
        {
            get
            {
                string tempStr;
                int i = (this._cYear - GanZhiStartYear) % 60; //�p��z��
                tempStr = ganStr[i % 10].ToString() + zhiStr[i % 12].ToString() + "�~";
                return tempStr;
            }
        }
        #endregion

        #region GanZhiMonthString
        /// <summary>
        /// ���z�䪺���ܦr�Ŧ�A�`�N�A�䪺�|�뤣�O�z��
        /// </summary>
        public string GanZhiMonthString
        {
            get
            {
                //�C�Ӥ몺�a���`�O�T�w��,�ӥB�`�O�q�G��}�l
                int zhiIndex;
                string zhi;
                if (this._cMonth > 10)
                {
                    zhiIndex = this._cMonth - 10;
                }
                else
                {
                    zhiIndex = this._cMonth + 2;
                }
                zhi = zhiStr[zhiIndex - 1].ToString();

                //�ھڷ�~���z��~���z�ӭp���z���Ĥ@��
                int ganIndex = 1;
                string gan;
                int i = (this._cYear - GanZhiStartYear) % 60; //�p��z��
                switch (i % 10)
                {
                    #region ...
                    case 0: //��
                        ganIndex = 3;
                        break;
                    case 1: //�A
                        ganIndex = 5;
                        break;
                    case 2: //��
                        ganIndex = 7;
                        break;
                    case 3: //�B
                        ganIndex = 9;
                        break;
                    case 4: //��
                        ganIndex = 1;
                        break;
                    case 5: //�v
                        ganIndex = 3;
                        break;
                    case 6: //��
                        ganIndex = 5;
                        break;
                    case 7: //��
                        ganIndex = 7;
                        break;
                    case 8: //��
                        ganIndex = 9;
                        break;
                    case 9: //��
                        ganIndex = 1;
                        break;
                    #endregion
                }
                gan = ganStr[(ganIndex + this._cMonth - 2) % 10].ToString();

                return gan + zhi + "��";
            }
        }
        #endregion

        #region GanZhiDayString
        /// <summary>
        /// ���z����ܪk
        /// </summary>
        public string GanZhiDayString
        {
            get
            {
                int i, offset;
                TimeSpan ts = this._date - GanZhiStartDay;
                offset = ts.Days;
                i = offset % 60;
                return ganStr[i % 10].ToString() + zhiStr[i % 12].ToString() + "��";
            }
        }
        #endregion

        #region GanZhiDateString
        /// <summary>
        /// ����e������z���ܪk�p �Ҥl�~�A���������
        /// </summary>
        public string GanZhiDateString
        {
            get
            {
                return GanZhiYearString + GanZhiMonthString + GanZhiDayString;
            }
        }
        #endregion
        #endregion
        #endregion
    }
}


