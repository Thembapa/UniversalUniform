using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace UniversalUniform
{

    public class Data
    {

        public DataSet returnDS(string SP, string DSName, SqlParameter sqlparameter)
        {
            DataSet DS = new DataSet(DSName);
            SqlConnection conn = new SqlConnection(UniversalUniform.Properties.Settings.Default.DBCon);
            using (conn)
            {
                SqlCommand sqlComm = new SqlCommand(SP, conn);
                sqlComm.Parameters.Add(sqlparameter);

                sqlComm.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlComm;

                da.Fill(DS);
                conn.Close();
                return DS;
            }


        }

        public DataSet returnDS(string SP, string DSName, SqlParameter sqlparameter, SqlParameter sqlparameter2)
        {
            DataSet DS = new DataSet(DSName);
            SqlConnection conn = new SqlConnection(UniversalUniform.Properties.Settings.Default.DBCon);

            using (conn)
            {
                SqlCommand sqlComm = new SqlCommand(SP, conn);
                sqlComm.Parameters.Add(sqlparameter);
                sqlComm.Parameters.Add(sqlparameter2);

                sqlComm.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlComm;

                da.Fill(DS);
                conn.Close();
                return DS;
            }


        }
        public DataSet returnDS(string SP, string DSName, SqlParameter sqlparameter, SqlParameter sqlparameter2, SqlParameter sqlparameter3)
        {
            DataSet DS = new DataSet(DSName);
            SqlConnection conn = new SqlConnection(UniversalUniform.Properties.Settings.Default.DBCon);
            using (conn)
            {
                SqlCommand sqlComm = new SqlCommand(SP, conn);
                sqlComm.Parameters.Add(sqlparameter);
                sqlComm.Parameters.Add(sqlparameter2);
                sqlComm.Parameters.Add(sqlparameter3);

                sqlComm.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlComm;

                da.Fill(DS);
                conn.Close();
                return DS;
            }


        }
        public DataSet returnDS(string SP, string DSName, SqlParameter sqlparameter, SqlParameter sqlparameter2, SqlParameter sqlparameter3, SqlParameter sqlparameter4)
        {
            DataSet DS = new DataSet(DSName);
            SqlConnection conn = new SqlConnection(UniversalUniform.Properties.Settings.Default.DBCon);
            using (conn)
            {
                SqlCommand sqlComm = new SqlCommand(SP, conn);
                sqlComm.Parameters.Add(sqlparameter);
                sqlComm.Parameters.Add(sqlparameter2);
                sqlComm.Parameters.Add(sqlparameter3);
                sqlComm.Parameters.Add(sqlparameter4);

                sqlComm.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlComm;

                da.Fill(DS);
                conn.Close();
                return DS;
            }


        }


        public DataSet returnDS(string SP, string DSName)
        {
            DataSet DS = new DataSet(DSName);
            SqlConnection conn = new SqlConnection(UniversalUniform.Properties.Settings.Default.DBCon);
            using (conn)
            {
                SqlCommand sqlComm = new SqlCommand(SP, conn);
                sqlComm.CommandTimeout = 1000;
                sqlComm.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlComm;

                da.Fill(DS);
                conn.Close();
                return DS;
            }
        }

        public DataSet returnDS(SqlCommand command, string DSName)
        {
            DataSet DS = new DataSet(DSName);
            SqlConnection conn = new SqlConnection(UniversalUniform.Properties.Settings.Default.DBCon);
            command.Connection = conn;
            using (conn)
            {
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = command;

                da.Fill(DS);
                conn.Close();
                return DS;
            }
        }


        public DataSet returnDS(SqlCommand command, string DSName, bool TextExec)
        {
            DataSet DS = new DataSet(DSName);
            SqlConnection conn = new SqlConnection(UniversalUniform.Properties.Settings.Default.DBCon);
            command.Connection = conn;
            using (conn)
            {
                if (TextExec)
                {
                    command.CommandType = CommandType.Text;
                }
                else
                {
                    command.CommandType = CommandType.StoredProcedure;
                }
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = command;

                da.Fill(DS);
                conn.Close();
                return DS;
            }
        }

        public void InsertType(SqlCommand sqlComm)
        {
            SqlConnection conn = new SqlConnection(UniversalUniform.Properties.Settings.Default.DBCon);
            using (conn)
            {
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.Connection = conn;
                conn.Open();
                sqlComm.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void DeleteType(SqlCommand sqlComm)
        {
            SqlConnection conn = new SqlConnection(UniversalUniform.Properties.Settings.Default.DBCon);
            using (conn)
            {
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.Connection = conn;
                conn.Open();
                sqlComm.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void UpdateType(SqlCommand sqlComm)
        {
            SqlConnection conn = new SqlConnection(UniversalUniform.Properties.Settings.Default.DBCon);
            using (conn)
            {
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.Connection = conn;
                conn.Open();
                sqlComm.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void ExecuteSQL(SqlCommand sqlComm)
        {
            SqlConnection conn = new SqlConnection(UniversalUniform.Properties.Settings.Default.DBCon);
            using (conn)
            {
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.Connection = conn;
                conn.Open();
                sqlComm.ExecuteNonQuery();
                conn.Close();
            }
        }

        public int ExecuteSQLReturnID(SqlCommand sqlComm, string IDName)
        {
            int contractID = 0;
            SqlConnection conn = new SqlConnection(UniversalUniform.Properties.Settings.Default.DBCon);
            using (conn)
            {
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.Connection = conn;
                conn.Open();
                sqlComm.ExecuteNonQuery();
                contractID = Convert.ToInt32(sqlComm.Parameters[IDName].Value);
                conn.Close();
            }
            return contractID;
        }

        public string ExecuteSQLReturnstringID(SqlCommand sqlComm, string IDName)
        {
            string contractID = "";
            SqlConnection conn = new SqlConnection(UniversalUniform.Properties.Settings.Default.DBCon);
            using (conn)
            {
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.Connection = conn;
                conn.Open();
                sqlComm.ExecuteNonQuery();
                contractID = sqlComm.Parameters[IDName].Value.ToString();
                conn.Close();
            }
            return contractID;
        }
    }
}