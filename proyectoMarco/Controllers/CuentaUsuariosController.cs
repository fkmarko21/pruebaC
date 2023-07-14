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
    public class CuentaUsuariosController : Controller
    {
        private BotilleriaEntities1 db = new BotilleriaEntities1();

        // GET: CuentaUsuarios
        public ActionResult Index()
        {
            return View(db.CuentaUsuario.ToList());
        }

        // GET: CuentaUsuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CuentaUsuario cuentaUsuario = db.CuentaUsuario.Find(id);
            if (cuentaUsuario == null)
            {
                return HttpNotFound();
            }
            return View(cuentaUsuario);
        }

        // GET: CuentaUsuarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CuentaUsuarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,correo,contraseña,contraseñaAntigua,direccion,habilitacionCuenta,numeroFijo,numeroTelefono")] CuentaUsuario cuentaUsuario)
        {
            if (ModelState.IsValid)
            {
                db.CuentaUsuario.Add(cuentaUsuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cuentaUsuario);
        }

        // GET: CuentaUsuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CuentaUsuario cuentaUsuario = db.CuentaUsuario.Find(id);
            if (cuentaUsuario == null)
            {
                return HttpNotFound();
            }
            return View(cuentaUsuario);
        }

        // POST: CuentaUsuarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,correo,contraseña,contraseñaAntigua,direccion,habilitacionCuenta,numeroFijo,numeroTelefono")] CuentaUsuario cuentaUsuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cuentaUsuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cuentaUsuario);
        }

        // GET: CuentaUsuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CuentaUsuario cuentaUsuario = db.CuentaUsuario.Find(id);
            if (cuentaUsuario == null)
            {
                return HttpNotFound();
            }
            return View(cuentaUsuario);
        }

        // POST: CuentaUsuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CuentaUsuario cuentaUsuario = db.CuentaUsuario.Find(id);
            db.CuentaUsuario.Remove(cuentaUsuario);
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
