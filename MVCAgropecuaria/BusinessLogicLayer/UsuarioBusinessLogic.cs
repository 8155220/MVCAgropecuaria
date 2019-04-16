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
    public class UsuarioBusinessLogic : BaseBusinessLogic
    {
        public Response Create(Usuarios dataUsuario)
        {
            using (var db = new AgropecuariaContext())
            {
                var usuarioYaRegistrado = db.Usuarios.FirstOrDefault(p => p.UserName == dataUsuario.UserName) !=null ? true : false ;

                if (!usuarioYaRegistrado)
                {
                    dataUsuario.Habilitado = true;
                    dataUsuario.FechaRegistro = DateTime.Now;
                    dataUsuario.FechaModificacion = DateTime.Now;
                    dataUsuario.IdPerMod = SessionHelper.CURRENT_PERSON_ID;
                    dataUsuario.IdPerReg = SessionHelper.CURRENT_PERSON_ID;
                    db.Usuarios.Add(dataUsuario);
                    db.SaveChanges();
                    responseModel.Error = false;
                }else 
                {
                    responseModel.Error = true;
                    responseModel.Message = "Ya existe registro de usuario con el mismo Nombre de Usuarios";
                }

            }
            return responseModel;
        }
        public Response Edit(Usuarios dataUsuario)
        {
            using (var db = new AgropecuariaContext())
            {
                var usuario = db.Usuarios.Find(dataUsuario.Id);

                if (usuario!=null)
                {
                    usuario.Habilitado = dataUsuario.Habilitado;
                    usuario.Password = dataUsuario.Password;
                    usuario.IdRol = dataUsuario.IdRol;
                    usuario.FechaModificacion = DateTime.Now;
                    usuario.IdPerMod = SessionHelper.CURRENT_PERSON_ID;
                    usuario.IdPerReg = SessionHelper.CURRENT_PERSON_ID;
                    db.SaveChanges();
                    responseModel.Error = false;
                }
                else
                {
                    responseModel.Error = true;
                    responseModel.Message = "Ocurrio un error al Guardar";
                }

            }
            return responseModel;

        }

        public Response GetAllHabilitados(string userName)
        {
            responseModel.Data = new List<Usuarios>();
            using (var db = new AgropecuariaContext())
            {
                var listaUsuarios = db.Usuarios
                    .Include("Roles")
                    .Where(usuario => usuario.Habilitado == true )
                    .Select(MapeoBdToEntity)
                    ;
                if (!String.IsNullOrEmpty(userName))
                {
                    listaUsuarios = listaUsuarios.Where(usuario => usuario.UserName.ToLower().Contains(userName.ToLower()));
                }
               if (listaUsuarios.Any())
                {
                        responseModel.Data = listaUsuarios.ToList();
                }
            }
            return responseModel;
        }

        public Response GetPersonasDisponibles()
        {
            responseModel.Data = new List<Persona>();
            using (var db = new AgropecuariaContext()) {
                var usuariosId = db.Usuarios.Select(u => u.IdPersona);
                var personas = db.Personas.Where(p => !usuariosId.Contains(p.Id)).ToList();
                responseModel.Data = personas;
                responseModel.Error = false;
            }

            return responseModel;
        }
        public Response Delete(int id)
        {
            responseModel.Error = true;
            using (var db = new AgropecuariaContext())
            {
                Usuarios usuario = db.Usuarios.Find(id);
                usuario.Habilitado = false;
                db.SaveChanges();
                responseModel.Error = false;
            }
            return responseModel;
        }

        public static Usuarios MapeoBdToEntity(Usuarios UsuarioBd)
        {
            return new Usuarios
            {
                Id = UsuarioBd.Id,
                UserName = UsuarioBd.UserName?.Trim(),
                Password = UsuarioBd.Password,
                Rol = UsuarioBd.Rol
            };
        }
    }


}