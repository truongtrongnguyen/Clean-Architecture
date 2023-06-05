using Domain.Products;
using MediatR;

namespace Application.Products.Update;

public record class UpdateProductCommand(
    ProductId ProductId,
    string Name,
    string Sku,
    string Currency,
    decimal Amount) : IRequest;

public record class UpdateProductRequest(
    string Name,    
    string Sku,
    string Currency,
    decimal Amount);