namespace Domain.Products;

public sealed class ProductNotFoundException : Exception
{
    public ProductNotFoundException(ProductId Id) : base($"The Prroduct with the ID = {Id.Value} was not found")
    {
    }
}
