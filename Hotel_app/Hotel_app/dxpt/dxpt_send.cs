using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Text.RegularExpressions;
using Maticsoft.DBUtility;
using System.Data.SqlClient;
using Hotel_app.common_file;

namespace Hotel_app.dxpt
{
    public partial class dxpt_send : Form
    {
        public dxpt_send()
        {
            InitializeComponent();
        }


        #region old
        //string sel_cond = " 1=1   ";//�󲿲�ѯ����
        //string sel_cond_2 = " 1=1  ";//��ѯ��ϸ
        //string tableName = "";
        //string sel_cond_0 = "";//ǰ����ѯ
        //string inport_filename = "";//������ļ���
        //string inport_file_type = "";//������ļ�����
        //DataSet ds_source = null;
        //int CurrentPage = 0;
        //int PageSize = 20;
        //int PageCount = 0;  //��ҳ��
        //DataTable dt = null;
        //BLL.Common B_common = new Hotel_app.BLL.Common();
        //int tempCount = -1;
        //private void b_search_Click(object sender, EventArgs e)
        //{

        //    Frm_gl frm_gl_new = new Frm_gl(this);
        //    frm_gl_new.tabControl1.SelectedIndex = 0;
        //    frm_gl_new.tabControl1.TabPages[0].Focus();
        //    frm_gl_new.StartPosition = FormStartPosition.CenterScreen;
        //    if (frm_gl_new.ShowDialog() == DialogResult.OK)
        //    {
        //        if(!frm_gl_new.TableName.Equals(tableName))//���ȣ�������յ�ǰ�Ĳ�ѯ����
        //        {
        //            sel_cond = " 1=1 ";
        //        }
        //       sel_cond += frm_gl_new.get_sel_cond;
        //        tableName = frm_gl_new.TableName;
        //        inport_file_type = frm_gl_new.inport_file_type;
        //        inport_filename=frm_gl_new.Inport_fileName;

        //        if (tableName.Equals(common_dxpt.dx_table_source_ks))
        //        {
        //            sel_cond_0 = "select  distinct krdh,krxm,zjhm   from   " + tableName;
        //        }
        //        if (tableName.Equals(common_dxpt.dx_table_source_hy))
        //        {
        //            sel_cond_0 = " select distinct   krsj as  krdh,krxm,zjhm   from   " + tableName;
        //        }
        //        if (tableName.Equals(common_dxpt.dx_table_source_xydw))
        //        {
        //            sel_cond_0 = " select distinct  krdh,nxr as  krxm,xydw as zjhm  from  " + tableName;
        //        }
        //        if (!tableName.Equals(common_dxpt.dx_table_wb))
        //        {
        //             tempCount = -1;
        //            //ds_source = B_common.GetList(sel_cond_0, sel_cond);

        //             dt = DbHelperSQL.CommonPagination(tableName, tableName + ".id", tableName + ".id", CurrentPage, PageSize, "*", sel_cond, "", ref tempCount);
        //            if ((tempCount % PageSize) == 0)
        //            {
        //                PageCount = tempCount / PageSize;
        //            }
        //            else
        //            {
        //                PageCount = tempCount / PageSize + 1;
        //            }

        //            l_totalPage.Text = PageCount.ToString();
        //            l_currentPage.Text = CurrentPage.ToString();
        //            dg_infoSource.AutoGenerateColumns = false;
        //            dg_infoSource.DataSource = dt;
        //        }
        //        if (tableName.Equals(common_dxpt.dx_table_wb))
        //        {
        //            if (inport_file_type.Equals("xls"))//����EXCEL
        //            {
        //                ds_source = ExcelToDataSet(inport_filename);
        //                if (ds_source != null && ds_source.Tables[0].Rows.Count > 0)
        //                {
        //                    for (int i = 0; i < ds_source.Tables[0].Rows.Count; i++)
        //                    {
        //                        string addInfo = "";//���ӵ�
        //                        string krxm = ds_source.Tables[0].Rows[i]["krxm"].ToString();
        //                        string zjhm = ds_source.Tables[0].Rows[i]["zjhm"].ToString();
        //                        string krdh = ds_source.Tables[0].Rows[i]["krdh"].ToString();
        //                        if (!krxm.Equals("") && !krdh.Equals(""))
        //                        {
        //                            addInfo = krxm + "|" + zjhm + "|" + krdh;
        //                            listBox1.Items.Add(addInfo);
        //                        }
        //                    }

