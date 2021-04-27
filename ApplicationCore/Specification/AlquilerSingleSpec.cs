using ApplicationCore.Entities;
using ApplicationCore.Specification.Filters;
using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Specification
{
   public  class AlquilerSingleSpec : Specification<Alquiler>,ISingleResultSpecification
    {
        public AlquilerSingleSpec(int id)
        {
            Query.Where(x => x.Id == id);

          
            
                Query.Include(x => x.Cliente);

                Query.Include(x => x.Auto);
            

        }
    }
}
