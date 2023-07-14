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
    public class DireccionsController : Controller
    {
        private BotilleriaEntities1 db = new BotilleriaEntities1();

        // GET: Direccions
        public ActionResult Index()
        {
            var direccion = db.Direccion.Include(d => d.Comunas).Include(d => d.CuentaUsuario);
            return View(direccion.ToList());
        }

        // GET: Direccions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Direccion direccion = db.Direccion.Find(id);
            if (direccion == null)
            {
                return HttpNotFound();
            }
            return View(direccion);
        }

        // GET: Direccions/Create
        public ActionResult Create()
        {
            ViewBag.idComunas = new SelectList(db.Comunas, "id", "nombre");
            ViewBag.idCuentaUsuario = new SelectList(db.CuentaUsuario, "id", "nombre");
            return View();
        }

        // POST: Direccions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,idComunas,idCuentaUsuario")] Direccion direccion)
        {
            if (ModelState.IsValid)
            {
                db.Direccion.Add(direccion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idComunas = new SelectList(db.Comunas, "id", "nombre", direccion.idComunas);
            ViewBag.idCuentaUsuario = new SelectList(db.CuentaUsuario, "id", "nombre", direccion.idCuentaUsuario);
            return View(direccion);
        }

        // GET: Direccions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Direccion direccion = db.Direccion.Find(id);
            if (direccion == null)
            {
                return HttpNotFound();
            }
            ViewBag.idComunas = new SelectList(db.Comunas, "id", "nombre", direccion.idComunas);
            ViewBag.idCuentaUsuario = new SelectList(db.CuentaUsuario, "id", "nombre", direccion.idCuentaUsuario);
            return View(direccion);
        }

        // POST: Direccions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,idComunas,idCuentaUsuario")] Direccion direccion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(direccion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idComunas = new SelectList(db.Comunas, "id", "nombre", direccion.idComunas);
            ViewBag.idCuentaUsuario = new SelectList(db.CuentaUsuario, "id", "nombre", direccion.idCuentaUsuario);
            return View(direccion);
        }

        // GET: Direccions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Direccion direccion = db.Direccion.Find(id);
            if (direccion == null)
            {
                return HttpNotFound();
            }
            return View(direccion);
        }

        // POST: Direccions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Direccion direccion = db.Direccion.Find(id);
            db.Direccion.Remove(direccion);
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
