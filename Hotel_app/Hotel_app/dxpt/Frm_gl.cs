using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.dxpt
{
    public partial class Frm_gl : Form
    {
        public Frm_gl(dxpt_send  frm_p)
        {
            InitializeComponent();
        }

        public string get_sel_cond = "  ";
        public string get_sel_cond_page2 = "   ";
        public string select_source = "";
        public string TableName = "";//���ز�ѯ��ʷ����Դ���ⲿ����ʱ�ſ�
        public string Inport_fileName = "";//���ѡ���ⲿ���룬���ﱣ��������ļ���
        public string inport_file_type = "";//�ⲿ�����ļ�����չ��
        private void cb_infoSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_infoSource.SelectedItem != null && !cb_infoSource.SelectedItem.ToString().Equals(""))
            {
                if (cb_infoSource.SelectedItem.ToString().Equals("��ʷ"))
                {
                    changePanelControlText("��ʷ");
                }
               if(cb_infoSource.SelectedItem.ToString().Equals("��Ա"))
                {
                    changePanelControlText("��Ա");
                }
                if(cb_infoSource.SelectedItem.ToString().Equals("Э�鵥λ"))
                {
                    changePanelControlText("Э�鵥λ");
                }
                if (cb_infoSource.SelectedItem.ToString().Equals("�ⲿ����"))
                {
                    changePanelControlText("�ⲿ����");
                }
            }
        }

        private void changePanelControlText(string p)
        {
            if (p.Equals("��ʷ"))
            {
                l_1.Visible = l_2.Visible = l_3.Visible = l_4.Visible = l_5.Visible = l_6.Visible = tB_1.Visible = tB_2.Visible = tB_3.Visible = tB_4.Visible = dT_ddsj_cs.Visible = dT_ddsj_js.Visible = dT_lksj_cs.Visible = dT_lksj_js.Visible =p_button.Visible= true;
                p_input.Height = 240;
                this.Height = 395;
               tB_0.Enabled = tB_1.Enabled = tB_2.Enabled = tB_3.Enabled = tB_4.Enabled = dT_ddsj_cs.Enabled = dT_ddsj_js.Enabled = dT_lksj_cs.Enabled = dT_lksj_js.Enabled = true;
               b_in.Visible =  b_selectFile.Visible = b_cancell.Visible = false;
               tB_0.Width = 219;

                l_0.Text = "�ֻ�����";
                l_1.Text = "֤������";
                l_2.Text = "��������";
                l_3.Text = "ע���ŵ�";
                tB_3.Enabled = false;
                l_4.Text = "�����Ա�";
                tB_4.Enabled = false;
                l_5.Text = "����ʱ��";
                l_6.Text = "�뿪ʱ��";

                select_source = "1";
                TableName = common_dxpt.dx_table_source_ks;
            }
            if (p.Equals("��Ա"))
            {
                l_1.Visible = l_2.Visible = l_3.Visible = l_4.Visible = l_5.Visible = l_6.Visible = tB_1.Visible = tB_2.Visible = tB_3.Visible = tB_4.Visible = dT_ddsj_cs.Visible = dT_ddsj_js.Visible = dT_lksj_cs.Visible = dT_lksj_js.Visible = p_button.Visible = true;
                p_input.Height = 240;
                this.Height = 395;
                tB_0.Enabled = tB_1.Enabled = tB_2.Enabled = tB_3.Enabled = tB_4.Enabled = dT_ddsj_cs.Enabled = dT_ddsj_js.Enabled = dT_lksj_cs.Enabled = dT_lksj_js.Enabled = true;
                b_in.Visible = b_selectFile.Visible = b_cancell.Visible = false;
                tB_0.Width = 219;
                l_0.Text = "��Ա����";
                l_1.Text = "��Ա����";
                l_2.Text = "��������";
                l_3.Text = "ע���ŵ�";
                l_4.Text = "�����Ա�";
                l_5.Text = "ע��ʱ��";
                l_6.Text = "�뿪ʱ��";
                dT_lksj_cs.Enabled = dT_lksj_js.Enabled = false;

                tB_0.Width = 219;
                select_source = "2";
                TableName =common_dxpt.dx_table_source_hy;

            }
            if(p.Equals("Э�鵥λ"))
            {
                l_1.Visible = l_2.Visible = l_3.Visible = l_4.Visible = l_5.Visible = l_6.Visible = tB_1.Visible = tB_2.Visible = tB_3.Visible = tB_4.Visible = dT_ddsj_cs.Visible = dT_ddsj_js.Visible = dT_lksj_cs.Visible = dT_lksj_js.Visible = p_button.Visible = true;
                p_input.Height = 240;
                this.Height = 395;
                tB_0.Enabled = tB_1.Enabled = tB_2.Enabled = tB_3.Enabled = tB_4.Enabled = dT_ddsj_cs.Enabled = dT_ddsj_js.Enabled = dT_lksj_cs.Enabled = dT_lksj_js.Enabled = true;
                b_in.Visible = b_selectFile.Visible = b_cancell.Visible = false;
                tB_0.Width = 219;
                l_0.Text = "Э�鵥λ";
                l_1.Text = "Э������";
                l_2.Text = "��ϵ��";
                l_3.Text = "����Ա";
                l_4.Text = "�����Ա�";
                tB_4.Enabled = false;
                l_5.Text = "ǩ��ʱ��";
                l_6.Text = "�뿪ʱ��";
                dT_lksj_cs.Enabled = dT_lksj_js.Enabled = false;

                tB_0.Width = 395;
                select_source = "3";
                TableName = common_dxpt.dx_table_source_xydw;

            }
            if (p.Equals("�ⲿ����"))
            {
                l_1.Visible = l_2.Visible = l_3.Visible = l_4.Visible = l_5.Visible = l_6.Visible =  tB_1.Visible = tB_2.Visible = tB_3.Visible = tB_4.Visible = dT_ddsj_cs.Visible = dT_ddsj_js.Visible = dT_lksj_cs.Visible = dT_lksj_js.Visible = false;
                b_in.Visible = b_exit.Visible = b_selectFile.Visible = b_cancell.Visible = true;
                l_0.Text = "�ļ���";
                p_button.Visible = false;

                tB_0.Width = 133;
                select_source = "4";
                TableName = common_dxpt.dx_table_wb;
                p_input.Height = 87;
                this.Height = 185;
            }
        }

        private void b_search_Click(object sender, EventArgs e)
        {
            gl();
            if (get_sel_cond != "")
            {
                this.DialogResult = DialogResult.OK;
            }
            if (get_sel_cond_page2 != "")
            {
                this.DialogResult = DialogResult.OK;
            }

        }

        private void gl()
        {
            if (tabControl1.SelectedIndex == 0)
            {
                if (select_source.Equals("1"))
                {

                    if (tB_0.Text.Trim() != "")
                    {
                        get_sel_cond += "  and  krdh  like '%" + tB_0.Text.Trim() + "%'  ";
                    }
                    if (tB_1.Text.Trim() != "")
                    {
                        get_sel_cond += "  and   zjhm  like '%" + tB_1.Text.Trim().Replace("'", "-") + "%'  ";
                    }
                    if (tB_2.Text.Trim() != "")
                    {
                        get_sel_cond += "  and  krxm   like '%" + tB_2.Text.Trim().Replace("'", "-") + "%'  ";
                    }
                    if (DateTime.Parse(dT_ddsj_cs.Value.ToShortDateString()) != DateTime.Parse(common_file.common_app.cssj) || DateTime.Parse(dT_ddsj_js.Value.ToShortDateString()) != DateTime.Parse(common_file.common_app.cssj))
                    {
                        get_sel_cond = get_sel_cond + " and (ddsj between '" + dT_ddsj_cs.Value.ToShortDateString() + "' and '" + dT_ddsj_js.Value.ToShortDateString() + " 23:59:59" + "')";
                    }
                    if (DateTime.Parse(dT_lksj_cs.Value.ToShortDateString()) != DateTime.Parse(common_file.common_app.cssj) || DateTime.Parse(dT_lksj_js.Value.ToShortDateString()) != DateTime.Parse(common_file.common_app.cssj))
                    {
                        get_sel_cond = get_sel_cond + " and (tfsj between '" + dT_lksj_cs.Value.ToShortDateString() + "' and '" + dT_lksj_cs.Value.ToShortDateString() + " 23:59:59" + "')";
                    }
                    get_sel_cond += "  and  krdh!=''  ";
                }
                if (select_source.Equals("2"))
                {
                    b_in.Visible = b_exit.Visible = true;

                    if (tB_0.Text.Trim() != "")
                    {
                        get_sel_cond += "  and  hykh_bz  like '%" + tB_0.Text.Trim() + "%'  ";
                    }
                    if (tB_1.Text.Trim() != "")
                    {
                        get_sel_cond += "  and   hyrx  like '%" + tB_1.Text.Trim().Replace("'", "-") + "%'  ";
                    }
                    if (tB_2.Text.Trim() != "")
                    {
                        get_sel_cond += "  and  krxm   like '%" + tB_2.Text.Trim().Replace("'", "-") + "%'  ";
                    }
                    if (tB_3.Text.Trim() != "")
                    {
                        get_sel_cond += "  and  krxb   like '%" + tB_3.Text.Trim().Replace("'", "-") + "%'  ";
                    }
                    if (DateTime.Parse(dT_ddsj_cs.Value.ToShortDateString()) != DateTime.Parse(common_file.common_app.cssj) || DateTime.Parse(dT_ddsj_js.Value.ToShortDateString()) != DateTime.Parse(common_file.common_app.cssj))
                    {
                        get_sel_cond = get_sel_cond + " and (djsj between '" + dT_ddsj_cs.Value.ToShortDateString() + "' and '" + dT_ddsj_js.Value.ToShortDateString() + " 23:59:59" + "')";
                    }
                    if (DateTime.Parse(dT_lksj_cs.Value.ToShortDateString()) != DateTime.Parse(common_file.common_app.cssj) || DateTime.Parse(dT_lksj_js.Value.ToShortDateString()) != DateTime.Parse(common_file.common_app.cssj))
                    {
                        get_sel_cond = get_sel_cond + " and (krsr between '" + dT_lksj_cs.Value.ToShortDateString() + "' and '" + dT_lksj_cs.Value.ToShortDateString() + " 23:59:59" + "')";
                    }
                    get_sel_cond += "  and  krsj!=''  ";

                }
                if (select_source.Equals("3"))
                {
                    b_in.Visible = b_exit.Visible = true;

                    if (tB_0.Text.Trim() != "")
                    {
                        get_sel_cond += "  and  xydw  like '%" + tB_0.Text.Trim() + "%'  ";
                    }
                    if (tB_1.Text.Trim() != "")
                    {
                        get_sel_cond += "  and   rx  like '%" + tB_1.Text.Trim().Replace("'", "-") + "%'  ";
                    }
                    if (tB_2.Text.Trim() != "")
                    {
                        get_sel_cond += "  and  nxr   like '%" + tB_2.Text.Trim().Replace("'", "-") + "%'  ";
                    }
                    if (tB_3.Text.Trim() != "")
                    {
                        get_sel_cond += "  and  xsy   like '%" + tB_3.Text.Trim().Replace("'", "-") + "%'  ";
                    }
                    if (DateTime.Parse(dT_ddsj_cs.Value.ToShortDateString()) != DateTime.Parse(common_file.common_app.cssj) || DateTime.Parse(dT_ddsj_js.Value.ToShortDateString()) != DateTime.Parse(common_file.common_app.cssj))
                    {
                        get_sel_cond = get_sel_cond + " and (clsj  between '" + dT_ddsj_cs.Value.ToShortDateString() + "' and '" + dT_ddsj_js.Value.ToShortDateString() + " 23:59:59" + "')";
                    }
                    get_sel_cond += "  and  krdh!=''  ";

                }
                if (select_source.Equals("4"))
                {
                    //�������пؼ������ֵ���ĶԻ���
                    //l_0.Visible = l_1.Visible = l_2.Visible = l_3.Visible = l_4.Visible = l_5.Visible = l_6.Visible = tB_0.Visible = tB_1.Visible = tB_2.Visible = tB_3.Visible = tB_4.Visible = dT_ddsj_cs.Visible = dT_ddsj_js.Visible = dT_lksj_cs.Visible = dT_lksj_js.Visible = false;
                    //b_in.Visible = b_exit.Visible = true;
                    //l_0.Text = "�ļ���";
                }
            }
            if (tabControl1.SelectedIndex == 1)
            {
                    if (DateTime.Parse(dt_fs_cs.Value.ToShortDateString()) != DateTime.Parse(common_file.common_app.cssj) || DateTime.Parse(dt_fs_js.Value.ToShortDateString()) != DateTime.Parse(common_file.common_app.cssj))
                    {
                        get_sel_cond_page2 = get_sel_cond_page2 + " and (sendTime  between '" + dt_fs_cs.Value.ToShortDateString() + "' and '" + dt_fs_js.Value.ToShortDateString() + " 23:59:59" + "')";
                    }
                    if (cb_fs_status.Text.Trim().Replace("'", "-") != "")
                    {
                        if(cb_fs_status.Text.Trim().Replace("'", "-").Equals("���ͳɹ�"))
                        {
                        get_sel_cond_page2 = get_sel_cond_page2 + " and sendStatusCode='0'  ";
                        }
                        if(cb_fs_status.Text.Trim().Replace("'", "-").Equals("����ʧ��"))
                        {
                        get_sel_cond_page2 = get_sel_cond_page2 + " and sendStatusCode!='0'  ";
                        }
                    }
                    if (tb_yfs_krxm.Text.Trim().Replace("'", "-") != "")
                    {
                        get_sel_cond_page2 = get_sel_cond_page2 + " and userName like '%" + tb_yfs_krxm.Text.Trim().Replace("'", "-") + "%'";
                    }
                    if (tb_yfs_sj.Text.Trim().Replace("'", "-") != "")
                    {
                        get_sel_cond_page2 = get_sel_cond_page2 + " and phoneNo like '%" + tb_yfs_sj.Text.Trim().Replace("'", "-") + "%'";
                    }
                    if (tb_yfs_info.Text.Trim().Replace("'", "-") != "")
                    {
                        get_sel_cond_page2 = get_sel_cond_page2 + " and tb_yfs_info like '%" + tb_yfs_info.Text.Trim().Replace("'", "-") + "%'";
                    }
            }
        }

        private void Frm_gl_Load(object sender, EventArgs e)
        {
            //Ĭ����ʾ�ɻ�Ա
            l_0.Visible = l_1.Visible = l_2.Visible = l_3.Visible = l_4.Visible = l_5.Visible = l_6.Visible = tB_0.Visible = tB_1.Visible = tB_2.Visible = tB_3.Visible = tB_4.Visible = dT_ddsj_cs.Visible = dT_ddsj_js.Visible = dT_lksj_cs.Visible = dT_lksj_js.Visible = true;
            b_in.Visible =  b_selectFile.Visible = b_cancell.Visible = false;
            tB_0.Width = 219;
            l_0.Text = "��Ա����";
            l_1.Text = "��Ա����";
            l_2.Text = "��������";
            l_3.Text = "ע���ŵ�";
            l_4.Text = "�����Ա�";
            l_5.Text = "ע��ʱ��";
            l_6.Text = "�뿪ʱ��";
            l_6.Visible = true;
            dT_lksj_cs.Enabled = dT_lksj_js.Enabled = false;

            tB_0.Width = 219;
            select_source = "2";
            cb_infoSource.SelectedIndex = 1; TableName = "Hhygl";

        }

        private void b_selectFile_Click(object sender, EventArgs e)
        {
            //txt�ļ���ʽ��һ��һ������
            //excel��ʽ��һ����Ѯ���ֱ�Ϊ���绰��֤����������
            openFileDialog1.Filter = "Text Files (*.txt)|*.txt|Excel Files (*.xls)|*.xls";
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = openFileDialog1.FileName;
                if (filename.Trim() != "")
                {
                    tB_0.Text = filename;
                }
                //ͨ�������ĺ�׺��������ʲô�����ļ�
                string extendName = filename.Substring(filename.LastIndexOf(".") + 1);
                if(extendName.Equals("txt"))//�ı��ļ�
                {
                    inport_file_type = "txt";
                }
                if (extendName.Equals("xls"))//Ҫ����EXCEL�ļ�
                {
                    inport_file_type = "xls";
                }
                Inport_fileName=filename;




            }
        }

        private void b_in_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void dT_ddsj_cs_Enter(object sender, EventArgs e)
        {
            common_file.common_app.GetCurrentTime(sender, e);
        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void b_selectFile_Click_1(object sender, EventArgs e)
        {

        }

        private void b_in_Click_1(object sender, EventArgs e)
        {

        }
    }
}