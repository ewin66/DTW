using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using Maticsoft.DBUtility;
using System.IO;
using System.Xml;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Specialized;

using System.Data;

namespace jdgl_res_head_app.common_file
{
    public class Common
    {
        //public static string Local_lsbh_middelChar = "ttydlsbh";
        //public static string Local_ddbh_middelChar = "YXYD";
        //public static string Local_yydh = "";
        public static string yydh ="aa";//��ȡӪҵ����

        public static F_main Fmain_Instance = null;

        public static void  AddMsg(DataSet  ds,string Msg)
        {
            int i=0;
             if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                 i+=ds.Tables[0].Rows.Count ;
            }
            Fmain_Instance.AddMsg("ʱ��:["+DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")+"]"+Msg+i.ToString()+"����¼�ɹ�.");
        }

        ////��ȡqyxx�����Ӫҵ����
        public static string Getyydh()
        {
            string yybh = "";
            //yybh = DbHelperSQL.GetSingle("select yydh from  Xqyxx ").ToString();
            return yybh;
        }
        ////��ȡqyxx�����Ӫҵ����
        public static string Getqymc()
        {
            string qymc = "";
            //qymc = DbHelperSQL.GetSingle("select qymc from  Xqyxx ").ToString();
            return qymc;
        }
        //��ȡ������ҵ��Ϣ
        public static string Getqyxx(int typeid)
        {
            string strQyxx = "";
            Model.Xqyxx M_qyxx = new Model.Xqyxx();
            BLL.Xqyxx B_qyxx = new BLL.Xqyxx();
            M_qyxx = B_qyxx.GetModelList("1=1")[0];
            if (typeid == 1)
            {
                strQyxx = M_qyxx.yydh;

            }
            else if (typeid == 2)
            {
                strQyxx = M_qyxx.qymc;

            }
            else if (typeid == 3)
            {
                strQyxx = M_qyxx.qybh;

            }
            else if (typeid == 4)
            {
                strQyxx = M_qyxx.hyjfrx;
            }
            else
            {
                strQyxx = M_qyxx.yydh;

            }
            return strQyxx;
        }
        //������������־�ļ�
        public static string fileName_restartApp = "";

        //���ڼ�¼Ӧ�ó���������־�ļ�
        public static string filename_errorlog = "";

        public static string errorlog = "";
        //����Ŀ¼�µ�Baseconfig.xml
        public static string ReadXML(string  node,string appKey)
        {
            string CurrentVlaue = "";
            XmlDocument xmlDoc = new XmlDocument();
            string path = Application.StartupPath + "\\jdgl_res_head_app.exe.config";
            xmlDoc.Load(path);
            XmlNodeList nodes = xmlDoc.GetElementsByTagName(node);
            //XmlNodeList nodes = xmlDoc.SelectSingleNode(node).ChildNodes;
            for (int i = 0; i < nodes.Count; i++)
            {
                //�õ���ǰ����KEY��ֵ
                XmlAttribute att = nodes[i].Attributes["key"];
                if (att.Value == appKey)
                {
                    att = nodes[i].Attributes["value"];
                    CurrentVlaue = att.Value.ToString();
                    break;
                }
            }
            return CurrentVlaue;
        }

        //singleTagSectionHandler
        public static string ReadAPPConfig(string sectinName, string key)
        {
            string  ss="";
            IDictionary IDTest1 = (IDictionary)ConfigurationManager.GetSection(sectinName);
            return ss = IDTest1[key].ToString();
        }

        //DictionarySectionHandler
        public static string ReadDictionarySectionValue(string SectionName, string key)
        {
            string value = "";
            IDictionary Test1 = (IDictionary)ConfigurationManager.GetSection(SectionName);
            foreach (string s in Test1.Keys)
            {
                if (s == key)
                {
                    value = Test1[key].ToString();
                    break;
                }
                else
                    continue;
            }
            return value;
        }

        //NameValueSectionHandler
        public static string ReadNameValueSectionValue(string SectionName, string Key)
        {
            string Value="";
            NameValueCollection Test3 = (NameValueCollection)ConfigurationManager.GetSection(SectionName);
            foreach (string s in Test3.AllKeys)
            {
                if (s == Key)
                {
                    Value = Test3[s].ToString();
                    break;
                }
                else
                    continue;
            }
            return Value;
        }

