using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel_app.common_file
{
    class common_hyAction
    {
        //��Ա�Ķ�������ʶҪ����ʲô���ţ�
        public static string hy_Action_djNew = "����ɢ��(��Ա)�Ǽ�";
        public static string hy_Action_djxg = "ɢ��(��Ա)�Ǽ��޸�";
        public static string hy_Action_hytf = "�˷�(��Ա)";


        public static string hy_Action_ydNew = "����ɢ��(��Ա)Ԥ��";
        public static string hy_Action_ydxg = "ɢ��(��Ա)Ԥ���޸�";
        public static string hy_Action_yddel = "ɢ��(��Ա)Ԥ��ɾ��";


        public static string hy_Action_HyNew = "������Ա";
        public static string hy_Action_hyqr = "��Ա��֤�ɹ�";


        //ͬ�����
        public static bool hygl_shqr_add(string yydh)
        {
            bool flage_hyrq_add = false;
            BLL.Qcounter B_qcounter_new = new Hotel_app.BLL.Qcounter();
            List<Model.Qcounter> list = new List<Model.Qcounter>();
            list = B_qcounter_new.GetModelList(" id>=0  and  yydh='" + yydh + "'");
            Model.Qcounter M_qcounter = null;
            if (list != null && list.Count >= 1)
            {
                flage_hyrq_add = bool.Parse(list[0].Hhygl_qyqr.ToString());
            }

            return flage_hyrq_add;
        }


        //��Զ���ƽ̨
        public static string hy_Action_dxqf = "�������Ⱥ��";
        public static string hy_Action_dxqf_error = "�޷�����";//��������������,������ڷ���֮ǰ
    }
}
