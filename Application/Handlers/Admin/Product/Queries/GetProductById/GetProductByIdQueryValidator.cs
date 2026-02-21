using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Handlers.Admin.Product.Queries.GetProductById
{
    internal class GetProductByIdQueryValidator : AbstractValidator<GetProductByIdQuery>
    {
        public GetProductByIdQueryValidator() 
        { 
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Id must be greater than 0.");
        }
    }
}
