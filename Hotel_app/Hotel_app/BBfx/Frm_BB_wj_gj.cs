using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Hotel_app.BBfx
{
    public partial class Frm_BB_wj_gj : Form
    {
        public Frm_BB_wj_gj()
        {
            InitializeComponent();
        }



        DataSet ds = null;
        string second_selection = "";
        string sel_str = "";
        string url = common_file.common_app.service_url;
        BLL.Common B_common = new Hotel_app.BLL.Common();

        string dt_date = "1800-01-01";

        private void dtp_cssj_Enter(object sender, EventArgs e)
        {
            common_file.common_app.GetCurrentTime(sender, e);
        }

        private void b_first_Click(object sender, EventArgs e)
        {
            r.ShowFirstPage();
        }

        private void b_previous_Click(object sender, EventArgs e)
        {
            r.ShowPreviousPage();
        }
        private void b_next_Click(object sender, EventArgs e)
        {
            r.ShowNextPage();
        }

        private void b_last_Click(object sender, EventArgs e)
        {
            r.ShowLastPage();
        }

        private void b_search_Click(object sender, EventArgs e)
        {
            p_gl.BringToFront();
            p_gl.Visible = true;
            //second_selection = "";
            if (DateTime.Parse(dtp_cssj.Value.ToShortDateString()) != DateTime.Parse(common_file.common_app.cssj))
            {
                dt_date = dtp_cssj.Value.ToShortDateString();
                second_selection = "  and  bbrq>='" + dtp_cssj.Text.Replace("/", "-").Trim() + "'  and bbrq<='" + dtp_cssj.Text.Replace("/", "-").Trim() + "  23:59:59 " + "' ";
            }
             if (tb_fxlx.Text.Trim() != "")
             {
                second_selection += "   and   fx_zt  like '%" + tb_fxlx.Text.Trim().Replace("'", "-") + "%' ";
             }
            Cursor.Current = Cursors.Default;
            displayBB(second_selection, "");

        }

        private void b_refresh_Click(object sender, EventArgs e)
        {

            common_file.common_app.get_czsj();
            displayBB(DateTime.Now.ToShortDateString(), "");
            Cursor.Current = Cursors.Default;
            common_file.common_app.Message_box_show(common_file.common_app.message_title, "��ʾ,�˲�ѯ�����ɴ���������,��ʼ����ǰһ��ļǹ�����ϸ,���ڲ�ѯʱ���ѡ���ѯ������,����߲�ѯЧ��");
        }

        private void b_print_Click(object sender, EventArgs e)
        {
            try
            {
                this.r.PrintReport();
            }
            catch
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "��ӡ����,����ȷ���ô�ӡ��");
            }
        }

        private void b_outport_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (common_file.common_roles.get_user_qx("B_bbfx_outPort", common_file.common_app.user_type) == false)
            { return; }

            System.Collections.Hashtable nameList = new System.Collections.Hashtable();
            //�����е����Ķ�Ӧ��
            nameList = new Hashtable();
            nameList.Add("bbrq", "��������");
            nameList.Add("ddsj", "����ʱ��");
            nameList.Add("lksj", "���ʱ��");
            nameList.Add("czsj", "����ʱ��");
            nameList.Add("krxm", "����");
            nameList.Add("jzzt", "��������");
            nameList.Add("xydw ", "��λ");
            nameList.Add("krly", "��Դ");
            nameList.Add("fjrb", "����");
            nameList.Add("fjbh", "����");
            nameList.Add("sktt", "ɢ���Ŷ�");
            nameList.Add("zfh", "����");
            nameList.Add("ds", "����");
            nameList.Add("qt", "����");
            nameList.Add("zyye", "�ܶ�");

            nameList.Add("czzt", "����״̬");
            nameList.Add("fx_zt", "����״̬");
            nameList.Add("czy", "����Ա");


            common_bb.ExportToExcel(ds, nameList);
            Cursor.Current = Cursors.Default;
        }


        private void displayBB(string cond, string other_cond)
        {
            common_file.common_app.get_czsj();
            common_bb.displayprogress(progressBar1);
            string  ss="id>=0  and   yydh='" + common_file.common_app.yydh+"'  " + cond+other_cond+ "  order by krxm,jzzt,czzt  asc";
            ds = B_common.GetList(" select *  from  BB_sh_wj_gj  ", "id>=0  and   yydh='" + common_file.common_app.yydh+"'  " + cond+other_cond+ "  order by krxm,jzzt,czzt  asc");

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                p_gl.Visible = false;
                common_bb.displayprogress(progressBar1);
                string _qymc = ""; string _qymc_english = ""; string _address_chinese = ""; string _address_english = ""; string _qydh = ""; string _qycz = ""; string _qyyb = ""; string _website = "";
                common_file.common_app.GetPrintInfo(ref  _qymc, ref  _qymc_english, ref  _address_chinese, ref _address_english, ref _qydh, ref _qycz, ref _qyyb, ref _website);
                BB_wj_gj_ls myreport = new BB_wj_gj_ls();
                myreport.SetDataSource(ds.Tables[0]);

                myreport.SetParameterValue("qymc", common_file.common_app.qymc);
                myreport.SetParameterValue("cssj", dt_date);
                myreport.SetParameterValue("address", _address_chinese);
                myreport.SetParameterValue("Tel", _qydh);
                myreport.SetParameterValue("Fax", _qycz);
                r.ReportSource = myreport;
            }
            else
            {
                r.ReportSource = null;
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "��ǰʱ�����û�з�������,�����Ը��Ĳ�ѯ��������ȡ�����ķ������ݣ�");
            }
        }

        private void Frm_BB_zz_gj_Load(object sender, EventArgs e)
        {
            //��ʾ����֮��δ�����ݷ���
            dt_date = DateTime.Now.AddDays(-1).ToShortDateString().Replace("/", "-");
            string ss = "   and   bbrq>='" + DateTime.Now.AddDays(-1).ToShortDateString().Replace("/", "-") + "'  and bbrq<='" + DateTime.Now.ToShortDateString().Replace("/", "-") + "  23:59:59'  ";
            displayBB("   and   bbrq>='"+DateTime.Now.AddDays(-1).ToShortDateString().Replace("/","-")+"'  and bbrq<='"+ DateTime.Now.ToShortDateString().Replace("/","-")+"  23:59:59'  ","");
            common_file.common_app.Message_box_show(common_file.common_app.message_title, "��ʾ,�˲�ѯ�����ɴ���������,��ʼ����ǰһ��ļ�(��)��ʷ��ϸ,���ڲ�ѯʱ���ѡ���ѯ������,����߲�ѯЧ��");
            Cursor.Current = Cursors.Default;
        }

        private void b_gl_Click(object sender, EventArgs e)
        {
            p_gl.BringToFront();
            dtp_cssj.Text = common_file.common_app.cssj;
            if (p_gl.Visible == false)
            {
                p_gl.Visible = true;
            }
            else
            {
                p_gl.Visible = false;
            }
        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void b_gl_exit_Click(object sender, EventArgs e)
        {
            p_gl.Visible = false;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

    }
}