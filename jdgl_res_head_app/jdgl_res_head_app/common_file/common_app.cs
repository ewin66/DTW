using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace jdgl_res_head_app.common_file
{
   public class common_app
    {
        public static string xxzs_xxvalue = "xx";//ѧϰ��
        public static string xxzs_zsvalue = "zs";//��ʽ��

        public static string Inital = "inital";
       public static string url = common_file.Common.ReadXML("add", "url");
       public static string xydwsc = common_file.Common.ReadXML("add", "xydw_sc");//��ȡЭ�鵥λ�Ƿ��ϴ�
       public static string xydwxz = common_file.Common.ReadXML("add", "xydw_xz");//��ȡЭ�鵥λ�Ƿ�����
       public static string yydh = Common.Getqyxx(1);
       public static string yydh_select = " and yydh='" + common_file.common_app.yydh + "' ";
       public static string qymc = Common.Getqyxx(2);
       public static string qybh = Common.Getqyxx(3);
       public static string hyjfrx = Common.Getqyxx(4);

        public static string get_suc = "success";//�ɹ���ֵ��
        public static string get_failure = "failure";//�ɹ���ֵ��

        public static string get_add = "add";//���ӵ�ֵ��
        public static string get_edit = "edit";//�༭��ֵ��



       public static string ddyy = "Ԥ������";
        public static string yddj_yd = "Ԥ��";
       public static string sktt_sk = "ɢ��";
       public static string sktt_tt = "����";
       public static string cznr_add = "����";
       public static string czy = "����Ԥ������";

        public static string yddj_qryd = "ȷ��Ԥ��";
        public static string yddj_dj = "�Ǽ�";
        public static string yddj_ydzdj = "Ԥ��ת�Ǽ�";
        public static string yddj_qx = "ȡ��";
        public static string yddj_wd = "δ��";
        public static string ddly = "����";

        public static string Yxydw_xydw = "Э�鵥λ";
        public static string Yxydw_gzdw = "���˵�λ";

        public static int x()//���λ��X
        {
            return Control.MousePosition.X;
        }
        public static int y()//���λ��Y
        {
            return Control.MousePosition.Y;
        }
        public static string message_title = "ϵͳ����ʦ��־����������";//��Ϣ��Ŀ;
        //�Զ���һ��message_box.show
        public static bool message_box_show_select(string F_title, string content)
        {
            jdgl_res_head_app.common_file.Message_box F_Message_box = new Message_box(F_title, content, 2);
            if (F_Message_box.ShowDialog() == DialogResult.Yes)
            {
                return true;
            }
            return false;
            F_Message_box.Dispose();

        }

        public static void Message_box_show(string F_title, string content)
        {
            jdgl_res_head_app.common_file.Message_box F_Message_box = new Message_box(F_title, content, 1);
            F_Message_box.ShowDialog();
        }
        //��listBox��������Ϣ
        public static void AddMsg(ListBox listBox1a, string msgStr)
        {
             listBox1a.Items.Add(msgStr);

        }

    }
}
