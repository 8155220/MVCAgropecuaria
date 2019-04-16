using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCAgropecuaria.Models
{
    public class Roles
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public Boolean Habilitado { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaModificacion { get; set; }

        public int? IdPerReg { get; set; }
        public int? IdPerMod { get; set; }

        [ForeignKey("IdPerReg")]
        public virtual Persona PersonaRegistro { get; set; }
        [ForeignKey("IdPerMod")]
        public virtual Persona PersonaModifico { get; set; }
    }
}