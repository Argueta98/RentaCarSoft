using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Infraestructure.Data;

namespace WebApp.Areas.Auto.Pages
{
    public class EditModel : PageModel
    {
        private readonly MyRepository<ApplicationCore.Entities.Auto> _repository;
        private INotyfService _notyfService { get; }
        public EditModel(MyRepository<ApplicationCore.Entities.Auto> repository, INotyfService notyfService)
        {
            _repository = repository;
            _notyfService = notyfService;
        }
        [BindProperty]
        public ApplicationCore.Entities.Auto Autos { get; set; }



        public async Task<IActionResult> OnGetAsync(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            Autos = await _repository.GetByIdAsync(id);

            if (Autos == null)
            {
                return NotFound();
            }

            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int id)
        {
            try
            {
                var autoToUpdate = await _repository.GetByIdAsync(id);
                if (autoToUpdate == null)
                {
                    return NotFound();
                }
                if (await TryUpdateModelAsync(autoToUpdate,
                    "Autos",
                    s => s.Placa,
                    s => s.Marca,
                    s => s.Modelo,
                    s => s.TipoAuto,
                    s => s.Color,
                    s => s.Combustible,
                    s => s.Estado,
                    s => s.Fotografia
                    ))
                {
                    await _repository.SaveChangesAsync();
                    _notyfService.Success("Se ha guardado con exito");
                    return base.RedirectToPage("./Index");
                }
            }
            catch (Exception ex)
            {

            }
            return Page();
        }
    }
}
