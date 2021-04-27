using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Enum;
using System;

namespace ApplicationCore.Entities
{
   public class Auto
    {
        public int Id { get; set; }
        public string Placa { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public TipoAuto TipoAuto { get; set; } 
        public string Fotografia { get; set; }
        public string Color { get; set; }
        public string Combustible { get; set; }
        public Estado Estado { get; set; }
        public List<Alquiler> Alquiler { get; set; }

        public string Descripcion()
        {
            return Marca + ' ' + Modelo;
        }
        public string NombreFotografia()
        {
            return Descripcion() + '-' + Guid.NewGuid().ToString();
        }

    }
}
