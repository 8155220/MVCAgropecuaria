using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCAgropecuaria.BusinessLogicLayer;
using MVCAgropecuaria.DAL;
using MVCAgropecuaria.Models;
using MVCAgropecuaria.Responses;

namespace MVCAgropecuaria.Controllers
{
    public class RolController : Controller
    {
        private AgropecuariaContext db = new AgropecuariaContext();
        private RolBusinessLogic businessLogic;
        protected Response responseHttp;
        // GET: Roles
        public RolController() : base()
        {
            businessLogic = new RolBusinessLogic();
            responseHttp = new Response();
        }
        public ActionResult Index(string searchString)
        {
            return View(businessLogic.GetAllHabilitados(searchString).Data);
        }

        // GET: Roles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Roles rol = db.Rols.Find(id);
            if (rol == null)
            {
                return HttpNotFound();
            }
            return View(rol);
        }

        // GET: Roles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Roles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Descripcion")] Roles rol)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var tmpAdicionarRespustaHttp = businessLogic.Create(rol);
                    if (tmpAdicionarRespustaHttp.Error)
                    {
                        ModelState.AddModelError("", tmpAdicionarRespustaHttp.Message);
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }
                }

            }
            catch (DataException)
            {
                {
                    ModelState.AddModelError("", "Ocurrio un error, intente mas tarde");
                }
            }

            return View(rol);
        }

        // GET: Roles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Roles rol = db.Rols.Find(id);
            if (rol == null)
            {
                return HttpNotFound();
            }
            return View(rol);
        }

        // POST: Roles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descripcion,Habilitado")] Roles rol)
        {
            if (ModelState.IsValid)
            {
                var tmpAdicionarRespustaHttp = businessLogic.Edit(rol);
                if (tmpAdicionarRespustaHttp.Error)
                {
                    ModelState.AddModelError("", tmpAdicionarRespustaHttp.Message);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            return View(rol);
        }

        // GET: Roles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Roles rol = db.Rols.Find(id);
            if (rol == null)
            {
                return HttpNotFound();
            }
            return View(rol);
        }

        // POST: Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            businessLogic.Delete(id);
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
