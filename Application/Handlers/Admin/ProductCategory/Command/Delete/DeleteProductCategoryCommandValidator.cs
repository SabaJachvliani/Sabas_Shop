using FluentValidation;

namespace Application.Handlers.Admin.ProductCategory.Command.Delete
{
    internal class DeleteProductCategoryCommandValidator : AbstractValidator<DeleteProductCategoryCommand>
    {
        public DeleteProductCategoryCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Id must be greater than 0.");
        }
    }

}
