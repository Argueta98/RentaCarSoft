using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Specification.Filters
{
   public  class AlquilerFilter : BaseFilter
    {
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal{ get; set; }
        public string TypeFilter { get; set; }
        public string SearchString { get; set; }
    }
}
