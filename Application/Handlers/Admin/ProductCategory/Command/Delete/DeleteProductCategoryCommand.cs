using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Handlers.Admin.ProductCategory.Command.Delete
{
    public record DeleteProductCategoryCommand
    (
        int Id
    )
        : IRequest<Unit>;
}
