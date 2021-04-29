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
        public decimal CalcularPrecioAlquiler(DateTime FechaInicio, DateTime FechaFin, TipoAuto precio)
        {
            // TimeSpan Total = FechaInicio - FechaFin;
            // var dias = Total.Days;
           

            int tiempoTotal = Convert.ToInt32((FechaInicio - FechaFin).TotalDays);
            //double totalDias = tiempoTotal.TotalDays;


            int total = tiempoTotal * Convert.ToInt32(precio.ToString());

            return total;


            //cALCULARlOSDIAS ENTRE FEHCHA INICIO Y FIN
            // 20 DIAS
            // PRECIO = TARIFA * DIAS
            //RETURN DEL PRECIO;
        }
    }
}
