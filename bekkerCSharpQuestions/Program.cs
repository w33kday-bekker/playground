using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("QUESTION 1 - LOOKUP CACHE TESTS");

        RunLookupTests();

        Console.WriteLine("QUESTION 2 - DISCOUNT SYSTEM TESTS");

        RunDiscountTests();
    }

    // =========================
    // LOOKUP CACHE TESTS
    // =========================
    static void RunLookupTests()
    {
        var cache = new LookupCache();

        Console.WriteLine("\n-- Add + Get single value --");
        cache.Add("Host", "localhost");
        Console.WriteLine(cache.Get("Host"));

        Console.WriteLine("\n-- AddRange multiple values --");
        cache.AddRange(
            ("Port", "8080"),
            ("Protocol", "http"),
            ("ACT", "Energy")
        );

        Console.WriteLine(cache.Get("Port"));
        Console.WriteLine(cache.Get("Protocol"));
        Console.WriteLine(cache.Get("ACT"));

        Console.WriteLine("\n-- Overwrite existing key --");
        cache.Add("Host", "127.0.0.1");
        Console.WriteLine(cache.Get("Host"));

        Console.WriteLine("\n-- Missing key handling (expected exception) --");
        try
        {
            Console.WriteLine(cache.Get("DoesNotExist"));
        }
        catch (KeyNotFoundException ex)
        {
            Console.WriteLine($"Handled: {ex.Message}");
        }
    }

    // DISCOUNT SYSTEM TESTS
    static void RunDiscountTests()
    {
        RunDiscountTest("Single percentage discount", 100m, new List<IDiscount>
        {
            new PercentageDiscount(10)
        });

        RunDiscountTest("Single fixed discount", 100m, new List<IDiscount>
        {
            new FixedDiscount(25)
        });

        RunDiscountTest("Percentage then fixed", 100m, new List<IDiscount>
        {
            new PercentageDiscount(10),
            new FixedDiscount(15)
        });

        RunDiscountTest("Fixed then percentage", 100m, new List<IDiscount>
        {
            new FixedDiscount(15),
            new PercentageDiscount(10)
        });

        RunDiscountTest("Multiple percentage discounts", 187m, new List<IDiscount>
        {
            new PercentageDiscount(10),
            new PercentageDiscount(10),
            new PercentageDiscount(10)
        });

        RunDiscountTest("Over-discount edge case", 50m, new List<IDiscount>
        {
            new FixedDiscount(30),
            new FixedDiscount(50),
            new PercentageDiscount(20)
        });
    }

    static void RunDiscountTest(string name, decimal basePrice, List<IDiscount> discounts)
    {
        Console.WriteLine("\n------------------------------------");
        Console.WriteLine(name);
        Console.WriteLine("------------------------------------");

        var result = basePrice.ApplyDiscounts(discounts);

        foreach (var step in result.Steps)
        {
            Console.WriteLine(step);
        }

        Console.WriteLine($"Final Price: {result.FinalPrice:C}");
    }
}