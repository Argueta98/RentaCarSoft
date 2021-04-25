using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Specification.Filters
{
   public  class AutoFilter : BaseFilter
    {
        public string Placa { get; set; }
        public string Marca { get; set; }
    }
}
