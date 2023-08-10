using EntityLayer.Concreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusniesLayer.ValidationRules
{
    public class StudentsValidation : AbstractValidator<Students>
    {
        public StudentsValidation()
        {
            RuleFor(x => x.StudentName).NotEmpty().WithMessage("Burası boş olamaz");
            RuleFor(x => x.StudentMail).NotEmpty().WithMessage("Burası boş olamaz");
            RuleFor(x => x.StudentSurName).NotEmpty().WithMessage("Burası boş olamaz");
            RuleFor(x => x.StudentName).MinimumLength(3).WithMessage("Lütfen en az 2 karakter giriniz");
            RuleFor(x => x.StudentMail).MaximumLength(20).WithMessage("20 karakterden fazla olamaz");

        }
    }
}
