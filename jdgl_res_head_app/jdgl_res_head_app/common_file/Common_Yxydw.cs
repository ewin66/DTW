using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Windows.Forms;
using Maticsoft.DBUtility;
using System.Data.SqlClient;

namespace jdgl_res_head_app.common_file
{
   public class Common_Yxydw
    {
       public static string yydh = common_file.Common.Getqyxx(1);//Ӫҵ����
       public static string url = common_file.Common.ReadXML("add", "url") + "/Xxtsz/Xxtsz_app.asmx";
       
       /// <summary>
       /// ��ʼЭ�鵥λ
        /// </summary>
        public static void M_Ts_start_Yxydw()
        {
            BLL.Yxydw B_Yxydw = new BLL.Yxydw();
            DataSet DS_Yxydw = B_Yxydw.GetList("ID>=0 " + common_app.yydh_select + " and rx='"+common_app.Yxydw_xydw+"'");
            if (DS_Yxydw != null && DS_Yxydw.Tables[0].Rows.Count > 0)
            {
                    object[] args = new object[2];
                    args[0] = DS_Yxydw;
                    args[1] = common_file.common_app.xxzs_zsvalue;
                    object result = jdgl_res_head_app.DynamicWebServiceCall.InvokeWebService(url, "Yxydw_add_DS", args);
                        if (result.ToString() == common_file.common_app.get_suc)
                        {
                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "��ʼ�ɹ���");
                            Common_Shsc.Updatshsc(DS_Yxydw, "Yxydw");//�ϴ����޸ı���shsh=1
                            Common.AddMsg(DS_Yxydw, "��ʼЭ�鵥λ");

                        }
                        else
                        {
                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "��ʼʧ�ܣ�");
                        }
            }
            DS_Yxydw.Dispose();
        }

       /// <summary>
        /// �ϴ�Э�鵥λ,�ϴ���󱾵�shsc=1
       /// </summary>
       public static void Upload_Yxydw()
       {
           BLL.Yxydw B_Yxydw = new BLL.Yxydw();
           string StrWhrer = " ID>=0 " + common_app.yydh_select + " and shsc=0 and rx='Э�鵥λ'";
           DataSet DS_Yxydw = B_Yxydw.GetList(200,StrWhrer,"id");
           if (DS_Yxydw != null && DS_Yxydw.Tables[0].Rows.Count > 0)
           {
               object[] args = new object[1];
               args[0] = DS_Yxydw;
               object result = jdgl_res_head_app.DynamicWebServiceCall.InvokeWebService(url, "Yxydw_add_DS_01", args);
               if (result.ToString() == common_file.common_app.get_suc)
               {
                   Common.AddMsg(DS_Yxydw,"�ϴ�Э�鵥λ");
                   Common_Shsc.Updatshsc(DS_Yxydw,"Yxydw");//�ϴ����޸ı���shsh=1
               }
           }
           
           DS_Yxydw.Dispose();
       }
         /// <summary>
       /// ����Э�鵥λ
         /// </summary>
         /// <returns></returns>
       public static string Download_Yxydw()
       {
           BLL.Yxydw B_Yxydw = new BLL.Yxydw();
           Model.Yxydw M_Yxydw = new Model.Yxydw();
           string s = common_file.common_app.get_failure;
           DataSet DS_download = new DataSet();
           string csdatatime = "1800-01-01";//Զ�̴������ĳ�ʼʱ��
           string jsdatatime = "1800-01-01";//Զ�̴������Ľ���ʱ��
           object[] args = new object[4];
           args[0] = yydh;
           args[1] = csdatatime;
           args[2] = jsdatatime;
           args[3] = DS_download;    
           object result = jdgl_res_head_app.DynamicWebServiceCall.InvokeWebService(url, "Yxydw_download", args);
           jsdatatime = (String)args[2];  //��ȡ����ʱ��
           if (result.ToString() == common_file.common_app.get_suc)
           {
               DS_download = (DataSet)args[3];//���غú��ֵ�����������ݿ�
               jsdatatime = (String)args[2];  //��ȡ����ʱ��
               csdatatime = (String)args[1];//��ȡ��ʼʱ��
               foreach (DataRow dr in DS_download.Tables[0].Rows)
               {
                   string xyh_service = dr["xyh"].ToString();//��ȡЭ���
                   M_Yxydw.qymc = dr["qymc"].ToString();
                   M_Yxydw.yydh = dr["yydh"].ToString();
                   M_Yxydw.zjm = dr["zjm"].ToString();
                   M_Yxydw.xzxg = dr["xzxg"].ToString();
                   M_Yxydw.xyrx = dr["xyrx"].ToString();
                   M_Yxydw.xyh_inner = dr["xyh_inner"].ToString();
                   M_Yxydw.xyh = dr["xyh"].ToString();
                   M_Yxydw.xydw = dr["xydw"].ToString();
                   M_Yxydw.xsy = dr["xsy"].ToString();
                   M_Yxydw.xfje = Convert.ToDecimal(dr["xfje"].ToString());
                   if (dr["sign_image"] != null && dr["sign_image"].ToString() != "")
                   {
                       M_Yxydw.sign_image = (byte[])(dr["sign_image"]);
                   }                  
                   M_Yxydw.shsh = Convert.ToBoolean(dr["shsh"].ToString());
                   M_Yxydw.shsc = true;
                   M_Yxydw.rx = dr["rx"].ToString();
                   M_Yxydw.pq = dr["pq"].ToString();
                   M_Yxydw.nxr = dr["nxr"].ToString();
                   M_Yxydw.lzfs = Convert.ToDecimal(dr["lzfs"].ToString());
                   M_Yxydw.krly = dr["krly"].ToString();
                   M_Yxydw.krgj = dr["krgj"].ToString();
                   M_Yxydw.krEmail = dr["kremail"].ToString();
                   M_Yxydw.krdz = dr["krdz"].ToString();
                   M_Yxydw.krdh = dr["krdh"].ToString();
                   M_Yxydw.krcz = dr["krcz"].ToString();
                   M_Yxydw.is_top = Convert.ToBoolean(dr["is_top"].ToString());
                   M_Yxydw.is_select = Convert.ToBoolean(dr["is_select"].ToString());
                   M_Yxydw.bz = dr["bz"].ToString();
                   M_Yxydw.clsj = Convert.ToDateTime(dr["clsj"].ToString());
                   M_Yxydw.fkje = Convert.ToDecimal(dr["fkje"].ToString());
                   //����Э��Ŷ�����ͬ�����������ͬ���޸�,��Ȼ��ֱ�����ص�Э�鵥λ��
                   DataSet DS_xyglservice = new DataSet();
                   DS_xyglservice = B_Yxydw.GetList("xyh='" + xyh_service + "'");
                   if (DS_xyglservice != null && DS_xyglservice.Tables[0].Rows.Count > 0)
                   {
                       M_Yxydw.id = Convert.ToInt32(DS_xyglservice.Tables[0].Rows[0]["id"].ToString());
                       if (B_Yxydw.Update(M_Yxydw))
                       {
                           s = common_file.common_app.get_suc;
                       }
                   }
                   else
                   {
                       if (B_Yxydw.Add(M_Yxydw) > 0)
                       {
                           s = common_file.common_app.get_suc;
                       }

                   }
               }
           }

           if (s == common_app.get_suc)
           {
               Common.AddMsg(DS_download, "����Э�鵥λ");
               common_file.Common_Yxydw.UpdateDownLoadTime(jsdatatime);//�سɹ������º��޸�Զ�̷�������ʱ��
           }   
           return s;
       }

       /// <summary>
       /// �������سɹ����޸�Զ�̷�������ʱ��
       /// </summary>
       /// <param name="jsdatatime"></param>
       /// <returns></returns>
       public static string UpdateDownLoadTime(string jsdatatime)
       {
           string ss = common_file.common_app.get_failure;
           object[] obj = new object[2];
           obj[0] = yydh;
           obj[1] = jsdatatime;
           object result = jdgl_res_head_app.DynamicWebServiceCall.InvokeWebService(url, "Yxydw_scxzsj", obj);
           ss = result.ToString();
           return ss;
       }


       /// <summary>
       /// �����ŵ�����Э��۸�
       /// </summary>
       /// <returns></returns>
       public static string DownLoad_Yxydw_fjrb()
       {
           BLL.Yxydw_fjrb B_Yxydw = new BLL.Yxydw_fjrb();
           Model.Yxydw_fjrb M_Yxydw = new Model.Yxydw_fjrb();
           string s = common_file.common_app.get_failure;
           DataSet DS_download = new DataSet();
           object[] args = new object[2];
           args[0] = yydh;
           args[1] = DS_download;
           object result = jdgl_res_head_app.DynamicWebServiceCall.InvokeWebService(url, "Yxydw_fjrb_download", args);
           if (result.ToString() == common_file.common_app.get_suc)
           {
               DS_download = (DataSet)args[1];//���غú��ֵ�����������ݿ�            
               foreach (DataRow dr in DS_download.Tables[0].Rows)
               {
                   string xyh_service = dr["xyh"].ToString();//��ȡЭ���
                   string strfjrb=dr["fjrb"].ToString();
                   M_Yxydw.qymc = dr["qymc"].ToString();
                   M_Yxydw.yydh = dr["yydh"].ToString();
                   M_Yxydw.xyh = xyh_service;
                   M_Yxydw.xydw = dr["xydw"].ToString();
                   M_Yxydw.sjjg = Convert.ToDecimal(dr["sjjg"].ToString());
                   M_Yxydw.is_top = Convert.ToBoolean(dr["is_top"].ToString());
                   M_Yxydw.is_select = Convert.ToBoolean(dr["is_select"].ToString());
                   M_Yxydw.fjrb = strfjrb;
                   M_Yxydw.fjrb_code = dr["fjrb_code"].ToString();
                   //���ݻ�Ա���Ŷ�����ͬ�����������ͬ���޸�,��Ȼ��ֱ�����ص���Ա��
                   DataSet DS_xyglservice = new DataSet();
                   DS_xyglservice = B_Yxydw.GetList("xyh='" + xyh_service + "' and fjrb='" + strfjrb + "'");
                   if (DS_xyglservice != null && DS_xyglservice.Tables[0].Rows.Count > 0)
                   {
                       M_Yxydw.id = Convert.ToInt32(DS_xyglservice.Tables[0].Rows[0]["id"].ToString());
                       if (B_Yxydw.Update(M_Yxydw))
                       {
                           s = common_file.common_app.get_suc;
                       }
                   }
                   else
                   {
                       if (B_Yxydw.Add(M_Yxydw) > 0)
                       {
                           s = common_file.common_app.get_suc;
                       }

                   }
               }
               Common.AddMsg(DS_download, "����Э���");
           }
           return s;
       }
    }
}
