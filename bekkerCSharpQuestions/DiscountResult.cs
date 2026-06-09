public class DiscountResult
{
    // Final price as all discounts have been applied sequentially 
    public decimal FinalPrice { get; set; }
    // Step-by-step breakdown of how the final result was reached
    public List<string> Steps { get; set; } = new();
}