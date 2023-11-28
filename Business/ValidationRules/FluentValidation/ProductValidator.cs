using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty();
            RuleFor(P => P.ProductName).MinimumLength(3);
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThan(0);
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 1);
            RuleFor(P => P.ProductName).Must(StartWirtA).WithMessage("Product Name Must Be Start With 'A'");
        }

        private bool StartWirtA(string arg)
        {
            // Alttaki örneğin alternatif kısa syntaxı
            return arg.StartsWith("A");

            //if (arg[0] == 'A')
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
        }
    }
}
