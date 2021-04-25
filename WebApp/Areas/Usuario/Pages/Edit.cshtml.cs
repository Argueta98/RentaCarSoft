using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using AspNetCoreHero.ToastNotification.Abstractions;
using Infraestructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Areas.Usuario.Pages
{
    public class EditModel : PageModel
    {
        private readonly MyRepository<Usuarios> _repository;
        private INotyfService _notyfService { get; }
        public EditModel(MyRepository<Usuarios> repository, INotyfService notyfService)
        {
            _repository = repository;
            _notyfService = notyfService;
        }
        [BindProperty]
        public Usuarios Usuario { get; set; }



        public async Task<IActionResult> OnGetAsync(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            Usuario = await _repository.GetByIdAsync(id);

            if (Usuario == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            try
            {
                var usuarioToUpdate = await _repository.GetByIdAsync(id);
                if (usuarioToUpdate == null)
                {
                    return NotFound();
                }
                if (await TryUpdateModelAsync<Usuarios>(usuarioToUpdate,
                    "Usuario",
                    s => s.DUI,
                    s => s.Nombres,
                    s => s.Apellidos,
                    s => s.Genero,
                    s => s.Direccion))
                {
                    await _repository.SaveChangesAsync();
                    _notyfService.Success("Se ha guardado con exito");
                    return RedirectToPage("./Index");
                }
            }
            catch (Exception ex)
            {

            }
            return Page();
        }

    }
}