using EntityLayer.Concreate;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusniesLayer.ValidationRules
{
    public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x=>x.CategoryName).NotEmpty().WithMessage("Burası boş olamaz");
            RuleFor(x=>x.CategoryDescription).NotEmpty().WithMessage("Açıklama boş olamaz");
            RuleFor(x=>x.CategoryName).MinimumLength(3).WithMessage("Lütfen en az 3 karakter giriniz");
            RuleFor(x => x.CategoryName).MaximumLength(20).WithMessage("20 karakterden fazla olamaz");
        }
    }
}
