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
    [Authorize(Roles = "Administrador,Gestor,BackOffice")]
    public class BackOfficeController : Controller
    {
        private GestorAduanasContext db = new GestorAduanasContext();

        // GET: BackOffice
        public ActionResult Index()
        {
            var backOffices = db.BackOffices.Include(b => b.Empresa);
            return View(backOffices.ToList());
        }

        // GET: BackOffice/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BackOffice backOffice = db.BackOffices.Find(id);
            if (backOffice == null)
            {
                return HttpNotFound();
            }
            return View(backOffice);
        }

        // GET: BackOffice/Create
        public ActionResult Create()
        {
            ViewBag.EmpresaId = new SelectList(db.Empresas, "EmpresaId", "Nombre");
            return View();
        }

        // POST: BackOffice/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdBackOffice,NombreBo,ApellidoBo,EmpresaId,Recorrido")] BackOffice backOffice)
        {
            if (ModelState.IsValid)
            {
                db.BackOffices.Add(backOffice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmpresaId = new SelectList(db.Empresas, "EmpresaId", "Nombre", backOffice.EmpresaId);
            return View(backOffice);
        }

        // GET: BackOffice/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BackOffice backOffice = db.BackOffices.Find(id);
            if (backOffice == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmpresaId = new SelectList(db.Empresas, "EmpresaId", "Nombre", backOffice.EmpresaId);
            return View(backOffice);
        }

        // POST: BackOffice/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdBackOffice,NombreBo,ApellidoBo,EmpresaId,Recorrido")] BackOffice backOffice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(backOffice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmpresaId = new SelectList(db.Empresas, "EmpresaId", "Nombre", backOffice.EmpresaId);
            return View(backOffice);
        }

        // GET: BackOffice/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BackOffice backOffice = db.BackOffices.Find(id);
            if (backOffice == null)
            {
                return HttpNotFound();
            }
            return View(backOffice);
        }

        // POST: BackOffice/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BackOffice backOffice = db.BackOffices.Find(id);
            db.BackOffices.Remove(backOffice);
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
