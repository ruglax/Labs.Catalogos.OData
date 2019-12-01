using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Labs.Catalogos.OData.Models
{
    public class c_CodigoPostal
    {
        [Key]
        public string Clave { get; set; }

        public string Estado { get; set; }

        public string Municipio { get; set; }

        public string Localidad { get; set; }

        public short EstimuloFranjaFronteriza { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime? FechaFin { get; set; }


    }
}
