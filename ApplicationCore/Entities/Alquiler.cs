using ApplicationCore.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
   public  class Alquiler
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public Cliente Cliente { get; set; }
        public int IdAuto { get; set; }
        public Auto Auto { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha Inicio")]
        public DateTime FechaInicio { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha Final")]
        public DateTime FechaFinal { get; set; }
        public PrecioAlquiler PrecioAlquiler { get; set; }
        //

        public int  CantidadTotal { get; set; }

    }
}
