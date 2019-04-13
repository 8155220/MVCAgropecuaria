using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCAgropecuaria.Models
{
    public class Persona
    {
        public int ID { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Sexo { get; set; }
        public string CI { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaRegistro { get; set; }
        public Boolean Habilitado { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string Domicilio { get; set; }
        public string Telefonos { get; set; }
        public string PersonaReferencia { get; set; }
        public int IdParentesco { get; set; }
        public string TelefonoReferencia { get; set; }

        //foreign key
        public int PersonaRegistroID { get; set; }
        public int PersonaModificoID { get; set; }
        //Navigation Property
        public virtual Cargo Cargo { get; set; }
        [ForeignKey("PersonaRegistroID")]
        public virtual Persona PersonaRegistro { get; set; }
        //[ForeignKey("PersonaModificoID")]
        public virtual Persona PersonaModifico { get; set; }

    }
}