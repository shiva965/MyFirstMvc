using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace MyFirstMvc.Models
{
    public class CrudOperationsDAL
    {
        public void InsertSchool(school sl)
        {
            SqlParameter[] prms = new SqlParameter[4];

            prms[0] = new SqlParameter("@Studentname",sl.Studentname);
            prms[1] = new SqlParameter("@location",sl.location);
            prms[2] = new SqlParameter("@mobile", sl.mobile);
            prms[3] = new SqlParameter("@Gender", sl.Gender);

            MvcDBHelper.ExecuteNonQuery("InsertSchool", prms);
        }
        public DataTable selectSChool()
        {
            DataTable dt = MvcDBHelper.GETtableFromsp("selectschool");
            return dt;
        }
        public void updateschool(school sl)
        {
            SqlParameter[] prms = new SqlParameter[5];

            prms[0] = new SqlParameter("@Sid", sl.Sid);
            prms[1] = new SqlParameter("@Studentname", sl.Studentname);
            prms[2] = new SqlParameter("@location", sl.location);
            prms[3] = new SqlParameter("@mobile", sl.mobile);
            prms[4] = new SqlParameter("@Gender", sl.Gender);
            MvcDBHelper.ExecuteNonQuery("updateschool", prms);
        }
        public void deleteSchool(school sl)
        {
            SqlParameter[] prms = new SqlParameter[1];
            prms[0] = new SqlParameter("@sid", sl.Sid);
            MvcDBHelper.ExecuteNonQuery("DeleteSchool", prms);
        }
        public DataTable Selectwhereschool(school sl)
        {
            SqlParameter[] prms = new SqlParameter[1];
            prms[0] = new SqlParameter("@sid", sl.Sid);
            DataTable dt = MvcDBHelper.GETtableFromsp("selectwhereSchool", prms);
            return dt;
        }
    }
}