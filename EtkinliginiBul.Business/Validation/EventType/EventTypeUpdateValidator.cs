using EtkinliginiBul.DAL.Dtos.EventType;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtkinliginiBul.Business.Validation.EventType
{
    public class EventTypeUpdateValidator : AbstractValidator<UpdateEventTypeDto>
    {
        public EventTypeUpdateValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Etklinlik Adı Alanı Boş Bırakılamaz!");

        }
    }
}
