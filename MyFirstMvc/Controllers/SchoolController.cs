using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyFirstMvc.Models;
using System.Data;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Net;
using PagedList;
using PagedList.Mvc;
using System.Collections;




namespace MyFirstMvc.Controllers
{
    public class SchoolController : Controller
    {
        private shivadbEntities db = new shivadbEntities();
        public ActionResult Index(int? page)
        {
            //IList<string> lst = new List<string>();
            //       lst.Add("shiva");
            //      lst.Add("prasanth");
            //TempData["1"] = "ram";
            //return RedirectToAction("create");
            var item = db.schools.ToList().ToPagedList(page ?? 1, 5);

           return View(item);



            // return View(db.schools.ToList().ToPagedList(page ?? 1, 5));
        }
        public ActionResult create()
        {
            string k = Convert.ToString(TempData["1"]);
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult create(FormCollection frm)
        {
            if(ModelState.IsValid)
            {
                school sl = new school();
                sl.Studentname = frm["Studentname"];
                sl.location = frm["location"];
                sl.mobile = frm["mobile"];
                sl.Gender = frm["Gender"];
                db.schools.Add(sl);
                db.SaveChanges();
               RedirectToAction("Index");
            }
            return View();    
        }
        public ActionResult Edit(int? id)
        {
            if(id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            school sl = db.schools.Find(id);
            if(sl == null)
            {
                return HttpNotFound();
            }
            return View(sl);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Sid,Studentname,location,mobile,Gender")] school sl)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(sl).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(sl);
        //}
        //public ActionResult Edit(school sl)
        //{
        //    if (ModelState.IsValid)
        //    {

        //        db.Entry(sl).State = EntityState.Modified;
        //        db.Entry(sl.Studentname).State = EntityState.Modified;
        //        db.Entry(sl.location).State = EntityState.Modified;
        //        db.Entry(sl.mobile).State = EntityState.Modified;
        //        db.Entry(sl.Gender).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(sl);
        //}
        public ActionResult Edit( FormCollection frm)
        {
            int id = Convert.ToInt32(frm["Sid"]);
            var k = db.schools.Where(m => m.Sid == id).First();
            k.Studentname = frm["Studentname"];
            k.location = frm["location"];
            k.mobile = frm["mobile"];
            k.Gender = frm["Gender"];
            db.SaveChanges();
            return View();
        }
    }
    
}