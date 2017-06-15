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
    public class HotelesController : Controller
    {
        private HotelEntities db = new HotelEntities();

        // GET: Hoteles
        public ActionResult Index()
        {
            var hoteles = db.Hoteles.Include(h => h.Categoria);
            return View(hoteles.ToList());
        }

        // GET: Hoteles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hoteles hoteles = db.Hoteles.Find(id);
            if (hoteles == null)
            {
                return HttpNotFound();
            }
            return View(hoteles);
        }

        // GET: Hoteles/Create
        public ActionResult Create()
        {
            ViewBag.categoria_hotel = new SelectList(db.Categoria, "id_cate", "descripcion_cate");
            return View();
        }

        // POST: Hoteles/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_hotel,categoria_hotel,nombre_hotel,direccion_hotel,telefono_hotel")] Hoteles hoteles)
        {
            if (ModelState.IsValid)
            {
                db.Hoteles.Add(hoteles);
                db.SaveChanges();
                return RedirectToAction("/Index");
            }

            ViewBag.categoria_hotel = new SelectList(db.Categoria, "id_cate", "descripcion_cate", hoteles.categoria_hotel);
            return View(hoteles);
        }

        // GET: Hoteles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hoteles hoteles = db.Hoteles.Find(id);
            if (hoteles == null)
            {
                return HttpNotFound();
            }
            ViewBag.categoria_hotel = new SelectList(db.Categoria, "id_cate", "descripcion_cate", hoteles.categoria_hotel);
            return View(hoteles);
        }

        // POST: Hoteles/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_hotel,categoria_hotel,nombre_hotel,direccion_hotel,telefono_hotel")] Hoteles hoteles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hoteles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("/Index");
            }
            ViewBag.categoria_hotel = new SelectList(db.Categoria, "id_cate", "descripcion_cate", hoteles.categoria_hotel);
            return View(hoteles);
        }

        // GET: Hoteles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hoteles hoteles = db.Hoteles.Find(id);
            if (hoteles == null)
            {
                return HttpNotFound();
            }
            return View(hoteles);
        }

        // POST: Hoteles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hoteles hoteles = db.Hoteles.Find(id);
            db.Hoteles.Remove(hoteles);
            db.SaveChanges();
            return RedirectToAction("/Index");
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Mostrar()
        {
            return View(db.Hoteles.Select(p => new { p.id_hotel, p.nombre_hotel, p.direccion_hotel }).ToList());
        }

        [HttpPost]
        public ActionResult Search(string BuscarHotel)
        {

            var result = db.Hoteles.Where(x => x.nombre_hotel.Contains(BuscarHotel)).Select(p => new { p.id_hotel, p.nombre_hotel, p.direccion_hotel }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);

        }
    }
}
