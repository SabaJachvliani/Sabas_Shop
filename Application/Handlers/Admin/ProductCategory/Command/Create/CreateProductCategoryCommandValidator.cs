using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Handlers.Admin.ProductCategory.Command.Create
{
    internal class CreateProductCategoryCommandValidator : AbstractValidator<CreateProductCategoryCommand>
    {
        public CreateProductCategoryCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(200).WithMessage("Name must be <= 200 characters.");
        }
    }
}
