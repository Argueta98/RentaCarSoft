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
using Microsoft.AspNetCore.Http;
using System.IO;
using WebApp.Services;

namespace WebApp.Areas.Auto.Pages
{
    public class CreateModel : PageModel
    {
        private readonly MyRepository<ApplicationCore.Entities.Auto> _repository;
        private INotyfService _notyfService { get; }
        private readonly IFileUploadService _fileUploadService;

        public CreateModel(MyRepository<ApplicationCore.Entities.Auto> repository, INotyfService notyfService, IFileUploadService fileUploadService)
        {
            _repository = repository;
            _notyfService = notyfService;
            _fileUploadService = fileUploadService;
        }

        [BindProperty]
        public ApplicationCore.Entities.Auto Auto { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(IFormFile fileUpload)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //Alumno.Fotografia = await _fileUploadService.SaveFileOnAWSS3(fileUpload, Alumno.NombreFotografia(), "mycleanarchitecturebucket");
                    Auto.Fotografia = await _fileUploadService.SaveFileOnDisk(fileUpload, Auto.NombreFotografia(), "auto");
                    await _repository.AddAsync(Auto);
                    _notyfService.Success("Auto agregado exitosamente");
                }
                else
                {
                    _notyfService.Warning("Su formulario no cumple las reglas de negocio");
                    return Page();
                }
                return RedirectToPage("Index");
            }
            catch (Exception ex)
            {

                _notyfService.Error("Ocurrio un error en el servidor, intente nuevamente");
                return RedirectToPage("Index");
            }
        }
    }
}
