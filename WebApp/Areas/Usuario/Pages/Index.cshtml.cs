using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Constants;
using ApplicationCore.Entities;
using ApplicationCore.Specification;
using ApplicationCore.Specification.Filters;
using AspNetCoreHero.ToastNotification.Abstractions;
using Infraestructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Areas.Usuario.Pages
{
    public class IndexModel : PageModel
    {
        private readonly MyRepository<Usuarios> _repository;
        private INotyfService _notyfService { get; }

        public IndexModel(MyRepository<Usuarios> repository, INotyfService notyfService)
        {
            _repository = repository;
            _notyfService = notyfService;
        }

        public List<Usuarios> Usuario { get; set; }
        public int[] DefaultPagesSizes => PaginationHelper.DefaultPagesSizes;
        public Pager Pager { get; set; }
        public string SearchString { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public async Task OnGetAsync(string searchString, int? currentPage, int? pageSize)
        {
            PageSize = pageSize.HasValue ? pageSize.Value : PaginationConstants.DefaultPageSize;

            if (!string.IsNullOrEmpty(searchString))
            {
                SearchString = searchString;
                TotalItems = await _repository.CountAsync(new UsuariosSpec(new UsuarioFilter { Apellidos = searchString, IsPagingEnabled = false }));
            }
            else
            {
                TotalItems = await _repository.CountAsync(new UsuariosSpec(new UsuarioFilter { IsPagingEnabled = false }));
            }

            Pager = new Pager(TotalItems, currentPage.HasValue ? currentPage.Value : PaginationConstants.DefaultPage, PageSize);

            var filter = new UsuarioFilter();
            filter.IsPagingEnabled = true;
            filter.Apellidos = searchString;
            //filter.Nombres = searchString;
            filter.SizePage = Pager.PageSize;
            filter.Page = Pager.CurrentPage;

            Usuario = await _repository.ListAsync(new UsuariosSpec(filter));
        }
    }
}
