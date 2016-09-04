using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;
using System.Configuration;
using System.IO;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using Maticsoft.Common;


namespace jdgl_res_head_app
{
    public partial class F_main : Form
    {
        string url = "";
        string qymc = "";
        string Local_lsbh = "";
        //���ڽ���ִ�д洢���̺��ֵ��ͨ�ñ�����
        int temp_result = 0;
        //���ڴ�����־
        string errorInfo = "";
        //���ڱ�ʶ�������λ��
        string postion = "";
        public static bool StateSc =true;//�Ƿ�ʼ����
        Login lg = new Login();

        public F_main()
        {
            InitializeComponent();
            this.url = url = common_file.common_app.url;
        }

        private void f_clock_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();//�ر�Ӧ�ó��� 
        }

        //�����ļ�
        private void x_configgl_Click(object sender, EventArgs e)
        {
            if (lg.ShowDialog() == DialogResult.OK)
            {
                Xxtsz.X_Config xconfig = new jdgl_res_head_app.Xxtsz.X_Config();
                xconfig.StartPosition = FormStartPosition.CenterParent;
                xconfig.ShowDialog();
            }
        }

        private void serviceline_Click(object sender, EventArgs e)
        {
            TestRemoteServerStatus();
        }

        #region  ��ʼ����
        //��ʼ��ҵ��Ϣ(web_qyxx)
        private void M_Csqyxx_Click(object sender, EventArgs e)
        {
            if (lg.ShowDialog() == DialogResult.OK)
            {
                common_file.Common_qyxx.CS_qyxx();
            }
        }

        //��ʼЭ�鵥λ ------->Xxydw
        private void Ts_start_Yxydw_Click(object sender, EventArgs e)
        {
            if (lg.ShowDialog() == DialogResult.OK)
            {
                //��ס���������ݲ�����
                common_file.Common_Yxydw.M_Ts_start_Yxydw();
                //DbHelperSQL.ExecuteSql("delete from Yxydw where yydh<>'" + common_file.common_app.yydh + "'");
                //Э�鵥λ�Զ��ϴ����س���
            }
        }

        //��ʼ��Ա����
        private void Ts_start_Hhyfj_Click(object sender, EventArgs e)
        {
            if (lg.ShowDialog() == DialogResult.OK)
            {
                common_file.Common_Hhyfj.Cs_Hhyfj();
            }
        }
        
        //��ʼ����Ffjrbͬʱ��ʼffjzt��(web_fjrb)
        private void Ts_fjrb_Click(object sender, EventArgs e)
        {
            common_file.Common_fjrb.M_Ts_Ffjrb();
        }

