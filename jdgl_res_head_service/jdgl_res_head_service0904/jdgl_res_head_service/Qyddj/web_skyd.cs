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

namespace jdgl_res_head_service.Qyddj
{
    public class web_skyd
    {
        //���ض��ŵ�����Ԥ�����ĵ���Ϣ
        public DataSet yddj_download_DS(string qymc, out  int rows, out  bool status)
        {
            DataSet DS_skyd = new DataSet();
            rows = 0;
            status = false;
            BLL.Web_skyd B_Web_skyd = new BLL.Web_skyd();

            DS_skyd = B_Web_skyd.GetList("qymc='" + qymc + "'  and  sfqr='1'  and  shsc='0'");
            if (DS_skyd != null)
            {
                rows = DS_skyd.Tables[0].Rows.Count;
                status = true;
            
            }
            return DS_skyd;
        }

        //Web_Qskyd_fjrb���ض��ŵ�����Ԥ�����䷿�͵���Ϣ
        public DataSet WebQskyd_fjrb_DS(string qymc,string lsbh,out int rows)
        {
            DataSet DS_WebQskyd_fjrb = new DataSet();
            rows = 0;
            BLL.Web_Qskyd_fjrb B_Web_Qskyd_fjrb = new BLL.Web_Qskyd_fjrb();
            DS_WebQskyd_fjrb = B_Web_Qskyd_fjrb.GetList("qymc='" + qymc + "' and lsbh='"+lsbh+"'");
            if (DS_WebQskyd_fjrb != null)
            {
                rows = DS_WebQskyd_fjrb.Tables[0].Rows.Count;

            }
            return DS_WebQskyd_fjrb;
        }
        //��InsertToQyddjlsbhbg_yy�������
        public string InsertToQyddjlsbhbg_yy(string yclsbh, string bdlsbh, string bdyydh)
        {
            string ss = common_file.common_app.get_failure;
            SqlParameter[] sp ={ 
            new SqlParameter("@yclsbh",SqlDbType.VarChar),
            new SqlParameter("@bdlsbh",SqlDbType.VarChar),
            new SqlParameter("@bdyydh",SqlDbType.VarChar),
            new SqlParameter("@rows",SqlDbType.Int)
            };
            sp[0].Value = yclsbh;
            sp[1].Value = bdlsbh;
            sp[2].Value = bdyydh;
            sp[3].Direction = ParameterDirection.Output;
            DbHelperSQLP helperSQLP = new DbHelperSQLP();
            helperSQLP.RunProcedure("InsertToQyddjlsbhbg_yy", sp);
            int result = Convert.ToInt32(sp[3].Value.ToString());
            if (result > 0)
            {
                ss = common_file.common_app.get_suc;
            }
            return ss;
        }

        //�޸�Web_Qskyd_fjrb����״̬shsc=1
        public string Web_Qskyd_fjrb_Updateshsc(int id)
        {
            string ss = common_file.common_app.get_failure;
            SqlParameter[] sp ={ 
            new SqlParameter("@id",SqlDbType.Int)
   
           
            };
            sp[0].Value = id;
            int result = result = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "Web_Qskyd_fjrb_Updateshsc", sp);
            if (result > 0)
            {
                ss = common_file.common_app.get_suc;
            }
            return ss;
        }


        //�ŵ���������Ԥ�����ݺ��޸Ķ���״̬
        public string yddj_ydownloadDataStatus(DataSet DS_yddj_downloadData)
        {
            string ss = common_file.common_app.get_failure;

            BLL.Web_skyd B_Web_skyd = new BLL.Web_skyd();
            Model.Web_skyd M_Web_skyd = new Model.Web_skyd();
            foreach (DataRow dr in DS_yddj_downloadData.Tables[0].Rows)
            {
                string id = dr[0].ToString();
                M_Web_skyd.id = Convert.ToInt32(id);
                int result = 0;
                //ִ�д洢�����޸�״̬
               
                SqlParameter[] pa ={ new SqlParameter("@id", SqlDbType.VarChar) };
                pa[0].Value = dr[0].ToString();

                result= SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "ydownloadDataStatus", pa);
                //�ɹ�����
                if (result > 0)
                {
                    ss = common_file.common_app.get_suc;
                    continue;
                }
                //�����ж�
                else
                {
                    ss = common_file.common_app.get_failure;
                    break;
                }
            }
            return ss;
        }
    }
}
