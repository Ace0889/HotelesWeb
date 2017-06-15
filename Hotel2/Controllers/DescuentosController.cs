using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hotel2;

namespace Hotel2.Controllers
{
    public class DescuentosController : Controller
    {
        private HotelEntities db = new HotelEntities();

        // GET: Descuentos
        public ActionResult Index()
        {
            return View(db.Descuentos.ToList());
        }

        // GET: Descuentos/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Descuentos descuentos = db.Descuentos.Find(id);
            if (descuentos == null)
            {
                return HttpNotFound();
            }
            return View(descuentos);
        }

        // GET: Descuentos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Descuentos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codigo_descuento,porcentaje_descuento")] Descuentos descuentos)
        {
            if (ModelState.IsValid)
            {
                db.Descuentos.Add(descuentos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(descuentos);
        }

        // GET: Descuentos/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Descuentos descuentos = db.Descuentos.Find(id);
            if (descuentos == null)
            {
                return HttpNotFound();
            }
            return View(descuentos);
        }

        // POST: Descuentos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codigo_descuento,porcentaje_descuento")] Descuentos descuentos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(descuentos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(descuentos);
        }

        // GET: Descuentos/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Descuentos descuentos = db.Descuentos.Find(id);
            if (descuentos == null)
            {
                return HttpNotFound();
            }
            return View(descuentos);
        }

        // POST: Descuentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Descuentos descuentos = db.Descuentos.Find(id);
            db.Descuentos.Remove(descuentos);
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
