using ApplicationCore.Entities;
using ApplicationCore.Specification;
using ApplicationCore.Specification.Filters;
using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class UsuariosSpec : Specification<Usuarios>
{
    public UsuariosSpec(UsuarioFilter filter)
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

