using MVCAgropecuaria.DAL;
using MVCAgropecuaria.Helpers;
using MVCAgropecuaria.Models;
using MVCAgropecuaria.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAgropecuaria.BusinessLogicLayer
{
    public class CargoBusinessLogic : BaseBusinessLogic
    {
        public Response Create(Cargo entity)
        {
            using (var db = new AgropecuariaContext())
            {

                var entityYaRegistrado = db.Cargos.FirstOrDefault(p => p.Descripcion == entity.Descripcion) != null ? true : false;
                if (!entityYaRegistrado)
                {
                    entity.Habilitado = true;
                    entity.FechaRegistro = DateTime.Now;
                    entity.FechaModificacion = DateTime.Now;
                    entity.PersonaModificoID = SessionHelper.CURRENT_PERSON_ID;
                    entity.PersonaRegistroID = SessionHelper.CURRENT_PERSON_ID;
                    db.Cargos.Add(entity);
                    db.SaveChanges();
                    responseModel.Error = false;
                }
                else
                {
                    responseModel.Error = true;
                    responseModel.Message = "Ya existe un Cargo con la misma Descripcion";
                }

            }
            return responseModel;
        }
        public Response Edit(Cargo newEntity)
        {
            using (var db = new AgropecuariaContext())
            {
                var entity = db.Rols.Find(newEntity.ID);
                var entityYaRegistrado = db.Rols.FirstOrDefault(p => p.Descripcion == entity.Descripcion) != null ? true : false;

                if (entity != null)
                {
                    if (entityYaRegistrado)
                    {
                        responseModel.Error = true;
                        responseModel.Message = "Ya existe un Cargo con la misma Descripcion";
                    }
                    else
                    {
                        entity.Habilitado = newEntity.Habilitado;
                        entity.FechaModificacion = DateTime.Now;
                        entity.PersonaModificoID = SessionHelper.CURRENT_PERSON_ID;
                        entity.PersonaRegistroID = SessionHelper.CURRENT_PERSON_ID;
                        db.SaveChanges();
                        responseModel.Error = false;
                    }
                }
                else
                {
                    responseModel.Error = true;
                    responseModel.Message = "Ocurrio un error al Guardar";
                }

            }
            return responseModel;

        }

        public Response GetAllHabilitados(string queryString)
        {
            responseModel.Data = new List<Cargo>();
            using (var db = new AgropecuariaContext())
            {
                var lista = db.Cargos
                    .Where(e => e.Habilitado == true)
                    .Select(MapeoBdToEntity);
                if (!String.IsNullOrEmpty(queryString))
                {
                    lista = lista.Where(e => e.Descripcion.ToLower().Contains(queryString.ToLower()));
                }
                if (lista.Any())
                {
                    responseModel.Data = lista.ToList();
                }
            }
            return responseModel;
        }


        public static Cargo MapeoBdToEntity(Cargo RolBd)
        {
            return new Cargo
            {
                ID = RolBd.ID,
                Descripcion = RolBd.Descripcion?.Trim(),
            };
        }
    }
}