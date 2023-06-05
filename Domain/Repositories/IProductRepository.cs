using Domain.Products;

namespace Domain.Repositories;

public interface IProductRepository
{
    Task<Product?> GetByIdAsync(ProductId Id);
    void Add(Product product);
    void Remove(Product product);
}
