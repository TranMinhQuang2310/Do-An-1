using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ExpenditureController : Controller
    {
        private QuanLiChiTieuEntities1 db = new QuanLiChiTieuEntities1();

        // GET: /Expenditure/
        public ActionResult Index()
        {
            var model = db.QLCTs.ToList();
            return View(model);
        }

        // GET: /Expenditure/Details/5
        public ActionResult Details(int? id)
        {
            var model = db.QLCTs.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // GET: /Expenditure/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Expenditure/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(QLCT model)
        {
            ValidateExpenditure(model);
            if (ModelState.IsValid)
            {
                model.Date = DateTime.Today;
                db.QLCTs.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        private void ValidateExpenditure(QLCT model)
        {
            if(model.Amount <= 0)
            {
                ModelState.AddModelError("Amount", "Số tiền quá ít!");
            }
            
        }

        // GET: /Expenditure/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QLCT quanlichitieu = db.QLCTs.Find(id);
            if (quanlichitieu == null)
            {
                return HttpNotFound();
            }
            return View(quanlichitieu);
        }

        // POST: /Expenditure/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,Ngay,Amount,Note")] QLCT quanlichitieu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quanlichitieu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(quanlichitieu);
        }

        // GET: /Expenditure/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QLCT quanlichitieu = db.QLCTs.Find(id);
            if (quanlichitieu == null)
            {
                return HttpNotFound();
            }
            return View(quanlichitieu);
        }

        // POST: /Expenditure/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QLCT quanlichitieu = db.QLCTs.Find(id);
            db.QLCTs.Remove(quanlichitieu);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

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
