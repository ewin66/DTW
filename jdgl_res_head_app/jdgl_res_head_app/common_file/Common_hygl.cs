using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;

using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;
using System.Configuration;
using Maticsoft.DBUtility;
using System.IO;
namespace jdgl_res_head_app.common_file
{
    public class Common_hygl
    {
        //���سɹ����޸�Զ�̷����shscΪ1
        public static string url = common_file.Common.ReadXML("add", "url") + "/Hhygl/Hhygl_app.asmx";
        public static string ss = common_file.common_app.get_failure;
        public static string Local_lsbh = "";
        //���ڽ���ִ�д洢���̺��ֵ��ͨ�ñ�����
        public static int temp_result = 0;
        public static string yydh = common_file.Common.Getqyxx(1);//Ӫҵ����
        public static string ycHyglshsc(DataSet Ds_shsc)
        {
            object[] obj = new object[1];
            obj[0] = Ds_shsc;
            object result = jdgl_res_head_app.DynamicWebServiceCall.InvokeWebService(url, "UDshsc", obj);
            ss = result.ToString();
            if (ss == common_file.common_app.get_suc)
            {
                //MessageBox.Show("�޸��������ݵ�״̬�ɹ�");
                ss = common_file.common_app.get_suc;
            }
            return ss;

        }

        //��ȡԶ�̷���ĳ�ʼʱ��
        public static string GetYcCstime(string yydh)
        {
            string csdatatime = "1800-01-01";//Զ�̴������ĳ�ʼʱ��
            object[] args = new object[2];
            args[0] = yydh;
            args[1] = csdatatime;
            object result = jdgl_res_head_app.DynamicWebServiceCall.InvokeWebService(url, "GetSCtime", args);
            if (result.ToString() == common_file.common_app.get_suc)
            {
                csdatatime = (String)args[1];

            }
            return csdatatime;

        }

        #region    �ϴ���Ա��Ϣ
        public static int UpLoad_hygl(DataSet DS_Hhygl)
        {
            int i = 1;
            object[] args = new object[2];
            args[0] = DS_Hhygl;
            args[1] = common_file.common_app.xxzs_zsvalue;
            object result = jdgl_res_head_app.DynamicWebServiceCall.InvokeWebService(url, "Hhygl_add_DS", args);
            if (result.ToString() == common_file.common_app.get_suc)
            {
                Common_Shsc.Updatshsc(DS_Hhygl, "Hhygl");//�޸ı���shsc=1
                if (DS_Hhygl != null && DS_Hhygl.Tables[0].Rows.Count > 0)
                {
                    i = DS_Hhygl.Tables[0].Rows.Count;
                }
            }
            return i;
        }       
        public static int UpLoad_hyjfdf(DataSet DS_Hhyjfdf)
        {
            int i = 0;
            object[] args = new object[1];
            args[0] = DS_Hhyjfdf;
            object result = jdgl_res_head_app.DynamicWebServiceCall.InvokeWebService(url, "Hhyjfdf_UploadDS", args);
            if (result.ToString() == common_file.common_app.get_suc)
            {
                Common_Shsc.Updatshsc(DS_Hhyjfdf, "Hhyjf_df"); //�ϴ�����޸ı��ػ��ֶһ���shsc=1
                if (DS_Hhyjfdf != null && DS_Hhyjfdf.Tables[0].Rows.Count > 0)
                {
                    i = DS_Hhyjfdf.Tables[0].Rows.Count;
                }
            }
            return i;
        }
        public static int UpLoad_hyjf_xfjl(DataSet DS_Hhyjf_xfjl)
        {
            int i = 0;
            object[] args = new object[1];
            args[0] = DS_Hhyjf_xfjl;
            //args[1] = common_file.common_app.xxzs_zsvalue;
            object result = jdgl_res_head_app.DynamicWebServiceCall.InvokeWebService(url, "Hhyjfxfjl_UploadDS", args);
            if (result.ToString() == common_file.common_app.get_suc)
            {
                Common_Shsc.Updatshsc(DS_Hhyjf_xfjl, "Hhyjf_xfjl");//�޸ı���shsc=1;
                if (DS_Hhyjf_xfjl != null && DS_Hhyjf_xfjl.Tables[0].Rows.Count > 0)
                {
                    i = DS_Hhyjf_xfjl.Tables[0].Rows.Count;
                }
            }
            return i;
        }
        #endregion

