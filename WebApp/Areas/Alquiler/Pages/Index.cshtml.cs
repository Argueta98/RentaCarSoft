using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Constants;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Specification;
using ApplicationCore.Specification.Filters;
using AspNetCoreHero.ToastNotification.Abstractions;
using Infraestructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Models;


namespace WebApp.Areas.Alquiler.Pages
{
    public class IndexModel : PageModel
    {
        private readonly MyRepository<ApplicationCore.Entities.Alquiler> _repository;
        private INotyfService _notyfService { get; }
        public IndexModel(MyRepository<ApplicationCore.Entities.Alquiler> repository, INotyfService notyfService)
        {
            _repository = repository;
            _notyfService = notyfService;
        }

        public List<ApplicationCore.Entities.Alquiler> Alquileres { get; set; }

        // public List<Alquiler> Alquiler { get; set; }
        public UIPaginationModel UIPagination { get; set; }

        public async Task OnGetAsync(string searchString, string typeFilter, int? currentPage, int? sizePage)
        {
            if (typeFilter == "")
                typeFilter = "Alquiler";

            var totalItems = await _repository.CountAsync(new AlquilerSpec(new AlquilerFilter { LoadChildren = true, IsPagingEnabled = true }));
            UIPagination = new UIPaginationModel(currentPage, searchString, sizePage, totalItems);

            Alquileres = await _repository.ListAsync(new AlquilerSpec(
                new AlquilerFilter
                {
                    IsPagingEnabled = true,
                    TypeFilter = typeFilter,
                    SearchString = searchString,
                    // = UIPagination.SearchString,
                    SizePage = UIPagination.GetSizePage,
                    Page = UIPagination.GetCurrentPage,
                    LoadChildren = true
                })
             );
        }
    }
}
