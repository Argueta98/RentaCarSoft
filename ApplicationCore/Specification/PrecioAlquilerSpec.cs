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
    public class PrecioAlquilerSpec : Specification<PrecioAlquiler>
    {
        public PrecioAlquilerSpec(PrecioAlquilerFilter filter)
        {
            Query.OrderBy(x => x.Precio).ThenByDescending(x => x.Id);

            if (filter.LoadChildren)
                Query.Include(x => x.Auto);

            if (filter.IsPagingEnabled)
                Query.Skip(PaginationHelper.CalculateSkip(filter))
                     .Take(PaginationHelper.CalculateTake(filter));

        }
    }
}
