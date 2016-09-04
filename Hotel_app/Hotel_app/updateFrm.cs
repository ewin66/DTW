using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Diagnostics;

namespace Hotel_app
{
    public partial class updateFrm : Form
    {
        public updateFrm(Fmain  fParent)
        {
            InitializeComponent();
            this.f = fParent;
        }
        public updateFrm()
        {
            InitializeComponent();
        }

        string url = common_file.common_app.service_url;
        string downloadUrl = "";
        bool UpdateReady = false;
        string clinetAppVersion = "";
        Fmain f = null;
        private void updateFrm_Load(object sender, EventArgs e)
        {
            label1.Visible = false;
            downLoad.Visible = false;
            label2.Visible = false;
            url = common_file.common_app.service_url;
            clinetAppVersion = System.Diagnostics.FileVersionInfo.GetVersionInfo(Application.StartupPath + "\\hotel_app.exe").ProductVersion;
            url +="update.asmx";
            object[] args = new object[2];
            args[0]=common_file.common_app.yydh;
            args[1] = clinetAppVersion;
            object result = Hotel_app.DynamicWebServiceCall.InvokeWebService(url, "GetUpdate", args);
            if (result != null && result.ToString() != "")
            {
                //��ȡ���µ�ַ
                url=common_file.common_app.service_url;
                downloadUrl=url+"Download.ashx";
                label1.Visible = true;
                downLoad.Visible = true;
            }
            else
            {
                string SysPath=Application.StartupPath+"\\hotel_app.exe";
                FileVersionInfo f= FileVersionInfo.GetVersionInfo(SysPath);
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "����,ϵͳ��ʱû�и���,ϵͳ�ڲ��汾Ϊ:"+f.FileVersion+",��������κκõĽ���,����ϵϵͳ����Ա��лл��");
                this.Visible = false;
                this.Close();
            }
        }

        private void downLoad_Click(object sender, EventArgs e)
        {
            WebClient wc = new WebClient();

             string fileName=System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "update.data");
            wc.DownloadFile(downloadUrl,fileName);
            UpdateReady = true;
            label2.Visible = true;
            this.DialogResult = DialogResult.OK; 
        }

        private void updateFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (UpdateReady)
            {
                try
                {


                    Process.Start(System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "Hotel_app.update.exe"));
                    //f.Close();
                    //�ص�ϵͳ���еĹ������Ӧ��
                    foreach (Process tmpP in Process.GetProcesses())
                    {
                        if (tmpP.ProcessName.ToLower().Trim().Contains("hotel_app")&&(!tmpP.ProcessName.ToLower().Trim().Contains("update"))&&tmpP.MainWindowTitle!="")
                        {
                            try
                            {
                                tmpP.Kill();
                            }
                            catch
                            {
                                common_file.common_app.Message_box_show(common_file.common_app.message_title, "��ǰϵͳ�û���Ȩ�޲���,���ֶ��رվƵ�ϵͳ�ٴε������!");
                                continue;
                            }
                        }
                    }
                    //Process.Start(System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "Hotel_app.update.exe"));



                }
                catch(Exception ee)
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title,"�Զ����³�������ʧ�ܣ�����ϵϵͳ��Ա�����ֶ�����!"+ee.ToString());
                }
            }
        }
    }
}