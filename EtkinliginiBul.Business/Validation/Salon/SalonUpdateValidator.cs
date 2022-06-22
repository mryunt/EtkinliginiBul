using EtkinliginiBul.DAL.Dtos.Salon;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtkinliginiBul.Business.Validation.Salon
{
    public class SalonUpdateValidator : AbstractValidator<UpdateSalonDto>
    {
        public SalonUpdateValidator()
        {
            RuleFor(p => p.AddressId).NotEmpty().WithMessage("Salon ID' si boş bırakılamaz!");
            RuleFor(p => p.Name).NotEmpty().WithMessage("Salon ismi alanı boş bırakılamaz!");
        }
    }
}
