using FluentValidation;

namespace Application.Handlers.Admin.Product.Comands.Create
{
    public sealed class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(200);

            RuleFor(x => x.Price)
                .GreaterThan(0);

            // if Description can be empty, keep it optional:
            RuleFor(x => x.Description)
                .MaximumLength(2000);

            RuleFor(x => x.ProductCategoryId)
                .GreaterThan(0);
        }
    }
}
