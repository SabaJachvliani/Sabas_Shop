using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Handlers.Admin.ProductCategory.Command.Create
{
    public record CreateProductCategoryCommand
    (
        string Name
    )
        : IRequest<int>;
    
}
