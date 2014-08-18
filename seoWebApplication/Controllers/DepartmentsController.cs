using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using seoWebApplication.Data;
using seoWebApplication.Service;

namespace seoWebApplication.Controllers
{
    public class DepartmentsController : Controller
    {
        private SeoWebAppEntities db = new SeoWebAppEntities();
        private DepartmentService _departmentService = new DepartmentService();
        // GET: /Departments/
        public ActionResult Index()
        {
            foreach(seoWebApplication.Data.department dep in db.departments){
                Models.Departments depts = new Models.Departments();
                depts.department_id = dep.department_id;
                depts.Description = dep.Description;
                depts.Name = dep.Name;
                depts.webstore_id = dep.webstore_id;
                _departmentService.Create(depts);
            }
            return View(db.departments.ToList());
        }

        // GET: /Departments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            seoWebApplication.Data.department department = db.departments.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // GET: /Departments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Departments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include="department_id,webstore_id,Description,Name,InsertDate,InsertENTUserAccountId,UpdateDate,UpdateENTUserAccountId,Version")] department department)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.departments.Add(department);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(department);
        //}

        // GET: /Departments/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    department department = db.departments.Find(id);
        //    if (department == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(department);
        //}

        // POST: /Departments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="department_id,webstore_id,Description,Name,InsertDate,InsertENTUserAccountId,UpdateDate,UpdateENTUserAccountId,Version")] department department)
        {
            if (ModelState.IsValid)
            {
                db.Entry(department).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(department);
        }

        // GET: /Departments/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    department department = db.departments.Find(id);
        //    if (department == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(department);
        //}

        // POST: /Departments/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    department department = db.departments.Find(id);
        //    db.departments.Remove(department);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
