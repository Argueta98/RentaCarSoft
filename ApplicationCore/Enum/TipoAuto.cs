using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Enum
{
   public  enum TipoAuto
    {
        [Display(Name = "Pick Up")]
        PickUp,
        [Display(Name = "Sedan")]
        Sedan,
        [Display(Name = "Camioneta")]
        Camioneta,
        [Display(Name = "Deportivo")]
        Deportivo
    }
}
