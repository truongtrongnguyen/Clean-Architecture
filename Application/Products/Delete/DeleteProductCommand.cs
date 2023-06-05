using Domain.Products;
using MediatR;

namespace Application.Products.Delete;

public record class DeleteProductCommand (
    ProductId ProductId) : IRequest;
