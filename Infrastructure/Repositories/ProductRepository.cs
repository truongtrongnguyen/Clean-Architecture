using Application.Data;
using Domain.Products;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public sealed class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Add(Product product)
    {
        _context.Products.Add(product);
    }

    public async Task<Product?> GetByIdAsync(ProductId Id)
    {
        return await _context.Products
             .Include(p => p.Sku)
             .Include(p => p.Price)
             .FirstOrDefaultAsync();
    }

    public void Remove(Product product)
    {
        _context.Products.Remove(product);
    }
}
