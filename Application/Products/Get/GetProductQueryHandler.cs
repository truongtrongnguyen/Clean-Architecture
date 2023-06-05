using MediatR;
using Application.Data;
using Domain.Products;

namespace Application.Products.Get;

public sealed class GetProductQueryHandler : IRequestHandler<GetProductQuery, ProductResponse>
{
    private readonly IApplicationDbContext _context;

    public GetProductQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ProductResponse> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var product = _context
            .Products
            .Where(p => p.Id == request.ProductId)
            .Select(p => new ProductResponse(
                p.Id.Value,
                p.Name,
                p.Sku.Value,
                p.Price.Currency,
                p.Price.Amount))
            .FirstOrDefault();
        
        if(product is null)
        {
            throw new ProductNotFoundException(request.ProductId);
        }

        return product;
    }
}
