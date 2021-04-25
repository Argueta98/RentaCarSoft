
using ApplicationCore.Enum;
namespace ApplicationCore.Entities
{
    public class Clientes
    {
        public int Id { get; set; }

        public string DUI { get; set; }

        public string Nombres { get; set; }

        public string Apellidos { get; set; }
        public Genero Genero { get; set; }

        public string Telefono { get; set; }
        public int NumLicencia { get; set; }

        public string Direccion { get; set; }

        public string NombreCompleto()
        {
            return Nombres + ' ' + Apellidos;
        }
    }
}

