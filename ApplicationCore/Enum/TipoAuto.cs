using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Enum
{
    public enum TipoAuto : int
    {

        //PickUp = 30,
        //Sedan = 40,
        //Camioneta = 50,
        //Deportivo = 6

        [Display(Name = "Pick Up")]
        PickUp = 30,
        [Display(Name = "Sedan")]
        Sedan= 40,
        [Display(Name = "Camioneta")]
        Camioneta= 50,
        [Display(Name = "Deportivo")]
        Deportivo=60
    }

}
