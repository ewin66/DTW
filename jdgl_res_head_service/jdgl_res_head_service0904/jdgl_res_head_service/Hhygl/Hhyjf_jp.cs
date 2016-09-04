using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace jdgl_res_head_service.Hhygl
{
    public class Hhyjf_jp
    {

        //��Ʒ������Ϣ���أ����ض��ŵ����ط���dataset
        public DataSet DSHhyjfjp_download(string yydh, out  int rows, out string csdatatime, out string jsdatatime)
        {
            BLL.Hhyjf_jp B_Hhyjf_jp = new BLL.Hhyjf_jp();
            Model.Hhyjf_jp M_Hhyjf_jp = new Model.Hhyjf_jp();
            Model.Hhy_sc_xz_sj M_Hhyscsj = new Model.Hhy_sc_xz_sj();
            BLL.Hhy_sc_xz_sj B_Hhyscsj = new BLL.Hhy_sc_xz_sj();

            //��ѯ���ϴ��ϴ�ʱ��
            DateTime cstime = Convert.ToDateTime("1800-01-01");
            if (yydh != "" && yydh != null)
            {
                M_Hhyscsj = B_Hhyscsj.GetModelList("yydh='" + yydh + "'")[0];
                cstime = M_Hhyscsj.hy_scsj;

            }
            string jstime = DateTime.Now.ToString();
            DataSet DS_Hhyjf_jp = new DataSet();
            rows = 0;
            jsdatatime = jstime;
            csdatatime = cstime.ToString();
            //status = false;
            //msg = "û�в鵽Ҫ���ص�������Ϣ����Զ�̷���������";
            DS_Hhyjf_jp = B_Hhyjf_jp.GetList(200, "yydh='" + yydh + "'", "id");

            if (DS_Hhyjf_jp != null)
            {
                rows = DS_Hhyjf_jp.Tables[0].Rows.Count;
                jsdatatime = jstime;
                csdatatime = cstime.ToString();
                //status = true;
                //msg = "��ѯ�ɹ�";

            }

            return DS_Hhyjf_jp;
        }

        //���ŵ��������Ͻ�Ʒ����
        public string Hhyjfjp_download(string yydh, out  int rows, out string csdatetime, out string jsdatatime, out  DataSet DS_download)
        {
            string ss = common_file.common_app.get_failure;
            rows = 0;
            //status = false;
            DS_download = null;
            DataSet DS_Hhyjf_jp;
            //msg = "û�в鵽Ҫ���ص�������Ϣ����Զ�̷���������,webservice";
            jsdatatime = "1800-01-01";   //����ʱ��
            csdatetime = "1800-01-01";   //��ʼʱ��
            DS_Hhyjf_jp = DSHhyjfjp_download(yydh, out rows, out csdatetime, out jsdatatime);
            if (DS_Hhyjf_jp != null && rows > 0)
            {
                DS_download = DS_Hhyjf_jp;
                ss = common_file.common_app.get_suc;
            }
            return ss;
        }
    }
}
