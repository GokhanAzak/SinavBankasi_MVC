using EntityLayer.Concreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusniesLayer.ValidationRules
{
    public class ContactValidator:AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Burası boş olamaz");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Burası boş olamaz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Burası boş olamaz");
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("Lütfen en az 3 karakter giriniz");
            RuleFor(x => x.Message).MaximumLength(100).WithMessage("100 karakterden fazla olamaz");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Lütfen en az 3 karakter giriniz");
            RuleFor(x => x.Subject).MaximumLength(100).WithMessage("100 karakterden fazla olamaz");
        }
    }
}
