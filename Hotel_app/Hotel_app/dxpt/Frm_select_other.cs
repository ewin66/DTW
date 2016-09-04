using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.dxpt
{
    public partial class Frm_select_other : Form
    {
        dxpt_send frm_dxpt_send_new = null;
        public Frm_select_other(dxpt_send frm,ref   ListBox  ls_parent)
        {
            InitializeComponent();
            frm_dxpt_send_new = frm;
        }

        public  string Inport_fileName = "";
        public  string inport_file_type = "";
        private void b_in_Click(object sender, EventArgs e)
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
                if (extendName.Equals("txt"))//�ı��ļ�
                {
                    inport_file_type = "txt";
                }
                if (extendName.Equals("xls"))//Ҫ����EXCEL�ļ�
                {
                    inport_file_type = "xls";
                }
                Inport_fileName = filename;
            }
        }

        private void b_inportInfo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void b_cancell_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}