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
   public  class AlquilerSpec : Specification<Alquiler>
    {
        public AlquilerSpec(AlquilerFilter filter)
        {
            Query.OrderBy(x => x.FechaInicio).ThenByDescending(x => x.Id);

            if (filter.LoadChildren)
            {
                Query.Include(x => x.Cliente);

                Query.Include(x => x.Auto);
            }
              

            if (filter.IsPagingEnabled)
                Query.Skip(PaginationHelper.CalculateSkip(filter))
                     .Take(PaginationHelper.CalculateTake(filter));

            if(filter.TypeFilter == "Auto")
            {
                if (!string.IsNullOrEmpty(filter.SearchString))
                    Query.Search(x => x.Auto.Descripcion(), "%" + filter.SearchString + "%");
            } else if(filter.TypeFilter == "Cliente")
            {
                if (!string.IsNullOrEmpty(filter.SearchString))
                    Query.Search(x => x.Cliente.NombreCompleto(), "%" + filter.SearchString + "%");
            }

        }
    }
}