        //                }
        //            }
        //            if (inport_file_type.Equals("txt"))//����txt
        //            {
        //                System.IO.StreamReader sr = new System.IO.StreamReader(inport_filename,System.Text.Encoding.Default);
        //                string sLine = "";
        //                while (sLine != null)
        //                {
        //                    sLine =sr.ReadLine();
        //                    if (sLine != null && !sLine.Equals(""))
        //                        listBox1.Items.Add(sLine);
        //                }
        //                sr.Close();
        //                common_file.common_app.Message_box_show(common_file.common_app.message_title, "����ɹ�");
        //            }
        //        }
        //    }
        //}
        #endregion


        //string sel_cond_ls = " 1=1   ";//�󲿲�ѯ����
        //string sel_cond_hy = " 1=1   ";//�󲿲�ѯ����
        //string sel_cond_xydw = " 1=1   ";//�󲿲�ѯ����





        //string operateType = "";
        //private void dbClick()
        //{
        //        //ȫѡ
        //        if (operateType == "SelectAll")
        //        {
        //            for (int i = 0; i < dt.Rows.Count; i++)
        //            {
        //                string addInfo = "";//���ӵ�
        //                string krxm = dt.Rows[i]["krxm"].ToString();
        //                string zjhm = dt.Rows[i]["zjhm"].ToString();
        //                string krdh = dt.Rows[i]["krdh"].ToString();
        //                if (!krxm.Equals("") && !krdh.Equals(""))
        //                {
        //                    addInfo = krxm + "|" + zjhm + "|" + krdh;
        //                    if (!listBox1.Items.Contains(addInfo))
        //                    {
        //                        listBox1.Items.Add(addInfo);
        //                    }
        //                }
        //            }
        //        }
        //        if (operateType == "CancelAll")
        //        {
        //            if (listBox1.Items.Count > 0)
        //            {
        //                listBox1.Items.Clear();
        //            }
        //        }

        //        //ȡ������
        //        if (operateType == "CancelMulti")
        //        {
        //            if (listBox1.SelectedItems.Count> 0)
        //            {
        //                for (int i = 0; i < listBox1.SelectedItems.Count;)
        //                {
        //                    listBox1.Items.Remove(listBox1.SelectedItems[i]); 
        //                }
        //            }

        //        }

        //        //ѡ�����
        //        if (operateType == "SelectMulti")
        //        {
        //            foreach (DataGridViewRow   dgvr_temp in dg_infoSource.Rows)
        //            {
        //                DataGridViewCheckBoxCell chk = dgvr_temp.Cells[0] as DataGridViewCheckBoxCell;

        //                if (bool.Parse(chk.EditingCellFormattedValue.ToString()))
        //                {
        //                    DataRowView dgr = dgvr_temp.DataBoundItem as DataRowView;
        //                    //int i = dt.Rows.IndexOf(dgr.Row) + (CurrentPage - 1) * PageCount;

        //                    int i = dt.Rows.IndexOf(dgr.Row);
        //                    string addInfo = "";//���ӵ�
        //                    string krxm = dt.Rows[i]["krxm"].ToString();
        //                    string zjhm = dt.Rows[i]["zjhm"].ToString();
        //                    string krdh = dt.Rows[i]["krdh"].ToString();
        //                    if (!krxm.Equals("")  && !krdh.Equals(""))
        //                    {

