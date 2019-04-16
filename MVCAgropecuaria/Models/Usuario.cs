using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCAgropecuaria.Models
{
    public class Usuarios
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public Boolean Habilitado { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaModificacion { get; set; }

        public int IdPersona { get; set; }
        public int IdRol { get; set; }

        [ForeignKey("IdPersona")]
        public virtual Persona Persona{get;set;}
        [ForeignKey("IdRol")]
        public virtual Roles Rol { get; set; }

        public int? IdPerReg { get; set; }
        public int? IdPerMod { get; set; }

    }
}