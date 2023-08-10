using EntityLayer.Concreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusniesLayer.ValidationRules
{
    public class WriterValidator: AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Burası boş olamaz");
            RuleFor(x => x.WriterSurName).NotEmpty().WithMessage("Burası boş olamaz");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Burası boş olamaz");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Burası boş olamaz");
            RuleFor(x => x.WriterName).MinimumLength(3).WithMessage("Lütfen en az 2 karakter giriniz");
            RuleFor(x => x.WriterSurName).MaximumLength(20).WithMessage("20 karakterden fazla olamaz");
        }
    }
}