        private void �ϴ�����״̬ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            common_file.Common_Ffjzt.M_UpLoad_Ffjzt_new();
        }
        #endregion

        #region  ��ԱFunctions
        //��Ա��Ϣ�ϴ�
        private void Ts_start_hygl_Click(object sender, EventArgs e)
        {
            if (lg.ShowDialog() == DialogResult.OK)
            {
                Hhygl_UpLoad();
            }
        }
      
        #region     �ϴ���Ա��Ϣ

        //�ϴ���Ա��Ϣ
        private void Hhygl_UpLoad()
        {
            int rowssum = 0;
            BLL.Hhygl B_Hhygl = new BLL.Hhygl();
            string yydh = common_file.Common.Getqyxx(1);//��ȡӪҵ����

            DataSet DS_Hhygl = B_Hhygl.GetList(200," ID>=0 and yydh='" + yydh + "'  and shqr=1 and shsc=0","id");
            string cssjtime =common_file.Common_hygl.GetScsj();
            string jstime = DateTime.Now.ToString();
            DataSet DS_HhyglUp = B_Hhygl.GetList(300," shxg=1  and shqr=1 and xgsj>='"+cssjtime+"'","id");
            try
            {
                if ((DS_Hhygl != null && DS_Hhygl.Tables[0].Rows.Count > 0) || (DS_HhyglUp != null && DS_HhyglUp.Tables[0].Rows.Count > 0))
                {
                    if (DS_Hhygl != null && DS_Hhygl.Tables[0].Rows.Count > 0)
                    {
                        rowssum = common_file.Common_hygl.UpLoad_hygl(DS_Hhygl);
                        common_file.Common.AddMsg(DS_Hhygl, "�ϴ���Ա��Ϣ");
                    }
                    if (DS_HhyglUp != null && DS_HhyglUp.Tables[0].Rows.Count > 0)
                    {
                        rowssum = common_file.Common_hygl.UpLoad_hygl(DS_HhyglUp);
                        common_file.Common.AddMsg(DS_HhyglUp, "�ϴ���Ա��Ϣ");
                    }
                    //common_file.common_app.AddMsg(listBox1, string.Format("����������ͻ�Ա��Ϣ�ļ������{0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                }
                else
                {
                    ts_lable_txt.Text = "û���������Ҫ�ϴ�";
                    //common_file.common_app.AddMsg(listBox1, string.Format("����������ͻ�Ա��Ϣû���������Ҫ�ϴ�{0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                }
            }
            catch (Exception ee)
            {
                #region Щ�θ�����2011-10-25��д��־����)
                //��ʼд��־
                errorInfo = ee.Message.ToString();
                postion = "�ϴ���Ա��Ϣʱ����";
                txtMessageOfWriteErrorLog.Text = common_file.Common.WriteLog(errorInfo, postion);
                #endregion
            }
            finally
            {
                DS_Hhygl.Dispose();
                DS_HhyglUp.Dispose();
            }
        }



        //�ϴ����ֶһ�
        private void Hhyjf_df_UpLoad()
        {
            try
            {
                int rowssum = 0;
                BLL.Hhyjf_df B_Hhyjfdf = new BLL.Hhyjf_df();
                string yydh = common_file.Common.Getqyxx(1);//��ȡӪҵ����
                DataSet DS_Hhyjfdf = B_Hhyjfdf.GetList(200," ID>=0 and yydh='" + yydh + "' and shsc=0","id");

                if ((B_Hhyjfdf != null && DS_Hhyjfdf.Tables[0].Rows.Count > 0))
                {

                    rowssum = common_file.Common_hygl.UpLoad_hyjfdf(DS_Hhyjfdf);
                    common_file.Common.AddMsg(DS_Hhyjfdf, "�ϴ���Ա���ֶһ�");

                    ts_lable_txt.Text = "��Ա���ֶһ��ϴ��ɹ�" + rowssum + "����¼";
                    //common_file.common_app.AddMsg(listBox1, string.Format("��������ϴ���Ա���ֶһ��ϴ��ɹ�{0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                }
                else
                {
                    ts_lable_txt.Text = "û���������Ҫ�ϴ�";
                    //common_file.common_app.AddMsg(listBox1, string.Format("��������ϴ���Ա���ֶһ�û���������Ҫ�ϴ�{0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                }
                DS_Hhyjfdf.Dispose();

            }
            catch (Exception ee)
            {
                #region Щ�θ�����2011-10-25��д��־����)
                //��ʼд��־
                errorInfo = ee.Message.ToString();
                postion = "�ϴ����ֶһ�ʱ����";
                txtMessageOfWriteErrorLog.Text = common_file.Common.WriteLog(errorInfo, postion);
                #endregion
            }
        }


        //�ϴ��������Ѽ�¼
        private void Hhyjf_xfjl_UpLoad()
        {
            try
            {
                int rowssum = 0;
                BLL.Hhyjf_xfjl B_Hhyjf_xfjl = new BLL.Hhyjf_xfjl();
                string yydh = common_file.Common.Getqyxx(1);//��ȡӪҵ����

                DataSet DS_Hhyjf_xfjl = B_Hhyjf_xfjl.GetList(200," ID>=0 and yydh='" + yydh + "' and shsc=0","id");
                if ((DS_Hhyjf_xfjl != null && DS_Hhyjf_xfjl.Tables[0].Rows.Count > 0))
                {
                    rowssum = common_file.Common_hygl.UpLoad_hyjf_xfjl(DS_Hhyjf_xfjl);
                    common_file.Common.AddMsg(DS_Hhyjf_xfjl, "�ϴ���Ա��������");
                    ts_lable_txt.Text = "��Ա�������Ѽ�¼�ϴ��ɹ�" + rowssum + "";
                    //common_file.common_app.AddMsg(listBox1, string.Format("����������ͻ�Ա�������Ѽ�¼�ϴ��ɹ�{0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                }
                else
                {
                    ts_lable_txt.Text = "û���������Ҫ�ϴ�";
                    //common_file.common_app.AddMsg(listBox1, string.Format("����������ͻ�Ա�������Ѽ�¼û���������Ҫ�ϴ�{0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                }
                DS_Hhyjf_xfjl.Dispose();
            }
            catch (Exception ee)
            {
                #region Щ�θ�����2011-10-25��д��־����)
                errorInfo = ee.Message.ToString();
                postion = "�ϴ��������Ѽ�¼ʱ����";
                txtMessageOfWriteErrorLog.Text = common_file.Common.WriteLog(errorInfo, postion);
                #endregion
            }
        }
        #endregion

        #region   ���ػ�Ա��Ϣ�����ֶһ�,�������Ѽ�¼
        private void DownLoad_Hhyjf_df()
        {
            try
            {
                common_file.Common_hygl.DownLoad_hyjf_df();
            }
            catch (Exception e)
            {
                common_file.Common.WriteLog(e.Message, "���ػ�Ա���ֶһ�ʱ����");
            }
        }
        public void DownLoad_Hygl()
        {
            try
            {
                common_file.Common_hygl.DownLoad_Hygl();
            }
            catch (Exception e)
            {
                common_file.Common.WriteLog(e.Message, "���ػ�Ա��Ϣʱ����");
            }
        }


        //���ػ������Ѽ�¼
        public void DownLoad_Hygljf_xfjl()
        {
            try
            {
                common_file.Common_hygl.DownLoad_hyjf_xfjl();

            }
            catch (Exception e)
            {
                common_file.Common.WriteLog(e.Message, "���ػ�Ա��Ϣʱ����");
            }
        }
        



        //���ػ��ֽ�Ʒ
        public void DownLoad_Hygljf_jp()
        {
            try
            {
                common_file.Common_hygl.DownLoad_hyjf_jp();
            }
            catch (Exception e)
            {
                common_file.Common.WriteLog(e.Message, "���ػ�Ա��Ϣʱ����");
            }
        }
        private void DL_hygl_Click(object sender, EventArgs e)
        {
            if (lg.ShowDialog() == DialogResult.OK)
            {
                DownLoad_Hygl();
            }
        }


        private void UpLoad_hyjfdf_Click(object sender, EventArgs e)
        {
            Hhyjf_df_UpLoad();
        }

        private void UpLoad_hyjf_xfjl_Click(object sender, EventArgs e)
        {
            if (lg.ShowDialog() == DialogResult.OK)
            {
                Hhyjf_xfjl_UpLoad();
            }
        }

        private void DownLoad_hyjf_df_Click(object sender, EventArgs e)
        {
            DownLoad_Hhyjf_df();
        }

        private void M_DownLoad_hyjfxfjl_Click(object sender, EventArgs e)
        {
            if (lg.ShowDialog() == DialogResult.OK)
            {
                DownLoad_Hygljf_xfjl();
            }
        }


        private void M_Download_hyjf_jp_Click(object sender, EventArgs e)
        {
            DownLoad_Hygljf_jp();
        }

        #endregion

        //�Զ��ϴ���Ա��Ϣ
        void ScHygl()
        {
            if (TestRemoteServerStatus() == 1)
            {
                ts_lable_txt.Text = "��Ա��Ϣ�ϴ���ʼ.....";
                Hhygl_UpLoad(); //�ϴ���Ա��Ϣ
                Hhyjf_df_UpLoad(); //�ϴ����ֶһ�
                Hhyjf_xfjl_UpLoad();//�ϴ���������
                string jstime = DateTime.Now.ToString();
                common_file.Common_hygl.Update_Hhy_scxzsj(jstime);//�ϴ�����޸ı��ص��ϴ�ʱ��ʹ�޸Ĺ��Ļ�Ա��Ϣ�����ظ��ϴ�

                ts_lable_txt.Text = "���ػ�Ա��Ϣ��ʼ";
                DownLoad_Hygl();//���ػ�Ա��Ϣ
                DownLoad_Hhyjf_df();//���ػ�Ա�һ�
                DownLoad_Hygljf_xfjl();//���ػ������Ѽ�¼
                ts_lable_txt.Text = "��Ա��Ϣ��������";
                common_file.common_app.AddMsg(listBox1, string.Format("�ϴ����ػ�Ա��Ϣ�ɹ�{0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
            }
 
        }
        #endregion

        #region  ���ݽ���        
        private void UpLoad_Qskydfjrb()
        {
            ts_lable_txt.Text = "�ϴ���������ά�޿�ʼ";
            int Upsum = common_file.Common_Qskyd_fjrb.UpLoad_Qskyd_fjrb();
            if (Upsum > 0)
            {
                ts_lable_txt.Text = "�ɹ��ϴ�" + Upsum.ToString() + "����¼";  
            }
            ts_lable_txt.Text = "�ϴ���������ά�޽���";
        }
        //�Զ��ϴ���������ά�޷�
        private void timer_AuTo_UpLoad_Qskydfjrb_Tick(object sender, EventArgs e)
        {
            timer_AuTo_UpLoad_Qskydfjrb.Enabled = false;
            if (TestRemoteServerStatus() == 1)
            {
                UpLoad_Qskydfjrb();//�ϴ�����
                common_file.common_app.AddMsg(listBox1, string.Format("�ϴ���������ά�޷��ɹ�{0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
            }
            else
            {
                common_file.Common.WriteLog("Զ��Webservices���Ӳ���,����������Ϣ", "�ϴ���������ά�޷�");
            }
            timer_AuTo_UpLoad_Qskydfjrb.Enabled = true;
        }
        //��Ա��Ϣ����
        private void M_AutoHygl_Click(object sender, EventArgs e)
        {
            ScHygl();
        }
        //Ԥ����Ϣ����
        private void download_ydxx_Click(object sender, EventArgs e)
        {
            UPdownload_Ydxx();
        }
        private void UpLoad_Qskyd_fjrb_Click(object sender, EventArgs e)
        {
            UpLoad_Qskydfjrb();
        }
        public void UPdownload_Ydxx()
        {
            if (TestRemoteServerStatus() == 1)
            {
                int Upsum = common_file.Common_yddj.Download_orderFrom400();
                common_file.Common_yddj.InsertToQttyd_ydzxqr();//�ϴ��ŵ�ȷ�������Ϣ
                common_file.Common_yddj.InsertToQttyd_ydzlzmx(); //�ϴ��ŵ�ȷ����ת�Ǽǵ���ϸ
                common_file.common_app.AddMsg(listBox1, string.Format("Ԥ�������ϴ���Ϣ�ɹ�" + Upsum.ToString() + "����¼{0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                if (Upsum > 0)
                {
                    ts_lable_txt.Text = "�ɹ�����" + Upsum.ToString() + "����¼";

                }
                else
                {
                    ts_lable_txt.Text = "��ǰû��Ҫ���ص�����";
                }
            }
            else
            {
                common_file.Common.WriteLog("Զ��Webservices���Ӳ���,����������Ϣ", "�ϴ�����Ԥ����Ϣ");
            }
 
        }

        public void UPdownload_Ydxx_test()
        {
            if (TestRemoteServerStatus() == 1)
            {
                int Upsum = common_file.Common_yddj.Download_orderFrom400_test();
                common_file.common_app.AddMsg(listBox1, string.Format("Ԥ�������ϴ���Ϣ�ɹ�" + Upsum.ToString() + "����¼{0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                if (Upsum > 0)
                {
                    ts_lable_txt.Text = "�ɹ�����" + Upsum.ToString() + "����¼";

                }
                else
                {
                    ts_lable_txt.Text = "��ǰû��Ҫ���ص�����";
                }
            }
            else
            {
                common_file.Common.WriteLog("Զ��Webservices���Ӳ���,����������Ϣ", "�ϴ�����Ԥ����Ϣ");
            }

        }
        #endregion

        #region �����ϴ�
        //�ϴ�������ϸ
        private void B_SsyxmfxUploand_Click(object sender, EventArgs e)
        {
            common_file.Common_Ssyxmfx.Cs_Ssyxmfx();
            common_file.Common_Ssyxmfx.Cs_Ssyxfmx_cz();
            common_file.Common_Ssyxmfx.Cs_Ssyxfmx_xsy();
            //ͬʱҲҪ�ϴ�Bszhrbbfl
            common_file.Common_Bszhrbbfl.Bszhrbbfl_Uploand();

        }
        //�ۺ��ձ����ϴ�
        private void BBzhrbb_uploand_Click(object sender, EventArgs e)
        {
            common_file.Common_BSzhrbb.BSzhrbb_uploand();
        }
        //�����¼�ϴ�
        private void Bszhrbb_uploand_Click(object sender, EventArgs e)
        {
            common_file.Common_Bszhrbbfl.Bszhrbbfl_Uploand();
        }
        #endregion

        #region  ��ʱ������
        private void timer_UpLoad_Hhygl_Tick(object sender, EventArgs e)
        {
            this.timer_UpLoad_Hhygl.Enabled = false;
            this.toolStripStatusLabel1.Text = "ע�⣬�Զ��ϴ���Ա��Ϣ�Ծ�����";
            if (TestRemoteServerStatus() == 1)
            {
                ScHygl();
            }
            else
            {
                txt_messageofWSconnectStatus.Text = "Զ��Webservices���Ӳ���,����������Ϣ";
                common_file.Common.WriteLog("Զ��Webservices���Ӳ���,����������Ϣ", "�ϴ����ػ�Ա��Ϣ");
            }
            this.toolStripStatusLabel1.Text = "�Զ��ϴ������ɹ�";
            this.timer_UpLoad_Hhygl.Enabled = true;
        }
        private void timer_SsyxfmxUpload_Tick(object sender, EventArgs e)
        {
            this.timer_SsyxfmxUpload.Enabled = false;
            if (TestRemoteServerStatus() == 1)
            {
                ts_lable_txt.Text = "�ϴ�������ϸ��ʼ";
                common_file.Common_Ssyxmfx.Cs_Ssyxmfx();
                common_file.Common_Ssyxmfx.Cs_Ssyxfmx_cz();
                common_file.Common_Ssyxmfx.Cs_Ssyxfmx_xsy();
                common_file.Common_Bszhrbbfl.Bszhrbbfl_Uploand();
                common_file.common_app.AddMsg(listBox1, string.Format("�ϴ�������ϸ�ɹ�{0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                ts_lable_txt.Text = "�ϴ�������ϸ����";

            }
            timer_SsyxfmxUpload.Enabled = true;

        }
        /// <summary>
        /// �ۺ��ձ�����ʷ��������4���ϴ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Bb_Tick(object sender, EventArgs e)
        {
            DateTime CurrentTime = DateTime.Now;
            int intHour = CurrentTime.Hour;
            int intMinute = CurrentTime.Minute;
            int intSecond = CurrentTime.Second;

            if (intHour == 5 && intMinute <= 59)//�������ʱ���������4��
            {
                this.timer_Bb.Enabled = false;
                common_file.Common_BSzhrbb.BSzhrbb_uploand();//�ϴ��ۺ��ձ���
                //common_file.Common_hygl.Update_hygljf();
                common_file.Common_Bszhrbbfl.Bszhrbbfl_Uploand();//�ϴ���¼
                //�ϴ�������ʷ����
                common_file.Common_lskr.UpLoad_lskr();
                common_file.Common_lskr.Download_lskr();
                common_file.common_app.AddMsg(listBox1, string.Format("�ϴ�������ʷ�������ۺ��ձ���ɹ�{0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                this.timer_Bb.Enabled = true;
            }
            else
            {
                //�ж�Э�鵥λ�Ƿ�Ҫ�ϴ�����
                if (common_file.common_app.xydwsc == "0")
                {
                    common_file.Common_Yxydw.Upload_Yxydw();//�ϴ�Э�鵥λ
                }
                if (common_file.common_app.xydwxz == "0")
                {
                    common_file.Common_Yxydw.Download_Yxydw();//����Э�鵥λ
                    common_file.Common_Yxydw.DownLoad_Yxydw_fjrb();//����Э���2012-11-02
                    common_file.common_app.AddMsg(listBox1, string.Format("�ϴ����ص�λ�ɹ�{0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                }
            }

        }
        /// <summary>
        /// Э�鵥λ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void M_AutoQxydw_Click(object sender, EventArgs e)
        {
            try
            {
                if (common_file.common_app.xydwsc == "0")
                {
                    common_file.Common_Yxydw.Upload_Yxydw();//�ϴ�Э�鵥λ
                }
                if (common_file.common_app.xydwxz == "0")
                {
                    common_file.Common_Yxydw.Download_Yxydw();//����Э�鵥λ
                }
                else
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "�ϴ�����Э�鵥λû�п���");

                }

            }
            catch (Exception ea)
            {
                common_file.Common.WriteLog(ea.Message, "�ϴ�����Э�鵥λʱ����");
            }

        }
        /// <summary>
        /// Ԥ���Ǽ���Ϣ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Ydxx_Tick(object sender, EventArgs e)
        {
            this.timer_Ydxx.Enabled = false;
            this.toolStripStatusLabel1.Text = "����Ԥ����Ϣ����";
            if (TestRemoteServerStatus() == 1)
            {
                UPdownload_Ydxx();//����Ԥ��������Ϣ
                UpLoad_Qskydfjrb();//�ϴ�Qskyd_fjrb��otherά�޷���������̬��2012-10-26�޸�Ԥ��������Ա��
                common_file.Common_Ffjzt.M_UpLoad_Ffjzt_new();//2012-09-19�¼ӵ�ʱʵ�������Ϸ�̬
            }
            else
            {
                common_file.Common.WriteLog("Զ��Webservices���Ӳ���,����������Ϣ", "����Ԥ����Ϣ");
                txt_messageofWSconnectStatus.Text = "Զ��Webservices���Ӳ���,����������Ϣ";
            }
            this.toolStripStatusLabel1.Text = "����Ԥ����Ϣ����";
            this.timer_Ydxx.Enabled = true;
        }
        #endregion

        #region   �����¼�
        private void F_main_Load(object sender, EventArgs e)
        {
            common_file.common_sjtb.SetDate();//ͬ��ʱ��
            common_file.Common.Fmain_Instance = this;
            this.toolStripStatusLabel1.Text = "��ʾ:��ǰû���ϴ�����";
            this.notifyIcon1.Visible = false;
            if (TestRemoteServerStatus() == 1)
            {
                common_file.common_app.AddMsg(listBox1, string.Format("���ӷ������ɹ�{0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                if (StateSc)
                {
                    this.txt_messageofWSconnectStatus.Text = common_file.common_app.qymc;
                    //�Զ��ϴ����ػ�Ա��Ϣ�ļ�ʱ��(һ�죩
                    timer_UpLoad_Hhygl.Enabled = false;
                    timer_UpLoad_Hhygl.Interval = 35 * 60 * 1000;
                    timer_UpLoad_Hhygl.Enabled = true;


                    //�Զ��ϴ�Qskyd_fjrb��otherά�޷���������̬��5���ӣ�
                    timer_AuTo_UpLoad_Qskydfjrb.Enabled = false;
                    timer_AuTo_UpLoad_Qskydfjrb.Interval = 6 * 60 * 1000;
                    timer_AuTo_UpLoad_Qskydfjrb.Enabled = true;


                    //�ϴ�������ϸ
                    timer_SsyxfmxUpload.Enabled = false;
                    timer_SsyxfmxUpload.Interval = 20 * 60 * 1000;
                    timer_SsyxfmxUpload.Enabled = true;


                    //�ۺ��ձ���ͷ�¼����ʷ����, //Э�鵥λ�Զ��ϴ����س���
                    timer_Bb.Enabled = false;
                    timer_Bb.Interval = 40 * 60 * 1000;
                    timer_Bb.Enabled = true;


                    //����Ԥ����Ϣ
                    timer_Ydxx.Enabled = false;
                    timer_Ydxx.Interval = 4 * 60 * 1000;
                    timer_Ydxx.Enabled = true;
                }
                else
                {
                    toolStripStatusLabel1.Text = "����ر�";
                }
            }
            else
            {
                Xxtsz.X_Config xconfig = new jdgl_res_head_app.Xxtsz.X_Config();
                xconfig.StartPosition = FormStartPosition.CenterParent;
                xconfig.ShowDialog();
                common_file.Common.WriteLog("Զ��Webservices���Ӳ���,����������Ϣ", "�����ʼʱ");
            }
        }

        //�ر��ϴ�����
        private void M_Ts_AutoClose_Click(object sender, EventArgs e)
        {
            this.toolStripStatusLabel1.Text = "ע��,�Զ��ϴ��ر�";
            timer_UpLoad_Hhygl.Enabled = false;
            timer_AuTo_UpLoad_Qskydfjrb.Enabled = false;
            timer_SsyxfmxUpload.Enabled = false;
            timer_Bb.Enabled = false;
            StateSc = false;
        }
        //��ʼ�Զ��������
        private void M_Ts_AutoBegin_Click(object sender, EventArgs e)
        {
            StateSc = true;
            this.toolStripStatusLabel1.Text = "ע��,�Զ��ϴ������ɹ�";
        }

        //�ر��ϴ�����
        private void M_closecopy_Click(object sender, EventArgs e)
        {
            this.toolStripStatusLabel1.Text = "ע��,�Զ��ϴ��ر�";
            timer_UpLoad_Hhygl.Enabled = false;
            timer_AuTo_UpLoad_Qskydfjrb.Enabled = false;
            timer_SsyxfmxUpload.Enabled = false;
            timer_Bb.Enabled = false;
            StateSc = false;
        }

        //���ڲ���WEBservice�Ƿ�����,������ʱ�򷵻�ֵΪ1
        private int TestRemoteServerStatus()
        {
            string url = common_file.Common.ReadXML("add", "url") + "/Xxtsz/Xxtsz_app.asmx";
            int status = -1;
            try
            {
                object temp = jdgl_res_head_app.DynamicWebServiceCall.InvokeWebService(url, "HelloServer", null);
                if (temp.ToString() == "1")
                {
                    ts_lable_txt.Text = "��ϲ,Զ�̷��������ӳɹ�";
                    status = Convert.ToInt32(temp.ToString());
                }
                else
                {
                    errorInfo = "Զ�̷��������ӳ���";
                    postion = "Զ�̷��������ӳ���";
                    txtMessageOfWriteErrorLog.Text = common_file.Common.WriteLog(errorInfo, postion);
                }
            }
            catch (Exception RemoteException)
            {
                errorInfo = RemoteException.Message.ToString();
                postion = "Զ�̷��������ӳ���";
                txtMessageOfWriteErrorLog.Text = common_file.Common.WriteLog(errorInfo, postion);
                //MessageBox.Show(RemoteException.Message.ToString());
            }
            return status;
        }
        //��С���¼�
        private void F_main_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                this.notifyIcon1.Visible = true;
            }
        }
        //˫��ͨ����˫���¼�
        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
            this.notifyIcon1.Visible = true;
        }

        private void ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
            this.notifyIcon1.Visible = true;
        }

        private void �˳�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.notifyIcon1.Visible = false;
            this.Close();
            this.Dispose();
            Application.Exit();

        }

        //��ʷ���˽���
        private void M_Autolskr_Click(object sender, EventArgs e)
        {
            common_file.Common_lskr.UpLoad_lskr();
            common_file.Common_lskr.Download_lskr();

        }

        //��listBox��������Ϣ
        public  void AddMsg(string msgStr)
        {
            this.listBox1.Items.Add(msgStr);
        }

        private void Tm_xzxyj_Click(object sender, EventArgs e)
        {
            common_file.Common_Yxydw.DownLoad_Yxydw_fjrb();
        }
        private void xztest_Click(object sender, EventArgs e)
        {
            UPdownload_Ydxx_test();
        }
#endregion       
    }
}