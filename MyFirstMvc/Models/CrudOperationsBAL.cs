using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace MyFirstMvc.Models
{
    public class CrudOperationsBAL
    {
        public  void insertSchool(school sl)
        {
            CrudOperationsDAL cdl = new CrudOperationsDAL();
            cdl.InsertSchool(sl);
        }
       public DataTable selectSchool()
        {
            CrudOperationsDAL cdl = new CrudOperationsDAL();
            DataTable dt = cdl.selectSChool();
            return dt;
        }
       public void updateschool(school sl)
        {
            CrudOperationsDAL cdl = new CrudOperationsDAL();
            cdl.updateschool(sl);
        }
        public void deletdSchool(school sl)
        {
            CrudOperationsDAL cdl = new CrudOperationsDAL();
            cdl.deleteSchool(sl);
        }
        public DataTable selectwhereSchool(school sl)
        {
            CrudOperationsDAL cdl = new CrudOperationsDAL();
            DataTable dt = cdl.Selectwhereschool(sl);
            return dt;
        }
    }
}