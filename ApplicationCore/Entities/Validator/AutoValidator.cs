using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities.Validator
{
    public class AutoValidator : AbstractValidator<Autos>
    {
        public AutoValidator()
        {
            RuleFor(x => x.Id).NotNull();

            RuleFor(x => x.Placa).NotNull().WithMessage("Numero de Placa requerido")
            .Length(12).WithMessage("El Codigo debe tener 12 caracteres");

            RuleFor(x => x.Marca).NotNull().WithMessage("Marca es requerida")
           .Length(3, 50).WithMessage("El Nombre debe contener entre 10 y 40 caracteres");

            RuleFor(x => x.Modelo).NotNull().WithMessage("Modelo es requerido")
           .Length(3, 50).WithMessage("El Apellido debe contener entre 3 y 50 caracteres");

           RuleFor(x => x.TipoAuto).IsInEnum().WithMessage("Sellecione Uno");

            RuleFor(x => x.Color).NotNull().WithMessage("Color es requerido")
          .Length(3, 50).WithMessage("El Apellido debe contener entre 3 y 10 caracteres");

            RuleFor(x => x.Combustible).NotNull().WithMessage("Tipo de Combustible es requerido")
           .Length(3, 50).WithMessage("El Apellido debe contener entre 3 y 10 caracteres");

            RuleFor(x => x.Estado).IsInEnum().WithMessage("Ingrese un Estado valido");


        }
    }
}
