using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using jdgl_res_head_app.Model;

namespace jdgl_res_head_app.BLL
{
    public class Common
    {
        public Common()
        { }
        private readonly jdgl_res_head_app.DAL.Common dal = new jdgl_res_head_app.DAL.Common();

        /// ��������б�
        public DataSet GetList(string strSelect, string strWhere)
        {
            return dal.GetList(strSelect, strWhere);

        }
        /// ִ���������
        public int ExecuteSql(string SQLString)
        {
            return dal.ExecuteSql(SQLString);

        }


    }
}

