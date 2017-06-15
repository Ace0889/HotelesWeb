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
    public class HabitacionesXHotelsController : Controller
    {
        private HotelEntities db = new HotelEntities();

        // GET: HabitacionesXHotels
        public ActionResult Index()
        {
            var habitacionesXHotel = db.HabitacionesXHotel.Include(h => h.Habitaciones).Include(h => h.Hoteles);
            return View(habitacionesXHotel.ToList());
        }

        // GET: HabitacionesXHotels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HabitacionesXHotel habitacionesXHotel = db.HabitacionesXHotel.Find(id);
            if (habitacionesXHotel == null)
            {
                return HttpNotFound();
            }
            return View(habitacionesXHotel);
        }

        // GET: HabitacionesXHotels/Create
        public ActionResult Create()
        {
            ViewBag.codigo_habitacion = new SelectList(db.Habitaciones, "codigo_habitacion", "tipo_habotacion");
            ViewBag.id_hotel = new SelectList(db.Hoteles, "id_hotel", "nombre_hotel");
            return View();
        }

        // POST: HabitacionesXHotels/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_relacion,id_hotel,codigo_habitacion,estado_habitacion")] HabitacionesXHotel habitacionesXHotel)
        {
            if (ModelState.IsValid)
            {
                db.HabitacionesXHotel.Add(habitacionesXHotel);
                db.SaveChanges();
                return RedirectToAction("/Index");
            }

            ViewBag.codigo_habitacion = new SelectList(db.Habitaciones, "codigo_habitacion", "tipo_habotacion", habitacionesXHotel.codigo_habitacion);
            ViewBag.id_hotel = new SelectList(db.Hoteles, "id_hotel", "nombre_hotel", habitacionesXHotel.id_hotel);
            return View(habitacionesXHotel);
        }

        // GET: HabitacionesXHotels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HabitacionesXHotel habitacionesXHotel = db.HabitacionesXHotel.Find(id);
            if (habitacionesXHotel == null)
            {
                return HttpNotFound();
            }
            ViewBag.codigo_habitacion = new SelectList(db.Habitaciones, "codigo_habitacion", "tipo_habotacion", habitacionesXHotel.codigo_habitacion);
            ViewBag.id_hotel = new SelectList(db.Hoteles, "id_hotel", "nombre_hotel", habitacionesXHotel.id_hotel);
            return View(habitacionesXHotel);
        }

        // POST: HabitacionesXHotels/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_relacion,id_hotel,codigo_habitacion,estado_habitacion")] HabitacionesXHotel habitacionesXHotel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(habitacionesXHotel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("/Index");
            }
            ViewBag.codigo_habitacion = new SelectList(db.Habitaciones, "codigo_habitacion", "tipo_habotacion", habitacionesXHotel.codigo_habitacion);
            ViewBag.id_hotel = new SelectList(db.Hoteles, "id_hotel", "nombre_hotel", habitacionesXHotel.id_hotel);
            return View(habitacionesXHotel);
        }

        // GET: HabitacionesXHotels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HabitacionesXHotel habitacionesXHotel = db.HabitacionesXHotel.Find(id);
            if (habitacionesXHotel == null)
            {
                return HttpNotFound();
            }
            return View(habitacionesXHotel);
        }

        // POST: HabitacionesXHotels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HabitacionesXHotel habitacionesXHotel = db.HabitacionesXHotel.Find(id);
            db.HabitacionesXHotel.Remove(habitacionesXHotel);
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
    }
}
