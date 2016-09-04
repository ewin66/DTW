using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace jdgl_res_head_app.Xxtsz
{
    public partial class X_Config : Form
    {
        public X_Config()
        {
            InitializeComponent();
        }

        private void b_save_Click(object sender, EventArgs e)
        {
            string strname = this.tB_name.Text.Trim();
            string strip = this.tB_webseiceip.Text.Trim();
            string strsjkm = this.tB_sjkm.Text.Trim();
            string strpwd = this.tB_pwd.Text.Trim();
            string strwsurl = this.tB_webserviceurl.Text.Trim();
            string strsetTime = this.tB_setxydw.Text.Trim();

            if (strname != "" && strip != "" && strsjkm != "" && strpwd != ""&&strsetTime!="")
            {
                try
                {
                    //WriteXML("url", this.textBox2.Text, path);
                    //WriteXML("applicationVersion", this.textBox3.Text, path);
                    //WriteXML("qymc", this.textBox4.Text, path);
                    //���������Է�����д�������ļ�
                    string conStr = "server=" + strip + ";database=" + strsjkm + ";uid=" + strname + ";password=" + strpwd;
                    //���ַ���д��XML�����ļ���

                    common_file.Common.SaveConfig("conStr", conStr);

                    common_file.Common.SaveConfig("url", strwsurl);
                
                    //�޸������ļ������ʱ������

                    common_file.Common.SaveConfig("xydwshkq", strsetTime);
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "������Ϣ�޸ĳɹ�");
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                }
            }
        }

        private void X_Config_Load(object sender, EventArgs e)
        {

            string[] ss = common_file.Common.LoadDBInfo("add", "conStr");
            this.tB_webseiceip.Text = ss[0].Substring(ss[0].LastIndexOf('=') + 1);//ip
            this.tB_sjkm.Text = ss[1].Substring(ss[1].LastIndexOf('=') + 1);//database
            this.tB_name.Text = ss[2].Substring(ss[2].LastIndexOf('=') + 1);//uid
            this.tB_pwd.Text = ss[3].Substring(ss[3].LastIndexOf('=') + 1);
            tB_webserviceurl.Text = common_file.Common.ReadXML("add", "url");//��ȡwebserviceUrl
            tB_setxydw.Text = common_file.Common.ReadXML("add", "xydw_sc");//��ȡwebserviceUrl

        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}