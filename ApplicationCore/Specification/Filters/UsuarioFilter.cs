using ApplicationCore.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Specification.Filters
{
    public class UsuarioFilter : BaseFilter
    {
        public Genero Genero { get; set; }
        public string Apellidos { get; set; }
        public string Codigo { get; set; }

    }
}