        //���ݽڵ���Ϣ�Զ���ȡ
        public static string  ReadValue(string sectionName, string key)
        {
            string value = "";
            XmlDocument Doc = new XmlDocument();
            string path = Application.StartupPath.ToString() + "\\jdgl_res_head_app.exe.config";
            Doc.Load(path);
            string  type="";
            XmlNodeList nodes = Doc.GetElementsByTagName("section");

            for (int i = 0; i < nodes.Count; i++)
            {
                //��ȡsectionName��Ӧ��TYPEֵ
                XmlAttribute att = nodes[i].Attributes["name"];
                if (att.Value == sectionName)
                {
                    type = nodes[i].Attributes["type"].Value.ToString();
                    if (type == "System.Configuration.DictionarySectionHandler")
                    {
                        value = ReadDictionarySectionValue(sectionName, key); break;
                    }
                    if (type == "System.Configuration.NameValueSectionHandler")
                    {
                        value = ReadNameValueSectionValue(sectionName, key); break;
                    }
                    if (type == "System.Configuration.SingleTagSectionHandler")
                    {
                        value = ReadAPPConfig(sectionName, key); break;
                    }
                }
            }
            return value;
        }

        public static void SaveConfig(string keyValue, string value)
        {
            XmlDocument doc = new XmlDocument();
            //��������ļ���ȫ·��
            string strFileName = Application.StartupPath.ToString() + "\\jdgl_res_head_app.exe.config";
            doc.Load(strFileName);
            //�ҳ�����Ϊ��add��������Ԫ��
            XmlNodeList nodes = doc.GetElementsByTagName("add");
            for (int i = 0; i < nodes.Count; i++)
            {
                //��õ�ǰԪ�ص�key����
                XmlAttribute att = nodes[i].Attributes["key"];
                //����Ԫ�صĵ�һ���������жϵ�ǰ��Ԫ���ǲ���Ŀ��Ԫ��
                if (att.Value == keyValue)
                {
                    //��Ŀ��Ԫ���еĵڶ������Ը�ֵ
                    att = nodes[i].Attributes["value"];
                    att.Value = value;
                    //����������޸�
                    doc.Save(strFileName);
                }
            }

        }

        public static string[] LoadDBInfo(string node, string appKey)
        {
            //�õ������ַ���
            string conStr = ReadXML(node, appKey);
            string[] ss = conStr.Split(';');
            return ss;
        }

        public static string GetReplaceString(object obj)
        {
            if (obj != null)
            {
                string temp = obj.ToString();
                if (temp.Contains("'"))
                  temp= temp.Replace("'", "");
                return temp;
            }
            else
            {
                return "";
            }
        }

       //����yydh�õ�qybh
        public static string GetQybhByyydh(string qymc)
        {
            string yybh = "";
            yybh = DbHelperSQL.GetSingle("select qybh from  Xqyxx  where  qymc='" + qymc + "'").ToString();
            return yybh;
        }

