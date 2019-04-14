using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCAgropecuaria.Models
{
    public class Usuario
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public Boolean Habilitado { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaModificacion { get; set; }

        public int PersonaID { get; set; }
        public int RolID { get; set; }

        [ForeignKey("PersonaID")]
        public virtual Persona Persona{get;set;}
        [ForeignKey("RolID")]
        public virtual Rol Rol { get; set; }

        public int? PersonaRegistroID { get; set; }
        public int? PersonaModificoID { get; set; }

    }
}