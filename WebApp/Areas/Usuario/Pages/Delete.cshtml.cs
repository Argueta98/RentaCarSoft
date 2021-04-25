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
    public class DeleteModel : PageModel
    {
        private readonly MyRepository<Usuarios> _repository;

        private INotyfService _notyfService { get; }
        public DeleteModel(MyRepository<Usuarios> repository, INotyfService notyfService)
        {
            _repository = repository;
            _notyfService = notyfService;
        }

        [BindProperty]
        public Usuarios Usuario { get; set; }
        public string ErrorMessage { get; set; }
        public async Task<IActionResult> OnGetAsync(int? Id, bool? saveChangesError = false)
        {
            if (Id == null)
            {
                return NotFound();
            }

            Usuario = await _repository.GetByIdAsync(Id);


            if (Usuario == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ErrorMessage = String.Format("DELETE {Id} Failed. Try again", Id);
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var usuario = await _repository.GetByIdAsync(Id);

            if (usuario == null)
            {
                return NotFound();
            }



            try
            {
                await _repository.DeleteAsync(usuario);
                await _repository.SaveChangesAsync();
                _notyfService.Success("Eliminado con exito");
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {


                return RedirectToPage("Index");
            }
        }

    }
}