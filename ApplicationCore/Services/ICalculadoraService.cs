using ApplicationCore.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public interface ICalculadoraService
    {
        decimal CalcularPrecioAlquiler(DateTime FechaInicio, DateTime FechaFin, PrecioAlquiler precio);
    }
}
