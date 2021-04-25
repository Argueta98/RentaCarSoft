
using ApplicationCore.Entities;
using ApplicationCore.Specification.Filters;
using Ardalis.Specification;
namespace ApplicationCore.Specification
{
    public class ClientesSpec : Specification<Clientes>
    {
        public ClientesSpec(ClienteFilter filter)
        {
            Query.OrderBy(x => x.Apellidos).ThenByDescending(x => x.Id);
            //Query.OrderBy(y => y.Nombres).ThenByDescending(y => y.Id);

            if (filter.IsPagingEnabled)
                Query.Skip(PaginationHelper.CalculateSkip(filter))
                     .Take(PaginationHelper.CalculateTake(filter));

            if (!string.IsNullOrEmpty(filter.Apellidos))
                Query.Search(x => x.Apellidos, "%" + filter.Apellidos + "%");

            //if (!string.IsNullOrEmpty(filter.Nombres))
             //   Query.Search(y => y.Nombres, "%" + filter.Nombres + "%");
        }
    }
}
