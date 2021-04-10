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
        private readonly MyRepository<Clientes> _repository;
        private INotyfService _notyfService { get; }
        public EditModel(MyRepository<Clientes> repository, INotyfService notyfService)
        {
            _repository = repository;
            _notyfService = notyfService;
        }
        [BindProperty]
        public Clientes Cliente { get; set; }
      
        
    }
}
