using System.Collections;

namespace SystemDesign;

public class BloomFilter<T>
{
    private readonly BitArray _bitArray;
    private readonly int _bitArraySize;
    private readonly int _hashFunctionsCount;

    public BloomFilter(int size, int hashFunctionsCount)
    {
        _bitArraySize = size;
        _hashFunctionsCount = hashFunctionsCount;
        _bitArray = new BitArray(_bitArraySize);
    }

    public void Add(T item)
    {
        int hash1 = item.GetHashCode();
        int hash2 = BloomFilter<T>.Hash2(item);

        for (int i = 0; i < _hashFunctionsCount; i++)
        {
            int combinedHash = BloomFilter<T>.ComputeHash(hash1, hash2, i);
            int index = Math.Abs(combinedHash % _bitArraySize);
            _bitArray.Set(index, true);
        }
    }

    public bool Contains(T item)
    {
        int hash1 = item.GetHashCode();
        int hash2 = BloomFilter<T>.Hash2(item);

        for (int i = 0; i < _hashFunctionsCount; i++)
        {
            int combinedHash = BloomFilter<T>.ComputeHash(hash1, hash2, i);
            int index = Math.Abs(combinedHash % _bitArraySize);

            if (!_bitArray.Get(index))
            {
                return false;
            }
        }

        return true;
    }

    private static int ComputeHash(int hash1, int hash2, int i)
    {
        return hash1 + i * hash2;
    }

    private static int Hash2(T item)
    {
        int hash = item.GetHashCode();
        return (hash >> 16) | (hash << 16);
    }
}