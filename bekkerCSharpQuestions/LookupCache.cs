using System;
using System.Collections.Generic;

// Simple in-memory key/value cache.
// Designed for fast lookups and simple overwrite semantics.
public class LookupCache
{
    // Internal storage using Dictionary for O(1) average lookup performance.
    private readonly Dictionary<string, string> _storage = new();

    // Adds a single value, if key already exists, it is overwritten
    public void Add(string key, string value)
    {
        if (key == null)
        {
            throw new ArgumentNullException(nameof(key));
        }
        _storage[key] = value;
    }

    // Add multiple values at once, not dependant on Add method 
public void AddRange(params (string key, string value)[] items)    {
    var dict = new Dictionary<string, string>();

    foreach (var item in items)
    {
        dict[item.key] = item.value;
    }

    foreach (var pair in dict)
    {
        _storage[pair.Key] = pair.Value;
    }
}

    // Retrieve a value by key
    public string Get(string key)
    {
        if (_storage.TryGetValue(key, out var value))
        {
            return value;
        }

        throw new KeyNotFoundException($"Key '{key}' not found.");
    }
}