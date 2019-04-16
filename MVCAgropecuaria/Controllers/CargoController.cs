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
    public class CargoController : Controller
    {
        private AgropecuariaContext db = new AgropecuariaContext();
        private CargoBusinessLogic businessLogic;
        protected Response responseHttp;
        public CargoController() : base()
        {
            businessLogic = new CargoBusinessLogic();
            responseHttp = new Response();
        }
        // GET: Cargo
        public ActionResult Index(string searchString)
        {
            return View(businessLogic.GetAllHabilitados(searchString).Data);
        }

        // GET: Cargo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cargo cargo = db.Cargos.Find(id);
            if (cargo == null)
            {
                return HttpNotFound();
            }
            return View(cargo);
        }

        // GET: Cargo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cargo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descripcion,Habilitado,FechaRegistro,FechaModificacion,IdPerReg,IdPerMod")] Cargo cargo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var tmpAdicionarRespustaHttp = businessLogic.Create(cargo);
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

            return View(cargo);
        }

        // GET: Cargo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cargo cargo = db.Cargos.Find(id);
            if (cargo == null)
            {
                return HttpNotFound();
            }
            return View(cargo);
        }

        // POST: Cargo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descripcion,Habilitado,FechaRegistro,FechaModificacion,IdPerReg,IdPerMod")] Cargo cargo)
        {
            if (ModelState.IsValid)
            {
                var response = businessLogic.Edit(cargo);
                if (response.Error)
                {
                    ModelState.AddModelError("", response.Message);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            return View(cargo);
        }

        // GET: Cargo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cargo cargo = db.Cargos.Find(id);
            if (cargo == null)
            {
                return HttpNotFound();
            }
            return View(cargo);
        }

        // POST: Cargo/Delete/5
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
