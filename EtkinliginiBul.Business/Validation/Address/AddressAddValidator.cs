using EtkinliginiBul.DAL.Dtos.Address;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtkinliginiBul.Business.Validation.Address
{
    public class AddressAddValidator : AbstractValidator<AddAddressDto>
    {
        public AddressAddValidator()
        {
            RuleFor(p => p.AddressName).NotEmpty();
            RuleFor(p => p.Lat).NotEmpty();
            RuleFor(p => p.Lng).NotEmpty();
        }
    }
}
