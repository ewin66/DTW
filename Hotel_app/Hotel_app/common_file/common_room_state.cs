using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.common_file
{
    public static class common_room_state
    {
        public static void room_state(control_user.UC_room_pic_0 UC_room_pic_0_temp, DataSet DS_fjbh_temp, int row_no)
        {
            BLL.Common B_Common = new Hotel_app.BLL.Common();
            DataSet DS_temp = B_Common.GetList("select * from Ffjzt", "fjbh='" + DS_fjbh_temp.Tables[0].Rows[row_no]["fjbh"].ToString() + "'");
            UC_room_pic_0_temp.MP_i_g_m_l_c = "";//�����ж���ס��Ԥ�������ռ������-ɢ�͡����塢���顢��ס���ӵ� 
            UC_room_pic_0_temp.MP_charge = "";//����
            UC_room_pic_0_temp.MP_room_clean = 0;//�ж��Ƿ�����ѽ෿,1��ʾ�����಻��ʾ
            UC_room_pic_0_temp.MP_room_special = 0;//�ж��Ƿ��������Ҫ��,1��ʾ�����಻��ʾ
            UC_room_pic_0_temp.MP_arrival = 0;//�ж��Ƿ����Ԥ�ַ�,1��ʾ�����಻��ʾ
            UC_room_pic_0_temp.MP_leaving = 0;//�ж��Ƿ����Ԥ�뷿,1��ʾ��2��ʾ���ڣ����಻��ʾ
            UC_room_pic_0_temp.MP_room_union = 0;//�ж��Ƿ��������,1��ʾ�����಻��ʾ
            UC_room_pic_0_temp.MP_room_VIP = 0;//�ж��Ƿ����VIP����ͷ��,1��ʾ�����಻��ʾ
            UC_room_pic_0_temp.MP_guestname = "";//��������

            string sktt_0 = "";
            if (DS_fjbh_temp.Tables[0].Rows[row_no]["zyzt"].ToString() == common_file.common_fjzt.gjf)
            {
                UC_room_pic_0_temp.MP_room_state = 1;
                room_state_yd(B_Common, DS_temp,UC_room_pic_0_temp, DS_fjbh_temp, row_no);
                if (DS_fjbh_temp.Tables[0].Rows[row_no]["zybz"].ToString() == common_fjzt.lszy)
                { UC_room_pic_0_temp.MP_lszy = 1; }
            }//"�ɾ���"
            else
                if (DS_fjbh_temp.Tables[0].Rows[row_no]["zyzt"].ToString() == common_file.common_fjzt.zf)
                {
                    UC_room_pic_0_temp.MP_room_state = 2;
                    room_state_yj_zzzf(UC_room_pic_0_temp, DS_fjbh_temp, row_no);
                    room_state_yd(B_Common, DS_temp, UC_room_pic_0_temp, DS_fjbh_temp, row_no);
                    if (DS_fjbh_temp.Tables[0].Rows[row_no]["zybz"].ToString() == common_fjzt.lszy)
                    { UC_room_pic_0_temp.MP_lszy = 1; }
                }//"�෿";
                else
                    if (DS_fjbh_temp.Tables[0].Rows[row_no]["zyzt"].ToString() == common_file.common_fjzt.wxf)
                    {
                        UC_room_pic_0_temp.MP_room_state = 3;
                        room_state_yd(B_Common, DS_temp, UC_room_pic_0_temp, DS_fjbh_temp, row_no);
                    }//"ά�޷�";
                    else
                        if (DS_fjbh_temp.Tables[0].Rows[row_no]["zyzt"].ToString() == common_file.common_fjzt.zzf)
                        {
                            UC_room_pic_0_temp.MP_room_state = 5;
                            room_statei_g_m_l_c_(UC_room_pic_0_temp, sktt_0, row_no);////�����ж���ס��Ԥ�������ռ������-ɢ�͡����塢���顢��ס���ӵ� 
                            
                            //UC_room_pic_0_temp.MP_guestname = DS_fjbh_temp.Tables[0].Rows[row_no]["krxm"].ToString();
                            
                            

                            //���÷���

                            


                            DS_temp = B_Common.GetList("select * from View_Qskzd", " fjbh='" + DS_fjbh_temp.Tables[0].Rows[row_no]["fjbh"].ToString() + "' and yddj='" + common_yddj.yddj_dj + "'");
                            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                            {
                                sktt_0 = DS_temp.Tables[0].Rows[0]["sktt"].ToString();
                                DataSet DS_temp_0 = B_Common.GetList("select * from Qcounter","id>=0");
                                if (DS_temp_0 != null && DS_temp_0.Tables[0].Rows.Count > 0)
                                {

                                    if (DS_fjbh_temp.Tables[0].Rows[row_no]["fjbm"].ToString() != "True")
                                    {
                                        if (DS_temp_0.Tables[0].Rows[0]["ft_xs_fjjg"].ToString() == "True")
                                        {
                                            UC_room_pic_0_temp.MP_charge = DS_temp.Tables[0].Rows[0]["fjjg"].ToString();
                                        }
                                    }
                                    if (DS_temp_0.Tables[0].Rows[0]["ft_xs_krxm"].ToString() == "True")
                                    {
                                        //��������ԭ��������(115),Ŀǰ�Ƶ����λ��,ֻ�ڵǼ�ʱ����ʾ
                                        UC_room_pic_0_temp.MP_guestname = DS_temp.Tables[0].Rows[0]["krxm"].ToString(); ;//��������
                                    }
                                }
                                DS_temp_0.Clear();
                                DS_temp_0.Dispose();
                            }



                            if (DS_fjbh_temp.Tables[0].Rows[row_no]["shlf"].ToString() == "True")
                            {
                                UC_room_pic_0_temp.MP_room_union = 1;
                            }
                            if (DS_fjbh_temp.Tables[0].Rows[row_no]["shts"].ToString() == "True")
                            {
                                UC_room_pic_0_temp.MP_room_special = 1;
                            }
                            if (DS_fjbh_temp.Tables[0].Rows[row_no]["shvip"].ToString() == "True")
                            {
                                UC_room_pic_0_temp.MP_room_VIP = 1;
                            }

                            room_statei_g_m_l_c_(UC_room_pic_0_temp, sktt_0, row_no);

                            room_state_yj_zzzf(UC_room_pic_0_temp, DS_fjbh_temp, row_no);
                            room_state_yd(B_Common, DS_temp, UC_room_pic_0_temp, DS_fjbh_temp, row_no);

                            if ((DateTime.Parse(DS_fjbh_temp.Tables[0].Rows[row_no]["lksj"].ToString())) >= DateTime.Now.Date && DateTime.Parse(DS_fjbh_temp.Tables[0].Rows[row_no]["lksj"].ToString()) < DateTime.Now.Date.AddDays(1))
                            {
                                UC_room_pic_0_temp.MP_leaving = 1;

                            }
                            else
                                if (DateTime.Parse(DS_fjbh_temp.Tables[0].Rows[row_no]["lksj"].ToString()) < DateTime.Now.Date)
                                { UC_room_pic_0_temp.MP_leaving = 2; }

                            

                        }//"��ס��";
                        else
                            if (DS_fjbh_temp.Tables[0].Rows[row_no]["zyzt"].ToString() == common_file.common_fjzt.qtf)
                            {
                                UC_room_pic_0_temp.MP_room_state = 4;

                            }//"������"; 

            //UC_room_pic_0_temp.MP_Border_select = 1;//�߿���ɫ


            //����������ԭ��λ��
            //UC_room_pic_0_temp.MP_guestname = DS_fjbh_temp.Tables[0].Rows[row_no]["krxm"].ToString(); ;//��������
            DS_temp.Clear();
            DS_temp.Dispose();

        }
        /// <summary>
        /// �ж�����һ��״̬��Iɢ�ͣ�G���壬M���飬L��ס��C�ӵ�
        /// </summary>
        /// <param name="UC_room_pic_0_temp"></param>
        /// <param name="DS_fjbh_temp"></param>
        /// <param name="row_no"></param>
        public static void room_statei_g_m_l_c_(control_user.UC_room_pic_0 UC_room_pic_0_temp, string sktt_0, int row_no)//�����ж���ס��Ԥ�������ռ������-ɢ�͡����塢���顢��ס���ӵ� 
        {
            if (sktt_0 == common_file.common_sktt.sktt_sk)
            {
                UC_room_pic_0_temp.MP_i_g_m_l_c = "In";
            }
            else
                if (sktt_0 == common_file.common_sktt.sktt_tt)
                { UC_room_pic_0_temp.MP_i_g_m_l_c = "Gr"; }
                else
                    if (sktt_0 == common_file.common_sktt.sktt_hy)
                    { UC_room_pic_0_temp.MP_i_g_m_l_c = "Me"; }
                    else
                        if (sktt_0 == common_file.common_sktt.sktt_cz)
                        { UC_room_pic_0_temp.MP_i_g_m_l_c = "Lo"; }
                        else
                            if (sktt_0 == common_file.common_sktt.sktt_zd)
                            { UC_room_pic_0_temp.MP_i_g_m_l_c = "Co"; }
        }
        /// <summary>
        /// �ж��ѽ෿����ס�෿
        /// </summary>
        /// <param name="UC_room_pic_0_temp"></param>
        /// <param name="DS_fjbh_temp"></param>
        /// <param name="row_no"></param>
        public static void room_state_yj_zzzf(control_user.UC_room_pic_0 UC_room_pic_0_temp, DataSet DS_fjbh_temp, int row_no)//�����ж���ס��Ԥ�������ռ������-ɢ�͡����塢���顢��ס���ӵ� 
        {
            //�෿��������Ҫ�����,����Ҫ����ֶα�ʶ��
            if (DS_fjbh_temp.Tables[0].Rows[row_no]["zyzt"].ToString() == common_file.common_fjzt.zzf )//|| DS_fjbh_temp.Tables[0].Rows[row_no]["zyzt"].ToString() == common_file.common_fjzt.zf)
            {
                if (DS_fjbh_temp.Tables[0].Rows[row_no]["zybz"].ToString() == common_file.common_fjzt.yjf)
                {
                    UC_room_pic_0_temp.MP_room_clean = 1;

                }
            }

        }
        /// <summary>
        /// ����Ԥ����
        /// </summary>
        /// <param name="UC_room_pic_0_temp"></param>
        /// <param name="DS_fjbh_temp"></param>
        /// <param name="row_no"></param>
        public static void room_state_yd(BLL.Common B_Common_0,DataSet DS_temp, control_user.UC_room_pic_0 UC_room_pic_0_temp, DataSet DS_fjbh_temp, int row_no)//�����ж���ס��Ԥ�������ռ������-ɢ�͡����塢���顢��ס���ӵ� 
        {
            string sktt_0 = "";
            if (DS_fjbh_temp.Tables[0].Rows[row_no]["zyzt_second"].ToString() == common_file.common_fjzt.ydf)
            {
                if (DS_fjbh_temp.Tables[0].Rows[row_no]["zyzt"].ToString() == common_file.common_fjzt.gjf)
                {
                    UC_room_pic_0_temp.MP_room_state = 11;
                    if ((DateTime.Parse(DS_fjbh_temp.Tables[0].Rows[row_no]["yd_ddsj"].ToString())) >= DateTime.Now.Date && DateTime.Parse(DS_fjbh_temp.Tables[0].Rows[row_no]["yd_ddsj"].ToString()) < DateTime.Now.Date.AddDays(1))
                    {
                        UC_room_pic_0_temp.MP_arrival = 1;

                    }

                }
                else
                    if (DS_fjbh_temp.Tables[0].Rows[row_no]["zyzt"].ToString() == common_file.common_fjzt.zf)
                    {
                        UC_room_pic_0_temp.MP_room_state = 21;
                        if ((DateTime.Parse(DS_fjbh_temp.Tables[0].Rows[row_no]["yd_ddsj"].ToString())) >= DateTime.Now.Date && DateTime.Parse(DS_fjbh_temp.Tables[0].Rows[row_no]["yd_ddsj"].ToString()) < DateTime.Now.Date.AddDays(1))
                        {
                            UC_room_pic_0_temp.MP_arrival = 1;

                        }
                    }
                    else
                        if (DS_fjbh_temp.Tables[0].Rows[row_no]["zyzt"].ToString() == common_file.common_fjzt.wxf)
                        {
                            UC_room_pic_0_temp.MP_room_state = 31;
                            if ((DateTime.Parse(DS_fjbh_temp.Tables[0].Rows[row_no]["yd_ddsj"].ToString())) >= DateTime.Now.Date && DateTime.Parse(DS_fjbh_temp.Tables[0].Rows[row_no]["yd_ddsj"].ToString()) < DateTime.Now.Date.AddDays(1))
                            {
                                UC_room_pic_0_temp.MP_arrival = 1;

                            }
                        }
                        else
                            if (DS_fjbh_temp.Tables[0].Rows[row_no]["zyzt"].ToString() == common_file.common_fjzt.zzf)
                            {
                                UC_room_pic_0_temp.MP_room_state = 51;
                                if ((DateTime.Parse(DS_fjbh_temp.Tables[0].Rows[row_no]["yd_ddsj"].ToString())) >= DateTime.Now.Date && DateTime.Parse(DS_fjbh_temp.Tables[0].Rows[row_no]["yd_ddsj"].ToString()) < DateTime.Now.Date.AddDays(1))
                                {
                                    UC_room_pic_0_temp.MP_arrival = 1;

                                }
                            }
                if (DS_fjbh_temp.Tables[0].Rows[row_no]["zyzt"].ToString() != common_file.common_fjzt.zzf)
                {
                    DS_temp = B_Common_0.GetList("select * from View_Qskzd", "fjbh='" + DS_fjbh_temp.Tables[0].Rows[row_no]["fjbh"].ToString() + "' and ddsj='" + DS_fjbh_temp.Tables[0].Rows[row_no]["yd_ddsj"].ToString() + "' and  lksj='" + DS_fjbh_temp.Tables[0].Rows[row_no]["yd_lksj"].ToString() + "'");
                    if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
                    {


                        sktt_0 = DS_temp.Tables[0].Rows[0]["sktt"].ToString();
                        DataSet DS_temp_0 = B_Common_0.GetList("select * from Qcounter", "id>=0");
                        if (DS_temp_0 != null && DS_temp_0.Tables[0].Rows.Count > 0)
                        {

                            if (DS_temp_0.Tables[0].Rows[0]["ft_xs_fjjg"].ToString() == "True")
                            {
                                if (DS_fjbh_temp.Tables[0].Rows[row_no]["fjbm"].ToString() != "True")
                                {
                                    //���÷���
                                    UC_room_pic_0_temp.MP_charge = DS_temp.Tables[0].Rows[0]["fjjg"].ToString();
                                }
                            }
                            if (DS_temp_0.Tables[0].Rows[0]["ft_xs_krxm"].ToString() == "True")
                            {
                                //��������ԭ��������(115),Ŀǰ�Ƶ����λ��,ֻ�ڵǼ�ʱ����ʾ
                                UC_room_pic_0_temp.MP_guestname = DS_temp.Tables[0].Rows[0]["krxm"].ToString(); ;//��������
                            }
                        }
                        DS_temp_0.Clear();
                        DS_temp_0.Dispose();

                    }
                    room_statei_g_m_l_c_(UC_room_pic_0_temp, sktt_0, row_no);
                }
            }

        }

    }
}
