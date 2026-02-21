using FluentValidation;

namespace Application.Handlers.Admin.Product.Comands.Update
{
    internal class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage("Id must be greater than 0.");

            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(200);

            RuleFor(x => x.Price)
                .GreaterThan(0);

            // optional (allow empty), just limit size
            RuleFor(x => x.Description)
                .MaximumLength(2000);

            RuleFor(x => x.ProductCategoryId)
                .GreaterThan(0);
        }
    }
}
