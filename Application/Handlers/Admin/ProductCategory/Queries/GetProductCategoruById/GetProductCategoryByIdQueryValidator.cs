using FluentValidation;

namespace Application.Handlers.Admin.ProductCategory.Queries.GetProductCategoruById
{
    internal class GetProductCategoryByIdQueryValidator : AbstractValidator<GetProductCategoryByIdQuery>
    {
        public GetProductCategoryByIdQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Id must be greater than 0.");
        }
    }

}
