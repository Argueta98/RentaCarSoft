using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities.Validator
{
    public class AlquilerValidator : AbstractValidator<Alquiler>
    {
        public AlquilerValidator()
        {
            RuleFor(x => x.Id).NotNull();

            RuleFor(x => x.ClienteId).NotNull();//Aqui modifique

            RuleFor(x => x.AutoId).NotNull(); //Aqui modifique

            RuleFor(x => x.FechaInicio).NotNull().WithMessage("Fecha es requerida");

            RuleFor(x => x.FechaFinal).IsInEnum().WithMessage("Fecha es requerida");

            RuleFor(x => x.PrecioAlquiler).IsInEnum().WithMessage("Color es requerido");

            RuleFor(x => x.CantidadTotal).NotNull().WithMessage("Tipo de Combustible es requerido");
        }
    }
}
