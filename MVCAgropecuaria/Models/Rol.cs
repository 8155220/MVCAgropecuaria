using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAgropecuaria.Models
{
    public class Rol
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }

        public Boolean Habilitado { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaModificacion { get; set; }

        public int IdPersonaRegistro { get; set; }
        public int IdPersonaModifico { get; set; }
    }
}