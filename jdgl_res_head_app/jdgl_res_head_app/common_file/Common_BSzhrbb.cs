using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Configuration;
using Maticsoft.DBUtility;
using System.IO;
namespace jdgl_res_head_app.common_file
{
   public class Common_BSzhrbb
    {
       //�Ȳ�ѯ��û���ϴ�������5�������
       //ɾ�����ķ�������Ҫ�ϴ����ڵļ�¼
       //����ձ���
      public static string url = common_file.Common.ReadXML("add", "url") + "/BBfx/BBfx_app.asmx";

      

        //���ڱ������<��һ��,��ѯǰ5���ʱ��>�����ڣ�2012-05-25
       public static string ServicesForBB_step1(string yydh, DataSet Ds_searchDate)
        {
            string result = common_app.get_failure;
            //ִ�в���δ��������
            object[] ob_args = new object[2];
            ob_args[0] = yydh;
            ob_args[1] = Ds_searchDate;
            object temp = jdgl_res_head_app.DynamicWebServiceCall.InvokeWebService(url, "BBzhrbb_Delete", ob_args);
            result = temp.ToString();
            return result;
        }

        //���ڱ������--<�ڶ���,��ӵ����ķ�����>�����ڣ�2012-05-25
       public static string ServicesForBB_step2(DataSet ds)
        {
            string result = common_app.get_failure;
            try
            {
                result = common_app.get_failure;
                object[] ob_args = new object[1];

                ob_args[0] = ds;
                object temp_all = jdgl_res_head_app.DynamicWebServiceCall.InvokeWebService(url, "BSzhrbb_UpLoadDS", ob_args);
                if (temp_all.ToString() == common_app.get_suc)
                {

                    Common_Shsc.Updatshsc(ds, "BSzhrbb");
                    Common.AddMsg(ds, "�ϴ��ۺ��ձ���");
                    result= common_app.get_suc;
                        
                  
                }
            }
            catch (Exception ee)
            {
                //txtMessage.Text = "����,��ϸ��ϢΪ:" + ee.Message;
                throw new Exception(ee.Message);
            }
            return result;
        }

       public static void BSzhrbb_uploand()
       {
           DataSet Ds_searchDate;
           DataSet Ds_searchAllunuploadData;
           string stryydh = common_app.yydh;
           DbHelperSQLP helper = new DbHelperSQLP();
           SqlParameter[] sp ={ new SqlParameter("@yydh", SqlDbType.VarChar) };
           sp[0].Value = stryydh;
           try
           {
               
               Ds_searchDate = helper.RunProcedure("searchDate_Bszhrbb", sp, "Table_time");
               
               SqlParameter[] sp1 ={ new SqlParameter("@yydh", SqlDbType.VarChar) };
               sp1[0].Value = stryydh;
         
               Ds_searchAllunuploadData = helper.RunProcedure("searchAll_Bszhrbb", sp1, "Table_all");
               //ɾ���������ϵ�����
               if (ServicesForBB_step1(stryydh, Ds_searchDate) == "success")
               {
                   ServicesForBB_step2(Ds_searchAllunuploadData);//�ϴ����� 
               }
           }
           catch (Exception ee)
           {

               //��ʼд��־
             
               Common.WriteLog(ee.Message.ToString(),"��ѯ�������ݺ���ɾ�����ķ������ϱ�������ʱ����");

           }
       }
       
    }
}
