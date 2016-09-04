using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Maticsoft.DBUtility;
using System.Data.SqlClient;
using System.Collections.Generic;
using jdgl_res_head_service.log;
namespace jdgl_res_head_service.Lskr
{
    public class Qskyd_lskr_delete
    {
        //�ϴ���Աȶ������������Qskyd_mainrecord_lskr��Qskyd_fjrb_lskr������ͬ lsbh ��ɾ��
        //ͬʱҲ���ص����ŵ�֪ͨ�ŵ�ɾ��
        public string Qskyd_lskr_delete_UploadDS(DataSet DS)  //�ϴ�
        {

            string s = common_file.common_app.get_failure;
            if (DS != null && DS.Tables[0].Rows.Count > 0)
            {

                foreach (DataRow dr in DS.Tables[0].Rows)
                {
                    SqlParameter[] parameters = {
					new SqlParameter("@yydh", SqlDbType.VarChar,50),
					new SqlParameter("@qymc", SqlDbType.VarChar,50),
					new SqlParameter("@lsbh", SqlDbType.VarChar,50),
					new SqlParameter("@shsc", SqlDbType.Bit,1),
					new SqlParameter("@czsj", SqlDbType.DateTime)};

                    string strlsbh = dr["lsbh"].ToString();
                    parameters[0].Value = dr["yydh"];
                    parameters[1].Value = dr["qymc"];
                    parameters[2].Value = dr["lsbh"];
                    parameters[3].Value = true;
                    parameters[4].Value = DateTime.Now;
                    SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "Qskyd_lskr_delete_ADD", parameters);
                    //��Ӻ�ɾ��д�ڴ�������
           
                }
                s = common_file.common_app.get_suc;
            }
            return s;
        }
        

        //Qskyd_fjrb_lskr��Ϣ���أ����ض��ŵ����ط���dataset
        public DataSet Qskyd_lskr_delete_download_DS(string yydh, out string csdatatime, out string jsdatatime)
        {
            
            BLL.Qskyd_lskr_delete B_Qskyd_lskr_delete = new BLL.Qskyd_lskr_delete();
            Model.Qskyd_lskr_delete M_Qskyd_lskr_delete = new Model.Qskyd_lskr_delete();
            Model.Lskr_sc_xz_sj M_Lskrscsj = new Model.Lskr_sc_xz_sj();
            BLL.Lskr_sc_xz_sj B_Lskrscsj = new BLL.Lskr_sc_xz_sj();
            string jstime = DateTime.Now.ToString();
            DataSet DS_Qskyd_lskr_delete = new DataSet();

            csdatatime = jsdatatime = string.Empty;
            //��ѯ���ϴ��ϴ�ʱ��
            DateTime cstime = Convert.ToDateTime("1800-01-01");
            if (yydh != "" && yydh != null)
            {
                List<Model.Lskr_sc_xz_sj> listlskr = B_Lskrscsj.GetModelList("yydh='" + yydh + "'");
                if (listlskr.Count > 0)
                {
                    M_Lskrscsj = listlskr[0];
                    cstime = M_Lskrscsj.scsj;
                    jsdatatime = jstime;
                    csdatatime = cstime.ToString();
                    DS_Qskyd_lskr_delete = B_Qskyd_lskr_delete.GetList(1000, "yydh<>'" + yydh + "' and czsj>='" + cstime + "' and czsj<'" + jstime + "'", "id");
                }
            }
            else
            {
                LogHelper.WriteLog("���ķ�������Lskr_sc_xz_sj��û������yydhΪ:" + yydh + "���ŵ��ʼ���صļ�¼��Ϣ,����������Ϣ");
                DS_Qskyd_lskr_delete = null;
            }
            return DS_Qskyd_lskr_delete;
        }
        //���ŵ�����Qskyd_lskr_delete
        public string Qskyd_lskr_delete_download(string yydh, out string csdatetime, out string jsdatatime, out  DataSet DS_download)
        {
            string ss = common_file.common_app.get_failure;

            DS_download = null;
            jsdatatime = "1800-01-01";   //����ʱ��
            csdatetime = "1800-01-01";   //��ʼʱ��
            DataSet DS_Qskyd_lskr_delete;
            DS_Qskyd_lskr_delete = Qskyd_lskr_delete_download_DS(yydh, out csdatetime, out jsdatatime);
            if (DS_Qskyd_lskr_delete != null)
            {
                DS_download = DS_Qskyd_lskr_delete;
                ss = common_file.common_app.get_suc;
            }
            return ss;
        }

    }
}
