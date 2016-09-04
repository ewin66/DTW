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
    public partial class F_main_S8 : Form
    {
        string url = "";
        public F_main_S8()
        {
            InitializeComponent();
            url = common_file.common_app.url;
        }

        
        //Ԥ����������
        private void download_ydxx_Click(object sender, EventArgs e)
        {
            Com.OrderHelper.DownLoadOrderFromSite();
        }

        #region  ��ʱ������
        /// <summary>
        /// Ԥ���Ǽ���Ϣ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Ydxx_Tick(object sender, EventArgs e)
        {
            this.timer_Ydxx.Enabled = false;
            this.toolStripStatusLabel1.Text = "����Ԥ����Ϣ����";
            string Msg=string.Empty;
            if (Com.CommFunc.TestRemoteServerStatus(ref Msg) == 1)
            {
                Com.OrderHelper.DownLoadOrderFromSite();  //����վ���ض�����Ϣ
                Com.OrderHelper.RefreshOrderStatus();           //�����ŵ��ȷ�������������վ�ϵĶ�����Ϣ
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
            Com.Common.Fmain_Instance = this;
            this.toolStripStatusLabel1.Text = "��ʾ:��ǰû������Ԥ������";
            this.notifyIcon1.Visible = false;
            string msg = string.Empty;
            if (Com.CommFunc.TestRemoteServerStatus(ref msg) == 1)
            {
                common_file.common_app.AddMsg(listBox1, string.Format("���ӷ������ɹ�{0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                {
                    this.txt_messageofWSconnectStatus.Text = common_file.common_app.qymc;
                    ////�Զ��ϴ����ػ�Ա��Ϣ�ļ�ʱ��(һ�죩
                    //timer_UpLoad_Hhygl.Enabled = false;
                    //timer_UpLoad_Hhygl.Interval = 35 * 60 * 1000;
                    //timer_UpLoad_Hhygl.Enabled = true;
                    //����Ԥ����Ϣ
                    int timeInterval = int.Parse(common_file.Common.ReadXML("add", "timeInterval"));
                    timer_Ydxx.Interval =timeInterval*60 * 1000;
                    timer_Ydxx.Enabled = true;
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

        //��listBox��������Ϣ
        public  void AddMsg(string msgStr)
        {
            this.listBox1.Items.Add(msgStr);
        }
#endregion       

        private void M_Ts_AutoBegin_Click(object sender, EventArgs e)
        {

        }
    }
}