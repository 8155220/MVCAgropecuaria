using System;
using System.Collections;
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
    public class UsuarioController : Controller
    {
        private AgropecuariaContext db = new AgropecuariaContext();
        private UsuarioBusinessLogic businessLogic;
        protected Response responseHttp ;
        // GET: Usuarios
        public UsuarioController() : base()
        {
            businessLogic = new UsuarioBusinessLogic();
            responseHttp = new Response();
        }
        public ActionResult Index(string searchString)
        {
            return View(businessLogic.GetAllHabilitados(searchString).Data);
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuarios usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            var listaUsuarios = (IList) businessLogic.GetPersonasDisponibles().Data;
            ViewBag.Personas = new SelectList(listaUsuarios, "Id", "Nombres");
            ViewBag.Rols = new SelectList(db.Rols, "Id", "Descripcion");   
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserName,Password,IdPersona,IdRol")] Usuarios usuario)
        {
            var listaUsuarios = (IList)businessLogic.GetPersonasDisponibles().Data;
            ViewBag.Personas = new SelectList(listaUsuarios, "Id", "Nombres");
            ViewBag.Rols = new SelectList(db.Rols, "Id", "Descripcion");
            try {
                if (ModelState.IsValid)
                {
                    var tmpAdicionarRespustaHttp = businessLogic.Create(usuario);
                    if (tmpAdicionarRespustaHttp.Error)
                    {
                        ModelState.AddModelError("", tmpAdicionarRespustaHttp.Message);
                    }else
                    {
                        return RedirectToAction("Index");
                    }
                }
                    
            }
            catch (DataException) {
                {
                    ModelState.AddModelError("", "Ocurrio un error, intente mas tarde");
                }
            }
            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            var listaUsuarios = (IList)businessLogic.GetPersonasDisponibles().Data;
            ViewBag.Personas = new SelectList(listaUsuarios, "Id", "Nombres");
            ViewBag.Rols = new SelectList(db.Rols, "Id", "Descripcion");

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuarios usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserName,Password,Habilitado,IdPersona,IdRol")] Usuarios usuario)
        {
            ViewBag.Rols = new SelectList(db.Rols, "Id", "Descripcion");
            if (ModelState.IsValid)
            {
                var tmpAdicionarRespustaHttp = businessLogic.Edit(usuario);
                if (tmpAdicionarRespustaHttp.Error)
                {
                    ModelState.AddModelError("", tmpAdicionarRespustaHttp.Message);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuarios usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Delete/5
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
