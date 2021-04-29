using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Constants;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Services;
using ApplicationCore.Specification;
using ApplicationCore.Specification.Filters;
using AspNetCoreHero.ToastNotification.Abstractions;
using Infraestructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Models;

namespace WebApp.Areas.Alquiler.Pages
{
    public class CreateModel : PageModel
    {
        private readonly MyRepository<ApplicationCore.Entities.Alquiler> _repository;
        private INotyfService _notyfService { get; }
        private readonly ICalculadoraService _calculadoraServices;
        public CreateModel(MyRepository<ApplicationCore.Entities.Alquiler> repository, INotyfService notyfService, ICalculadoraService calculadoraServices)
        {
            _repository = repository;
            _notyfService = notyfService;
            _calculadoraServices = calculadoraServices;
        }

        public ApplicationCore.Entities.Alquiler Alquileres { get; set; }
        public UIPaginationModel UIPagination { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //Alumno.Fotografia = await _fileUploadService.SaveFileOnAWSS3(fileUpload, Alumno.NombreFotografia(), "mycleanarchitecturebucket");
                    // Auto.Fotografia = await _fileUploadService.SaveFileOnDisk(fileUpload, Auto.NombreFotografia(), "auto");

                    Alquileres.PrecioAlquiler =
                    await _calculadoraServices.CalcularPrecioAlquiler(Alquileres.FechaInicio, Alquileres.FechaFinal, Alquileres.Auto.TipoAuto.GetType(int));
                    await _repository.AddAsync(Alquileres);
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
