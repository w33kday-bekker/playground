using System.Collections.Generic;
// Extension methods for applying multiple discounts to a base price.
// Encapsulates discount pipeline logic in a reusable way.
public static class DiscountExtensions
{
    // Applies a sequence of discounts in order to a base price.
    // Each step is recorded for traceability.
    public static DiscountResult ApplyDiscounts(
        this decimal price,
        IEnumerable<IDiscount> discounts)
    {
        var result = new DiscountResult();

        // Tracks running price as each discount is applied
        decimal current = price;

        foreach (var discount in discounts)
        {
            var newPrice = discount.Apply(current);
            // Records steps for reviewing purposes
            result.Steps.Add(
                $"{discount.Description}: {current:C} -> {newPrice:C}"
            );
            current = newPrice;
        }

        result.FinalPrice = current;
        return result;
    }
}