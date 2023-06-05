using MediatR;

namespace Application.Products;

public record class CreateProductCommand(
    string Name,
    string Sku,
    string Currency,
    decimal Amount) : IRequest;
