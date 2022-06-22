using EtkinliginiBul.DAL.Dtos.Images;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtkinliginiBul.Business.Validation.Images
{
    public class ImagesAddValidator : AbstractValidator<AddImagesDto>
    {
        public ImagesAddValidator()
        {
            RuleFor(p => p.Image).NotEmpty();
            RuleFor(p => p.EventID).NotEmpty();
        }
    }
}
