using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Handlers.Admin.ProductCategory.Command.Update
{
    public record UpdateProductCategoryCommand
    (
        int Id,
        string Name 
    )
        : IRequest<int>;

}
