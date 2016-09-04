using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Windows.Forms;
namespace jdgl_res_head_app.common_file
{
   public class Common_Hhyfj
    {
       public static void Cs_Hhyfj()
       {
           BLL.Hhyfj B_Hhyfj = new BLL.Hhyfj();
           DataSet DS_Hhyfj = B_Hhyfj.GetList(" ID>=0  "+common_app.yydh_select+" ");
           if (DS_Hhyfj != null && DS_Hhyfj.Tables[0].Rows.Count > 0)
           {
               if (MessageBox.Show("�Ƿ�ȷ��Ҫ��ʼ��Ա������Ϣ��", "ѯ��  ", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
               {
                   string url = common_file.Common.ReadXML("add", "url") + "/Hhygl/Hhygl_app.asmx";
                   object[] args = new object[2];
                   args[0] = DS_Hhyfj;
                   args[1] = common_file.common_app.xxzs_zsvalue;
                   object result = jdgl_res_head_app.DynamicWebServiceCall.InvokeWebService(url, "Hhyfj_add_DS", args);
                   if (result.ToString() == common_file.common_app.get_suc)
                   {
                       Common.AddMsg(DS_Hhyfj, "��ʼ��Ա����");
                       common_file.common_app.Message_box_show(common_file.common_app.message_title, "��ʼ�ɹ���");
                   }
                   else
                   {
                       common_file.common_app.Message_box_show(common_file.common_app.message_title, "��ʼʧ�ܣ�");
                   }
               }
           }

           DS_Hhyfj.Dispose();
       }


    }
}
