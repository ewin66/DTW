using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//�����������
namespace jdgl_res_head_app.DAL
{
   public class Common
    {
       public Common()
		{}
        /// ��������б�
        public DataSet GetList(string strSelect,string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            if (strSelect.Trim() != "")
            {
                strSql.Append(strSelect);
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" where " + strWhere);
                }
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// ִ���������
        public int ExecuteSql(string SQLString)
        {
            int i = 0;
            StringBuilder strSql = new StringBuilder();
            if (SQLString.Trim() != "")
            {
               i= DbHelperSQL.ExecuteSql(SQLString);
            }
            return i;
        }


    }
}
