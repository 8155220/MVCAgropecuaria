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
        public Response Create(Usuario dataUsuario)
        {
            using (var db = new AgropecuariaContext())
            {
                var usuarioYaRegistrado = db.Usuarios.FirstOrDefault(p => p.UserName == dataUsuario.UserName) !=null ? true : false ;

                if (!usuarioYaRegistrado)
                {
                    dataUsuario.Habilitado = true;
                    dataUsuario.FechaRegistro = DateTime.Now;
                    dataUsuario.FechaModificacion = DateTime.Now;
                    dataUsuario.PersonaModificoID = SessionHelper.CURRENT_PERSON_ID;
                    dataUsuario.PersonaRegistroID = SessionHelper.CURRENT_PERSON_ID;
                    db.Usuarios.Add(dataUsuario);
                    db.SaveChanges();
                    responseModel.Error = false;
                }else 
                {
                    responseModel.Error = true;
                    responseModel.Message = "Ya existe registro de usuario con el mismo Nombre de Usuario";
                }

            }
            return responseModel;
        }
        public Response Edit(Usuario dataUsuario)
        {
            using (var db = new AgropecuariaContext())
            {
                var usuario = db.Usuarios.Find(dataUsuario.ID);

                if (usuario!=null)
                {
                    usuario.Habilitado = dataUsuario.Habilitado;
                    usuario.Password = dataUsuario.Password;
                    usuario.RolID = dataUsuario.RolID;
                    usuario.FechaModificacion = DateTime.Now;
                    usuario.PersonaModificoID = SessionHelper.CURRENT_PERSON_ID;
                    usuario.PersonaRegistroID = SessionHelper.CURRENT_PERSON_ID;
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
            responseModel.Data = new List<Usuario>();
            using (var db = new AgropecuariaContext())
            {
                var listaUsuarios = db.Usuarios
                    .Include("Rol")
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
                var usuariosId = db.Usuarios.Select(u => u.PersonaID);
                var personas = db.Personas.Where(p => !usuariosId.Contains(p.ID)).ToList();
                responseModel.Data = personas;
                responseModel.Error = false;
            }

            return responseModel;
        }

        public static Usuario MapeoBdToEntity(Usuario UsuarioBd)
        {
            return new Usuario
            {
                ID = UsuarioBd.ID,
                UserName = UsuarioBd.UserName?.Trim(),
                Password = UsuarioBd.Password,
                Rol = UsuarioBd.Rol
            };
        }
    }


}