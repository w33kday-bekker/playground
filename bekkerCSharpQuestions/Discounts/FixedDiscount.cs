public class FixedDiscount : IDiscount
{
    // Discount amount to apply (8.5 = $8.50)
    private readonly decimal _amount;

    public FixedDiscount(decimal amount)
    {
        _amount = amount;
    }

    // Used for trace outputs
    public string Description => $"{_amount:C} off";

    // Applies fixed discount to input price
    public decimal Apply(decimal price)
    {
        var result = price - _amount;
        
        // prevent negative prices
        result = result < 0 ? 0 : result;
        
        return Math.Round(result, 2);

    }
}