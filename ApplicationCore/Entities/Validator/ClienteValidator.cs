using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities.Validator
{
    public class ClienteValidator : AbstractValidator<Clientes>
    {
        public ClienteValidator()
        {
            RuleFor(x => x.Id).NotNull();

            RuleFor(x => x.DUI).NotNull().WithMessage("Codigo es requerido")
            .Length(3,12).WithMessage("El Codigo debe tener 12 caracteres")
            .Matches(@"^\d{8}-\d{1}$").WithMessage("El número de DUI debe de tener formato correcto");

            RuleFor(x => x.Nombres).NotNull().WithMessage("Nombre es requerido")
           .Length(3, 100).WithMessage("El Nombre debe contener entre 3 y 100 caracteres");

            RuleFor(x => x.Apellidos).NotNull().WithMessage("Apellido es requerido")
           .Length(3, 100).WithMessage("El Apellido debe contener entre 3 y 100 caracteres");

            RuleFor(x => x.Genero).IsInEnum().WithMessage("Ingrese un Genero valido");

            RuleFor(x => x.Telefono).NotNull()
                .Matches(@"^\d{4}-\d{4}$").WithMessage("El número de telefono debe de tener formato correcto");

            RuleFor(x => x.NumLicencia).NotNull().WithMessage("No dejar Vacio");

            RuleFor(x => x.Direccion).NotNull().WithMessage("Direccion es requerida");
        }
    }
}