        #region ��Ա��Ϣ����
        //���ػ�Ա�������Ѽ�¼
        public static void DownLoad_hyjf_xfjl()
        {
            BLL.Hhyjf_xfjl B_Hhyjf_xfjl = new BLL.Hhyjf_xfjl();
            Model.Hhyjf_xfjl M_Hhyjf_xfjl = new Model.Hhyjf_xfjl();
            int rows = 0;
            string csdatatime = "1800-01-01";
            string jsdatatime = "1800-01-01";
            DataSet DS_download = new DataSet();
            object[] args = new object[5];
            args[0] = yydh;
            args[1] = rows;
            args[2] = csdatatime;
            args[3] = jsdatatime;
            args[4] = DS_download;
            object result = jdgl_res_head_app.DynamicWebServiceCall.InvokeWebService(url, "Hhyjfxfjl_download", args);
            jsdatatime = (String)args[3];  //��ȡ����ʱ��
            if (result.ToString() == common_file.common_app.get_suc)
            {
                DS_download = (DataSet)args[4];//���غú��ֵ�����������ݿ�
                jsdatatime = (String)args[3];  //��ȡ����ʱ��
                csdatatime = (String)args[2];//��ȡ��ʼʱ��
                foreach (DataRow dr in DS_download.Tables[0].Rows)
                {
                    //id,qymc,yydh,lsbh_df,hykh,hykh_bz,krxm,id_app,lsbh,fjrb,fjbh,xfsj,hyjf,bz,xfdr,xfrb,xfxm,sjxmje,shsc,scsj,is_top,is_select,shqx
                    string hykh_service = dr["lsbh_df"].ToString();
                    M_Hhyjf_xfjl.yydh = dr["yydh"].ToString();
                    M_Hhyjf_xfjl.lsbh_df = dr["lsbh_df"].ToString();
                    M_Hhyjf_xfjl.qymc = dr["qymc"].ToString();
                    M_Hhyjf_xfjl.hykh = dr["hykh"].ToString();
                    M_Hhyjf_xfjl.hykh_bz = dr["hykh_bz"].ToString();
                    M_Hhyjf_xfjl.krxm = dr["krxm"].ToString();
                    M_Hhyjf_xfjl.id_app = dr["id_app"].ToString();
                    M_Hhyjf_xfjl.lsbh = dr["lsbh"].ToString();
                    M_Hhyjf_xfjl.fjrb = dr["fjrb"].ToString();
                    M_Hhyjf_xfjl.fjbh = dr["fjbh"].ToString();
                    M_Hhyjf_xfjl.xfsj = Convert.ToDateTime(dr["xfsj"].ToString());
                    M_Hhyjf_xfjl.hyjf = Convert.ToDecimal(dr["hyjf"].ToString());
                    M_Hhyjf_xfjl.bz = dr["bz"].ToString();
                    M_Hhyjf_xfjl.xfdr = dr["xfdr"].ToString();
                    M_Hhyjf_xfjl.xfrb = dr["xfrb"].ToString();
                    M_Hhyjf_xfjl.xfxm = dr["xfxm"].ToString();
                    M_Hhyjf_xfjl.sjxfje = Convert.ToDecimal(dr["sjxfje"].ToString());
                    M_Hhyjf_xfjl.shsc = true;
                    M_Hhyjf_xfjl.scsj = Convert.ToDateTime(csdatatime);//ȡ��ʼʱ��
                    M_Hhyjf_xfjl.shqx = Convert.ToBoolean(dr["shqx"].ToString());
                    M_Hhyjf_xfjl.parent_hykh = dr["parent_hykh"].ToString();
                    M_Hhyjf_xfjl.xfrq = Convert.ToDateTime(dr["xfrq"].ToString());

                    DataSet DS_Hhyglservice = new DataSet();
                    DS_Hhyglservice = B_Hhyjf_xfjl.GetList("lsbh_df='" + hykh_service + "'");
                    //����Lsbh_df��ѯ����û����ͬ�ļ�¼���������ɾ���ڼӡ�
                    if (DS_Hhyglservice != null && DS_Hhyglservice.Tables[0].Rows.Count > 0)
                    {
                        int strid = Convert.ToInt32(DS_Hhyglservice.Tables[0].Rows[0]["id"].ToString());
                        if (B_Hhyjf_xfjl.Delete(strid))
                        {
                            ss = common_file.common_app.get_suc;
                        }


                    }


                    if (B_Hhyjf_xfjl.Add(M_Hhyjf_xfjl) > 0)
                    {
                        ss = common_file.common_app.get_suc;
                    }




                }
                try
                {
                    common_file.Common_hygl.Update_hygljf(DS_download);//����������¼������
                }
                catch
                { }

            }
            common_file.Common_hygl.DownLoadUpdate(jsdatatime);//�������سɹ����޸�Զ�̷�������ʱ��
            Common.AddMsg(DS_download, "���ػ�Ա��������");



        }
        //���ػ�Ա�һ���¼
        public static void DownLoad_hyjf_df()
        {

            BLL.Hhyjf_df B_Hhyjf_df = new BLL.Hhyjf_df();
            Model.Hhyjf_df M_Hhyjf_df = new Model.Hhyjf_df();
            int rows = 0;
            string csdatatime = "1800-01-01";
            string jsdatatime = "1800-01-01";
            DataSet DS_download = new DataSet();
            object[] args = new object[5];
            args[0] = yydh;
            args[1] = rows;
            args[2] = csdatatime;
            args[3] = jsdatatime;
            args[4] = DS_download;
            object result = jdgl_res_head_app.DynamicWebServiceCall.InvokeWebService(url, "Hhyjfdf_download", args);
            if (result.ToString() == common_file.common_app.get_suc)
            {
                DS_download = (DataSet)args[4];//���غú��ֵ�����������ݿ�
                jsdatatime = (String)args[3];  //��ȡ����ʱ��
                csdatatime = (String)args[2];//��ȡ��ʼʱ��
                foreach (DataRow dr in DS_download.Tables[0].Rows)
                {
                    string hykh_service = dr["lsbh_df"].ToString();
                    M_Hhyjf_df.yydh = dr["yydh"].ToString();
                    M_Hhyjf_df.lsbh_df = dr["lsbh_df"].ToString();
                    M_Hhyjf_df.qymc = dr["qymc"].ToString();
                    M_Hhyjf_df.hykh = dr["hykh"].ToString();
                    M_Hhyjf_df.hykh_bz = dr["hykh_bz"].ToString();
                    M_Hhyjf_df.krxm = dr["krxm"].ToString();
                    M_Hhyjf_df.dfjf = Convert.ToDecimal(dr["dfjf"].ToString());
                    M_Hhyjf_df.dfxm = dr["dfxm"].ToString();
                    M_Hhyjf_df.dfsl = Convert.ToDecimal(dr["dfsl"].ToString());
                    M_Hhyjf_df.xfsj = Convert.ToDateTime(dr["xfsj"].ToString());
                    M_Hhyjf_df.shsc = true;
                    M_Hhyjf_df.scsj = Convert.ToDateTime(csdatatime);//ȡ��ʼʱ��
                    M_Hhyjf_df.xfrq = Convert.ToDateTime(dr["xfrq"].ToString());

                    M_Hhyjf_df.shqx = Convert.ToBoolean(dr["shqx"].ToString());
                    M_Hhyjf_df.xfrq = Convert.ToDateTime(dr["xfrq"].ToString());
                    DataSet DS_Hhyglservice = new DataSet();
                    DS_Hhyglservice = B_Hhyjf_df.GetList("lsbh_df='" + hykh_service + "'");
                    //����Lsbh_df��ѯ����û����ͬ�ļ�¼���������ɾ���ڼӡ�
                    if (DS_Hhyglservice != null && DS_Hhyglservice.Tables[0].Rows.Count > 0)
                    {
                        int strid = Convert.ToInt32(DS_Hhyglservice.Tables[0].Rows[0]["id"].ToString());
                        if (B_Hhyjf_df.Delete(strid))
                        {
                            ss = common_file.common_app.get_suc;
                        }


                    }

                    if (B_Hhyjf_df.Add(M_Hhyjf_df) > 0)
                    {
                        ss = common_file.common_app.get_suc;
                    }



                }
                try
                {
                    common_file.Common_hygl.Update_hygljf(DS_download);//����������¼������
                }
                catch
                { }
                Common.AddMsg(DS_download, "���ػ�Ա�һ���¼");
            }
        }
        //���ػ�Ա��Ʒ
        public static void DownLoad_hyjf_jp()
        {
            BLL.Hhyjf_jp B_Hhyjf_jp = new BLL.Hhyjf_jp();
            Model.Hhyjf_jp M_Hhyjf_jp = new Model.Hhyjf_jp();
            int rows = 0;
            string csdatatime = "1800-01-01";
            string jsdatatime = "1800-01-01";
            DataSet DS_download = new DataSet();
            object[] args = new object[5];
            args[0] = yydh;
            args[1] = rows;
            args[2] = csdatatime;
            args[3] = jsdatatime;
            args[4] = DS_download;
            object result = jdgl_res_head_app.DynamicWebServiceCall.InvokeWebService(url, "Hhyjfjp_download", args);
            if (result.ToString() == common_file.common_app.get_suc)
            {
                DS_download = (DataSet)args[4];//���غú��ֵ�����������ݿ�
                jsdatatime = (String)args[3];  //��ȡ����ʱ��
                csdatatime = (String)args[2];//��ȡ��ʼʱ��
                foreach (DataRow dr in DS_download.Tables[0].Rows)
                {
                    //ID,yydh,qymc,classname,Title,jpjf,simg,bimg,info,bz,isTuiJian,isshow,shsc,hyjfrx,is_top,is_select
                    string hykh_service = dr["title"].ToString();
                    string strclassname = dr["classname"].ToString();
                    M_Hhyjf_jp.yydh = dr["yydh"].ToString();
                    M_Hhyjf_jp.qymc = dr["qymc"].ToString();
                    M_Hhyjf_jp.classname = strclassname;
                    M_Hhyjf_jp.Title = hykh_service;
                    M_Hhyjf_jp.jpjf = Convert.ToDecimal(dr["jpjf"].ToString());
                    M_Hhyjf_jp.simg = dr["simg"].ToString();
                    M_Hhyjf_jp.bimg = dr["bimg"].ToString();
                    M_Hhyjf_jp.info = dr["info"].ToString();
                    M_Hhyjf_jp.bz = dr["bz"].ToString();
                    M_Hhyjf_jp.shsc = true;
                    M_Hhyjf_jp.hyjfrx = dr["hyjfrx"].ToString();




                    DataSet DS_Hhyglservice = new DataSet();
                    DS_Hhyglservice = B_Hhyjf_jp.GetList("title='" + hykh_service + "' and classname='" + strclassname + "'");
                    //����Lsbh_df��ѯ����û����ͬ�ļ�¼���������ɾ���ڼӡ�
                    if (DS_Hhyglservice != null && DS_Hhyglservice.Tables[0].Rows.Count > 0)
                    {
                        int strid = Convert.ToInt32(DS_Hhyglservice.Tables[0].Rows[0]["id"].ToString());
                        M_Hhyjf_jp.ID = strid;
                        if (B_Hhyjf_jp.Update(M_Hhyjf_jp))
                        {
                            ss = common_file.common_app.get_suc;
                        }
                    }
                    else
                    {
                        if (B_Hhyjf_jp.Add(M_Hhyjf_jp) > 0)
                        {
                            ss = common_file.common_app.get_suc;
                        }
                    }
                }
                Common.AddMsg(DS_download, "���ػ�Ա��Ʒ��¼");
            }
        }
        //���ػ�Ա��Ϣ
        public static void DownLoad_Hygl()
        {
            BLL.Hhygl B_Hhygl = new BLL.Hhygl();
            Model.Hhygl M_Hhygl = new Model.Hhygl();
            string yydh = common_file.Common.Getqyxx(1);
            string s = common_file.common_app.get_failure;
            DataSet DS_download = new DataSet();
            int rows = 0;

            string csdatatime = "1800-01-01";//Զ�̴������ĳ�ʼʱ��
            string jsdatatime = "1800-01-01";//Զ�̴������Ľ���ʱ��
            url = common_file.Common.ReadXML("add", "url") + "/Hhygl/Hhygl_app.asmx";
            object[] args = new object[5];
            args[0] = yydh;
            args[1] = rows;
            args[2] = csdatatime;
            args[3] = jsdatatime;
            args[4] = DS_download;
            object result = jdgl_res_head_app.DynamicWebServiceCall.InvokeWebService(url, "Hhygl_download", args);
            if (result.ToString() == common_file.common_app.get_suc)
            {
                DS_download = (DataSet)args[4];//���غú��ֵ�����������ݿ�
                jsdatatime = (String)args[3];  //��ȡ����ʱ��
                csdatatime = (String)args[2];//��ȡ��ʼʱ��
                foreach (DataRow dr in DS_download.Tables[0].Rows)
                {
                    string hykh_service = dr["hykh"].ToString();//��ȡ��Ա����
                    M_Hhygl.yydh = dr["yydh"].ToString();
                    M_Hhygl.qymc = dr["qymc"].ToString();
                    M_Hhygl.hyrx = dr["hyrx"].ToString();
                    M_Hhygl.hykh = dr["hykh"].ToString();
                    M_Hhygl.hykh_bz = dr["hykh_bz"].ToString();
                    M_Hhygl.krxm = dr["krxm"].ToString();
                    M_Hhygl.krgj = dr["krgj"].ToString();
                    M_Hhygl.krmz = dr["krmz"].ToString();
                    M_Hhygl.yxzj = dr["yxzj"].ToString();
                    M_Hhygl.zjhm = dr["zjhm"].ToString();
                    M_Hhygl.krsr = Convert.ToDateTime(dr["krsr"].ToString());
                    M_Hhygl.krdh = dr["krdh"].ToString();
                    M_Hhygl.krsj = dr["krsj"].ToString();
                    M_Hhygl.krEmail = dr["krEmail"].ToString();
                    M_Hhygl.krdz = dr["krdz"].ToString();
                    M_Hhygl.krzy = dr["krzy"].ToString();
                    M_Hhygl.krdw = dr["krdw"].ToString();
                    M_Hhygl.qzrx = dr["qzrx"].ToString();
                    M_Hhygl.qzhm = dr["qzhm"].ToString();
                    M_Hhygl.zjyxq = Convert.ToDateTime(dr["zjyxq"].ToString());
                    M_Hhygl.tlyxq = Convert.ToDateTime(dr["tlyxq"].ToString());
                    M_Hhygl.tjrq = Convert.ToDateTime(dr["tjrq"].ToString());
                    M_Hhygl.lzka = dr["lzka"].ToString();
                    M_Hhygl.bz = dr["bz"].ToString();
                    M_Hhygl.djsj = Convert.ToDateTime(dr["djsj"].ToString());
                    M_Hhygl.hyjf = Convert.ToDecimal(dr["hyjf"].ToString());
                    M_Hhygl.shsc = true;
                    M_Hhygl.scsj = Convert.ToDateTime(jsdatatime);//ȡ����ʱ��
                    M_Hhygl.xgsj = Convert.ToDateTime(dr["xgsj"].ToString());
                    M_Hhygl.shxg = false;
                    M_Hhygl.shqr = true;
                    M_Hhygl.is_top = Convert.ToBoolean(dr["is_top"].ToString());
                    M_Hhygl.is_select = Convert.ToBoolean(dr["is_select"].ToString());
                    M_Hhygl.fkje = Convert.ToDecimal(dr["fkje"].ToString());
                    M_Hhygl.parent_hykh = dr["parent_hykh"].ToString();   //����
                    M_Hhygl.czy = dr["czy"].ToString();
                    M_Hhygl.xsy = dr["xsy"].ToString();

                    //���ݻ�Ա���Ŷ�����ͬ�����������ͬ���޸�,��Ȼ��ֱ�����ص���Ա��

                    DataSet DS_Hhyglservice = new DataSet();
                    DS_Hhyglservice = B_Hhygl.GetList("hykh='" + hykh_service + "'");
                    if (DS_Hhyglservice != null && DS_Hhyglservice.Tables[0].Rows.Count > 0)
                    {
                        M_Hhygl.id = Convert.ToInt32(DS_Hhyglservice.Tables[0].Rows[0]["id"].ToString());
                        if (B_Hhygl.Update(M_Hhygl))
                        {
                            s = common_file.common_app.get_suc;
                        }


                    }
                    else
                    {
                        if (B_Hhygl.Add(M_Hhygl) > 0)
                        {
                            s = common_file.common_app.get_suc;
                        }

                    }
                }
                try
                {
                    common_file.Common_hygl.Update_hygljf(DS_download);//����������¼������
                }
                catch
                { }
            }
            Common.AddMsg(DS_download, "���ػ�Ա��Ϣ��¼");

        }
        //�������سɹ����޸�Զ�̷�������ʱ��
        public static string DownLoadUpdate(string jsdatatime)
        {
            string ss = common_file.common_app.get_failure;
            url = common_file.Common.ReadXML("add", "url") + "/Hhygl/Hhygl_app.asmx";
            object[] obj = new object[2];
            obj[0] = yydh;
            obj[1] = jsdatatime;
            object result = jdgl_res_head_app.DynamicWebServiceCall.InvokeWebService(url, "Hhy_scxzsj", obj);
            ss = result.ToString();
            if (ss == common_file.common_app.get_suc)
            {
                Common.Fmain_Instance.AddMsg("�޸����ķ������л�Ա����ʱ���¼�ɹ�.");
                ss = common_file.common_app.get_suc;
            }
            else
            {

                ss = "����" + ss;
            }
            return ss;
        }
        #endregion

