using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GestorAduana_v1.Context;

namespace GestorAduana_v1.Controllers
{
    [Authorize(Roles = "Administrador,Gestor,BackOffice,Camionero")]
    public class CamioneroController : Controller
    {
        private GestorAduanasContext db = new GestorAduanasContext();

        // GET: Camionero
        public ActionResult Index()
        {
            var camioneros = db.Camioneros.Include(c => c.Empresa);
            return View(camioneros.ToList());
        }

        // GET: Camionero/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Camionero camionero = db.Camioneros.Find(id);
            if (camionero == null)
            {
                return HttpNotFound();
            }
            return View(camionero);
        }

        // GET: Camionero/Create
        public ActionResult Create()
        {
            ViewBag.EmpresaId = new SelectList(db.Empresas, "EmpresaId", "Nombre");
            return View();
        }

        // POST: Camionero/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCamionero,Nombre,Apellido,Dui,Edad,Placa,QueTransporta,CantidadTransportada,EmpresaId")] Camionero camionero)
        {
            if (ModelState.IsValid)
            {
                db.Camioneros.Add(camionero);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmpresaId = new SelectList(db.Empresas, "EmpresaId", "Nombre", camionero.EmpresaId);
            return View(camionero);
        }

        // GET: Camionero/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Camionero camionero = db.Camioneros.Find(id);
            if (camionero == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmpresaId = new SelectList(db.Empresas, "EmpresaId", "Nombre", camionero.EmpresaId);
            return View(camionero);
        }

        // POST: Camionero/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCamionero,Nombre,Apellido,Dui,Edad,Placa,QueTransporta,CantidadTransportada,EmpresaId")] Camionero camionero)
        {
            if (ModelState.IsValid)
            {
                db.Entry(camionero).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmpresaId = new SelectList(db.Empresas, "EmpresaId", "Nombre", camionero.EmpresaId);
            return View(camionero);
        }

        // GET: Camionero/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Camionero camionero = db.Camioneros.Find(id);
            if (camionero == null)
            {
                return HttpNotFound();
            }
            return View(camionero);
        }

        // POST: Camionero/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Camionero camionero = db.Camioneros.Find(id);
            db.Camioneros.Remove(camionero);
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