        //���ɱ�Ų���(lsbh��5λ��ddbh����λ)
        #region "���ַ���λ����0"
        /// <summary>
        /// ���ַ���λ����0
        /// </summary>
        /// <param name="CharTxt">�ַ���</param>
        /// <param name="CharLen">�ַ�����</param>
        /// <returns></returns>
        public static string FillZero(string CharTxt, int CharLen)
        {
            if (CharTxt.Length < CharLen)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < CharLen - CharTxt.Length; i++)
                {
                    sb.Append("0");
                }
                sb.Append(CharTxt);
                return sb.ToString();
            }
            else
            {
                return CharTxt;
            }
        }
        #endregion

        //������ʱlsbh��ddbh
        public static  void Xcounter(ref string ddbh, ref string lsbh)
        {
            string today = DateTime.Now.ToString("yyyy-MM-dd");
            string str_ddbh = "SKYD";
            string str_lsbh = "YQSKYD";
            //string ddbh;
            //string lsbh;
            //begin
            string dtsj;
            int skyd_counter;

            string dtsj2;
            int lsbh_counter;
            //end
            string strsql = "select * from Xcounter";
            DataTable dt = DbHelperSQL.Query(strsql).Tables[0];
            if (dt.Rows.Count > 0)
            {
                #region ///�������(ע�Ȿ�صĶ����������λ)
                string ss = Convert.ToDateTime(dt.Rows[0]["skyddate"]).ToString("yyyy-MM-dd");
                if (ss != today)
                {
                    skyd_counter = 1;
                    dtsj = DateTime.Now.ToString("yyyMMdd");
                    string skyd_sql = string.Format("update Xcounter set skydcounter={0},skyddate='{1}' ", 1, today);
                    DbHelperSQL.ExecuteSql(skyd_sql);
                }
                else
                {
                    skyd_counter = Convert.ToInt32(dt.Rows[0]["skydcounter"]) + 1;
                    dtsj = Convert.ToDateTime(dt.Rows[0]["skyddate"]).ToString("yyyMMdd");
                    string skyd_sql = string.Format("update Xcounter set skydcounter={0} ", skyd_counter);
                    DbHelperSQL.ExecuteSql(skyd_sql);
                }
               // ddbh = GetQybh() + str_ddbh + dtsj + Common.FillZero(skyd_counter.ToString(),2);
               // ddbh = GetQybh() + Common.Local_ddbh_middelChar + dtsj + Common.FillZero(skyd_counter.ToString(), 2);
                #endregion

                #region ///��ˮ��ţ����ص���ʱ�����5λ)
                string sss = Convert.ToDateTime(dt.Rows[0]["lsbhdate"]).ToString("yyyy-MM-dd");
                if (sss != today)
                {
                    lsbh_counter = 1;
                    dtsj2 = DateTime.Now.ToString("yyyMMdd");
                    string skyd_sql = string.Format("update Xcounter set lsbhcounter={0},lsbhdate='{1}' ", 1, today);
                    DbHelperSQL.ExecuteSql(skyd_sql);
                }
                else
                {
                    lsbh_counter = Convert.ToInt32(dt.Rows[0]["lsbhcounter"]) + 1;
                    dtsj2 = Convert.ToDateTime(dt.Rows[0]["lsbhdate"]).ToString("yyyMMdd");
                    string skyd_sql = string.Format("update Xcounter set lsbhcounter={0} ", lsbh_counter);
                    DbHelperSQL.ExecuteSql(skyd_sql);
                }
                //lsbh = GetQybh() + str_lsbh + dtsj2 + Common.FillZero(lsbh_counter.ToString(), 5);
               // lsbh = GetQybh() + Common.Local_lsbh_middelChar + dtsj2 + Common.FillZero(lsbh_counter.ToString(), 5);
                #endregion
            }
            dt.Clear();
            dt.Dispose();
        }

        private static string GetQybh()
        {
            string qymc=Common.ReadXML("add","qymc");
            return DbHelperSQL.GetSingle("select  qybh  from Xqyxx  where qymc='" + qymc + "'").ToString();
        }

        //���Ӵ�����־����
        public static string WriteLog(string error,string postion)
        {
            string msg = "��־д��ʧ��";
            //�������ʱ����һ��д�������־����ʽΪ������ʱ��+������ϸ��Ϣ+���ֵ�λ��(�������쳣��λ��)
            //��������������־�ļ�·��
            fileName_restartApp = Common.ReadXML("add", "ErrorlogFileName");
            //�����ڼ�¼������Ϣ����־�ļ�
            filename_errorlog = Common.ReadXML("add", "WriteErrorLogFileName");
            if (error.Length > 200)
            {
                error = error.Substring(0, 200) + ".....";
            }

            //��ȡerror��Ϣ��ǰ200���ַ�,���ɴ�����־�ļ�
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("-------------------------------------------------");
            sb.AppendLine("������ʱ��Ϊ:"+DateTime.Now.ToString());
            sb.Append("��ϸ������ϢΪ:");
            sb.AppendLine(error);
            sb.AppendLine("�����Ĵ���λ��Ϊ" + postion);
            sb.AppendLine("--------------------------------------------------");
            sb.AppendLine("");
            sb.AppendLine("");
            errorlog = sb.ToString();

            //����д������־��Ϣ
            try
            {
                System.IO.StreamWriter SW1 = new StreamWriter(filename_errorlog,true);
                SW1.Write(errorlog);
                SW1.Flush();
                SW1.Close();
                System.IO.StreamWriter SW2 = new System.IO.StreamWriter(fileName_restartApp);
                SW2.Write("a");
                SW2.Flush();
                SW2.Close();
                msg = "��־д��ɹ�";
            }
            catch
            {
                msg = "��־д��ʧ��";   
            }
            return msg;
        }
    }
}
