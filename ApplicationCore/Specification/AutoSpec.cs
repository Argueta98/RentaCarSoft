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
   public  class AutoSpec : Specification<Autos>
    {
        public AutoSpec(AutoFilter filter)
        {
            Query.OrderBy(x => x.Marca).ThenByDescending(x => x.Id);

            if (filter.IsPagingEnabled)
                Query.Skip(PaginationHelper.CalculateSkip(filter))
                     .Take(PaginationHelper.CalculateTake(filter));

            if (!string.IsNullOrEmpty(filter.Marca))
                Query.Search(x => x.Marca, "%" + filter.Marca + "%");
        }
    }
}
