using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;

namespace Hotel_app.common_file
{
    class Common_ReadAccess
    {

        //��Excel�ļ����������ݼ�
        public DataSet ReadDataToDataSet()
        {
            // ����DataSet�����ڴ洢����.
            DataSet testDataSet = new DataSet(); 
        /// <summary>
        /// Access �����ݿ������ַ���.
        /// </summary>
        /// 
            string IDCardsInfoDBPath = Application.StartupPath + "\\IDcardsInfoDB\\HX_ScanDb.mdb";
            string connString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + IDCardsInfoDBPath;

        /// <summary>
        /// ���ڲ�ѯ�� SQL ���.
        /// </summary>
         const string SQL = "SELECT *   FROM   ScanResult ";


            // �������ݿ�����.
            OleDbConnection conn = new OleDbConnection(connString);

            // ����һ��������
            OleDbDataAdapter adapter = new OleDbDataAdapter(SQL, conn);

            // ִ�в�ѯ���������ݵ���DataSet.
            adapter.Fill(testDataSet, "SfzScanResult");
            
            // �ر����ݿ�����.
            conn.Close();
            return testDataSet;
            // ����DataSet�е�ÿһ������.
            //foreach (DataRow testRow in testDataSet.Tables["SfzScanResult"].Rows)
            //{
            //    // ���������������ݣ��������Ļ��.
            //    Console.WriteLine("ID: {0}   Name: {1}",
            //        testRow["member_type_code"], testRow["member_type_name"]
            //        );
            //}
        }


    }
}
