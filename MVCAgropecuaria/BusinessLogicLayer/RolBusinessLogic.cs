using MVCAgropecuaria.DAL;
using MVCAgropecuaria.Helpers;
using MVCAgropecuaria.Models;
using MVCAgropecuaria.Responses;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCAgropecuaria.BusinessLogicLayer
{
    public class RolBusinessLogic : BaseBusinessLogic
    {
        
        public Response Create(Roles entity)
        {
            using (var db = new AgropecuariaContext())
            {
           
                var entityYaRegistrado = db.Rols.FirstOrDefault(p => p.Descripcion == entity.Descripcion) != null ? true : false;
           

                if (!entityYaRegistrado)
                {
                    entity.Habilitado = true;
                    entity.FechaRegistro = DateTime.Now;
                    entity.FechaModificacion = DateTime.Now;
                    entity.IdPerMod = SessionHelper.CURRENT_PERSON_ID;
                    entity.IdPerReg = SessionHelper.CURRENT_PERSON_ID;
                    db.Rols.Add(entity);
                    db.SaveChanges();
                    responseModel.Error = false;
                }
                else
                {
                    responseModel.Error = true;
                    responseModel.Message = "Ya existe un Roles con la misma Descripcion";
                }

            }
            return responseModel;
        }
        public Response Edit(Roles newEntity)
        {
            using (var db = new AgropecuariaContext())
            {
                var entity = db.Rols.Find(newEntity.Id);
                var entityYaRegistrado = db.Rols.FirstOrDefault(p => p.Descripcion == newEntity.Descripcion) != null ? true : false;
               
                if (entity != null)
                {
                    if (entityYaRegistrado && entity.Descripcion != newEntity.Descripcion)
                    {
                        responseModel.Error = true;
                        responseModel.Message = "Ya existe un Roles con la misma Descripcion";
                    }
                    else
                    {
                        entity.Descripcion = newEntity.Descripcion;
                        entity.Habilitado = newEntity.Habilitado;
                        entity.FechaModificacion = DateTime.Now;
                        entity.IdPerMod = SessionHelper.CURRENT_PERSON_ID;
                        entity.IdPerReg = SessionHelper.CURRENT_PERSON_ID;
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
        public Response Delete(int id)
        {
            responseModel.Error = true;
            using (var db = new AgropecuariaContext())
            {
                Roles rol = db.Rols.Find(id);
                rol.Habilitado = false;
                db.SaveChanges();
                responseModel.Error = false;
            }
            return responseModel;
        }
        public Response GetAllHabilitados(string queryString)
        {
            responseModel.Data = new List<Roles>();
            using (var db = new AgropecuariaContext())
            {
                var lista = db.Rols
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


        public static Roles MapeoBdToEntity(Roles RolBd)
        {
            return new Roles
            {
                Id = RolBd.Id,
                Descripcion = RolBd.Descripcion?.Trim(),
            };
        }
    }
}