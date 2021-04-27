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

namespace WebApp.Areas.Cliente.Pages
{
    public class EditModel : PageModel
    {
        private readonly MyRepository<ApplicationCore.Entities.Cliente> _repository;
        private INotyfService _notyfService { get; }
        public EditModel(MyRepository<ApplicationCore.Entities.Cliente> repository, INotyfService notyfService)
        {
            _repository = repository;
            _notyfService = notyfService;
        }
        [BindProperty]
        public ApplicationCore.Entities.Cliente Cliente { get; set; }
 

      
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            
                if(id == null)
                {
                    return NotFound();
                }

            Cliente = await _repository.GetByIdAsync(id);

            if (Cliente == null)
                {
                    return NotFound();
                }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            try
            {
                var clienteToUpdate = await _repository.GetByIdAsync(id);
                if(clienteToUpdate == null)
                {
                    return NotFound();
                }
                if(await TryUpdateModelAsync(clienteToUpdate, 
                    "Cliente",
                    s => s.DUI,
                    s => s.Nombres,
                    s => s.Apellidos,
                    s => s.Genero,
                    s => s.Telefono,
                    s => s.NumLicencia,
                    s => s.Direccion))
                {
                    await _repository.SaveChangesAsync();
                    _notyfService.Success("Se ha guardado con exito");
                    return base.RedirectToPage("./Index");
                }
            }
            catch(Exception ex)
            {
                _notyfService.Error("Error no se puede");
            }
            return Page();
        }
        
    }
}
