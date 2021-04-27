
using ApplicationCore.Enum;
using System.Collections.Generic;

namespace ApplicationCore.Entities
{
    public class Cliente
    {
        public int Id { get; set; }

        public string DUI { get; set; }

        public string Nombres { get; set; }

        public string Apellidos { get; set; }
        public Genero Genero { get; set; }

        public string Telefono { get; set; }
        public int NumLicencia { get; set; }

        public string Direccion { get; set; }

        public  List<Alquiler> Alquiler { get; set; }

        public string NombreCompleto()
        {
            return Nombres + ' ' + Apellidos;
        }
    }
}