        /// <summary>
        /// �������޸Ĺ��Ļ�Ա��¼�޸�ʱ��
        /// </summary>
        /// <returns></returns>
        public static string GetScsj()
        {
            Model.Hhy_sc_xz_sj M_Hhyscsj = new Model.Hhy_sc_xz_sj();
            BLL.Hhy_sc_xz_sj B_Hhyscsj = new BLL.Hhy_sc_xz_sj();
            //��ѯ���ϴ��ϴ�ʱ��
            DateTime cstime = Convert.ToDateTime("1800-01-01");
            M_Hhyscsj = B_Hhyscsj.GetModelList("1=1")[0];
            if (M_Hhyscsj != null)
            {
                cstime = M_Hhyscsj.hy_scsj;
            }
            return cstime.ToString();

        }
         
        /// <summary>
        /// ���ڱ��������ϴ��󣬸����´��޸�ʱ��ĳ�ʼʱ��
        /// </summary>
        /// <param name="jsdatatime"></param>
        /// <returns></returns>
        public static string Update_Hhy_scxzsj(string jsdatatime)
        {
            string s = common_file.common_app.get_failure;
            string strsql = "update Hhy_sc_xz_sj set hy_scsj='" + jsdatatime + "'";
            int i = DbHelperSQL.ExecuteSql(strsql);
            if (i > 0)
            {
                s = common_file.common_app.get_suc;
            }
            return s;
        }

