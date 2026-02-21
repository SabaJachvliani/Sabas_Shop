using Application.DTO.ProductCategory;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Handlers.Admin.ProductCategory.Queries.GetProductCategoryList
{
    public record GetProductCategoryListQuery() : IRequest<List<GetProductCategoryListDTO>>;
    
}
