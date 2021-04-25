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
    public class DeleteModel : PageModel
    {
        private readonly MyRepository<Clientes> _repository;

        private INotyfService _notyfService { get; }
        public DeleteModel(MyRepository<Clientes> repository, INotyfService notyfService)
        {
            _repository = repository;
            _notyfService = notyfService;
        }

        [BindProperty]
        public Clientes Cliente { get; set; }
        public string ErrorMessage { get; set; }
        public async Task<IActionResult> OnGetAsync(int? Id, bool? saveChangesError = false)
        {
            if(Id== null)
            {
                return NotFound();
            }

            Cliente = await _repository.GetByIdAsync(Id);
                

            if(Cliente == null)
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
            if(Id == null)
            {
                return NotFound();
            }

            var cliente = await _repository.GetByIdAsync(Id);

            if(cliente == null)
            {
                return NotFound();
            }



            try
            {
                await _repository.DeleteAsync(cliente);
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
