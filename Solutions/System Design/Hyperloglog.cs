using System.Numerics;

namespace SystemDesign;

public class Hyperloglog
{
    private readonly int _b;
    private readonly int _m;
    private readonly double _alphaMM; 
    private readonly byte[] _registers;

    /// <summary>
    /// Creates a new Hyperloglog instance.
    /// </summary>
    /// <param name="b">The number of bits for the register index (between 4 and 16 recommended).</param>
    public Hyperloglog(int b = 10)
    {
        if (b < 4 || b > 16)
        {
            throw new ArgumentException("b must be between 4 and 16");
        }

        _b = b;
        _m = 1 << b; // m = 2^b
        _registers = new byte[_m];
        _alphaMM = GetAlphaMM(_m);
        Console.WriteLine($"Initialized Hyperloglog with b = {_b}, m = {_m}");
    }

    /// <summary>
    /// Computes the alpha * m^2 constant based on m.
    /// </summary>
    private static double GetAlphaMM(int m)
    {
        if (m == 16)
        return 0.673 * m * m;
        if (m == 32)
        return 0.697 * m * m;
        if (m == 64)
        return 0.709 * m * m;
        else
        return (0.7213 / (1 + 1.079 / m)) * m * m;
    }

    /// <summary>
    /// Adds an item to the Hyperloglog instance.
    /// </summary>
    /// <param name="item">The item to add.</param>
    public void Add(string item)
    {
        ulong hash = Fnv1aHash64(item);
        int index = (int)(hash & ((ulong)_m - 1));
        hash >>= _b;
        int rank = BitOperations.LeadingZeroCount(hash) + 1;

        if (rank > _registers[index])
        {
            _registers[index] = (byte)rank;
        }

        // Debug
        Console.WriteLine($"Adding item: {item}, index: {index}, rank: {rank}");
        Console.WriteLine($" 64-bit hash: {Fnv1aHash64(item)}");
        Console.WriteLine($" Register Index: (from low {_b} bits): {index:X}");
        Console.WriteLine($" Rank: {rank}");
        Console.WriteLine($" Registers: {string.Join(", ", _registers)}");
        Console.WriteLine();
    }

    /// <summary>
    /// Estimates the number of distinct elements added.
    /// </summary>
    /// <returns>The estimated number of distinct elements.</returns>
    public double Estimate()
    {
        double sum = 0;
        int zeroRegisters = 0;
        for (int i = 0; i < _m; i++)
        {
            sum += 1.0 / (1 << _registers[i]);
            if (_registers[i] == 0)
            {
                zeroRegisters++;
            }
        }

        double estimate = _alphaMM / sum;

        if (estimate <= 2.5 * _m)
        {
            if (zeroRegisters != 0)
            {
                estimate = _m * Math.Log((double)_m / zeroRegisters);
            }
        }

        // Debug
        Console.WriteLine($"\nEstimated details:");
        Console.WriteLine($"Zero Registers: {zeroRegisters}");
        Console.WriteLine($"Sum: {sum}");
        Console.WriteLine($"Estimate distinct count: {estimate}\n");

        return estimate;
    }

    /// <summary>
    /// A simple 64-bit FNV-1a hash function.
    /// </summary>
    private static ulong Fnv1aHash64(string data)
    {
        const ulong offsetBasis = 14695981039346656037ul;
        const ulong prime = 1099511628211ul;
        ulong hash = offsetBasis;
        foreach (char c in data)
        {
            hash ^= c;
            hash *= prime;
        }
        return hash;
    }
}