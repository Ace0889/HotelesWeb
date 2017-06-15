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
    public class TarjetasController : Controller
    {
        private HotelEntities db = new HotelEntities();

        // GET: Tarjetas
        public ActionResult Index()
        {
            return View(db.Tarjetas.ToList());
        }

        // GET: Tarjetas/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarjetas tarjetas = db.Tarjetas.Find(id);
            if (tarjetas == null)
            {
                return HttpNotFound();
            }
            return View(tarjetas);
        }

        // GET: Tarjetas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tarjetas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "num_tarjeta,titular_tarjeta,fecha_venc_tarjeta")] Tarjetas tarjetas)
        {
            if (ModelState.IsValid)
            {
                db.Tarjetas.Add(tarjetas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tarjetas);
        }

        // GET: Tarjetas/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarjetas tarjetas = db.Tarjetas.Find(id);
            if (tarjetas == null)
            {
                return HttpNotFound();
            }
            return View(tarjetas);
        }

        // POST: Tarjetas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "num_tarjeta,titular_tarjeta,fecha_venc_tarjeta")] Tarjetas tarjetas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tarjetas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tarjetas);
        }

        // GET: Tarjetas/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarjetas tarjetas = db.Tarjetas.Find(id);
            if (tarjetas == null)
            {
                return HttpNotFound();
            }
            return View(tarjetas);
        }

        // POST: Tarjetas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Tarjetas tarjetas = db.Tarjetas.Find(id);
            db.Tarjetas.Remove(tarjetas);
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
