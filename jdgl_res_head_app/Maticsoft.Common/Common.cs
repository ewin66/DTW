using System;
using System.Collections.Generic;
using System.Text;

namespace Maticsoft.Common
{
    public class Common
    {
        #region ��ȡ�ַ���
        /// �����ַ�����ʵ�ʳ��Ƚ�ȡָ�����ȵ��ַ�����Ӣ����ĸΪ��׼��
        /// </summary>
        /// <param name="str">�ַ���</param>
        /// <param name="Length">ָ������</param>
        /// <returns></returns>
        public static string CutStrLen(string str, int Length)
        {
            if (String.IsNullOrEmpty(str))
            {
                return str;
            }

            int i = 0, j = 0;

            foreach (char Char in str)
            {
                if ((int)Char > 127)
                    i += 2;
                else
                    i++;

                if (i > Length)
                {
                    str = str.Substring(0, j - 2) + "...";
                    break;
                }
                j++;
            }
            return str;
        }
        #endregion



    }
}
