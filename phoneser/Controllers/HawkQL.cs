using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;

namespace phoneser.Controllers
{
    public class HawkQL
    {
        OleDbConnection connection;
        OleDbCommand comamd;
        OleDbTransaction transsql;
        //OleDbDataAdapter OleAdapter;
        Models.svinfo i = new Models.svinfo();
        public HawkQL()
        {
            connection = new OleDbConnection("Data Source = DESKTOP-IVMG6H0\\SQLEXPRESS; Initial Catalog = phonese; User ID =sa; Password =z ;Provider=SQLOLEDB");
            comamd = new OleDbCommand("", connection);
            //OleAdapter = new OleDbDataAdapter(comamd);
        }

        public DataTable getTable(string sqlselect, OleDbParameter[] parameters)
        {
            comamd.CommandText = sqlselect;
            comamd.CommandType = CommandType.Text;
            DataTable dt = new DataTable();
            try
            {
                connection.Open();
                comamd.Parameters.Clear();
                if (parameters != null)


                    comamd.Parameters.AddRange(parameters);
                OleDbDataReader reader = comamd.ExecuteReader();
                dt.Load(reader);
                connection.Close();
                return dt;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public DataTable getTableSP(string storeproc, OleDbParameter[] parameters)
        {
            comamd.CommandText = storeproc;
            comamd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            try
            {
                connection.Open();
                comamd.Parameters.Clear();
                if (parameters != null)
                    comamd.Parameters.AddRange(parameters);
                OleDbDataReader reader = comamd.ExecuteReader();
                dt.Load(reader);
                connection.Close();
                return dt;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public int executeSp(string store, OleDbParameter[] parameters)
        {
            try
            {
                connection.Open();
                comamd.CommandText = store;
                comamd.CommandType = CommandType.StoredProcedure;
                comamd.Parameters.Clear();
                if (parameters != null)
                    comamd.Parameters.AddRange(parameters);
                int n = comamd.ExecuteNonQuery();
                connection.Close();
                return n;
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }

        public int executeQl(string sql, OleDbParameter[] parameters)
        {
            try
            {
                connection.Open();
                comamd.CommandText = sql;
                comamd.CommandType = CommandType.Text;
                comamd.Parameters.Clear();
                if (parameters != null)
                    comamd.Parameters.AddRange(parameters);
                int n = comamd.ExecuteNonQuery();
                connection.Close();
                return n;
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }
    }
}