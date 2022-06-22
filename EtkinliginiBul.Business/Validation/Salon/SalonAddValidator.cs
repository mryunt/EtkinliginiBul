using EtkinliginiBul.DAL.Dtos.Salon;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtkinliginiBul.Business.Validation.Salon
{
    public class SalonAddValidator : AbstractValidator<AddSalonDto>
    {
        public SalonAddValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Salon ismi alanı boş bırakılamaz!");
            RuleFor(p => p.AddressId).NotEmpty().WithMessage("Salon ismi alanı boş bırakılamaz!");

        }
    }
}
