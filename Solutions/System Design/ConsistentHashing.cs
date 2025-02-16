namespace SystemDesign;

public class ConsistentHashing<T>
{
    private SortedDictionary<int, T> ring = new SortedDictionary<int, T>();
    private int numberOfReplicas;

    public ConsistentHashing(IEnumerable<T> nodes, int numberOfReplicas = 100)
    {
        this.numberOfReplicas = numberOfReplicas;
        foreach (T node in nodes)
        {
            Add(node);
        }
    }

    public void Add(T node)
    {
        for (int i = 0; i < numberOfReplicas; i++)
        {
            int hash = ConsistentHashing<T>.GetHash(node.ToString() + i);
            ring[hash] = node;
            Console.WriteLine($"Added node {node} with replica {i} at position {hash}");
        }
    }

    // Remove a node and all replicas from the ring
    public void Remomve(T node)
    {
        for (int i = 0; i < numberOfReplicas; i++)
        {
            int hash = ConsistentHashing<T>.GetHash(node.ToString() + i);
            ring.Remove(hash);
            Console.WriteLine($"Removed node {node} replica {i} at position {hash}");
        }
    }

    // Get the node responsible for a given key
    public T GetNode(string key)
    {
        if (ring.Count == 0)
        {
            throw new Exception("No nodes in the ring");
        }

        int hash = ConsistentHashing<T>.GetHash(key);
        foreach (var entry in ring)
        {
            if (entry.Key >= hash)
            return entry.Value;
        }

        return ring.First().Value;

    }

    private static int GetHash(string key)
    {
        return Math.Abs(key.GetHashCode());
    }
}