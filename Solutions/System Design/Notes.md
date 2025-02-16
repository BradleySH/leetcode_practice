# System Design

## Bloom Filter

- A Bloom filter is a probabilistic data structure that allows you to check if an element is in a set.
- It can tell you if an element is in a set, but it may return a false positive.
- It is a space-efficient data structure that is used to check if an element is in a set.
- It is a good choice when you want to check if an element is in a set and you don't care about the false positives.

### What is a Bloom Filter?

Imagine a huge liste of items (millions of words), and you want to quickly check if a specific item is in that list
without scanning the entire collection. A _Bloom Filter_ helps you do this efficiently with a twist: it is fast and memory efficient but might sometimes say an item is there when it is not (false positive). However, if it tells you an item is not present, you can trust that result.

### Why It's Needed

- Space Efficieny:
  - Instead of storing every element explicitly, a _Bloom Filter_ uses a fixed bit array. This is ideal for huge datasets where memory is at a premium.
- Speed:
  - Membership checks involve only a few hash function computations and bit array lookups. This makes it extremely fast compared to scanning through large datasets.
- Scalability:
  - A _Bloom Filter_ can manage millions of elements without a proportional increase in memory usage. This is crucial in systems that need to scale differently.
- Acceptable Tradeoff:
  - In many applications, a small chance of false positives is acceptable if it means significantly reduced memory usage and increased speed.

### How Does It Work?

1. Fixed-Size Bit Array:
   - The filter starts with a bit array of predetermined size, where each bit is initially set to 0 (false).
2. Multiple Hash Functions:
   - Several hash functions are used.
   - Each function converts an element (like a word) into a specific index in a bit array.
3. Adding an Element:
   - When you add an element, each hash function produces an index. The bits at these indices are set to 1 (true).
4. Checking for Membership:
   - To check if an element is in the set, the element is hashed using the same functions.
   - If all the corresponding bits are 1, the element might be in the set(false positive).
   - If any bit is 0, the element is definetly not in the set.
5. Double Hashing:
   - Often, two base hash functions are combined (using techniques like bit shifting) to simulate multiple hash functions. This simplifies implementation while still ensuring good distribution across the bit array.

### Use Cases

- Caching:
  - Quickly determines whether to check a cache or skip a lookup if the item is definetly not there. Saves time and reduces load on slower storage systems.
- Web Crawling:
  - Tracks which URLs have been visited, avoiding duplicate crawling.
  - Helps manage massive lists of URLs efficiently.
- Database Query Optimization:
  - Filters out non-existent keys before performing expensive database queries.
  - Reduces unnecessary disk I/O and improves performance.
- Networking and Distributed Systems:
  - Determines whether a node might contain a piece of data in a distributed database or peer-to-peer network.
  - Minimizes network traffic and improves system efficiency.
- Security:
  - Identifies potential malicious entries (like URLS or IP addresses) quickly without storing the full list.
  - Used in spam filtering, intrusion detection, and other security applications.

### How to Implement a Bloom Filter in C-Sharp

see [BloomFilter.cs](../SystemDesign/BloomFilter.cs)

## Geohash

### What is a Geohash?

- Definition:
A Geohash is a geocoding system that encodes a geographic location (latitude and longitude) into a short alphanumeric string.

- Purpose:
It represents spatial data in a compact form, making it easy to index and query geographic locations.

- Key Characteristics:
  - Hierarchical:
  The longer the Geohash string, the more precise the location.
  - Spatial Proximity:
  Nearby locations often share the same prefix in their Geohash representation.
  - Compact: A single string can encode a specific region or point on earth.

### Why It's Needed

- Efficient Spatial Indexing: Geohases allow databases and search systems to index geographic data quickly and efficiently by grouping nearby locations together.
- **Simplified Proximity Searches:** By comparing Geohash prefixes, you can quickly narrow down regions when performing range queries or finding nearby points.
- **Compact Representation:** Instead of string floating-point latitude and longitude values, a geohash compresses this information into a short string.
- **Data Sharing and Caching:** A concise string is easier to send over networks or store in caches, which is useful for web services and mobile applications.

### How Does It Work?

