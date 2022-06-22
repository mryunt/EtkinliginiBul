using EtkinliginiBul.DAL.Dtos.Seat;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtkinliginiBul.Business.Validation.Seat
{
    public class SeatUpdateValidator : AbstractValidator<UpdateSeatDto>
    {
        public SeatUpdateValidator()
        {
            RuleFor(p => p.SeatNo).NotEmpty().WithMessage("Koltuk numarası boş bırakılamaz!");
            RuleFor(p => p.SeatPrice).NotEmpty().WithMessage("Koltuk fiyatı boş bırakılamaz!");
            RuleFor(p => p.SalonId).NotEmpty().WithMessage("Koltuk fiyatı boş bırakılamaz!");
        }
    }
}
