using Domain.Products;
using MediatR;

namespace Application.Products.Get;

public record class GetProductQuery(ProductId ProductId) : IRequest<ProductResponse>;

public record class ProductResponse(
    Guid Id, 
    string Name, 
    string Sku, 
    string Currentcy,
    decimal Amount);