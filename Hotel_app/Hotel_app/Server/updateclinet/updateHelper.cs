using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Diagnostics;

namespace Hotel_app.Server.updateclinet
{
    public class updateHelper
    {
        static string UpdateAppUrl = HttpContext.Current.Server.MapPath(string.Format("~/App_Data/Update/{0}", System.Web.Configuration.WebConfigurationManager.AppSettings["clientAppName"]));
        static string filePath = HttpContext.Current.Server.MapPath("~/App_Data/Update/");


        //���ɸ���ѹ����
        public static string  makeZipFiles()
        {
            string s = common_file.common_app.get_suc;
            try
            {
                GZipCompresser.Compress(filePath, HttpContext.Current.Server.MapPath("~/App_Data/Update.gzip"));

            }
            catch (Exception  ee)
            {
                s = ee.ToString() + common_file.common_app.get_failure;
            }
            return s;
        }


        public static string GetFileVersion(string filePath)
        {
            FileVersionInfo f = FileVersionInfo.GetVersionInfo(filePath);
            return f.FileVersion;
        }

        public static string GetNewVersion(string  yydh,string ClientVerison)
        {
            //�Ƚϵ�ǰ���ݿ��еİ汾�����Ŀ¼�µİ汾��������ȣ������ɸ����ļ�
            string updateVersion = GetFileVersion(UpdateAppUrl); //��ǰ�汾
            string preVersion = "";                                             //��һ�ΰ汾
            BLL.Common B_common = new Hotel_app.BLL.Common();
            DataSet ds = B_common.GetList(" select  *  from  X_update ", " id>=0  and yydh='"+yydh+"' ");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                preVersion = ds.Tables[0].Rows[0]["preVersion"].ToString();
                if (preVersion.Trim() != "")
                {
                    if (preVersion != updateVersion)
                    {
                        B_common.ExecuteSql(" update  X_update set preVersion='" + updateVersion + "'  where      Id>=0  and yydh='"+yydh+"' ");
                        makeZipFiles();
                    }
                }
            }
            return updateVersion;

        }

    }
}
