using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace jdgl_res_head_app.common_file
{
    public partial class Message_box : Form
    {
        #region ���������
        private string  F_content;  //�����ڲ���ʾ������

        public string  F_Content
        {
            get { return F_content; }
            set { F_content = value; }
        }
        private int judge_y_n_con;//����Ҫ��ʾ�İ�Ŧ,����1ʱ����ȷ������,����2ʱ�����Ƿ����

        public int Judge_y_n_con
        {
            get { return judge_y_n_con; }
            set { judge_y_n_con = value; }
        }
        private string  F_tilte;//���������Ϣ����ʾ���Ǿ���

        public string  F_Title
        {
            get { return F_tilte; }
            set { F_tilte = value; }
        }
        #endregion
        //public string F_content = "����,��־����";
        //public int judge_y_n_con = 1;//����1ʱ����ȷ������,����2ʱ�����Ƿ����
        public Message_box()
        {
            InitializeComponent();
            initialize();
        }

        public Message_box(string F_tilte, string F_content, int judge_y_n_con)
        {
            InitializeComponent();
           
            this.F_Title = F_tilte;
            this.F_Content = F_content;
            this.Judge_y_n_con = judge_y_n_con;
            initialize();
        }
        public void initialize()
        {
            this.Text = this.F_Title;
            this.tB_content.Text = F_Content;
            if (judge_y_n_con == 1)
            {
                b_confirm.Visible = true;
            }
            else
            {
                b_yes.Visible = true;
                b_no.Visible = true;
            }
  
        }

        private void b_yes_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
        }

        private void b_confirm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void b_no_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }

        private void Massage_box_Load(object sender, EventArgs e)
        {
        }
    }
}