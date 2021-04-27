using ApplicationCore.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class CalculadoraService : ICalculadoraService
    {
        public decimal CalcularPrecioAlquiler(DateTime FechaInicio, DateTime FechaFin, PrecioAlquiler precio)
        {
            //cALCULARlOSDIAS ENTRE FEHCHA INICIO Y FIN
            // 20 DIAS
            // PRECIO = TARIFA * DIAS
            //RETURN DEL PRECIO;
            return 0.0m;
        }
    }
}
