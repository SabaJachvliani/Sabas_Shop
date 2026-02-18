using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Handlers.Admin.Product.Comands.Delete
{
    public record DeleteProductCommand(int Id) : IRequest<Unit>;
        
}
