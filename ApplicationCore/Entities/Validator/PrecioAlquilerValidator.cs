using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities.Validator
{
   public  class PrecioAlquilerValidator : AbstractValidator<PrecioAlquiler>
    {
        public PrecioAlquilerValidator()
        {
            RuleFor(x => x.Id).NotNull();

            RuleFor(x => x.Precio).NotNull().WithMessage("Coloque el precio");
        }
    }
}