1. **Grid Division:** The world is divided into a grid of cells. Each cell represents a rectangular area of the Earths surface.
2. **Binary Encoding:** Latitude and Longitude are converted into binary representations. The binary strings are interleaved to form a single combined binary string.
3. **Base32 Conversion:** The combined binary string is then converted into Base32 string, which is the final Geohash. Then length of the Geohash determines the cell size (longer strings mean smaller, more precise cells).
4. **Hierarchical Structure:** The beginning of a Geohash string (its prefix) represents a border area. Adding more characters refines the location within that area.
5. **Spatial Proximity:** Points that are geographically close will usually have similar Geohash Prefixes. This makes it efficient to search nearby points by comparing prefixes.

### Use Cases

- **Location-Based Services:** Mobile apps and web services use Geohashes to quickly determine nearby points of interest (e.g., restaurants, ATMs).
- **Mapping and GIS:** Geographic Information Systems (GIS) use Geohashes to index and query spatial data efficiently.
- **Spatial Databases:** Databases like MongoDB or Elasticsearch can use Geohashes to perform fast geospatial queries.
- **Clustering and Heatmaps:** Geohashes are useful for grouping spatial data into clusters for analysis or visualization (e.g., heatmaps showing user density).
- **Routing and Navigation:** Geohashes help in segmenting the map into regions for efficient route planning and navigation.
- **Caching Geographical Data:** Systems can cache location-specific data using Geohash strings as keys, improving performance for repeated queries.

### How to Implement a Geohash in C-Sharp

see [Geohash.cs](../SystemDesign/Geohash.cs)

## Hyperloglog

### What is a Hyperloglog?

- Hyperloglog is a probabilistic algo used for counting the number of distinct elements (the cardinality) in a very large dataset.
- Unlike traditional methods that store every item to count unique values, Hyperloglog uses a small, fixed amount of memory to provide an estimate of the count.
- It sacrifices exact accuracy for memory efficiency and speed, which is acceptable in some real world scenarios where approximate count is enough.

## Why Is It Needed?

- **Memory Efficiency:**
  - When dealing with massive data steams (e.g., website visits, sensor data , logs), keeping every unique element in memory is impractical.
  - Hyperloglog allows you to estimate the number of distinct items using very little memory (often just a few kilobytes).

- **Speed:**
  - It processes each element in constant time (O(1)), making it ideal for high-throughput systems.

- **Scalability:**
  - It scales well with the size of the data. Even with billions of entries, the memory footprint remains small.

- **Use in Big Data and Streaming:**
  - In many applications (like counting unique visitors on a website or unique queries to a search engine), a precise count isn't necessary - a good estimate is sufficient for decision making.

### How Does It Work?

1. **Hashing the Data:**
   - Every incoming element is passed through a hash function that produces a 64-bit (or other size) hash value.
   - Hash functions convert items into a uniform random distribution of bits.

2. **Splitting the Hash:**
   - The hash is divided into two parts:
    - **Bucket Index:** The first few bits (determined by a parameter) determine which register (or bucket) to update.
    - **Remaining Bits:** The rest of the bits are used to determine the "rank," which is essentially the position of the first 1-bit in the hash.

3. **Counting Leading Zeros (Rank):**
   - For each bucket, the algo keeps track of the max number of leading zeros seen in the hash values assigned to that bucket.
   - A longer run of zeros suggests that there are more distinct elements mapping to that bucket.

4. **Aggregation and Estimation:**
   - After processing the data, Hyperloglog aggregates the information from all buckets.
   - It uses the harmonic mean of the recorded ranks (with some correction factors) to estimate the total number of unique elements.
   - Corrections are applied for small or very large cardinalities to improve the accuracy of the estimate.

### Use Cases

- **Web Analytics:**
  - Estimating the number of unique visitors to a website.
- **Database Query Optimization:**
  - Quickly approximating the number of unique keys in a large table to help with query planning.
- **Network Traffic Analysis:**
  - Counting the number of unique IP addresses passing through a router.
- **Log Analysis:**
  - Determining the number of unique error messages or events in a large log file.
- **Streaming Data:**
  - Applications that need real-time estimates (like monitoring unique user interactions in social media feeds) can use Hyperloglog due to its fast, constant-time operations.

