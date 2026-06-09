public interface IDiscount
{
    // Applies the discount to the given price and returns the new price.
    decimal Apply(decimal price);
    // Human-readable description used for traceability in logs.
    string Description { get; }
}