using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using AspNetCoreHero.ToastNotification.Abstractions;
using Infraestructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Areas.Auto.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly MyRepository<ApplicationCore.Entities.Auto> _repository;
        private INotyfService _notyfService { get; }

        public DeleteModel(MyRepository<ApplicationCore.Entities.Auto> repository, INotyfService notyfService)
        {
            _repository = repository;
            _notyfService = notyfService;
        }
        [BindProperty]
        public ApplicationCore.Entities.Auto Auto { get; set; }
        public string ErrorMessage { get; set; }
        public async Task<IActionResult> OnGetAsync(int? Id, bool? saveChangesError = false)
        {
            if (Id == null)
            {
                return NotFound();
            }

            Auto = await _repository.GetByIdAsync(Id);


            if (Auto == null)
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

            var autos = await _repository.GetByIdAsync(Id);

            if (autos == null)
            {
                return NotFound();
            }



            try
            {
                await _repository.DeleteAsync(autos);
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
