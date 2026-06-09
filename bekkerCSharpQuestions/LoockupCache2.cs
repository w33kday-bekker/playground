using System;
using System.Collections.Generic;

// Simple in-memory key/value cache with generic value support.
public class LookupCache2<T>
{
    private readonly Dictionary<string, T> _storage = new();

    public void Add(string key, T value)
    {
        if (key == null)
            throw new ArgumentNullException(nameof(key));

        _storage[key] = value;
    }

    public void AddRange(params (string key, T value)[] items)
    {
        foreach (var (key, value) in items)
        {
            Add(key, value); // reuse validation + logic
        }
    }

    public T Get(string key)
    {
        if (key == null)
            throw new ArgumentNullException(nameof(key));

        if (_storage.TryGetValue(key, out var value))
            return value;

        throw new KeyNotFoundException($"Key '{key}' not found.");
    }
}