        public static void Update_hygljf(DataSet DS_Hhygl)
        {         
            if (DS_Hhygl.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in DS_Hhygl.Tables[0].Rows)
                {
                    string hykh = dr["hykh"].ToString();
                    Common_Shsc.UpdateHYJF(hykh, SumJF(hykh));//���»�Ա����
                }
            }
        }

        #region ��Ա����
        //�����Ա�ܵĻ���
        public static int SumJF(string strhykh)
        {
            int zongjifen = GetzJiFen(strhykh);  //�ܻ���
            int duijifen = GetDhJiFen(strhykh); //�Ѷһ�����
            int nowjifen = zongjifen - duijifen; //Ŀǰ����
            return nowjifen;
        }
        /// <summary>
        /// ��ȡ��Ա�ܻ���
        /// </summary>
        /// <param name="hyxm"></param>
        /// <param name="hykh"></param>
        /// <returns></returns>
        public static int GetzJiFen(string hykh)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SUM(hyjf) from Hhyjf_xfjl");
            strSql.Append(" where  hykh=@hykh");
            SqlParameter[] parameters = {					
                    new SqlParameter("@hykh", SqlDbType.NVarChar,200)};
            parameters[0].Value = hykh;
            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                return 0;
            }
            else
            {
                return decimalToInt(obj);
            }
        }
        /// <summary>
        /// ��ȡ��Ա�һ����Ļ���
        /// </summary>
        /// <param name="hyxm"></param>
        /// <param name="hykh"></param>
        /// <returns></returns>
        public static int GetDhJiFen(string hykh)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SUM(dfjf) from Hhyjf_df");
            strSql.Append(" where hykh=@hykh ");
            SqlParameter[] parameters = {
					
                    new SqlParameter("@hykh", SqlDbType.NVarChar,200)};

            parameters[0].Value = hykh;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);

            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                return 0;
            }
            else
            {
                //return Convert.ToInt32(obj.ToString());
                return decimalToInt(obj);
            }
        }
        #endregion
        #region "decimalToInt"
        /// <summary>
        /// decimalToInt ����С����3λ���� decimal ת����Int
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static int decimalToInt(object num)
        {
            int i = 0;
            if ((Object.Equals(num, null)) || (Object.Equals(num, System.DBNull.Value)))
            {
                i = 0;
            }
            else
            {
                i = Convert.ToInt32(num);
            }
            return i;
        }
        public static string decimalToStr(object num)
        {
            string s = "0";
            if ((Object.Equals(num, null)) || (Object.Equals(num, System.DBNull.Value)))
            {
                s = "0";
            }
            else
            {
                s = Convert.ToInt32(num).ToString();
                if (s == "0")
                {
                    s = "0";
                }
            }
            return s;
        }
         #endregion
    }
}
