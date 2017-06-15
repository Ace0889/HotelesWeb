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
    public class ReservacionesController : Controller
    {
        private HotelEntities db = new HotelEntities();

        // GET: Reservaciones
        public ActionResult Index()
        {
            var reservaciones = db.Reservaciones.Include(r => r.Agencia).Include(r => r.Clientes).Include(r => r.Descuentos).Include(r => r.Habitaciones).Include(r => r.Hoteles);
            return View(reservaciones.ToList());
        }

        // GET: Reservaciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservaciones reservaciones = db.Reservaciones.Find(id);
            if (reservaciones == null)
            {
                return HttpNotFound();
            }
            return View(reservaciones);
        }

        // GET: Reservaciones/Create
        public ActionResult Create()
        {
            ViewBag.agencia_reservacion = new SelectList(db.Agencia, "id_agencia", "nombre_agencia");
            ViewBag.cliente_reservacion = new SelectList(db.Clientes, "id_cliente", "nombre_cliente");
            ViewBag.descuento_reservacion = new SelectList(db.Descuentos, "codigo_descuento", "codigo_descuento");
            ViewBag.habitacion_reservacion = new SelectList(db.Habitaciones, "codigo_habitacion", "tipo_habotacion");
            ViewBag.hotel_reservacion = new SelectList(db.Hoteles, "id_hotel", "nombre_hotel");
            return View();
        }

        // POST: Reservaciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_reservacion,precio_reservacion,fecha_entrada_reservacion,fecha_salida_reservacion,nombre_reservacion,hotel_reservacion,habitacion_reservacion,cliente_reservacion,agencia_reservacion,descuento_reservacion")] Reservaciones reservaciones)
        {
            if (ModelState.IsValid)
            {
                db.Reservaciones.Add(reservaciones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.agencia_reservacion = new SelectList(db.Agencia, "id_agencia", "nombre_agencia", reservaciones.agencia_reservacion);
            ViewBag.cliente_reservacion = new SelectList(db.Clientes, "id_cliente", "nombre_cliente", reservaciones.cliente_reservacion);
            ViewBag.descuento_reservacion = new SelectList(db.Descuentos, "codigo_descuento", "codigo_descuento", reservaciones.descuento_reservacion);
            ViewBag.habitacion_reservacion = new SelectList(db.Habitaciones, "codigo_habitacion", "tipo_habotacion", reservaciones.habitacion_reservacion);
            ViewBag.hotel_reservacion = new SelectList(db.Hoteles, "id_hotel", "nombre_hotel", reservaciones.hotel_reservacion);
            return View(reservaciones);
        }

        // GET: Reservaciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservaciones reservaciones = db.Reservaciones.Find(id);
            if (reservaciones == null)
            {
                return HttpNotFound();
            }
            ViewBag.agencia_reservacion = new SelectList(db.Agencia, "id_agencia", "nombre_agencia", reservaciones.agencia_reservacion);
            ViewBag.cliente_reservacion = new SelectList(db.Clientes, "id_cliente", "nombre_cliente", reservaciones.cliente_reservacion);
            ViewBag.descuento_reservacion = new SelectList(db.Descuentos, "codigo_descuento", "codigo_descuento", reservaciones.descuento_reservacion);
            ViewBag.habitacion_reservacion = new SelectList(db.Habitaciones, "codigo_habitacion", "tipo_habotacion", reservaciones.habitacion_reservacion);
            ViewBag.hotel_reservacion = new SelectList(db.Hoteles, "id_hotel", "nombre_hotel", reservaciones.hotel_reservacion);
            return View(reservaciones);
        }

        // POST: Reservaciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_reservacion,precio_reservacion,fecha_entrada_reservacion,fecha_salida_reservacion,nombre_reservacion,hotel_reservacion,habitacion_reservacion,cliente_reservacion,agencia_reservacion,descuento_reservacion")] Reservaciones reservaciones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reservaciones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.agencia_reservacion = new SelectList(db.Agencia, "id_agencia", "nombre_agencia", reservaciones.agencia_reservacion);
            ViewBag.cliente_reservacion = new SelectList(db.Clientes, "id_cliente", "nombre_cliente", reservaciones.cliente_reservacion);
            ViewBag.descuento_reservacion = new SelectList(db.Descuentos, "codigo_descuento", "codigo_descuento", reservaciones.descuento_reservacion);
            ViewBag.habitacion_reservacion = new SelectList(db.Habitaciones, "codigo_habitacion", "tipo_habotacion", reservaciones.habitacion_reservacion);
            ViewBag.hotel_reservacion = new SelectList(db.Hoteles, "id_hotel", "nombre_hotel", reservaciones.hotel_reservacion);
            return View(reservaciones);
        }

        // GET: Reservaciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservaciones reservaciones = db.Reservaciones.Find(id);
            if (reservaciones == null)
            {
                return HttpNotFound();
            }
            return View(reservaciones);
        }

        // POST: Reservaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reservaciones reservaciones = db.Reservaciones.Find(id);
            db.Reservaciones.Remove(reservaciones);
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
