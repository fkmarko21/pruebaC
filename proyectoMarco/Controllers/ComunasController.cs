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
    public class ComunasController : Controller
    {
        private BotilleriaEntities1 db = new BotilleriaEntities1();

        // GET: Comunas
        public ActionResult Index()
        {
            var comunas = db.Comunas.Include(c => c.Ciudad);
            return View(comunas.ToList());
        }

        // GET: Comunas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comunas comunas = db.Comunas.Find(id);
            if (comunas == null)
            {
                return HttpNotFound();
            }
            return View(comunas);
        }

        // GET: Comunas/Create
        public ActionResult Create()
        {
            ViewBag.idCiudad = new SelectList(db.Ciudad, "id", "nombre");
            return View();
        }

        // POST: Comunas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,idCiudad")] Comunas comunas)
        {
            if (ModelState.IsValid)
            {
                db.Comunas.Add(comunas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCiudad = new SelectList(db.Ciudad, "id", "nombre", comunas.idCiudad);
            return View(comunas);
        }

        // GET: Comunas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comunas comunas = db.Comunas.Find(id);
            if (comunas == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCiudad = new SelectList(db.Ciudad, "id", "nombre", comunas.idCiudad);
            return View(comunas);
        }

        // POST: Comunas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,idCiudad")] Comunas comunas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comunas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCiudad = new SelectList(db.Ciudad, "id", "nombre", comunas.idCiudad);
            return View(comunas);
        }

        // GET: Comunas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comunas comunas = db.Comunas.Find(id);
            if (comunas == null)
            {
                return HttpNotFound();
            }
            return View(comunas);
        }

        // POST: Comunas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comunas comunas = db.Comunas.Find(id);
            db.Comunas.Remove(comunas);
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
