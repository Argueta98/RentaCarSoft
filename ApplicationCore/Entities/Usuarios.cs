using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ApplicationCore.Enum;
namespace ApplicationCore.Entities
{
    public class Usuarios
    {
        public int Id { get; set; }

        public string DUI { get; set; }

        public string Nombres { get; set; }

        public string Apellidos { get; set; }
        public Genero Genero { get; set; }

        public string Direccion { get; set; }

        public string NombreCompleto()
        {
            return Nombres + ' ' + Apellidos;
        }
    }
}