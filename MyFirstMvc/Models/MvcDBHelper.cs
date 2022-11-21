using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace MyFirstMvc.Models
{
    public static class MvcDBHelper
    {
        private static readonly string connectionString = "Data source=ADMIN-PC\\SQLEXPRESS;Initial Catalog = shivadb;Integrated security=true";
        public static void ExecuteNonQuery(string sp, SqlParameter[] prms)
        {

            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd = new SqlCommand(sp, cn);
                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(prms);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {
                cn.Close();
                cmd.Dispose();
            }
        }
        public static DataTable GETtableFromsp(string sp, SqlParameter[] prms)
        {
            SqlConnection cn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd = new SqlCommand(sp, cn);
                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(prms);
                DataTable dt = new DataTable();

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cn.Close();
            }
        }
        public static DataTable GETtableFromsp(string sp)
        {
            SqlConnection cn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd = new SqlCommand(sp, cn);
                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cn.Close();
            }
        }
    }
}