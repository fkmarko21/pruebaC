using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace proyectoMarco.Models
{
    public class DetalleProveedorsController : Controller
    {
        private BotilleriaEntities1 db = new BotilleriaEntities1();

        // GET: DetalleProveedors
        public ActionResult Index()
        {
            var detalleProveedor = db.DetalleProveedor.Include(d => d.Productos).Include(d => d.Proveedor);
            return View(detalleProveedor.ToList());
        }

        // GET: DetalleProveedors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleProveedor detalleProveedor = db.DetalleProveedor.Find(id);
            if (detalleProveedor == null)
            {
                return HttpNotFound();
            }
            return View(detalleProveedor);
        }

        // GET: DetalleProveedors/Create
        public ActionResult Create()
        {
            ViewBag.idProductos = new SelectList(db.Productos, "id", "nombre");
            ViewBag.idProveedor = new SelectList(db.Proveedor, "id", "nombreProveedor");
            return View();
        }

        // POST: DetalleProveedors/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idProductos,idProveedor,cantidad,subtotal")] DetalleProveedor detalleProveedor)
        {
            if (ModelState.IsValid)
            {
                db.DetalleProveedor.Add(detalleProveedor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idProductos = new SelectList(db.Productos, "id", "nombre", detalleProveedor.idProductos);
            ViewBag.idProveedor = new SelectList(db.Proveedor, "id", "nombreProveedor", detalleProveedor.idProveedor);
            return View(detalleProveedor);
        }

        // GET: DetalleProveedors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleProveedor detalleProveedor = db.DetalleProveedor.Find(id);
            if (detalleProveedor == null)
            {
                return HttpNotFound();
            }
            ViewBag.idProductos = new SelectList(db.Productos, "id", "nombre", detalleProveedor.idProductos);
            ViewBag.idProveedor = new SelectList(db.Proveedor, "id", "nombreProveedor", detalleProveedor.idProveedor);
            return View(detalleProveedor);
        }

        // POST: DetalleProveedors/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idProductos,idProveedor,cantidad,subtotal")] DetalleProveedor detalleProveedor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalleProveedor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idProductos = new SelectList(db.Productos, "id", "nombre", detalleProveedor.idProductos);
            ViewBag.idProveedor = new SelectList(db.Proveedor, "id", "nombreProveedor", detalleProveedor.idProveedor);
            return View(detalleProveedor);
        }

        // GET: DetalleProveedors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleProveedor detalleProveedor = db.DetalleProveedor.Find(id);
            if (detalleProveedor == null)
            {
                return HttpNotFound();
            }
            return View(detalleProveedor);
        }

        // POST: DetalleProveedors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DetalleProveedor detalleProveedor = db.DetalleProveedor.Find(id);
            db.DetalleProveedor.Remove(detalleProveedor);
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
