using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyFirstMvc.Models;
using System.Data;
using System.Data.SqlClient;
using System.Net;

namespace MyFirstMvc.Controllers
{
    public class SchoolArchitectureController : Controller
    {
        // GET: SchoolArchitecture
        private shivadbEntities db = new shivadbEntities();
        public ActionResult Index()
        {
            CrudOperationsBAL cbal = new CrudOperationsBAL();
            DataTable dt = cbal.selectSchool();
            return View(dt);
            //return View();
        }
        [HttpPost]
        public ActionResult Index(int id)
        {
            //var item = db.schools.Where(m => m.Sid == id).First();
            //DataTable dt = new DataTable();
            //dt.Columns.AddRange(new[] { new DataColumn("Sid",typeof(int)),
            //                           new DataColumn("Studentname",typeof(string)),
            //                            new DataColumn("location",typeof(string)),
            //                             new DataColumn("mobile",typeof(string)),
            //                              new DataColumn("Gender",typeof(string))});
            //DataRow row;
            //row = dt.NewRow();
            //row[0] = item.Sid;
            //row[1] = item.Studentname;
            //row[2] = item.location;
            //row[3] = item.mobile;
            //row[4] = item.Gender;
            //dt.Rows.Add(row);

            //return View(dt);

            CrudOperationsBAL cbal = new CrudOperationsBAL();
            school sl = new school();
            sl.Sid = id;
            DataTable dt = cbal.selectwhereSchool(sl);
            return View(dt);

        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        
        public ActionResult Create(school sl)
        {
            CrudOperationsBAL cbal = new CrudOperationsBAL();
            cbal.insertSchool(sl);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            var item = db.schools.Where(m => m.Sid == id).First();
            return View(item);
        }
        [HttpPost]
        public ActionResult Edit(school sl)
        {
            CrudOperationsBAL cbal = new CrudOperationsBAL();
            cbal.updateschool(sl);
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            var item = db.schools.Where(m => m.Sid == id).First();
            return View(item);
        }
        public ActionResult Delete(int id)
        {
            var item = db.schools.Where(m => m.Sid == id).First();
            return View(item);
        }
        [HttpPost]
        public ActionResult Delete(school sl )
        {
            //var item = db.schools.Where(m => m.Sid == id).First();
            //db.schools.Remove(item);
            //db.SaveChanges();
            //return RedirectToAction("Index");


            CrudOperationsBAL Cbal = new CrudOperationsBAL();
            //school sl = new school();

            Cbal.deletdSchool(sl);
            return RedirectToAction("Index");
        }

    }
}