        //                        addInfo = krxm + "|" + zjhm + "|" + krdh;
        //                        if (!listBox1.Items.Contains(addInfo))
        //                        {
        //                            listBox1.Items.Add(addInfo);
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //        l_selectCount.Text = listBox1.Items.Count.ToString();
        //}
        //private void b_selectAll_Click(object sender, EventArgs e)
        //{
        //    operateType = "SelectAll";
        //    dbClick();
        //}
        //private void b_SelectMulti_Click(object sender, EventArgs e)
        //{
        //    operateType = "SelectMulti";
        //    dbClick();
        //}
        //private void b_CancelMulti_Click(object sender, EventArgs e)
        //{
        //    operateType = "CancelMulti";
        //    dbClick();
        //}
        //private void b_CancelAll_Click(object sender, EventArgs e)
        //{
        //    operateType = "CancelAll";
        //    dbClick();
        //}


        //ʵ��excel����


        //�ļ�����ʱ�Ĳ���





        private string inport_filename = "";
        private string inport_file_type = "";
        private DataSet ds_source = null;
        static public DataSet ExcelToDataSet(string filename)
        {
            DataSet ds;
            string strCon = "Provider=Microsoft.Jet.OLEDB.4.0;" +
                            "Extended Properties=Excel 8.0;" +
                            "data source=" + filename;
            OleDbConnection myConn = new OleDbConnection(strCon);
            string strCom = " SELECT * FROM [Sheet1$]";
            myConn.Open();
            OleDbDataAdapter myCommand = new OleDbDataAdapter(strCom, myConn);
            ds = new DataSet();
            myCommand.Fill(ds);
            myConn.Close();
            return ds;
        }

