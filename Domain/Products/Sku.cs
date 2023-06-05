namespace Domain.Products;

public record class Sku
{
    private const int DefaultLength = 8;
    public string Value { get; init; }
    private Sku(string Value) => Value = Value;
    public static Sku? Create(string value)
    {
        if (string.IsNullOrEmpty(value))
            return null;

        if (value.Length < DefaultLength)
            return null;

        return new Sku(value);
    }
}
