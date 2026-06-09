public class PercentageDiscount : IDiscount
{
    // Percentage discount to apply (10 = 10%)
    private readonly decimal _percentage;

    public PercentageDiscount(decimal percentage)
    {
        _percentage = percentage;
    }

    // Used for trace outputs
    public string Description => $"{_percentage}% off";

    // Applies percent discount to input price
    public decimal Apply(decimal price)
    {
        //m suffix added to ensure demcimal data type is used
        var result = price - (price * _percentage / 100m);
        return Math.Round(result, 2);
    }
}