        //ʵ�ֶ��ŷ���Ⱥ��
         public void SendMsM()
         {
             string info = "";
             string krxm_0 = "";
             string krsj_0 = "";
             string[]  infoString=null;
             List<string> list_send = new List<string>();
            if (listBox1.Items.Count > 0)
            {
                list_send.Clear();
                foreach (string  lvi in listBox1.Items)
                {
                    info = lvi.Trim();
                    //��ȡ�û���,�ֻ���
                    infoString = lvi.Trim().Split(new char[] { '|' });
                    if (infoString.Length== 3)//���еĸ�ʽ
                    {
                        krxm_0 = infoString[0];
                        krsj_0 = infoString[1];
                        common_dxpt.SendDxMuliti(krsj_0, krxm_0, txt_sendContent.Text.Trim());
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SendMsM();
        }

        //private void b_exportToExcel_Click(object sender, EventArgs e)
        //{
        //    //����ǰ���ݵ����༭�������ڵ���
        //    common_file.common_DataSetToExcel.ExportMX(ds_source, "dx_send", "����Ⱥ����ʱ���ݵ���");
        //}

        //private void b_refresh_Click(object sender, EventArgs e)
        //{
        //    ds_source = null;
        //    dg_infoSource.DataSource = null;
        //    sel_cond = "  1=1  ";
        ////}

        //private void b_next_Click(object sender, EventArgs e)
        //{
        //    if (CurrentPage < PageCount)
        //    {
        //        CurrentPage += 1;
        //    }
        //    else
        //    {
        //        CurrentPage = PageCount;
        //    }
        //    l_totalPage.Text = PageCount.ToString();
        //    l_currentPage.Text = CurrentPage.ToString();
        //     dt = DbHelperSQL.CommonPagination(tableName, tableName + ".id", tableName + ".id", CurrentPage, 20, "*", sel_cond, "", ref tempCount);
        //     dg_infoSource.DataSource = dt;
        //}

        //private void b_previous_Click(object sender, EventArgs e)
        //{
        //    if (CurrentPage >= 1)
        //    {
        //        CurrentPage -= 1;
        //    }
        //    l_totalPage.Text = PageCount.ToString();
        //    l_currentPage.Text = CurrentPage.ToString();
        //     dt = DbHelperSQL.CommonPagination(tableName, tableName + ".id", tableName + ".id", CurrentPage, 20, "*", sel_cond, "", ref tempCount);
        //     dg_infoSource.DataSource = dt;
        //}

        //private void b_first_Click(object sender, EventArgs e)
        //{
        //    CurrentPage = 1;
        //    l_totalPage.Text = PageCount.ToString();
        //    l_currentPage.Text = CurrentPage.ToString();
        //     dt = DbHelperSQL.CommonPagination(tableName, tableName + ".id", tableName + ".id", CurrentPage, 20, "*", sel_cond, "", ref tempCount);
        //    dg_infoSource.DataSource = dt;
        //}

        //private void b_last_Click(object sender, EventArgs e)
        //{
        //    CurrentPage = PageCount;
        //    l_totalPage.Text = PageCount.ToString();
        //    l_currentPage.Text = CurrentPage.ToString();
        //     dt = DbHelperSQL.CommonPagination(tableName, tableName + ".id", tableName + ".id", CurrentPage, 20, "*", sel_cond, "", ref tempCount);
        //     dg_infoSource.DataSource = dt;
        //}

        private void dxpt_send_Load(object sender, EventArgs e)
        {
            this.listBox1.ItemHeight = 40;
        }

        private void ly_click(object sender, EventArgs e)
        {
            Button B_click = (Button)sender;
            if (B_click != null)
            {
                if (B_click.Text.Equals("��ʷ"))
                {
                    Frm_select_lskr frm_new = new Frm_select_lskr(this, ref listBox1);
                    frm_new.StartPosition = FormStartPosition.CenterScreen;
                    frm_new.ShowDialog();
                }
                if (B_click.Text.Equals("��Ա"))
                {
                    Frm_select_hy frm_new = new Frm_select_hy(this, ref listBox1); frm_new.StartPosition = FormStartPosition.CenterScreen;
                    frm_new.ShowDialog();
                } if (B_click.Text.Equals("��λ"))
                {
                    Frm_select_xydw frm_new = new Frm_select_xydw(this, ref listBox1); frm_new.StartPosition = FormStartPosition.CenterScreen;
                    frm_new.ShowDialog();
                }
                if (B_click.Text.Equals("�ļ�"))
                {

                    Frm_select_other frm_new = new Frm_select_other(this, ref listBox1); frm_new.StartPosition = FormStartPosition.CenterScreen;
                    if (frm_new.ShowDialog() == DialogResult.OK)
                    {
                        inport_file_type = frm_new.inport_file_type;
                        inport_filename = frm_new.Inport_fileName;
                        if (inport_file_type.Equals("xls"))//����EXCEL
                        {
                            ds_source = ExcelToDataSet(inport_filename);
                            if (ds_source != null && ds_source.Tables[0].Rows.Count > 0)
                            {
                                for (int i = 0; i < ds_source.Tables[0].Rows.Count; i++)
                                {
                                    string addInfo = "";//���ӵ�
                                    string krxm = ds_source.Tables[0].Rows[i]["krxm"].ToString();
                                    string zjhm = ds_source.Tables[0].Rows[i]["zjhm"].ToString();
                                    string krdh = ds_source.Tables[0].Rows[i]["krdh"].ToString();
                                    if (!krxm.Equals("") && !krdh.Equals(""))
                                    {
                                        addInfo = krxm + "|" + zjhm + "|" + krdh;
                                        listBox1.Items.Add(addInfo);
                                    }
                                }

                            }
                        }
                        if (inport_file_type.Equals("txt"))//����txt
                        {
                            System.IO.StreamReader sr = new System.IO.StreamReader(inport_filename, System.Text.Encoding.Default);
                            string sLine = "";
                            while (sLine != null)
                            {
                                sLine = sr.ReadLine();
                                if (sLine != null && !sLine.Equals(""))
                                    listBox1.Items.Add(sLine);
                            }
                            sr.Close();
                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "����ɹ�");
                        }

                    }
                }
            }
        }

        private void tsm_delAll_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count > 0)
            {
                listBox1.Items.Clear();
            }
        }

        private void tsm_delSome_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count > 0)
            {
                for (int i = 0; i < listBox1.SelectedItems.Count; )
                {
                    listBox1.Items.Remove(listBox1.SelectedItems[i]);
                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dx_fs_detail Frm_detail = new dx_fs_detail();
            Frm_detail.StartPosition = FormStartPosition.CenterScreen;
            Frm_detail.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SendMsM();
        }
    }
}